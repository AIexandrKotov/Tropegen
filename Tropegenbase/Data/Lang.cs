using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tropegenbase.Data
{
    public class Lang : ICloneable
    {
        public static string Get(string s) => Current.Strings.ContainsKey(s) ? Current.Strings[s] : s;

        public static readonly Lang Default;
        public readonly static Lang External;
        public static Lang Current;

        private static (string, bool, int)[] names;
        private static (string, int)[] surnames;

        public static string[] MaleNames;
        public static string[] FemaleNames;
        public static string[] Surnames;

        static int popsetnames, popsetsurnames = 0;
        public static int PopularSettingNames
        {
            get => popsetnames;
            set
            {
                popsetnames = value;
                RecountNames(popsetnames);
            }
        }
        public static int PopularSettingSurnames
        {
            get => popsetsurnames;
            set
            {
                popsetsurnames = value;
                RecountSurnames(popsetsurnames);
            }
        }
        public const int DefaultPopularSettingNames = 20000;
        public const int DefaultPopularSettingSurnames = 10000;

        static void RecountNames(int pop)
        {
            MaleNames = names.Where(x => x.Item2 && (x.Item3 >= pop)).Select(x => x.Item1).ToArray();
            FemaleNames = names.Where(x => !x.Item2 && (x.Item3 >= pop)).Select(x => x.Item1).ToArray();
        }

        static void RecountSurnames(int pop)
        {
            Surnames = surnames.Where(x => x.Item2 >= pop).Select(x => x.Item1).ToArray();
        }

        public static int Case(int a)
        {
            a %= 100;
            if (a > 20) a %= 10;
            else a %= 20;
            if (a == 0 || a >= 5) return 1;
            if (a == 1) return 2;
            return 3;
        }

        public string this[string key]
        {
            get => Get(key);
        }

        public object Clone()
        {
            var lang = new Lang();
            lang.Strings = new Dictionary<string, string>(Strings);
            return lang;
        }

        public Dictionary<string, string> Strings { get; internal set; } = new Dictionary<string, string>();

        static IEnumerable<string> ReadLines(Func<Stream> streamProvider, Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        static Lang ReadLang(Stream stream)
        {
            var lang = new Lang();
            using (var tr = new StreamReader(stream))
            {
                while (!tr.EndOfStream)
                {
                    var s = tr.ReadLine();
                    if (s.StartsWith("//") || string.IsNullOrWhiteSpace(s)) continue;

                    var splitter = s.IndexOf('=');
                    lang.Strings[s.Substring(0, splitter)] = s.Substring(splitter + 1, s.Length - splitter - 1);
                }
            }
            return lang;
        }

        static void ReadToLang(Lang lang, Stream stream)
        {
            using (var tr = new StreamReader(stream))
            {
                while (!tr.EndOfStream)
                {
                    var s = tr.ReadLine();
                    if (s.StartsWith("//") || string.IsNullOrWhiteSpace(s)) continue;

                    var splitter = s.IndexOf('=');
                    lang.Strings[s.Substring(0, splitter)] = s.Substring(splitter + 1, s.Length - splitter - 1);
                }
            }
        }

        public static readonly int
            MaxNames,
            MaxSurnames;

        static Lang()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Lang lang = new Lang();
            using (var stream = assembly.GetManifestResourceStream("Tropegenbase.Data.Lang.dat")) lang = ReadLang(stream);
            Default = lang;
            if (File.Exists("Lang.dat"))
            {
                External = (Lang)Default.Clone();
                using (var stream = File.OpenRead("Lang.dat")) ReadToLang(External, stream);
                Current = External;
            }
            else Current = Default;

            names = ReadLines(() => assembly.GetManifestResourceStream("Tropegenbase.Data.Names.dat"), Encoding.UTF8).ToName(x => x.Split(' ')[0], x => int.Parse(x.Split(' ')[2]), x => x.Split(' ')[1] == "M").ToArray();
            surnames = ReadLines(() => assembly.GetManifestResourceStream("Tropegenbase.Data.Surnames.dat"), Encoding.UTF8).ToSurname(x => x.Split(' ')[0], x => int.Parse(x.Split(' ')[1])).ToArray();
            PopularSettingNames = DefaultPopularSettingNames;
            PopularSettingSurnames = DefaultPopularSettingSurnames;
            MaxNames = Math.Min(names.Where(x => x.Item2).Max(x => x.Item3), names.Where(x => !x.Item2).Max(x => x.Item3));
            MaxSurnames = surnames.Max(x => x.Item2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tropegenbase.Data
{
    public class Lang
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

        public string this[string key]
        {
            get => Get(key);
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
                    lang.Strings.Add(s.Substring(0, splitter), s.Substring(splitter + 1, s.Length - splitter - 1));
                }
            }
            return lang;
        }

        static Lang()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Lang lang = new Lang();
            using (var stream = assembly.GetManifestResourceStream("Tropegenbase.Data.Lang.dat")) lang = ReadLang(stream);
            Default = lang;
            if (File.Exists("Lang.dat"))
            {
                using (var stream = File.OpenRead("Lang.dat")) External = ReadLang(stream);
                Current = External;
            }
            else Current = Default;

            names = ReadLines(() => assembly.GetManifestResourceStream("Tropegenbase.Data.Names.dat"), Encoding.GetEncoding(1251)).ToName(x => x.Split(' ')[0], x => int.Parse(x.Split(' ')[2]), x => x.Split(' ')[1] == "M").ToArray();
            surnames = ReadLines(() => assembly.GetManifestResourceStream("Tropegenbase.Data.Surnames.dat"), Encoding.GetEncoding(1251)).ToSurname(x => x.Split(' ')[0], x => int.Parse(x.Split(' ')[1])).ToArray();
            PopularSettingNames = DefaultPopularSettingNames;
            PopularSettingSurnames = DefaultPopularSettingSurnames;
        }
    }
}

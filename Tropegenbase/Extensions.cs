using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropegenbase
{
    public static class Extensions
    {
        public static string JoinIntoString<T>(this IEnumerable<T> e, string delim)
        {
            var g = e.GetEnumerator();
            var sb = new StringBuilder("");
            if (g.MoveNext())
            {
                sb.Append(g.Current.ToString());
                while (g.MoveNext()) sb.Append(delim + g.Current.ToString());
            }
            return sb.ToString();
        }

        public static string JoinIntoString<T>(this IEnumerable<T> e)
        {
            if (typeof(T) == typeof(char)) return e.JoinIntoString("");
            else return e.JoinIntoString(" ");
        }
        public static string Transleet(this string s)
        {
            s = s.Replace('а', 'a');
            s = s.Replace('б', 'b');
            throw new NotSupportedException();
        }

        public static T Random<T>(this T t, Random rnd) where T : Enum
        {
            return RandomEnum<T>(rnd);
        }

        public static T RandomEnum<T>(Random rnd) where T : Enum
        {
            return CachedEnum<T>.Random(rnd);
        }

        public static T Random<T>(this T[] s) => s[new Random().Next(s.Length)];
        public static T Random<T>(this T[] s, Random rnd) => s[rnd.Next(s.Length)];
        public static string Opis<T>(this T t) where T : Enum => $"{t.GetType().Lang()}: {t.Lang()}";
        public static string Lang(this string s) => Data.Lang.Current.Strings.ContainsKey(s) ? Data.Lang.Current.Strings[s] : s;
        public static string Lang(this Enum e) => Data.Lang.Current.Strings.ContainsKey($"{e.GetType().Name}.{e}") ? Data.Lang.Current[$"{e.GetType().Name}.{e}"] : e.ToString();
        public static string Lang(this Type t) => Data.Lang.Current.Strings.ContainsKey(t.FullName) ? Data.Lang.Current[t.FullName] : t.FullName;
        public static T ToEnum<T>(this string s) where T : Enum
        {
            return CachedEnum<T>.Parse(s);
        }

        internal static IEnumerable<(string, int)> ToSurname(this IEnumerable<string> surnames, Func<string, string> getname, Func<string, int> getcount)
        {
            return surnames.Select(x => (getname(x), getcount(x)));
        }
        internal static IEnumerable<(string, bool, int)> ToName(this IEnumerable<string> surnames, Func<string, string> getname, Func<string, int> getcount, Func<string, bool> getismale)
        {
            return surnames.Select(x => (getname(x), getismale(x), getcount(x)));
        }
        public static void DoWithAllDescendants(this System.Xml.XmlReader xmlReader, string brahchname, Action<System.Xml.XmlReader> action)
        {
            xmlReader.ReadToDescendant(brahchname);
            do
            {
                action(xmlReader);
            }
            while (xmlReader.ReadToFollowing(brahchname));
        }

        private static System.Resources.ResourceManager mscorlibresources = new System.Resources.ResourceManager("mscorlib", typeof(object).Assembly);
        private static string ErrorStringFromResource(string s)
        {
            return mscorlibresources.GetString(s);
        }
        public static sbyte ToSByte(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var Result = (c - 48);
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > sbyte.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_SByte"));
                Result = Result * 10 + (c - 48);
                j += 1;
            }
            if (Result < 0)
            {
                if (Result == sbyte.MinValue && sign == -1) return (sbyte)Result;
                else throw new OverflowException(ErrorStringFromResource("Overflow_SByte"));
            }
            if (sign == -1)
            {
                Result = -Result;
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return (sbyte)Result;
        }
        public static short ToInt16(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var Result = (c - 48);
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > short.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_Int16"));
                Result = (short)(Result * 10 + (c - 48));
                j += 1;
            }
            if (Result < 0)
            {
                if (Result == short.MinValue && sign == -1) return (short)Result;
                else throw new OverflowException(ErrorStringFromResource("Overflow_Int16"));
            }
            if (sign == -1)
            {
                Result = -Result;
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return (short)Result;
        }
        public static int ToInt32(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var Result = c - 48;
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > int.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_Int32"));
                Result = Result * 10 + (c - 48);
                j += 1;
            }
            if (Result < 0)
            {
                if (Result == int.MinValue && sign == -1) return Result;
                else throw new OverflowException(ErrorStringFromResource("Overflow_Int32"));
            }
            if (sign == -1)
            {
                Result = -Result;
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return Result;
        }
        public static long ToInt64(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            long Result = c - 48;
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > long.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_Int64"));
                Result = Result * 10 + (c - 48);
                j += 1;
            }
            if (Result < 0)
            {
                if (Result == long.MinValue && sign == -1) return Result;
                else throw new OverflowException(ErrorStringFromResource("Overflow_Int64"));
            }
            if (sign == -1)
            {
                Result = -Result;
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return Result;
        }
        public static byte ToByte(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var Result = (c - 48);
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > byte.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_Byte"));
                Result = Result * 10 + (c - 48);
                j += 1;
            }
            if (Result < 0)
            {
                throw new OverflowException(ErrorStringFromResource("Overflow_Byte"));
            }
            if (sign == -1)
            {
                throw new OverflowException(ErrorStringFromResource("Overflow_Byte"));
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return (byte)Result;
        }
        public static ushort ToUInt16(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var Result = (c - 48);
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > ushort.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_UInt16"));
                Result = (ushort)(Result * 10 + (c - 48));
                j += 1;
            }
            if (Result < 0)
            {
                throw new OverflowException(ErrorStringFromResource("Overflow_UInt16"));
            }
            if (sign == -1)
            {
                Result = -Result;
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return (ushort)Result;
        }
        public static uint ToUInt32(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            long Result = (c - 48);
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > int.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_UInt32"));
                Result = (Result * 10 + (c - 48));
                j += 1;
            }
            if (Result < 0)
            {
                if (Result == int.MinValue && sign == -1) return (uint)Result;
                else throw new OverflowException(ErrorStringFromResource("Overflow_UInt32"));
            }
            if (sign == -1)
            {
                Result = -Result;
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return (uint)Result;
        }
        public static ulong ToUInt64(this string s)
        {
            var j = 1;
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1])) j += 1;
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var sign = 0;
            if (s[j - 1] == '-')
            {
                sign = -1;
                j += 1;
            }
            else if (s[j - 1] == '+')
            {
                sign = 1;
                j += 1;
            }
            if (j > s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var c = (int)s[j - 1];
            if (c < 48 || c > 57) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            var Result = (ulong)c - 48;
            j += 1;
            while (j <= s.Length)
            {
                c = (int)s[j - 1];
                if (c > 57) break;
                if (c < 48) break;
                if (Result > ulong.MaxValue) throw new OverflowException(ErrorStringFromResource("Overflow_UInt64"));
                Result = (ulong)(Result * 10 + (ulong)(c - 48));
                j += 1;
            }
            if (sign == -1)
            {
                throw new OverflowException(ErrorStringFromResource("Overflow_UInt64"));
            }
            while (j <= s.Length && char.IsWhiteSpace(s[j - 1]))
            {
                j += 1;
            }
            if (j < s.Length) throw new FormatException(ErrorStringFromResource("Format_InvalidString"));
            return Result;
        }
        public static float ToFloat(this string s) => float.Parse(s);
        public static double ToDouble(this string s) => double.Parse(s);
        public static bool ToBool(this string s) => bool.Parse(s);
    }
}

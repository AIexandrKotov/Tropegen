using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropegenbase
{
    public static class CachedEnum<T> where T: Enum
    {
        public static readonly Type Type = typeof(T);
        public static readonly string[] Names = Enum.GetNames(Type);
        public static readonly int[] Values = (int[])Enum.GetValues(Type);
        public static readonly T[] Enums = Array.ConvertAll(Values, x => (T)Enum.ToObject(Type, x));
        public static readonly Dictionary<string, T> Dict = Names.ToDictionary(x => x, x => (T)Enum.Parse(Type, x));
        public static T Parse(string s)
        {
            return Dict[s];
        }

        public static T Random(Random rnd)
        {
            if (RandomationLaw<T>.IsLawDefined()) return RandomationLaw<T>.Random(rnd);
            else return Enums[rnd.Next(Enums.Length)];
        }
    }
}

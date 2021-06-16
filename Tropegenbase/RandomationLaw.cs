using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropegenbase.Characters;
using Tropegenbase.Data;

namespace Tropegenbase
{
    static class RandomationLawHelper
    {
        static List<Type> types = new List<Type>();
        public static Type[] Types;

        public static Dictionary<Type, Func<Random, Enum>> RandomationFuncs = new Dictionary<Type, Func<Random, Enum>>();

        static void add(Type t, Func<Random, Enum> f)
        {
            types.Add(t);
            RandomationFuncs.Add(t, f);
        }

        static RandomationLawHelper()
        {
            add(CachedEnum<Archetypes.AgeType>.Type, Defaults.RandomLaw_AgeType);
            add(CachedEnum<Archetypes.Morality>.Type, Defaults.RandomLaw_Morality);
            add(CachedEnum<Archetypes.Protest>.Type, Defaults.RandomLaw_Protest);
            add(CachedEnum<Archetypes.Political>.Type, Defaults.RandomLaw_Political);
            Types = types.ToArray();
        }
    }

    public static class RandomationLaw<T> where T : Enum
    {
        public class PercentLaw
        {
            PercentLawNode[] lawNodes;
            private List<(double, T)> l1;
            private List<(double, double, T)> l2;

            public PercentLaw()
            {
                l1 = new List<(double, T)>();
                l2 = new List<(double, double, T)>();
            }

            public void Add((double, T) x)
            {
                l1.Add(x);
            }

            public void Add((double, double, T) x)
            {
                l2.Add(x);
            }

            public void Init()
            {
                if (l1.Any())
                {
                    var arr = l1.ToArray();
                    var right = 0D;
                    lawNodes = new PercentLawNode[arr.Length];
                    for (var i = 0; i < arr.Length; i++)
                    {
                        lawNodes[i] = new PercentLawNode(right, right + arr[i].Item1, arr[i].Item2);
                        right += arr[i].Item1;
                    }
                }
                else if (l2.Any())
                {
                    lawNodes = l2.Select(x => new PercentLawNode(x.Item1, x.Item2, x.Item3)).ToArray();
                }
                else throw new Exception();
                l1 = null;
                l2 = null;
            }

            public PercentLaw(params (double, double, T)[] arr)
            {
                lawNodes = arr.Select(x => new PercentLawNode(x.Item1, x.Item2, x.Item3)).ToArray();
            }

            public PercentLaw(params (double, T)[] arr)
            {
                var right = 0D;
                lawNodes = new PercentLawNode[arr.Length];
                for (var i = 0; i < arr.Length; i++)
                {
                    lawNodes[i] = new PercentLawNode(right, right + arr[i].Item1, arr[i].Item2);
                    right += arr[i].Item1;
                }
            }

            public T Get(double d)
            {
                for (var i = 0; i < lawNodes.Length; i++)
                {
                    if (d >= lawNodes[i].Left && d < lawNodes[i].Right) return lawNodes[i].Value;
                }
                return default;
            }
        }

        struct PercentLawNode
        {
            public double Left;
            public double Right;
            public T Value;

            public PercentLawNode(double l, double r, T t)
            {
                Left = l;
                Right = r;
                Value = t;
            }
        }

        public static bool IsLawDefined()
        {
            var tp = CachedEnum<T>.Type;
            if (RandomationLawHelper.Types.Contains(tp)) return true;
            return false;
        }

        public static T Random(Random rnd)
        {
            return (T)RandomationLawHelper.RandomationFuncs[CachedEnum<T>.Type].Invoke(rnd);
        }
    }

}

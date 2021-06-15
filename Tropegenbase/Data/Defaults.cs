using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Tropegenbase.Characters.Archetypes;

namespace Tropegenbase.Data
{
    public class Defaults
    {
        #region AgeTypeLaw
        public enum AgeTypeLaw
        {
            All,
        }

        static Dictionary<AgeTypeLaw, RandomationLaw<AgeType>.PercentLaw> agetypelaw = new Dictionary<AgeTypeLaw, RandomationLaw<AgeType>.PercentLaw>();
        private static AgeTypeLaw _atl = AgeTypeLaw.All;
        public static AgeTypeLaw CurrentAgeTypeRandomLaw
        {
            get => _atl;
            set => _atl = value;
        }
        internal static Enum RandomLaw_AgeType(Random rnd) => agetypelaw[_atl].Get(rnd.NextDouble());
        #endregion

        #region XmlRead

        static void ReadXmlFile(Stream stream)
        {
            var xdoc = new XmlDocument();
            xdoc.Load(stream);
            var xroot = xdoc.DocumentElement;
            foreach (XmlElement rndlaws in xroot.ChildNodes)
            {
                switch (rndlaws.Name)
                {
                    case "AgeTypeRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<AgeTypeLaw>();
                                var x = new RandomationLaw<AgeType>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<AgeType>()));
                                }
                                x.Init();
                                agetypelaw.Add(value, x);
                            }
                        }
                        break;
                }
            }
        }

        internal static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (File.Exists("Defaults.xml"))
            {
                using (var s = File.OpenRead("Defaults.xml")) ReadXmlFile(s);
            }
            else
            {
                using (var s = assembly.GetManifestResourceStream("Tropegenbase.Data.Defaults.xml")) ReadXmlFile(s);
            }
        }

        static Defaults()
        {
            Init();
        }
        #endregion
    }
}

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
            Normal,
        }

        static Dictionary<AgeTypeLaw, RandomationLaw<AgeType>.PercentLaw> agetypelaw = new Dictionary<AgeTypeLaw, RandomationLaw<AgeType>.PercentLaw>();
        private static AgeTypeLaw _atl = AgeTypeLaw.Normal;
        public static AgeTypeLaw CurrentAgeTypeRandomLaw
        {
            get => _atl;
            set => _atl = value;
        }
        internal static Enum RandomLaw_AgeType(Random rnd) => agetypelaw[_atl].Get(rnd.NextDouble());
        #endregion

        #region MoralityLaw
        public enum MoralityLaw
        {
            All,
            Normal,
        }

        static Dictionary<MoralityLaw, RandomationLaw<Morality>.PercentLaw> moralitylaw = new Dictionary<MoralityLaw, RandomationLaw<Morality>.PercentLaw>();
        private static MoralityLaw _mrl = MoralityLaw.All;
        public static MoralityLaw CurrentMoralityRandomLaw
        {
            get => _mrl;
            set => _mrl = value;
        }
        internal static Enum RandomLaw_Morality(Random rnd) => moralitylaw[_mrl].Get(rnd.NextDouble());
        #endregion

        #region ProtestLaw
        public enum ProtestLaw
        {
            All,
        }

        static Dictionary<ProtestLaw, RandomationLaw<Protest>.PercentLaw> protestlaw = new Dictionary<ProtestLaw, RandomationLaw<Protest>.PercentLaw>();
        private static ProtestLaw _prtl = ProtestLaw.All;
        public static ProtestLaw CurrentProtestRandomLaw
        {
            get => _prtl;
            set => _prtl = value;
        }
        internal static Enum RandomLaw_Protest(Random rnd) => protestlaw[_prtl].Get(rnd.NextDouble());
        #endregion

        #region PoliticalLaw
        public enum PoliticalLaw
        {
            All,
        }

        static Dictionary<PoliticalLaw, RandomationLaw<Political>.PercentLaw> politicallaw = new Dictionary<PoliticalLaw, RandomationLaw<Political>.PercentLaw>();
        private static PoliticalLaw _pol = PoliticalLaw.All;
        public static PoliticalLaw CurrentPoliticalRandomLaw
        {
            get => _pol;
            set => _pol = value;
        }
        internal static Enum RandomLaw_Political(Random rnd) => politicallaw[_pol].Get(rnd.NextDouble());
        #endregion

        #region PhysicalPowerLaw
        public enum PhysicalPowerLaw
        {
            All,
        }

        static Dictionary<PhysicalPowerLaw, RandomationLaw<PhysicalPower>.PercentLaw> physicalpowerlaw = new Dictionary<PhysicalPowerLaw, RandomationLaw<PhysicalPower>.PercentLaw>();
        private static PhysicalPowerLaw _ppl = PhysicalPowerLaw.All;
        public static PhysicalPowerLaw CurrentPhysicalPowerRandomLaw
        {
            get => _ppl;
            set => _ppl = value;
        }
        internal static Enum RandomLaw_PhysicalPower(Random rnd) => physicalpowerlaw[_ppl].Get(rnd.NextDouble());
        #endregion

        #region MagicPowerLaw
        public enum MagicPowerLaw
        {
            All,
        }

        static Dictionary<MagicPowerLaw, RandomationLaw<MagicPower>.PercentLaw> magicpowerlaw = new Dictionary<MagicPowerLaw, RandomationLaw<MagicPower>.PercentLaw>();
        private static MagicPowerLaw _mpl = MagicPowerLaw.All;
        public static MagicPowerLaw CurrentMagicPowerRandomLaw
        {
            get => _mpl;
            set => _mpl = value;
        }
        internal static Enum RandomLaw_MagicPower(Random rnd) => magicpowerlaw[_mpl].Get(rnd.NextDouble());
        #endregion

        #region WillPowerLaw
        public enum WillPowerLaw
        {
            All,
        }

        static Dictionary<WillPowerLaw, RandomationLaw<WillPower>.PercentLaw> willpowerlaw = new Dictionary<WillPowerLaw, RandomationLaw<WillPower>.PercentLaw>();
        private static WillPowerLaw _wpl = WillPowerLaw.All;
        public static WillPowerLaw CurrentWillPowerRandomLaw
        {
            get => _wpl;
            set => _wpl = value;
        }
        internal static Enum RandomLaw_WillPower(Random rnd) => willpowerlaw[_wpl].Get(rnd.NextDouble());
        #endregion

        #region StaminaLaw
        public enum StaminaLaw
        {
            All,
        }

        static Dictionary<StaminaLaw, RandomationLaw<Stamina>.PercentLaw> staminalaw = new Dictionary<StaminaLaw, RandomationLaw<Stamina>.PercentLaw>();
        private static StaminaLaw _sl = StaminaLaw.All;
        public static StaminaLaw CurrentStaminaRandomLaw
        {
            get => _sl;
            set => _sl = value;
        }
        internal static Enum RandomLaw_Stamina(Random rnd) => staminalaw[_sl].Get(rnd.NextDouble());
        #endregion

        #region IntellectLaw
        public enum IntellectLaw
        {
            All,
        }

        static Dictionary<IntellectLaw, RandomationLaw<Intellect>.PercentLaw> intellectlaw = new Dictionary<IntellectLaw, RandomationLaw<Intellect>.PercentLaw>();
        private static IntellectLaw _il = IntellectLaw.All;
        public static IntellectLaw CurrentIntellectRandomLaw
        {
            get => _il;
            set => _il = value;
        }
        internal static Enum RandomLaw_Intellect(Random rnd) => intellectlaw[_il].Get(rnd.NextDouble());
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
                    case "MoralityRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<MoralityLaw>();
                                var x = new RandomationLaw<Morality>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<Morality>()));
                                }
                                x.Init();
                                moralitylaw.Add(value, x);
                            }
                        }
                        break;
                    case "ProtestRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<ProtestLaw>();
                                var x = new RandomationLaw<Protest>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<Protest>()));
                                }
                                x.Init();
                                protestlaw.Add(value, x);
                            }
                        }
                        break;
                    case "PoliticalRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<PoliticalLaw>();
                                var x = new RandomationLaw<Political>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<Political>()));
                                }
                                x.Init();
                                politicallaw.Add(value, x);
                            }
                        }
                        break;
                    case "PhysicalPowerRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<PhysicalPowerLaw>();
                                var x = new RandomationLaw<PhysicalPower>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<PhysicalPower>()));
                                }
                                x.Init();
                                physicalpowerlaw.Add(value, x);
                            }
                        }
                        break;

                    case "MagicPowerRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<MagicPowerLaw>();
                                var x = new RandomationLaw<MagicPower>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<MagicPower>()));
                                }
                                x.Init();
                                magicpowerlaw.Add(value, x);
                            }
                        }
                        break;

                    case "WillPowerRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<WillPowerLaw>();
                                var x = new RandomationLaw<WillPower>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<WillPower>()));
                                }
                                x.Init();
                                willpowerlaw.Add(value, x);
                            }
                        }
                        break;

                    case "StaminaRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<StaminaLaw>();
                                var x = new RandomationLaw<Stamina>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<Stamina>()));
                                }
                                x.Init();
                                staminalaw.Add(value, x);
                            }
                        }
                        break;

                    case "IntellectRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<IntellectLaw>();
                                var x = new RandomationLaw<Intellect>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<Intellect>()));
                                }
                                x.Init();
                                intellectlaw.Add(value, x);
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

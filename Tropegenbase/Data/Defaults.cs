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

        public const AgeTypeLaw DefaultAgeTypeRandomLaw = AgeTypeLaw.All;
        static Dictionary<AgeTypeLaw, RandomationLaw<AgeType>.PercentLaw> agetypelaw = new Dictionary<AgeTypeLaw, RandomationLaw<AgeType>.PercentLaw>();
        private static AgeTypeLaw _atl = DefaultAgeTypeRandomLaw;
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

        public const MoralityLaw DefaultMoralityRandomLaw = MoralityLaw.All;
        static Dictionary<MoralityLaw, RandomationLaw<Morality>.PercentLaw> moralitylaw = new Dictionary<MoralityLaw, RandomationLaw<Morality>.PercentLaw>();
        private static MoralityLaw _mrl = DefaultMoralityRandomLaw;
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

        public const ProtestLaw DefaultProtestRandomLaw = ProtestLaw.All;
        static Dictionary<ProtestLaw, RandomationLaw<Protest>.PercentLaw> protestlaw = new Dictionary<ProtestLaw, RandomationLaw<Protest>.PercentLaw>();
        private static ProtestLaw _prtl = DefaultProtestRandomLaw;
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

        public const PoliticalLaw DefaultPoliticalRandomLaw = PoliticalLaw.All;
        static Dictionary<PoliticalLaw, RandomationLaw<Political>.PercentLaw> politicallaw = new Dictionary<PoliticalLaw, RandomationLaw<Political>.PercentLaw>();
        private static PoliticalLaw _pol = DefaultPoliticalRandomLaw;
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

        public const PhysicalPowerLaw DefaultPhysicalPowerRandomLaw = PhysicalPowerLaw.All;
        static Dictionary<PhysicalPowerLaw, RandomationLaw<PhysicalPower>.PercentLaw> physicalpowerlaw = new Dictionary<PhysicalPowerLaw, RandomationLaw<PhysicalPower>.PercentLaw>();
        private static PhysicalPowerLaw _ppl = DefaultPhysicalPowerRandomLaw;
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

        public const MagicPowerLaw DefaultMagicPowerRandomLaw = MagicPowerLaw.All;
        static Dictionary<MagicPowerLaw, RandomationLaw<MagicPower>.PercentLaw> magicpowerlaw = new Dictionary<MagicPowerLaw, RandomationLaw<MagicPower>.PercentLaw>();
        private static MagicPowerLaw _mpl = DefaultMagicPowerRandomLaw;
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
        
        public const WillPowerLaw DefaultWillPowerRandomLaw = WillPowerLaw.All;
        static Dictionary<WillPowerLaw, RandomationLaw<WillPower>.PercentLaw> willpowerlaw = new Dictionary<WillPowerLaw, RandomationLaw<WillPower>.PercentLaw>();
        private static WillPowerLaw _wpl = DefaultWillPowerRandomLaw;
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

        public const StaminaLaw DefaultStaminaRandomLaw = StaminaLaw.All;
        static Dictionary<StaminaLaw, RandomationLaw<Stamina>.PercentLaw> staminalaw = new Dictionary<StaminaLaw, RandomationLaw<Stamina>.PercentLaw>();
        private static StaminaLaw _sl = DefaultStaminaRandomLaw;
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

        public const IntellectLaw DefaultIntellectRandomLaw = IntellectLaw.All;
        static Dictionary<IntellectLaw, RandomationLaw<Intellect>.PercentLaw> intellectlaw = new Dictionary<IntellectLaw, RandomationLaw<Intellect>.PercentLaw>();
        private static IntellectLaw _il = DefaultIntellectRandomLaw;
        public static IntellectLaw CurrentIntellectRandomLaw
        {
            get => _il;
            set => _il = value;
        }
        internal static Enum RandomLaw_Intellect(Random rnd) => intellectlaw[_il].Get(rnd.NextDouble());
        #endregion        
        
        #region HeightTypeLaw
        public enum HeightTypeLaw
        {
            All,
        }

        public const HeightTypeLaw DefaultHeightTypeRandomLaw = HeightTypeLaw.All;
        static Dictionary<HeightTypeLaw, RandomationLaw<HeightType>.PercentLaw> heighttypelaw = new Dictionary<HeightTypeLaw, RandomationLaw<HeightType>.PercentLaw>();
        private static HeightTypeLaw _htl = DefaultHeightTypeRandomLaw;
        public static HeightTypeLaw CurrentHeightTypeRandomLaw
        {
            get => _htl;
            set => _htl = value;
        }
        internal static Enum RandomLaw_HeightType(Random rnd) => heighttypelaw[_htl].Get(rnd.NextDouble());
        #endregion

        #region EyesColorLaw
        public enum EyesColorLaw
        {
            All,
        }

        public const EyesColorLaw DefaultEyesColorRandomLaw = EyesColorLaw.All;
        static Dictionary<EyesColorLaw, RandomationLaw<EyesColor>.PercentLaw> eyescolorlaw = new Dictionary<EyesColorLaw, RandomationLaw<EyesColor>.PercentLaw>();
        private static EyesColorLaw _ecl = DefaultEyesColorRandomLaw;
        public static EyesColorLaw CurrentEyesColorRandomLaw
        {
            get => _ecl;
            set => _ecl = value;
        }
        internal static Enum RandomLaw_EyesColor(Random rnd) => eyescolorlaw[_ecl].Get(rnd.NextDouble());
        #endregion


        #region Other
        static (int, int, double, double)[] AHM;
        public static double GetAgeHeightDecrease(int age)
        {
            for (var i = 0; i < AHM.Length; i++)
            {
                if (age >= AHM[i].Item1 && age < AHM[i].Item2)
                {
                    return (float)((age - AHM[i].Item1) / ((double)AHM[i].Item2 - AHM[i].Item1) * (AHM[i].Item4 - AHM[i].Item3) + AHM[i].Item3);
                }
            }
            return 1.0;
        }
        public static double WomanDecrease { get; private set; }
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
                    case "AgeHeights":
                        {
                            WomanDecrease = rndlaws.GetAttribute("womandecreaser").ToDouble();
                            var ahm = new List<(int, int, double, double)>();
                            foreach (XmlElement ageheight in rndlaws)
                            {
                                ahm.Add((ageheight.GetAttribute("leftvalue").ToInt32(), ageheight.GetAttribute("rightvalue").ToInt32(), ageheight.GetAttribute("modifierleft").ToDouble(), ageheight.GetAttribute("modifierright").ToDouble()));
                            }
                            AHM = ahm.ToArray();
                        }
                        break;
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
                    case "HeightTypeRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<HeightTypeLaw>();
                                var x = new RandomationLaw<HeightType>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<HeightType>()));
                                }
                                x.Init();
                                heighttypelaw.Add(value, x);
                            }
                        }
                        break;
                    case "EyesColorRandomLaws":
                        {
                            foreach (XmlElement rndlaw in rndlaws)
                            {
                                var value = rndlaw.GetAttribute("law").ToEnum<EyesColorLaw>();
                                var x = new RandomationLaw<EyesColor>.PercentLaw();
                                foreach (XmlElement val in rndlaw)
                                {
                                    x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<EyesColor>()));
                                }
                                x.Init();
                                eyescolorlaw.Add(value, x);
                            }
                        }
                        break;

                }
            }
        }

        internal static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var s = assembly.GetManifestResourceStream("Tropegenbase.Data.Defaults.xml")) ReadXmlFile(s);
            if (File.Exists("Defaults.xml")) using (var s = File.OpenRead("Defaults.xml")) ReadXmlFile(s);
        }

        static Defaults()
        {
            Init();
        }
        #endregion
    }
}

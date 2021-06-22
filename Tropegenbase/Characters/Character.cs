using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tropegenbase.Data;

namespace Tropegenbase.Characters
{
    /// <summary>
    /// Персонаж
    /// </summary>
    public class Character : ICloneable
    {
        /// <summary>
        /// Ключ генерации использованный при создании этого персонажа
        /// </summary>
        public int Seed { get; set; }
        public bool Generated { get; set; }

        #region Title
        public Archetypes.BiologicalGender Gender { get; set; }
        public Archetypes.AgeType AgeType { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);
        public string Name { get; set; } = "Name";
        public string Surname { get; set; } = "Surname";
        #endregion

        #region Person
        public Archetypes.Morality Morality { get; set; }
        public Archetypes.Changes[] MoralityFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.Ethical Ethical { get; set; }
        public Archetypes.Changes[] EthicalFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.Ego Ego { get; set; }
        public Archetypes.Changes[] EgoFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.Idea Idea { get; set; }
        public Archetypes.Changes[] IdeaFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.Protest Protest { get; set; }
        public Archetypes.Political Political { get; set; }
        public Archetypes.Empathy Empathy { get; set; }
        public Archetypes.Emotional Emotional { get; set; }
        #endregion

        #region Appearance
        public Archetypes.HeightType HeightType { get; set; }
        public int Height { get; set; } = 180;
        public Archetypes.EyesColor EyesColor { get; set; }
        public Archetypes.HairColor HairColor { get; set; }
        public Archetypes.HairLength HairLength { get; set; }
        public Archetypes.BeautyType BeautyType { get; set; }
        public Color HairColorRGB { get; set; } = Color.Red;
        public Archetypes.Physique Physique { get; set; }
        public Archetypes.PhysiqueStatus PhysiqueStatus { get; set; }
        /// <summary>
        /// 1 = 0.1 кг
        /// </summary>
        public int Weight { get; set; } = 750;
        public double Fat { get; set; }
        public double Muscles { get; set; }
        #endregion

        #region Social
        public Archetypes.SocialStatus SocialStatus { get; set; }
        public Archetypes.Sexuality Sexuality { get; set; }
        public Archetypes.Responsibility Responsibility { get; set; }
        public Archetypes.Loyalty Loyalty { get; set; }
        public Archetypes.Adaptability Adaptability { get; set; }
        public Archetypes.FaithInPeople TrustInPeople { get; set; }
        public Archetypes.Humour Humour { get; set; }
        #endregion

        #region Forces
        public Archetypes.PhysicalPower PhysicalPower { get; set; }
        public Archetypes.Changes[] PhysicalPowerFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.MagicPower MagicPower { get; set; }
        public Archetypes.Changes[] MagicPowerFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.WillPower WillPower { get; set; }
        public Archetypes.Changes[] WillPowerFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.Stamina Stamina { get; set; }
        public Archetypes.Changes[] StaminaFuture { get; set; } = new Archetypes.Changes[5];

        public Archetypes.Intellect Intellect { get; set; }
        public Archetypes.Changes[] IntellectFuture { get; set; } = new Archetypes.Changes[5];
        #endregion

        #region IntegeredPower
        public double PercentPhysicalPower => NotMoreOne(GetPower((int)PhysicalPower) * GetFuturePower(PhysicalPowerFuture) / 250.0);
        public double PercentMagicPower => NotMoreOne(GetPower((int)MagicPower) * GetFuturePower(MagicPowerFuture) / 250.0);
        public double PercentWillPower => NotMoreOne(GetPower((int)WillPower) * GetFuturePower(WillPowerFuture) / 250.0);
        public double PercentStamina => NotMoreOne(GetPower((int)Stamina) * GetFuturePower(StaminaFuture) / 250.0);
        public double PercentIntellect => NotMoreOne(GetPower((int)Intellect) * GetFuturePower(IntellectFuture) / 250.0);

        int GetPower(int a)
        {
            switch (a)
            {
                case 0: return 50;
                case 1: return 75;
                case 2: return 100;
                case 3: return 150;
                case 4: return 200;
            }
            return 100;
        }

        double NotMoreOne(double d)
        {
            if (d > 1.0) return 1.0;
            else return d;
        }

        double GetFuturePower(Archetypes.Changes[] a)
        {
            var rslt = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == 0) rslt += 3;
                if ((int)a[i] == 1) rslt += 1;
                if ((int)a[i] == 3) rslt -= 1;
                if ((int)a[i] == 4) rslt -= 3;
            }
            return (rslt) / 15.0 + 1.0;
        }
        #endregion

        public string Fate { get; set; } = string.Empty;

        public void RandomName(Random seed)
        {
            Name = Gender == Archetypes.BiologicalGender.Male ? Lang.MaleNames.Random(seed) : Lang.FemaleNames.Random(seed);
        }

        public void RandomSurname(Random seed)
        {
            Surname = Lang.Surnames.Random(seed);
        }

        public void RandomBirthDate(Random seed)
        {
            BirthDate = new DateTime(2000, 1, 1).AddDays(seed.NextDouble() * 366);
        }

        public void RandomHairColor(Random seed)
        {
            var bs = new byte[3];
            seed.NextBytes(bs);
            HairColorRGB = Color.FromArgb(bs[0], bs[1], bs[2]);
        }

        public void RandomSocial(Random seed)
        {
            SocialStatus = SocialStatus.Random(seed);
            Sexuality = Sexuality.Random(seed);
            Responsibility = Responsibility.Random(seed);
            Loyalty = Loyalty.Random(seed);
            Adaptability = Adaptability.Random(seed);
            TrustInPeople = TrustInPeople.Random(seed);
            Humour = Humour.Random(seed);
        }

        public void RandomationAppearance1(Random Seed)
        {
            RandomationHeight(Seed);
            RandomationPhysique(Seed);
        }

        public void RandomationAppearance2(Random Seed)
        {
            EyesColor = EyesColor.Random(Seed);
            HairColor = HairColor.Random(Seed);
            if (HairColor == Archetypes.HairColor.Artificial_Coloring) RandomHairColor(Seed);
            HairLength = HairLength.Random(Seed);
            BeautyType = BeautyType.Random(Seed);
        }

        public void RandomationPerson(Random Seed)
        {
            Morality = Morality.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, MoralityFuture);

            Ethical = Ethical.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, EthicalFuture);

            Ego = Ego.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, EgoFuture);

            Idea = Idea.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, IdeaFuture);

            Protest = Protest.Random(Seed);
            Political = Political.Random(Seed);
            Empathy = Empathy.Random(Seed);
            Emotional = Emotional.Random(Seed);
        }

        public void RandomationForces(Random Seed)
        {
            PhysicalPower = PhysicalPower.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, PhysicalPowerFuture);

            MagicPower = MagicPower.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, MagicPowerFuture);

            WillPower = WillPower.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, WillPowerFuture);

            Stamina = Stamina.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, StaminaFuture);

            Intellect = Intellect.Random(Seed);
            CharacterBuilder.GenerateFiveChanges(Seed, IntellectFuture);
        }

        public void RandomationHeight(Random Seed)
        {
            HeightType = HeightType.Random(Seed);
            switch (HeightType)
            {
                case Archetypes.HeightType.Small:
                    {
                        Height = Seed.Next(170, 180);
                    }
                    break;
                case Archetypes.HeightType.Ordinary:
                    {
                        Height = Seed.Next(180, 190);
                    }
                    break;
                case Archetypes.HeightType.Big:
                    {
                        Height = Seed.Next(190, 210);
                    }
                    break;
            }
            Height = (int)(Height * Defaults.GetAgeHeightDecrease(Age) * (Gender == Archetypes.BiologicalGender.Female ? Defaults.WomanDecrease : 1.0));
        }

        public void RandomationPhysique(Random Seed)
        {
            Physique = Physique.Random(Seed);
            PhysiqueStatus = PhysiqueStatus.Random(Seed);

            switch (Physique)
            {
                case Archetypes.Physique.Ektomorph:
                    {
                        switch (PhysiqueStatus)
                        {
                            case Archetypes.PhysiqueStatus.Small:
                                {
                                    Weight = Seed.Next(500, 600);
                                    Fat = Seed.NextDouble(0.05, 0.1);
                                    Muscles = Seed.NextDouble(0, 0.05);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Ordinary:
                                {
                                    Weight = Seed.Next(500, 600);
                                    Fat = Seed.NextDouble(0.05, 0.1);
                                    Muscles = Seed.NextDouble(0.05, 0.15);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Big:
                                {
                                    Weight = Seed.Next(600, 700);
                                    Fat = Seed.NextDouble(0.05, 0.1);
                                    Muscles = Seed.NextDouble(0.15, 0.25);
                                }
                                break;
                        }
                    }
                    break;
                case Archetypes.Physique.Endomorph:
                    {
                        switch (PhysiqueStatus)
                        {
                            case Archetypes.PhysiqueStatus.Small:
                                {
                                    Weight = Seed.Next(700, 800);
                                    Fat = Seed.NextDouble(0.1, 0.15);
                                    Muscles = Seed.NextDouble(0, 0.1);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Ordinary:
                                {
                                    Weight = Seed.Next(800, 900);
                                    Fat = Seed.NextDouble(0.15, 0.25);
                                    Muscles = Seed.NextDouble(0.05, 0.25);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Big:
                                {
                                    Weight = Seed.Next(900, 1200);
                                    Fat = Seed.NextDouble(0.25, 0.75);
                                    Muscles = Seed.NextDouble(0, 0.1);
                                }
                                break;
                        }
                    }
                    break;
                case Archetypes.Physique.Mesomorph:
                    {
                        switch (PhysiqueStatus)
                        {
                            case Archetypes.PhysiqueStatus.Small:
                                {
                                    Weight = Seed.Next(700, 800);
                                    Fat = Seed.NextDouble(0.1, 0.15);
                                    Muscles = Seed.NextDouble(0.15, 0.25);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Ordinary:
                                {
                                    Weight = Seed.Next(800, 1000);
                                    Fat = Seed.NextDouble(0.1, 0.15);
                                    Muscles = Seed.NextDouble(0.25, 0.35);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Big:
                                {
                                    Weight = Seed.Next(1000, 1200);
                                    Fat = Seed.NextDouble(0.1, 0.15);
                                    Muscles = Seed.NextDouble(0.45, 0.65);
                                }
                                break;
                        }
                    }
                    break;
            }
            Weight = (int)(Weight * Math.Pow(Height / 180.0, 1.25));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Lang()}: {Name} {Surname}");
            sb.AppendLine($" {Gender.Opis()}");
            sb.Append($" {AgeType.Opis()}");
            sb.AppendLine($" ({Age} {Lang.Get($"years{Lang.Case(Age)}")})");
            sb.AppendLine($" {Lang.Get("birthdate")}: {BirthDate.Day} {Lang.Get($"Month{BirthDate.Month}")}");
            sb.AppendLine();
            sb.AppendLine(Lang.Current["Appearance"] + ":");
            sb.AppendLine($" {Lang.Get("Height")}: {Height} {Lang.Get("cm")}");
            sb.AppendLine($" {Lang.Get("Weight")}: {Weight / 10.0} {Lang.Get("kg")} ({Fat.Percent()} {Lang.Get("Fat")}, {Muscles.Percent()} {Lang.Get("Muscles")})");
            sb.AppendLine($" {EyesColor.Opis()}");
            sb.AppendLine($" {HairColor.Opis()}");
            sb.AppendLine($" {HairLength.Opis()}");
            sb.AppendLine($" {BeautyType.Opis()}");
            sb.AppendLine();
            sb.AppendLine(Lang.Current["Personality"] + ":");
            sb.AppendLine($" {Morality.Opis(),-22} [{InfoChanges(MoralityFuture, 5)}]");
            sb.AppendLine($" {Ethical.Opis(),-22} [{InfoChanges(EthicalFuture, 5)}]");
            sb.AppendLine($" {Ego.Opis(),-22} [{InfoChanges(EgoFuture, 5)}]");
            sb.AppendLine($" {Idea.Opis(),-22} [{InfoChanges(IdeaFuture, 5)}]");
            sb.AppendLine($" {Political.Opis()}");
            sb.AppendLine($" {Protest.Opis()}");
            sb.AppendLine($" {Empathy.Opis()}");
            sb.AppendLine($" {Emotional.Opis()}");
            sb.AppendLine();
            sb.AppendLine(Lang.Current["Social"] + ":");
            sb.AppendLine($" {SocialStatus.Opis()}");
            sb.AppendLine($" {Sexuality.Opis()}");
            sb.AppendLine($" {Responsibility.Opis()}");
            sb.AppendLine($" {Loyalty.Opis()}");
            sb.AppendLine($" {Adaptability.Opis()}");
            sb.AppendLine($" {TrustInPeople.Opis()}");
            sb.AppendLine($" {Humour.Opis()}");
            sb.AppendLine();
            sb.AppendLine(Lang.Current["Forces"] + ":");
            sb.AppendLine($" {PhysicalPower.Opis(),-28} [{InfoChanges(PhysicalPowerFuture, 5)}]");
            sb.AppendLine($" {MagicPower.Opis(),-28} [{InfoChanges(MagicPowerFuture, 5)}]");
            sb.AppendLine($" {WillPower.Opis(),-28} [{InfoChanges(WillPowerFuture, 5)}]");
            sb.AppendLine($" {Stamina.Opis(),-28} [{InfoChanges(StaminaFuture, 5)}]");
            sb.AppendLine($" {Intellect.Opis(),-28} [{InfoChanges(IntellectFuture, 5)}]");
            sb.AppendLine($" {PhysicalPower.LangEnumType()}: {PercentPhysicalPower.Percent()}");
            sb.AppendLine($" {MagicPower.LangEnumType()}: {PercentMagicPower.Percent()}");
            sb.AppendLine($" {WillPower.LangEnumType()}: {PercentWillPower.Percent()}");
            sb.AppendLine($" {Stamina.LangEnumType()}: {PercentStamina.Percent()}");
            sb.AppendLine($" {Intellect.LangEnumType()}: {PercentIntellect.Percent()}");
            return sb.ToString();
        }


        public static int MinSupportedBuild => 190;
        static int cached_currend_revision => GlobalAssemblyVersion.Revision.ToInt32();
        const string TGCFILETITLE = "TROPEGENCHSFILE";

        public void ReadFrom(BinaryReader br, int revision)
        {
            Seed = br.ReadInt32();
            Gender = (Archetypes.BiologicalGender)br.ReadByte();
            AgeType = (Archetypes.AgeType)br.ReadByte();
            Age = br.ReadInt32();
            BirthDate = new DateTime(br.ReadInt64());
            Name = br.ReadFullString();
            Surname = br.ReadFullString();
            Morality = (Archetypes.Morality)br.ReadByte();
            for (var i = 0; i < 5; i++) MoralityFuture[i] = (Archetypes.Changes)br.ReadByte();
            Ethical = (Archetypes.Ethical)br.ReadByte();
            for (var i = 0; i < 5; i++) EthicalFuture[i] = (Archetypes.Changes)br.ReadByte();
            Ego = (Archetypes.Ego)br.ReadByte();
            for (var i = 0; i < 5; i++) EgoFuture[i] = (Archetypes.Changes)br.ReadByte();
            Idea = (Archetypes.Idea)br.ReadByte();
            for (var i = 0; i < 5; i++) IdeaFuture[i] = (Archetypes.Changes)br.ReadByte();
            Protest = (Archetypes.Protest)br.ReadByte();
            Political = (Archetypes.Political)br.ReadByte();
            Empathy = (Archetypes.Empathy)br.ReadByte();
            Emotional = (Archetypes.Emotional)br.ReadByte();
            HeightType = (Archetypes.HeightType)br.ReadByte();
            Height = br.ReadInt32();
            EyesColor = (Archetypes.EyesColor)br.ReadByte();
            HairColor = (Archetypes.HairColor)br.ReadByte();
            HairLength = (Archetypes.HairLength)br.ReadByte();
            BeautyType = (Archetypes.BeautyType)br.ReadByte();
            HairColorRGB = Color.FromArgb(br.ReadInt32());
            Physique = (Archetypes.Physique)br.ReadByte();
            PhysiqueStatus = (Archetypes.PhysiqueStatus)br.ReadByte();
            Weight = br.ReadInt32();
            Fat = br.ReadDouble();
            Muscles = br.ReadDouble();
            SocialStatus = (Archetypes.SocialStatus)br.ReadByte();
            Sexuality = (Archetypes.Sexuality)br.ReadByte();
            Responsibility = (Archetypes.Responsibility)br.ReadByte();
            Loyalty = (Archetypes.Loyalty)br.ReadByte();
            Adaptability = (Archetypes.Adaptability)br.ReadByte();
            TrustInPeople = (Archetypes.FaithInPeople)br.ReadByte();
            Humour = (Archetypes.Humour)br.ReadByte();
            PhysicalPower = (Archetypes.PhysicalPower)br.ReadByte();
            for (var i = 0; i < 5; i++) PhysicalPowerFuture[i] = (Archetypes.Changes)br.ReadByte();
            MagicPower = (Archetypes.MagicPower)br.ReadByte();
            for (var i = 0; i < 5; i++) MagicPowerFuture[i] = (Archetypes.Changes)br.ReadByte();
            WillPower = (Archetypes.WillPower)br.ReadByte();
            for (var i = 0; i < 5; i++) WillPowerFuture[i] = (Archetypes.Changes)br.ReadByte();
            Stamina = (Archetypes.Stamina)br.ReadByte();
            for (var i = 0; i < 5; i++) StaminaFuture[i] = (Archetypes.Changes)br.ReadByte();
            Intellect = (Archetypes.Intellect)br.ReadByte();
            for (var i = 0; i < 5; i++) IntellectFuture[i] = (Archetypes.Changes)br.ReadByte();
            Fate = br.ReadFullString();
        }

        public void WriteIn(BinaryWriter bw)
        {
            bw.Write(Seed);
            bw.Write((byte)Gender);
            bw.Write((byte)AgeType);
            bw.Write(Age);
            bw.Write(BirthDate.Ticks);
            bw.WriteFullstring(Name);
            bw.WriteFullstring(Surname);
            bw.Write((byte)Morality);
            for (var i = 0; i < 5; i++) bw.Write((byte)MoralityFuture[i]);
            bw.Write((byte)Ethical);
            for (var i = 0; i < 5; i++) bw.Write((byte)EthicalFuture[i]);
            bw.Write((byte)Ego);
            for (var i = 0; i < 5; i++) bw.Write((byte)EgoFuture[i]);
            bw.Write((byte)Idea);
            for (var i = 0; i < 5; i++) bw.Write((byte)IdeaFuture[i]);
            bw.Write((byte)Protest);
            bw.Write((byte)Political);
            bw.Write((byte)Empathy);
            bw.Write((byte)Emotional);
            bw.Write((byte)HeightType);
            bw.Write(Height);
            bw.Write((byte)EyesColor);
            bw.Write((byte)HairColor);
            bw.Write((byte)HairLength);
            bw.Write((byte)BeautyType);
            bw.Write(HairColorRGB.ToArgb());
            bw.Write((byte)Physique);
            bw.Write((byte)PhysiqueStatus);
            bw.Write(Weight);
            bw.Write(Fat);
            bw.Write(Muscles);
            bw.Write((byte)SocialStatus);
            bw.Write((byte)Sexuality);
            bw.Write((byte)Responsibility);
            bw.Write((byte)Loyalty);
            bw.Write((byte)Adaptability);
            bw.Write((byte)TrustInPeople);
            bw.Write((byte)Humour);
            bw.Write((byte)PhysicalPower);
            for (var i = 0; i < 5; i++) bw.Write((byte)PhysicalPowerFuture[i]);
            bw.Write((byte)MagicPower);
            for (var i = 0; i < 5; i++) bw.Write((byte)MagicPowerFuture[i]);
            bw.Write((byte)WillPower);
            for (var i = 0; i < 5; i++) bw.Write((byte)WillPowerFuture[i]);
            bw.Write((byte)Stamina);
            for (var i = 0; i < 5; i++) bw.Write((byte)StaminaFuture[i]);
            bw.Write((byte)Intellect);
            for (var i = 0; i < 5; i++) bw.Write((byte)IntellectFuture[i]);
            bw.WriteFullstring(Fate);
        }

        public static void Save(string path, IList<Character> characters)
        {
            using (var stream = File.Create(path))
            using (var bw = new BinaryWriter(stream))
            {
                bw.WriteShortString(TGCFILETITLE);
                bw.Write(cached_currend_revision);
                bw.Write(characters.Count);
                for (var i = 0; i < characters.Count; i++)
                {
                    characters[i].WriteIn(bw);
                }
            }
        }

        public static Character[] Load(string path)
        {
            using (var stream = File.OpenRead(path))
            using (var br = new BinaryReader(stream))
            {
                if (br.ReadShortString() != TGCFILETITLE) throw new Exception();
                var revision = br.ReadInt32();
                if (revision < MinSupportedBuild) throw new Exception();
                var count = br.ReadInt32();
                var ret = new Character[count];
                for (var i = 0; i < ret.Length; i++)
                {
                    ret[i] = new Character();
                    ret[i].ReadFrom(br, revision);
                }
                return ret;
            }
        }

        public static string InfoChanges(Archetypes.Changes[] changes, int max)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < changes.Length; i++)
            {
                if (i > max) break;
                if (changes[i] == Archetypes.Changes.None) continue;
                sb.Append(changes[i].Lang());

            }
            return sb.ToString().PadRight(max);
        }

        public object Clone()
        {
            var ch = new Character()
            {
                Adaptability = Adaptability,
                Age = Age,
                AgeType = AgeType,
                BeautyType = BeautyType,
                BirthDate = BirthDate,
                Ego = Ego,
                Emotional = Emotional,
                Empathy = Empathy,
                Ethical = Ethical,
                EyesColor = EyesColor,
                Fat = Fat,
                Gender = Gender,
                HairColor = HairColor,
                HairColorRGB = HairColorRGB,
                HairLength = HairLength,
                Height = Height,
                HeightType = HeightType,
                Humour = Humour,
                Idea = Idea,
                Intellect = Intellect,
                Loyalty = Loyalty,
                MagicPower = MagicPower,
                Morality = Morality,
                Muscles = Muscles,
                Name = Name,
                PhysicalPower = PhysicalPower,
                Physique = Physique,
                PhysiqueStatus = PhysiqueStatus,
                Political = Political,
                Protest = Protest,
                Responsibility = Responsibility,
                Seed = Seed,
                Sexuality = Sexuality,
                SocialStatus = SocialStatus,
                Stamina = Stamina,
                Surname = Surname,
                TrustInPeople = TrustInPeople,
                Weight = Weight,
                WillPower = WillPower
            };

            for (var i = 0; i < 5; i++)
            {
                ch.EgoFuture[i] = EgoFuture[i];
                ch.EthicalFuture[i] = EthicalFuture[i];
                ch.IdeaFuture[i] = IdeaFuture[i];
                ch.IntellectFuture[i] = IntellectFuture[i];
                ch.MagicPowerFuture[i] = MagicPowerFuture[i];
                ch.MoralityFuture[i] = MoralityFuture[i];
                ch.PhysicalPowerFuture[i] = PhysicalPowerFuture[i];
                ch.StaminaFuture[i] = StaminaFuture[i];
                ch.WillPowerFuture[i] = WillPowerFuture[i];
            }

            return ch;
        }
    }
}

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
        public Color HairColorRGB { get; set; }
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
        public Archetypes.TrustInPeople TrustInPeople { get; set; }
        public Archetypes.Humor Humor { get; set; }
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
            sb.AppendLine($" {Humor.Opis()}");
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


        public void ReadFrom(BinaryReader br)
        {
            Seed = br.ReadInt32();
            Gender = (Archetypes.BiologicalGender)br.ReadInt32();
            AgeType = (Archetypes.AgeType)br.ReadInt32();
            Age = br.ReadInt32();
            BirthDate = new DateTime(br.ReadInt64());
            Name = br.ReadFullString();
            Surname = br.ReadFullString();
            Morality = (Archetypes.Morality)br.ReadInt32();
            for (var i = 0; i < 5; i++) MoralityFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Ethical = (Archetypes.Ethical)br.ReadInt32();
            for (var i = 0; i < 5; i++) EthicalFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Ego = (Archetypes.Ego)br.ReadInt32();
            for (var i = 0; i < 5; i++) EgoFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Idea = (Archetypes.Idea)br.ReadInt32();
            for (var i = 0; i < 5; i++) IdeaFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Protest = (Archetypes.Protest)br.ReadInt32();
            Political = (Archetypes.Political)br.ReadInt32();
            Empathy = (Archetypes.Empathy)br.ReadInt32();
            Emotional = (Archetypes.Emotional)br.ReadInt32();
            HeightType = (Archetypes.HeightType)br.ReadInt32();
            Height = br.ReadInt32();
            EyesColor = (Archetypes.EyesColor)br.ReadInt32();
            HairColor = (Archetypes.HairColor)br.ReadInt32();
            HairLength = (Archetypes.HairLength)br.ReadInt32();
            BeautyType = (Archetypes.BeautyType)br.ReadInt32();
            HairColorRGB = Color.FromArgb(br.ReadInt32());
            Physique = (Archetypes.Physique)br.ReadInt32();
            PhysiqueStatus = (Archetypes.PhysiqueStatus)br.ReadInt32();
            Weight = br.ReadInt32();
            Fat = br.ReadDouble();
            Muscles = br.ReadDouble();
            SocialStatus = (Archetypes.SocialStatus)br.ReadInt32();
            Sexuality = (Archetypes.Sexuality)br.ReadInt32();
            Responsibility = (Archetypes.Responsibility)br.ReadInt32();
            Loyalty = (Archetypes.Loyalty)br.ReadInt32();
            Adaptability = (Archetypes.Adaptability)br.ReadInt32();
            TrustInPeople = (Archetypes.TrustInPeople)br.ReadInt32();
            Humor = (Archetypes.Humor)br.ReadInt32();
            PhysicalPower = (Archetypes.PhysicalPower)br.ReadInt32();
            for (var i = 0; i < 5; i++) PhysicalPowerFuture[i] = (Archetypes.Changes)br.ReadInt32();
            MagicPower = (Archetypes.MagicPower)br.ReadInt32();
            for (var i = 0; i < 5; i++) MagicPowerFuture[i] = (Archetypes.Changes)br.ReadInt32();
            WillPower = (Archetypes.WillPower)br.ReadInt32();
            for (var i = 0; i < 5; i++) WillPowerFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Stamina = (Archetypes.Stamina)br.ReadInt32();
            for (var i = 0; i < 5; i++) StaminaFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Intellect = (Archetypes.Intellect)br.ReadInt32();
            for (var i = 0; i < 5; i++) IntellectFuture[i] = (Archetypes.Changes)br.ReadInt32();
            Fate = br.ReadFullString();
        }

        public void WriteIn(BinaryWriter bw)
        {
            bw.Write(Seed);
            bw.Write((int)Gender);
            bw.Write((int)AgeType);
            bw.Write(Age);
            bw.Write(BirthDate.Ticks);
            bw.WriteFullstring(Name);
            bw.WriteFullstring(Surname);
            bw.Write((int)Morality);
            for (var i = 0; i < 5; i++) bw.Write((int)MoralityFuture[i]);
            bw.Write((int)Ethical);
            for (var i = 0; i < 5; i++) bw.Write((int)EthicalFuture[i]);
            bw.Write((int)Ego);
            for (var i = 0; i < 5; i++) bw.Write((int)EgoFuture[i]);
            bw.Write((int)Idea);
            for (var i = 0; i < 5; i++) bw.Write((int)IdeaFuture[i]);
            bw.Write((int)Protest);
            bw.Write((int)Political);
            bw.Write((int)Empathy);
            bw.Write((int)Emotional);
            bw.Write((int)HeightType);
            bw.Write(Height);
            bw.Write((int)EyesColor);
            bw.Write((int)HairColor);
            bw.Write((int)HairLength);
            bw.Write((int)BeautyType);
            bw.Write(HairColorRGB.ToArgb());
            bw.Write((int)Physique);
            bw.Write((int)PhysiqueStatus);
            bw.Write(Weight);
            bw.Write(Fat);
            bw.Write(Muscles);
            bw.Write((int)SocialStatus);
            bw.Write((int)Sexuality);
            bw.Write((int)Responsibility);
            bw.Write((int)Loyalty);
            bw.Write((int)Adaptability);
            bw.Write((int)TrustInPeople);
            bw.Write((int)Humor);
            bw.Write((int)PhysicalPower);
            for (var i = 0; i < 5; i++) bw.Write((int)PhysicalPowerFuture[i]);
            bw.Write((int)MagicPower);
            for (var i = 0; i < 5; i++) bw.Write((int)MagicPowerFuture[i]);
            bw.Write((int)WillPower);
            for (var i = 0; i < 5; i++) bw.Write((int)WillPowerFuture[i]);
            bw.Write((int)Stamina);
            for (var i = 0; i < 5; i++) bw.Write((int)StaminaFuture[i]);
            bw.Write((int)Intellect);
            for (var i = 0; i < 5; i++) bw.Write((int)IntellectFuture[i]);
            bw.WriteFullstring(Fate);
        }

        public static void Save(string path, IList<Character> characters)
        {
            using (var stream = File.Create(path))
            using (var bw = new BinaryWriter(stream))
            {
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
                var count = br.ReadInt32();
                var ret = new Character[count];
                for (var i = 0; i < ret.Length; i++)
                {
                    ret[i] = new Character();
                    ret[i].ReadFrom(br);
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
                Humor = Humor,
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

            for (var i = 0; i < 5; i++) ch.EgoFuture[i] = EgoFuture[i];
            for (var i = 0; i < 5; i++) ch.EthicalFuture[i] = EthicalFuture[i];
            for (var i = 0; i < 5; i++) ch.IdeaFuture[i] = IdeaFuture[i];
            for (var i = 0; i < 5; i++) ch.IntellectFuture[i] = IntellectFuture[i];
            for (var i = 0; i < 5; i++) ch.MagicPowerFuture[i] = MagicPowerFuture[i];
            for (var i = 0; i < 5; i++) ch.MoralityFuture[i] = MoralityFuture[i];
            for (var i = 0; i < 5; i++) ch.PhysicalPowerFuture[i] = PhysicalPowerFuture[i];
            for (var i = 0; i < 5; i++) ch.StaminaFuture[i] = StaminaFuture[i];
            for (var i = 0; i < 5; i++) ch.WillPowerFuture[i] = WillPowerFuture[i];

            return ch;
        }
    }
}

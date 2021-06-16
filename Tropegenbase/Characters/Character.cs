using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropegenbase.Data;

namespace Tropegenbase.Characters
{
    /// <summary>
    /// Персонаж
    /// </summary>
    public class Character
    {
        public int Seed { get; set; }

        public Archetypes.BiologicalGender Gender { get; set; }
        public Archetypes.AgeType AgeType { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Archetypes.Morality Morality { get; set; }
        public Archetypes.Changes[] MoralityFuture { get; set; }

        public Archetypes.Ethical Ethical { get; set; }
        public Archetypes.Changes[] EthicalFuture { get; set; }

        public Archetypes.Ego Ego { get; set; }
        public Archetypes.Changes[] EgoFuture { get; set; }

        public Archetypes.Idea Idea { get; set; }
        public Archetypes.Changes[] IdeaFuture { get; set; }

        public Archetypes.Protest Protest { get; set; }
        public Archetypes.Political Political { get; set; }

        public Archetypes.PhysicalPower PhysicalPower { get; set; }
        public Archetypes.Changes[] PhysicalPowerFuture { get; set; }

        public Archetypes.MagicPower MagicPower { get; set; }
        public Archetypes.Changes[] MagicPowerFuture { get; set; }

        public Archetypes.WillPower WillPower { get; set; }
        public Archetypes.Changes[] WillPowerFuture { get; set; }

        public Archetypes.Stamina Stamina { get; set; }
        public Archetypes.Changes[] StaminaFuture { get; set; }

        public Archetypes.Intellect Intellect { get; set; }
        public Archetypes.Changes[] IntellectFuture { get; set; }

/*        public double PercentPhysicalPower => NotMoreOne(GetPower((int)PhysicalPower) * GetFuturePower(PhysicalPowerFuture) / 300.0);
        public double PercentMagicPower => NotMoreOne(GetPower((int)MagicPower) * GetFuturePower(MagicPowerFuture) / 300.0);
        public double PercentWillPower => NotMoreOne(GetPower((int)WillPower) * GetFuturePower(WillPowerFuture) / 300.0);
        public double PercentStamina => NotMoreOne(GetPower((int)Stamina) * GetFuturePower(StaminaFuture) / 300.0);
        public double PercentIntellect => NotMoreOne(GetPower((int)Intellect) * GetFuturePower(IntellectFuture) / 300.0);

        public int GetPower(int a)
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

        public double NotMoreOne(double d)
        {
            if (d > 1.0) return 1.0;
            else return d;
        }

        public double GetFuturePower(Archetypes.Changes[] a)
        {
            var rslt = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == 0) rslt += 2;
                if ((int)a[i] == 1) rslt += 1;
                if ((int)a[i] == 3) rslt -= 1;
                if ((int)a[i] == 4) rslt -= 2;
            }
            return (rslt) / 10.0 + 1.0;
        }*/

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Lang()}: {Name} {Surname}");
            sb.AppendLine(Gender.Opis());
            sb.Append(AgeType.Opis());
            sb.AppendLine($" ({Age} {Lang.Get("years")})");
            sb.AppendLine($"{Lang.Get("birthdate")}: {BirthDate.Day} {Lang.Get($"Month{BirthDate.Month}")}");
            sb.AppendLine();
            sb.AppendLine($"{Morality.Opis(),-22} [{InfoChanges(MoralityFuture, 5)}]");
            sb.AppendLine($"{Ethical.Opis(),-22} [{InfoChanges(EthicalFuture, 5)}]");
            sb.AppendLine($"{Ego.Opis(),-22} [{InfoChanges(EgoFuture, 5)}]");
            sb.AppendLine($"{Idea.Opis(),-22} [{InfoChanges(IdeaFuture, 5)}]");
            sb.AppendLine(Political.Opis());
            sb.AppendLine(Protest.Opis());
            sb.AppendLine();
            sb.AppendLine($"{PhysicalPower.Opis(),-28} [{InfoChanges(PhysicalPowerFuture, 5)}]");
            sb.AppendLine($"{MagicPower.Opis(),-28} [{InfoChanges(MagicPowerFuture, 5)}]");
            sb.AppendLine($"{WillPower.Opis(),-28} [{InfoChanges(WillPowerFuture, 5)}]");
            sb.AppendLine($"{Stamina.Opis(),-28} [{InfoChanges(StaminaFuture, 5)}]");
            sb.AppendLine($"{Intellect.Opis(),-28} [{InfoChanges(IntellectFuture, 5)}]");
/*            sb.AppendLine($"{PhysicalPower.LangEnumType()}: {PercentPhysicalPower:P}");
            sb.AppendLine($"{MagicPower.LangEnumType()}: {PercentMagicPower:P}");
            sb.AppendLine($"{WillPower.LangEnumType()}: {PercentWillPower:P}");
            sb.AppendLine($"{Stamina.LangEnumType()}: {PercentStamina:P}");
            sb.AppendLine($"{Intellect.LangEnumType()}: {PercentIntellect:P}");*/
            /*
            sb.AppendLine($"{Ethical.Opis(),-22} [{InfoChanges(EthicalFuture, 5)}]");
            sb.AppendLine($"{Ego.Opis(),-22} [{InfoChanges(EgoFuture, 5)}]");
            sb.AppendLine($"{Idea.Opis(),-22} [{InfoChanges(IdeaFuture, 5)}]");
            if (Age > 13)
            {
                sb.AppendLine();
                sb.AppendLine(Political.Opis());
                sb.AppendLine(Protest.Opis());
                sb.AppendLine(PoliticalFuture.Opis());
            }
            sb.AppendLine();
            sb.AppendLine($"{PhysicalPower.Opis(),-28} [{InfoChanges(PhysicalPowerFuture, 5)}]");
            sb.AppendLine($"{MagicPower.Opis(),-28} [{InfoChanges(MagicPowerFuture, 5)}]");
            sb.AppendLine($"{WillPower.Opis(),-28} [{InfoChanges(WillPowerFuture, 5)}]");
            sb.AppendLine($"{Stamina.Opis(),-28} [{InfoChanges(StaminaFuture, 5)}]");
            sb.AppendLine($"{Intellect.Opis(),-28} [{InfoChanges(IntellectFuture, 5)}]");*/
            return sb.ToString();
        }

        string InfoChanges(Archetypes.Changes[] changes, int max)
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
    }
}

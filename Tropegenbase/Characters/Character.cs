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
        public string Name { get; set; }
        public string Surname { get; set; }
        public Archetypes.BiologicalGender Gender { get; set; }
        public Archetypes.AgeType AgeType { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Lang()}: {Name} {Surname}");
            sb.AppendLine(Gender.Opis());
            sb.Append(AgeType.Opis());
            sb.AppendLine($" ({Age} {Lang.Get("years")})");
            sb.AppendLine($"{Lang.Get("birthdate")}: {BirthDate.Day} {Lang.Get($"Month{BirthDate.Month}")}");
            sb.AppendLine();
            /*sb.AppendLine($"{Morality.Opis(),-22} [{InfoChanges(MoralityFuture, 5)}]");
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
    }
}

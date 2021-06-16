using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropegenbase.Data;

namespace Tropegenbase.Characters
{
    public class CharacterBuilder
    {
        public int RandomSeed { get; set; }
        public Random Seed { get; set; }

        private Character inCh;

        public CharacterBuilder(int i)
        {
            RandomSeed = i;
            Seed = new Random(i);
            inCh = new Character();
        }

        private bool
            title_inited;

        public Archetypes.Changes[] GenerateFiveChanges(Random rnd)
        {
            var ret = new Archetypes.Changes[5];
            var integer = rnd.Next();
            for (var i = 0; i < 5; i++)
            {
                var current2 = integer & 0b111111;
                var current1 = current2 >> 3;
                current2 &= 0b111;
                current2 = ((current1 + current2) / 2 + 1) / 2;
                ret[i] = (Archetypes.Changes)current2;
                integer >>= 6;
            }
            return ret;
        }

        private void InitGenderAge()
        {
            inCh.Gender = inCh.Gender.Random(Seed);
            inCh.AgeType = inCh.AgeType.Random(Seed);
        }

        private void InitBirthDate()
        {
            inCh.BirthDate = new DateTime(2000, 1, 1).AddDays(Seed.NextDouble() * 366);
        }

        private void InitAge()
        {
            switch (inCh.AgeType)
            {
                case Archetypes.AgeType.Child:
                    {
                        inCh.Age = Seed.Next(6, 12);
                    }
                    break;
                case Archetypes.AgeType.Teen:
                    {
                        inCh.Age = Seed.Next(12, 18);
                    }
                    break;
                case Archetypes.AgeType.Adult:
                    {
                        inCh.Age = Seed.Next(18, 30);
                    }
                    break;
                case Archetypes.AgeType.Middle:
                    {
                        inCh.Age = Seed.Next(30, 50);
                    }
                    break;
                case Archetypes.AgeType.Senior:
                    {
                        inCh.Age = Seed.Next(50, 65);
                    }
                    break;
                case Archetypes.AgeType.Elderly:
                    {
                        inCh.Age = Seed.Next(65, 100);
                    }
                    break;
            }
        }

        private void InitName()
        {
            inCh.Name = inCh.Gender == Archetypes.BiologicalGender.Male ? Lang.MaleNames.Random(Seed) : Lang.FemaleNames.Random(Seed);
        }

        public void InitTitle()
        {
            if (title_inited) throw new Exception();
            title_inited = true;
            InitGenderAge();
            InitBirthDate();
            InitAge();
            InitName();
            inCh.Surname = Lang.Surnames.Random(Seed);
            
        }

        public void InitCharacter()
        {
            inCh.Morality = inCh.Morality.Random(Seed);
            inCh.MoralityFuture = GenerateFiveChanges(Seed);

            inCh.Ethical = inCh.Ethical.Random(Seed);
            inCh.EthicalFuture = GenerateFiveChanges(Seed);

            inCh.Ego = inCh.Ego.Random(Seed);
            inCh.EgoFuture = GenerateFiveChanges(Seed);

            inCh.Idea = inCh.Idea.Random(Seed);
            inCh.IdeaFuture = GenerateFiveChanges(Seed);

            inCh.Protest = inCh.Protest.Random(Seed);
            inCh.Political = inCh.Political.Random(Seed);

            inCh.PhysicalPower = inCh.PhysicalPower.Random(Seed);
            inCh.PhysicalPowerFuture = GenerateFiveChanges(Seed);

            inCh.MagicPower = inCh.MagicPower.Random(Seed);
            inCh.MagicPowerFuture = GenerateFiveChanges(Seed);

            inCh.WillPower = inCh.WillPower.Random(Seed);
            inCh.WillPowerFuture = GenerateFiveChanges(Seed);

            inCh.Stamina = inCh.Stamina.Random(Seed);
            inCh.StaminaFuture = GenerateFiveChanges(Seed);

            inCh.Intellect = inCh.Intellect.Random(Seed);
            inCh.IntellectFuture = GenerateFiveChanges(Seed);
        }

        public Character ToCharacter()
        {

            return inCh;
        }

        public Character Init()
        {
            InitTitle();
            InitCharacter();
            return inCh;
        }
    }
}

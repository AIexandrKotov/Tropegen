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

        public Character ToCharacter()
        {

            return inCh;
        }

        public Character Init()
        {
            InitTitle();
            return inCh;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
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
            inCh.Seed = i;
            inCh.Generated = true;
        }

        private bool
            title_inited, appear_inited, person_inited, forces_inited;

        internal static void GenerateFiveChanges(Random rnd, Archetypes.Changes[] ret)
        {
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
        }

        private Archetypes.Changes[] GenerateFiveChanges(Random rnd)
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

        private void InitHeight()
        {
            inCh.RandomationHeight(Seed);
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

        public void ReInit()
        {
            Seed = new Random(RandomSeed);
            title_inited = false;
            appear_inited = false;
            person_inited = false;
            forces_inited = false;
        }

        public void InitTitle()
        {
            if (title_inited)
            {
                ReInit();
            }
            title_inited = true;
            InitGenderAge();
            InitAge();
            InitBirthDate();
            InitName();
            inCh.Surname = Lang.Surnames.Random(Seed);
        }

        private void InitPhysique()
        {
            inCh.RandomationPhysique(Seed);
        }

        public void InitAppearance()
        {
            if (appear_inited)
            {
                ReInit();
                InitTitle();
            }
            appear_inited = true;
            inCh.RandomationAppearance1(Seed);
            inCh.RandomationAppearance2(Seed);
        }

        public void InitPerson()
        {
            if (person_inited)
            {
                ReInit();
                InitTitle();
                InitAppearance();
            }
            person_inited = true;
            inCh.RandomationPerson(Seed);
        }

        public void InitForces()
        {
            if (forces_inited)
            {
                ReInit();
                InitTitle();
                InitAppearance();
                InitPerson();
            }
            forces_inited = true;
            inCh.RandomationForces(Seed);
        }

        public void InitSocial()
        {
            inCh.RandomSocial(Seed);
        }

        public Character ToCharacter()
        {
            return inCh;
        }

        public Character Init()
        {
            InitTitle();
            InitAppearance();
            InitPerson();
            InitForces();
            InitSocial();
            return inCh;
        }
    }
}

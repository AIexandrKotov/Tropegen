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

        private static void GenerateFiveChanges(Random rnd, Archetypes.Changes[] ret)
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
            inCh.HeightType = inCh.HeightType.Random(Seed);
            switch (inCh.HeightType)
            {
                case Archetypes.HeightType.Small:
                    {
                        inCh.Height = Seed.Next(170, 180);
                    }
                    break;
                case Archetypes.HeightType.Ordinary:
                    {
                        inCh.Height = Seed.Next(180, 190);
                    }
                    break;
                case Archetypes.HeightType.Big:
                    {
                        inCh.Height = Seed.Next(190, 210);
                    }
                    break;
            }
            inCh.Height = (int)(inCh.Height * Defaults.GetAgeHeightDecrease(inCh.Age) * (inCh.Gender == Archetypes.BiologicalGender.Female ? Defaults.WomanDecrease : 1.0));
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
            inCh.Physique = inCh.Physique.Random(Seed);
            inCh.PhysiqueStatus = inCh.PhysiqueStatus.Random(Seed);

            switch (inCh.Physique)
            {
                case Archetypes.Physique.Ektomorph:
                    {
                        switch (inCh.PhysiqueStatus)
                        {
                            case Archetypes.PhysiqueStatus.Small:
                                {
                                    inCh.Weight = Seed.Next(500, 600);
                                    inCh.Fat = Seed.NextDouble(0.05, 0.1);
                                    inCh.Muscles = Seed.NextDouble(0, 0.05);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Ordinary:
                                {
                                    inCh.Weight = Seed.Next(500, 600);
                                    inCh.Fat = Seed.NextDouble(0.05, 0.1);
                                    inCh.Muscles = Seed.NextDouble(0.05, 0.15);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Big:
                                {
                                    inCh.Weight = Seed.Next(600, 700);
                                    inCh.Fat = Seed.NextDouble(0.05, 0.1);
                                    inCh.Muscles = Seed.NextDouble(0.15, 0.25);
                                }
                                break;
                        }
                    }
                    break;
                case Archetypes.Physique.Endomorph:
                    {
                        switch (inCh.PhysiqueStatus)
                        {
                            case Archetypes.PhysiqueStatus.Small:
                                {
                                    inCh.Weight = Seed.Next(700, 800);
                                    inCh.Fat = Seed.NextDouble(0.1, 0.15);
                                    inCh.Muscles = Seed.NextDouble(0, 0.1);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Ordinary:
                                {
                                    inCh.Weight = Seed.Next(800, 900);
                                    inCh.Fat = Seed.NextDouble(0.15, 0.25);
                                    inCh.Muscles = Seed.NextDouble(0.05, 0.25);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Big:
                                {
                                    inCh.Weight = Seed.Next(900, 1200);
                                    inCh.Fat = Seed.NextDouble(0.25, 0.75);
                                    inCh.Muscles = Seed.NextDouble(0, 0.1);
                                }
                                break;
                        }
                    }
                    break;
                case Archetypes.Physique.Mesomorph:
                    {
                        switch (inCh.PhysiqueStatus)
                        {
                            case Archetypes.PhysiqueStatus.Small:
                                {
                                    inCh.Weight = Seed.Next(700, 800);
                                    inCh.Fat = Seed.NextDouble(0.1, 0.15);
                                    inCh.Muscles = Seed.NextDouble(0.15, 0.25);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Ordinary:
                                {
                                    inCh.Weight = Seed.Next(800, 1000);
                                    inCh.Fat = Seed.NextDouble(0.1, 0.15);
                                    inCh.Muscles = Seed.NextDouble(0.25, 0.35);
                                }
                                break;
                            case Archetypes.PhysiqueStatus.Big:
                                {
                                    inCh.Weight = Seed.Next(1000, 1200);
                                    inCh.Fat = Seed.NextDouble(0.1, 0.15);
                                    inCh.Muscles = Seed.NextDouble(0.45, 0.65);
                                }
                                break;
                        }
                    }
                    break;
            }
            inCh.Weight = (int)(inCh.Weight * Math.Pow(inCh.Height / 180.0, 1.25));
        }

        public void InitAppearance()
        {
            if (appear_inited)
            {
                ReInit();
                InitTitle();
            }
            appear_inited = true;
            InitHeight();
            InitPhysique();
            inCh.EyesColor = inCh.EyesColor.Random(Seed);
            inCh.HairColor = inCh.HairColor.Random(Seed);
            if (inCh.HairColor == Archetypes.HairColor.Artificial_Coloring)
            {
                var bs = new byte[3];
                Seed.NextBytes(bs);
                inCh.HairColorRGB = Color.FromArgb(bs[0], bs[1], bs[2]);
            }
            inCh.HairLength = inCh.HairLength.Random(Seed);
            inCh.BeautyType = inCh.BeautyType.Random(Seed);
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
            inCh.Morality = inCh.Morality.Random(Seed);
            GenerateFiveChanges(Seed, inCh.MoralityFuture);

            inCh.Ethical = inCh.Ethical.Random(Seed);
            GenerateFiveChanges(Seed, inCh.EthicalFuture);

            inCh.Ego = inCh.Ego.Random(Seed);
            GenerateFiveChanges(Seed, inCh.EgoFuture);

            inCh.Idea = inCh.Idea.Random(Seed);
            GenerateFiveChanges(Seed, inCh.IdeaFuture);

            inCh.Protest = inCh.Protest.Random(Seed);
            inCh.Political = inCh.Political.Random(Seed);
            inCh.Empathy = inCh.Empathy.Random(Seed);
            inCh.Emotional = inCh.Emotional.Random(Seed);
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
            inCh.PhysicalPower = inCh.PhysicalPower.Random(Seed);
            GenerateFiveChanges(Seed, inCh.PhysicalPowerFuture);

            inCh.MagicPower = inCh.MagicPower.Random(Seed);
            GenerateFiveChanges(Seed, inCh.MagicPowerFuture);

            inCh.WillPower = inCh.WillPower.Random(Seed);
            GenerateFiveChanges(Seed, inCh.WillPowerFuture);

            inCh.Stamina = inCh.Stamina.Random(Seed);
            GenerateFiveChanges(Seed, inCh.StaminaFuture);

            inCh.Intellect = inCh.Intellect.Random(Seed);
            GenerateFiveChanges(Seed, inCh.IntellectFuture);

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
            return inCh;
        }
    }
}

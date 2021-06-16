using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropegenbase.Data;

namespace Tropegenbase.Characters
{
    public class Archetypes
    {
        public enum BiologicalGender
        {
            Male,
            Female
        }

        public enum AgeType
        {
            Child,
            Teen,
            Adult,
            Middle,
            Senior,
            Elderly
        }

        public enum Morality
        {
            Neutral,
            White,
            LightGray,
            Gray,
            DarkGray,
            Black,
        }

        public enum Changes
        {
            VeryPlus,
            Plus,
            None,
            Minus,
            VeryMinus,
        }

        public enum Ethical
        {
            Lawful,
            Neutral,
            Chaotic,
        }

        public enum Ego
        {
            Altruist,
            Opportunist,
            Egoist,
        }

        public enum Idea
        {
            Idealist,
            Apathetic,
            Cynic,
        }

        public enum Protest
        {
            None,
            Activist,
            Reactivist,
            Extremist,
            Terrorist,
            Aboveit,
        }

        public enum Political
        {
            Apolit,
            Neutral,
            Centrist,
            LeftWing,
            RightWing,
            FarLeft,
            FarRight
        }

        public enum PhysicalPower
        {
            None,
            Milksop,
            Ordinary,
            Strong,
            IncrediblyStrong,
        }

        public enum MagicPower
        {
            None,
            Milksop,
            Ordinary,
            Strong,
            IncrediblyStrong,
        }

        public enum WillPower
        {
            None,
            Milksop,
            Ordinary,
            Strong,
            IncrediblyStrong,
        }

        public enum Stamina
        {
            None,
            Little,
            Ordinary,
            High,
            Hardy,
        }

        public enum Intellect
        {
            None,
            Stupid,
            Ordinary,
            Smart,
            Supermind,
        }
    }
}

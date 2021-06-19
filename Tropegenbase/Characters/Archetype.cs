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
        #region Biology
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
        #endregion

        #region Appearance
        public enum HeightType
        {
            Small,
            Ordinary,
            Big,
        }

        public enum EyesColor
        {
            Brown,
            Walnut,
            Green,
            Gray,
            Cyan,
            Amber,
            Heterochromia,
        }

        public enum Physique
        {
            Ektomorph,
            Endomorph,
            Mesomorph,
        }

        public enum PhysiqueStatus
        {
            Small,
            Ordinary,
            Big,
        }

        public enum HairLength
        {
            Zero,
            Short,
            Middle,
            Long,
        }

        public enum HairColor
        {
            Blonde,
            Light_Brown,
            Chestnut,
            Brunette,
            Red,
            Artificial_Coloring,
        }

        public enum BeautyType
        {
            VeryUgly,
            Brutal,
            Ugly,
            Ordinary,
            Pretty,
            Cute,
        }
        #endregion

        #region Personality
        public enum Morality
        {
            Neutral,
            White,
            LightGray,
            Gray,
            DarkGray,
            Black,
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

        public enum Empathy
        {
            None,
        }

        public enum Emotional
        {
            None,
        }
        #endregion

        #region Social
        /// <summary>
        /// Социальный статус
        /// </summary>
        public enum SocialStatus
        {
            None,
        }

        /// <summary>
        /// Секусальное поведение
        /// </summary>
        public enum Sexuality
        {
            None,
        }

        /// <summary>
        /// Ответственность
        /// </summary>
        public enum Responsibility
        {
            None,
        }

        /// <summary>
        /// Преданность
        /// </summary>
        public enum Loyalty
        {
            None,
        }

        /// <summary>
        /// Адаптивность
        /// </summary>
        public enum Adaptability
        {
            None,
        }

        /// <summary>
        /// Доверие людям
        /// </summary>
        public enum TrustInPeople
        {
            None,
        }

        /// <summary>
        /// Юмор
        /// </summary>
        public enum Humor
        {
            None,
        }
        #endregion

        #region Text Generation
        /// <summary>
        /// Привычки
        /// </summary>
        public enum Habits
        {
            /// <summary>
            /// Душнила
            /// </summary>
            Overpowering,
            /// <summary>
            /// Курение
            /// </summary>
            Smoking,
            /// <summary>
            /// Легкий алкоголизм
            /// </summary>
            MildAlcoholism,
            /// <summary>
            /// Тяжелый алкоголизм
            /// </summary>
            SevereAlcoholism,
            SweetTooth,
            BadFood,
            Gambling,
            FoulLanguage,
            Lie,
        }

        public enum Parents
        {

        }

        public enum Childhood
        {

        }

        public enum OtherFeatures
        {

        }

        public enum Death
        {

        }
        #endregion

        #region Forces
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
        #endregion

        public enum Changes
        {
            VeryPlus,
            Plus,
            None,
            Minus,
            VeryMinus,
        }
    }
}

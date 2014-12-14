﻿namespace Dnd.Core.Model.Character.Attributes
{
    using System;

    /// <summary>
    /// A character attribute, can be of type Strength, Dexterity,
    /// Constitution, Wisdom, Intelligence, Charisma
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// If no score is provided the score will default to 10, whioh
        /// is the average for an attribute (+0 modifier)
        /// </summary>
        private const int _defaultScore = 10;

        /// <summary>
        /// Denotes which attribute this is. This is decided at creation 
        /// of this class and can not be changed
        /// </summary>
        public AttributeType Type { get; protected set; }

        /// <summary>
        /// The total attribute score. Base score and any bonusses.
        /// </summary>
        public int Score { get { return BaseScore + BonusScore; } }

        /// <summary>
        /// The actual bare attribute score. No bonusses are applies.
        /// </summary>
        private int _baseScore;
        public int BaseScore {
            get { return _baseScore; }
            protected set {
                if (value <= 0) {
                    throw new ArgumentException("The Base Score needs to be at least 1.");
                }
                _baseScore = value;
            }
        }

        /// <summary>
        /// Any bonusses which are added to this attribute.
        /// </summary>
        public int BonusScore { get; protected set; }

        /// <summary>
        /// The modifier used for various checks and skills.
        /// </summary>
        public int Modifier {
            get {
                if (Score <= 0) {
                    throw new ArgumentException("Score can not be 0, it would mean death", "Score");
                }
                return (Score - 10) / 2;
            }
        }

        public Attribute(AttributeType attributeType, int baseScore = _defaultScore, int bonusScore = 0) {
            Type = attributeType;
            BaseScore = baseScore;
            BonusScore = bonusScore;
        }

        /// <summary>
        /// Increase the BaseScore by the given amount
        /// </summary>
        /// <param name="value">A positive value. Negative will throw an exception</param>
        public void Increase(int value) {
            if (value < 0) {
                throw new ArgumentException("Must be positive. Use Decrease if you want to lower the score", "value");
            }
            BaseScore += value;
        }

        /// <summary>
        /// Decrease the BaseScore by the given amount
        /// </summary>
        /// <param name="value">A positive value. Negative will throw an exception</param>
        /// <returns>Boolean Indicating if the resultant score is positive. Negative score probably means a character is dead.</returns>
        public bool Decrease(int value) {
            if (value < 0) {
                throw new ArgumentException("Must be positive. Use Increase if you want to heighten the score", "value");
            }
            BaseScore -= value;
            return Score > 0;
        }

        /// <summary>
        /// Adds the given bonus amount to the current BonusScore
        /// </summary>
        /// <param name="value">Positive or negative bonus from an external source.</param>
        /// <returns>Boolean Indicating if the resultant score is positive. Negative score probably means a character is dead.</returns>
        public bool AdjustBonus(int value) {
            BonusScore += value;
            return Score > 0; // a value of 0 or lower should have consequences
        }

        public static implicit operator int(Attribute attr) {
            return attr.Score;
        }
    }
}

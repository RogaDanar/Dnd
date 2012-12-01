namespace Dnd.Core.Attributes
{
    using Dnd.Core.Enums;

    public class Attribute : ReadOnlyAttribute
    {
        public Attribute(AttributeType attributeType, int? baseScore = null, int bonusScore = 0)
            : base(attributeType, baseScore, bonusScore) {
        }

        public void Increase(int value) {
            if (value < 0) {
                throw new System.ArgumentException("Must be positive. Use Decrease if you want to lower the score", "value");
            }
            BaseScore += value;
        }

        public bool Decrease(int value) {
            if (value < 0) {
                throw new System.ArgumentException("Must be positive. Use Increase if you want to heighten the score", "value");
            }
            BaseScore -= value;
            return Score > 0; // a value of 0 or lower should have consequences
        }

        public bool AdjustBonus(int value) {
            BonusScore += value;
            return Score > 0; // a value of 0 or lower should have consequences
        }

        //public static implicit operator Attribute(int i) {
        //    return new Attribute { BaseScore = i };
        //}

        public static implicit operator int(Attribute attr) {
            return attr.Score;
        }
    }
}

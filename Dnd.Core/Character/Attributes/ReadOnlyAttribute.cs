namespace Dnd.Core.Character.Attributes
{
    using System;

    public class ReadOnlyAttribute
    {
        public ReadOnlyAttribute(AttributeType attributeType, int? baseScore = null, int bonusScore = 0) {
            Type = attributeType;
            BaseScore = baseScore ?? 10;
            BonusScore = bonusScore;
        }

        public AttributeType Type { get; protected set; }
        public int Score { get { return BaseScore + BonusScore; } }
        public int BaseScore { get; protected set; }
        public int BonusScore { get; protected set; }

        public int Modifier {
            get {
                if (Score <= 0) {
                    throw new ArgumentException("Score can not be 0, it would mean death", "Score");
                }
                return (Score - 10) / 2;
            }
        }

        public static implicit operator int(ReadOnlyAttribute attr) {
            return attr.Score;
        }
    }
}

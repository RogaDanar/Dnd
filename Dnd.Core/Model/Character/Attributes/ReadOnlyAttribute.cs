namespace Dnd.Core.Model.Character.Attributes
{
    using System;

    /// <summary>
    /// Wrapper for the <see cref="Attribute"/> class to make it read only.
    /// Prevent any modification by making it impossible to cast it back to an Attribute 
    /// </summary>
    public class ReadOnlyAttribute
    {
        private readonly Attribute _attribute;

        public AttributeType Type { get { return _attribute.Type; } }
        public int Score { get { return _attribute.Score; } }
        public int BaseScore { get { return _attribute.BaseScore; } }
        public int BonusScore { get { return _attribute.BonusScore; } }
        public int Modifier { get { return _attribute.Modifier; } }

        public ReadOnlyAttribute(Attribute attribute) {
            if (attribute == null) {
                throw new ArgumentNullException("attribute", "ReadOnlyAttribute requires a normal attribute");
            }
            _attribute = attribute;
        }

        public static implicit operator int(ReadOnlyAttribute attr) {
            return attr.Score;
        }
    }
}

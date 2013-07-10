namespace Dnd.Core.Character.Skills
{
    using Dnd.Core.Character.Attributes;
    using Attribute = System.Attribute;

    public class AbilityModifierAttribute : Attribute
    {
        public AttributeType Type;

        public AbilityModifierAttribute(AttributeType type) {
            Type = type;
        }
    }
}

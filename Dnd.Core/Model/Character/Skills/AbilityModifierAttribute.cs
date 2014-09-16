namespace Dnd.Core.Model.Character.Skills
{
    using Dnd.Core.Model.Character.Attributes;
    using Attribute = System.Attribute;

    public class AbilityModifierAttribute : Attribute
    {
        public AttributeType Type;

        public AbilityModifierAttribute(AttributeType type) {
            Type = type;
        }
    }
}

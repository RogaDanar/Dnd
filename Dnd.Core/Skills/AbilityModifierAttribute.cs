namespace Dnd.Core.Skills
{
    using System;
    using Dnd.Core.Enums;

    public class AbilityModifierAttribute : Attribute
    {
        public AttributeType Type;

        public AbilityModifierAttribute(AttributeType type) {
            Type = type;
        }
    }
}

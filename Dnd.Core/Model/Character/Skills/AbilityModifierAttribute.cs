namespace Dnd.Core.Model.Character.Skills
{
    using Dnd.Core.Model.Character.Abilities;
    using System;

    public class AbilityModifierAttribute : Attribute
    {
        public AbilityType Type;

        public AbilityModifierAttribute(AbilityType type) {
            Type = type;
        }
    }
}

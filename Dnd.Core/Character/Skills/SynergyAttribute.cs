namespace Dnd.Core.Character.Skills
{
    using System;
    using System.Collections.Generic;

    public class SynergyFromAttribute : Attribute
    {
        public IEnumerable<SkillType> Skills;

        public SynergyFromAttribute(params SkillType[] skills) {
            Skills = skills;
        }
    }
}

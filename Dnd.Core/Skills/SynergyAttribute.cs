namespace Dnd.Core.Skills
{
    using System;
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public class SynergyFromAttribute : Attribute
    {
        public IEnumerable<SkillType> Skills;

        public SynergyFromAttribute(params SkillType[] skills) {
            Skills = skills;
        }
    }
}

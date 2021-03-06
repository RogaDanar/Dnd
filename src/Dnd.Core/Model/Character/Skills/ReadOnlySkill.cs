﻿namespace Dnd.Core.Model.Character.Skills
{
    using Dnd.Core.Extensions;
    using Dnd.Core.Model.Character.Abilities;
    using System.Collections.Generic;
    using System.Linq;

    public class ReadOnlySkill
    {
        public SkillType Type { get; protected set; }

        public string SubSkill { get; protected set; }

        public AbilityType AbilityModifierType { get; protected set; }

        public IEnumerable<SkillType> SynergyFromSkills { get; protected set; }

        public int Ranks { get; protected set; }

        public int MiscModifier { get; protected set; }

        public ReadOnlySkill(SkillType type, string subSkill = null) {
            Type = type;
            Ranks = 0;
            MiscModifier = 0;
            SetAbilityModifierType(type);
            SetSynergyFromTypes(type);
            SubSkill = subSkill;
        }

        private void SetAbilityModifierType(SkillType type) {
            var ability = type.GetAttribute<AbilityModifierAttribute>();
            if (ability != null) {
                AbilityModifierType = ability.Type;
            }
        }

        private void SetSynergyFromTypes(SkillType type) {
            var synergyFrom = type.GetAttribute<SynergyFromAttribute>();
            SynergyFromSkills = synergyFrom != null ? synergyFrom.Skills : Enumerable.Empty<SkillType>();
        }
    }
}

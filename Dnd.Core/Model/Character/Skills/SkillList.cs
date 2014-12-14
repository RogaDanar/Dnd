using System.Collections;

namespace Dnd.Core.Model.Character.Skills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Extensions;

    public class SkillList : IEnumerable<KeyValuePair<SkillType, int>>
    {
        private readonly DefaultCharacter _character;

        private readonly List<Skill> _list = new List<Skill>();

        public int UnusedRanks { get; private set; }

        protected SkillList() { }

        public int this[SkillType type] {
            get {
                if (_list.Any(x => x.Type == type)) {
                    return GetScore(_list.Single(x => x.Type == type));
                } else {
                    return 0;
                }
            }
        }

        public SkillList(DefaultCharacter character) {
            _character = character;
            var skills = Enum.GetValues(typeof(SkillType)).Cast<SkillType>();
            foreach (var skill in skills) {
                var trainedOnly = skill.GetAttribute<TrainedOnlyAttribute>();
                if (trainedOnly == null || !trainedOnly.TrainedOnly) {
                    _list.Add(new Skill(skill));
                }
            }
        }

        public void AddRanks(int amount) {
            UnusedRanks += amount;
        }

        public void Increase(SkillType skill, int points, string subSkill = null) {
            if (_list.SingleOrDefault(x => x.Type == skill && x.SubSkill == subSkill) == null) {
                _list.Add(new Skill(skill, subSkill));
            };
            _list.Single(x => x.Type == skill && x.SubSkill == subSkill).Increase(points);
        }

        public void IncreaseBonus(SkillType skill, int points, string subSkill = null) {
            if (_list.SingleOrDefault(x => x.Type == skill && x.SubSkill == subSkill) == null) {
                _list.Add(new Skill(skill, subSkill));
            };
            _list.Single(x => x.Type == skill && x.SubSkill == subSkill).IncreaseModifier(points);
        }

        public int TotalRanks() {
            return _list.Sum(x => x.Ranks);
        }

        public IEnumerable<KeyValuePair<SkillType, int>> GetAll() {
            foreach (var skill in _list) {
                yield return new KeyValuePair<SkillType, int>(skill.Type, GetScore(skill));
            }
        }

        private int GetScore(Skill skill) {
            var score = skill.Ranks + skill.MiscModifier + _character.Abilities[skill.AbilityModifierType].Modifier;
            foreach (var synergyFromSkill in skill.SynergyFromSkills) {
                if (this[synergyFromSkill] >= 5) {
                    score += 2;
                }
            }
            return score;
        }

        public IEnumerator<KeyValuePair<SkillType, int>> GetEnumerator() {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

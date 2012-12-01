namespace Dnd.Core.Attacks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Attributes;
    using Dnd.Core.Enums;

    public class AttackList
    {
        private readonly Dictionary<AttackBonusType, IAttackBonus> _bonusses = new Dictionary<AttackBonusType, IAttackBonus> {  
            { AttackBonusType.Poor, new PoorAttackBonus()},
            { AttackBonusType.Average, new AvgAttackBonus()},
            { AttackBonusType.Good, new GoodAttackBonus()}        
        };

        private AttributeList _attributes;
        private Dictionary<int, Attack> _attacks;
        private int _level;
        private IAttackBonus _attackBonus;

        public AttackList(AttackBonusType type, AttributeList attributes) {
            _attributes = attributes;
            _attackBonus = _bonusses[type];
            _level = 1;
            _attacks = new Dictionary<int, Attack>() { { 1, new Attack(_attackBonus, 1) } };
        }

        public void AdjustAttackBonusType(AttackBonusType type) {
            _attackBonus = _bonusses[type];
            foreach (var attack in _attacks) {
                attack.Value.AdjustBaseBonus(_attackBonus);
            }
        }

        public void IncreaseLevel() {
            _level++;
            foreach (var attack in _attacks) {
                attack.Value.IncreaseLevel();
            }
            var last = _attacks.Last();
            var newAttackNumber = last.Key + 1;
            if (last.Value.Value == 6) {
                _attacks.Add(newAttackNumber, new Attack(_attackBonus, newAttackNumber, _level));
            }
        }

        public IEnumerable<KeyValuePair<int, int>> GetAllAttacks(WeaponType weaponType) {
            foreach (var attack in _attacks) {
                yield return new KeyValuePair<int, int>(attack.Key, GetScore(attack.Value, weaponType));
            }
        }

        private int GetScore(Attack attack, WeaponType weaponType) {
            switch (weaponType) {
                case WeaponType.OneHanded:
                case WeaponType.TwoHanded:
                    return attack.Value + _attributes[AttributeType.Strength].Modifier;
                case WeaponType.Ranged:
                    return attack.Value + _attributes[AttributeType.Dexterity].Modifier;
                default:
                    throw new ArgumentException("weaponType");
            }
        }
    }
}

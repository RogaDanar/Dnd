using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dnd.Core.Character.Attacks
{
    public class AttackList : IEnumerable<Attack>
    {
        private readonly DefaultCharacter _character;

        private readonly List<Attack> _list = new List<Attack>();

        public Dictionary<WeaponType, int> Bonusses { get; private set; }

        public AttackList(DefaultCharacter character) {
            _character = character;
            Bonusses = new Dictionary<WeaponType, int> { { WeaponType.OneHanded, 0 }, { WeaponType.TwoHanded, 0 }, { WeaponType.Ranged, 0 } };
        }

        public IEnumerable<int> GetAttacks(WeaponType weaponType) {
            var baseAttack = _character.Classes.Sum(x => x.Value.Attack);
            do {
                yield return GetAttackScore(baseAttack, weaponType);
                baseAttack -= 5;
            } while (baseAttack > 0);
        }

        public int GetAttackScore(int baseAttack, WeaponType weaponType) {
            switch (weaponType) {
                case WeaponType.OneHanded:
                case WeaponType.TwoHanded:
                    return baseAttack + _character.Strength.Modifier + Bonusses[weaponType];
                case WeaponType.Ranged:
                    return baseAttack + _character.Dexterity.Modifier + Bonusses[weaponType];
                default:
                    throw new ArgumentException("weaponType");
            }
        }

        public IEnumerator<Attack> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

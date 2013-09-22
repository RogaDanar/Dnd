

namespace Dnd.Core.Character.Attributes
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class AttributeList : IEnumerable<ReadOnlyAttribute>
    {
        public int UnusedPoints { get; private set; }

        public ReadOnlyAttribute Strength { get { return _strength; } }
        public ReadOnlyAttribute Dexterity { get { return _dexterity; } }
        public ReadOnlyAttribute Constitution { get { return _constitution; } }
        public ReadOnlyAttribute Intelligence { get { return _intelligence; } }
        public ReadOnlyAttribute Wisdom { get { return _wisdom; } }
        public ReadOnlyAttribute Charisma { get { return _constitution; } }

        private readonly Attribute _strength;
        private readonly Attribute _dexterity;
        private readonly Attribute _constitution;
        private readonly Attribute _intelligence;
        private readonly Attribute _wisdom;
        private readonly Attribute _charisma;

        private readonly List<Attribute> _list;
        private bool _creating;

        public AttributeList(Dictionary<AttributeType, int> abilityScores) {
            _creating = true;
            var str = abilityScores.ContainsKey(AttributeType.Strength) ? abilityScores[AttributeType.Strength] : 10;
            var dex = abilityScores.ContainsKey(AttributeType.Dexterity) ? abilityScores[AttributeType.Dexterity] : 10;
            var con = abilityScores.ContainsKey(AttributeType.Constitution) ? abilityScores[AttributeType.Constitution] : 10;
            var intel = abilityScores.ContainsKey(AttributeType.Intelligence) ? abilityScores[AttributeType.Intelligence] : 10;
            var wis = abilityScores.ContainsKey(AttributeType.Wisdom) ? abilityScores[AttributeType.Wisdom] : 10;
            var cha = abilityScores.ContainsKey(AttributeType.Charisma) ? abilityScores[AttributeType.Charisma] : 10;
            _strength = new Attribute(AttributeType.Strength, str);
            _dexterity = new Attribute(AttributeType.Dexterity, dex);
            _constitution = new Attribute(AttributeType.Constitution, con);
            _intelligence = new Attribute(AttributeType.Intelligence, intel);
            _wisdom = new Attribute(AttributeType.Wisdom, wis);
            _charisma = new Attribute(AttributeType.Charisma, cha);
            _list = new List<Attribute> {
                _strength,
                _dexterity,
                _constitution,
                _intelligence,
                _wisdom,
                _charisma
            };
        }

        private void UsePoint() {
            if (UnusedPoints > 0 && !_creating) {
                UnusedPoints--;
            }
        }

        public void AddPoints(int amount) {
            UnusedPoints += amount;
        }

        public ReadOnlyAttribute this[AttributeType type] {
            get {
                return _list.Single(x => x.Type == type);
            }
        }

        public void Increase(AttributeType attr, int points) {
            while (points > 0) {
                if (_creating || UnusedPoints > 0) {
                    _list.Single(x => x.Type == attr).Increase(1);
                    UsePoint();
                }
                points--;
            }
        }

        public void Decrease(AttributeType attr, int points) {
            _list.Single(x => x.Type == attr).Decrease(points);
        }

        public void DoneCreating() {
            _creating = false;
        }

        public IEnumerator<ReadOnlyAttribute> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

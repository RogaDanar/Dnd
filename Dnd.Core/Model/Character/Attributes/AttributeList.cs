

namespace Dnd.Core.Model.Character.Attributes
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class AttributeList : IEnumerable<ReadOnlyAttribute>
    {
        public int UnusedPoints { get; private set; }

        public Dictionary<AttributeType, int> StartAttributes { get; private set; }
        public Dictionary<AttributeType, int> ModAttributes { get; private set; }

        public ReadOnlyAttribute Strength { get { return _strength; } }
        public ReadOnlyAttribute Dexterity { get { return _dexterity; } }
        public ReadOnlyAttribute Constitution { get { return _constitution; } }
        public ReadOnlyAttribute Intelligence { get { return _intelligence; } }
        public ReadOnlyAttribute Wisdom { get { return _wisdom; } }
        public ReadOnlyAttribute Charisma { get { return _constitution; } }

        private Attribute _strength;
        private Attribute _dexterity;
        private Attribute _constitution;
        private Attribute _intelligence;
        private Attribute _wisdom;
        private Attribute _charisma;

        private List<Attribute> _list;
        private bool _creating;

        public AttributeList(Dictionary<AttributeType, int> attributeScores) {
            _creating = true;
            Initialize(attributeScores);
        }

        private void Initialize(Dictionary<AttributeType, int> attributeScores) {
            StartAttributes = attributeScores;
            var str = attributeScores.ContainsKey(AttributeType.Strength) ? attributeScores[AttributeType.Strength] : 10;
            var dex = attributeScores.ContainsKey(AttributeType.Dexterity) ? attributeScores[AttributeType.Dexterity] : 10;
            var con = attributeScores.ContainsKey(AttributeType.Constitution) ? attributeScores[AttributeType.Constitution] : 10;
            var intel = attributeScores.ContainsKey(AttributeType.Intelligence) ? attributeScores[AttributeType.Intelligence] : 10;
            var wis = attributeScores.ContainsKey(AttributeType.Wisdom) ? attributeScores[AttributeType.Wisdom] : 10;
            var cha = attributeScores.ContainsKey(AttributeType.Charisma) ? attributeScores[AttributeType.Charisma] : 10;
            _strength = new Attribute(AttributeType.Strength, str);
            _dexterity = new Attribute(AttributeType.Dexterity, dex);
            _constitution = new Attribute(AttributeType.Constitution, con);
            _intelligence = new Attribute(AttributeType.Intelligence, intel);
            _wisdom = new Attribute(AttributeType.Wisdom, wis);
            _charisma = new Attribute(AttributeType.Charisma, cha);
            _list = new List<Attribute>
                {
                    _strength,
                    _dexterity,
                    _constitution,
                    _intelligence,
                    _wisdom,
                    _charisma
                };
            ModAttributes = new Dictionary<AttributeType, int>
                {
                    {AttributeType.Strength, 0},
                    {AttributeType.Dexterity , 0},
                    {AttributeType.Constitution , 0},
                    {AttributeType.Intelligence , 0},
                    {AttributeType.Wisdom , 0},
                    {AttributeType.Charisma , 0}
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
                    ModAttributes[attr]++;
                    UsePoint();
                }
                points--;
            }
        }

        public void Decrease(AttributeType attr, int points) {
            _list.Single(x => x.Type == attr).Decrease(points);
            ModAttributes[attr]--;
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

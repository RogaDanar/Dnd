namespace Dnd.Core.Character.Attributes
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class AttributeList : IEnumerable<ReadOnlyAttribute>
    {
        public Attribute Strength { get; private set; }
        public Attribute Dexterity { get; private set; }
        public Attribute Constitution { get; private set; }
        public Attribute Intelligence { get; private set; }
        public Attribute Wisdom { get; private set; }
        public Attribute Charisma { get; private set; }

        private readonly List<Attribute> _list;

        public AttributeList() {
            Strength = new Attribute(AttributeType.Strength, 10);
            Dexterity = new Attribute(AttributeType.Dexterity, 10);
            Constitution = new Attribute(AttributeType.Constitution, 10);
            Intelligence = new Attribute(AttributeType.Intelligence, 10);
            Wisdom = new Attribute(AttributeType.Wisdom, 10);
            Charisma = new Attribute(AttributeType.Charisma, 10);

            _list = new List<Attribute> {
                Strength,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma
            };
        }

        public Attribute this[AttributeType type] {
            get {
                return _list.Single(x => x.Type == type);
            }
        }

        public void Increase(AttributeType attr, int points) {
            _list.Single(x => x.Type == attr).Increase(points);
        }

        public void Decrease(AttributeType attr, int points) {
            _list.Single(x => x.Type == attr).Decrease(points);
        }

        public IEnumerator<ReadOnlyAttribute> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

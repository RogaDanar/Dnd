namespace Dnd.Core.Model.Character.Attributes
{
    using Dnd.Core.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class AttributeList : IEnumerable<ReadOnlyAttribute>
    {
        private const int _defaultScore = 10;
        private bool _creating;

        private readonly List<Attribute> _attributes = new List<Attribute>();
        private readonly Attribute _strength;
        private readonly Attribute _dexterity;
        private readonly Attribute _constitution;
        private readonly Attribute _intelligence;
        private readonly Attribute _wisdom;
        private readonly Attribute _charisma;

        /// <summary>
        /// Attribute points still available
        /// </summary>
        public int UnusedPoints { get; private set; }

        /// <summary>
        /// The attribute scores with which the character was originally created. This score
        /// in combination with the added scores (through levelling for instance) results in the current value;
        /// </summary>
        public IReadOnlyDictionary<AttributeType, int> StartAttributeScores { get; private set; }

        /// <summary>
        /// Added scores since the original creation. These scores added to the starting scores result in the
        /// current base values.
        /// </summary>
        public IReadOnlyDictionary<AttributeType, int> AddedAttributeScores {
            get {
                return new ReadOnlyDictionary<AttributeType, int>(
                    _attributes.ToDictionary(x => x.Type, y => y.BaseScore - StartAttributeScores[y.Type]));
            }
        }

        public ReadOnlyAttribute Strength { get { return new ReadOnlyAttribute(_strength); } }
        public ReadOnlyAttribute Dexterity { get { return new ReadOnlyAttribute(_dexterity); } }
        public ReadOnlyAttribute Constitution { get { return new ReadOnlyAttribute(_constitution); } }
        public ReadOnlyAttribute Intelligence { get { return new ReadOnlyAttribute(_intelligence); } }
        public ReadOnlyAttribute Wisdom { get { return new ReadOnlyAttribute(_wisdom); } }
        public ReadOnlyAttribute Charisma { get { return new ReadOnlyAttribute(_constitution); } }

        public ReadOnlyAttribute this[AttributeType type] {
            get {
                return new ReadOnlyAttribute(_attributes.Single(x => x.Type == type));
            }
        }

        /// <summary>
        /// Calling this constructor will set this class to a creation state. To finish the creation
        /// the <see cref="DoneCreating"/> method needs to be called
        /// </summary>
        /// <param name="attributeScores">Any type that isn;t in the dictionary will be set to a default score.</param>
        public AttributeList(Dictionary<AttributeType, int> attributeScores) {
            _creating = true;
            StartAttributeScores = new ReadOnlyDictionary<AttributeType, int>(attributeScores);

            var str = attributeScores.GetValueOrDefault(AttributeType.Strength, _defaultScore);
            var dex = attributeScores.GetValueOrDefault(AttributeType.Dexterity, _defaultScore);
            var con = attributeScores.GetValueOrDefault(AttributeType.Constitution, _defaultScore);
            var @int = attributeScores.GetValueOrDefault(AttributeType.Intelligence, _defaultScore);
            var wis = attributeScores.GetValueOrDefault(AttributeType.Wisdom, _defaultScore);
            var cha = attributeScores.GetValueOrDefault(AttributeType.Charisma, _defaultScore);

            _strength = new Attribute(AttributeType.Strength, str);
            _dexterity = new Attribute(AttributeType.Dexterity, dex);
            _constitution = new Attribute(AttributeType.Constitution, con);
            _intelligence = new Attribute(AttributeType.Intelligence, @int);
            _wisdom = new Attribute(AttributeType.Wisdom, wis);
            _charisma = new Attribute(AttributeType.Charisma, cha);

            _attributes.AddRange(new[] { _strength, _dexterity, _constitution, _intelligence, _wisdom, _charisma });
        }

        /// <summary>
        /// Add points which can be used to increase attributes.
        /// </summary>
        /// <param name="amount">A positive value to add. A negative value will throw an exception</param>
        public void AddPoints(int amount) {
            if (amount < 0) {
                throw new ArgumentException("Must be positive, point can onyl be added.", "amount");
            }
            UnusedPoints += amount;
        }

        /// <summary>
        /// Increase the given attribute with the given amount, as long as there are Unused points available or
        /// we still are in the creation phase.
        /// </summary>
        /// <param name="attr">Specifies the attribute to increase</param>
        /// <param name="points">A positive value. Providing a negative value has no effect</param>
        public void Increase(AttributeType attr, int points) {
            while (points > 0) {
                if (_creating || UnusedPoints > 0) {
                    _attributes.Single(x => x.Type == attr).Increase(1);
                    usePoint();
                }
                points--;
            }
        }

        /// <summary>
        /// Increase the given attribute with the given amount.
        /// </summary>
        /// <param name="attr">Specifies the attribute to increase</param>
        /// <param name="points">A positive value. Providing a negative value will throw an exception</param>
        public void Decrease(AttributeType attr, int points) {
            if (points < 0) {
                throw new ArgumentException("Must be positive, point can onyl be added.", "points");
            }
            _attributes.Single(x => x.Type == attr).Decrease(points);
        }

        /// <summary>
        /// Will change the state of this object, so modifications are restricted.
        /// </summary>
        public void DoneCreating() {
            _creating = false;
        }

        private void usePoint() {
            if (UnusedPoints > 0 && !_creating) {
                UnusedPoints--;
            }
        }

        public IEnumerator<ReadOnlyAttribute> GetEnumerator() {
            return _attributes.Select(x => new ReadOnlyAttribute(x)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

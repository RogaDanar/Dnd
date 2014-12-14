namespace Dnd.Core.Model.Character.Abilities
{
    using Dnd.Core.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class AbilityList : IEnumerable<ReadOnlyAbility>
    {
        private const int _defaultScore = 10;
        private bool _creating;

        private readonly List<Ability> _abilities = new List<Ability>();
        private readonly Ability _strength;
        private readonly Ability _dexterity;
        private readonly Ability _constitution;
        private readonly Ability _intelligence;
        private readonly Ability _wisdom;
        private readonly Ability _charisma;

        /// <summary>
        /// Ability points still available
        /// </summary>
        public int UnusedPoints { get; private set; }

        /// <summary>
        /// The ability scores with which the character was originally created. This score
        /// in combination with the added scores (through levelling for instance) results in the current value;
        /// </summary>
        public IReadOnlyDictionary<AbilityType, int> StartAbilityScores { get; private set; }

        /// <summary>
        /// Added scores since the original creation. These scores added to the starting scores result in the
        /// current base values.
        /// </summary>
        public IReadOnlyDictionary<AbilityType, int> AddedAbilityScores {
            get {
                return new ReadOnlyDictionary<AbilityType, int>(
                    _abilities.ToDictionary(x => x.Type, y => y.BaseScore - StartAbilityScores[y.Type]));
            }
        }

        public ReadOnlyAbility Strength { get { return new ReadOnlyAbility(_strength); } }
        public ReadOnlyAbility Dexterity { get { return new ReadOnlyAbility(_dexterity); } }
        public ReadOnlyAbility Constitution { get { return new ReadOnlyAbility(_constitution); } }
        public ReadOnlyAbility Intelligence { get { return new ReadOnlyAbility(_intelligence); } }
        public ReadOnlyAbility Wisdom { get { return new ReadOnlyAbility(_wisdom); } }
        public ReadOnlyAbility Charisma { get { return new ReadOnlyAbility(_constitution); } }

        public ReadOnlyAbility this[AbilityType type] {
            get {
                return new ReadOnlyAbility(_abilities.Single(x => x.Type == type));
            }
        }


        /// <summary>
        /// Calling this constructor will set this class to a creation state. To finish the creation
        /// the <see cref="DoneCreating"/> method needs to be called. All abilitys will de set to a
        /// default value
        /// </summary>
        public AbilityList()
            : this(new Dictionary<AbilityType, int>()) { }

        /// <summary>
        /// Calling this constructor will set this class to a creation state. To finish the creation
        /// the <see cref="DoneCreating"/> method needs to be called.
        /// </summary>
        /// <param name="abilityScores">Any type that isn't in the dictionary will be set to a default score.</param>
        public AbilityList(Dictionary<AbilityType, int> abilityScores) {
            _creating = true;
            StartAbilityScores = new ReadOnlyDictionary<AbilityType, int>(abilityScores);

            var str = abilityScores.GetValueOrDefault(AbilityType.Strength, _defaultScore);
            var dex = abilityScores.GetValueOrDefault(AbilityType.Dexterity, _defaultScore);
            var con = abilityScores.GetValueOrDefault(AbilityType.Constitution, _defaultScore);
            var @int = abilityScores.GetValueOrDefault(AbilityType.Intelligence, _defaultScore);
            var wis = abilityScores.GetValueOrDefault(AbilityType.Wisdom, _defaultScore);
            var cha = abilityScores.GetValueOrDefault(AbilityType.Charisma, _defaultScore);

            _strength = new Ability(AbilityType.Strength, str);
            _dexterity = new Ability(AbilityType.Dexterity, dex);
            _constitution = new Ability(AbilityType.Constitution, con);
            _intelligence = new Ability(AbilityType.Intelligence, @int);
            _wisdom = new Ability(AbilityType.Wisdom, wis);
            _charisma = new Ability(AbilityType.Charisma, cha);

            _abilities.AddRange(new[] { _strength, _dexterity, _constitution, _intelligence, _wisdom, _charisma });
        }

        /// <summary>
        /// Add points which can be used to increase abilitys.
        /// </summary>
        /// <param name="amount">A positive value to add. A negative value will throw an exception</param>
        public void AddPoints(int amount) {
            if (amount < 0) {
                throw new ArgumentException("Must be positive, point can onyl be added.", "amount");
            }
            UnusedPoints += amount;
        }

        /// <summary>
        /// Increase the given ability with the given amount, as long as there are Unused points available or
        /// we still are in the creation phase.
        /// </summary>
        /// <param name="ability">Specifies the ability to increase</param>
        /// <param name="points">A positive value. Providing a negative value has no effect</param>
        public void Increase(AbilityType ability, int points) {
            while (points > 0) {
                if (_creating || UnusedPoints > 0) {
                    _abilities.Single(x => x.Type == ability).Increase(1);
                    usePoint();
                }
                points--;
            }
        }

        /// <summary>
        /// Increase the given ability with the given amount.
        /// </summary>
        /// <param name="ability">Specifies the ability to increase</param>
        /// <param name="points">A positive value. Providing a negative value will throw an exception</param>
        public void Decrease(AbilityType ability, int points) {
            if (points < 0) {
                throw new ArgumentException("Must be positive, point can onyl be added.", "points");
            }
            _abilities.Single(x => x.Type == ability).Decrease(points);
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

        public IEnumerator<ReadOnlyAbility> GetEnumerator() {
            return _abilities.Select(x => new ReadOnlyAbility(x)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

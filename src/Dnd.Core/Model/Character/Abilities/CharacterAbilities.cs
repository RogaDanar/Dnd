namespace Dnd.Core.Model.Character.Abilities
{
    using Dnd.Core.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class CharacterAbilities : IEnumerable<ReadOnlyAbility>
    {
        private const int _defaultScore = 10;

        private readonly IDictionary<AbilityType, Ability> _abilities;
        public ReadOnlyAbility Strength { get { return new ReadOnlyAbility(_abilities[AbilityType.Strength]); } }
        public ReadOnlyAbility Dexterity { get { return new ReadOnlyAbility(_abilities[AbilityType.Dexterity]); } }
        public ReadOnlyAbility Constitution { get { return new ReadOnlyAbility(_abilities[AbilityType.Constitution]); } }
        public ReadOnlyAbility Intelligence { get { return new ReadOnlyAbility(_abilities[AbilityType.Intelligence]); } }
        public ReadOnlyAbility Wisdom { get { return new ReadOnlyAbility(_abilities[AbilityType.Wisdom]); } }
        public ReadOnlyAbility Charisma { get { return new ReadOnlyAbility(_abilities[AbilityType.Charisma]); } }

        public ReadOnlyAbility this[AbilityType type] {
            get {
                return new ReadOnlyAbility(_abilities[type]);
            }
        }

        /// <summary>
        /// Ability points still available
        /// </summary>
        public int UnusedPoints { get; private set; }

        /// <summary>
        /// The ability scores with which the character was originally created. This score
        /// in combination with the added scores (through levelling for instance) results in the current value;
        /// </summary>
        public IReadOnlyDictionary<AbilityType, int> StartScores { get; private set; }

        /// <summary>
        /// Added scores since the original creation. These scores added to the starting scores result in the
        /// current base values.
        /// </summary>
        public IReadOnlyDictionary<AbilityType, int> AddedScores {
            get {
                return new ReadOnlyDictionary<AbilityType, int>(
                    _abilities.Values.ToDictionary(x => x.Type, y => y.BaseScore - StartScores[y.Type]));
            }
        }
        /// <summary>
        /// Create AbilityScores with default valus, or supply your own values
        /// </summary>
        /// <param name="abilityScores">Any type that isn't in the dictionary will be set to a default score.</param>
        public CharacterAbilities(Dictionary<AbilityType, int> abilityScores = null) {
            abilityScores = abilityScores ?? new Dictionary<AbilityType, int>();
            StartScores = new ReadOnlyDictionary<AbilityType, int>(abilityScores);

            var str = abilityScores.GetValueOrDefault(AbilityType.Strength, _defaultScore);
            var dex = abilityScores.GetValueOrDefault(AbilityType.Dexterity, _defaultScore);
            var con = abilityScores.GetValueOrDefault(AbilityType.Constitution, _defaultScore);
            var @int = abilityScores.GetValueOrDefault(AbilityType.Intelligence, _defaultScore);
            var wis = abilityScores.GetValueOrDefault(AbilityType.Wisdom, _defaultScore);
            var cha = abilityScores.GetValueOrDefault(AbilityType.Charisma, _defaultScore);

            var strength = new Ability(AbilityType.Strength, str);
            var dexterity = new Ability(AbilityType.Dexterity, dex);
            var constitution = new Ability(AbilityType.Constitution, con);
            var intelligence = new Ability(AbilityType.Intelligence, @int);
            var wisdom = new Ability(AbilityType.Wisdom, wis);
            var charisma = new Ability(AbilityType.Charisma, cha);

            _abilities = new[] { strength, dexterity, constitution, intelligence, wisdom, charisma }.ToDictionary(x => x.Type, y => y);
        }

        /// <summary>
        /// Add points which can be used to increase abilitys.
        /// </summary>
        /// <param name="amount">A positive value to add. A negative value will throw an exception</param>
        public void AddPoints(int amount) {
            if (amount < 0) {
                throw new ArgumentException("Must be positive, point can only be added.", "amount");
            }
            UnusedPoints += amount;
        }

        /// <summary>
        /// Increase the given ability with the given amount.
        /// </summary>
        /// <param name="type">Specifies the ability to increase</param>
        /// <param name="points">A positive value. Providing a negative value has no effect</param>
        public void Increase(AbilityType type, int points) {
            while (points > 0) {
                if (UnusedPoints > 0) {
                    _abilities[type].Increase(1);
                    UnusedPoints--;
                }
                points--;
            }
        }

        /// <summary>
        /// Increase the given ability with the given amount.
        /// </summary>
        /// <param name="type">Specifies the ability to increase</param>
        /// <param name="points">A positive value. Providing a negative value will throw an exception</param>
        public void Decrease(AbilityType type, int points) {
            if (points < 0) {
                throw new ArgumentException("Must be positive, point can onyl be added.", "points");
            }
            _abilities[type].Decrease(points);
        }

        public IReadOnlyDictionary<AbilityType, ReadOnlyAbility> AsReadOnlyDictionary() {
            return new ReadOnlyDictionary<AbilityType, ReadOnlyAbility>(_abilities.ToDictionary(x => x.Key, y => new ReadOnlyAbility(y.Value)));
        }

        public IEnumerator<ReadOnlyAbility> GetEnumerator() {
            return _abilities.Select(x => new ReadOnlyAbility(x.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}

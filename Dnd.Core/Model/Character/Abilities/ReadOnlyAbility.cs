namespace Dnd.Core.Model.Character.Abilities
{
    using System;

    /// <summary>
    /// Wrapper for the <see cref="Ability"/> class to make it read only.
    /// Prevent any modification by making it impossible to cast it back to an <see cref="Ability"/> 
    /// </summary>
    public class ReadOnlyAbility
    {
        private readonly Ability _ability;

        public AbilityType Type { get { return _ability.Type; } }
        public int Score { get { return _ability.Score; } }
        public int BaseScore { get { return _ability.BaseScore; } }
        public int BonusScore { get { return _ability.BonusScore; } }
        public int Modifier { get { return _ability.Modifier; } }

        public ReadOnlyAbility(Ability ability) {
            if (ability == null) {
                throw new ArgumentNullException("ability", "ReadOnlyAbility requires a normal ability");
            }
            _ability = ability;
        }

        public static implicit operator int(ReadOnlyAbility ability) {
            return ability.Score;
        }
    }
}

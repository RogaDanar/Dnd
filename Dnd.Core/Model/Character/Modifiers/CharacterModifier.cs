namespace Dnd.Core.Model.Character.Modifiers
{
    /// <summary>
    /// The base character modifier, which adds the base features and ability points for any character
    /// </summary>
    public class CharacterModifier : ICharacterModifier
    {
        public void ModifyOnCreation(ICharacter subject) {
            subject.Features.IncreaseFeatureCount(1);
        }

        public void ModifyOnLevel(ICharacter subject) {
            if (subject.Experience.Level % 4 == 0) {
                subject.Abilities.AddPoints(1);
            }
            if (subject.Experience.Level % 3 == 0) {
                subject.Features.IncreaseFeatureCount(1);
            }
        }
    }
}

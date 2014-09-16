namespace Dnd.Core.Model.Character.Modifiers
{
    public class CharacterModifier : IModifier<ICharacter>
    {
        public void ModifyOnCreation(ICharacter subject) {
            subject.Features.IncreaseFeatureCount(1);
        }

        public void ModifyOnLevel(ICharacter subject) {
            if (subject.Experience.Level % 4 == 0) {
                subject.Attributes.AddPoints(1);
            }
            if (subject.Experience.Level % 3 == 0) {
                subject.Features.IncreaseFeatureCount(1);
            }
        }
    }
}

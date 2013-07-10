namespace Dnd.Core.Character.Modifiers
{
    public class CharacterModifier : IModifier<DefaultCharacter>
    {
        public void ModifyOnCreation(DefaultCharacter subject) {
            subject.AddFeatures(1);
        }

        public void ModifyOnLevel(DefaultCharacter subject) {
            if (subject.Level % 4 == 0) {
                subject.AddAttributePoints(1);
            }
            if (subject.Level % 3 == 0) {
                subject.AddFeatures(1);
            }
        }
    }
}

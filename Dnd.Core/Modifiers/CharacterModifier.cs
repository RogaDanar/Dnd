namespace Dnd.Core.Modifiers
{
    public class CharacterModifier : IModifier<Character>
    {
        public void ModifyOnCreation(Character subject) {
            subject.AddFeatures(1);
        }

        public void ModifyOnLevel(Character subject) {
            if (subject.Level % 4 == 0) {
                subject.AddAttributePoints(1);
            }
            if (subject.Level % 3 == 0) {
                subject.AddFeatures(1);
            }
        }
    }
}

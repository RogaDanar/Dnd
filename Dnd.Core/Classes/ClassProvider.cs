namespace Dnd.Core.Classes
{
    using Dnd.Core.Character.Modifiers;

    public static class ClassProvider
    {
        public static IClass GetNewClass(ClassType classType, ModifierProvider modifierProvider) {
            return new CharacterClass(classType, 1, modifierProvider.GetClassModifier(classType));
        }

        public static IClass GetNextLevel(IClass charClass, ModifierProvider modifierProvider) {
            return new CharacterClass(charClass.ClassType, charClass.Level + 1, modifierProvider.GetClassModifier(charClass.ClassType));
        }
    }
}

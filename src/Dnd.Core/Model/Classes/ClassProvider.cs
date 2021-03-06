﻿namespace Dnd.Core.Model.Classes
{
    using Dnd.Core.Model.Character.Modifiers;

    public static class ClassProvider
    {
        public static IClass GetNewClass(ClassType classType, IModifierProvider modifierProvider) {
            return new CharacterClass(classType, 1, modifierProvider.GetClassModifier(classType));
        }

        public static IClass GetNextLevel(IClass charClass, IModifierProvider modifierProvider) {
            return new CharacterClass(charClass.ClassType, charClass.Level + 1, modifierProvider.GetClassModifier(charClass.ClassType));
        }
    }
}

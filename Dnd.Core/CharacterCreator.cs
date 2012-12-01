namespace Dnd.Core
{
    using Dnd.Core.Enums;
    using Dnd.Core.Modifiers;

    public class CharacterCreator
    {
        public static Character CreateCharacter(Race race, Class charClass, int level) {
            var character = new Character(charClass, race, new ModifierProvider());
            while (level > 1) {
                character.SetExperienceToNextLevel();
                level--;
            }
            return character;
        }
    }
}

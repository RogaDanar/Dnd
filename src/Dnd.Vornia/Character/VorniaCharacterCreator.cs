namespace Dnd.Vornia.Character
{
    using Dnd.Core.Model.Character;
    using Dnd.Vornia.CharacterTemplates;

    public static class VorniaCharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static ICharacter CreateMaswari() {
            return new Maswari();
        }

        public static ICharacter CreateMaswariCommander() {
            return new MaswariCommander();
        }
    }
}

namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Modifiers;

    public interface IRaceModifier : IModifier<ICharacter>
    {
        Size Size { get; }
        int Speed { get; }
    }
}

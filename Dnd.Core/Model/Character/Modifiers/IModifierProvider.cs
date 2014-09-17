namespace Dnd.Core.Model.Character.Modifiers
{
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Classes.Modifiers;
    using Dnd.Core.Model.Races;
    using Dnd.Core.Model.Races.Modifiers;

    public interface IModifierProvider
    {
        ICharacterModifier GetBaseModifier();
        IClassModifier GetClassModifier(ClassType classType);
        IRaceModifier GetRaceModifier(Race race);
    }
}

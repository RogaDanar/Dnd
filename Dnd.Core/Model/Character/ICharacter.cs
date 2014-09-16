namespace Dnd.Core.Model.Character
{
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Character.Saves;
    using Dnd.Core.Model.Character.Skills;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Classes.Modifiers;
    using Dnd.Core.Model.Items;
    using Dnd.Core.Model.Races;
    using System.Collections.Generic;

    public interface ICharacter : IModifiable<ICharacter>, ISize, IEntity<int>
    {
        string Name { get; set; }
        Race Race { get; }
        new Size Size { get; set; }
        Dictionary<ClassType, IClass> Classes { get; }
        int Speed { get; set; }
        Hitpoints Hitpoints { get; }
        Experience Experience { get; }
        AttributeList Attributes { get; }
        ReadOnlyAttribute Strength { get; }
        ReadOnlyAttribute Dexterity { get; }
        ReadOnlyAttribute Constitution { get; }
        ReadOnlyAttribute Intelligence { get; }
        ReadOnlyAttribute Wisdom { get; }
        ReadOnlyAttribute Charisma { get; }
        SavesList Saves { get; }
        AttackList Attacks { get; }
        FeatureList Features { get; }
        SkillList Skills { get; }
        Equipment Equipment { get; }
        int AC(bool flatFooted = false);
        void LevelUp(ClassType charClass);
        void AcceptOnMultiClass(IClassModifier modifier);
    }
}
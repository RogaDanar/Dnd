using System.Collections.Generic;
using Dnd.Core.Character.Attacks;
using Dnd.Core.Character.Attributes;
using Dnd.Core.Character.Features;
using Dnd.Core.Character.Modifiers;
using Dnd.Core.Character.Saves;
namespace Dnd.Core.Character
{
    using Dnd.Core.Character.Skills;
    using Dnd.Core.Classes;
    using Dnd.Core.Classes.Modifiers;
    using Dnd.Core.Items;
    using Dnd.Core.Races;

    public interface ICharacter : IModifiable<ICharacter>, ISize
    {
        string Name { get; set; }
        Race Race { get; }
        new Size Size { get; set; }
        Dictionary<ClassType, IClass> Classes { get; }
        int Speed { get; set; }
        Hitpoints Hitpoints { get; set; }
        Experience Experience { get; set; }
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
        int GetAc(bool flatFooted = false);
        void LevelUp(ClassType charClass);
        void AcceptOnMultiClass(IClassModifier modifier);
        bool EquipItem(IItem item);
        IWeapon GetWeapon();
    }
}
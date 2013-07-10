namespace Dnd.Core.Classes
{
    using System.Collections.Generic;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Attacks.Bonus;
    using Dnd.Core.Character.Saves;
    using Dnd.Core.Classes.Modifiers;

    public class CharacterClass : IClass
    {
        private readonly Dictionary<AttackBonusType, IAttackBonus> _attackBonusses = new Dictionary<AttackBonusType, IAttackBonus> {  
            { AttackBonusType.Poor, new PoorAttackBonus()},
            { AttackBonusType.Average, new AvgAttackBonus()},
            { AttackBonusType.Good, new GoodAttackBonus()}        
        };

        public ClassType ClassType { get; protected set; }
        public IClassModifier Modifier { get; protected set; }
        public int Level { get; protected set; }
        public SavesList Saves { get; protected set; }
        public Attack Attack { get; protected set; }

        public Save FortitudeSave { get { return Saves.FortitudeSave; } }
        public Save ReflexSave { get { return Saves.ReflexSave; } }
        public Save WillSave { get { return Saves.WillSave; } }

        public CharacterClass(ClassType classType, int level, AbstractClassModifier modifier) {
            ClassType = classType;
            Level = level;
            Modifier = modifier;
            Saves = new SavesList(modifier.FortitudeSaveType, modifier.ReflexSaveType, modifier.WillSaveType, Level);
            Attack = new Attack(_attackBonusses[modifier.AttackBonusType], level);
        }
    }
}

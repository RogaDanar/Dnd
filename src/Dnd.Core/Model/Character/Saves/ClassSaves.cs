﻿namespace Dnd.Core.Model.Character.Saves
{
    using System.Collections.Generic;

    public class ClassSaves
    {
        private readonly Dictionary<SaveBonusType, ISaveBonus> _bonusses = new Dictionary<SaveBonusType, ISaveBonus> {  
            { SaveBonusType.Poor, new PoorSaveBonus()},
            { SaveBonusType.Good, new GoodSaveBonus()}        
        };

        public Save FortitudeSave { get; private set; }
        public Save ReflexSave { get; private set; }
        public Save WillSave { get; private set; }

        public ClassSaves(SaveBonusType fortitude, SaveBonusType reflex, SaveBonusType will, int level) {
            FortitudeSave = new Save(_bonusses[fortitude], level);
            ReflexSave = new Save(_bonusses[reflex], level);
            WillSave = new Save(_bonusses[will], level);
        }
    }
}

namespace Dnd.Core.Saves
{
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public class SavesList
    {
        private readonly Dictionary<SaveBonusType, ISaveBonus> _bonusses = new Dictionary<SaveBonusType, ISaveBonus> {  
            { SaveBonusType.Poor, new PoorSaveBonus()},
            { SaveBonusType.Good, new GoodSaveBonus()}        
        };

        private Save _fortitude;
        private Save _reflex;
        private Save _will;

        public ReadOnlySave FortitudeSave { get { return _fortitude; } }
        public ReadOnlySave ReflexSave { get { return _reflex; } }
        public ReadOnlySave WillSave { get { return _will; } }

        public SavesList(SaveBonusType fortitude, SaveBonusType reflex, SaveBonusType will) {
            _fortitude = new Save(_bonusses[fortitude]);
            _reflex = new Save(_bonusses[reflex]);
            _will = new Save(_bonusses[will]);
        }

        public void AdjustSaves(SaveBonusType fortitude, SaveBonusType reflex, SaveBonusType will) {
            _fortitude.AdjustBaseBonus(_bonusses[fortitude]);
            _reflex.AdjustBaseBonus(_bonusses[reflex]);
            _will.AdjustBaseBonus(_bonusses[will]);
        }

        public void IncreaseLevel() {
            _fortitude.IncreaseLevel();
            _reflex.IncreaseLevel();
            _will.IncreaseLevel();
        }

        public void AdjustBonus(SaveType type, int value) {
            switch (type) {
                case SaveType.Fortitude:
                    _fortitude.AdjustBonus(value);
                    break;
                case SaveType.Reflex:
                    _reflex.AdjustBonus(value);
                    break;
                case SaveType.Will:
                    _will.AdjustBonus(value);
                    break;
                default:
                    break;
            }
        }
    }
}

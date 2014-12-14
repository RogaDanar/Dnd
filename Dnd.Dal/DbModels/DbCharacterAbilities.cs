namespace Dnd.Dal.DbModels
{
    using System.Collections.Generic;
    using Core.Model;
    using Core.Model.Character.Abilities;

    public class DbCharacterAbilities : IEntity<int>
    {
        public int Id { get; set; }

        //public DbCharacter Character { get; set; }

        public int StartStrength { get; set; }
        public int StartDexterity { get; set; }
        public int StartConstitution { get; set; }
        public int StartIntelligence { get; set; }
        public int StartWisdom { get; set; }
        public int StartCharisma { get; set; }

        public int ModStrength { get; set; }
        public int ModDexterity { get; set; }
        public int ModConstitution { get; set; }
        public int ModIntelligence { get; set; }
        public int ModWisdom { get; set; }
        public int ModCharisma { get; set; }

        public Dictionary<AbilityType, int> StartValues {
            get {
                return new Dictionary<AbilityType, int>
                    {
                        {AbilityType.Strength, StartStrength},
                        {AbilityType.Dexterity, StartDexterity},
                        {AbilityType.Constitution, StartConstitution},
                        {AbilityType.Intelligence, StartIntelligence},
                        {AbilityType.Wisdom, StartWisdom},
                        {AbilityType.Charisma, StartCharisma}
                    };
            }
        }

        public Dictionary<AbilityType, int> ModValues {
            get {
                var modValues = new Dictionary<AbilityType, int>();
                if (ModStrength > 0) {
                    modValues.Add(AbilityType.Strength, ModStrength);
                }
                if (ModDexterity > 0) {
                    modValues.Add(AbilityType.Dexterity, ModDexterity);
                }
                if (ModConstitution > 0) {
                    modValues.Add(AbilityType.Constitution, ModConstitution);
                }
                if (ModIntelligence > 0) {
                    modValues.Add(AbilityType.Intelligence, ModIntelligence);
                }
                if (ModWisdom > 0) {
                    modValues.Add(AbilityType.Wisdom, ModWisdom);
                }
                if (ModCharisma > 0) {
                    modValues.Add(AbilityType.Charisma, ModCharisma);
                }
                return modValues;
            }
        }
    }
}

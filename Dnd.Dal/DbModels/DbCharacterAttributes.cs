namespace Dnd.Dal.DbModels
{
    using System.Collections.Generic;
    using Core.Model;
    using Core.Model.Character.Attributes;

    public class DbCharacterAttributes : IEntity<int>
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

        public Dictionary<AttributeType, int> StartValues {
            get {
                return new Dictionary<AttributeType, int>
                    {
                        {AttributeType.Strength, StartStrength},
                        {AttributeType.Dexterity, StartDexterity},
                        {AttributeType.Constitution, StartConstitution},
                        {AttributeType.Intelligence, StartIntelligence},
                        {AttributeType.Wisdom, StartWisdom},
                        {AttributeType.Charisma, StartCharisma}
                    };
            }
        }

        public Dictionary<AttributeType, int> ModValues {
            get {
                var modValues = new Dictionary<AttributeType, int>();
                if (ModStrength > 0) {
                    modValues.Add(AttributeType.Strength, ModStrength);
                }
                if (ModDexterity > 0) {
                    modValues.Add(AttributeType.Dexterity, ModDexterity);
                }
                if (ModConstitution > 0) {
                    modValues.Add(AttributeType.Constitution, ModConstitution);
                }
                if (ModIntelligence > 0) {
                    modValues.Add(AttributeType.Intelligence, ModIntelligence);
                }
                if (ModWisdom > 0) {
                    modValues.Add(AttributeType.Wisdom, ModWisdom);
                }
                if (ModCharisma > 0) {
                    modValues.Add(AttributeType.Charisma, ModCharisma);
                }
                return modValues;
            }
        }
    }
}

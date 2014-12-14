namespace Dnd.Dal.DbModels
{
    using Core.Model;
    using Core.Model.Character;
    using Core.Model.Character.Skills;
    using Core.Model.Classes;
    using Core.Model.Races;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class DbCharacter : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Race { get; set; }
        public int HitpointsCurrent { get; set; }
        public int HitpointsMax { get; set; }
        public int Experience { get; set; }

        public DbCharacterAbilities Abilities { get; set; }

        public ICollection<DbCharacterClass> Classes { get; set; }
        public ICollection<DbCharacterFeature> Features { get; set; }
        public ICollection<DbCharacterSkill> Skills { get; set; }

        public DbCharacter() {
            Classes = new Collection<DbCharacterClass>();
            Features = new Collection<DbCharacterFeature>();
            Skills = new Collection<DbCharacterSkill>();
        }

        public ICharacter ToCharacter() {
            var character = CharacterCreator.CreateCharacter((Race)Race, (ClassType)Classes.First().Type, Classes.First().Level, Abilities.StartValues);
            character.Name = Name;
            foreach (var charClass in Classes.Skip(1)) {
                for (int i = 0; i < charClass.Level; i++) {
                    character.LevelUp((ClassType)charClass.Type);
                }
            }
            foreach (var modValue in Abilities.ModValues) {
                character.Abilities.Increase(modValue.Key, modValue.Value);
            }
            //foreach (var feature in Features) {
            //    character.Features.Add((Feature)feature.Feature);
            //}
            foreach (var skill in Skills) {
                character.Skills.Increase((SkillType)skill.Type, skill.Ranks);
            }
            return character;
        }
    }
}

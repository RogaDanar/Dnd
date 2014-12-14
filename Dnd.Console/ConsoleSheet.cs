namespace Dnd.CharGenerator
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Items.Weapons;
    using System;
    using System.Linq;

    /// <summary>
    /// Displays a character to the console
    /// </summary>
    public class ConsoleSheet
    {
        private const ConsoleColor HEADER_COLOR = ConsoleColor.Yellow;

        private ConsoleSheet() { }

        public static void Display(ICharacter character) {
            DisplayStatus(character);
            DisplayAbilities(character);
            DisplaySaves(character);
            DisplayOneHandedAttacks(character);
            DisplayEquipment(character);
            DisplayFeatures(character);
            DisplaySkills(character);
        }

        private static void DisplayStatus(ICharacter character) {
            PrintHeader("Character Sheet");
            Console.WriteLine("Name:  " + character.Name);
            Console.WriteLine("Level: " + character.Experience.Level);
            Console.WriteLine("XP:    " + character.Experience.Current);
            Console.WriteLine("Race:  " + character.Race);
            Console.WriteLine("Class: " + string.Join(", ", character.Classes.Keys.ToArray()));
            Console.WriteLine("HP:    " + character.Hitpoints.Max);
            Console.WriteLine("Size:  " + character.Size);
            Console.WriteLine("Speed: " + character.Speed + "ft");
        }

        private static void DisplaySkills(ICharacter character) {
            PrintHeader("Skills", character.Skills.UnusedRanks);
            foreach (var skill in character.Skills) {
                Console.Write(skill.Key + ": ");
                if (skill.Value > 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(skill.Value + Environment.NewLine);
                Console.ResetColor();
            }
        }

        private static void DisplayFeatures(ICharacter character) {
            PrintHeader("Features", character.Features.UnusedFeatures);
            foreach (var feat in character.Features) {
                Console.WriteLine(feat);
            }
        }

        private static void DisplayOneHandedAttacks(ICharacter character) {
            PrintHeader("Attacks");
            foreach (var attack in character.Attacks.GetAttackScores(WeaponType.OneHanded)) {
                Console.WriteLine("+{0}", attack);
            }
        }

        private static void DisplayEquipment(ICharacter character) {
            PrintHeader("Equipment");
            foreach (var slot in character.Equipment.Slots.Where(x => x.Value != null)) {
                Console.WriteLine("{0}: {1}", slot.Key, slot.Value.Name);
            }
        }

        private static void DisplaySaves(ICharacter character) {
            PrintHeader("Saves");
            Console.WriteLine("Fortitude: " + character.Saves.Fortitude);
            Console.WriteLine("Reflex:    " + character.Saves.Reflex);
            Console.WriteLine("Will:      " + character.Saves.Will);
        }

        private static void DisplayAbilities(ICharacter character) {
            PrintHeader("Abilities", character.Abilities.UnusedPoints);
            foreach (var ability in character.Abilities) {
                Console.WriteLine("{0} ({1}) {2}", ability.Score, ability.Modifier, ability.Type);
            }
        }

        private static void PrintHeader(string headerTitle) {
            Console.ForegroundColor = HEADER_COLOR;
            Console.WriteLine("****  {0}", headerTitle);
            Console.ResetColor();
        }

        private static void PrintHeader(string headerTitle, int unusedSkillPoints) {
            Console.ForegroundColor = HEADER_COLOR;
            Console.WriteLine("****  {0}    *** Unused: {1}", headerTitle, unusedSkillPoints);
            Console.ResetColor();
        }
    }
}

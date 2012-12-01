namespace Dnd.CharGenerator
{
    using System;
    using Dnd.Core;
    using Dnd.Core.Enums;

    public class ConsoleSheet
    {
        private const ConsoleColor HEADER_COLOR = ConsoleColor.Yellow;

        private ConsoleSheet() { }

        public static void Display(Character character) {
            Console.WriteLine("Level: " + character.Level);
            Console.WriteLine("XP:    " + character.Experience);
            Console.WriteLine("Race:  " + character.Race);
            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("HP:    " + character.HpMax);
            Console.WriteLine("Size:  " + character.Size);
            Console.WriteLine("Speed: " + character.Speed + "ft");

            DisplayAttributes(character);
            DisplaySaves(character);
            DisplayAttacks(character);
            DisplayFeatures(character);
            DisplaySkills(character);
        }

        private static void DisplaySkills(Character character) {
            PrintHeader("Skills", character.UnusedSkillPoints);
            foreach (var skill in character.Skills) {
                Console.Write(skill.Key + ": ");
                if (skill.Value > 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(skill.Value + Environment.NewLine);
                Console.ResetColor();
            }
        }

        private static void DisplayFeatures(Character character) {
            PrintHeader("Features", character.UnusedFeatures);
            foreach (var feat in character.Features) {
                Console.WriteLine(feat);
            }
        }

        private static void DisplayAttacks(Character character) {
            PrintHeader("Attacks");
            foreach (var attack in character.GetAttacks(WeaponType.OneHanded)) {
                Console.WriteLine(String.Format("{0}: +{1}", attack.Key, attack.Value));
            }
        }

        private static void DisplaySaves(Character character) {
            PrintHeader("Saves");
            Console.WriteLine("Fortitude: " + character.FortitudeSave);
            Console.WriteLine("Reflex:    " + character.ReflexSave);
            Console.WriteLine("Will:      " + character.WillSave);
        }

        private static void DisplayAttributes(Character character) {
            PrintHeader("Attributes", character.UnusedAttributePoints);
            foreach (var attr in character.Attributes) {
                Console.WriteLine(String.Format("{0} ({1}) {2}", attr.Score, attr.Modifier, attr.Type));
            }
        }

        private static void PrintHeader(string header) {
            Console.ForegroundColor = HEADER_COLOR;
            Console.WriteLine(String.Format("****  {0}", header));
            Console.ResetColor();
        }

        private static void PrintHeader(string header, int unused) {
            Console.ForegroundColor = HEADER_COLOR;
            Console.WriteLine(String.Format("****  {0}    *** Unused: {1}", header, unused));
            Console.ResetColor();
        }
    }
}

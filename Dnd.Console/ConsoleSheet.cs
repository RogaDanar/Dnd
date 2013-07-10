﻿namespace Dnd.CharGenerator
{
    using System;
    using System.Linq;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;

    /// <summary>
    /// Displays a character to the console
    /// </summary>
    public class ConsoleSheet
    {
        private const ConsoleColor HEADER_COLOR = ConsoleColor.Yellow;

        private ConsoleSheet() { }

        public static void Display(DefaultCharacter character) {
            DisplayStatus(character);
            DisplayAttributes(character);
            DisplaySaves(character);
            DisplayOneHandedAttacks(character);
            DisplayEquipment(character);
            DisplayFeatures(character);
            DisplaySkills(character);
        }

        private static void DisplayStatus(DefaultCharacter character) {
            PrintHeader("Character Sheet");
            Console.WriteLine("Level: " + character.Level);
            Console.WriteLine("XP:    " + character.Experience);
            Console.WriteLine("Race:  " + character.Race);
            Console.WriteLine("Class: " + string.Join(", ", character.Classes.Keys.ToArray()));
            Console.WriteLine("HP:    " + character.HpMax);
            Console.WriteLine("Size:  " + character.Size);
            Console.WriteLine("Speed: " + character.Speed + "ft");
        }

        private static void DisplaySkills(DefaultCharacter character) {
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

        private static void DisplayFeatures(DefaultCharacter character) {
            PrintHeader("Features", character.UnusedFeatures);
            foreach (var feat in character.Features) {
                Console.WriteLine(feat);
            }
        }

        private static void DisplayOneHandedAttacks(DefaultCharacter character) {
            PrintHeader("Attacks");
            foreach (var attack in character.GetAttacks(WeaponType.OneHanded)) {
                Console.WriteLine(String.Format("+{0}", attack));
            }
        }

        private static void DisplayEquipment(DefaultCharacter character) {
            PrintHeader("Equipment");
            foreach (var slot in character.Equipment.Slots.Where(x => x.Value != null)) {
                Console.WriteLine(string.Format("{0}: {1}", slot.Key, slot.Value.Name));
            }
        }

        private static void DisplaySaves(DefaultCharacter character) {
            PrintHeader("Saves");
            Console.WriteLine("Fortitude: " + character.FortitudeSave);
            Console.WriteLine("Reflex:    " + character.ReflexSave);
            Console.WriteLine("Will:      " + character.WillSave);
        }

        private static void DisplayAttributes(DefaultCharacter character) {
            PrintHeader("Attributes", character.UnusedAttributePoints);
            foreach (var attr in character.Attributes) {
                Console.WriteLine(String.Format("{0} ({1}) {2}", attr.Score, attr.Modifier, attr.Type));
            }
        }

        private static void PrintHeader(string headerTitle) {
            Console.ForegroundColor = HEADER_COLOR;
            Console.WriteLine(String.Format("****  {0}", headerTitle));
            Console.ResetColor();
        }

        private static void PrintHeader(string headerTitle, int unusedSkillPoints) {
            Console.ForegroundColor = HEADER_COLOR;
            Console.WriteLine(String.Format("****  {0}    *** Unused: {1}", headerTitle, unusedSkillPoints));
            Console.ResetColor();
        }
    }
}

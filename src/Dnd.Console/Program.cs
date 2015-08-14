namespace Dnd.CharGenerator
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private const string USAGE = @"Usage [optional]: Dnd.Console <Race> <Class> <Level> [str dex con int wis cha]";

        static int Main(string[] args) {
            // At least Race, level and class need to be provided
            if (args.Length < 3) {
                Console.WriteLine(USAGE);
                Console.ReadKey();
                return 1;
            }

            // If ability scores are provided, they need to be all there
            if (args.Length > 3 && args.Length != 9) {
                Console.WriteLine(USAGE);
                Console.ReadKey();
                return 1;
            }

            var race = GetRace(args[0]);
            var classType = GetClass(args[1]);
            var level = GetLevel(args[2]);
            var abilityScores = GetAbilityScores(args.Skip(3));

            // If either one of these is 0, it means the creation has failed, quit
            if (race == 0 || classType == 0 || level == 0) {
                return 1;
            }

            var character = CharacterCreator.CreateCharacter(race, classType, level, abilityScores);

            // write the charactersheet to the console
            ConsoleSheet.Display(character);

            Console.ReadKey();

            return 0;
        }

        /// <summary>
        /// Gets the ability scores from the program argumentlist by index. If the element is missing 
        /// a default value is used
        /// </summary>
        private static Dictionary<AbilityType, int> GetAbilityScores(IEnumerable<string> abilities) {
            const string defaultScore = "11";
            var str = Int32.Parse(abilities.ElementAtOrDefault(0) ?? defaultScore);
            var dex = Int32.Parse(abilities.ElementAtOrDefault(1) ?? defaultScore);
            var con = Int32.Parse(abilities.ElementAtOrDefault(2) ?? defaultScore);
            var intel = Int32.Parse(abilities.ElementAtOrDefault(3) ?? defaultScore);
            var wis = Int32.Parse(abilities.ElementAtOrDefault(4) ?? defaultScore);
            var cha = Int32.Parse(abilities.ElementAtOrDefault(5) ?? defaultScore);

            var abilityScores = new Dictionary<AbilityType, int>() { 
                {AbilityType.Strength, str},
                {AbilityType.Dexterity, dex},
                {AbilityType.Constitution, con},
                {AbilityType.Intelligence, intel},
                {AbilityType.Wisdom, wis},
                {AbilityType.Charisma, cha}
            };
            return abilityScores;
        }

        /// <summary>
        /// Gets the race from the program argument list and writes an error to the console if unsuccesful
        /// </summary>
        private static Race GetRace(string raceName) {
            Race race;
            if (!Enum.TryParse<Race>(raceName, true, out race)) {
                Console.WriteLine(USAGE);
                Console.WriteLine("{0} is not a valid race", raceName);
            }
            return race;
        }

        /// <summary>
        /// Gets the class from the program argument list and writes an error to the console if unsuccesful
        /// </summary>
        private static ClassType GetClass(string className) {
            ClassType charClass;
            if (!Enum.TryParse<ClassType>(className, true, out charClass)) {
                Console.WriteLine(USAGE);
                Console.WriteLine("{0} is not a valid class", className);
            }
            return charClass;
        }

        /// <summary>
        /// Gets the level from the program argument list and writes an error to the console if unsuccesful
        /// </summary>
        private static int GetLevel(string levelName) {
            int level;
            if (!Int32.TryParse(levelName, out level)) {
                Console.WriteLine(USAGE);
                Console.WriteLine("{0} is not a valid level", levelName);
            }
            return level;
        }
    }
}

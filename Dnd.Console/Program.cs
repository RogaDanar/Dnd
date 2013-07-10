namespace Dnd.CharGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Classes;
    using Dnd.Core.Races;

    class Program
    {
        private const string USAGE = "Usage [optional]: Dnd.Console <Race> <Class> <Level> [str dex con int wis cha]";

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

            var race = GetRace(args);
            var classType = GetClass(args);
            var level = GetLevel(args);
            var abilityScores = GetAbilityScores(args);

            // If either one of these is 0, it means the creation has failed, quit
            if (race == 0 || classType == 0 || level == 0) {
                return 1;
            }

            var character = CharacterCreator.CreateCharacter(race, classType, level).SetAbilities(abilityScores);
            character.SetExperienceToNextLevel();
            character.LevelUp(ClassType.Fighter);

            // write the charactersheet to the console
            ConsoleSheet.Display(character);

            Console.ReadKey();

            return 0;
        }

        /// <summary>
        /// Gets the ability scores from the program argumentlist by index. If the element is missing 
        /// a default value is used
        /// </summary>
        private static Dictionary<AttributeType, int> GetAbilityScores(string[] args) {
            const string defaultScore = "11";
            var str = Int32.Parse(args.ElementAtOrDefault(3) ?? defaultScore);
            var dex = Int32.Parse(args.ElementAtOrDefault(4) ?? defaultScore);
            var con = Int32.Parse(args.ElementAtOrDefault(5) ?? defaultScore);
            var intel = Int32.Parse(args.ElementAtOrDefault(6) ?? defaultScore);
            var wis = Int32.Parse(args.ElementAtOrDefault(7) ?? defaultScore);
            var cha = Int32.Parse(args.ElementAtOrDefault(8) ?? defaultScore);

            var abilityScores = new Dictionary<AttributeType, int>() { 
                {AttributeType.Strength, str},
                {AttributeType.Dexterity, dex},
                {AttributeType.Constitution, con},
                {AttributeType.Intelligence, intel},
                {AttributeType.Wisdom, wis},
                {AttributeType.Charisma, cha}
            };
            return abilityScores;
        }

        /// <summary>
        /// Gets the race from the program argument list and writes an error to the console if unsuccesful
        /// </summary>
        private static Race GetRace(string[] args) {
            Race race;
            if (!Enum.TryParse<Race>(args[0], true, out race)) {
                Console.WriteLine(USAGE);
                Console.WriteLine("{0} is not a valid race", args[0]);
            }
            return race;
        }

        /// <summary>
        /// Gets the class from the program argument list and writes an error to the console if unsuccesful
        /// </summary>
        private static ClassType GetClass(string[] args) {
            ClassType charClass;
            if (!Enum.TryParse<ClassType>(args[1], true, out charClass)) {
                Console.WriteLine(USAGE);
                Console.WriteLine("{0} is not a valid class", args[1]);
            }
            return charClass;
        }

        /// <summary>
        /// Gets the level from the program argument list and writes an error to the console if unsuccesful
        /// </summary>
        private static int GetLevel(string[] args) {
            int level;
            if (!Int32.TryParse(args[2], out level)) {
                Console.WriteLine(USAGE);
                Console.WriteLine("{0} is not a valid level", args[2]);
            }
            return level;
        }
    }
}

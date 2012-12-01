namespace Dnd.CharGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core;
    using Dnd.Core.Enums;

    class Program
    {
        private const string USAGE = "Usage [optional]: Dnd.Console <Race> <Class> <Level> [str dex con int wis cha]";

        static int Main(string[] args) {
            if (args.Length < 3) {
                Console.WriteLine(USAGE);
                return 1;
            }

            if (args.Length > 3 && args.Length != 9) {
                Console.WriteLine(USAGE);
                return 1;
            }

            Race race = GetRace(args);
            Class charClass = GetClass(args);
            int level = GetLevel(args);

            var abilityScores = GetAbilityScores(args);

            if (race == 0 || charClass == 0 || level == 0) {
                return 1;
            }

            var character = CharacterCreator.CreateCharacter(race, charClass, level);
            SetAbilities(character, abilityScores);
            ConsoleSheet.Display(character);

            return 0;
        }

        private static void SetAbilities(Character character, Dictionary<AttributeType, int> abilityScores) {
            foreach (var ability in abilityScores) {
                var diff = ability.Value - character.Attributes.Single(x => x.Type == ability.Key).BaseScore;
                if (diff > 0) {
                    character.IncreaseAttribute(ability.Key, diff);
                } else if (diff < 0) {
                    character.DecreaseAttribute(ability.Key, Math.Abs(diff));
                }
            }
        }

        private static Dictionary<AttributeType, int> GetAbilityScores(string[] args) {
            var str = Int32.Parse(args[3]);
            var dex = Int32.Parse(args[4]);
            var con = Int32.Parse(args[5]);
            var intel = Int32.Parse(args[6]);
            var wis = Int32.Parse(args[7]);
            var cha = Int32.Parse(args[8]);

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

        private static Race GetRace(string[] args) {
            Race race;
            if (!Enum.TryParse<Race>(args[0], true, out race)) {
                Console.WriteLine(USAGE);
                Console.WriteLine(String.Format("{0} is not a valid race", args[0]));
            }
            return race;
        }

        private static Class GetClass(string[] args) {
            Class charClass;
            if (!Enum.TryParse<Class>(args[1], true, out charClass)) {
                Console.WriteLine(USAGE);
                Console.WriteLine(String.Format("{0} is not a valid class", args[1]));
            }
            return charClass;
        }

        private static int GetLevel(string[] args) {
            int level;
            if (!Int32.TryParse(args[2], out level)) {
                Console.WriteLine(USAGE);
                Console.WriteLine(String.Format("{0} is not a valid level", args[2]));
            }
            return level;
        }
    }
}

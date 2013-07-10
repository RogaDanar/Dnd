namespace DnD.Arena
{
    using System;
    using Dnd.CharGenerator;
    using Dnd.Core;
    using Dnd.Core.Actions;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Classes;
    using Dnd.Core.Items.Armor;
    using Dnd.Core.Items.Shields;
    using Dnd.Core.Items.Weapons;
    using Dnd.Core.Races;

    class Program
    {
        private static DefaultCharacter _player1;
        private static DefaultCharacter _player2;

        static void Main(string[] args) {
            _player1 = CharacterCreator.CreateCharacter(Race.Human, ClassType.Fighter, 8);
            _player1.SetExperienceToNextLevel();
            _player1.LevelUp(ClassType.Barbarian);
            _player1.SetExperienceToNextLevel();
            _player1.LevelUp(ClassType.Barbarian);
            _player1.SetExperienceToNextLevel();
            _player1.LevelUp(ClassType.Barbarian);
            _player1.Name = "Roga";
            _player1.IncreaseAttribute(AttributeType.Strength, 4);
            _player1.IncreaseAttribute(AttributeType.Dexterity, 4);

            _player2 = CharacterCreator.CreateCharacter(Race.Human, ClassType.Fighter, 8);
            _player2.Name = "Armus";
            _player2.IncreaseAttribute(AttributeType.Strength, 4);
            _player2.IncreaseAttribute(AttributeType.Dexterity, 4);

            var greatsword = new Greatsword(Size.Medium);
            var longsword = new Longsword(Size.Medium);
            _player1.EquipItem(greatsword);
            _player1.EquipItem(new Breastplate(Size.Medium));
            _player2.EquipItem(longsword);
            _player2.EquipItem(new TowerShield(Size.Medium));

            ConsoleSheet.Display(_player1);
            Console.WriteLine();
            ConsoleSheet.Display(_player2);
            Console.ReadKey();

            var arena = new Arena(_player1, _player2);
            arena.AttackMade += ArenaAttackMade;
            arena.Attacked += ArenaAttacked;
            arena.FightDone += ArenaFightDone;
            arena.StartFight();
        }

        static void ArenaFightDone(object sender, EventArgs e) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (_player1.HpCurrent <= 0) {
                Console.WriteLine("You died.");
            } else {
                Console.WriteLine("You slay " + _player2.Name + "!");
            }
            Console.ResetColor();

            Console.WriteLine("{0} hp: {1}", _player1.Name, _player1.HpCurrent);
            Console.WriteLine("{0} hp: {1}", _player2.Name, _player2.HpCurrent);
        }

        static void ArenaAttackMade(object sender, AttackEventArgs e) {
            var color = ConsoleColor.White;
            string result = string.Empty;
            switch (e.AttackResult) {
                case AttackResultType.Hit:
                    result = "hit";
                    color = ConsoleColor.Green;
                    break;
                case AttackResultType.CriticalHit:
                    result = "critically hit";
                    color = ConsoleColor.DarkGreen;
                    break;
                case AttackResultType.Miss:
                    result = "miss";
                    color = ConsoleColor.White;
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = color;
            Console.WriteLine("You {0} for {1} damage", result, e.Damage);
            Console.ResetColor();
        }

        static void ArenaAttacked(object sender, AttackEventArgs e) {
            var color = ConsoleColor.White;
            string result = string.Empty;
            switch (e.AttackResult) {
                case AttackResultType.Hit:
                    result = "hits";
                    color = ConsoleColor.Red;
                    break;
                case AttackResultType.CriticalHit:
                    result = "critically hits";
                    color = ConsoleColor.DarkRed;
                    break;
                case AttackResultType.Miss:
                    result = "misses";
                    color = ConsoleColor.White;
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = color;
            Console.WriteLine("{0} {1} you for {2} damage", e.PlayerName, result, e.Damage);
            Console.ResetColor();
        }
    }
}

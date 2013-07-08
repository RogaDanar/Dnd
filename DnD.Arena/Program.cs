namespace DnD.Arena
{
    using System;
    using Dnd.Core;
    using Dnd.Core.Enums;
    using Dnd.Core.Items.Armor;
    using Dnd.Core.Items.Shields;
    using Dnd.Core.Items.Weapons;

    class Program
    {
        private static Character _player1;
        private static Character _player2;

        static void Main(string[] args) {
            _player1 = CharacterCreator.CreateCharacter(Race.Human, Class.Fighter, 8);
            _player1.Name = "Roga";
            _player1.IncreaseAttribute(AttributeType.Strength, 4);
            _player1.IncreaseAttribute(AttributeType.Dexterity, 4);
            _player2 = CharacterCreator.CreateCharacter(Race.Human, Class.Fighter, 8);
            _player2.Name = "Armus";
            _player2.IncreaseAttribute(AttributeType.Strength, 4);
            _player2.IncreaseAttribute(AttributeType.Dexterity, 4);

            var greatsword = new GreatSword(Size.Medium);
            var longsword = new LongSword(Size.Medium);
            _player1.EquipItem(greatsword);
            _player1.EquipItem(new BreastPlate(Size.Medium));
            _player2.EquipItem(longsword);
            _player2.EquipItem(new TowerShield(Size.Medium));

            var arena = new Arena(_player1, _player2);
            arena.AttackMade += new EventHandler<AttackEventArgs>(arena_AttackMade);
            arena.Attacked += new EventHandler<AttackEventArgs>(arena_Attacked);
            arena.FightDone += new EventHandler(arena_FightDone);
            arena.StartFight();
            Console.ReadKey();
        }

        static void arena_FightDone(object sender, EventArgs e) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (_player1.HpCurrent <= 0) {
                Console.WriteLine("You died.");
            } else {
                Console.WriteLine("You slay " + _player2.Name + "!");
            }
            Console.ResetColor();

            Console.WriteLine(String.Format("{0} hp: {1}", _player1.Name, _player1.HpCurrent));
            Console.WriteLine(String.Format("{0} hp: {1}", _player2.Name, _player2.HpCurrent));
        }

        static void arena_AttackMade(object sender, AttackEventArgs e) {
            ConsoleColor color = ConsoleColor.White;
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
            Console.WriteLine(String.Format("You {1} for {2} damage", e.PlayerName, result, e.Damage));
            Console.ResetColor();
        }

        static void arena_Attacked(object sender, AttackEventArgs e) {
            ConsoleColor color = ConsoleColor.White;
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
            Console.WriteLine(String.Format("{0} {1} you for {2} damage", e.PlayerName, result, e.Damage));
            Console.ResetColor();
        }
    }
}

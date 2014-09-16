namespace DnD.Arena
{
    using System;
    using Dnd.Vornia.Character;
    using Dnd.CharGenerator;
    using Dnd.Core;
    using Dnd.Core.Model.Actions;
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Items.Armor;
    using Dnd.Core.Model.Items.Weapons;

    class Program
    {
        private static ICharacter _player1;
        private static ICharacter _player2;

        static void Main(string[] args) {
            _player1 = VorniaCharacterCreator.CreateMaswari();
            _player1.Name = "Roga";
            _player1.Equipment.Equip(new Greatsword(Size.Medium));
            _player1.Equipment.Equip(new Breastplate(Size.Medium));

            _player2 = VorniaCharacterCreator.CreateMaswariCommander();
            _player2.Equipment.Equip(new Longsword(Size.Medium));
            _player2.Equipment.Equip(new TowerShield(Size.Medium));

            ConsoleSheet.Display(_player1);
            Console.WriteLine();
            ConsoleSheet.Display(_player2);
            Console.ReadKey();

            var arena = new Dnd.Core.Model.Arena(_player1, _player2);
            arena.AttackMade += ArenaAttackMade;
            arena.Attacked += ArenaAttacked;
            arena.FightDone += ArenaFightDone;
            arena.StartFight();
            Console.ReadKey();
        }

        static void ArenaFightDone(object sender, EventArgs e) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (_player1.Hitpoints.Current <= 0) {
                Console.WriteLine("You died.");
            } else {
                Console.WriteLine("You slay " + _player2.Name + "!");
            }
            Console.ResetColor();

            Console.WriteLine("{0} hp: {1}", _player1.Name, _player1.Hitpoints.Current);
            Console.WriteLine("{0} hp: {1}", _player2.Name, _player2.Hitpoints.Current);
        }

        static void ArenaAttackMade(object sender, AttackEventArgs e) {
            Console.ForegroundColor = ConsoleColor.White;
            switch (e.AttackResult) {
                case AttackResultType.Hit:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You hit for {0} damage", e.Damage);
                    break;
                case AttackResultType.CriticalHit:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You critically hit for {0} damage", e.Damage);
                    break;
                case AttackResultType.Miss:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You miss...");
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }

        static void ArenaAttacked(object sender, AttackEventArgs e) {
            Console.ForegroundColor = ConsoleColor.White;
            switch (e.AttackResult) {
                case AttackResultType.Hit:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} hits you for {1} damage", e.CharacterName, e.Damage);
                    break;
                case AttackResultType.CriticalHit:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("{0} critically hits you for {1} damage", e.CharacterName, e.Damage);
                    break;
                case AttackResultType.Miss:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0} misses you", e.CharacterName);
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }
    }
}

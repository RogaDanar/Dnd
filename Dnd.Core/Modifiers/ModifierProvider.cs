namespace Dnd.Core.Modifiers
{
    using System;
    using Dnd.Core.Enums;
    using Dnd.Core.Modifiers.Classes;
    using Dnd.Core.Modifiers.Races;

    public class ModifierProvider
    {
        public IModifier<Character> GetBaseModifier() {
            return new CharacterModifier();
        }

        public IModifier<Character> GetModifier(Race race) {
            switch (race) {
                case Race.Elf:
                    return new ElfModifier();
                case Race.Human:
                    return new HumanModifier();
                case Race.Dwarf:
                    return new DwarfModifier();
                case Race.Gnome:
                    return new GnomeModifier();
                case Race.HalfElf:
                    return new HalfElfModifier();
                case Race.HalfOrc:
                    return new HalfOrcModifier();
                case Race.Halfling:
                    return new HalflingModifier();
                default:
                    throw new NotImplementedException();
            }
        }

        public IModifier<Character> GetModifier(Class charClass) {
            switch (charClass) {
                case Class.Barbarian:
                    return new BarbarianModifier();
                case Class.Bard:
                    return new BardModifier();
                case Class.Fighter:
                    return new FighterModifier();
                case Class.Cleric:
                    return new ClericModifier();
                case Class.Druid:
                    return new DruidModifier();
                case Class.Monk:
                    return new MonkModifier();
                case Class.Paladin:
                    return new PaladinModifier();
                case Class.Ranger:
                    return new RangerModifier();
                case Class.Rogue:
                    return new RogueModifier();
                case Class.Sorceror:
                    return new SorcerorModifier();
                case Class.Wizard:
                    return new WizardModifier();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

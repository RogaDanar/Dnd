namespace Dnd.Core.Modifiers
{
    using System;
    using Dnd.Core.Enums;
    using Dnd.Core.Modifiers.Classes;
    using Dnd.Core.Modifiers.Races;

    public class ModifierProvider
    {
        /// <summary>
        /// Returns the base character modifier, which adds the base features and attributepoints for any character
        /// </summary>
        public IModifier<Character> GetBaseModifier() {
            return new CharacterModifier();
        }

        /// <summary>
        /// returns the Race modifier, which adjust race specific penalties and bonuses on a character
        /// </summary>
        public IModifier<Character> GetRaceModifier(Race race) {
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

        /// <summary>
        /// returns the Class modifier, which adjust class specific penalties and bonuses on a character
        /// </summary>
        public IModifier<Character> GetClassModifier(Class charClass) {
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

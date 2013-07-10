﻿namespace Dnd.Core.Character.Modifiers
{
    using System;
    using Dnd.Core.Classes;
    using Dnd.Core.Classes.Modifiers;
    using Dnd.Core.Races;
    using Dnd.Core.Races.Modifiers;

    public class ModifierProvider
    {
        /// <summary>
        /// Returns the base character modifier, which adds the base features and attributepoints for any character
        /// </summary>
        public IModifier<DefaultCharacter> GetBaseModifier() {
            return new CharacterModifier();
        }

        /// <summary>
        /// returns the Race modifier, which adjust race specific penalties and bonuses on a character
        /// </summary>
        public IModifier<DefaultCharacter> GetRaceModifier(Race race) {
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
        public AbstractClassModifier GetClassModifier(ClassType classType) {
            switch (classType) {
                case ClassType.Barbarian:
                    return new BarbarianModifier();
                case ClassType.Bard:
                    return new BardModifier();
                case ClassType.Fighter:
                    return new FighterModifier();
                case ClassType.Cleric:
                    return new ClericModifier();
                case ClassType.Druid:
                    return new DruidModifier();
                case ClassType.Monk:
                    return new MonkModifier();
                case ClassType.Paladin:
                    return new PaladinModifier();
                case ClassType.Ranger:
                    return new RangerModifier();
                case ClassType.Rogue:
                    return new RogueModifier();
                case ClassType.Sorceror:
                    return new SorcerorModifier();
                case ClassType.Wizard:
                    return new WizardModifier();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
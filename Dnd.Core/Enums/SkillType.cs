using Dnd.Core.Skills;
namespace Dnd.Core.Enums
{
    public enum SkillType
    {
        [SynergyFrom(SkillType.Craft)]
        [AbilityModifier(AttributeType.Intelligence)]
        Appraise,

        [SynergyFrom(SkillType.Tumble)]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        Balance,

        [AbilityModifier(AttributeType.Charisma)]
        Bluff,

        [ArmorCheck]
        [AbilityModifier(AttributeType.Strength)]
        Climb,

        [AbilityModifier(AttributeType.Constitution)]
        Concentration,

        [AbilityModifier(AttributeType.Intelligence)]
        Craft,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Intelligence)]
        DecipherScript,

        [SynergyFrom(SkillType.Bluff, SkillType.Knowledge, SkillType.SenseMotive)]
        [AbilityModifier(AttributeType.Charisma)]
        Diplomacy,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Intelligence)]
        DisableDevice,

        [SynergyFrom(SkillType.Bluff)]
        [AbilityModifier(AttributeType.Charisma)]
        Disguise,

        [SynergyFrom(SkillType.UseRope)]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        EscapeArtist,

        [AbilityModifier(AttributeType.Intelligence)]
        Forgery,

        [SynergyFrom(SkillType.Knowledge)]
        [AbilityModifier(AttributeType.Charisma)]
        GatherInformation,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Charisma)]
        HandleAnimal,

        [AbilityModifier(AttributeType.Wisdom)]
        Heal,

        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        Hide,

        [SynergyFrom(SkillType.Bluff)]
        [AbilityModifier(AttributeType.Charisma)]
        Intimidate,

        [SynergyFrom(SkillType.Tumble)]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Strength)]
        Jump,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Intelligence)]
        Knowledge,

        [AbilityModifier(AttributeType.Wisdom)]
        Listen,

        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        MoveSilently,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Dexterity)]
        OpenLock,

        [AbilityModifier(AttributeType.Charisma)]
        Perform,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Wisdom)]
        Profession,

        [SynergyFrom(SkillType.HandleAnimal)]
        [AbilityModifier(AttributeType.Dexterity)]
        Ride,

        [AbilityModifier(AttributeType.Intelligence)]
        Search,

        [AbilityModifier(AttributeType.Wisdom)]
        SenseMotive,

        [SynergyFrom(SkillType.Bluff)]
        [TrainedOnly]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        SleightOfHand,

        [TrainedOnly]
        SpeakLanguage,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Intelligence)]
        Spellcraft,

        [AbilityModifier(AttributeType.Wisdom)]
        Spot,

        [AbilityModifier(AttributeType.Wisdom)]
        Survival,

        [ArmorCheck]
        [AbilityModifier(AttributeType.Strength)]
        Swim,

        [SynergyFrom(SkillType.Jump)]
        [TrainedOnly]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        Tumble,

        [SynergyFrom(SkillType.DecipherScript)]
        [TrainedOnly]
        [AbilityModifier(AttributeType.Charisma)]
        UseMagicDevice,

        [AbilityModifier(AttributeType.Dexterity)]
        UseRope,
    }
}

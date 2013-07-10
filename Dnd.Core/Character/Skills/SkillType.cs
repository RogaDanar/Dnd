namespace Dnd.Core.Character.Skills
{
    using Dnd.Core.Character.Attributes;

    public enum SkillType
    {
        [SynergyFrom(Craft)]
        [AbilityModifier(AttributeType.Intelligence)]
        Appraise,

        [SynergyFrom(Tumble)]
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

        [SynergyFrom(Bluff, Knowledge, SenseMotive)]
        [AbilityModifier(AttributeType.Charisma)]
        Diplomacy,

        [TrainedOnly]
        [AbilityModifier(AttributeType.Intelligence)]
        DisableDevice,

        [SynergyFrom(Bluff)]
        [AbilityModifier(AttributeType.Charisma)]
        Disguise,

        [SynergyFrom(UseRope)]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        EscapeArtist,

        [AbilityModifier(AttributeType.Intelligence)]
        Forgery,

        [SynergyFrom(Knowledge)]
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

        [SynergyFrom(Bluff)]
        [AbilityModifier(AttributeType.Charisma)]
        Intimidate,

        [SynergyFrom(Tumble)]
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

        [SynergyFrom(HandleAnimal)]
        [AbilityModifier(AttributeType.Dexterity)]
        Ride,

        [AbilityModifier(AttributeType.Intelligence)]
        Search,

        [AbilityModifier(AttributeType.Wisdom)]
        SenseMotive,

        [SynergyFrom(Bluff)]
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

        [SynergyFrom(Jump)]
        [TrainedOnly]
        [ArmorCheck]
        [AbilityModifier(AttributeType.Dexterity)]
        Tumble,

        [SynergyFrom(DecipherScript)]
        [TrainedOnly]
        [AbilityModifier(AttributeType.Charisma)]
        UseMagicDevice,

        [AbilityModifier(AttributeType.Dexterity)]
        UseRope,
    }
}

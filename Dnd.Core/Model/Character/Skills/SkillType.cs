namespace Dnd.Core.Model.Character.Skills
{
    using Dnd.Core.Model.Character.Abilities;

    public enum SkillType
    {
        [SynergyFrom(Craft)]
        [AbilityModifier(AbilityType.Intelligence)]
        Appraise,

        [SynergyFrom(Tumble)]
        [ArmorCheck]
        [AbilityModifier(AbilityType.Dexterity)]
        Balance,

        [AbilityModifier(AbilityType.Charisma)]
        Bluff,

        [ArmorCheck]
        [AbilityModifier(AbilityType.Strength)]
        Climb,

        [AbilityModifier(AbilityType.Constitution)]
        Concentration,

        [AbilityModifier(AbilityType.Intelligence)]
        Craft,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Intelligence)]
        DecipherScript,

        [SynergyFrom(Bluff, Knowledge, SenseMotive)]
        [AbilityModifier(AbilityType.Charisma)]
        Diplomacy,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Intelligence)]
        DisableDevice,

        [SynergyFrom(Bluff)]
        [AbilityModifier(AbilityType.Charisma)]
        Disguise,

        [SynergyFrom(UseRope)]
        [ArmorCheck]
        [AbilityModifier(AbilityType.Dexterity)]
        EscapeArtist,

        [AbilityModifier(AbilityType.Intelligence)]
        Forgery,

        [SynergyFrom(Knowledge)]
        [AbilityModifier(AbilityType.Charisma)]
        GatherInformation,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Charisma)]
        HandleAnimal,

        [AbilityModifier(AbilityType.Wisdom)]
        Heal,

        [ArmorCheck]
        [AbilityModifier(AbilityType.Dexterity)]
        Hide,

        [SynergyFrom(Bluff)]
        [AbilityModifier(AbilityType.Charisma)]
        Intimidate,

        [SynergyFrom(Tumble)]
        [ArmorCheck]
        [AbilityModifier(AbilityType.Strength)]
        Jump,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Intelligence)]
        Knowledge,

        [AbilityModifier(AbilityType.Wisdom)]
        Listen,

        [ArmorCheck]
        [AbilityModifier(AbilityType.Dexterity)]
        MoveSilently,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Dexterity)]
        OpenLock,

        [AbilityModifier(AbilityType.Charisma)]
        Perform,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Wisdom)]
        Profession,

        [SynergyFrom(HandleAnimal)]
        [AbilityModifier(AbilityType.Dexterity)]
        Ride,

        [AbilityModifier(AbilityType.Intelligence)]
        Search,

        [AbilityModifier(AbilityType.Wisdom)]
        SenseMotive,

        [SynergyFrom(Bluff)]
        [TrainedOnly]
        [ArmorCheck]
        [AbilityModifier(AbilityType.Dexterity)]
        SleightOfHand,

        [TrainedOnly]
        SpeakLanguage,

        [TrainedOnly]
        [AbilityModifier(AbilityType.Intelligence)]
        Spellcraft,

        [AbilityModifier(AbilityType.Wisdom)]
        Spot,

        [AbilityModifier(AbilityType.Wisdom)]
        Survival,

        [ArmorCheck]
        [AbilityModifier(AbilityType.Strength)]
        Swim,

        [SynergyFrom(Jump)]
        [TrainedOnly]
        [ArmorCheck]
        [AbilityModifier(AbilityType.Dexterity)]
        Tumble,

        [SynergyFrom(DecipherScript)]
        [TrainedOnly]
        [AbilityModifier(AbilityType.Charisma)]
        UseMagicDevice,

        [AbilityModifier(AbilityType.Dexterity)]
        UseRope,
    }
}

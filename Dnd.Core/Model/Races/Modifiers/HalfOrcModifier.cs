﻿namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Features;

    public class HalfOrcModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Attributes.Increase(AttributeType.Strength, 2);
            subject.Attributes.Decrease(AttributeType.Intelligence, 2);
            subject.Attributes.Decrease(AttributeType.Charisma, 2);

            subject.Features.Add(Feature.DarkVision);
        }
    }
}
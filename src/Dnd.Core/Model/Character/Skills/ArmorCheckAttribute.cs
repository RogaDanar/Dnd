﻿namespace Dnd.Core.Model.Character.Skills
{
    using System;

    public class ArmorCheckAttribute : Attribute
    {
        public bool ArmorCheck;

        public ArmorCheckAttribute() {
            ArmorCheck = true;
        }

        public ArmorCheckAttribute(bool armorCheck) {
            ArmorCheck = armorCheck;
        }
    }
}

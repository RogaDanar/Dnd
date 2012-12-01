namespace Dnd.Core.Skills
{
    using System;

    public class TrainedOnlyAttribute : Attribute
    {
        public bool TrainedOnly;

        public TrainedOnlyAttribute() {
            TrainedOnly = true;
        }

        public TrainedOnlyAttribute(bool trainedOnly) {
            TrainedOnly = trainedOnly;
        }
    }
}

namespace Dnd.Core.Actions
{
    using Dnd.Core.Enums;

    public class AttackResult : ActionResult
    {
        public AttackResultType Attack { get; set; }

        public int Damage { get; set; }
    }
}

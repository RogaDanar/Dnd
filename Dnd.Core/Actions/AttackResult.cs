namespace Dnd.Core.Actions
{
    public class AttackResult : ActionResult
    {
        public AttackResultType Attack { get; set; }

        public int Damage { get; set; }
    }
}

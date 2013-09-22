namespace Dnd.Core.Actions
{
    public class AttackResult : ActionResult
    {
        public AttackResultType Type { get; set; }

        public int Damage { get; set; }
    }
}

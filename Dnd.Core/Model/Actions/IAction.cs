namespace Dnd.Core.Model.Actions
{
    using System.Collections.Generic;

    public interface IAction<TResult> where TResult : ActionResult
    {
        IEnumerable<TResult> Execute();
    }
}

namespace Dnd.Core.Model.Character.Modifiers
{
    /// <summary>
    /// Generic visitee interface
    /// </summary>
    public interface IModifiable<T>
    {
        void AcceptOnCreation(IModifier<T> modifier);
        void AcceptOnLevel(IModifier<T> modifier);
    }
}

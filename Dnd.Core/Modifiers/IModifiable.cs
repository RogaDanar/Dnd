namespace Dnd.Core.Modifiers
{
    public interface IModifiable<T>
    {
        void AcceptOnCreation(IModifier<T> modifier);
        void AcceptOnLevel(IModifier<T> modifier);
    }
}

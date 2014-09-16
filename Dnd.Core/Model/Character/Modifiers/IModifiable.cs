namespace Dnd.Core.Model.Character.Modifiers
{
    public interface IModifiable<T>
    {
        void AcceptOnCreation(IModifier<T> modifier);
        void AcceptOnLevel(IModifier<T> modifier);
    }
}

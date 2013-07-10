namespace Dnd.Core.Character.Modifiers
{
    public interface IModifier<T>
    {
        void ModifyOnCreation(T subject);
        void ModifyOnLevel(T subject);
    }
}

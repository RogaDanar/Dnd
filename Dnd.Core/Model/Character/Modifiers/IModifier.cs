namespace Dnd.Core.Model.Character.Modifiers
{
    public interface IModifier<T>
    {
        void ModifyOnCreation(T subject);
        void ModifyOnLevel(T subject);
    }
}

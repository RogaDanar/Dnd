namespace Dnd.Core.Model.Character.Modifiers
{
    /// <summary>
    /// Generic visitor interface
    /// </summary>
    public interface IModifier<T>
    {
        void ModifyOnCreation(T subject);
        void ModifyOnLevel(T subject);
    }
}

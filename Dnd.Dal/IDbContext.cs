namespace Dnd.Dal
{
    using System.Data.Entity;
    using Core.Model;

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity<int>;
        int SaveChanges();
        void Dispose();
    }
}
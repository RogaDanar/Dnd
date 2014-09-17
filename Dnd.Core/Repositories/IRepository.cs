namespace Dnd.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Dnd.Core.Model;

    public interface IRepository<TEntity, U> where TEntity : class, IEntity<U>
    {
        TEntity Add(TEntity entity);
        TEntity GetById(U id);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}

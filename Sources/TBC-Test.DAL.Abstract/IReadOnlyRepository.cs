using System;
using System.Linq;
using System.Linq.Expressions;
using TBC_Test.Business.Domain;

namespace TBC_Test.DAL.Abstract
{
    public interface IReadOnlyRepository<TEntity, TEntityId> where TEntity : IEntity<TEntityId>
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> GetAll();
        TEntity GetById(TEntityId id);
    }
}
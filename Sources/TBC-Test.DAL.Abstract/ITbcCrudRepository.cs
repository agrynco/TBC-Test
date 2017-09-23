using System.Linq;
using TBC_Test.Business.Domain;

namespace TBC_Test.DAL.Abstract
{
    public interface ITbcCrudRepository<TEntity, TEntityId> : ICrudRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
    {
        void Delete(bool permanently, params TEntity[] entities);
        void Delete(bool permanently, params TEntityId[] entityIds);
        IQueryable<TEntity> GetAll(bool includeDeleted);
    }

    public interface ITbcCrudRepository<TEntity> : ITbcCrudRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
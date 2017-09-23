using TBC_Test.Business.Domain;

namespace TBC_Test.DAL.Abstract
{
    public interface ICrudRepository<TEntity, TEntityId> : IReadOnlyRepository<TEntity, TEntityId>
        where TEntity : IEntity<TEntityId>
    {
        TEntity Add(TEntity entity);
        TEntity Add(TEntity entity, bool save);
        void Delete(params TEntityId[] id);
        void Delete(params TEntity[] entities);
        void SaveChanges();
        void Update(TEntity entity);
        void Update(TEntity entity, bool save);
    }
}
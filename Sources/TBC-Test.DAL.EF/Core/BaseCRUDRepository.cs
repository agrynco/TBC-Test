using System.Data.Entity;
using TBC_Test.Business.Domain;
using TBC_Test.DAL.Abstract;

namespace TBC_Test.DAL.EF.Core
{
    public class BaseCrudRepository<TDbContext, TEntity, TEntityId> :
        BaseReadOnlyRepository<TDbContext, TEntity, TEntityId>,
        ICrudRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
        where TDbContext : DbContext
    {
        protected BaseCrudRepository(TDbContext dbContext)
            : base(dbContext)
        {
        }

        public TEntity Add(TEntity entity)
        {
            return Add(entity, true);
        }

        public TEntity Add(TEntity entity, bool save)
        {
            TEntity addedEntity = DbSet.Add(entity);
            if (save)
            {
                DbContext.SaveChanges();
            }

            return addedEntity;
        }

        public virtual void Delete(params TEntityId[] id)
        {
            foreach (TEntityId entityId in id)
            {
                Delete(GetById(entityId));
            }
        }

        public virtual void Delete(params TEntity[] entities)
        {
            DbSet.RemoveRange(entities);
            DbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Update(entity, true);
        }

        public virtual void Update(TEntity entity, bool save)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            if (save)
            {
                DbContext.SaveChanges();
            }
        }
    }
}
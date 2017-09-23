using System;
using System.Linq;
using TBC_Test.Business.Domain;
using TBC_Test.DAL.Abstract;
using TBC_Test.DAL.EF.Core;

namespace TBC_Test.DAL.EF
{
    public class TbcCrudRepository<TEntity> : TbcCrudRepository<TEntity, int>,
        ITbcCrudRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected TbcCrudRepository(TbcDbContext dbContext) : base(dbContext)
        {
        }
    }

    public class TbcCrudRepository<TEntity, TEntityId> : BaseCrudRepository<TbcDbContext, TEntity, TEntityId>,
        ITbcCrudRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
    {
        protected TbcCrudRepository(TbcDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(bool permanently, params TEntity[] entities)
        {
            if (!permanently)
            {
                foreach (TEntity entity in entities)
                {
                    entity.IsDeleted = true;
                    entity.Deleted = DateTime.UtcNow;
                    Update(entity);
                }
            }
            else
            {
                Delete(entities);
            }
        }

        public void Delete(bool permanently, params TEntityId[] entityIds)
        {
            Delete(permanently, GetAll(true).Where(entity => entityIds.Contains(entity.Id)).ToArray());
        }

        public override IQueryable<TEntity> GetAll()
        {
            return GetAll(false);
        }

        public IQueryable<TEntity> GetAll(bool includeDeleted)
        {
            return base.GetAll().Where(entity => includeDeleted || !entity.IsDeleted);
        }

        public override void Update(TEntity entity, bool save)
        {
            entity.Updated = DateTime.UtcNow;
            base.Update(entity, save);
        }
    }
}
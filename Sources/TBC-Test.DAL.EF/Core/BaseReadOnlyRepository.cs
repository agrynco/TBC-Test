using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TBC_Test.Business.Domain;
using TBC_Test.DAL.Abstract;
using TBC_Test.DAL.Abstract.Exceptions;

namespace TBC_Test.DAL.EF.Core
{
    public class BaseReadOnlyRepository<TDbContext, TEntity, TEntityId> : BaseRepository<TDbContext>,
        IReadOnlyRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
        where TDbContext : DbContext
    {
        protected BaseReadOnlyRepository(TDbContext dbContext) : base(dbContext)
        {
            DbSet = DbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return orderBy?.Invoke(query).AsQueryable() ?? query.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public virtual TEntity GetById(TEntityId id)
        {
            TEntity entity = DbContext.Set<TEntity>().Find(id);
            if (entity == null)
            {
                throw new ThereIsNoEntityException<TEntity, TEntityId>(id);
            }
            return entity;
        }
    }
}
using System.Data.Entity;

namespace TBC_Test.DAL.EF.Core
{
    public class BaseRepository<TDbContext> where TDbContext : DbContext
    {
        protected BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext { get; }
    }
}
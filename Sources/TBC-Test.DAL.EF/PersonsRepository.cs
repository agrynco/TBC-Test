using TBC_Test.Business.Domain;
using TBC_Test.DAL.Abstract;

namespace TBC_Test.DAL.EF
{
    public class PersonsRepository : TbcCrudRepository<Person>, IPersonsRepository
    {
        public PersonsRepository(TbcDbContext dbContext) : base(dbContext)
        {
        }
    }
}
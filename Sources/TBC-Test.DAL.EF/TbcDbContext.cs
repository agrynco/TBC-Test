using System.Data.Entity;
using System.Diagnostics;
using TBC_Test.Business.Domain;

namespace TBC_Test.DAL.EF
{
    public class TbcDbContext : DbContext
    {
        protected TbcDbContext() : this("tbc-test")
        {
        }

        public TbcDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Debug.WriteLine("Create NeosweatDbContext");
            Database.Log = message => Debug.WriteLine(message);
        }

        public DbSet<Person> Persons { get; set; }
    }
}
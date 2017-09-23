using System.Data.Entity.Migrations;

namespace TBC_Test.DAL.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TbcDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TbcDbContext context)
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
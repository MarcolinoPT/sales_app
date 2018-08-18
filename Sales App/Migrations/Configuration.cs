namespace SalesApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesApp.Data.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SalesApp.Data.SalesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Regions.AddOrUpdate(
              p => p.Id,
              new Models.SalesRegion
              {
                  Active = true,
                  Code = "NTH",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.Now,
                  Id = 1,
                  Name = "North Region",
                  SalesTarget = 100000.00M,
                  UpdatedBy = "Admin",
                  UpdatedDate = DateTime.Now
              },
              new Models.SalesRegion
              {
                  Active = true,
                  Code = "STH",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.Now,
                  Id = 2,
                  Name = "South Region",
                  SalesTarget = 100000.00M,
                  UpdatedBy = "Admin",
                  UpdatedDate = DateTime.Now
              }
            );
            context.People.AddOrUpdate(
              p => p.Id,
            new Models.SalesPerson
            {
                Active = true,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                FirstName = "Bob",
                Id = 1,
                LastName = "Smith",
                RegionId = 1,
                SalesTarget = 2000.00M,
                UpdatedBy = "Admin",
                UpdatedDate = DateTime.Now
            });
            context.Sales.AddOrUpdate(
             p => p.Id,
           new Models.Sale
           {
               Amount = 321.45M,
               CreatedBy = "Admin",
               CreatedDate = DateTime.Now,
               Date = new DateTime(2014, 2, 3),
               Id = 1,
               PersonId = 1,
               RegionId = 1,
               UpdatedBy = "Admin",
               UpdatedDate = DateTime.Now
           });
        }
    }
}

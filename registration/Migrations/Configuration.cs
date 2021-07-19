namespace registration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<registration.Models.ApplicationDbContext>
    {
        public Configuration()
        {

            //AutomaticMigrationsEnabled = false;

            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(registration.Models.ApplicationDbContext context)
        {
            context.Cities.AddOrUpdate(
               new Entities.City() { Id = 1, city = "Samastipur" },
               new Entities.City() { Id = 2, city = "Patna" },
               new Entities.City() { Id = 3, city = "Bengaluru" },
               new Entities.City() { Id = 4, city = "Mumbai" },
               new Entities.City() { Id = 5, city = "Delhi" }
               );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

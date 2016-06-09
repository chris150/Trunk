namespace MyWebHzg.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<MyWebHzg.Repositories.WebHzgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyWebHzg.Repositories.WebHzgContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.ActualValueAllgs.AddOrUpdate(
            //  new ActualValueAllg { Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, Witterungstemperatur = -5.5 },
            //  new ActualValueAllg { Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, Witterungstemperatur = -4.2 },
            //  new ActualValueAllg { Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, Witterungstemperatur = -2.0 },
            //  new ActualValueAllg { Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, Witterungstemperatur =  0.5 },
            //  new ActualValueAllg { Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, Witterungstemperatur =  4.7 },
            //  new ActualValueAllg { Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, Witterungstemperatur =  6.0 }
            //);
        }
    }
}

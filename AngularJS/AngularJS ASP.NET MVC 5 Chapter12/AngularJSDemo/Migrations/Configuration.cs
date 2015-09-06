using AngularJSDemo.Models;

namespace AngularJSDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularJSDemo.Models.MovieDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//change false to true to enable automatic migrations;
        }

        protected override void Seed(AngularJSDemo.Models.MovieDb context)
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
            context.Movies.AddOrUpdate(m => m.Title,
                new Movie { Title = "star wars", ReleaseYear = 1977, Runtime = 121 },
                new Movie { Title = "Inception", ReleaseYear = 2010, Runtime = 148 },
                new Movie { Title = "toy story", ReleaseYear = 1995, Runtime = 81 });
        }
    }
}

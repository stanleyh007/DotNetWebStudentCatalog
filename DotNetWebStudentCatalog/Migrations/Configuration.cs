namespace DotNetWebStudentCatalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DotNetWebStudentCatalog.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetWebStudentCatalog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
           
        }

        protected override void Seed(DotNetWebStudentCatalog.Models.ApplicationDbContext context)
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

            context.Students.AddOrUpdate(s => s.Email, new StudentModel[]
            {
               new StudentModel
                { FirstName = "Taeyeon", LastName = "Kim", Email = "taeyeonkim@sm.kr", Phone = "42355678"},
               new StudentModel
               { FirstName = "YoonA", LastName = "Lim", Email = "Yonnalim@sm.kr", Phone = "12589658"},
            }
               

                );
        }
    }
}

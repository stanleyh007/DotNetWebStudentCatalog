namespace DotNetWebStudentCatalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DotNetWebStudentCatalog.Models.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

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

            context.Students.AddOrUpdate(s => s.StudentModelId, new StudentModel[]
            {
               new StudentModel
               { FirstName = "Taeyeon", LastName = "Kim", StudentModelId = 1, Phone = "42355678"},
               new StudentModel
               { FirstName = "YoonA", LastName = "Lim", StudentModelId = 2, Phone = "12589658"},
               new StudentModel
               { FirstName = "Jessica", LastName = "Jung", StudentModelId = 3, Phone = "45859632"},
               new StudentModel
               { FirstName = "Juhyun", LastName = "Seo", StudentModelId = 4, Phone = "89741354"},
               new StudentModel
               { FirstName = "Sooyoung", LastName = "Choi", StudentModelId = 5, Phone = "48496632"},
               new StudentModel
               { FirstName = "Hyoyeon", LastName = "Kim", StudentModelId = 6, Phone = "58949632"},
               new StudentModel
               { FirstName = "Sunny", LastName = "Lee", StudentModelId = 7, Phone = "18596454"},
               new StudentModel
               { FirstName = "Yuri", LastName = "Kwon", StudentModelId = 8, Phone = "56984582"},
               new StudentModel
               { FirstName = "Tiffany", LastName = "Hwang", StudentModelId = 9, Phone = "48966553"},
               new StudentModel
               { FirstName = "Krystal", LastName = "Jung", StudentModelId = 10, Phone = "59568817"}
            });

            context.CompetencyHeaderModels.AddOrUpdate(h => h.CompetencyHeaderModelId, new CompetencyHeaderModel[]
            {
                new CompetencyHeaderModel
                { CompetencyHeaderModelId = 1, name = "Design"},
                new CompetencyHeaderModel
                { CompetencyHeaderModelId = 2, name = "Computer Programming"},
                new CompetencyHeaderModel
                { CompetencyHeaderModelId = 3, name = "Software"}
            });

            context.CompetencyModels.AddOrUpdate(c => c.CompetencyModelId, new CompetencyModel[]
            {
                new CompetencyModel
                { CompetencyModelId = 1, CompetencyHeaderModelId = 1, name = "Fashion"},
                new CompetencyModel
                { CompetencyModelId = 2, CompetencyHeaderModelId = 1, name = "Sewing"},
                new CompetencyModel
                { CompetencyModelId = 3, CompetencyHeaderModelId = 2, name = "Java"},
                new CompetencyModel
                { CompetencyModelId = 4, CompetencyHeaderModelId = 2, name = "MySQL"},
                new CompetencyModel
                { CompetencyModelId = 5, CompetencyHeaderModelId = 3, name = "Microsoft Office"}
            });

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("admin"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var client1 = new ApplicationUser { UserName = "stanleyhxk@gmail.com" };
            var result1 = userManager.Create(client1, "12345678");
            if (result1.Succeeded == false)
            {
                client1 = userManager.FindByName("stanleyhxk@gmail.com");
            }
            context.SaveChanges();
            userManager.AddToRole(client1.Id, "admin");
        }
    }
}

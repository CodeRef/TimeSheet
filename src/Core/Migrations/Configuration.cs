using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeTracker.Model.Migrations.data;

namespace TimeTracker.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var role = new IdentityRole { Name = "SuperAdmin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Employee"))
            {
                var role = new IdentityRole { Name = "Employee" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "admin", EmailConfirmed = true };

                userManager.Create(user, "@denver188");
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
            //var admin = context.Users.FirstOrDefault();
            //context.Books.AddOrUpdate(new Project
            //{
            //    Id = 1,
            //    Name = "hello",
            //    //ISBN = Guid.NewGuid().ToString(),
            //    Description = "test",
            //    Title = "test",
            //    CreatedBy = admin.Id,
            //    UpdatedBy = admin.Id,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    //PublicationDate = DateTime.Now,
            //    Picture = "succeeding-with-agile-cover.jpg"
            //}, new Project
            //{
            //    Id = 2,
            //    Name = "hello2",
            //    //ISBN = Guid.NewGuid().ToString(),
            //    Description = "test2",
            //    Title = "test2",
            //    CreatedBy = admin.Id,
            //    UpdatedBy = admin.Id,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now,
            //    //PublicationDate = DateTime.Now,
            //    Picture = "agile-cover.jpg"
            //});

            //context.Shelfs.AddOrUpdate(
            //    new Shelf
            //    {
            //        Name = "Shelf-1",
            //        Title = "No Title",
            //        Description = "No Description",
            //        CreatedBy = admin.Id,
            //        UpdatedBy = admin.Id,
            //        CreatedDate = DateTime.Now,
            //        UpdatedDate = DateTime.Now
            //    });
            //admin.Shelfs = new List<Shelf> {context.Shelfs.FirstOrDefault()};
            //context.SaveChanges();

            //context.Books.ToList()
            //    .ForEach(
            //        a =>
            //        {
            //            context.SelfBook.AddOrUpdate(new ShelfBook
            //            {
            //                BookId = a.Id,
            //                ShelfId = context.Shelfs.FirstOrDefault().Id
            //            });
            //        });
            //context.SaveChanges();
            // Seed default data of job type.
            //var jobTypes = new JobTypeData(context, admin);
            //jobTypes.Seed();
        }
    }
}
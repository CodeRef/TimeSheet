using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestMeet.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;

namespace RestMeet.Test
{
    public class TodoContext : BaseContext
    {
        public TodoContext(DbConnection connection)
            : base(connection)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<ToDo> ToDoes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<TodoContext>(new AlwaysCreateInitializer());
            base.OnModelCreating(modelBuilder);
        }
        public void Seed(TodoContext Context)
        {
            var store2 = new UserStore<ApplicationUser>(Context);
            var manager2 = new UserManager<ApplicationUser>(store2);
            var user = new ApplicationUser { UserName = "founder" };

            manager2.Create(user, "@denver188");
            var listTodo = new List<ToDo>() {
             new ToDo() { Id = 1, Name = "US",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,Start=DateTime.Now,End=DateTime.Now ,OwnerBy=user},
             new ToDo() { Id = 2, Name = "India",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,Start=DateTime.Now,End=DateTime.Now ,OwnerBy=user},
             new ToDo() { Id = 3, Name = "Russia",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,Start=DateTime.Now,End=DateTime.Now,OwnerBy=user }
            };
            Context.ToDoes.AddRange(listTodo);
            Context.SaveChanges();
        }
        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<TodoContext>
        {
            protected override void Seed(TodoContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}

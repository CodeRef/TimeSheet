using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ploeh.AutoFixture;
using RestMeet.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;

namespace RestMeet.Test
{
    public class BookContext : BaseContext
    {
        public BookContext(DbConnection connection)
            : base(connection)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<BookContext>(new AlwaysCreateInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(BookContext Context)
        {
            var listBook = new List<Book>() {
             new Book() { Id = 1,ISBN="978-0-123456-47-2", Name = "Book Q",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },
             new Book() { Id = 2,ISBN="978-0-123456-47-3", Name = "Book W",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },
             new Book() { Id = 3,ISBN="978-0-123456-47-4",Name = "Book B" ,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now}
            };

            //var fixture = new Fixture();
            //var myInstances = fixture.Build<Model.Book>()
            //    .Without(m => m.UpdateUser)
            //    .Without(m => m.CreateUser)
            //    .CreateMany(10);
            //Context.Books.AddRange(myInstances);


            Context.Books.AddRange(listBook);

            Context.SaveChanges();
        }
        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<BookContext>
        {
            protected override void Seed(BookContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}

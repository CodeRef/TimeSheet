using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using TimeTracker.Model;

namespace RestMeet.Test
{
    public class ShopContext : BaseContext
    {
        public ShopContext(DbConnection connection)
            : base(connection)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Shop> Shops { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<ShopContext>(new AlwaysCreateInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ShopContext Context)
        {
            var listShop = new List<Shop>() {
             new Shop() { Id = 1, Name = "Shop Q",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },
             new Shop() { Id = 2, Name = "Shop W",CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },
             new Shop() { Id = 3, Name = "Shop B" ,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now}
            };
            Context.Shops.AddRange(listShop);
            Context.SaveChanges();
        }
        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<ShopContext>
        {
            protected override void Seed(ShopContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}

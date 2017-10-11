using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TimeTracker.Model;
using TimeTracker.Model.Map;

namespace RestMeet.Test
{
    public class BaseContext : IdentityDbContext<ApplicationUser>
    {
        public BaseContext()
            : base("Name=ShopContext")
        {

        }
        public BaseContext(bool enableLazyLoading, bool enableProxyCreation)
            : base("Name=ShopContext")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }
        public BaseContext(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserProfileMap());
            base.OnModelCreating(modelBuilder);
        }
        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
        {
            protected override void Seed(ShopContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
        public class CreateInitializer : CreateDatabaseIfNotExists<ShopContext>
        {
            protected override void Seed(ShopContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }


    }
}

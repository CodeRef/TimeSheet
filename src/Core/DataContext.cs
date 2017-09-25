using System.Data.Common;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeTracker.Model.Map;

namespace TimeTracker.Model
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
            : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DataContext(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Shelf> Shelfs { get; set; }
        public virtual DbSet<ShelfBook> SelfBook { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<TaskModel> Tasks { get; set; }
        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserProfileMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
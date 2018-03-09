using System.Data.Common;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public virtual DbSet<Prospect> Prospects { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }


        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<FeatureUser> FeatureUsers { get; set; }     
        public virtual DbSet<TaskUser> TaskUsers { get; set; }
        public virtual DbSet<TimeLog> TimeLogs { get; set; }
       
        //public virtual DbSet<TaskModel> Tasks { get; set; }
        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UserProfileMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
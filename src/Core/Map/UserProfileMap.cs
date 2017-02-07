using System.Data.Entity.ModelConfiguration;

namespace TimeTracker.Model.Map
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // Primary Key
            HasKey(t => new {t.UserId, t.ApplicationUserId});
            // Table & Column Mappings
            // this.ToTable("FundMap", "SPE");
        }
    }
}
using System;

namespace TimeTracker.Model.Migrations.data
{
    public class JobTypeData
    {
        public JobTypeData(DataContext context, ApplicationUser user)
        {
            DataContext = context;
            User = user;
        }

        private DataContext DataContext { get; }
        private ApplicationUser User { get; }

        public void Seed()
        {
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Primary",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Variable",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Annual Leave",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Sick Leave",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Ongoing Contract",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Sales support",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Customer meetings",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Public Holiday",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Weekend",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.JobTypes.Add(new JobType
            {
                Name = "Personal Leave",
                CreatedBy = User.Id,
                CreatedDate = DateTime.Now,
                UpdatedBy = User.Id,
                UpdatedDate = DateTime.Now
            });
            DataContext.SaveChanges();
        }
    }
}
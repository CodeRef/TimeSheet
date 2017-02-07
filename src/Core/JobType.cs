using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class JobType : AuditableEntity<int>
    {
        public string Name { get; set; }
    }
}
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class State : AuditableEntity<int>
    {
        public string Name { get; set; }
    }
}
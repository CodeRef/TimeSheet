using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Shelf : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
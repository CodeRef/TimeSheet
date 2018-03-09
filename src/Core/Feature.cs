using System;
using System.Collections.Generic;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Feature : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}

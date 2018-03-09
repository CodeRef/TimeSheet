using System;
using System.Collections.Generic;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Project : AuditableEntity<int>
    {

        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Feature> Features { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public string Picture { get; set; }
        public virtual Prospect Prospect { get; set; }
    }
}
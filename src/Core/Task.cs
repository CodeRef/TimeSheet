﻿using System;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class TaskModel: AuditableEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Book : AuditableEntity<int>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<UserProfile> Authers { get; set; }
        public string Picture { get; set; }
    }
}
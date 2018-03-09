using System.Collections.Generic;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Address : AuditableEntity<int>
    {
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string AddressText { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
        public string ZipCode { get; set; }
        public virtual List<string> PhoneNumber { get; set; }
    }
}
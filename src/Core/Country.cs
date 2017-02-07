using System.Collections.Generic;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Country : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string OIfficialName { get; set; }
        public string IsoCode { get; set; }
        public string IsoShort { get; set; }
        public string IsoLong { get; set; }
        public string UnCode { get; set; }
        public string CapitalCity { get; set; }
        public virtual List<State> State { get; set; }
    }
}
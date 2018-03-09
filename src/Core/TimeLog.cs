using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class TimeLog : Entity<int>
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}

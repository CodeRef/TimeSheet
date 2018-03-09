using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Feature:Entity<int>
    {
        public string Name { get; set; }
    }
}

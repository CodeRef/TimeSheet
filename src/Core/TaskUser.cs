using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class TaskUser : BaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Task")]
        public Guid TaskModelId { get; set; }
        public virtual TaskModel Task { get; set; }
        public virtual List<TimeLog> TimeLog { get; set; }
    }
}

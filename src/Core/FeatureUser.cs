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
    public class FeatureUser : BaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Feature")]
        public Guid FeatureId { get; set; }
        public virtual Feature Feature { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

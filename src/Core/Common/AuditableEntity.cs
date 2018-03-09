using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model.Common
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreateUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual ApplicationUser UpdateUser { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}
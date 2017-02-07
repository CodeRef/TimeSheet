//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Template
{
    using System;
    using System.Collections.Generic;
    
    public partial class Condition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Condition()
        {
            this.ConditionAdvices = new HashSet<ConditionAdvice>();
            this.Badges = new HashSet<Badge>();
        }
    
        public int Id { get; set; }
        public string type { get; set; }
        public string request { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }
        public string result { get; set; }
        public string CalculationType { get; set; }
        public string CalculationDetail { get; set; }
        public Nullable<int> validated { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public Nullable<System.DateTime> DateUpd { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConditionAdvice> ConditionAdvices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Badge> Badges { get; set; }
    }
}

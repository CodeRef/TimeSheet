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
    
    public partial class MessageReaded
    {
        public int MessageId { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Message Message { get; set; }
    }
}

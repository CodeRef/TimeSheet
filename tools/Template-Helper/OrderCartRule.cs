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
    
    public partial class OrderCartRule
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> CartRuleId { get; set; }
        public Nullable<int> OrderInvoiceId { get; set; }
        public string name { get; set; }
        public Nullable<double> value { get; set; }
        public Nullable<double> ValueTaxExcl { get; set; }
        public Nullable<int> FreeShipping { get; set; }
    }
}

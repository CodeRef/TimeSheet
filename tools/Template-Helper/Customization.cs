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
    
    public partial class Customization
    {
        public int Id { get; set; }
        public int AddressDeliveryId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> ProductAttributeId { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> QuantityRefunded { get; set; }
        public Nullable<int> QuantityReturned { get; set; }
        public Nullable<int> InCart { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

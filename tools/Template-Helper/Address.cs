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
    
    public partial class Address
    {
        public int Id { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public string alias { get; set; }
        public string company { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string other { get; set; }
        public string phone { get; set; }
        public string PhoneMobile { get; set; }
        public string VatNumber { get; set; }
        public string dni { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public Nullable<System.DateTime> DateUpd { get; set; }
        public Nullable<int> active { get; set; }
        public Nullable<int> deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

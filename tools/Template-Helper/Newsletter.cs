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
    
    public partial class Newsletter
    {
        public int id { get; set; }
        public Nullable<int> ShopId { get; set; }
        public Nullable<int> ShopGroupId { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> NewsletterDateAdd { get; set; }
        public string IpRegistrationNewsletter { get; set; }
        public string HttpReferer { get; set; }
        public Nullable<int> active { get; set; }
    }
}

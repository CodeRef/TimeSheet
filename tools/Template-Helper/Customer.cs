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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.ProductCommentUsefulnesses = new HashSet<ProductCommentUsefulness>();
            this.Groups = new HashSet<Group>();
            this.ProductComments = new HashSet<ProductComment>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ShopGroupId { get; set; }
        public Nullable<int> ShopId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> DefaultGroupId { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<int> RiskId { get; set; }
        public string company { get; set; }
        public string siret { get; set; }
        public string ape { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string passwd { get; set; }
        public Nullable<System.DateTime> LastPasswdGen { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public Nullable<int> newsletter { get; set; }
        public string IpRegistrationNewsletter { get; set; }
        public Nullable<System.DateTime> NewsletterDateAdd { get; set; }
        public Nullable<int> optin { get; set; }
        public string website { get; set; }
        public Nullable<double> OutstandingAllowAmount { get; set; }
        public Nullable<int> ShowPublicPrices { get; set; }
        public Nullable<int> MaxPaymentDays { get; set; }
        public string SecureKey { get; set; }
        public string note { get; set; }
        public Nullable<int> active { get; set; }
        public Nullable<int> IsGuest { get; set; }
        public Nullable<int> deleted { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public Nullable<System.DateTime> DateUpd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCommentUsefulness> ProductCommentUsefulnesses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductComment> ProductComments { get; set; }
    }
}

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
    
    public partial class AttributeGroupLang
    {
        public int AttributeGroupId { get; set; }
        public int LanguageId { get; set; }
        public string name { get; set; }
        public string PublicName { get; set; }
    
        public virtual AttributeGroup AttributeGroup { get; set; }
        public virtual Language Language { get; set; }
    }
}

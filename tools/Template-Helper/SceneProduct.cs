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
    
    public partial class SceneProduct
    {
        public int SceneId { get; set; }
        public int ProductId { get; set; }
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public Nullable<int> ZoneWidth { get; set; }
        public Nullable<int> ZoneHeight { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Scene Scene { get; set; }
    }
}

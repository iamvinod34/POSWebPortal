//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_MaterialKit
    {
        public string KitID { get; set; }
        public string KitDescription { get; set; }
        public string MaterialLess { get; set; }
        public string UOMLess { get; set; }
        public Nullable<decimal> QuantityLess { get; set; }
        public string MaterialAdd { get; set; }
        public string UOMAdd { get; set; }
        public Nullable<decimal> QuantityAdd { get; set; }
    
        public virtual tbl_Material tbl_Material { get; set; }
        public virtual tbl_Material tbl_Material1 { get; set; }
        public virtual tbl_MaterialKit tbl_MaterialKit1 { get; set; }
        public virtual tbl_MaterialKit tbl_MaterialKit2 { get; set; }
        public virtual tbl_UOM tbl_UOM { get; set; }
        public virtual tbl_UOM tbl_UOM1 { get; set; }
    }
}

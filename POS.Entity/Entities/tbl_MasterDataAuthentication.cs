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
    
    public partial class tbl_MasterDataAuthentication
    {
        public long Id { get; set; }
        public long Loc_Auth_Id { get; set; }
        public Nullable<bool> Location { get; set; }
        public Nullable<bool> Terminal { get; set; }
        public Nullable<bool> Storage { get; set; }
        public Nullable<bool> Vendor { get; set; }
        public Nullable<bool> Customer { get; set; }
        public Nullable<bool> Category { get; set; }
        public Nullable<bool> SubCategory { get; set; }
        public Nullable<bool> UOM { get; set; }
        public Nullable<bool> Material { get; set; }
        public Nullable<bool> Price { get; set; }
        public Nullable<bool> LocationPrice { get; set; }
        public Nullable<bool> Users { get; set; }
        public Nullable<bool> City { get; set; }
        public Nullable<bool> Region { get; set; }
        public Nullable<bool> Country { get; set; }
    
        public virtual tbl_LocationAuthentication tbl_LocationAuthentication { get; set; }
    }
}
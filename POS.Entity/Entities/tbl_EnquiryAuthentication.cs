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
    
    public partial class tbl_EnquiryAuthentication
    {
        public long Id { get; set; }
        public long Loc_Auth_Id { get; set; }
        public Nullable<bool> SalesOrder { get; set; }
        public Nullable<bool> POReceive { get; set; }
        public Nullable<bool> ReturnToSupplier { get; set; }
        public Nullable<bool> TranfterToDisplay { get; set; }
        public Nullable<bool> PhysicalInventory { get; set; }
        public Nullable<bool> TransfterIN { get; set; }
        public Nullable<bool> TransfterOUT { get; set; }
        public Nullable<bool> EOD { get; set; }
    
        public virtual tbl_LocationAuthentication tbl_LocationAuthentication { get; set; }
    }
}

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
    
    public partial class tbl_TempDetail
    {
        public int TempDetailID { get; set; }
        public int TempMasterID { get; set; }
        public string DocumentID { get; set; }
        public string CompanyID { get; set; }
        public string LocationID { get; set; }
        public string StorageID { get; set; }
        public System.DateTime DocumentDate { get; set; }
        public string PostingType { get; set; }
        public Nullable<System.DateTime> PostingDate { get; set; }
        public string VendorID { get; set; }
        public Nullable<int> Counter { get; set; }
        public string CategoryID { get; set; }
        public string MaterialID { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> TranQty { get; set; }
        public Nullable<decimal> BaseQty { get; set; }
        public Nullable<decimal> CreditQty { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> CreditAmount { get; set; }
        public string UserID { get; set; }
        public Nullable<int> PostKey { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public Nullable<decimal> OrderQty { get; set; }
        public string Type { get; set; }
    }
}

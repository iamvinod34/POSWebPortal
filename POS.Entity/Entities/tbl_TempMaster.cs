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
    
    public partial class tbl_TempMaster
    {
        public int TempMasterID { get; set; }
        public string Type { get; set; }
        public string DocumentID { get; set; }
        public string PONumber { get; set; }
        public string CompanyID { get; set; }
        public string LocationID { get; set; }
        public string StorageID { get; set; }
        public Nullable<System.DateTime> DocumentDate { get; set; }
        public Nullable<System.DateTime> PostingDate { get; set; }
        public string DocDetail { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> NetValue { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string Filter { get; set; }
        public string Filter_Id { get; set; }
        public Nullable<bool> Status { get; set; }
        public string VendorID { get; set; }
        public string TLocationID { get; set; }
        public string TStorageID { get; set; }
    }
}
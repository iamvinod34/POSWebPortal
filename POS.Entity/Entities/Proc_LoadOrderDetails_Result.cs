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
    
    public partial class Proc_LoadOrderDetails_Result
    {
        public string DocumentID { get; set; }
        public string CompanyID { get; set; }
        public string LocationID { get; set; }
        public string StorageID { get; set; }
        public string TerminalID { get; set; }
        public System.DateTime DocumentDate { get; set; }
        public string PostingType { get; set; }
        public Nullable<System.DateTime> PostingDate { get; set; }
        public string CustomerID { get; set; }
        public int Counter { get; set; }
        public string CategoryID { get; set; }
        public string MaterialID { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> TranQty { get; set; }
        public Nullable<decimal> BaseQty { get; set; }
        public Nullable<decimal> CreditQty { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> CreditAmount { get; set; }
        public string UserID { get; set; }
        public int PostKey { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public int Dataid { get; set; }
    }
}
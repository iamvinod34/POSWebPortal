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
    
    public partial class Proc_CashCollection_Result
    {
        public string EODID { get; set; }
        public string TerminialID { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public Nullable<decimal> Loan { get; set; }
        public Nullable<decimal> SystemCash { get; set; }
        public Nullable<decimal> ActualCash { get; set; }
        public Nullable<decimal> Cash_Collection { get; set; }
    }
}

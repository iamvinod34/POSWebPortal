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
    
    public partial class tbl_POS_Logs
    {
        public int LogID { get; set; }
        public string Proc_Name { get; set; }
        public string Parameters { get; set; }
        public string Error_Message { get; set; }
        public Nullable<System.DateTime> Row_Created_Date { get; set; }
        public string Error_Number { get; set; }
        public string Error_Line { get; set; }
    }
}

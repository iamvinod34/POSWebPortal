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
    
    public partial class tbl_PhoneCode
    {
        public int Id { get; set; }
        public string PhoneCode { get; set; }
        public int PhoneDigits { get; set; }
        public string PhoneDescription { get; set; }
        public bool Conread { get; set; }
    }
}
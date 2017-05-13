using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace POS.Util.Model
{
   public class CustomerModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="Please Enter Customer ID")]
        public string CustomerID { get; set; }
        public string Name1 { get; set; }
        [Required(ErrorMessage ="Please Enter Last Name")]
        public string Name2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string POBox { get; set; }

        [Required(ErrorMessage ="Please Enter Mobile Number")]
        public string Phone { get; set; }

        [Compare("Phone",ErrorMessage ="Please Enter Corrct Mobile Number")]
        
        public string ConPhone { get; set; }

        public string Fax { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<int> CustInt1 { get; set; }
        public Nullable<int> CustInt2 { get; set; }
        public Nullable<int> CustInt3 { get; set; }
        public string CustText1 { get; set; }
        public string CustText2 { get; set; }
        public string CustText3 { get; set; }
        public string CustType { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        [Required(ErrorMessage ="Please Enter 4-digit PassCode")]
        [MaxLength(4,ErrorMessage = "Please Enter 4-digit PassCode")]
        public string POSPassword { get; set; }
        [Compare("POSPassword", ErrorMessage ="Please Enter Correct Password")]
        [MaxLength(4, ErrorMessage = "Please Enter 4-digit PassCode")]
        public string ConPassword { get; set; }
        public long ID { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }

        public virtual tbl_City tbl_City { get; set; }

        public List<tbl_Customer> lstCustomers { set; get; }
        public List<tbl_PhoneCode> lstPhoneCodes { get; set; }
    }
}

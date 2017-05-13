using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using POS.Entity.Entities;

namespace POS.Util.Model
{
   public class VendorModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Enter Vendor ID")]
        public string VendorID { get; set; }
        [Required(ErrorMessage ="* Please Enter Vendor Name")]
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        [Required(ErrorMessage ="* Please Enter Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required(ErrorMessage ="* Please Enter POBox")]
        public string POBox { get; set; }
        [Required(ErrorMessage ="* Please Enter Contact")]
        public string Contact { get; set; }
        [Required(ErrorMessage ="* Please Enter Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="* Please Enter Fax")]
        public string Fax { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage ="* Please Select City")]
        public string City { get; set; }
        [Required(ErrorMessage ="* Please Select Region")]
        public string Region { get; set; }
        [Required(ErrorMessage ="* Please Select Country")]
        public string Country { get; set; }
        public Nullable<int> CustInt1 { get; set; }
        public Nullable<int> CustInt2 { get; set; }
        public Nullable<int> CustInt3 { get; set; }
        public string CustText1 { get; set; }
        public string CustText2 { get; set; }
        public string CustText3 { get; set; }


        public List<tbl_Vendor> LVendor;
        public List<tbl_Country> LCountry;
        public List<tbl_Region> LRegion;
        public List<tbl_City> LCity;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

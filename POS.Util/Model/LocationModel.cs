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
    public class LocationModel : UserAuthenticationModel
    {
        [Required(ErrorMessage = "* Please Enter LocationID")]
        public string LocationID { get; set; }

        [Required(ErrorMessage = "* Please Enter Location Name")]
        public string LocationDesc { get; set; }

        [Required(ErrorMessage = "* Please Enter Address1")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [Required(ErrorMessage = "* Please Enter POBox")]
        public string POBox { get; set; }
        public string Contact { get; set; }

        [Required(ErrorMessage = "* Please Enter Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "* Please Enter Fax")]
        public string Fax { get; set; }

        //[Required(ErrorMessage = "* Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Please Select City")]
        public string City { get; set; }
        [Required(ErrorMessage = "* Please Select Region")]
        public string Region { get; set; }
        [Required(ErrorMessage = "* Please Select Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "* Please Enter CostCenter")]
        public string CostCenter { get; set; }
        public string BusinessArea { get; set; }
        public string FieldArea { get; set; }
        [Required(ErrorMessage = "* Please Enter CashLoan")]
        public Nullable<decimal> CashLoan { get; set; }
        public Nullable<int> CustInt1 { get; set; }
        public Nullable<int> CustInt2 { get; set; }
        public Nullable<int> CustInt3 { get; set; }
        public string CustText1 { get; set; }
        public string CustText2 { get; set; }
        public string CustText3 { get; set; }
        public string TfrDisplay { get; set; }
        public string POReceive { get; set; }
        public string TfrIn { get; set; }
        public string TfrOut { get; set; }
        public string RtnVendor { get; set; }
        public string PhyCount { get; set; }


        public List<tbl_City> MCity;
        public List<tbl_Region> MRegion;
        public List<tbl_Country> MCountry;
        public List<tbl_Location> MLocation;
        public tbl_Location ByLocationID;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }

    }
}

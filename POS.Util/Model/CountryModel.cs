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
    public class CountryModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Enter CountryID")]
        public int CountryID { get; set; }
        [Required(ErrorMessage ="* Please Enter Country Name")]
        public string CountryName { get; set; }

        public List<tbl_Country> lstCountry;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

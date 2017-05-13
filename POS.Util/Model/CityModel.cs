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
   public class CityModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Enter CityID")]
        public string CityID { get; set; }
        [Required(ErrorMessage ="* Please Enter City Name")]
        public string CityName { get; set; }

        public List<tbl_City> lstCity;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

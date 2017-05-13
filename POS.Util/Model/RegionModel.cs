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
   public class RegionModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Enter RegionID")]
        public int RegionID { get; set; }
        [Required(ErrorMessage ="* Please Enter Region Name")]
        public string RegionName { get; set; }

        public List<tbl_Region> Region;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

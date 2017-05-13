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
   public class SubCategoryModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Enter Sub CategoryID")]
        public string SubCategoryID { get; set; }
        [Required(ErrorMessage = "* Please Enter Sub Category Description")]
        public string SubCategoryDesc { get; set; }
        [Required(ErrorMessage ="* Please Select CategoryID")]
        public string CategoryID { get; set; }

        public List<tbl_Category> Category;
        public List<tbl_SubCategory> SubCategory;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

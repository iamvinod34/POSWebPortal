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
    
    public class CategoryModel : UserAuthenticationModel
    {
        [Key]
        [Required(ErrorMessage = "* Please Enter Category ID")]
        public string CategoryID { get; set; }
        [Required(ErrorMessage = "* Please Enter Category Description")]
        public string CategoryDesc { get; set; }

        public List<tbl_Category> Category;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }

    }
}

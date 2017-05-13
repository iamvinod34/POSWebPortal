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
    class MaterialEANModel : UserAuthenticationModel
    {
        // Material EAN Table
        [Required(ErrorMessage = "* Please Enter BarCode Number")]
        public string EAN13 { get; set; }
        [Required(ErrorMessage = "* Please Enter MaterialID")]
        public string EMaterialID { get; set; }
        [Required(ErrorMessage = "* Please Enter UOM")]
        public string UOM { get; set; }
        [Required(ErrorMessage = "* Please Enter Convert Value")]
        public Nullable<decimal> ConvertValue { get; set; }
        [Required(ErrorMessage = "* Please Enter BaseUOM")]
        public string EBaseUOM { get; set; }
        [Required(ErrorMessage = "* Please Enter MaterialMix")]
        public string MaterialMix { get; set; }

        //Price File Table
        [Required(ErrorMessage = "* Please Enter Price")]
        public Nullable<decimal> Price { get; set; }

        //Prefer UOM table
        public string PreforUOM { get; set; }

        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

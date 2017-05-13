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
   public class LocationPriceModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Select LocationID")]
        public string LocationID { get; set; }
        [Required(ErrorMessage ="* Please Select BarCode")]
        public string EAN13 { get; set; }
        [Required(ErrorMessage ="* Please Select Material ID")]
        public string MaterialID { get; set; }
        [Required(ErrorMessage ="* Please Enter UOM")]
        public string UOM { get; set; }
        [Required(ErrorMessage ="* Please Enter Price")]
        [DataType(DataType.Currency,ErrorMessage ="* Please Enter Decimal Only")]
        public Nullable<decimal> Price { get; set; }

        public List<tbl_Material> MMaterial;
        public List<tbl_LocationPrice> MLocationPrice;
        public List<tbl_MaterialEAN> MMaterialEAN;
        public List<tbl_Location> MLocation;
        public List<tbl_UOM> MUOM;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }
    }
}

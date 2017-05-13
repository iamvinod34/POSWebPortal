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
   public class MaterialModel : UserAuthenticationModel
    {
        [Key]
        [Required(ErrorMessage ="* Please Enter Valid MaterialID")]
        public string MaterialID { get; set; }
        [Required(ErrorMessage ="* Please Enter Material Description")]
        public string MaterialDesc1 { get; set; }
        [Required(ErrorMessage = "* Please Enter Arabic Material Description")]
        public string MaterialDesc2 { get; set; }
        public string MaterialDesc3 { get; set; }
        [Required(ErrorMessage ="* Please Enter ProductURL")]
        public string ProductURL { get; set; }
        [Required(ErrorMessage ="* Please Select Category")]
        public string CategoryID { get; set; }
        [Required(ErrorMessage ="* Please Select SubCategory")]
        public string SubCategoryID { get; set; }
        [Required(ErrorMessage ="* Please Enter BaseUOM")]
        public string BaseUOM { get; set; }

        public Nullable<decimal> Cost { get; set; }
        [Required(ErrorMessage ="* Please Select VendorID")]
        public string VendorID { get; set; }
        public Nullable<int> CustInt1 { get; set; }
        public Nullable<int> CustInt2 { get; set; }
        public Nullable<int> CustInt3 { get; set; }
        public Nullable<System.DateTime> CustDate1 { get; set; }
        public Nullable<System.DateTime> CustDate2 { get; set; }
        public Nullable<System.DateTime> CustDate3 { get; set; }
        public string CustText1 { get; set; }
        public string CustText2 { get; set; }
        public string CustText3 { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }

        // Material EAN Table
        [Required(ErrorMessage = "* Please Enter BarCode Number")]
        public string EAN13 { get; set; }
        [Required(ErrorMessage = "* Please Enter MaterialID")]
        public string EMaterialID { get; set; }
        [Required(ErrorMessage = "* Please Enter UOM")]
        public string  UOM { get; set; }
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
        public bool PreforUOM { get; set; }

        public string filePath { get; set; }

        
        public int ImageDetailsID { get; set; }
        public string Type { get; set; }
        public string ID { get; set; }
        public string FileName { get; set; }
        public System.DateTime RowCreatedDate { get; set; }

        public List<tbl_Category> GetAllCategory;
        public List<tbl_Material> GetAllMaterial;
        public List<tbl_Vendor> GetAllVendor;
        public List<tbl_SubCategory> GetAllSubCategory;
        public List<tbl_UOM> MUOM;
        public List<tbl_ImageDetails> MImage_Details;

        public List<Proc_LoadMaterialDetails_Result> GetByIDMaterial;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Util.Enum;
using System.IO;
using System.Configuration;

namespace POS.Web.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {

        MaterialBL MaterialBL;
        public MaterialController()
        {
            MaterialBL = new MaterialBL();
        }
        MaterialModel MM = new MaterialModel();
        // GET: Material
        public ActionResult Index()
        {
            MM = MaterialBL.GetMterialModel();
            ViewBag.NewEANIndex = 0;
            return View(MM);
        }

        public PartialViewResult GetMaterialById(string MaterialID)
        {
            List<Proc_LoadMaterialDetails_Result> MaterialDetails = new List<Proc_LoadMaterialDetails_Result>();
            MaterialDetails = MaterialBL.GetByIDMaterial(MaterialID);

            MM = MaterialBL.GetMterialModel();
            MM.GetByIDMaterial = MaterialDetails;
            MM.MaterialID = MaterialDetails.FirstOrDefault().MaterialID;
            MM.MaterialDesc1 = MaterialDetails.FirstOrDefault().MaterialDesc1;
            MM.MaterialDesc2 = MaterialDetails.FirstOrDefault().MaterialDesc2;
            MM.CategoryID = MaterialDetails.FirstOrDefault().CategoryID;
            MM.SubCategoryID = MaterialDetails.FirstOrDefault().SubCategoryID;
            MM.BaseUOM = MaterialDetails.FirstOrDefault().BaseUOM;
            MM.Cost = MaterialDetails.FirstOrDefault().Cost;
            MM.VendorID = MaterialDetails.FirstOrDefault().VendorID;
            MM.ID = MaterialDetails.FirstOrDefault().ID;

            for (int i = 0; i < MaterialDetails.Count; i++)
            {
                MM.EAN13 = MaterialDetails[i].EAN13.ToString();
                MM.UOM = MaterialDetails[i].UOM.ToString();
                MM.ConvertValue = Convert.ToDecimal(MaterialDetails[i].ConvertValue);
                MM.EBaseUOM = MaterialDetails[i].BaseUOM.ToString();
                MM.MaterialMix = MaterialDetails[i].MaterialMix.ToString();
                MM.Price =Convert.ToDecimal(MaterialDetails[i].Price);

                PartialView("~/Views/Material/Partial/_MaterialDetailsPartial.cshtml", MM);
            }
            if(MaterialDetails.FirstOrDefault().PreforUOMMaterialID!=null && MaterialDetails.FirstOrDefault().PreforUOMEAN13!=null )
            {
                //write textbox id names
                MM.PreforUOM = true;
            }
            return PartialView("~/Views/Material/Partial/_MaterialDetailsPartial.cshtml", MM);
        }
        public PartialViewResult NewMaterialEntries(string index)
        {
            MM = MaterialBL.GetMterialModel();
            ViewBag.NewEANIndex = index;
            return PartialView("~/Views/Material/Partial/_MaterialNewEANEntries.cshtml", MM);
        }

        public string InsertUpdate(FormCollection FormCollection, MaterialModel MaterialModelForm, int Valueindex,HttpPostedFileBase file,string MaterialID)
        {
            string result = string.Empty;
           
              tbl_Material Material = new tbl_Material();
            Material.MaterialID = MaterialModelForm.MaterialID;
            Material.MaterialDesc1 = MaterialModelForm.MaterialDesc1;
            Material.MaterialDesc2 = MaterialModelForm.MaterialDesc2;
            Material.ProductURL = MaterialModelForm.ProductURL;
            Material.SubCategoryID = MaterialModelForm.SubCategoryID;
            Material.UpdDate = DateTime.Now;
            Material.UserID = MaterialModelForm.UserID;
            Material.VendorID = MaterialModelForm.VendorID;
            Material.AddDate = DateTime.Now;
            Material.BaseUOM = MaterialModelForm.BaseUOM;
            Material.CategoryID = MaterialModelForm.CategoryID;
            Material.Cost = MaterialModelForm.Cost;
            //Material Table
            InsertOrUpdateMaterial(MaterialModelForm);
            //Material EAN
            InsertOrUpdateMaterialEAN(FormCollection, Valueindex);
            //PreforUOM
            InsertOrUpdatePreforUOM();
            //Price File
            InsertOrUpdatePriceFile(FormCollection, Valueindex);

            MM = MaterialBL.GetMterialModel();

            //Image
            GetImage(file, MaterialID,FormCollection);
            return result;
        }
        public string InsertOrUpdateMaterial(MaterialModel MaterialModel)
        {
            string result = string.Empty;
            tbl_Material Material = new tbl_Material();
            Material.MaterialID = MaterialModel.MaterialID;
            Material.MaterialDesc1 = MaterialModel.MaterialDesc1;
            Material.MaterialDesc2 = MaterialModel.MaterialDesc2;
            Material.ProductURL = MaterialModel.ProductURL;
            Material.SubCategoryID = MaterialModel.SubCategoryID;
            Material.UpdDate = DateTime.Now;
            Material.UserID = MaterialModel.UserID;
            Material.VendorID = MaterialModel.VendorID;
            Material.AddDate = DateTime.Now;
            Material.BaseUOM = MaterialModel.BaseUOM;
            Material.CategoryID = MaterialModel.CategoryID;
            Material.Cost = MaterialModel.Cost;
            return MaterialBL.InsertUpdateMaterial(MaterialModel);
        }

        public string InsertOrUpdateMaterialEAN(FormCollection FormCollection, int index)
        {
            string result = string.Empty;

            List<MaterialModel> MaterialModel = new List<MaterialModel>();
            MaterialModel EAN = new MaterialModel();
            for (int i = 0; i <= index; i++)
            {
                EAN.EAN13 = FormCollection["EAN13" + i].ToString();
                EAN.UOM = FormCollection["UOM" + i].ToString();
                EAN.EBaseUOM = FormCollection["EBaseUOM" + i].ToString();
                EAN.ConvertValue = Convert.ToDecimal(FormCollection["ConvertValue" + i].ToString());
                EAN.MaterialMix = FormCollection["MaterialMix" + i].ToString();
                EAN.Price = Convert.ToDecimal(FormCollection["Price" + i].ToString());
                EAN.EMaterialID = FormCollection["MaterialID"].ToString();
                MaterialModel.Add(EAN);
             result= MaterialBL.InsertUpdateMaterialEAN(EAN);
            }
            return result;
        }

        public string InsertOrUpdatePreforUOM()
        {
            string selectedPU = Request.Form["PreforUOM"];
            MaterialModel EAN = new MaterialModel();
            EAN.EAN13 = Request["EAN13" + selectedPU].ToString();
            EAN.UOM = Request["UOM" + selectedPU].ToString();
            EAN.BaseUOM = Request["EBaseUOM" + selectedPU].ToString();
            EAN.ConvertValue = Convert.ToDecimal(Request["ConvertValue" + selectedPU].ToString());
            EAN.MaterialID = Request["MaterialID"].ToString();
            EAN.MaterialMix = Request["MaterialMix" + selectedPU].ToString();
            EAN.Price = Convert.ToDecimal(Request["Price" + selectedPU].ToString());
            return MaterialBL.InsertUpdatePreforUOM(EAN);
        }

        public string InsertOrUpdatePriceFile(FormCollection FormCollection, int index)
        {
            MaterialModel MaterialModel= new MaterialModel();
            string result = string.Empty;
            for (int i = 0; i <= index; i++)
            {
                MaterialModel.EAN13 = FormCollection["EAN13" + i].ToString();
                MaterialModel.UOM = FormCollection["UOM" + i].ToString();
                MaterialModel.Price = Convert.ToDecimal(FormCollection["Price" + i].ToString());
                MaterialModel.MaterialID = FormCollection["MaterialID"].ToString();
                MaterialBL.InsertUpdatePriceFile(MaterialModel);
            }
            return result;
        }

        public string GetImage(HttpPostedFileBase file,string MaterialID,FormCollection FormCollection)
        {
            string result = string.Empty;

            var ImagePath = file.FileName;
            string extension = Path.GetExtension(ImagePath);
            var path = Path.Combine(Server.MapPath("~/Images/Profile_Image"), Path.GetFileName(MaterialID+extension));
            string Type = file.ContentType;
            file.SaveAs(path);
            InsertOrUpdateImage(FormCollection,MaterialID,Type,MaterialID+extension);
            return result;
        }

        public string InsertOrUpdateImage(FormCollection FormCollection,string MaterialID,string Type,string FileName)
        {
            MaterialModel MaterialModel = new MaterialModel();
            string result = string.Empty;
            MaterialModel.Type = Type;
            MaterialModel.ID = MaterialID;
            MaterialModel.FileName = FileName;
            MaterialModel.RowCreatedDate = DateTime.Now;
            return MaterialBL.InsertUpdateImage(MaterialModel);
        }
    }
}
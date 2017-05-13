using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Util.Model;

namespace POS.Web.Controllers.Transaction
{
    [Authorize]
    public class PhysicalInventoryController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        StorageBL StorageBL = new StorageBL();
        CategoryBL CategoryBL = new CategoryBL();
        TransactionBL TransactionBL = new TransactionBL();
        TempStorage TempStorage = new TempStorage();
        TransactionModel TransactionModel = new TransactionModel();
        // GET: PhysicalInventory
        public ActionResult Index()
        {
            LocationBL.EmailID = User.Identity.Name;
            ViewBag.Location = LocationBL.GetAll().Select(c => new SelectListItem()
            {
                Text = c.LocationDesc,
                Value = c.LocationID,

            }).ToList();
         
           
            return View(TransactionModel);
        }

        public PartialViewResult GetStorage(string LocationID,string type)
        {
               List<tbl_Storage> subCategories = StorageBL.GetByID(LocationID);
                ViewBag.Storages = subCategories.Select(s => new SelectListItem()
                {
                    Text = s.StorageID,
                    Value = s.StorageID,

                }).ToList();
                return PartialView("~/Views/Shared/Dropdown.cshtml");
            
        }

        public PartialViewResult GetCategory()
        {

            List<tbl_Category> Categories = CategoryBL.GetCategoryAll();
            ViewBag.Categorie = Categories.Select(s => new SelectListItem()
            {
                Text = s.CategoryDesc,
                Value = s.CategoryID,

            }).ToList();
            return PartialView("~/Views/Shared/Dropdown.cshtml");
        }

        public PartialViewResult GetEAN(string EAN13, string UOM,string Pagename)
        {
            List<Proc_SearchEAN_Result> lstEAN13 = TransactionBL.GetProc_SearchEAN(EAN13, UOM,string.Empty, Pagename);
            if (lstEAN13.Count > 1)
            {
                return PartialView("~/Views/ReturnToSupplier/ListMaterial.cshtml", lstEAN13);
            }
            else if (lstEAN13.Count == 1)
            {
                Proc_MaterialBarcodeSearch_Result MaterialBarCode = new Proc_MaterialBarcodeSearch_Result();
                MaterialBarCode.EAN13 = lstEAN13.FirstOrDefault().EAN13;
                MaterialBarCode.MaterialDesc1 = lstEAN13.FirstOrDefault().MaterialDesc1;
                MaterialBarCode.MaterialEANUOM = lstEAN13.FirstOrDefault().MaterialEANUOM;
                MaterialBarCode.MaterialID = lstEAN13.FirstOrDefault().MaterialID;
                MaterialBarCode.Price = lstEAN13.FirstOrDefault().Price;
                MaterialBarCode.VendorID = lstEAN13.FirstOrDefault().VendorID;
                return PartialView("~/Views/ReturnToSupplier/ReturntoSupplierRow.cshtml", MaterialBarCode);
            }
            else return null;
        }

        public PartialViewResult GetCategoryMaterial(string MaterialID, string CategoryID,string CategoryText)
        {
            try
            {
                List<Proc_MaterialCategorySearch_Result> lstMaterialCategory = TransactionBL.Proc_MaterialCategorySearch(CategoryText, MaterialID, CategoryID);

                if (lstMaterialCategory.Count > 1)
                {
                    Proc_MaterialBarcodeSearch_Result MatCat = new Proc_MaterialBarcodeSearch_Result();
                    MatCat.EAN13 = lstMaterialCategory.FirstOrDefault().EAN13;
                    MatCat.MaterialDesc1 = lstMaterialCategory.FirstOrDefault().MaterialDesc1;
                    MatCat.MaterialEANUOM = lstMaterialCategory.FirstOrDefault().MaterialEANUOM;
                    MatCat.MaterialID = lstMaterialCategory.FirstOrDefault().MaterialID;
                    MatCat.Price = lstMaterialCategory.FirstOrDefault().Price;
                    return PartialView("~/Views/ReturnToSupplier/ListMaterial.cshtml", MatCat);
                }
                else if (lstMaterialCategory.Count == 1)
                {
                    Proc_MaterialBarcodeSearch_Result MaterialBarCode = new Proc_MaterialBarcodeSearch_Result();
                    MaterialBarCode.EAN13 = lstMaterialCategory.FirstOrDefault().EAN13;
                    MaterialBarCode.MaterialDesc1 = lstMaterialCategory.FirstOrDefault().MaterialDesc1;
                    MaterialBarCode.MaterialEANUOM = lstMaterialCategory.FirstOrDefault().MaterialEANUOM;
                    MaterialBarCode.MaterialID = lstMaterialCategory.FirstOrDefault().MaterialID;
                    MaterialBarCode.Price = lstMaterialCategory.FirstOrDefault().Price;
                    MaterialBarCode.VendorID = lstMaterialCategory.FirstOrDefault().VendorID;

                    return PartialView("~/Views/ReturnToSupplier/ReturntoSupplierRow.cshtml", MaterialBarCode);
                }
                else return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public string InsertTempData(string data,string inputval,string LocationID,string StorageID,string Radio,string CategoryID)
        {
            string result = string.Empty;
            try
            {
                string[] values = data.Split('\n');
                if(values.Length>0)
                {
                    string MaterialID = values[2].ToString().Trim();
                    string UOM = values[4].ToString().Trim();
                    string[] UserName = User.Identity.Name.Split('@');
                    result =   TempStorage.InsertTempMater(MaterialID.Trim(), UOM.Trim(), inputval, LocationID.Trim(), StorageID.Trim(), Radio.Trim(), CategoryID,UserName[0]);
                }
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public string DeleteRow(string data, string inputval, string LocationID)
        {
            string result = string.Empty;
            string UOM = string.Empty;
            try
            {
                string MaterialID = null;
                string[] values = data.Split('\n');
                if (values.Length > 0)
                {
                    string Value = values[2].ToString();
                    if (Value == "Delete")
                    {
                         MaterialID = values[2].ToString();
                        UOM = values[4].ToString();
                    }
                    else
                    {
                        MaterialID = values[4].ToString();
                        UOM = values[6].ToString();
                        
                    }
                    result = TempStorage.DeleteRow(MaterialID.Trim(), UOM.Trim(), inputval.Trim(), LocationID.Trim());
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
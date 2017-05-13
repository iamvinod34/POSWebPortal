using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Entity.Entities;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Util.Model;
namespace POS.Web.Controllers.Transaction
{
    [Authorize]
    public class PurchaseOrderController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        TransactionBL TransactionBL = new TransactionBL();
        VendorBL VendorBL = new VendorBL();
        StorageBL StorageBL = new StorageBL();
        TempStorage TempStorage = new TempStorage();
        TransactionModel TransactionModel = new TransactionModel();
        // GET: PurchaseOrder
        public ActionResult Index()
        {
            LocationBL.EmailID = User.Identity.Name;
            ViewBag.Location = LocationBL.GetAll().Select(c => new SelectListItem()
            {
                Text = c.LocationDesc,
                Value = c.LocationID,

            }).ToList();

            ViewBag.Vendor = VendorBL.GetVendorAll().Select(a => new SelectListItem()
            {
                Text = a.Name1,
                Value = a.VendorID

            }).ToList();

            return View(TransactionModel);
        }
        public PartialViewResult GetMaterial(string MatrialOrBarcode, string VendorID,string PageName)
        {
            List<Proc_MaterialBarcodeSearch_Result> lstMaterial = TransactionBL.GetReturnToSupplierMaterial(MatrialOrBarcode, VendorID,PageName);
            if (lstMaterial.Count > 1)
            {
                return PartialView("~/Views/ReturnToSupplier/ListMaterial.cshtml", lstMaterial);
            }
            else if (lstMaterial.Count == 1)
            {
                return PartialView("~/Views/ReturnToSupplier/ReturntoSupplierRow.cshtml", lstMaterial.FirstOrDefault());
            }
            else return null;
        }

        public PartialViewResult GetStorage(string LocationID)
        {

            List<tbl_Storage> subCategories = StorageBL.GetByID(LocationID.Trim());
            ViewBag.Storages = subCategories.Select(s => new SelectListItem()
            {
                Text = s.StorageID,
                Value = s.StorageID,

            }).ToList();
            return PartialView("~/Views/Shared/Dropdown.cshtml");
        }

        public PartialViewResult GetEAN(string EAN13, string UOM, string VendorID,string PageName)
        {
            List<Proc_SearchEAN_Result> lstEAN13 = TransactionBL.GetProc_SearchEAN(EAN13, UOM, VendorID,PageName);
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

        public string InsertTempDataPurchaseOrder(string data, string inputval, string LocationID, string StorageID, string Vendor, string TempMasterID)
        {
            string result = string.Empty;
            try
            {
                string[] values = data.Split('\n');
                if (values.Length > 0)
                {
                    string MaterialID = values[2].ToString().Trim();
                    string UOM = values[4].ToString().Trim();
                    string[] UserName = User.Identity.Name.Split('@');
                    result = TempStorage.InsertTempMaterPurchaseOrder(MaterialID.Trim(), UOM.Trim(), inputval, LocationID.Trim(), StorageID.Trim(), Vendor, TempMasterID, UserName[0]);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PartialViewResult GetTempDetails(string LocationID, string Type)
        {
            try
            {
                List<Proc_TempDetailsData_Result> GetTempDetails = TempStorage.GetTempDetails(LocationID.Trim(), Type.Trim());

                return PartialView("~/Views/Shared/TempDetails.cshtml", GetTempDetails);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? Accept(string ID)
        {
            int? result = 0;
            int TempMasterID = Convert.ToInt32(ID);
            result = TempStorage.pxAcceptTransaction(TempMasterID);

            return true;
        }
    }
}
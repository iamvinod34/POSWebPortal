using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Entity.Entities;
using POS.Business.BusinessComponents;
using POS.Util.Model;
namespace POS.Web.Controllers.Transaction
{
    [Authorize]
    public class ProductionOrderController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        TransactionBL TransactionBL = new TransactionBL();
        TempStorage TempStorage = new TempStorage();
        ProductionOrder ProductionOrder = new ProductionOrder();
        TransactionModel TransactionModel = new TransactionModel();
        // GET: ProductionOrder
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
        public PartialViewResult GETBOMID(string MatrialOrBarcode)
        {
            ViewBag.Page = "Transfter OUT";
            List<Proc_MaterialBarcodeSearch_Result> lstMaterial = ProductionOrder.GETBOMID(MatrialOrBarcode);
            //if (lstMaterial.Count > 1)
            //{
            //    return PartialView("~/Views/ReturnToSupplier/ListMaterial.cshtml", lstMaterial);
            //}
            //else 
            if (lstMaterial.Count >0)
            {
                return PartialView("~/Views/ReturnToSupplier/ReturntoSupplierRow.cshtml", lstMaterial.FirstOrDefault());
            }
            else return null;
        }

        public string InsertTempData(string data, string inputval, string LocationID,string StorageID)
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
                    result = TempStorage.InsertTempMaterProductionOrder(MaterialID.Trim(), UOM.Trim(), inputval, LocationID.Trim(), UserName[0], StorageID);
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
using POS.Business.BusinessComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Entity.Entities;
using POS.Util.Model;


namespace POS.Web.Controllers.POSReport
{
    [Authorize]
    public class ProductionOrderStatusController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        Reprots Reprots = new Reprots();
        ProductionOrderStatusModel ProductionOrderStatusModel = new ProductionOrderStatusModel();
        // GET: ProductionOrderStatus
        public ActionResult Index()
        {
            LocationBL.EmailID = User.Identity.Name;
            ViewBag.Location = LocationBL.GetAll().Select(c => new SelectListItem()
            {
                Text = c.LocationDesc,
                Value = c.LocationID,

            }).ToList();

            return View(ProductionOrderStatusModel);
        }
        public PartialViewResult GetList(string LocationID,string FromDate,string ToDate)
        {
            List<Proc_REPORTProductionOrderStatus_Result> ProductionOrderStatus = new List<Proc_REPORTProductionOrderStatus_Result>();
            ProductionOrderStatus = Reprots.ProductioOrderStatusReport(LocationID,Convert.ToDateTime(FromDate),Convert.ToDateTime(ToDate));

            List<ProductionOrderStatusModel> ProdcutionOrderStatusModel = new List<ProductionOrderStatusModel>();
            Proc_REPORTProductionOrderStatus_Result Proc_REPORTProductionOrderStatus_Result = new Proc_REPORTProductionOrderStatus_Result();
            foreach (Proc_REPORTProductionOrderStatus_Result item in ProductionOrderStatus)
            {
                ProductionOrderStatusModel objProductionOrderStatusModel = new ProductionOrderStatusModel();
                objProductionOrderStatusModel.CategoryID = item.CategoryID;
                objProductionOrderStatusModel.ID = item.ID;
                objProductionOrderStatusModel.LocationID = item.LocationID;
                objProductionOrderStatusModel.MaterialDesc1 = item.MaterialDesc1;
                objProductionOrderStatusModel.MaterialID = item.MaterialID;
                objProductionOrderStatusModel.Status = item.Status;
                objProductionOrderStatusModel.StorageID = item.StorageID;
                objProductionOrderStatusModel.TotalTransQty = item.TotalTransQty;
                objProductionOrderStatusModel.TotalDeliveryQty = item.TotalDeliveryQty;
                objProductionOrderStatusModel.UOM = item.UOM;
                objProductionOrderStatusModel.UserID = item.UserID;
                ProdcutionOrderStatusModel.Add(objProductionOrderStatusModel);
            }

            return PartialView("~/Views/ProductionOrderStatus/ProductionOrderStatus.cshtml", ProdcutionOrderStatusModel);
        }
    }
}
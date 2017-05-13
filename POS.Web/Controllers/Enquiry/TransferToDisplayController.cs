using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;


namespace POS.Web.Controllers.Enquiry
{
    [Authorize]
    public class TransferToDisplayController : Controller
    {
        TransferDisplayBL TransferDisplayBL = new TransferDisplayBL();
        TransferDisplayModel TransferDisplayModel;
        LocationBL LocationBL = new LocationBL();
       
        public ActionResult Index()
        {
            TransferDisplayModel = TransferDisplayBL.GetTransferDisplay();
            ViewBag.Page = "Transfer Display";
            ViewBag.Categories = TransferDisplayModel.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryDesc,
                Value = c.CategoryID,

            }).ToList();

            LocationBL.EmailID = User.Identity.Name;
            ViewBag.Locations = LocationBL.GetAll().Select(l => new SelectListItem()
            {
                Text = l.LocationDesc,
                Value = l.LocationID,

            }).ToList();

            return View(TransferDisplayModel);
        }

        public ActionResult PhysicalInventory()
        {
            TransferDisplayModel = TransferDisplayBL.GetPhysicalInventory();
            ViewBag.Page = "Physical Inventory";
            ViewBag.Categories = TransferDisplayModel.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryDesc,
                Value = c.CategoryID,

            }).ToList();

            ViewBag.Locations = LocationBL.GetAll().Select(l => new SelectListItem()
            {
                Text = l.LocationDesc,
                Value = l.LocationID,

            }).ToList();

            return View("~/Views/TransferToDisplay/Index.cshtml",TransferDisplayModel);
        }

        //public PartialViewResult Filter(TransferDisplayModel TransferDisplayModel)
        //{
        //    TransferDisplayModel.SelectedCategory = Request.Form["fltrCategory"];
        //    string subcategory = Request.Form["fltrSubCategory"];
        //    TransferDisplayModel.SelectedSubCategory = subcategory != null ? subcategory : string.Empty;
        //    return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.Filter(salesEnquiry));
        //}
    }
}
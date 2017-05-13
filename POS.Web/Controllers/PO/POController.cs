using POS.Business.BusinessComponents;
using POS.Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Web.Controllers.PO
{
    [Authorize]
    public class POController : Controller
    {
        SalesBL salesBL = new SalesBL();
        LocationBL LocationBL = new LocationBL();
        TransferDisplayBL TransferDisplayBL = new TransferDisplayBL();
        SalesEnquiryModel salesModel;
        // GET: PO
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recieve()
        {
            salesModel = salesBL.GetPOReieve();
            ViewBag.Page = "PO Recieve";
            ViewBag.Categories = salesModel.Categories.Select(c => new SelectListItem()
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

            return View("~/Views/Sales/Enquiry.cshtml", salesModel);
        }

        public ActionResult ReturnToSupplier()
        {
            salesModel = salesBL.GetReturnToSupplier();
            ViewBag.Page = "Return To Supplier";
            ViewBag.Categories = salesModel.Categories.Select(c => new SelectListItem()
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
            return View("~/Views/Sales/Enquiry.cshtml", salesModel);
        }

        public PartialViewResult GetPORecieveMaterial(string docid,string FilterName)
        {
            return PartialView("~/Views/Sales/Partial/_DocumentMaterialPartial.cshtml", salesBL.GetPORecieveMaterial(docid,FilterName));
        }

        public PartialViewResult Filter(SalesEnquiryModel salesEnquiry)
        {
            salesEnquiry.SelectedCategory = Request.Form["fltrCategory"];
            string subcategory = Request.Form["fltrSubCategory"];
            salesEnquiry.Location = Request.Form["fltrLocation"].Trim();
            salesEnquiry.SelectedSubCategory = subcategory != null ? subcategory : string.Empty;
            ViewBag.Page = "PO Recieve";
            return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.POFilter(salesEnquiry));
        }

        public ActionResult TransfterToDisplay()
        {
            salesModel = salesBL.GetTransfterToDisplay();
            ViewBag.Page = "Transfter To Display";
            ViewBag.Categories = salesModel.Categories.Select(c => new SelectListItem()
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
            return View("~/Views/Sales/Enquiry.cshtml", salesModel);
        }


        public ActionResult PhysicalInventory()
        {
            salesModel = salesBL.GetPhysicalInventory();
            ViewBag.Page = "Physical Inventory";
            ViewBag.Categories = salesModel.Categories.Select(c => new SelectListItem()
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
            return View("~/Views/Sales/Enquiry.cshtml", salesModel);
        }

        public PartialViewResult GetPORecieveMaterialPrintDocument(string docid, string FilterName)
        {
            return PartialView("~/Views/Sales/Partial/AllDocumentPrint.cshtml", salesBL.PrintallDocuments(docid, FilterName));
        }

        public ActionResult TransfterIN()
        {
            salesModel = salesBL.GetTransfterIN();
            ViewBag.Page = "Transfter IN";
            ViewBag.Categories = salesModel.Categories.Select(c => new SelectListItem()
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
            return View("~/Views/Sales/Enquiry.cshtml", salesModel);
        }

        public ActionResult TransfterOUT()
        {
            salesModel = salesBL.GetTransfterOUT();
            ViewBag.Page = "Transfter OUT";
            ViewBag.Categories = salesModel.Categories.Select(c => new SelectListItem()
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
            return View("~/Views/Sales/Enquiry.cshtml", salesModel);
        }
    }
}
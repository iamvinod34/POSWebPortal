using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;

namespace POS.Web.Controllers
{
    ///Created by Srikanth Kotnala on 8/13/2016
    ///<summary>
    ///Location Controller
    /// </summary>
    //[Authorize(Roles = "Admin, User")]
    [Authorize]
    public class EnquiryController : Controller
    {
        SalesBL salesBL = new SalesBL();
        SalesEnquiryModel salesModel;
        LocationBL LocationBL = new LocationBL();

        public ActionResult GetEnquiry()
        {
            salesModel = salesBL.GetEnquiries();
            ViewBag.Page = "Sales Enquiry";
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

        public PartialViewResult Filter(SalesEnquiryModel salesEnquiry)
        {
            salesEnquiry.SelectedCategory = Request.Form["fltrCategory"];
            string subcategory = Request.Form["fltrSubCategory"];
            //salesEnquiry.Location= Request.Form["fltrLocation"].Trim();
            salesEnquiry.SelectedSubCategory = subcategory != null ? subcategory : string.Empty;
            return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.Filter(salesEnquiry));
        }

        public PartialViewResult GetSubCategory(string categoryID)
        {

            List<tbl_SubCategory> subCategories = salesBL.SubCategoriesByID(categoryID);
            ViewBag.SubCategories = subCategories.Select(c => new SelectListItem()
            {
                Text = c.SubCategoryDesc,
                Value = c.SubCategoryID,

            }).ToList();
            return PartialView("~/Views/Shared/Dropdown.cshtml");
        }

        public PartialViewResult Material(string docid)
        {
            return PartialView("~/Views/Sales/Partial/_DocumentMaterialPartial.cshtml", salesBL.GetDocumentMaterial(docid));
        }

        public PartialViewResult Tender(string docid)
        {
            return PartialView("~/Views/Sales/Partial/_DocumentTenderPartial.cshtml", salesBL.GetDocumentTender(docid));
        }

        public ActionResult ReturnWithInvoice()
        {
            salesModel = salesBL.GetSalesWithInvoice();
            ViewBag.Page = "ReturnWithInvoice";
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

        public PartialViewResult FilterReturnWithInvoice(SalesEnquiryModel salesEnquiry)
        {
            return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.FilterReturnWithInvoice(salesEnquiry));
        }

        public ActionResult ReturnWithoutInvoice()
        {
            salesModel = salesBL.GetSalesWithoutInvoice();
            ViewBag.Page = "ReturnWithoutInvoice";
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

        public PartialViewResult FilterReturnWithoutInvoice(SalesEnquiryModel salesEnquiry)
        {
            return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.FilterReturnWithoutInvoice(salesEnquiry));
        }

        public ActionResult SalesDelete()
        {
            salesModel = salesBL.GetAllSalesDelete();
            ViewBag.Page = "Sales Delete";
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

        public PartialViewResult GetDeletedMaterial(string docid)
        {
            return PartialView("~/Views/Sales/Partial/_DocumentMaterialPartial.cshtml", salesBL.GetDeletedDocumentMaterial(docid));
        }

        public PartialViewResult GetDeletedTender(string docid)
        {
            return PartialView("~/Views/Sales/Partial/_DocumentTenderPartial.cshtml", salesBL.GetDeletedDocumentTender(docid));
        }

        public ActionResult GetUnHoldEnquiry()
        {
            salesModel = salesBL.GetAllSalesUnhold();
            ViewBag.Page = "Sales Hold Invoice";
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

        public PartialViewResult GetRecentSales()
        {
            return PartialView("~/Views/Sales/Partial/_RecentSalesGrid.cshtml", salesBL.GetLatestSalesDetails());
        }

        public PartialViewResult FilterReturnTransfterPhysical(SalesEnquiryModel salesEnquiry, string FilterName)
        {
            try
            {
                ViewBag.Page = FilterName;
                return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.FilterReturnTrafterPhysical(salesEnquiry, FilterName));
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public PartialViewResult FilterDeleteLineItems(SalesEnquiryModel salesEnquiry, string FilterName)
        {
            try
            {
                ViewBag.Page = FilterName;
                return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.FilterDeleteLineItems(salesEnquiry));
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public PartialViewResult PrintDocument(string docID)
        {
            try
            {
                return PartialView("~/Views/Sales/Partial/PrintDocument.cshtml", salesBL.PrintDocTenderDetails(docID));
            }
            catch (Exception ex)
            {

            }
            return PartialView();
        }

        public PartialViewResult FilterUnHold(SalesEnquiryModel salesEnquiry)
        {
            salesEnquiry.SelectedCategory = Request.Form["fltrCategory"];
            string subcategory = Request.Form["fltrSubCategory"];
            //salesEnquiry.Location= Request.Form["fltrLocation"].Trim();
            salesEnquiry.SelectedSubCategory = subcategory != null ? subcategory : string.Empty;
            return PartialView("~/Views/Sales/Partial/_SalesGridPartial.cshtml", salesBL.FilterUnHold(salesEnquiry));
        }

        public ActionResult EnquiryEOD(SalesEnquiryModel salesEnquiry, string FilterName)
        {
            try
            {
                salesModel = salesBL.GetEODEnquiries();
                ViewBag.Page = "EOD";
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

                return View("~/Views/Sales/EODEnquiry.cshtml", salesModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PartialViewResult FilterEod(SalesEnquiryModel salesEnquiry, string FilterName)
        {
            try
            {
                ViewBag.Page = FilterName;
                return PartialView("~/Views/Sales/Partial/EodEnquiryDetails.cshtml", salesBL.FilerEod(salesEnquiry,FilterName));
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public FileResult GetByEodFile(string docid)
        {
            byte[] FileByte = salesBL.GetEodFile(docid);
           
            return File(FileByte, "application/pdf",docid+".pdf");
        }
    }
}
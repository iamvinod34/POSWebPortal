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
    public class PORecieveController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        TransactionBL TransactionBL = new TransactionBL();
        TransactionModel TransactionModel = new TransactionModel();
        // GET: PORecieve
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
        [HttpPost]
        public JsonResult GetPONumberByLocation(string LocationID)
        {
            return Json(TransactionBL.GetPOByLocation(LocationID));
        }

        public JsonResult GetPOByDocID(string DOCID)
        {
            tbl_PurchaseOrder PO = TransactionBL.GetOrderByDocID(DOCID);

            return Json(new { PostingDate = PO.PostingDate.Value.ToString("dd/MM/yyyy"), VendorID = PO.VendorID }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult PODetail(string DOCID)
        {
            TempData["DocID"] = DOCID;
            return PartialView("~/Views/PORecieve/PODetail.cshtml", TransactionBL.GetPODetail(DOCID));
        }

        [HttpPost]
        public ActionResult PORecieve(FormCollection form)
        {
            Dictionary<string, string> latestPODetails = new Dictionary<string, string>();
            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                latestPODetails.Add(key, value);
            }
            string docid = TempData["DocID"].ToString();
            TransactionBL.AcceptPO(latestPODetails, docid);
            return null;
        }
        [HttpPost]
        public ActionResult TIRecieve(FormCollection form)
        {
            Dictionary<string, string> latestPODetails = new Dictionary<string, string>();
            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                latestPODetails.Add(key, value);
            }
            string docid = TempData["DocID"].ToString();
            TransactionBL.AcceptTI(latestPODetails, docid);
            return null;
        }
    }
}
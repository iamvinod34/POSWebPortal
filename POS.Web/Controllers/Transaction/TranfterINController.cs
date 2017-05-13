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
    public class TranfterINController : Controller
    {
        // GET: TranfterIN
        LocationBL LocationBL = new LocationBL();
        TransactionBL TransactionBL = new TransactionBL();
        TransactionModel TransactionModel = new TransactionModel();

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
        public JsonResult GetTINumberByLocation(string LocationID)
        {
            ViewBag.Page = "Transfter IN";
            return Json(TransactionBL.GetTIByLocation(LocationID));
        }
        public JsonResult GetTIByDocID(string DOCID)
        {
            ViewBag.Page = "Transfter IN";
            tbl_TransferOut PO = TransactionBL.GetTIOrderByDocID(DOCID);

            return Json(new { PostingDate = PO.PostingDate.Value.ToString("dd/MM/yyyy"), VendorID = PO.VendorID }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult TIDetail(string DOCID)
        {
            TempData["DocID"] = DOCID;
            ViewBag.Page = "Transfter IN";
            return PartialView("~/Views/PORecieve/PODetail.cshtml", TransactionBL.GetTIDetail(DOCID));
        }
    }
}
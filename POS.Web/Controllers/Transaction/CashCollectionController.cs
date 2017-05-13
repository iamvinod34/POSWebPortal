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
    public class CashCollectionController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        CashCollection CashCollection = new CashCollection();
        TransactionModel TransactionModel = new TransactionModel();
        EODBL EODBL = new EODBL();
        // GET: CashCollection
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
        public PartialViewResult GetEodIDCashCollection(string LocationID,string FromDate,string ToDate)
        {
            List<Proc_CashCollection_Result> Proc_CashCollection_Result = new List<Entity.Entities.Proc_CashCollection_Result>();
           Proc_CashCollection_Result= CashCollection.GetEodDetails(LocationID.Trim(),FromDate,ToDate).ToList();
            return PartialView("~/Views/CashCollection/Partial/EODDetails.cshtml",Proc_CashCollection_Result);
        }

        public string UpdateCashCollection(string TextBoxVal,string EODIDVal,string LocationID)
        {
            string CashCollection = string.Empty;
            try
            {
                tbl_EOD GetByEodId = new tbl_EOD();
                GetByEodId.LocationID = LocationID.Trim();
                GetByEodId.EODID = EODIDVal.Trim();
                    GetByEodId.Cash_Collection =Convert.ToDecimal(TextBoxVal.Trim());
                CashCollection= CashCollection = EODBL.Update(GetByEodId);
                return CashCollection;
            }
            catch (Exception ex)
            {
                CashCollection = "Please Try again...!!!";
                return CashCollection;
            }
            
        }
    }
}
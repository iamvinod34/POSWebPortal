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
    public class TranfterOUTController : Controller
    {

        LocationBL LocationBL = new LocationBL();
        TransactionBL TransactionBL = new TransactionBL();
        TempStorage TempStorage = new TempStorage();
        TransactionModel TransactionModel = new TransactionModel();
        // GET: TranfterOUT
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

        public string Accept(string ID)
        {
            string result = null;
            int TempMasterID = Convert.ToInt32(ID);
            result = TempStorage.pxAcceptTransaction(TempMasterID).ToString();

            return "True";
        }
    }
}
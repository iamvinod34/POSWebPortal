using POS.Business.BusinessComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;
using POS.Entity.Entities;

namespace POS.Web.Controllers.POSReport
{
    [Authorize]
    public class ProfitShortageController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        UserAuthenticationModel UserAuthenticationModel = new UserAuthenticationModel();
        ProfitShortageModel ProfitShortageModel = new ProfitShortageModel();
        Reprots Reprots = new Reprots();
        // GET: ProfitShortage
        public ActionResult Index()
        {
            LocationBL.EmailID = User.Identity.Name;
            ViewBag.Location = LocationBL.GetAll().Select(c => new SelectListItem()
            {
                Text = c.LocationDesc,
                Value = c.LocationID,

            }).ToList();

            return View(ProfitShortageModel);
        }

        public PartialViewResult GetProfitShort(string LocationID,DateTime? FromDate,DateTime? ToDate)
        {
            try
            {
                List<Proc_ProfitShortageReport_Result> ProfitShortageReport = new List<Proc_ProfitShortageReport_Result>();
                ProfitShortageReport = Reprots.ProfitShortageReport(LocationID,FromDate,ToDate);
                return PartialView("~/Views/ProfitShortage/Partial/ProfitShortage.cshtml", ProfitShortageReport);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
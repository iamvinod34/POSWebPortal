using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace POS.Web.Controllers.POSReport
{
    [Authorize]
    public class POSReportController : Controller
    {
        
        // GET: POSReport
        public ActionResult Index(string Report)
        {
            Session["Reportname"] = Report;
            return RedirectToAction("../ReportViewer/ReportViewer.aspx", new { ReportName = Report });
        }
        //public ActionResult Index(string Report)
        //{
        //    Session["Reportname"] = Report;
        //    return RedirectToAction("../ReportViewer/ReportViewer.aspx", new { ReportName = Report });
        //}
    }
}
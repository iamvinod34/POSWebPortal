using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Web.Controllers.TransfterToDisplayTimeToTime
{
    [Authorize]
    public class TransfterToDisplayTimeToTimeController : Controller
    {
        // GET: TransfterToDisplayTimeToTime
        public ActionResult Index()
        {
            return View();
        }
    }
}
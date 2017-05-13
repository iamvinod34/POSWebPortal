using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Util.Enum;

namespace POS.Web.Controllers
{
    [Authorize]
    public class TerminalController : Controller
    {
        TerminalBL TerminalBL;
        public TerminalController()
        {
            TerminalBL = new TerminalBL();
        }
        // GET: Terminal
        public ActionResult Index()
        {
            TerminalModel TM = new TerminalModel();
            var Values = Enum.GetValues(typeof(TerminalEnum)).Cast<TerminalEnum>();
            var Terminals = from Ter in Values
                            select new SelectListItem
                            {
                                Text = ((int)Ter).ToString(),
                                Value = ((int)Ter).ToString()

                            };
            ViewBag.Terminals = Terminals;

            //IEnumerable<SelectListItem> Terminals=

            TM = TerminalBL.GetAllTerminal();
            return View(TM);
        }
        public PartialViewResult GetTerminalById(string LocationID)
        {
            TerminalModel TModel = new TerminalModel();
            var Values = Enum.GetValues(typeof(TerminalEnum)).Cast<TerminalEnum>();
            var Terminals = from Ter in Values
                            select new SelectListItem
                            {
                                Text = ((int)Ter).ToString(),
                                Value = ((int)Ter).ToString()

                            };
            ViewBag.Terminals = Terminals;
            TModel = TerminalBL.GetByTerminalId(LocationID);
            
            return PartialView("~/Views/Terminal/Partial/_TerminalDetailsPartial.cshtml",TModel);
        }

        public string InsertOrUpdateTerminal(TerminalModel TM)
        {
            tbl_Terminal TBLT = new tbl_Terminal();
            TBLT.LocationID = TM.LocationID;
            TBLT.TerminalID = TM.TerminalID;
            return TerminalBL.InsertOrUpdate(TBLT);
        }

    }
}
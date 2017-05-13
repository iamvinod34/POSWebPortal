using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Entity.Entities;
using POS.Util.Model;
using POS.Business.BusinessComponents;

namespace POS.Web.Controllers
{
    [Authorize]
    public class RegionController : Controller
    {
        RegionBL RegionBL;
        public RegionController()
        {
            RegionBL = new RegionBL();
        }
        // GET: Region
        public ActionResult Index()
        {
            RegionModel RM = new RegionModel();
            RM = RegionBL.RegionModel();
            return View(RM);
        }
        public string InsertOrUpdateRegion(RegionModel RM)
        {
            tbl_Region Region = new tbl_Region();
            Region.RegionID = RM.RegionID;
            Region.RegionName = RM.RegionName;
            return RegionBL.InsertOrUpdate(RM);
        }

        public PartialViewResult GetRegionById(int RegionID)
        {
            RegionModel RM = new RegionModel();
            tbl_Region Region;
            Region = RegionBL.GetById(RegionID);

            if (Region == null)
            {
                Region = new tbl_Region();
            }
            RM.RegionID = Region.RegionID;
            RM.RegionName = Region.RegionName;

            return PartialView("~/Views/Region/Partial/_RegionDetailsPartial.cshtml", RM);
        }
    }
}
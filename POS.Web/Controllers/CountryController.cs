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
    public class CountryController : Controller
    {
        CountryBL CountryBL;
        public CountryController()
        {
            CountryBL = new CountryBL();
        }
        // GET: Country
        public ActionResult Index()
        {
            CountryModel CoM = new CountryModel();
            CoM = CountryBL.CountryModel();
            return View(CoM);
        }
        public string InsertOrUpdateCountry(CountryModel CM)
        {
            tbl_Country Country = new tbl_Country();
            Country.CountryID = CM.CountryID;
            Country.CountryName = CM.CountryName;
            return CountryBL.InsertOrUpdate(CM);
        }

        public PartialViewResult GetCountryById(int CountryID)
        {
            CountryModel CM = new CountryModel();
            tbl_Country Country;
            Country = CountryBL.GetById(CountryID);

            if (Country == null)
            {
                Country = new tbl_Country();
            }
            CM.CountryID = Country.CountryID;
            CM.CountryName = Country.CountryName;

            return PartialView("~/Views/Country/Partial/_CountryDetailsPartial.cshtml", CM);
        }
    }
}
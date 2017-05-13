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
    public class CityController : Controller
    {
        CityBL CityBL;
        public CityController()
        {
            CityBL = new CityBL();
        }
        // GET: City
        public ActionResult Index()
        {
            CityModel CM = new CityModel();
            CM = CityBL.MCity();
            return View(CM);
        }
        public string InsertOrUpdateCity(CityModel CM)
        {
            tbl_City City = new tbl_City();
            City.CityID = CM.CityID;
            City.CityName = CM.CityName;
            return  CityBL.InsertOrUpdate(CM);
        }

        public PartialViewResult GetCityById(string CityID)
        {
            CityModel CM = new CityModel();
            tbl_City city;
            city = CityBL.GetById(CityID);

            if (city == null)
            {
                city = new tbl_City();
            }
            CM.CityID = city.CityID;
            CM.CityName = city.CityName;

            return PartialView("~/Views/City/Partial/_CityDetailsPartial.cshtml", CM);
        }
    }
}
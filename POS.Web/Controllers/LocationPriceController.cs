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
    public class LocationPriceController : Controller
    {
        LocationPriceModel LPM = new LocationPriceModel();

        LocationPriceBL LocationPriceBL;
        public LocationPriceController()
        {
            LocationPriceBL = new LocationPriceBL();
        }

        // GET: LocationPrice
        public ActionResult Index()
        {
            
            LocationPriceModel LPM = new LocationPriceModel();
            LPM = LocationPriceBL.MLocationPrice();
            return View(LPM);
        }
        public string InsertOrUpdateLocationPrice(LocationPriceModel LPM)
        {
            tbl_LocationPrice LocationPrice= new tbl_LocationPrice();
            LocationPrice.EAN13 = LPM.EAN13;
            LocationPrice.LocationID = LPM.LocationID;
            LocationPrice.MaterialID = LPM.MaterialID;
            LocationPrice.Price = LPM.Price;
            LocationPrice.UOM = LPM.UOM;
            return LocationPriceBL.InsertOrUpdate(LPM);
        }

        public string LocationPriceGetByID(LocationPriceModel LPM)
        {
          List<tbl_LocationPrice> LP = new List<tbl_LocationPrice>();
         //   LP.FirstOrDefault().EAN13 = LPM.EAN13;
          //  LP.FirstOrDefault().LocationID = LPM.LocationID;

            string LocID = string.Join(",",LPM.LocationID);
            string EAN13 = string.Join(",", LPM.EAN13);

            return null;// LocationPriceBL.GetById(EAN13, LocID);

        }
    }
}
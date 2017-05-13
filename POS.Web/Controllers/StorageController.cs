using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Util.Model;

namespace POS.Web.Controllers
{
    [Authorize]
    ///Created by Vinod on 16/08/2016
    ///<summary>
    ///Storage Controller
    /// </summary>
    public class StorageController : Controller
    {
        StorageBL StorageBL;
        public StorageController()
        {
            StorageBL = new StorageBL();
        }

        // GET: Storage
        public ActionResult Index()
        {
            LocationStorageModel LocationStorage = new LocationStorageModel();
            LocationStorage = StorageBL.GetStorage();
            return View(LocationStorage);
        }

        //public PartialViewResult GetStorageByID(string locationID)
        //{
        //   List<tbl_Storage> storageGetById = StorageBL.GetByID(locationID);
        //    return PartialView("~/Views/Storage/Partial/_StorageDetailsPartial.cshtml", storageGetById);
        //}

        public string InsertOrUpdateStorage(LocationStorageModel LSM)
        {
            tbl_Storage storage = new tbl_Storage();
            storage.LocationID = LSM.LocationID;
            storage.StorageID = LSM.StorageID;
            return StorageBL.InsertOrUpdate(storage);
        }

        public PartialViewResult GetStorageById(string LocationID)
        {
         
            LocationStorageModel LocationStorage = new LocationStorageModel();
            LocationStorage= StorageBL.GetStorageById(LocationID);
           
            return PartialView("~/Views/Storage/Partial/_StorageDetailsPartial.cshtml", LocationStorage);
        }
        public PartialViewResult GetStorageId(string locationID)
        {
            List<tbl_Storage> locationId = StorageBL.GetByID(locationID.Trim()).ToList();
            bool IsExsit = false;
            if (locationId == null || locationId.Count == 0)
            {
                locationId = new List<tbl_Storage>();
                IsExsit = true;
            }
            LocationStorageModel LSM = new LocationStorageModel();
            if (!IsExsit)
            {
                LSM.LocationID = locationId[0].ToString();
                LSM.LocationDesc = locationId[1].ToString();
                LSM.StorageID = locationId[2].ToString();
            }
            return PartialView("~/Views/Storage/Partial/_StorageDetailsPartial.cshtml", LSM);
        }
    }
}
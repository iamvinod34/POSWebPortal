using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Business.BusinessComponents;
using POS.Util.Model;
namespace POS.Web.Controllers.Transaction
{
    [Authorize]
    public class TransactionTransfterToDisplayController : Controller
    {
        LocationBL LocationBL = new LocationBL();
        TempStorage TempStorage = new TempStorage();
        TransactionModel TransactionModel = new TransactionModel();

        // GET: TransactionTransfterToDisplay
        public ActionResult Index()
        {
            LocationBL.EmailID = User.Identity.Name;
            ViewBag.Location = LocationBL.GetAll().Select(c => new SelectListItem()
            {
                Text = c.LocationDesc,
                Value = c.LocationID,

            }).ToList();

            
            return View("~/Views/TransferToDisplay/TransferToDisplay.cshtml", TransactionModel);
        }
        public string InsertTempData(string data, string inputval, string LocationID)
        {
            string result = string.Empty;
            try
            {
                string[] values = data.Split('\n');
                if (values.Length > 0)
                {
                    string MaterialID = values[2].ToString().Trim();
                    string UOM = values[4].ToString().Trim();
                    string[] UserName = User.Identity.Name.Split('@');
                    result = TempStorage.InsertTempMaterTransfterToDisplay(MaterialID.Trim(), UOM.Trim(), inputval, LocationID.Trim(),UserName[0]);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string DeleteRow(string data, string inputval, string LocationID)
        {
            string result = string.Empty;
            try
            {
                string[] values = data.Split('\n');
                if (values.Length > 0)
                {
                    string MaterialID = values[2].ToString();
                    string UOM = values[4].ToString();
                    result = TempStorage.DeleteRow(MaterialID.Trim(), UOM.Trim(), inputval.Trim(), LocationID.Trim());
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Accept(string ID)
        {
            string result = null;
            int TempMasterID = Convert.ToInt32(ID);
            result = TempStorage.pxAcceptTransaction(TempMasterID).ToString();

            return "True";
        }

        public string InsertTempTO(string data, string inputval, string FLocationID,string TLocationID,string FStorageID,string TStorageID)

        {
            string result = string.Empty;
            try
            {
                string[] values = data.Split('\n');
                if (values.Length > 0)
                {
                    string MaterialID = values[2].ToString().Trim();
                    string UOM = values[4].ToString().Trim();
                    string[] UserName = User.Identity.Name.Split('@');
                    result = TempStorage.InsertTempMaterTransfterOUT(MaterialID.Trim(), UOM.Trim(), inputval, FLocationID.Trim(), UserName[0],TLocationID,FStorageID,TStorageID);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
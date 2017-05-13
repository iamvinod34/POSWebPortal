using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Business.BusinessComponents;
using POS.Util.Model;

namespace POS.Web.Controllers.ControlPanel
{
    [Authorize]
    public class UserAuthenticationController : Controller
    {
        AuthenticationBL AuthenticationBL = new AuthenticationBL();
        UserAuthenticationModel UserAuthenticationModel = new UserAuthenticationModel();
        LocationBL LocationBL = new LocationBL();
        // GET: UserAuthentication
        public ActionResult Index()
        {
            LocationBL.EmailID = User.Identity.Name;
            LocationBL.UserAuthentication = "UserAuthentication";
            UserAuthenticationModel.lstLocations = LocationBL.GetAll();
            UserAuthenticationModel.lstUseridsbyManager = AuthenticationBL.SelectUserId(User.Identity.Name);
            UserAuthenticationModel.lstAspNetRole = AuthenticationBL.AspNetRoleGetAll();
            LocationBL.UserAuthentication = string.Empty;
            return View(UserAuthenticationModel);
        }
        [HttpPost]
        public ActionResult Save(FormCollection FormCollection,UserAuthenticationModel UserAuthenticationModel)
        {
            string result = string.Empty;
            LocationBL.UserAuthentication = "UserAuthentication";
            LocationBL.EmailID = User.Identity.Name;
            UserAuthenticationModel.lstLocations = LocationBL.GetAll();
            string ULLocationIDs = string.Empty;
            string MLLocationIDs = string.Empty; ;
            for (int i = 0; i < UserAuthenticationModel.lstLocations.Count; i++)
            {
                string ULLocId = UserAuthenticationModel.lstLocations[i].LocationID + "UL" + i;
                string MLLocId = UserAuthenticationModel.lstLocations[i].LocationID + "ML" + i;
                var ULColl = FormCollection[ULLocId].Split(',');
                var MLColl = FormCollection[MLLocId].Split(',');

                if (ULColl.Length > 0)
                {
                    bool ULChecked = ULColl[0].Contains("true");
                    if (ULChecked)
                    {
                        ULLocationIDs=(UserAuthenticationModel.lstLocations[i].LocationID.Trim())+","+ ULLocationIDs;
                    }
                }

                if (MLColl.Length > 0)
                {
                    bool MLChecked = MLColl[0].Contains("true");
                    if (MLChecked)
                    {
                        MLLocationIDs = (UserAuthenticationModel.lstLocations[i].LocationID.Trim())+","+ MLLocationIDs;
                    }
                }
            }
            AuthenticationBL.SaveAuthentication(UserAuthenticationModel, ULLocationIDs, MLLocationIDs);
            LocationBL.UserAuthentication = string.Empty;
            UserAuthenticationModel.lstUseridsbyManager = AuthenticationBL.SelectUserId(User.Identity.Name);
            UserAuthenticationModel.lstAspNetRole = AuthenticationBL.AspNetRoleGetAll();
            result = "Success";
            return View("Index",UserAuthenticationModel);
        }

        public PartialViewResult Select(string Email,string UserId)
        {
            LocationBL.UserAuthentication = "UserAuthentication";
            UserAuthenticationModel = AuthenticationBL.SelectUserAuthentication(UserId, Email);
            LocationBL.UserAuthentication = string.Empty;
            return PartialView("~/Views/UserAuthentication/Partial/UserLocations.cshtml",UserAuthenticationModel);
        }
    }
}
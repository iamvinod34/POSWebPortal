using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Business.BusinessComponents;
using POS.Util.Model;
using POS.Entity.Entities;
using POS.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Configuration;

namespace POS.Web.Controllers.ControlPanel
{
    [Authorize]
    public class AddUsersController : Controller
    {
        AuthenticationBL AuthenticationBL = new AuthenticationBL();
        UserAuthenticationModel UserAuthenticationModel = new UserAuthenticationModel();
        LocationBL LocationBL = new LocationBL();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        // GET: AddUsers
        public ActionResult Index()
        {
            return View(UserAuthenticationModel);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public async System.Threading.Tasks.Task<PartialViewResult> SaveUser(UserAuthenticationModel UserAuthenticationModel)
        {
            List<tbl_LocationAuthentication> LocationAuth = AuthenticationBL.LocationAuthenticationGetByEmail(User.Identity.Name);
            if (LocationAuth.Count > 0)
            {
                tbl_ManagerUserAuthentication ManagerUserAuthentication = new tbl_ManagerUserAuthentication();
                ManagerUserAuthentication.Manager_EmailID = User.Identity.Name;
                ManagerUserAuthentication.User_EmailID = UserAuthenticationModel.User_EmailID;
                ManagerUserAuthentication.MID = LocationAuth.FirstOrDefault().Id;
                
                if (UserAuthenticationModel.UserName != string.Empty && UserAuthenticationModel.User_EmailID != string.Empty)
                {
                    var user = new ApplicationUser { UserName = UserAuthenticationModel.User_EmailID, Email = UserAuthenticationModel.User_EmailID };
                   var result = await UserManager.CreateAsync(user, UserAuthenticationModel.Password);
                    if (result.Succeeded)
                    {
                        string resultInsert = AuthenticationBL.AspNetManagerInsert(ManagerUserAuthentication);
                        return PartialView("~/Views/AddUsers/Partial/Users.cshtml", UserAuthenticationModel);
                    }
                    else
                    {
                        AddErrors(result);
                        
                    }
                }
            }
            return PartialView("~/Views/AddUsers/Partial/Users.cshtml", UserAuthenticationModel);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
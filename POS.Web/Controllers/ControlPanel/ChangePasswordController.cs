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
    public class ChangePasswordController : Controller
    {
        AuthenticationBL AuthenticationBL = new AuthenticationBL();
        UserAuthenticationModel UserAuthenticationModel = new UserAuthenticationModel();
        LocationBL LocationBL = new LocationBL();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        // GET: ChangePassword
        public ActionResult Index()
        {
            return View(new ChangePassword());
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

        public async System.Threading.Tasks.Task<ActionResult> ChangePassword(ChangePassword ChangePassword)
        {
            if (ChangePassword.Email != string.Empty && ChangePassword.Password != string.Empty && ChangePassword.CurrentPassword != string.Empty)
            {
                List<AspNetUser> UserId = AuthenticationBL.AspNetUserGetByUserEmail(User.Identity.Name);
                var user = new ApplicationUser { UserName = ChangePassword.Email, Email = ChangePassword.Email };
                var result = await UserManager.ChangePasswordAsync(UserId.FirstOrDefault().Id, ChangePassword.CurrentPassword, ChangePassword.Password);
                if (result.Succeeded)
                {
                    ChangePassword.Result = "Successfully Password Changed..";
                    return View("Index", ChangePassword);
                }
                else
                {
                    ChangePassword.Result = "Incorrect password.";
                    return Content(ChangePassword.Result);
                }
            }
            else
            {
                return PartialView("~/Views/ChangePassword/Partial/ChangePassword.cshtml", ChangePassword);
            }
            //return PartialView("~/Views/ChangePassword/Partial/ChangePassword.cshtml", ChangePassword);
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
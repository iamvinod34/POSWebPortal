using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Web.Models;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Util.Model;


namespace POS.Web.Controllers
{
    public class HomeController : Controller
    {
        AuthenticationBL AuthenticationBL = new AuthenticationBL();

        LoginViewModel LoginViewModel;
        public HomeController()
        {
            LoginViewModel = new LoginViewModel();
        }

        public ActionResult Index()
        {
            LocationBL LocationBL = new LocationBL();
            LocationBL.EmailID = User.Identity.Name;
            return View("Index", "_HomeLayout", LoginViewModel);
        }
        public ActionResult Company()
        {
            ViewBag.Message = "Company";

            return View("Company", "_HomeLayout");
        }

        public ActionResult Solutions()
        {
            ViewBag.Message = "Solutions";
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Authorize]
        //public ActionResult ValidationUserSecurity()
        //{
        //    if(User.Identity.IsAuthenticated)
        //    {
        //        string Email = User.Identity.Name;
        //        List<AspNetUser> AspNetUser = AuthenticationBL.AspNetUserGetByUserEmail(Email);
        //        if(AspNetUser.Count>0)
        //        {
        //            string Id = AspNetUser.FirstOrDefault().Id;
        //            LoginViewModel.UserAuthenticationModel =  AuthenticationBL.SelectUserAuthentication(Id, Email);
        //        }
        //        if (LoginViewModel.UserAuthenticationModel.Id == null || LoginViewModel.UserAuthenticationModel.Id == string.Empty)
        //        {
        //            return View("Index", "_HomeLayout", LoginViewModel);
        //        }
        //        else
        //        {
        //            return View("Index", "_HomeLayout", LoginViewModel);
        //        }
        //    }
        //    else
        //    {
        //        return View("Index", "_HomeLayout", LoginViewModel);
        //    }
        //}
    }
}
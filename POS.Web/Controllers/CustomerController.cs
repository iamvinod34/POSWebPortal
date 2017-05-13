using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Business.BusinessComponents;
using POS.Util.Model;
using POS.Entity.Entities;



namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        CustomerModel CustomerModel;
        public CustomerController()
        {
            
        }

        //Object for tbl_Customer
        CustomerBL CustomerBL = new CustomerBL();

        // GET: Customer
        public ActionResult Index()
      {
            CustomerModel = new CustomerModel();
            CustomerModel.lstCustomers= CustomerBL.GetAll();
            CustomerModel.lstPhoneCodes = CustomerBL.GetAllPhoneCode();
            return View(CustomerModel);
        }
    }
}
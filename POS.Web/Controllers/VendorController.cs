using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;

namespace POS.Web.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {
        VendorBL VendorBL;
        public VendorController()
        {
            VendorBL = new VendorBL();

        }
        // GET: Vendor
        public ActionResult Index()
        {
            VendorModel VM = new VendorModel();
            VM = VendorBL.GetVendor();
            return View(VM);
        }
        public PartialViewResult GetByVendorId(string VendorId)
        {
            VendorModel VM = new VendorModel();
            VM = VendorBL.GetVendor();
            tbl_Vendor Vendor = VendorBL.GetByID(VendorId);
            if (Vendor != null)
            {
                VM.VendorID = Vendor.VendorID;
                VM.Name1 = Vendor.Name1;
                VM.Address1 = Vendor.Address1;
                VM.Address2 = Vendor.Address2;
                VM.Address3 = Vendor.Address3;
                VM.POBox = Vendor.POBox;
                VM.City = Vendor.City;
                VM.Region = Vendor.Region;
                VM.Country = Vendor.Country;
                VM.Contact = Vendor.Contact;
                VM.Phone = Vendor.Phone;
                VM.Fax = Vendor.Fax;
            }
            else
            {
                Vendor = new tbl_Vendor();
            }
            return PartialView("~/Views/Vendor/Partial/_VendorDetailsPartial.cshtml", VM);
        }
        public string InsertOrUpdateVendor(VendorModel VM)
        {
            tbl_Vendor Vendor = new tbl_Vendor();
            Vendor.VendorID = VM.VendorID;
            Vendor.Name1 = VM.Name1;
            Vendor.Address1 = VM.Address1;
            Vendor.Address2 = VM.Address2;
            Vendor.Address3 = VM.Address3;
            Vendor.POBox = VM.POBox;
            Vendor.Contact = VM.Contact;
            Vendor.Phone = VM.Phone;
            Vendor.Fax = VM.Fax;
            Vendor.Email = VM.Email;
            Vendor.City = VM.City;
            Vendor.Region = VM.Region;
            Vendor.Country = VM.Country;
            return VendorBL.InsertOrUpdate(VM);
        }
    }
}
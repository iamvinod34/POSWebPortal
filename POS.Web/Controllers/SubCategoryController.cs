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
    [Authorize]
    public class SubCategoryController : Controller
    {
        SubCategoryBL SubCategoryBL;
        public SubCategoryController()
        {
            SubCategoryBL = new SubCategoryBL();
        }
        // GET: SubCategory
        public ActionResult Index()
        {
            SubCategoryModel SCM = new SubCategoryModel();
            SCM = SubCategoryBL.SubCategoryM();
            return View(SCM);
        }
        /// <summary>
        /// Get Location details By ID -Srikanth
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        public PartialViewResult GetSubCategoryByID(string SubCategoryID)
        {
            SubCategoryModel SCM = new SubCategoryModel();
            tbl_SubCategory subcategory;
            SCM = SubCategoryBL.SubCategoryM();
            subcategory = SubCategoryBL.GetByID(SubCategoryID.Trim());

            if (subcategory == null)
            {
                subcategory = new tbl_SubCategory();
            }
            SCM.CategoryID = subcategory.CategoryID;
            SCM.SubCategoryID = subcategory.SubCategoryID;
            SCM.SubCategoryDesc = subcategory.SubCategoryDesc;
            return PartialView("~/Views/SubCategory/Partial/_SubCategoryDetailsPartial.cshtml", SCM);
        }
        public string InsertOrUpdateSubCategory(SubCategoryModel SCM)
        {
            tbl_SubCategory subcategory = new tbl_SubCategory();
            subcategory.CategoryID = SCM.CategoryID;
            subcategory.SubCategoryID = SCM.SubCategoryID;
            subcategory.SubCategoryDesc = SCM.SubCategoryDesc;
            return SubCategoryBL.InsertOrUpdate(SCM);
        }
    }
}
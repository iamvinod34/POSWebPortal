using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Util.Model;
using POS.Entity.Entities;
using POS.Business.BusinessComponents;

namespace POS.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryBL CategoryBL;
        public CategoryController()
        {
            CategoryBL = new CategoryBL();
        }
        // GET: Category
        public ActionResult Index()
        {
            CategoryModel CM = new CategoryModel();
            CM.Category = CategoryBL.GetCategoryAll().ToList();
            return View(CM);
        }
        /// <summary>
        /// Get Category details By ID -Vinod
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public PartialViewResult GetCategoryById(string CategoryID)
        {
            CategoryModel CM = new CategoryModel();
            tbl_Category category;
            category= CategoryBL.GetByID(CategoryID.Trim());

            if (category == null)
            {
                category = new tbl_Category();
            }
            CM.CategoryID = category.CategoryID;
            CM.CategoryDesc = category.CategoryDesc;

            return PartialView("~/Views/Category/Partial/_CategoryDetailsPartial.cshtml", CM);
        }
        public string InsertOrUpdateCategory(CategoryModel CM)
        {
            tbl_Category category= new tbl_Category();
            category.CategoryID = CM.CategoryID;
            category.CategoryDesc = CM.CategoryDesc;
            return CategoryBL.InsertOrUpdate(CM);
        }
    }
}
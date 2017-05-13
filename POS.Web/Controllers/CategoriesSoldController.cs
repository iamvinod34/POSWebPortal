using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace POS.Web.Controllers
{
    public class CategoriesSoldController : Controller
    {
        SalesBL salesBL = new SalesBL();
        public JsonResult ThisMonth()
        {
            List<CategoryData> lstCat = new List<CategoryData>();
            List<pxSelectCategoryPieChart_Result>  lstCategory = salesBL.GetCategoryPieChart();
            decimal? total = lstCategory.Sum(e => e.NetSales);
            foreach (pxSelectCategoryPieChart_Result item in lstCategory)
            {
                CategoryData cat = new CategoryData();
                cat.y = item.NetSales/total*100;
                cat.name = item.CategoryDesc + " (" + item.NetSales.Value.ToString("F") + ")";
                lstCat.Add(cat);
            }
            return Json(lstCat, JsonRequestBehavior.AllowGet);
        }
    }

    public class CategoryData
    {
        public decimal? y;
        public string name;
    }
}
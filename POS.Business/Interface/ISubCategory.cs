using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
   public interface ISubCategory
    {
        List<tbl_SubCategory> GetAll();

        List<tbl_SubCategory> GetById(string SubCategoryId);

        List<tbl_SubCategory> Insert(tbl_SubCategory subcategory);

        List<tbl_SubCategory> Update(tbl_SubCategory subcategory);
    }
}

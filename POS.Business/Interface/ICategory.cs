using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    public interface ICategory
    {
        List<tbl_Category> GetAll();
        List<tbl_Category> GetById(string CategoryId);
        string Insert(tbl_Category Categoty);

        string Update(tbl_Category Category);

        bool DeleteByID(int id);
    }
}

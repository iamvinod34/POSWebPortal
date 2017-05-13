using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    public interface IVendor
    {
        List<tbl_Vendor> GetAll();
        List<tbl_Vendor> GetById(string VendorId);
        string Insert(tbl_Vendor vendor);

        string Update(tbl_Vendor vendor);

        bool DeleteByID(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;


namespace POS.Business.Interface
{
    interface IPosUsers
    {
        tbl_Users insert(tbl_Users user);
        tbl_Users update(tbl_Users user);
        void DeleteById(string UserId, string LocationId);
        List<tbl_Users> GetAll();


    }
}

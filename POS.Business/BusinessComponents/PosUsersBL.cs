using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Business.Interface;
using POS.Entity.Entities;

namespace POS.Business.BusinessComponents
{
    public class PosUsersBL : IPosUsers
    {
        public void DeleteById(string UserId, string LocationId)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public tbl_Users insert(tbl_Users user)
        {
            throw new NotImplementedException();
        }

        public tbl_Users update(tbl_Users user)
        {
            throw new NotImplementedException();
        }
    }
}

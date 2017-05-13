using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Business.Interface;
using POS.Entity.Entities;
using POS.Util.Model;
using POS.Repository;
using POS.Repository.UnitOfWork;

namespace POS.Business.BusinessComponents
{
    public class CustomerBL : UserAuthenticationModel, ICustomer
    {
        Context Context;
        public CustomerBL()
        {
            Context = new Context();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Customer> GetAll()
        {
            List<tbl_Customer> lstCustomer = new List<tbl_Customer>();
            try
            {
               lstCustomer= Context.Customer.Get().ToList();
                return lstCustomer;
            }
            catch (Exception ex)
            {
              return  lstCustomer = null;
            }
        }

        public List<tbl_Customer> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public tbl_Customer Insert(tbl_Customer Customer)
        {
            throw new NotImplementedException();
        }

        public tbl_Customer Select(string Id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_PhoneCode> GetAllPhoneCode()
        {
            List<tbl_PhoneCode> lstPhoneCode = new List<tbl_PhoneCode>();
            try
            {
               lstPhoneCode= Context.PhoneCode.Get().ToList();
                return lstPhoneCode;
            }
            catch (Exception ex)
            {
                return lstPhoneCode = null;
            }
        }
    }
}

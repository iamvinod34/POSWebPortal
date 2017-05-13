using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    interface ICustomer
    {
        /// <summary>
        /// tbl_Customer Insert Method Inter Face
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        tbl_Customer Insert(tbl_Customer Customer);

        List<tbl_Customer> GetById(string Id);

        void Delete(string Id);

        List<tbl_Customer> GetAll();

        tbl_Customer Select(string Id);



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
namespace POS.Business.Interface
{
    public interface ICity
    {
        List<tbl_City> GetAll();

        List<tbl_City> GetById(string CityID);

        tbl_City Insert(tbl_City City);

        tbl_City Update(tbl_City UpdateCity);
    }
}

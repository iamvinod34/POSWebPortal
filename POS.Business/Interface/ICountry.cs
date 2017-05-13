using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
  public interface ICountry
    {
        List<tbl_Country> GetAll();

        List<tbl_Country> GetById(string CountryID);

        tbl_Country Insert(tbl_Country Country);

        tbl_Country Update(tbl_Country Country);
    }
}

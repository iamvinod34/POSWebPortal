using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
 public interface IRegion
    {
        List<tbl_Region> GetAll();

        List<tbl_Region> GetById(string RegionID);

        tbl_Region Insert(tbl_Region Region);

        tbl_Region Update(tbl_Region Region);
    }
}

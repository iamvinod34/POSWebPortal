using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
   public interface IEod
    {
        string Update(tbl_EOD Eod);

        List<tbl_EOD> GetAll();
    }
}

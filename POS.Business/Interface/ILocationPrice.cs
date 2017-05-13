using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
   public interface ILocationPrice
    {
        List<tbl_LocationPrice> GetAll();

        List<tbl_LocationPrice> GetById(string MaterialID);

        tbl_LocationPrice Insert(tbl_LocationPrice LocationPrice);

        tbl_LocationPrice Update(tbl_LocationPrice LocationPricec);
         
            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    
    ///Created by Srikanth Kotnala on 8/6/2016
    ///<summary>
    ///Interface for POS Location
    /// </summary>
    public interface ILocation
    {
        List<tbl_Location> GetAll();

        tbl_Location GetByID(string id);

        string Insert(tbl_Location location);

        string Update(tbl_Location location);

        bool DeleteByID(int id);

        bool DeleteByLocationDetails(tbl_Location location);
    }
}

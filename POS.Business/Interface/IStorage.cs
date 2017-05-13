using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    ///Created by Vinod Kumar on 16/08/2016
    ///<summary>
    ///Interface for POS Storage
    /// </summary>
    public interface IStorage
    {
        List<tbl_Storage> GetAll();

        List<tbl_Storage> GetByID(string locationid);

        string Insert(tbl_Storage storage);

        string Update(tbl_Storage storage);

        bool DeleteByID(int id);

        bool DeleteByLocationDetails(tbl_Storage storage);


    }
}

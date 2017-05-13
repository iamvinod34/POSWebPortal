using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    public interface IMaterial
    {
        List<tbl_Material> GetAll();

        List<tbl_Material> GetId(string MaterialID);

        string Insert(tbl_Material Material);

        string Update(tbl_Material Material);

        bool DeleteById(string MaterialID);
    }
}

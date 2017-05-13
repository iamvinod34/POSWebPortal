using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface
{
    /// <summary>
    /// Interface Terminal Class -Vinod
    /// </summary>
   public interface ITerminal
    {
        List<tbl_Terminal> GetAll();

        tbl_Terminal GetById(string LocationID);

        string Insert(tbl_Terminal Terminal);

        string Update(tbl_Terminal Terminal);

        bool DeleteById(string LocationID, string TerminalId);
    }
}

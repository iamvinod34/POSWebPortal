using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Repository.UnitOfWork;
using POS.Util.Model;

namespace POS.Business.BusinessComponents
{
    public class CashCollection : UserAuthenticationModel
    {
        Context Context;
        public CashCollection()
        {
            Context = new Context();
        }

        public List<Proc_CashCollection_Result> GetEodDetails(string LocationID,string FromDate,string ToDate)
        {
            List<Proc_CashCollection_Result> Proc_CashCollection_Result = new List<Entity.Entities.Proc_CashCollection_Result>();
            try
            {
                Proc_CashCollection_Result = Context.Proc_Cash_Collection(LocationID,FromDate,ToDate).ToList();
                return Proc_CashCollection_Result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public string UpdateCashCollection(string TextBoxVal,string EODIDVal)
        {
            string result = string.Empty;
            try
            {
                
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}

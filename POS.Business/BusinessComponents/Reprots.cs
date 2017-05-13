using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Business.Interface;
using POS.Repository.UnitOfWork;
using POS.Repository;
using POS.Util.Model;

namespace POS.Business.BusinessComponents
{
    
    public  class Reprots
    {
        Context Context = new Context();

        public List<Proc_REPORTProductionOrderStatus_Result> ProductioOrderStatusReport(string LocationID,DateTime? FromDate,DateTime? ToDate)
        {
            List<Proc_REPORTProductionOrderStatus_Result> ProductionOrderStatus = new List<Proc_REPORTProductionOrderStatus_Result>();
            try
            {
               
                ProductionOrderStatus = Context.ReportProductionOrderStatus(LocationID, FromDate, ToDate);
                return ProductionOrderStatus;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Proc_ProfitShortageReport_Result> ProfitShortageReport(string LocationID,DateTime? FromDate,DateTime? ToDate)
        {
            try
            {
                List<Proc_ProfitShortageReport_Result> ProfitShortage = new List<Proc_ProfitShortageReport_Result>();
                ProfitShortage= Context.ProfitShortageReport(LocationID, FromDate, ToDate);
                return ProfitShortage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}

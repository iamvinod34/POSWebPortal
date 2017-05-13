using POS.Business.Interface;
using POS.Entity.Entities;
using POS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Business.BusinessComponents
{
    public class EODBL : IEod    
    {
        Context Context;
        public EODBL()
        {
            Context = new Context();
        }

        public List<tbl_EOD> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<tbl_EOD> GetById(string id,string LocationID)
        {
            List<tbl_EOD> Eod;
            try
            {
                Eod = Context.EOD.Get(e => e.EODID == id && e.LocationID==LocationID).ToList();
                return Eod;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Update(tbl_EOD Eod)
        {
            string result = string.Empty;
            try
            {
                List<tbl_EOD> GetById = this.GetById(Eod.EODID, Eod.LocationID).ToList();
                if(GetById==null)
                {
                    return "Error";
                }
                else
                {

                    GetById.FirstOrDefault().EODID = Eod.EODID;
                    GetById.FirstOrDefault().LocationID = Eod.LocationID;
                    GetById.FirstOrDefault().Cash_Collection = Eod.Cash_Collection;
                    
                    Context.EOD.Update(GetById[0]);
                    Context.EOD.Save();
                    return Eod.EODID + " Cash Collection Updated Successfully!!";
                }
                
            }
            catch (Exception ex)
            {

                return "Error in update details, Please try again!!";
            }
        }
    }
}

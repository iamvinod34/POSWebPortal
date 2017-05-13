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
   public class ProductionOrder
    {
        Context Context;
        public ProductionOrder()
        {
            Context = new Context();
        }

        public List<Proc_MaterialBarcodeSearch_Result> GETBOMID(string matrialOrBarcode)
        {
            try
            {
                List<Proc_MaterialBarcodeSearch_Result> MaterialSearch = new List<Proc_MaterialBarcodeSearch_Result>();
                List<Proc_SearchBOMID_Result> BOMIDSearch = Context.SearchBOMID(matrialOrBarcode);
                foreach (Proc_SearchBOMID_Result item in BOMIDSearch)
                {
                    Proc_MaterialBarcodeSearch_Result MaterialSearchOne = new Proc_MaterialBarcodeSearch_Result();
                    MaterialSearchOne.MaterialID = item.BOMID;
                    MaterialSearchOne.MaterialEANUOM = item.UOM;
                    MaterialSearchOne.MaterialDesc1 = item.MaterialDesc1;
                    MaterialSearchOne.Price = 0;

                    MaterialSearch.Add(MaterialSearchOne);
                }
                return MaterialSearch;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

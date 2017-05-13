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
    public class TransferDisplayBL
    {
        Context Context = new Context();

        public TransferDisplayModel GetTransferDisplay()
        {
            TransferDisplayModel transferDisplayModel = new TransferDisplayModel();
            try
            {
                transferDisplayModel.Categories = Context.Category.Get().ToList();
                transferDisplayModel.TransferDocuments = Context.GetTransferDocument();
                return transferDisplayModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TransferDisplayModel GetPhysicalInventory()
        {
            TransferDisplayModel transferDisplayModel = new TransferDisplayModel();
            try
            {
                List<pxSelectTransferDocument_Result> lstPhysicalDocument = new List<pxSelectTransferDocument_Result>();
                List<pxSelectPhysicalDocument_Result> lstPhysicalDocuments = Context.GetPhysicalDocument();
                foreach (pxSelectPhysicalDocument_Result filter in lstPhysicalDocuments)
                {
                    pxSelectTransferDocument_Result PhysicalDocument = new pxSelectTransferDocument_Result();
                    PhysicalDocument.DocumentID = filter.DocumentID;
                    PhysicalDocument.Amount = filter.Amount;
                    PhysicalDocument.LocationDesc = filter.LocationDesc;
                   // PhysicalDocument.Name1 = filter.Name1;
                    PhysicalDocument.PostingDate = filter.PostingDate;
                    PhysicalDocument.UserID = filter.UserID;
                    lstPhysicalDocument.Add(PhysicalDocument);
                }
                transferDisplayModel.TransferDocuments = lstPhysicalDocument;
                transferDisplayModel.Categories = Context.Category.Get().ToList();

                return transferDisplayModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

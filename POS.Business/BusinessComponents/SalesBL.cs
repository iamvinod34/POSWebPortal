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
using System.IO;

namespace POS.Business.BusinessComponents
{
    public class SalesBL : ISales
    {
        Context Context = new Context();
        public SalesEnquiryModel GetEnquiries()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                salesModel.Categories = Context.Category.Get().ToList();
                salesModel.SalesEnquiries = Context.GetAllSalesEnquiry();
                return salesModel;
            }
            catch (Exception ex)
            {
                return salesModel;
            }
        }

        public List<tbl_SubCategory> SubCategoriesByID(string categoryID)
        {
            try
            {
                return Context.SubCategory.Get(e => e.CategoryID == categoryID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectDocumentMaterial_Result> GetDocumentMaterial(string docid)
        {
            try
            {
                return Context.GetDocumentMaterial(docid);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<pxSelectDocumentTender_Result> GetDocumentTender(string docid)
        {
            try
            {
                return Context.GetDocumentTender(docid);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<pxSelectSalesEnquiry_Result> Filter(SalesEnquiryModel sales)
        {
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                string[] amount = sales.Amount.Split('-');
                List<pxSelectFilterSalesEnquiry_Result> lstFilterSalesEnquiry = Context.FilterSalesEnquiry(sales.FromDate, sales.ToDate, sales.Terminal,sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(),sales.Location.Trim());
                foreach (pxSelectFilterSalesEnquiry_Result filter in lstFilterSalesEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.Name1;
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;
                    
                    lstSalesEnquiry.Add(salesEnquiry);
                }
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public SalesEnquiryModel GetSalesWithInvoice()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectReturnSalesWithInvoice_Result> lstSalesWithInvoice = Context.ReturnSalesWithInvoice();
                foreach (pxSelectReturnSalesWithInvoice_Result filter in lstSalesWithInvoice)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.Name1;
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                }
                salesModel.SalesEnquiries = lstSalesEnquiry;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectSalesEnquiry_Result> FilterReturnWithInvoice(SalesEnquiryModel sales)
        {
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                string[] amount = sales.Amount.Split('-');
                List<pxSelectFilterReturnWithInvoice_Result> lstFilterSalesEnquiry = Context.FilterReturnSalesWithInvoice(sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(),sales.Location);
                foreach (pxSelectFilterReturnWithInvoice_Result filter in lstFilterSalesEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.Name1;
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                }
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public SalesEnquiryModel GetSalesWithoutInvoice()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectReturnSalesWithoutInvoice_Result> lstSalesWithoutInvoice = Context.ReturnSalesWithoutInvoice();
                foreach (pxSelectReturnSalesWithoutInvoice_Result filter in lstSalesWithoutInvoice)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.Name1;
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                }
                salesModel.SalesEnquiries = lstSalesEnquiry;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectSalesEnquiry_Result> FilterReturnWithoutInvoice(SalesEnquiryModel sales)
        {
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                string[] amount = sales.Amount.Split('-');
                List<pxSelectFilterReturnWithoutInvoice_Result> lstFilterSalesEnquiry = Context.FilterReturnSalesWithoutInvoice(sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(),sales.Location);
                foreach (pxSelectFilterReturnWithoutInvoice_Result filter in lstFilterSalesEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.Name1;
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                }
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public SalesEnquiryModel GetAllSalesDelete()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectSalesDelete_Result> lstSalesWithoutInvoice = Context.GetAllSalesDelete();
                foreach (pxSelectSalesDelete_Result delete in lstSalesWithoutInvoice)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = delete.DocumentID;
                    salesEnquiry.Amount = delete.Amount;
                    salesEnquiry.LocationDesc = delete.LocationDesc;
                    salesEnquiry.Name1 = delete.Name1;
                    salesEnquiry.PostingDate = delete.AddDate;
                    salesEnquiry.UserID = delete.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                    salesEnquiry = null;
                }
                salesModel.SalesEnquiries = lstSalesEnquiry;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectSalesEnquiry_Result> FilterDeleteLineItems(SalesEnquiryModel sales)
        {
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                string[] amount = sales.Amount.Split('-');
                List<pxSelectFilterSalesDeleteLineItemsEnquiry_Result> lstFilterSalesEnquiry = Context.SelectFilterDeleteLineITems(sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(), sales.Location);
                foreach (pxSelectFilterSalesDeleteLineItemsEnquiry_Result filter in lstFilterSalesEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = "Walkin";
                    salesEnquiry.PostingDate = filter.AddDate;
                    salesEnquiry.UserID = filter.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                }
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<pxSelectDocumentMaterial_Result> GetDeletedDocumentMaterial(string docid)
        {
            try
            {
                List<pxSelectDeleteDocumentMaterial_Result> lstDeleteMaterial = Context.GetDeletedDocumentMaterial(docid);
                List<pxSelectDocumentMaterial_Result> lstDeleteSalesViewModel = new List<pxSelectDocumentMaterial_Result>();
                foreach (pxSelectDeleteDocumentMaterial_Result deletedItem in lstDeleteMaterial)
                {
                    pxSelectDocumentMaterial_Result DeleteSalesViewModel = new pxSelectDocumentMaterial_Result();
                    DeleteSalesViewModel.Amount = deletedItem.Amount;
                    DeleteSalesViewModel.CategoryDesc = deletedItem.CategoryDesc;
                    DeleteSalesViewModel.MaterialDesc1 = deletedItem.MaterialDesc1;
                    DeleteSalesViewModel.MaterialID = deletedItem.MaterialID;
                    DeleteSalesViewModel.TranQty = deletedItem.TranQty;
                    DeleteSalesViewModel.UOM = deletedItem.UOM;
                    lstDeleteSalesViewModel.Add(DeleteSalesViewModel);
                }
                return lstDeleteSalesViewModel;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<pxSelectDocumentTender_Result> GetDeletedDocumentTender(string docid)
        {
            try
            {
                List<pxSelectDeleteDocumentTender_Result> lstDeletedTender = Context.GetDeletedDocumentTender(docid);
                List<pxSelectDocumentTender_Result> lstDeletedTenderViewModel = new List<pxSelectDocumentTender_Result>();
                foreach (pxSelectDeleteDocumentTender_Result DeletedTender in lstDeletedTender)
                {
                    pxSelectDocumentTender_Result DeletedTenderViewModel = new pxSelectDocumentTender_Result();
                    DeletedTenderViewModel.Amount = DeletedTender.Amount;
                    DeletedTenderViewModel.ChangeAmount = DeletedTender.ChangeAmount;
                    DeletedTenderViewModel.PaidAmount = DeletedTender.PaidAmount;
                    DeletedTenderViewModel.TenderName = DeletedTender.TenderName;
                    DeletedTenderViewModel.TransCode = DeletedTender.TransCode;
                    lstDeletedTenderViewModel.Add(DeletedTenderViewModel);
                }
                return lstDeletedTenderViewModel;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public SalesEnquiryModel GetAllSalesUnhold()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectSalesUnHoldEnquiry_Result> lstSalesUnhold = Context.GetAllSalesUnhold();
                foreach (pxSelectSalesUnHoldEnquiry_Result unhold in lstSalesUnhold)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = unhold.DocumentID;
                    salesEnquiry.Amount = Convert.ToDecimal(unhold.Amount);
                    salesEnquiry.LocationDesc = unhold.LocationDesc;
                    salesEnquiry.Name1 = unhold.Name1;
                    salesEnquiry.PostingDate = unhold.DocDate;
                    salesEnquiry.UserID = unhold.UserID;
                    lstSalesEnquiry.Add(salesEnquiry);
                    salesEnquiry = null;
                }
                salesModel.SalesEnquiries = lstSalesEnquiry;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectCategoryPieChart_Result> GetCategoryPieChart()
        {
            try
            {
                return Context.GetCategoryPieChart();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<pxSelectLatestSalesDetails_Result> GetLatestSalesDetails()
        {
            try
            {
                return Context.GetLatestSalesDetails();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public SalesEnquiryModel GetPOReieve()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstPORecieveViewModel = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectPORecieve_Result> lstPORecieve = Context.GetPORecieve();
                foreach (pxSelectPORecieve_Result PORecieve in lstPORecieve)
                {
                    pxSelectSalesEnquiry_Result PORecieveViewModel = new pxSelectSalesEnquiry_Result();
                    PORecieveViewModel.DocumentID = PORecieve.DocumentID;
                    PORecieveViewModel.Amount = Convert.ToDecimal(PORecieve.Amount);
                    PORecieveViewModel.LocationDesc = PORecieve.LocationDesc;
                    PORecieveViewModel.Name1 = PORecieve.Name1;
                    PORecieveViewModel.PostingDate = PORecieve.DocumentDate;
                    PORecieveViewModel.UserID = PORecieve.UserID;
                    lstPORecieveViewModel.Add(PORecieveViewModel);
                    PORecieveViewModel = null;
                }
                salesModel.SalesEnquiries = lstPORecieveViewModel;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SalesEnquiryModel GetReturnToSupplier()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstReturnToSupplierViewModel = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectReturnToSupplier_Result> lstReturnToSupplier = Context.GetReturnToSupplier();
                foreach (pxSelectReturnToSupplier_Result ReturnToSupplier in lstReturnToSupplier)
                {
                    pxSelectSalesEnquiry_Result PORecieveViewModel = new pxSelectSalesEnquiry_Result();
                    PORecieveViewModel.DocumentID = ReturnToSupplier.DocumentID;
                    PORecieveViewModel.Amount = Convert.ToDecimal(ReturnToSupplier.Amount);
                    PORecieveViewModel.LocationDesc = ReturnToSupplier.LocationDesc;
                    PORecieveViewModel.Name1 = ReturnToSupplier.Name1;
                    PORecieveViewModel.PostingDate = ReturnToSupplier.DocumentDate;
                    PORecieveViewModel.UserID = ReturnToSupplier.UserID;
                    lstReturnToSupplierViewModel.Add(PORecieveViewModel);
                    PORecieveViewModel = null;
                }
                salesModel.SalesEnquiries = lstReturnToSupplierViewModel;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectDocumentMaterial_Result> GetPORecieveMaterial(string docid,string FilterName)
        {
            try
            {
                List<pxSelectPORecieveMaterial_Result> lstDeleteMaterial = Context.GetPORecieveMaterial(docid, FilterName);
                List<pxSelectDocumentMaterial_Result> lstDeleteSalesViewModel = new List<pxSelectDocumentMaterial_Result>();
                foreach (pxSelectPORecieveMaterial_Result deletedItem in lstDeleteMaterial)
                {
                    pxSelectDocumentMaterial_Result DeleteSalesViewModel = new pxSelectDocumentMaterial_Result();
                    DeleteSalesViewModel.Amount = deletedItem.Amount;
                    DeleteSalesViewModel.CategoryDesc = deletedItem.CategoryDesc;
                    DeleteSalesViewModel.MaterialDesc1 = deletedItem.MaterialDesc1;
                    DeleteSalesViewModel.MaterialID = deletedItem.MaterialID;
                    DeleteSalesViewModel.TranQty = deletedItem.TranQty;
                    DeleteSalesViewModel.UOM = deletedItem.UOM;
                    lstDeleteSalesViewModel.Add(DeleteSalesViewModel);
                }
                return lstDeleteSalesViewModel;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<pxSelectSalesEnquiry_Result> POFilter(SalesEnquiryModel sales)
        {
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                string[] amount = sales.Amount.Split('-');
                List<Proc_FilterPOReceive_Result> lstFilterSalesEnquiry = Context.Proc_FilterPOReceive(sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(), sales.Location);
                foreach (Proc_FilterPOReceive_Result filter in lstFilterSalesEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.UserID;
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;

                    lstSalesEnquiry.Add(salesEnquiry);
                }
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<pxSelectSalesEnquiry_Result> FilterReturnTrafterPhysical(SalesEnquiryModel sales,string filterName)
        {
            string[] amount=new string[2];
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                if(sales.Amount!=null)
                {
                    amount = sales.Amount.Split('-');
                }
                else
                {
                    amount[0] = "0";
                    amount[1] = "100000";
                }
                
                List<Proc_FilterReturnORTransferORPhysicalORTransInORTransOUT_Result> lstFilterEnquiry = Context.Proc_FilterReturnORTransferORPhysical(filterName, sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(), sales.Location);
                foreach (Proc_FilterReturnORTransferORPhysicalORTransInORTransOUT_Result filter in lstFilterEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = filter.Amount;
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = "Doc";
                    salesEnquiry.PostingDate = filter.PostingDate;
                    salesEnquiry.UserID = filter.UserID;

                    lstSalesEnquiry.Add(salesEnquiry);
                   
                }
                lstFilterEnquiry = null;
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SalesEnquiryModel GetTransfterToDisplay()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstTranfterToDisplayViewModel = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectTransferDocument_Result> lstTransfterToDisplay = Context.GetTransferDocument();
                foreach (pxSelectTransferDocument_Result transfterToDisplay in lstTransfterToDisplay)
                {
                    pxSelectSalesEnquiry_Result PORecieveViewModel = new pxSelectSalesEnquiry_Result();
                    PORecieveViewModel.DocumentID = transfterToDisplay.DocumentID;
                    PORecieveViewModel.Amount = Convert.ToDecimal(transfterToDisplay.Amount);
                    PORecieveViewModel.LocationDesc = transfterToDisplay.LocationDesc;
                    PORecieveViewModel.Name1 = "";
                    PORecieveViewModel.PostingDate = transfterToDisplay.PostingDate;
                    PORecieveViewModel.UserID = transfterToDisplay.UserID;
                    lstTranfterToDisplayViewModel.Add(PORecieveViewModel);
                    PORecieveViewModel = null;
                }
                salesModel.SalesEnquiries = lstTranfterToDisplayViewModel;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SalesEnquiryModel GetPhysicalInventory()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstPhysicalInventoryViewModel = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectPhysicalDocument_Result> lstPhysicalInventory= Context.GetPhysicalDocument();
                foreach (pxSelectPhysicalDocument_Result physicalinventory in lstPhysicalInventory)
                {
                    pxSelectSalesEnquiry_Result PORecieveViewModel = new pxSelectSalesEnquiry_Result();
                    PORecieveViewModel.DocumentID = physicalinventory.DocumentID;
                    PORecieveViewModel.Amount = Convert.ToDecimal(physicalinventory.Amount);
                    PORecieveViewModel.LocationDesc = physicalinventory.LocationDesc;
                    PORecieveViewModel.Name1 = "";
                    PORecieveViewModel.PostingDate = physicalinventory.PostingDate;
                    PORecieveViewModel.UserID = physicalinventory.UserID;
                    lstPhysicalInventoryViewModel.Add(PORecieveViewModel);
                    PORecieveViewModel = null;
                }
                salesModel.SalesEnquiries = lstPhysicalInventoryViewModel;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SalesEnquiryModel GetTransfterIN()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstPhysicalInventoryViewModel = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectTransfterIN_Result> lstPhysicalInventory = Context.SelectTransfterIN();
                foreach (pxSelectTransfterIN_Result physicalinventory in lstPhysicalInventory)
                {
                    pxSelectSalesEnquiry_Result PORecieveViewModel = new pxSelectSalesEnquiry_Result();
                    PORecieveViewModel.DocumentID = physicalinventory.DocumentID;
                    PORecieveViewModel.Amount = Convert.ToDecimal(physicalinventory.Amount);
                    PORecieveViewModel.LocationDesc = physicalinventory.LocationDesc;
                    PORecieveViewModel.Name1 = "";
                    PORecieveViewModel.PostingDate = physicalinventory.DocumentDate;
                    PORecieveViewModel.UserID = physicalinventory.UserID;
                    lstPhysicalInventoryViewModel.Add(PORecieveViewModel);
                    PORecieveViewModel = null;
                }
                salesModel.SalesEnquiries = lstPhysicalInventoryViewModel;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SalesEnquiryModel GetTransfterOUT()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectSalesEnquiry_Result> lstPhysicalInventoryViewModel = new List<pxSelectSalesEnquiry_Result>();
                List<pxSelectTransfterOUT_Result> lstPhysicalInventory = Context.SelectTransfterOUT();
                foreach (pxSelectTransfterOUT_Result physicalinventory in lstPhysicalInventory)
                {
                    pxSelectSalesEnquiry_Result PORecieveViewModel = new pxSelectSalesEnquiry_Result();
                    PORecieveViewModel.DocumentID = physicalinventory.DocumentID;
                    PORecieveViewModel.Amount = Convert.ToDecimal(physicalinventory.Amount);
                    PORecieveViewModel.LocationDesc = physicalinventory.LocationDesc;
                    PORecieveViewModel.Name1 = "";
                    PORecieveViewModel.PostingDate = physicalinventory.DocumentDate;
                    PORecieveViewModel.UserID = physicalinventory.UserID;
                    lstPhysicalInventoryViewModel.Add(PORecieveViewModel);
                    PORecieveViewModel = null;
                }
                salesModel.SalesEnquiries = lstPhysicalInventoryViewModel;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Proc_DocumentdetailsTenderDetails_Result> PrintDocTenderDetails(string DocumentID)
        {
            List<Proc_DocumentdetailsTenderDetails_Result> DocumentDetailsTenderDetails = new List<Proc_DocumentdetailsTenderDetails_Result>();
            try
            {
                DocumentDetailsTenderDetails = Context.DocumentdetailsTenderDetails(DocumentID);
            }
            catch(Exception ex)
            {

            }
            return DocumentDetailsTenderDetails;
        }

        public List<Proc_AllDocumentPrint_Result> PrintallDocuments(string DocumentID,string FilterName)
        {
            List<Proc_AllDocumentPrint_Result> DocumentDetails = new List<Proc_AllDocumentPrint_Result>();
            try
            {
                DocumentDetails = Context.AllDocumentPrint(DocumentID, FilterName);
            }
            catch (Exception ex)
            {

            }
            return DocumentDetails;
        }

        public List<pxSelectSalesEnquiry_Result> FilterUnHold(SalesEnquiryModel sales)
        {
            try
            {
                List<pxSelectSalesEnquiry_Result> lstSalesEnquiry = new List<pxSelectSalesEnquiry_Result>();
                string[] amount = sales.Amount.Split('-');
                List<pxSelectFilterSalesUnHoldEnquiry_Result> lstFilterSalesEnquiry = Context.FilterSalesUnHoldEnquiry(sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(), sales.Location.Trim());
                foreach (pxSelectFilterSalesUnHoldEnquiry_Result filter in lstFilterSalesEnquiry)
                {
                    pxSelectSalesEnquiry_Result salesEnquiry = new pxSelectSalesEnquiry_Result();
                    salesEnquiry.DocumentID = filter.DocumentID;
                    salesEnquiry.Amount = Convert.ToDecimal(filter.Amount);
                    salesEnquiry.LocationDesc = filter.LocationDesc;
                    salesEnquiry.Name1 = filter.Name1;
                    salesEnquiry.PostingDate = filter.DocDate;
                    salesEnquiry.UserID = filter.UserID;

                    lstSalesEnquiry.Add(salesEnquiry);
                }
                return lstSalesEnquiry;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public SalesEnquiryModel GetEODEnquiries()
        {
            SalesEnquiryModel salesModel = new SalesEnquiryModel();
            try
            {
                List<pxSelectFilterEodEnquiry_Result> lstSalesEnquiry = new List<pxSelectFilterEodEnquiry_Result>();
                List<Proc_SelectEODEnquiry_Result> lstSalesUnhold = Context.Proc_SelectEODEnquiry();
                foreach (Proc_SelectEODEnquiry_Result unhold in lstSalesUnhold)
                {
                    pxSelectFilterEodEnquiry_Result salesEnquiry = new pxSelectFilterEodEnquiry_Result();
                    salesEnquiry.EODID = unhold.EODID;
                    salesEnquiry.LocationDesc = unhold.LocationDesc;
                    salesEnquiry.DocDate = unhold.DocDate;
                    salesEnquiry.C_1 = unhold.C_1;
                    salesEnquiry.C_5 = unhold.C_5;
                    salesEnquiry.C_10 = unhold.C_10;
                    salesEnquiry.C_20 = unhold.C_20;
                    salesEnquiry.C_50 = unhold.C_50;
                    salesEnquiry.C_100 = unhold.C_100;
                    salesEnquiry.C_200 = unhold.C_200;
                    salesEnquiry.C_500 = unhold.C_500;
                    salesEnquiry.Loan = unhold.Loan;
                    salesEnquiry.SystemCash = unhold.SystemCash;
                    salesEnquiry.ActualCash = unhold.ActualCash;
                    salesEnquiry.CreditAmt = unhold.CreditAmt;
                    salesEnquiry.DebitAmt = unhold.DebitAmt;
                    salesEnquiry.OnAccAmt = unhold.OnAccAmt;
                    salesEnquiry.Amount = Convert.ToDecimal(unhold.Amount);
                    lstSalesEnquiry.Add(salesEnquiry);
                    salesEnquiry = null;
                }
                salesModel.EODEnquiries = lstSalesEnquiry;
                salesModel.Categories = Context.Category.Get().ToList();

                return salesModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<pxSelectFilterEodEnquiry_Result> FilerEod(SalesEnquiryModel sales, string filterName)
        {
            string[] amount = new string[2];
            try
            {
                if (sales.Amount != null)
                {
                    amount = sales.Amount.Split('-');
                }
                else
                {
                    amount[0] = "0";
                    amount[1] = "100000";
                }

                List<pxSelectFilterEodEnquiry_Result> lstFilterEnquiry = Context.selectFilterEOd(sales.FromDate, sales.ToDate, sales.Terminal, sales.Material, sales.EAN, sales.SelectedCategory, sales.SelectedSubCategory, sales.User, amount[0].Trim(), amount[1].Trim(), sales.Location);
                SalesEnquiryModel SalesEnquiryModel = new SalesEnquiryModel();
                SalesEnquiryModel.EODEnquiries = lstFilterEnquiry;
                return SalesEnquiryModel.EODEnquiries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] GetEodFile(string EODID)
        {
            try
            {
                List<Proc_EodByIdFile_Result> EODIDFile= Context.GetByIDFile(EODID).ToList();
                return EODIDFile.FirstOrDefault().FileByte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Business.Interface;
using POS.Repository.UnitOfWork;
using POS.Repository;
using POS.Util.Model;
using System;


namespace POS.Business.BusinessComponents
{
    ///Created by Srikanth Kotnala on 09/30/2016
    ///<summary>
    ///Business logic for Transactions 
    /// </summary>
    public class TransactionBL
    {
        LocationBL LocationBL = new LocationBL();


        Context Context;
        public TransactionBL()
        {
            Context = new Context();
        }

        public List<string> GetPOByLocation(string locationID)
        {
            List<string> lstPONumbers = Context.PurchaseOrder.Get(e => e.LocationID == locationID && e.POStatus == "Open").Select(a => a.DocumentID).ToList();
            return lstPONumbers;
        }

        public List<string> GetTIByLocation(string locationID)
        {
            List<string> lstPONumbers = Context.TransfterOUT.Get(e => e.LocationID == locationID && e.TO_Status == "Open").Select(a => a.DocumentID).ToList();
            return lstPONumbers;
        }

        public tbl_PurchaseOrder GetOrderByDocID(string docid)
        {
            tbl_PurchaseOrder PO = Context.PurchaseOrder.Get(e => e.DocumentID == docid).FirstOrDefault();
            return PO;
        }

        public tbl_TransferOut GetTIOrderByDocID(string docid)
        {
            tbl_TransferOut PO = Context.TransfterOUT.Get(e => e.DocumentID == docid).FirstOrDefault();
            return PO;
        }

        public List<pxSelectPurchaseOrderDetailByDocId_Result> GetPODetail(string docid)
        {
            return Context.GetPurchaseOrderDetailByDocId(docid);
        }

        public List<pxSelectPurchaseOrderDetailByDocId_Result> GetTIDetail(string docid)
        {
            try
            {
                List<pxSelectPurchaseOrderDetailByDocId_Result> List = new List<pxSelectPurchaseOrderDetailByDocId_Result>();
                List<pxSelectTranfterOUTDetailByDocId_Result> Details = Context.GetTIGetDocById(docid);
                foreach (pxSelectTranfterOUTDetailByDocId_Result item in Details)
                {
                    pxSelectPurchaseOrderDetailByDocId_Result ObjPuchageOrder = new pxSelectPurchaseOrderDetailByDocId_Result();
                    ObjPuchageOrder.DocumentID = item.DocumentID;
                    ObjPuchageOrder.MaterialDesc1 = item.MaterialDesc1;
                    ObjPuchageOrder.MaterialID = item.MaterialID;
                    ObjPuchageOrder.StorageID = item.StorageID;
                    ObjPuchageOrder.TranQty = item.TranQty;
                    ObjPuchageOrder.UOM = item.UOM;

                    List.Add(ObjPuchageOrder);
                }
                Details = null;
                return List;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
          
        }

        public void AcceptPO(Dictionary<string, string> dictPO, string docid)
        {
            tbl_PurchaseOrder PO = Context.PurchaseOrder.Get(e => e.DocumentID == docid && e.POStatus == "Open").FirstOrDefault();
            List<tbl_PurchaseOrder_Detail> lstPODetail = Context.PurchaseOrderDetail.Get(e => e.DocumentID == docid).ToList();
            bool isChanged = false;

            tbl_StockReceive stockRecieve = new tbl_StockReceive();
            stockRecieve.DocumentID = docid;
            stockRecieve.PONumber = docid;
            stockRecieve.CompanyID = PO.CompanyID;
            stockRecieve.LocationID = PO.LocationID;
            stockRecieve.StorageID = PO.StorageID;
            stockRecieve.DocumentDate = PO.DocumentDate;
            stockRecieve.PostingDate = PO.PostingDate;
            stockRecieve.VendorID = PO.VendorID;
            stockRecieve.Amount = PO.Amount;
            stockRecieve.Discount = PO.Discount;
            stockRecieve.NetValue = PO.NetValue;
            stockRecieve.UserID = PO.UserID;
            stockRecieve.AddDate = PO.AddDate;
            stockRecieve.Dataid = PO.Dataid;
            Context.StockReceive.Insert(stockRecieve);
            Context.StockReceive.Save();

            foreach (tbl_PurchaseOrder_Detail POD in lstPODetail)
            {
                decimal qty = Convert.ToDecimal(dictPO[POD.MaterialID]);
                if (POD.TranQty != qty)
                {
                    isChanged = true;
                }
                tbl_StockReceive_Detail srd = new tbl_StockReceive_Detail();
                srd.DocumentID = POD.DocumentID;
                srd.CompanyID = POD.CompanyID;
                srd.LocationID = POD.LocationID;
                srd.StorageID = POD.StorageID;
                srd.DocumentDate = POD.DocumentDate;
                srd.PostingType = POD.PostingType;
                srd.PostingDate = POD.PostingDate;
                srd.VendorID = POD.VendorID;
                srd.Counter = POD.Counter;
                srd.CategoryID = POD.CategoryID;
                srd.MaterialID = POD.MaterialID;
                srd.UOM = POD.UOM;
                srd.TranQty = qty;
                srd.BaseQty = qty;
                srd.CreditQty = POD.CreditQty;
                srd.Cost = POD.Cost;
                srd.DiscountRate = POD.DiscountRate;
                srd.Amount = POD.Amount;
                srd.CreditAmount = POD.CreditAmount;
                srd.UserID = POD.UserID;
                srd.PostKey = POD.PostKey;
                srd.AddDate = DateTime.Now;
                srd.UpdDate = DateTime.Now;
                srd.Dataid = POD.Dataid;
                srd.OrderQty = qty;
                Context.StockReceiveDetail.Insert(srd);
            }
            Context.StockReceiveDetail.Save();
            if (isChanged)
            {
                PO.POStatus = "Pending";
            }
            else
            {
                PO.POStatus = "Complete";
            }

            Context.PurchaseOrder.Update(PO);
            Context.PurchaseOrder.Save();
        }

        public List<Proc_MaterialBarcodeSearch_Result> GetReturnToSupplierMaterial(string MatrialOrBarcode, string VendorID,string PageName)
        {
            return Context.GetReturnToSupplierMaterial(MatrialOrBarcode, VendorID,PageName).ToList();
        }

        public List<Proc_SearchEAN_Result> GetProc_SearchEAN(string EAN13, string UOM, string VendorID,string PageName)
        {
            return Context.GetProc_SearchEAN(EAN13, UOM, VendorID,PageName).ToList();
        }

        public void AcceptReturnToSupplier(string LocationID, string VendorID, string StorageID, string DocID)
        {
            try
            {
                List<tbl_Company> Company = Context.Company.Get().ToList();
                string CompanyID = Company.FirstOrDefault().CompanyID;

                tbl_StockReceive stockRecieve = new tbl_StockReceive();
                int Increment = Convert.ToInt32(DocID) + 1;
                stockRecieve.DocumentID = LocationID + Increment;
                stockRecieve.PONumber = LocationID + Increment;
                stockRecieve.CompanyID = CompanyID;
                stockRecieve.LocationID = LocationID;
                stockRecieve.StorageID = StorageID;
                stockRecieve.DocumentDate = DateTime.Now;
                stockRecieve.PostingDate = DateTime.Now;
                stockRecieve.VendorID = VendorID;
                stockRecieve.Amount = 0.00M;
                stockRecieve.Discount = 0.00M;
                stockRecieve.NetValue = 0.00M;
                stockRecieve.UserID = "Vinod";
                stockRecieve.AddDate = DateTime.Now;
                Context.StockReceive.Insert(stockRecieve);
                Context.StockReceive.Save();
                DocID = null;
            }
            catch (Exception ex)
            {

            }

        }

        //public void ReturnToSupplierDetails(string LocationID, string VendorID, string StorageID, string DocID, decimal? Quantity, string MaterialID, string UOM)
        //{
        //    try
        //    {
        //        int Increment = Convert.ToInt32(DocID) + 1;
        //        string DocumentID = LocationID + Increment;
        //        Context.Proc_InsertRetunToSupplier(DocumentID, LocationID, MaterialID, UOM, "VInod", StorageID, VendorID, Quantity ?? 0);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public void UpdateDocId(tbl_Location Location)
        {
            Context.Location.Update(Location);
            Context.Location.Save();
        }

        public List<Proc_MaterialCategorySearch_Result> Proc_MaterialCategorySearch(string CategoryText, string MaterialID, string CategoryID)
        {
            return Context.Proc_MaterialCategorySearch(CategoryText, MaterialID, CategoryID);
        }

        public void AcceptTI(Dictionary<string, string> dictPO, string docid)
        {
            tbl_TransferOut PO = Context.TransfterOUT.Get(e => e.DocumentID == docid && e.TO_Status == "Open").FirstOrDefault();
            List<tbl_TransferOut_Detail> lstPODetail = Context.TransfterOUTDetails.Get(e => e.DocumentID == docid).ToList();
            bool isChanged = false;

            tbl_TransferIN stockRecieve = new tbl_TransferIN();
            stockRecieve.DocumentID = docid;
            stockRecieve.PONumber = docid;
            stockRecieve.CompanyID = PO.CompanyID;
            stockRecieve.LocationID = PO.LocationID;
            stockRecieve.StorageID = PO.StorageID;
            stockRecieve.DocumentDate = PO.DocumentDate;
            stockRecieve.PostingDate = PO.PostingDate;
            stockRecieve.VendorID = PO.VendorID;
            stockRecieve.Amount = PO.Amount;
            stockRecieve.Discount = PO.Discount;
            stockRecieve.NetValue = PO.NetValue;
            stockRecieve.UserID = PO.UserID;
            stockRecieve.AddDate = PO.AddDate;
            stockRecieve.Dataid = PO.Dataid;
            Context.TransfterIN.Insert(stockRecieve);
            Context.TransfterIN.Save();

            foreach (tbl_TransferOut_Detail POD in lstPODetail)
            {
                decimal qty = Convert.ToDecimal(dictPO[POD.MaterialID]);
                if (POD.TranQty != qty)
                {
                    isChanged = true;
                }
                tbl_TransferIN_Detail srd = new tbl_TransferIN_Detail();
                srd.DocumentID = POD.DocumentID;
                srd.CompanyID = POD.CompanyID;
                srd.LocationID = POD.LocationID;
                srd.StorageID = POD.StorageID;
                srd.DocumentDate = POD.DocumentDate;
                srd.PostingType = POD.PostingType;
                srd.PostingDate = POD.PostingDate;
                srd.VendorID = POD.VendorID;
                srd.Counter = POD.Counter;
                srd.CategoryID = POD.CategoryID;
                srd.MaterialID = POD.MaterialID;
                srd.UOM = POD.UOM;
                srd.TranQty = qty;
                srd.BaseQty = qty;
                srd.CreditQty = POD.CreditQty;
                srd.Cost = POD.Cost;
                srd.DiscountRate = POD.DiscountRate;
                srd.Amount = POD.Amount;
                srd.CreditAmount = POD.CreditAmount;
                srd.UserID = POD.UserID;
                srd.PostKey = POD.PostKey;
                srd.AddDate = DateTime.Now;
                srd.UpdDate = DateTime.Now;
                srd.Dataid = POD.Dataid;
                srd.OrderQty = qty.ToString();
                Context.TransfterINDetails.Insert(srd);
            }
            Context.TransfterINDetails.Save();
            if (isChanged)
            {
                PO.TO_Status = "Pending";
            }
            else
            {
                PO.TO_Status = "Complete";
            }

            Context.TransfterOUT.Update(PO);
            Context.TransfterOUT.Save();
        }


    }
}

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

    public class TempStorage
    {
        LocationBL LocationBL = new LocationBL();
        Context Context;
        public TempStorage()
        {
            Context = new Context();
        }

        public int StoreTempPhysicalInventory(tbl_TempMaster tempMaster, tbl_TempDetail tempDetail)
        {
            try
            {
                if (tempMaster.TempMasterID == 0)
                {
                    Context.TempMaster.Insert(tempMaster);
                    Context.TempMaster.Save();
                }

                if (tempMaster.TempMasterID != 0)
                {
                    Context.TempDetail.Insert(tempDetail);
                    Context.TempDetail.Save();
                }
                return tempMaster.TempMasterID;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public string InsertTempMater(string MaterialID, string UOM, string Qty, string LocationID, string StorageID, string Radio, string CategoryID,string UserName)
        {
            tbl_Location Location = LocationBL.GetByID(LocationID.Trim());
            int Docid = Convert.ToInt32(Location.PhyCount);
            int cnt = Docid + 1;
            string DocumentID = (LocationID + cnt).ToString().Trim();
            List<tbl_Company> Company = Context.Company.Get().ToList();
            string CompanyID = Company.FirstOrDefault().CompanyID;

            string TempMasterID = null;
            try
            {
                tbl_TempMaster TempMasterHeader = new tbl_TempMaster();

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                else
                {
                    TempMasterHeader = new tbl_TempMaster();
                }

                if (TempMasterID == string.Empty || TempMasterID == null)
                {
                    TempMasterHeader.DocumentID = DocumentID;
                    TempMasterHeader.PONumber = DocumentID;
                    TempMasterHeader.AddDate = DateTime.Now;
                    TempMasterHeader.CompanyID = CompanyID;
                    TempMasterHeader.DocumentDate = DateTime.Now;
                    TempMasterHeader.Filter = Radio;
                    TempMasterHeader.Filter_Id = CategoryID;
                    TempMasterHeader.LocationID = LocationID;
                    TempMasterHeader.PostingDate = DateTime.Now;
                    TempMasterHeader.StorageID = StorageID;
                    TempMasterHeader.Type = "TPI";
                    TempMasterHeader.UserID = UserName;
                    Context.TempMaster.Insert(TempMasterHeader);
                    Context.TempMaster.Save();
                }

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }

                tbl_TempDetail TempDetail = new tbl_TempDetail();
                TempDetail.MaterialID = MaterialID;
                TempDetail.UOM = UOM;
                TempDetail.AddDate = DateTime.Now;
                TempDetail.BaseQty = Convert.ToDecimal(Qty);
                TempDetail.CategoryID = CategoryID;
                TempDetail.CompanyID = CompanyID;
                TempDetail.DocumentDate = DateTime.Now;
                TempDetail.DocumentID = DocumentID;
                TempDetail.LocationID = LocationID;
                TempDetail.PostingDate = DateTime.Now;
                TempDetail.StorageID = StorageID;
                TempDetail.TranQty = Convert.ToDecimal(Qty);
                TempDetail.UpdDate = DateTime.Now;
                TempDetail.UserID = UserName;
                TempDetail.TempMasterID = Convert.ToInt32(TempMasterID);
                TempDetail.CreditQty = 0.00M;
                TempDetail.Cost = 0.00M;
                TempDetail.DiscountRate = 0.00M;
                TempDetail.Amount = 0.00M;
                TempDetail.CreditAmount = 0.00M;
                TempDetail.OrderQty = 0.00M;
                TempDetail.Type = "TPI";

                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e=>e.LocationID == LocationID && e.MaterialID == MaterialID && e.UOM == UOM).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    TempDetail = CheckTempDetails.FirstOrDefault();
                    TempDetail.TranQty = Convert.ToDecimal(Qty) + CheckTempDetails.FirstOrDefault().TranQty;
                    TempDetail.BaseQty = TempDetail.TranQty;

                    Context.TempDetail.Update(TempDetail);
                    Context.tempDetail.Save();
                }
                else
                {
                    Context.TempDetail.Insert(TempDetail);
                    Context.TempDetail.Save();
                }

            }
            catch (Exception ex)
            {

            }
            return TempMasterID;
        }

        public string DeleteRow(string MaterialID, string UOM, string Qty, string LocationID)
        {
            try
            {
                string result = null;
                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e => e.MaterialID == MaterialID && e.UOM == UOM && e.LocationID == LocationID).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    decimal Qtyval = Convert.ToDecimal(Qty);
                    decimal CheckTempDetailsQty = Convert.ToDecimal(CheckTempDetails.FirstOrDefault().TranQty);
                    if (Qtyval < CheckTempDetailsQty)
                    {
                        tbl_TempDetail TempDetail = new tbl_TempDetail();
                        TempDetail = CheckTempDetails.FirstOrDefault();
                        TempDetail.TranQty = CheckTempDetailsQty - Qtyval;
                        TempDetail.BaseQty = CheckTempDetailsQty - Qtyval;

                        Context.TempDetail.Update(TempDetail);
                        Context.TempDetail.Save();
                    }
                    else if (Qtyval == CheckTempDetailsQty)
                    {
                        Context.TempDetail.Delete(CheckTempDetails.FirstOrDefault().TempDetailID);
                        Context.TempDetail.Save();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public List<Proc_TempDetailsData_Result> TempDetails(string LocationID, string Type)
        {
            return Context.Proc_TempDetailsData(LocationID, Type).ToList();
        }

        public string InsertTempMaterTransfterToDisplay(string MaterialID, string UOM, string Qty, string LocationID,string UserName)
        {
            tbl_Location Location = LocationBL.GetByID(LocationID.Trim());
            int Docid = Convert.ToInt32(Location.TfrDisplay);
            int cnt = Docid + 1;
            string DocumentID = (LocationID + cnt).ToString().Trim();
            List<tbl_Company> Company = Context.Company.Get().ToList();
            string CompanyID = Company.FirstOrDefault().CompanyID;

            string TempMasterID = null;
            try
            {
                tbl_TempMaster TempMasterHeader = new tbl_TempMaster();

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                else
                {
                    TempMasterHeader = new tbl_TempMaster();
                }

                if (TempMasterID == string.Empty || TempMasterID == null)
                {
                    TempMasterHeader.DocumentID = DocumentID;
                    TempMasterHeader.PONumber = DocumentID;
                    TempMasterHeader.AddDate = DateTime.Now;
                    TempMasterHeader.CompanyID = CompanyID;
                    TempMasterHeader.DocumentDate = DateTime.Now;
                    TempMasterHeader.Filter = "TransterToDisplay";
                    TempMasterHeader.Filter_Id = "";
                    TempMasterHeader.LocationID = LocationID;
                    TempMasterHeader.PostingDate = DateTime.Now;
                    TempMasterHeader.StorageID = "D";
                    TempMasterHeader.Type = "TTTD";
                    TempMasterHeader.UserID = UserName;
                    Context.TempMaster.Insert(TempMasterHeader);
                    Context.TempMaster.Save();
                }

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }

                tbl_TempDetail TempDetail = new tbl_TempDetail();
                TempDetail.MaterialID = MaterialID;
                TempDetail.UOM = UOM;
                TempDetail.AddDate = DateTime.Now;
                TempDetail.BaseQty = Convert.ToDecimal(Qty);
                TempDetail.CategoryID = "";
                TempDetail.CompanyID = CompanyID;
                TempDetail.DocumentDate = DateTime.Now;
                TempDetail.DocumentID = DocumentID;
                TempDetail.LocationID = LocationID;
                TempDetail.PostingDate = DateTime.Now;
                TempDetail.StorageID = "D";
                TempDetail.TranQty = Convert.ToDecimal(Qty);
                TempDetail.UpdDate = DateTime.Now;
                TempDetail.UserID = UserName;
                TempDetail.TempMasterID = Convert.ToInt32(TempMasterID);
                TempDetail.CreditQty = 0.00M;
                TempDetail.Cost = 0.00M;
                TempDetail.DiscountRate = 0.00M;
                TempDetail.Amount = 0.00M;
                TempDetail.CreditAmount = 0.00M;
                TempDetail.OrderQty = 0.00M;
                TempDetail.Type = "TTTD";

                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e => e.LocationID == LocationID && e.MaterialID == MaterialID && e.UOM == UOM).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    TempDetail = CheckTempDetails.FirstOrDefault();
                    TempDetail.TranQty = Convert.ToDecimal(Qty) + CheckTempDetails.FirstOrDefault().TranQty;
                    TempDetail.BaseQty = TempDetail.TranQty;

                    Context.TempDetail.Update(TempDetail);
                    Context.tempDetail.Save();
                }
                else
                {
                    Context.TempDetail.Insert(TempDetail);
                    Context.TempDetail.Save();
                }

            }
            catch (Exception ex)
            {

            }
            return TempMasterID;
        }

        public string InsertTempMaterReturnToSupplier(string MaterialID, string UOM, string Qty, string LocationID, string StorageID, string Vendor,string TempDMasterID,string UserName)
        {
            tbl_Location Location = LocationBL.GetByID(LocationID.Trim());
            int Docid = Convert.ToInt32(Location.RtnVendor);
            int cnt = Docid + 1;
            string DocumentID = (LocationID + cnt).ToString().Trim();
            List<tbl_Company> Company = Context.Company.Get().ToList();
            string CompanyID = Company.FirstOrDefault().CompanyID;



            string TempMasterID = null;
            try
            {
                tbl_TempMaster TempMasterHeader = new tbl_TempMaster();

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                else
                {
                    TempMasterHeader = new tbl_TempMaster();
                }

                if (TempMasterID == string.Empty || TempMasterID == null)
                {
                    TempMasterHeader.DocumentID = DocumentID;
                    TempMasterHeader.PONumber = DocumentID;
                    TempMasterHeader.AddDate = DateTime.Now;
                    TempMasterHeader.CompanyID = CompanyID;
                    TempMasterHeader.DocumentDate = DateTime.Now;
                    TempMasterHeader.Filter = "";
                    TempMasterHeader.Filter_Id = "";
                    TempMasterHeader.LocationID = LocationID;
                    TempMasterHeader.PostingDate = DateTime.Now;
                    TempMasterHeader.StorageID = StorageID;
                    TempMasterHeader.Type = "TRTS";
                    TempMasterHeader.UserID = UserName;
                    TempMasterHeader.VendorID = Vendor;
                    Context.TempMaster.Insert(TempMasterHeader);
                    Context.TempMaster.Save();
                }
                // Header Check 
                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                //Details Check
                tbl_TempDetail TempDetail = new tbl_TempDetail();

                int DetailsTempMasterID = Convert.ToInt32(TempMasterID);

               List<tbl_TempDetail> CheckMasterCount = Context.TempDetail.Get(e=>e.TempMasterID== DetailsTempMasterID).ToList();

                int Counter = CheckMasterCount.Count + 1;


                TempDetail.MaterialID = MaterialID;
                TempDetail.UOM = UOM;
                TempDetail.AddDate = DateTime.Now;
                TempDetail.BaseQty = Convert.ToDecimal(Qty);
                TempDetail.CategoryID = "";
                TempDetail.CompanyID = CompanyID;
                TempDetail.DocumentDate = DateTime.Now;
                TempDetail.DocumentID = DocumentID;
                TempDetail.LocationID = LocationID;
                TempDetail.PostingDate = DateTime.Now;
                TempDetail.StorageID = StorageID;
                TempDetail.TranQty = Convert.ToDecimal(Qty);
                TempDetail.UpdDate = DateTime.Now;
                TempDetail.UserID = UserName;
                TempDetail.TempMasterID = Convert.ToInt32(TempMasterID);
                TempDetail.CreditQty = 0.00M;
                TempDetail.Cost = 0.00M;
                TempDetail.DiscountRate = 0.00M;
                TempDetail.Amount = 0.00M;
                TempDetail.CreditAmount = 0.00M;
                TempDetail.OrderQty = 0.00M;
                TempDetail.Type = "TRTS";
                TempDetail.VendorID = Vendor;
                TempDetail.PostKey = -1;
                TempDetail.Counter = Counter;

                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e => e.MaterialID == MaterialID && e.UOM == UOM && e.LocationID == LocationID).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    TempDetail = CheckTempDetails.FirstOrDefault();
                    TempDetail.TranQty = Convert.ToDecimal(Qty) + CheckTempDetails.FirstOrDefault().TranQty;
                    TempDetail.BaseQty = TempDetail.TranQty;


                    Context.TempDetail.Update(TempDetail);
                    Context.tempDetail.Save();
                }
                else
                {
                    if(TempDMasterID==string.Empty)
                    {
                        Context.TempDetail.Insert(TempDetail);
                        Context.TempDetail.Save();
                    }
                    else
                    {
                        int TempDDMasterID = Convert.ToInt32(TempDMasterID);
                        TempDetail.TempMasterID = TempDDMasterID;
                        Context.TempDetail.Insert(TempDetail);
                        Context.TempDetail.Save();
                    }
                   
                }

            }
            catch (Exception ex)
            {

            }
            return TempMasterID;
        }

        public List<Proc_TempDetailsData_Result> GetTempDetails(string LocationID, string Type)
        {
            return Context.Proc_TempDetailsData(LocationID, Type);
        }

        public int? pxAcceptTransaction(int ID)
        {
            try
            {
                return Context.pxAcceptTransaction(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string InsertTempMaterPurchaseOrder(string MaterialID, string UOM, string Qty, string LocationID, string StorageID, string Vendor, string TempDMasterID, string UserName)
        {
            tbl_Location Location = LocationBL.GetByID(LocationID.Trim());
            int Docid = Convert.ToInt32(Location.RtnVendor);
            int cnt = Docid + 1;
            string DocumentID = (LocationID + cnt).ToString().Trim();
            List<tbl_Company> Company = Context.Company.Get().ToList();
            string CompanyID = Company.FirstOrDefault().CompanyID;



            string TempMasterID = null;
            try
            {
                tbl_TempMaster TempMasterHeader = new tbl_TempMaster();

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                else
                {
                    TempMasterHeader = new tbl_TempMaster();
                }

                if (TempMasterID == string.Empty || TempMasterID == null)
                {
                    TempMasterHeader.DocumentID = DocumentID;
                    TempMasterHeader.PONumber = DocumentID;
                    TempMasterHeader.AddDate = DateTime.Now;
                    TempMasterHeader.CompanyID = CompanyID;
                    TempMasterHeader.DocumentDate = DateTime.Now;
                    TempMasterHeader.Filter = "";
                    TempMasterHeader.Filter_Id = "";
                    TempMasterHeader.LocationID = LocationID;
                    TempMasterHeader.PostingDate = DateTime.Now;
                    TempMasterHeader.StorageID = StorageID;
                    TempMasterHeader.Type = "TPO";
                    TempMasterHeader.UserID = UserName;
                    TempMasterHeader.VendorID = Vendor;
                    Context.TempMaster.Insert(TempMasterHeader);
                    Context.TempMaster.Save();
                }
                // Header Check 
                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                //Details Check
                tbl_TempDetail TempDetail = new tbl_TempDetail();

                int DetailsTempMasterID = Convert.ToInt32(TempMasterID);

                List<tbl_TempDetail> CheckMasterCount = Context.TempDetail.Get(e => e.TempMasterID == DetailsTempMasterID).ToList();

                int Counter = CheckMasterCount.Count + 1;


                TempDetail.MaterialID = MaterialID;
                TempDetail.UOM = UOM;
                TempDetail.AddDate = DateTime.Now;
                TempDetail.BaseQty = Convert.ToDecimal(Qty);
                TempDetail.CategoryID = "";
                TempDetail.CompanyID = CompanyID;
                TempDetail.DocumentDate = DateTime.Now;
                TempDetail.DocumentID = DocumentID;
                TempDetail.LocationID = LocationID;
                TempDetail.PostingDate = DateTime.Now;
                TempDetail.StorageID = StorageID;
                TempDetail.TranQty = Convert.ToDecimal(Qty);
                TempDetail.UpdDate = DateTime.Now;
                TempDetail.UserID = UserName;
                TempDetail.TempMasterID = Convert.ToInt32(TempMasterID);
                TempDetail.CreditQty = 0.00M;
                TempDetail.Cost = 0.00M;
                TempDetail.DiscountRate = 0.00M;
                TempDetail.Amount = 0.00M;
                TempDetail.CreditAmount = 0.00M;
                TempDetail.OrderQty = 0.00M;
                TempDetail.Type = "TPO";
                TempDetail.VendorID = Vendor;
                TempDetail.PostKey = 1;
                TempDetail.Counter = Counter;

                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e => e.MaterialID == MaterialID && e.UOM == UOM && e.LocationID == LocationID).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    TempDetail = CheckTempDetails.FirstOrDefault();
                    TempDetail.TranQty = Convert.ToDecimal(Qty) + CheckTempDetails.FirstOrDefault().TranQty;
                    TempDetail.BaseQty = TempDetail.TranQty;


                    Context.TempDetail.Update(TempDetail);
                    Context.tempDetail.Save();
                }
                else
                {
                    if (TempDMasterID == string.Empty)
                    {
                        Context.TempDetail.Insert(TempDetail);
                        Context.TempDetail.Save();
                    }
                    else
                    {
                        int TempDDMasterID = Convert.ToInt32(TempDMasterID);
                        TempDetail.TempMasterID = TempDDMasterID;
                        Context.TempDetail.Insert(TempDetail);
                        Context.TempDetail.Save();
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return TempMasterID;
        }

        public string InsertTempMaterTransfterOUT(string MaterialID, string UOM, string Qty, string FLocationID, string UserName, string TLocationID, string FStorageID, string TStorageID)
        {
            tbl_Location Location = LocationBL.GetByID(FLocationID.Trim());
            int Docid = Convert.ToInt32(Location.TfrOut);
            int cnt = Docid + 1;
            string DocumentID = (FLocationID + cnt).ToString().Trim();
            List<tbl_Company> Company = Context.Company.Get().ToList();
            string CompanyID = Company.FirstOrDefault().CompanyID;

            string TempMasterID = null;
            try
            {
                tbl_TempMaster TempMasterHeader = new tbl_TempMaster();

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == FLocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                else
                {
                    TempMasterHeader = new tbl_TempMaster();
                }

                if (TempMasterID == string.Empty || TempMasterID == null)
                {
                    TempMasterHeader.DocumentID = DocumentID;
                    TempMasterHeader.PONumber = DocumentID;
                    TempMasterHeader.AddDate = DateTime.Now;
                    TempMasterHeader.CompanyID = CompanyID;
                    TempMasterHeader.DocumentDate = DateTime.Now;
                    TempMasterHeader.Filter = "Transfter OUT";
                    TempMasterHeader.Filter_Id = "";
                    TempMasterHeader.LocationID = FLocationID;
                    TempMasterHeader.PostingDate = DateTime.Now;
                    TempMasterHeader.StorageID = FStorageID;
                    TempMasterHeader.Type = "TO";
                    TempMasterHeader.UserID = UserName;
                    TempMasterHeader.TLocationID = TLocationID;
                    TempMasterHeader.TStorageID = TStorageID;
                    Context.TempMaster.Insert(TempMasterHeader);
                    Context.TempMaster.Save();
                }

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == FLocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }

                tbl_TempDetail TempDetail = new tbl_TempDetail();
                TempDetail.MaterialID = MaterialID;
                TempDetail.UOM = UOM;
                TempDetail.AddDate = DateTime.Now;
                TempDetail.BaseQty = Convert.ToDecimal(Qty);
                TempDetail.CategoryID = "";
                TempDetail.CompanyID = CompanyID;
                TempDetail.DocumentDate = DateTime.Now;
                TempDetail.DocumentID = DocumentID;
                TempDetail.LocationID = FLocationID;
                TempDetail.PostingDate = DateTime.Now;
                TempDetail.StorageID = FStorageID;
                TempDetail.TranQty = Convert.ToDecimal(Qty);
                TempDetail.UpdDate = DateTime.Now;
                TempDetail.UserID = UserName;
                TempDetail.TempMasterID = Convert.ToInt32(TempMasterID);
                TempDetail.CreditQty = 0.00M;
                TempDetail.Cost = 0.00M;
                TempDetail.DiscountRate = 0.00M;
                TempDetail.Amount = 0.00M;
                TempDetail.CreditAmount = 0.00M;
                TempDetail.OrderQty = 0.00M;
                TempDetail.Type = "TO";

                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e => e.LocationID == FLocationID && e.MaterialID == MaterialID && e.UOM == UOM).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    TempDetail = CheckTempDetails.FirstOrDefault();
                    TempDetail.TranQty = Convert.ToDecimal(Qty) + CheckTempDetails.FirstOrDefault().TranQty;
                    TempDetail.BaseQty = TempDetail.TranQty;

                    Context.TempDetail.Update(TempDetail);
                    Context.tempDetail.Save();
                }
                else
                {
                    Context.TempDetail.Insert(TempDetail);
                    Context.TempDetail.Save();
                }

            }
            catch (Exception ex)
            {

            }
            return TempMasterID;
        }

        public string InsertTempMaterProductionOrder(string MaterialID, string UOM, string Qty, string LocationID, string UserName,string StorageID)
        {
            tbl_Location Location = LocationBL.GetByID(LocationID.Trim());
            int Docid = Convert.ToInt32(Location.Prod_Order);
            int cnt = Docid + 1;
            string DocumentID = (LocationID + cnt).ToString().Trim();
            List<tbl_Company> Company = Context.Company.Get().ToList();
            string CompanyID = Company.FirstOrDefault().CompanyID;

            string TempMasterID = null;
            try
            {
                tbl_TempMaster TempMasterHeader = new tbl_TempMaster();

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                }
                else
                {
                    TempMasterHeader = new tbl_TempMaster();
                }

                if (TempMasterID == string.Empty || TempMasterID == null)
                {
                    TempMasterHeader.DocumentID = DocumentID;
                    TempMasterHeader.PONumber = DocumentID;
                    TempMasterHeader.AddDate = DateTime.Now;
                    TempMasterHeader.CompanyID = CompanyID;
                    TempMasterHeader.DocumentDate = DateTime.Now;
                    TempMasterHeader.Filter = "";
                    TempMasterHeader.Filter_Id = "";
                    TempMasterHeader.LocationID = LocationID;
                    TempMasterHeader.PostingDate = DateTime.Now;
                    TempMasterHeader.StorageID = StorageID;
                    TempMasterHeader.Type = "PDO";
                    TempMasterHeader.UserID = UserName;
                    TempMasterHeader.DocDetail = "Production Order";
                    Context.TempMaster.Insert(TempMasterHeader);
                    Context.TempMaster.Save();
                }

                TempMasterHeader = Context.TempMaster.Get(e => e.LocationID == LocationID && e.DocumentID == DocumentID).FirstOrDefault();
                if (TempMasterHeader != null)
                {
                    TempMasterID = TempMasterHeader.TempMasterID.ToString();
                    StorageID = TempMasterHeader.StorageID.ToString();
                }

                tbl_TempDetail TempDetail = new tbl_TempDetail();
                TempDetail.MaterialID = MaterialID;
                TempDetail.UOM = UOM;
                TempDetail.AddDate = DateTime.Now;
                TempDetail.BaseQty = Convert.ToDecimal(Qty);
                TempDetail.CategoryID = "";
                TempDetail.CompanyID = CompanyID;
                TempDetail.DocumentDate = DateTime.Now;
                TempDetail.DocumentID = DocumentID;
                TempDetail.LocationID = LocationID;
                TempDetail.PostingDate = DateTime.Now;
                if(StorageID==null)
                {

                }
                else
                {
                    TempDetail.StorageID = StorageID;
                }
               
                TempDetail.TranQty = Convert.ToDecimal(Qty);
                TempDetail.UpdDate = DateTime.Now;
                TempDetail.UserID = UserName;
                TempDetail.TempMasterID = Convert.ToInt32(TempMasterID);
                TempDetail.CreditQty = 0.00M;
                TempDetail.Cost = 0.00M;
                TempDetail.DiscountRate = 0.00M;
                TempDetail.Amount = 0.00M;
                TempDetail.CreditAmount = 0.00M;
                TempDetail.OrderQty = 0.00M;
                TempDetail.Type = "PDO";

                List<tbl_TempDetail> CheckTempDetails = Context.TempDetail.Get(e => e.LocationID == LocationID && e.MaterialID == MaterialID && e.UOM == UOM).ToList();

                if (CheckTempDetails.Count >= 1)
                {
                    TempDetail = CheckTempDetails.FirstOrDefault();
                    TempDetail.TranQty = Convert.ToDecimal(Qty) + CheckTempDetails.FirstOrDefault().TranQty;
                    TempDetail.BaseQty = TempDetail.TranQty;

                    Context.TempDetail.Update(TempDetail);
                    Context.tempDetail.Save();
                }
                else
                {
                    Context.TempDetail.Insert(TempDetail);
                    Context.TempDetail.Save();
                }

            }
            catch (Exception ex)
            {

            }
            return TempMasterID;
        }
    }
}

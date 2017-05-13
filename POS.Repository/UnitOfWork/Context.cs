using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Repository;


namespace POS.Repository.UnitOfWork
{
    ///Created by Srikanth Kotnala on 8/4/2016
    ///Unit of work for POS database objects.
    public class Context
    {
        POSEntities POSEntities;
        public Context()
        {
            POSEntities = new POSEntities();
        }

        /// <summary>
        ///Unit of work for POS database tables.
        /// </summary>
        #region Data Model Repository Properties


        private GenericRepository<tbl_Location> location;
        /// <summary>
        /// tbl_Location table property as Location
        /// </summary>
        public GenericRepository<tbl_Location> Location
        {
            get
            {
                if (this.location == null)
                {
                    this.location = new GenericRepository<tbl_Location>(EntityConstant.POS);
                }
                return location;
            }
            set
            {
                this.location = new GenericRepository<tbl_Location>(EntityConstant.POS);
            }

        }

        /// <summary>
        /// tbl_Storage table property as Storage
        /// </summary>
        private GenericRepository<tbl_Storage> storage;
        public GenericRepository<tbl_Storage> Storage
        {
            get
            {
                if (this.storage == null)
                {
                    this.storage = new GenericRepository<tbl_Storage>(EntityConstant.POS);
                }
                return storage;
            }
            set
            {
                this.storage = new GenericRepository<tbl_Storage>(EntityConstant.POS);
            }
        }

        private GenericRepository<tbl_Terminal> terminal;
        public GenericRepository<tbl_Terminal> Terminal
        {
            get
            {
                if (this.terminal == null)
                {
                    this.terminal = new GenericRepository<tbl_Terminal>(EntityConstant.POS);
                }
                return terminal;
            }
            set
            {
                this.terminal = new GenericRepository<tbl_Terminal>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_Vendor> vendor;
        public GenericRepository<tbl_Vendor> Vendor
        {
            get
            {
                if (this.vendor == null)
                {
                    this.vendor = new GenericRepository<tbl_Vendor>(EntityConstant.POS);
                }
                return vendor;
            }
            set
            {
                this.vendor = new GenericRepository<tbl_Vendor>(EntityConstant.POS);
            }

        }

        public GenericRepository<tbl_City> city;
        public GenericRepository<tbl_City> City
        {
            get
            {
                if (this.city == null)
                {
                    this.city = new GenericRepository<tbl_City>(EntityConstant.POS);
                }
                return city;
            }
            set
            {
                this.city = new GenericRepository<tbl_City>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_Country> country;
        public GenericRepository<tbl_Country> Country
        {
            get
            {
                if (this.country == null)
                {
                    this.country = new GenericRepository<tbl_Country>(EntityConstant.POS);
                }
                return country;
            }
            set
            {
                this.country = new GenericRepository<tbl_Country>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_Region> region;
        public GenericRepository<tbl_Region> Region
        {
            get
            {
                if (this.region == null)
                {
                    this.region = new GenericRepository<tbl_Region>(EntityConstant.POS);
                }
                return region;
            }
            set
            {
                this.region = new GenericRepository<tbl_Region>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_Category> category;
        public GenericRepository<tbl_Category> Category
        {
            get
            {
                if (category == null)
                {
                    this.category = new GenericRepository<tbl_Category>(EntityConstant.POS);
                }
                return category;
            }
            set
            {
                this.category = new GenericRepository<tbl_Category>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_Material> material;
        public GenericRepository<tbl_Material> Material
        {
            get
            {
                if (material == null)
                {
                    this.material = new GenericRepository<tbl_Material>(EntityConstant.POS);
                }
                return material;
            }
            set
            {
                this.material = new GenericRepository<tbl_Material>(EntityConstant.POS);
            }

        }

        public GenericRepository<tbl_SubCategory> subcategory;
        public GenericRepository<tbl_SubCategory> SubCategory
        {
            get
            {
                if (subcategory == null)
                {
                    this.subcategory = new GenericRepository<tbl_SubCategory>(EntityConstant.POS);
                }
                return subcategory;
            }
            set
            {
                this.subcategory = new GenericRepository<tbl_SubCategory>(EntityConstant.POS);
            }
        }
        public GenericRepository<tbl_UOM> uom;
        public GenericRepository<tbl_UOM> UOM
        {
            get
            {
                if (uom == null)
                {
                    this.uom = new GenericRepository<tbl_UOM>(EntityConstant.POS);
                }
                return uom;
            }
            set
            {
                this.uom = new GenericRepository<tbl_UOM>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_LocationPrice> locationprice;
        public GenericRepository<tbl_LocationPrice> LocationPrice
        {
            get
            {
                if (locationprice == null)
                {
                    this.locationprice = new GenericRepository<tbl_LocationPrice>(EntityConstant.POS);
                }
                return locationprice;
            }
            set
            {
                this.locationprice = new GenericRepository<tbl_LocationPrice>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_MaterialEAN> materialean;
        public GenericRepository<tbl_MaterialEAN> MaterialEAN
        {
            get
            {
                if (materialean == null)
                {
                    materialean = new GenericRepository<tbl_MaterialEAN>(EntityConstant.POS);
                }
                return materialean;
            }
            set
            {
                materialean = new GenericRepository<tbl_MaterialEAN>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_PreferUOM> preforuom;
        public GenericRepository<tbl_PreferUOM> PreforUOM
        {
            get
            {
                if (preforuom == null)
                {
                    preforuom = new GenericRepository<tbl_PreferUOM>(EntityConstant.POS);
                }
                return preforuom;
            }
            set
            {
                preforuom = new GenericRepository<tbl_PreferUOM>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_PriceFile> pricefile;
        public GenericRepository<tbl_PriceFile> PriceFile
        {
            get
            {
                if (pricefile == null)
                {
                    pricefile = new GenericRepository<tbl_PriceFile>(EntityConstant.POS);
                }
                return pricefile;
            }
            set
            {
                pricefile = new GenericRepository<tbl_PriceFile>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_ImageDetails> imagedetails;
        public GenericRepository<tbl_ImageDetails> ImageDetails
        {
            get
            {
                if (imagedetails == null)
                {
                    imagedetails = new GenericRepository<tbl_ImageDetails>(EntityConstant.POS);
                }
                return imagedetails;
            }
            set
            {
                imagedetails = new GenericRepository<tbl_ImageDetails>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_PurchaseOrder> purchaseOrder;
        public GenericRepository<tbl_PurchaseOrder> PurchaseOrder
        {
            get
            {
                if (purchaseOrder == null)
                {
                    purchaseOrder = new GenericRepository<tbl_PurchaseOrder>(EntityConstant.POS);
                }
                return purchaseOrder;
            }
            set
            {
                purchaseOrder = new GenericRepository<tbl_PurchaseOrder>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_PurchaseOrder_Detail> purchaseOrderDetail;
        public GenericRepository<tbl_PurchaseOrder_Detail> PurchaseOrderDetail
        {
            get
            {
                if (purchaseOrderDetail == null)
                {
                    purchaseOrderDetail = new GenericRepository<tbl_PurchaseOrder_Detail>(EntityConstant.POS);
                }
                return purchaseOrderDetail;
            }
            set
            {
                purchaseOrderDetail = new GenericRepository<tbl_PurchaseOrder_Detail>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_StockReceive> stockReceive;
        public GenericRepository<tbl_StockReceive> StockReceive
        {
            get
            {
                if (stockReceive == null)
                {
                    stockReceive = new GenericRepository<tbl_StockReceive>(EntityConstant.POS);
                }
                return stockReceive;
            }
            set
            {
                stockReceive = new GenericRepository<tbl_StockReceive>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_StockReceive_Detail> stockReceiveDetail;
        public GenericRepository<tbl_StockReceive_Detail> StockReceiveDetail
        {
            get
            {
                if (stockReceiveDetail == null)
                {
                    stockReceiveDetail = new GenericRepository<tbl_StockReceive_Detail>(EntityConstant.POS);
                }
                return stockReceiveDetail;
            }
            set
            {
                stockReceiveDetail = new GenericRepository<tbl_StockReceive_Detail>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_TempMaster> tempMaster;
        public GenericRepository<tbl_TempMaster> TempMaster
        {
            get
            {
                if (tempMaster == null)
                {
                    tempMaster = new GenericRepository<tbl_TempMaster>(EntityConstant.POS);
                }
                return tempMaster;
            }
            set
            {
                tempMaster = new GenericRepository<tbl_TempMaster>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_TempDetail> tempDetail;
        public GenericRepository<tbl_TempDetail> TempDetail
        {
            get
            {
                if (tempDetail == null)
                {
                    tempDetail = new GenericRepository<tbl_TempDetail>(EntityConstant.POS);
                }
                return tempDetail;
            }
            set
            {
                tempDetail = new GenericRepository<tbl_TempDetail>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_Company> company;
        public GenericRepository<tbl_Company> Company
        {
            get
            {
                if (company == null)
                {
                    company = new GenericRepository<tbl_Company>(EntityConstant.POS);
                }
                return company;
            }
            set
            {
                company = new GenericRepository<tbl_Company>(EntityConstant.POS);
            }
        }

        public GenericRepository<tbl_EOD> eod;
        public GenericRepository<tbl_EOD> EOD
        {
            get {
                if(eod==null)
                {
                    eod = new GenericRepository<tbl_EOD>(EntityConstant.POS);
                }
                return eod; }
            set { eod = new GenericRepository<tbl_EOD>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_TransferIN> transfterin;
        public GenericRepository<tbl_TransferIN> TransfterIN
        {
            get {
                if(transfterin==null)
                {
                    transfterin =new GenericRepository<tbl_TransferIN>(EntityConstant.POS);
                }
                return transfterin;
            }
            set { transfterin = new GenericRepository<tbl_TransferIN>(EntityConstant.POS);  }
        }


        private GenericRepository<tbl_Users> users;

        public GenericRepository<tbl_Users> Users
        {
            get {
                
                if (users==null)
                {
                    users = new GenericRepository<tbl_Users>(EntityConstant.POS);
                }
                return users;
            }
            set { Users = new GenericRepository<tbl_Users>(EntityConstant.POS);
                
            }
        }


        private GenericRepository<tbl_TransferOut> transfterout;
        public GenericRepository<tbl_TransferOut> TransfterOUT
        {
            get
            {
                if (transfterin == null)
                {
                    transfterout = new GenericRepository<tbl_TransferOut>(EntityConstant.POS);
                }
                return transfterout;
            }
            set { transfterout = new GenericRepository<tbl_TransferOut>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_TransferIN_Detail> transfterindetails;
        public GenericRepository<tbl_TransferIN_Detail> TransfterINDetails
        {
            get {
                if(transfterindetails==null)
                {
                    transfterindetails = new GenericRepository<tbl_TransferIN_Detail>(EntityConstant.POS);
                }
                return transfterindetails;
            }
            
            set { transfterindetails = new GenericRepository<tbl_TransferIN_Detail>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_TransferOut_Detail> transfteroutdetails;
        public GenericRepository<tbl_TransferOut_Detail> TransfterOUTDetails
        {
            get
            {
                if (transfteroutdetails == null)
                {
                    transfteroutdetails = new GenericRepository<tbl_TransferOut_Detail>(EntityConstant.POS);
                }
                return transfteroutdetails;
            }

            set { transfteroutdetails = new GenericRepository<tbl_TransferOut_Detail>(EntityConstant.POS); }
        }

        private GenericRepository<AspNetRole> aspnetroles;
        public GenericRepository<AspNetRole> AspNetRoles
        {
            get
            {
                if (aspnetroles == null)
                {
                    aspnetroles = new GenericRepository<AspNetRole>(EntityConstant.POS);
                }
                return aspnetroles;
            }

            set { aspnetroles = new GenericRepository<AspNetRole>(EntityConstant.POS); }
        }

        private GenericRepository<AspNetUserRole> aspnetuserroles;
        public GenericRepository<AspNetUserRole> AspNetUserRoles
        {
            get
            {
                if (aspnetuserroles == null)
                {
                    aspnetuserroles = new GenericRepository<AspNetUserRole>(EntityConstant.POS);
                }
                return aspnetuserroles;
            }

            set { aspnetuserroles = new GenericRepository<AspNetUserRole>(EntityConstant.POS); }
        }


        private GenericRepository<AspNetUser> aspnetusers;
        public GenericRepository<AspNetUser> AspNetUsers
        {
            get
            {
                if (aspnetusers == null)
                {
                    aspnetusers = new GenericRepository<AspNetUser>(EntityConstant.POS);
                }
                return aspnetusers;
            }

            set { aspnetusers = new GenericRepository<AspNetUser>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_LocationAuthentication> locationauthentication;
        public GenericRepository<tbl_LocationAuthentication> LocationAuthentication
        {
            get
            {
                if (locationauthentication == null)
                {
                    locationauthentication = new GenericRepository<tbl_LocationAuthentication>(EntityConstant.POS);
                }
                return locationauthentication;
            }

            set { locationauthentication = new GenericRepository<tbl_LocationAuthentication>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_MasterDataAuthentication> masterdataauthentication;
        public GenericRepository<tbl_MasterDataAuthentication> MasterDataAuthentication
        {
            get
            {
                if (masterdataauthentication == null)
                {
                    masterdataauthentication = new GenericRepository<tbl_MasterDataAuthentication>(EntityConstant.POS);
                }
                return masterdataauthentication;
            }

            set { masterdataauthentication = new GenericRepository<tbl_MasterDataAuthentication>(EntityConstant.POS); }
        }


        private GenericRepository<tbl_TrasactionsAuthentication> trasactionsauthentication;
        public GenericRepository<tbl_TrasactionsAuthentication> TrasactionsAuthentication
        {
            get
            {
                if (trasactionsauthentication == null)
                {
                    trasactionsauthentication = new GenericRepository<tbl_TrasactionsAuthentication>(EntityConstant.POS);
                }
                return trasactionsauthentication;
            }

            set { trasactionsauthentication = new GenericRepository<tbl_TrasactionsAuthentication>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_EnquiryAuthentication> enquiryauthentication;
        public GenericRepository<tbl_EnquiryAuthentication> EnquiryAuthentication
        {
            get
            {
                if (enquiryauthentication == null)
                {
                    enquiryauthentication = new GenericRepository<tbl_EnquiryAuthentication>(EntityConstant.POS);
                }
                return enquiryauthentication;
            }

            set { enquiryauthentication = new GenericRepository<tbl_EnquiryAuthentication>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_SetupAuthentication> setupauthentication;
        public GenericRepository<tbl_SetupAuthentication> SetupAuthentication
        {
            get
            {
                if (setupauthentication == null)
                {
                    setupauthentication = new GenericRepository<tbl_SetupAuthentication>(EntityConstant.POS);
                }
                return setupauthentication;
            }

            set { setupauthentication = new GenericRepository<tbl_SetupAuthentication>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_ManagerUserAuthentication> manageruserauthentication;

        public GenericRepository<tbl_ManagerUserAuthentication> ManagerUserAuthentication
        {
            get
            {
                if(manageruserauthentication==null)
                {
                    manageruserauthentication = new GenericRepository<tbl_ManagerUserAuthentication>(EntityConstant.POS);
                }
                return manageruserauthentication;
            }
            set { manageruserauthentication = new GenericRepository<tbl_ManagerUserAuthentication>(EntityConstant.POS); }
        }

        private GenericRepository<tbl_Customer> customer;

        public GenericRepository<tbl_Customer> Customer
        {
            get {
            if(customer==null)
                {
                    customer = new GenericRepository<tbl_Customer>(EntityConstant.POS);
                }
                return customer;
                    }
            set {
                customer = new GenericRepository<tbl_Customer>(EntityConstant.POS);
            }
        }

        private GenericRepository<tbl_PhoneCode> phonecode;

        public GenericRepository<tbl_PhoneCode> PhoneCode
        {
            get {
                if(phonecode==null)
                {
                    phonecode = new GenericRepository<tbl_PhoneCode>(EntityConstant.POS);
                }
                return phonecode;
            }
            set {
                phonecode = new GenericRepository<tbl_PhoneCode>(EntityConstant.POS);
            }
        }



        #endregion

        /// <summary>
        ///Unit of work for POS database Stored Procedures.
        /// </summary>
        #region POS Stored Procedures
        /// <summary>
        /// SP Description
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Proc_GetMasterCategory_Result> GetMasterCategory(string CategoryID)
        {
            return POSEntities.Proc_GetMasterCategory(CategoryID).ToList();
        }


        /// <summary>
        /// Get all location details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public List<Proc_LoadMasterLocation_Result> GetAllLocation()
        //{
        //    return pOSEntities.Proc_LoadMasterLocation().ToList();
        //}

        public List<pxSelectSalesEnquiry_Result> GetAllSalesEnquiry()
        {
            return POSEntities.pxSelectSalesEnquiry().ToList();
        }
        public List<pxSelectDocumentMaterial_Result> GetDocumentMaterial(string DocID)
        {
            return POSEntities.pxSelectDocumentMaterial(DocID).ToList();
        }
        public List<pxSelectDocumentTender_Result> GetDocumentTender(string DocID)
        {
            return POSEntities.pxSelectDocumentTender(DocID).ToList();
        }
        public List<pxSelectFilterSalesEnquiry_Result> FilterSalesEnquiry(DateTime? dateFrom, DateTime? dateTo, string terminalIDs, string materialID, string eAN, string category, string subCategory, string userID, string amountTo, string amountFrom, string location)
        {
            return POSEntities.pxSelectFilterSalesEnquiry(dateFrom, dateTo, terminalIDs, materialID, eAN, category.Trim(), subCategory, userID, amountTo, amountFrom, location).ToList();
        }
        public List<pxSelectReturnSalesWithInvoice_Result> ReturnSalesWithInvoice()
        {
            return POSEntities.pxSelectReturnSalesWithInvoice().ToList();
        }
        public List<pxSelectFilterReturnWithInvoice_Result> FilterReturnSalesWithInvoice(DateTime? dateFrom, DateTime? dateTo, string terminalIDs, string materialID, string eAN, string category, string subCategory, string userID, string amountTo, string amountFrom, string location)
        {
            return POSEntities.pxSelectFilterReturnWithInvoice(dateFrom, dateTo, terminalIDs, materialID, eAN, category, subCategory, userID, amountTo, amountFrom, location).ToList();
        }
        public List<pxSelectReturnSalesWithoutInvoice_Result> ReturnSalesWithoutInvoice()
        {
            return POSEntities.pxSelectReturnSalesWithoutInvoice().ToList();
        }
        public List<pxSelectFilterReturnWithoutInvoice_Result> FilterReturnSalesWithoutInvoice(DateTime? dateFrom, DateTime? dateTo, string terminalIDs, string materialID, string eAN, string category, string subCategory, string userID, string amountTo, string amountFrom, string location)
        {
            return POSEntities.pxSelectFilterReturnWithoutInvoice(dateFrom, dateTo, terminalIDs, materialID, eAN, category, subCategory, userID, amountTo, amountFrom,location).ToList();
        }

        public List<pxSelectSalesDelete_Result> GetAllSalesDelete()
        {
            return POSEntities.pxSelectSalesDelete().ToList();
        }
        public List<pxSelectDeleteDocumentMaterial_Result> GetDeletedDocumentMaterial(string DocID)
        {
            return POSEntities.pxSelectDeleteDocumentMaterial(DocID).ToList();
        }
        public List<pxSelectDeleteDocumentTender_Result> GetDeletedDocumentTender(string DocID)
        {
            return POSEntities.pxSelectDeleteDocumentTender(DocID).ToList();
        }
        public List<pxSelectSalesUnHoldEnquiry_Result> GetAllSalesUnhold()
        {
            return POSEntities.pxSelectSalesUnHoldEnquiry().ToList();
        }
        public List<pxSelectCategoryPieChart_Result> GetCategoryPieChart()
        {
            return POSEntities.pxSelectCategoryPieChart().ToList();
        }
        public List<pxSelectLatestSalesDetails_Result> GetLatestSalesDetails()
        {
            return POSEntities.pxSelectLatestSalesDetails().ToList();
        }

        /// <summary>
        /// Get all location details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Proc_LoadMasterLocation_Result> GetAllLocation()
        {
            return POSEntities.Proc_LoadMasterLocation().ToList();
        }

        /// <summary>
        /// Get All Storage and location Inner Join
        /// </summary>
        /// <returns></returns>
        public List<Proc_LoadGetLocationStorage_Result> GetAllStorage()
        {
            return POSEntities.Proc_LoadGetLocationStorage().ToList();
        }
        /// <summary>
        /// Get Storage By Id-Vinod InnerJoin
        /// </summary>
        /// <param name="LocationID"></param>
        /// <returns></returns>
        public List<Proc_LoadStorageGetById_Result> GetStorageById(string LocationID)
        {
            return POSEntities.Proc_LoadStorageGetById(LocationID).ToList();
        }

        public List<Proc_GetAllLTerminal_Result> GetAllTerminal()
        {
            return POSEntities.Proc_GetAllLTerminal().ToList();
        }
        public List<Proc_GetMasterTerminal_Result> GetMTeminal(string LocationID)
        {
            return POSEntities.Proc_GetMasterTerminal(LocationID).ToList();
        }


        public List<pxSelectPORecieve_Result> GetPORecieve()
        {
            return POSEntities.pxSelectPORecieve().ToList();
        }

        public List<pxSelectReturnToSupplier_Result> GetReturnToSupplier()
        {
            return POSEntities.pxSelectReturnToSupplier().ToList();
        }

        public List<pxSelectPORecieveMaterial_Result> GetPORecieveMaterial(string dOCID,string FilterName)
        {
            return POSEntities.pxSelectPORecieveMaterial(FilterName,dOCID).ToList();
        }

        public List<Proc_LoadMaterialDetails_Result> LoadMaterialDetails(string MaterialID)
        {
            return POSEntities.Proc_LoadMaterialDetails(MaterialID).ToList();
        }


        public List<pxSelectTransferDocument_Result> GetTransferDocument()
        {
            return POSEntities.pxSelectTransferDocument().ToList();
        }

        public List<pxSelectPhysicalDocument_Result> GetPhysicalDocument()
        {
            return POSEntities.pxSelectPhysicalDocument().ToList();
        }

        public List<pxSelectPurchaseOrderDetailByDocId_Result> GetPurchaseOrderDetailByDocId(string dOCID)
        {
            return POSEntities.pxSelectPurchaseOrderDetailByDocId(dOCID).ToList();
        }

        public List<Proc_MaterialBarcodeSearch_Result> GetReturnToSupplierMaterial(string MatrialOrBarcode, string VendorID,string PageName)
        {
            return POSEntities.Proc_MaterialBarcodeSearch(MatrialOrBarcode, VendorID,PageName).ToList();
        }

        public List<Proc_SearchEAN_Result> GetProc_SearchEAN(string EAN13, string UOM, string VendorID,string PageName)
        {
            return POSEntities.Proc_SearchEAN(EAN13, UOM, VendorID,PageName).ToList();
        }

        //public List<Proc_InsertRetunToSupplier_Result> Proc_InsertRetunToSupplier(string DocumentID, string LocationID, string MaterialID, string UOM, string UserID, string StorageID, string VendorID, decimal Quantity)
        //{
        //    return POSEntities.Proc_InsertRetunToSupplier(DocumentID, LocationID, MaterialID, UOM, UserID, StorageID, VendorID, Quantity).ToList();
        //}

        public List<Proc_MaterialCategorySearch_Result> Proc_MaterialCategorySearch(string CategoryText, string MaterialID, string CategoryID)
        {
            return POSEntities.Proc_MaterialCategorySearch(CategoryText, MaterialID, CategoryID).ToList();
        }

        public List<Proc_TempDetailsData_Result> Proc_TempDetailsData(string LocationID, string Type)
        {
            return POSEntities.Proc_TempDetailsData(LocationID, Type).ToList();
        }

        public int? pxAcceptTransaction(int? ID)
        {
            return POSEntities.pxAcceptTransaction(ID);

        }

        public List<Proc_FilterPOReceive_Result> Proc_FilterPOReceive(DateTime? dateFrom, DateTime? dateTo, string Terminals, string materialID, string eAN, string Category, string SubCategory, string userID, string amountFrom, string amountTo, string LocationIDs)
        {
            return POSEntities.Proc_FilterPOReceive(dateFrom, dateTo, Terminals, materialID, eAN, Category, SubCategory, userID, amountFrom, amountTo, LocationIDs).ToList();
        }

        public List<Proc_FilterReturnORTransferORPhysicalORTransInORTransOUT_Result> Proc_FilterReturnORTransferORPhysical(string filterName, DateTime? dateform, DateTime? dateto, string TerminalsIDs, string materialID, string eAN, string Category, string SubCategory, string userID, string AmountForm, string amountTo, string Location)
        {
            return POSEntities.Proc_FilterReturnORTransferORPhysicalORTransInORTransOUT(filterName, dateform, dateto, TerminalsIDs, materialID, eAN, Category, SubCategory, userID, AmountForm, amountTo, Location).ToList();
        }
        public List<Proc_DocumentdetailsTenderDetails_Result> DocumentdetailsTenderDetails(string DocumentID)
        {
            return POSEntities.Proc_DocumentdetailsTenderDetails(DocumentID).ToList();
        }

        public List<Proc_AllDocumentPrint_Result> AllDocumentPrint(string DocumentID,string FilterName)
        {
            return POSEntities.Proc_AllDocumentPrint(FilterName, DocumentID).ToList();
        }

        public List<Proc_SelectEODEnquiry_Result> Proc_SelectEODEnquiry()
        {
            return POSEntities.Proc_SelectEODEnquiry().ToList();
        }

        public List<Proc_CashCollection_Result> Proc_Cash_Collection(string LocationID,string FromDate,string ToDate)
        {
            return POSEntities.Proc_CashCollection(LocationID,FromDate,ToDate).ToList();
        }

        public List<pxSelectFilterSalesUnHoldEnquiry_Result> FilterSalesUnHoldEnquiry(DateTime? dateFrom, DateTime? dateTo, string terminalIDs, string materialID, string eAN, string category, string subCategory, string userID, string amountTo, string amountFrom, string location)
        {
            return POSEntities.pxSelectFilterSalesUnHoldEnquiry(dateFrom, dateTo, terminalIDs, materialID, eAN, category, subCategory, userID, amountTo, amountFrom, location).ToList();
        }
        public List<pxSelectTransfterIN_Result> SelectTransfterIN()
        {
            return POSEntities.pxSelectTransfterIN().ToList();
        }
        public List<pxSelectTransfterOUT_Result> SelectTransfterOUT()
        {
            return POSEntities.pxSelectTransfterOUT().ToList();
        }
        public List<pxSelectFilterSalesDeleteLineItemsEnquiry_Result> SelectFilterDeleteLineITems(DateTime? dateFrom, DateTime? dateTo, string terminalIDs, string materialID, string eAN, string category, string subCategory, string userID, string amountTo, string amountFrom, string location)
        {
            return POSEntities.pxSelectFilterSalesDeleteLineItemsEnquiry(dateFrom, dateTo, terminalIDs, materialID, eAN, category, subCategory, userID, amountTo, amountFrom, location).ToList();
        }

        public List<pxSelectFilterEodEnquiry_Result> selectFilterEOd(DateTime? dateFrom, DateTime? dateTo, string terminalIDs, string materialID, string eAN, string category, string subCategory, string userID, string amountTo, string amountFrom, string location)
        {
            return POSEntities.pxSelectFilterEodEnquiry(dateFrom, dateTo, terminalIDs, materialID, eAN, category, subCategory, userID, amountTo, amountFrom, location).ToList();
        }

        public List<pxSelectTranfterOUTDetailByDocId_Result> GetTIGetDocById(string DocId)
        {
            return POSEntities.pxSelectTranfterOUTDetailByDocId(DocId).ToList();
        }


        public List<Proc_SearchBOMID_Result> SearchBOMID(string BOMID)
        {
            return POSEntities.Proc_SearchBOMID(BOMID).ToList();
        }

        public List<Proc_EodByIdFile_Result> GetByIDFile(string EODID)
        {
            return POSEntities.Proc_EodByIdFile(EODID).ToList();
        }

        public List<Proc_SelectUserAuthentication_Result> Proc_SelectUserAuthentication(string UserId,string Email)
        {
            return POSEntities.Proc_SelectUserAuthentication(UserId).ToList();
        }
        public List<Proc_AspNetUsersLocations_Result> Proc_AspNetUsersLocations(string Email)
        {
            return POSEntities.Proc_AspNetUsersLocations(Email).ToList();
        }
        public List<Proc_AspNetManagerLocations_Result> Proc_AspNetManagerLocations(string Email)
        {
            return POSEntities.Proc_AspNetManagerLocations(Email).ToList();
        }

        public List<Proc_SelectUserId_Result> SelectUserId(string ManagerEmail)
        {
            return POSEntities.Proc_SelectUserId(ManagerEmail).ToList();
        }

        public List<Proc_REPORTProductionOrderStatus_Result> ReportProductionOrderStatus(string LocationID,DateTime? FromDate,DateTime? ToDate)
        {
            return POSEntities.Proc_REPORTProductionOrderStatus(LocationID, FromDate, ToDate).ToList();
        }
        
        public List<Proc_ProfitShortageReport_Result> ProfitShortageReport(string LocationID,DateTime? FromDate,DateTime? ToDate)
        {
            return POSEntities.Proc_ProfitShortageReport(LocationID, FromDate, ToDate).ToList();
        }
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Business.Interface;
using POS.Business.BusinessComponents;
using POS.Entity.Entities;
using POS.Repository.UnitOfWork;
using POS.Business.Interface.ControlPanel;
using POS.Util.Model;
using System.Web;

namespace POS.Business.BusinessComponents
{
    public class AuthenticationBL : IAuthentication
    {
        LocationBL LocationBL = new LocationBL();
        Context Context;
        public AuthenticationBL()
        {
            Context = new Context();
        }


        public List<tbl_ManagerUserAuthentication> AspNetManagerGetAll()
        {
            List<tbl_ManagerUserAuthentication> AspNetManager = new List<Entity.Entities.tbl_ManagerUserAuthentication>();
            try
            {
                AspNetManager = Context.ManagerUserAuthentication.Get().ToList();
                return AspNetManager;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public tbl_ManagerUserAuthentication AspNetManagerGetById(int id)
        {
            tbl_ManagerUserAuthentication AspNetManager = new Entity.Entities.tbl_ManagerUserAuthentication();
            try
            {
                AspNetManager = Context.ManagerUserAuthentication.GetByID(id);
                return AspNetManager;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_ManagerUserAuthentication> AspNetManagerGetByUserId(string id)
        {
            List<tbl_ManagerUserAuthentication> AspNetManager = new List<tbl_ManagerUserAuthentication>();
            try
            {
                AspNetManager = Context.ManagerUserAuthentication.Get(m => m.ID.ToString() == id).ToList();
                return AspNetManager;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_ManagerUserAuthentication> AspNetManagerGetByUserEmail(string Email)
        {
            List<tbl_ManagerUserAuthentication> AspNetManager = new List<tbl_ManagerUserAuthentication>();
            try
            {
                AspNetManager = Context.ManagerUserAuthentication.Get(m => m.Manager_EmailID == Email).ToList();
                return AspNetManager;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string AspNetManagerInsert(tbl_ManagerUserAuthentication AspNetUser)
        {
            string result = string.Empty;
            try
            {
                Context.ManagerUserAuthentication.Insert(AspNetUser);
                Context.ManagerUserAuthentication.Save();
                result = AspNetUser.User_EmailID + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public List<AspNetRole> AspNetRoleGetAll()
        {
            List<AspNetRole> AspNetRole = new List<Entity.Entities.AspNetRole>();
            try
            {
                AspNetRole = Context.AspNetRoles.Get().ToList();
                return AspNetRole;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public AspNetRole AspNetRoleGetById(string id)
        {
            AspNetRole AspNetRole = new Entity.Entities.AspNetRole();
            try
            {
                AspNetRole = Context.AspNetRoles.GetByID(id);
                return AspNetRole;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string AspNetRoleInsert(AspNetRole AspNetRole)
        {
            string result = string.Empty;
            try
            {
                Context.AspNetRoles.Insert(AspNetRole);
                Context.AspNetRoles.Save();
                result = AspNetRole.Name + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string AspNetRoleUpdate(AspNetRole AspNetRole)
        {
            string result = string.Empty;
            try
            {
                Context.AspNetRoles.Update(AspNetRole);
                Context.AspNetRoles.Save();
                result = AspNetRole.Id +"Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public List<AspNetUser> AspNetUserGetAll()
        {
            List<AspNetUser> AspNetUser = new List<Entity.Entities.AspNetUser>();
            try
            {
                AspNetUser = Context.AspNetUsers.Get().ToList();
                return AspNetUser;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public AspNetUser AspNetUserGetById(int id)
        {
            AspNetUser AspNetUser = new Entity.Entities.AspNetUser();
            try
            {
                AspNetUser = Context.AspNetUsers.GetByID(id);
                return AspNetUser;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<AspNetUser> AspNetUserGetByUserId(string id)
        {
            List<AspNetUser> AspNetUser = new List<AspNetUser>();
            try
            {
                AspNetUser = Context.AspNetUsers.Get(m=>m.Id==id).ToList();
                return AspNetUser;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<AspNetUser> AspNetUserGetByUserEmail(string Email)
        {
            List<AspNetUser> AspNetUser = new List<AspNetUser>();
            try
            {
                AspNetUser = Context.AspNetUsers.Get(m => m.Email == Email).ToList();
                return AspNetUser;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string AspNetUserInsert(AspNetUser AspNetUser)
        {
            string result = string.Empty;
            try
            {
                Context.AspNetUsers.Insert(AspNetUser);
                Context.AspNetUsers.Save();
                result = AspNetUser.Email + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public List<AspNetUserRole> AspNetUserRoleGetAll()
        {
            List<AspNetUserRole> AspNetUserRole = new List<Entity.Entities.AspNetUserRole>();
            try
            {
                AspNetUserRole = Context.AspNetUserRoles.Get().ToList();
                return AspNetUserRole;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public AspNetUserRole AspNetUserRoleGetById(int id)
        {
            AspNetUserRole AspNetUserRole = new Entity.Entities.AspNetUserRole();
            try
            {
                AspNetUserRole = Context.AspNetUserRoles.GetByID(id);
                return AspNetUserRole;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<AspNetUserRole> AspNetUserRoleLoc_Anth_Id(long id)
        {
            List<AspNetUserRole> AspNetUserRole = new List<AspNetUserRole>();
            try
            {
                AspNetUserRole = Context.AspNetUserRoles.Get(m=>m.Loc_Auth_Id==id).ToList();
                return AspNetUserRole;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string AspNetUserRoleInsert(AspNetUserRole AspNetUserRole)
        {
            string result = string.Empty;
            try
            {
                Context.AspNetUserRoles.Insert(AspNetUserRole);
                Context.AspNetUserRoles.Save();
                result = AspNetUserRole.UserId + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string AspNetUserRoleUpdate(AspNetUserRole AspNetUserRole)
        {
            string result = string.Empty;
            try
            {
                Context.AspNetUserRoles.Update(AspNetUserRole);
                Context.AspNetUserRoles.Save();
                result = AspNetUserRole.RoleId + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public string AspNetUserUpdate(AspNetUser AspNetUser)
        {
            string result = string.Empty;
            try
            {
                Context.AspNetUsers.Update(AspNetUser);
                Context.AspNetUsers.Save();
                result = AspNetUser.Email + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public List<tbl_EnquiryAuthentication> EnquiryAuthenticationGetAll()
        {
            List<tbl_EnquiryAuthentication> EnquiryAuthentication = new List<Entity.Entities.tbl_EnquiryAuthentication>();
            try
            {
                EnquiryAuthentication = Context.EnquiryAuthentication.Get().ToList();
                return EnquiryAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public tbl_EnquiryAuthentication EnquiryAuthenticationGetById(int id)
        {
            tbl_EnquiryAuthentication EnquiryAuthentication = new Entity.Entities.tbl_EnquiryAuthentication();
            try
            {
                EnquiryAuthentication = Context.EnquiryAuthentication.GetByID(id);
                return EnquiryAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_EnquiryAuthentication> EnquiryAuthenticationLoc_Auth_Id(long id)
        {
            List<tbl_EnquiryAuthentication> EnquiryAuthentication = new List<tbl_EnquiryAuthentication>();
            try
            {
                EnquiryAuthentication = Context.EnquiryAuthentication.Get(m=>m.Loc_Auth_Id==id).ToList();
                return EnquiryAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string EnquiryAuthenticationInsert(tbl_EnquiryAuthentication EnquiryAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.EnquiryAuthentication.Insert(EnquiryAuthentication);
                Context.EnquiryAuthentication.Save();
                result = EnquiryAuthentication.Id + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string EnquiryAuthenticationUpdate(tbl_EnquiryAuthentication EnquiryAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.EnquiryAuthentication.Update(EnquiryAuthentication);
                Context.EnquiryAuthentication.Save();
                result = EnquiryAuthentication.Id + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public List<tbl_LocationAuthentication> LocationAuthenticationGetAll()
        {
            List<tbl_LocationAuthentication> LocationAuthentication = new List<Entity.Entities.tbl_LocationAuthentication>();
            try
            {
                LocationAuthentication = Context.LocationAuthentication.Get().ToList();
                return LocationAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public tbl_LocationAuthentication LocationAuthenticationGetById(int id)
        {
            tbl_LocationAuthentication LocationAuthentication = new Entity.Entities.tbl_LocationAuthentication();
            try
            {
                LocationAuthentication = Context.LocationAuthentication.GetByID(id);
                return LocationAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_LocationAuthentication> LocationAuthenticationGetByEmail(string Email)
        {
            List<tbl_LocationAuthentication> LocationAuthentication = new List<tbl_LocationAuthentication>();
            try
            {
                LocationAuthentication = Context.LocationAuthentication.Get(x => x.Email == Email).ToList();
                return LocationAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string LocationAuthenticationInsert(tbl_LocationAuthentication LocationAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.LocationAuthentication.Insert(LocationAuthentication);
                Context.LocationAuthentication.Save();
                result = LocationAuthentication.Id + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string LocationAuthenticationUpdate(tbl_LocationAuthentication LocationAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.LocationAuthentication.Update(LocationAuthentication);
                Context.LocationAuthentication.Save();
                result = LocationAuthentication.Id + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public List<tbl_MasterDataAuthentication> MasterDataAuthenticationGetAll()
        {
            List<tbl_MasterDataAuthentication> MasterDataAuthentication = new List<Entity.Entities.tbl_MasterDataAuthentication>();
            try
            {
                MasterDataAuthentication = Context.MasterDataAuthentication.Get().ToList();
                return MasterDataAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public tbl_MasterDataAuthentication MasterDataAuthenticationGetById(int id)
        {
            tbl_MasterDataAuthentication MasterDataAuthentication = new Entity.Entities.tbl_MasterDataAuthentication();
            try
            {
                MasterDataAuthentication = Context.MasterDataAuthentication.GetByID(id);
                return MasterDataAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_MasterDataAuthentication> MasterDataAuthenticationLoc_Auth_Id(long id)
        {
            List<tbl_MasterDataAuthentication> MasterDataAuthentication = new List<tbl_MasterDataAuthentication>();
            try
            {
                MasterDataAuthentication = Context.MasterDataAuthentication.Get(m => m.Loc_Auth_Id==id).ToList();
                return MasterDataAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string MasterDataAuthenticationInsert(tbl_MasterDataAuthentication MasterDataAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.MasterDataAuthentication.Insert(MasterDataAuthentication);
                Context.MasterDataAuthentication.Save();
                result = MasterDataAuthentication.Id + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string MasterDataAuthenticationUpdate(tbl_MasterDataAuthentication MasterDataAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.MasterDataAuthentication.Update(MasterDataAuthentication);
                Context.MasterDataAuthentication.Save();
                result = MasterDataAuthentication.Id + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public List<tbl_SetupAuthentication> SetupAuthenticationGetAll()
        {
            List<tbl_SetupAuthentication> SetupAuthentication = new List<Entity.Entities.tbl_SetupAuthentication>();
            try
            {
                SetupAuthentication = Context.SetupAuthentication.Get().ToList();
                return SetupAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public tbl_SetupAuthentication SetupAuthenticationGetById(int id)
        {
            tbl_SetupAuthentication SetupAuthentication = new Entity.Entities.tbl_SetupAuthentication();
            try
            {
                SetupAuthentication = Context.SetupAuthentication.GetByID(id);
                return SetupAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_SetupAuthentication> SetupAuthenticationLoc_Auth_Id(long id)
        {
            List<tbl_SetupAuthentication> SetupAuthentication = new List<tbl_SetupAuthentication>();
            try
            {
                SetupAuthentication = Context.SetupAuthentication.Get(m=>m.Loc_Auth_Id==id).ToList();
                return SetupAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string SetupAuthenticationInsert(tbl_SetupAuthentication SetupAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.SetupAuthentication.Insert(SetupAuthentication);
                Context.SetupAuthentication.Save();
                result = SetupAuthentication.Id + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string SetupAuthenticationUpdate(tbl_SetupAuthentication SetupAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.SetupAuthentication.Update(SetupAuthentication);
                Context.SetupAuthentication.Save();
                result = SetupAuthentication.Id + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }

        public List<tbl_TrasactionsAuthentication> TrasactionsAuthenticationGetAll()
        {
            List<tbl_TrasactionsAuthentication> TrasactionsAuthentication = new List<Entity.Entities.tbl_TrasactionsAuthentication>();
            try
            {
                TrasactionsAuthentication = Context.TrasactionsAuthentication.Get().ToList();
                return TrasactionsAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public tbl_TrasactionsAuthentication TrasactionsAuthenticationGetById(int id)
        {
            tbl_TrasactionsAuthentication TrasactionsAuthentication = new Entity.Entities.tbl_TrasactionsAuthentication();
            try
            {
                TrasactionsAuthentication = Context.TrasactionsAuthentication.GetByID(id);
                return TrasactionsAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<tbl_TrasactionsAuthentication> TrasactionsAuthenticationLoc_Auth_Id(long id)
        {
            List<tbl_TrasactionsAuthentication> TrasactionsAuthentication = new List<tbl_TrasactionsAuthentication>();
            try
            {
                TrasactionsAuthentication = Context.TrasactionsAuthentication.Get(m=>m.Loc_Auth_Id==id).ToList();
                return TrasactionsAuthentication;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public string TrasactionsAuthenticationInsert(tbl_TrasactionsAuthentication TrasactionsAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.TrasactionsAuthentication.Insert(TrasactionsAuthentication);
                Context.TrasactionsAuthentication.Save();
                result = TrasactionsAuthentication.Id + "Insert Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
            }
            return result;
        }

        public string TrasactionsAuthenticationUpdate(tbl_TrasactionsAuthentication TrasactionsAuthentication)
        {
            string result = string.Empty;
            try
            {
                Context.TrasactionsAuthentication.Update(TrasactionsAuthentication);
                Context.TrasactionsAuthentication.Save();
                result = TrasactionsAuthentication.Id + "Update Successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }


        public string SaveAuthentication(UserAuthenticationModel UserAuthenticationModel,string UserLocations,string ManagerLocations)
        {
            string result = string.Empty;
            try
            {
                bool LocationAuthenticationCheck = false;
                bool MasterDataAuthenticationCheck = false;
                bool TrasactionsAuthenticationCheck = false;
                bool EnquiryAuthenticationCheck = false;
                bool SetupAuthenticationCheck = false;
                bool AspNetUserRoleCheck = false;

                List<tbl_LocationAuthentication> LocationAuthentication;
                LocationAuthentication = this.LocationAuthenticationGetByEmail(UserAuthenticationModel.Email);
                tbl_LocationAuthentication Location = new tbl_LocationAuthentication();
                if (LocationAuthentication == null || LocationAuthentication.Count==0)
                {
                    Location.UserId = UserAuthenticationModel.UserId;
                    Location.User_Locations = UserLocations;
                    Location.Manager_Locations = ManagerLocations;
                    Location.Email = UserAuthenticationModel.Email;
                }
                else
                {
                    LocationAuthenticationCheck = true;
                    LocationAuthentication.FirstOrDefault().UserId = UserAuthenticationModel.UserId;
                    LocationAuthentication.FirstOrDefault().User_Locations = UserLocations;
                    LocationAuthentication.FirstOrDefault().Manager_Locations = ManagerLocations;
                    LocationAuthentication.FirstOrDefault().Email = UserAuthenticationModel.Email;
                }

                // LocationAuthentication
                if (LocationAuthenticationCheck)
                {
                    this.LocationAuthenticationUpdate(LocationAuthentication.FirstOrDefault());
                }
                else
                {
                    this.LocationAuthenticationInsert(Location);
                }


                List<tbl_LocationAuthentication> CLocationAuth = this.LocationAuthenticationGetByEmail(UserAuthenticationModel.Email);
                UserAuthenticationModel.Loc_Auth_Id = CLocationAuth.FirstOrDefault().Id;

                List<AspNetUser> Users = this.AspNetUserGetByUserId(UserAuthenticationModel.UserId);
                if(Users.Count>0)
                {
                    Users.FirstOrDefault().Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    this.AspNetUserUpdate(Users.FirstOrDefault());

                }

                List<AspNetUserRole> AspNetUserRole = this.AspNetUserRoleLoc_Anth_Id(UserAuthenticationModel.Loc_Auth_Id);
                AspNetUserRole IUAspNetUserRole = new Entity.Entities.AspNetUserRole();
                if(AspNetUserRole==null || AspNetUserRole.Count==0)
                {
                    IUAspNetUserRole.UserId = UserAuthenticationModel.UserId;
                    IUAspNetUserRole.RoleId = UserAuthenticationModel.RoleId;
                    IUAspNetUserRole.Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                }
                else
                {
                    AspNetUserRoleCheck = true;
                    AspNetUserRole.FirstOrDefault().UserId= UserAuthenticationModel.UserId;
                    AspNetUserRole.FirstOrDefault().RoleId= UserAuthenticationModel.RoleId;
                    AspNetUserRole.FirstOrDefault().Loc_Auth_Id= UserAuthenticationModel.Loc_Auth_Id;
                }

                if(AspNetUserRoleCheck)
                {
                    this.AspNetUserRoleUpdate(AspNetUserRole.FirstOrDefault());
                }
                else
                {
                    this.AspNetUserRoleInsert(IUAspNetUserRole);
                }

                //MasterDataAuthentication
                List<tbl_MasterDataAuthentication> MasterDataAuthentication;
                MasterDataAuthentication = this.MasterDataAuthenticationLoc_Auth_Id(UserAuthenticationModel.Loc_Auth_Id);
                tbl_MasterDataAuthentication MasterData = new tbl_MasterDataAuthentication();
                if (MasterDataAuthentication == null || MasterDataAuthentication.Count == 0)
                {
                    MasterData.Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    MasterData.Location = UserAuthenticationModel.Location;
                    MasterData.Terminal = UserAuthenticationModel.Terminal;
                    MasterData.Storage = UserAuthenticationModel.Storage;
                    MasterData.Vendor = UserAuthenticationModel.Vendor;
                    MasterData.Customer = UserAuthenticationModel.Customer;
                    MasterData.Category = UserAuthenticationModel.Category;
                    MasterData.SubCategory = UserAuthenticationModel.SubCategory;
                    MasterData.UOM = UserAuthenticationModel.UOM;
                    MasterData.Material = UserAuthenticationModel.Material;
                    MasterData.Price = UserAuthenticationModel.Price;
                    MasterData.LocationPrice = UserAuthenticationModel.LocationPrice;
                    MasterData.Users = UserAuthenticationModel.Users;
                    MasterData.City = UserAuthenticationModel.City;
                    MasterData.Region = UserAuthenticationModel.Region;
                    MasterData.Country = UserAuthenticationModel.Country;
                }
                else
                {
                    MasterDataAuthenticationCheck = true;

                    MasterDataAuthentication.FirstOrDefault().Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    MasterDataAuthentication.FirstOrDefault().Location = UserAuthenticationModel.Location;
                    MasterDataAuthentication.FirstOrDefault().Terminal = UserAuthenticationModel.Terminal;
                    MasterDataAuthentication.FirstOrDefault().Storage = UserAuthenticationModel.Storage;
                    MasterDataAuthentication.FirstOrDefault().Vendor = UserAuthenticationModel.Vendor;
                    MasterDataAuthentication.FirstOrDefault().Customer = UserAuthenticationModel.Customer;
                    MasterDataAuthentication.FirstOrDefault().Category = UserAuthenticationModel.Category;
                    MasterDataAuthentication.FirstOrDefault().SubCategory = UserAuthenticationModel.SubCategory;
                    MasterDataAuthentication.FirstOrDefault().UOM = UserAuthenticationModel.UOM;
                    MasterDataAuthentication.FirstOrDefault().Material = UserAuthenticationModel.Material;
                    MasterDataAuthentication.FirstOrDefault().Price = UserAuthenticationModel.Price;
                    MasterDataAuthentication.FirstOrDefault().LocationPrice = UserAuthenticationModel.LocationPrice;
                    MasterDataAuthentication.FirstOrDefault().Users = UserAuthenticationModel.Users;
                    MasterDataAuthentication.FirstOrDefault().City = UserAuthenticationModel.City;
                    MasterDataAuthentication.FirstOrDefault().Region = UserAuthenticationModel.Region;
                    MasterDataAuthentication.FirstOrDefault().Country = UserAuthenticationModel.Country;
                }

               

                // TrasactionsAuthentication
                List<tbl_TrasactionsAuthentication> TrasactionsAuthentication;
                TrasactionsAuthentication = this.TrasactionsAuthenticationLoc_Auth_Id(UserAuthenticationModel.Loc_Auth_Id);
                tbl_TrasactionsAuthentication Trasaction = new tbl_TrasactionsAuthentication();
                if (TrasactionsAuthentication==null || TrasactionsAuthentication.Count==0)
                {
                    Trasaction.Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    Trasaction.SalesOrder = UserAuthenticationModel.TSalesOrder;
                    Trasaction.POReceive = UserAuthenticationModel.TPOReceive;
                    Trasaction.ReturnToSupplier = UserAuthenticationModel.TReturnToSupplier;
                    Trasaction.TranfterToDisplay = UserAuthenticationModel.TTranfterToDisplay;
                    Trasaction.TransfterIN = UserAuthenticationModel.TTransfterIN;
                    Trasaction.TransfterOUT = UserAuthenticationModel.TTransfterOUT;
                    Trasaction.PhysicalInventory = UserAuthenticationModel.TPhysicalInventory;
                    Trasaction.PuchaseOrder = UserAuthenticationModel.TPuchaseOrder;
                    Trasaction.CashCollection = UserAuthenticationModel.TCashCollection;
                    Trasaction.ProductionOrder = UserAuthenticationModel.TProductionOrder;
                }
                else
                {
                    TrasactionsAuthenticationCheck = true;

                    TrasactionsAuthentication.FirstOrDefault().Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    TrasactionsAuthentication.FirstOrDefault().SalesOrder = UserAuthenticationModel.TSalesOrder;
                    TrasactionsAuthentication.FirstOrDefault().POReceive = UserAuthenticationModel.TPOReceive;
                    TrasactionsAuthentication.FirstOrDefault().ReturnToSupplier = UserAuthenticationModel.TReturnToSupplier;
                    TrasactionsAuthentication.FirstOrDefault().TranfterToDisplay = UserAuthenticationModel.TTranfterToDisplay;
                    TrasactionsAuthentication.FirstOrDefault().TransfterIN = UserAuthenticationModel.TTransfterIN;
                    TrasactionsAuthentication.FirstOrDefault().TransfterOUT = UserAuthenticationModel.TTransfterOUT;
                    TrasactionsAuthentication.FirstOrDefault().PhysicalInventory = UserAuthenticationModel.TPhysicalInventory;
                    TrasactionsAuthentication.FirstOrDefault().PuchaseOrder = UserAuthenticationModel.TPuchaseOrder;
                    TrasactionsAuthentication.FirstOrDefault().CashCollection = UserAuthenticationModel.TCashCollection;
                    TrasactionsAuthentication.FirstOrDefault().ProductionOrder = UserAuthenticationModel.TProductionOrder;
                }
               

                // EnquiryAuthentication
                List<tbl_EnquiryAuthentication> EnquiryAuthentication;
                EnquiryAuthentication = this.EnquiryAuthenticationLoc_Auth_Id(UserAuthenticationModel.Loc_Auth_Id);
                tbl_EnquiryAuthentication Enquiry = new tbl_EnquiryAuthentication();
                if (EnquiryAuthentication==null || EnquiryAuthentication.Count==0)
                {
                    Enquiry.Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    Enquiry.SalesOrder = UserAuthenticationModel.SalesOrder;
                    Enquiry.POReceive = UserAuthenticationModel.POReceive;
                    Enquiry.ReturnToSupplier = UserAuthenticationModel.ReturnToSupplier;
                    Enquiry.TranfterToDisplay = UserAuthenticationModel.TranfterToDisplay;
                    Enquiry.PhysicalInventory = UserAuthenticationModel.PhysicalInventory;
                    Enquiry.TransfterIN = UserAuthenticationModel.TransfterIN;
                    Enquiry.TransfterOUT = UserAuthenticationModel.TransfterOUT;
                    Enquiry.EOD = UserAuthenticationModel.EOD;
                }
                else
                {
                    EnquiryAuthenticationCheck = true;

                    EnquiryAuthentication.FirstOrDefault().Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    EnquiryAuthentication.FirstOrDefault().SalesOrder = UserAuthenticationModel.SalesOrder;
                    EnquiryAuthentication.FirstOrDefault().POReceive = UserAuthenticationModel.POReceive;
                    EnquiryAuthentication.FirstOrDefault().ReturnToSupplier = UserAuthenticationModel.ReturnToSupplier;
                    EnquiryAuthentication.FirstOrDefault().TranfterToDisplay = UserAuthenticationModel.TranfterToDisplay;
                    EnquiryAuthentication.FirstOrDefault().TransfterIN = UserAuthenticationModel.TransfterIN;
                    EnquiryAuthentication.FirstOrDefault().PhysicalInventory = UserAuthenticationModel.PhysicalInventory;
                    EnquiryAuthentication.FirstOrDefault().TransfterOUT = UserAuthenticationModel.TransfterOUT;
                    EnquiryAuthentication.FirstOrDefault().EOD = UserAuthenticationModel.EOD;
                }
              

                // SetupAuthentication
                List<tbl_SetupAuthentication> SetupAuthentication;
                SetupAuthentication = this.SetupAuthenticationLoc_Auth_Id(UserAuthenticationModel.Loc_Auth_Id);
                tbl_SetupAuthentication Setup = new tbl_SetupAuthentication();
                if (SetupAuthentication == null || SetupAuthentication.Count == 0)
                {
                    Setup.Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    Setup.ChangePassword = UserAuthenticationModel.ChangePassword;
                    Setup.AddUsers = UserAuthenticationModel.AddUsers;
                    Setup.UsersAuthentication = UserAuthenticationModel.UsersAuthentication;
                    Setup.Reports = UserAuthenticationModel.Reports;
                    Setup.ProductionOrderStatusReport = UserAuthenticationModel.ProductionOrderStatusReport;
                    Setup.LostOpporTunitySalesReport = UserAuthenticationModel.LostOpporTunitySalesReport;
                }
                else
                {
                    SetupAuthenticationCheck = true;


                    SetupAuthentication.FirstOrDefault().Loc_Auth_Id = UserAuthenticationModel.Loc_Auth_Id;
                    SetupAuthentication.FirstOrDefault().ChangePassword = UserAuthenticationModel.ChangePassword;
                    SetupAuthentication.FirstOrDefault().AddUsers = UserAuthenticationModel.AddUsers;
                    SetupAuthentication.FirstOrDefault().UsersAuthentication = UserAuthenticationModel.UsersAuthentication;
                    SetupAuthentication.FirstOrDefault().Reports = UserAuthenticationModel.Reports;
                    SetupAuthentication.FirstOrDefault().ProductionOrderStatusReport = UserAuthenticationModel.ProductionOrderStatusReport;
                    SetupAuthentication.FirstOrDefault().LostOpporTunitySalesReport = UserAuthenticationModel.LostOpporTunitySalesReport;
                }
              

               

                if(MasterDataAuthenticationCheck)
                {
                    this.MasterDataAuthenticationUpdate(MasterDataAuthentication.FirstOrDefault());
                }
                else
                {
                    this.MasterDataAuthenticationInsert(MasterData);
                }
                if(TrasactionsAuthenticationCheck)
                {
                    this.TrasactionsAuthenticationUpdate(TrasactionsAuthentication.FirstOrDefault());
                }
                else
                {
                    this.TrasactionsAuthenticationInsert(Trasaction);
                }
                if(EnquiryAuthenticationCheck)
                {
                    this.EnquiryAuthenticationUpdate(EnquiryAuthentication.FirstOrDefault());
                }
                else
                {
                    this.EnquiryAuthenticationInsert(Enquiry);
                }
                if(SetupAuthenticationCheck)
                {
                    this.SetupAuthenticationUpdate(SetupAuthentication.FirstOrDefault());
                }
                else
                {
                    this.SetupAuthenticationInsert(Setup);
                }
                result = "User Security added successfully...";
            }
            catch (Exception ex)
            {
                result = "Error...";
                throw;
            }
            return result;
        }


        public UserAuthenticationModel SelectUserAuthentication(string UserId,string Email)
        {
            UserAuthenticationModel UserAuthenticationModel = new UserAuthenticationModel();
            try
            {
                List<Proc_SelectUserAuthentication_Result> SelectUsers = Context.Proc_SelectUserAuthentication(UserId, Email);
                if(SelectUsers.Count>0)
                {
                    
                    UserAuthenticationModel.AddUsers =Convert.ToBoolean(SelectUsers.FirstOrDefault().AddUsers);
                    UserAuthenticationModel.UserId = SelectUsers.FirstOrDefault().UserId;
                    UserAuthenticationModel.Email = SelectUsers.FirstOrDefault().Email;
                    UserAuthenticationModel.Loc_Auth_Id = SelectUsers.FirstOrDefault().LId;
                    UserAuthenticationModel.UserId = SelectUsers.FirstOrDefault().UserId;
                    UserAuthenticationModel.SalesOrder = Convert.ToBoolean(SelectUsers.FirstOrDefault().SalesOrder);
                    UserAuthenticationModel.POReceive = Convert.ToBoolean(SelectUsers.FirstOrDefault().POReceive);
                    UserAuthenticationModel.ReturnToSupplier = Convert.ToBoolean(SelectUsers.FirstOrDefault().ReturnToSupplier);
                    UserAuthenticationModel.TranfterToDisplay = Convert.ToBoolean(SelectUsers.FirstOrDefault().TranfterToDisplay);
                    UserAuthenticationModel.TransfterIN = Convert.ToBoolean(SelectUsers.FirstOrDefault().TransfterIN);
                    UserAuthenticationModel.TransfterOUT = Convert.ToBoolean(SelectUsers.FirstOrDefault().TransfterOUT);
                    UserAuthenticationModel.PhysicalInventory = Convert.ToBoolean(SelectUsers.FirstOrDefault().PhysicalInventory);
                    UserAuthenticationModel.EOD = Convert.ToBoolean(SelectUsers.FirstOrDefault().EOD);
                    UserAuthenticationModel.User_Locations = SelectUsers.FirstOrDefault().User_Locations;
                    UserAuthenticationModel.Manager_Locations = SelectUsers.FirstOrDefault().Manager_Locations;
                    UserAuthenticationModel.Location = Convert.ToBoolean(SelectUsers.FirstOrDefault().Location);
                    UserAuthenticationModel.Terminal = Convert.ToBoolean(SelectUsers.FirstOrDefault().Terminal);
                    UserAuthenticationModel.Storage = Convert.ToBoolean(SelectUsers.FirstOrDefault().Storage);
                    UserAuthenticationModel.Vendor = Convert.ToBoolean(SelectUsers.FirstOrDefault().Vendor);
                    UserAuthenticationModel.Customer = Convert.ToBoolean(SelectUsers.FirstOrDefault().Customer);
                    UserAuthenticationModel.Category = Convert.ToBoolean(SelectUsers.FirstOrDefault().Category);
                    UserAuthenticationModel.SubCategory = Convert.ToBoolean(SelectUsers.FirstOrDefault().SubCategory);
                    UserAuthenticationModel.UOM = Convert.ToBoolean(SelectUsers.FirstOrDefault().UOM);
                    UserAuthenticationModel.Material = Convert.ToBoolean(SelectUsers.FirstOrDefault().Material);
                    UserAuthenticationModel.Price = Convert.ToBoolean(SelectUsers.FirstOrDefault().Price);
                    UserAuthenticationModel.LocationPrice = Convert.ToBoolean(SelectUsers.FirstOrDefault().LocationPrice);
                    UserAuthenticationModel.Users = Convert.ToBoolean(SelectUsers.FirstOrDefault().Users);
                    UserAuthenticationModel.City = Convert.ToBoolean(SelectUsers.FirstOrDefault().City);
                    UserAuthenticationModel.Region = Convert.ToBoolean(SelectUsers.FirstOrDefault().Region);
                    UserAuthenticationModel.Country = Convert.ToBoolean(SelectUsers.FirstOrDefault().Country);
                    UserAuthenticationModel.ChangePassword = Convert.ToBoolean(SelectUsers.FirstOrDefault().ChangePassword);
                    UserAuthenticationModel.AddUsers = Convert.ToBoolean(SelectUsers.FirstOrDefault().AddUsers);
                    UserAuthenticationModel.UsersAuthentication = Convert.ToBoolean(SelectUsers.FirstOrDefault().UsersAuthentication);
                    UserAuthenticationModel.TSalesOrder = Convert.ToBoolean(SelectUsers.FirstOrDefault().TSalesOrder);
                    UserAuthenticationModel.TPOReceive = Convert.ToBoolean(SelectUsers.FirstOrDefault().TPOReceive);
                    UserAuthenticationModel.TReturnToSupplier = Convert.ToBoolean(SelectUsers.FirstOrDefault().TReturnToSupplier);
                    UserAuthenticationModel.TTranfterToDisplay = Convert.ToBoolean(SelectUsers.FirstOrDefault().TTranfterToDisplay);
                    UserAuthenticationModel.TTransfterIN = Convert.ToBoolean(SelectUsers.FirstOrDefault().TTransfterIN);
                    UserAuthenticationModel.TTransfterOUT = Convert.ToBoolean(SelectUsers.FirstOrDefault().TTransfterOUT);
                    UserAuthenticationModel.TPhysicalInventory = Convert.ToBoolean(SelectUsers.FirstOrDefault().TPhysicalInventory);
                    UserAuthenticationModel.TPuchaseOrder = Convert.ToBoolean(SelectUsers.FirstOrDefault().TPuchaseOrder);
                    UserAuthenticationModel.TCashCollection = Convert.ToBoolean(SelectUsers.FirstOrDefault().TCashCollection);
                    UserAuthenticationModel.TProductionOrder = Convert.ToBoolean(SelectUsers.FirstOrDefault().TProductionOrder);
                    UserAuthenticationModel.Reports = Convert.ToBoolean(SelectUsers.FirstOrDefault().Reports);
                    UserAuthenticationModel.ProductionOrderStatusReport = Convert.ToBoolean(SelectUsers.FirstOrDefault().ProductionOrderStatusReport);
                    UserAuthenticationModel.LostOpporTunitySalesReport = Convert.ToBoolean(SelectUsers.FirstOrDefault().LostOpporTunitySalesReport);


                    UserAuthenticationModel.lstLocations = LocationBL.GetAll();
                    UserAuthenticationModel.lstAspNetUsers = this.AspNetUserGetAll();
                    UserAuthenticationModel.lstAspNetRole = this.AspNetRoleGetAll();
                    UserAuthenticationModel.lstUseridsbyManager = this.SelectUserId(HttpContext.Current.User.Identity.Name);

                }
                else
                {
                    UserAuthenticationModel.lstLocations = LocationBL.GetAll();
                    UserAuthenticationModel.lstAspNetUsers = this.AspNetUserGetAll();
                    UserAuthenticationModel.lstAspNetRole = this.AspNetRoleGetAll();
                    UserAuthenticationModel.lstUseridsbyManager = this.SelectUserId(HttpContext.Current.User.Identity.Name);
                }
                return UserAuthenticationModel;
            }
            catch (Exception ex)
            {
                return null;
               
            }
        }

        public List<Proc_AspNetUsersLocations_Result> AspNetUserLocationAuthentication(string EmailId)
        {
            return Context.Proc_AspNetUsersLocations(EmailId);
        }
        public List<Proc_AspNetManagerLocations_Result> AspNetManagerLocationAuthentication(string EmailId)
        {
            return Context.Proc_AspNetManagerLocations(EmailId);
        }
        public List<Proc_SelectUserId_Result> SelectUserId(string ManagerEmail)
        {
            return Context.SelectUserId(ManagerEmail);
        }


    }
}

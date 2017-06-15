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
using System.Web;



namespace POS.Business.BusinessComponents
{
    ///Created by Srikanth Kotnala on 8/6/2016
    ///<summary>
    ///Business logic for POS Location
    /// </summary>
   
    public class LocationBL : UserAuthenticationModel,ILocation
    {
        
        public string EmailID { get; set; }
        public string UserAuthentication { get; set; }
        Context Context;
        /// <summary>
        /// Initialize Base Context Model
        /// </summary>
        public LocationBL()
        {
            Context = new Context();
        }

        /// <summary>
        /// Get all location from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Location> GetAll()
        {
            AuthenticationBL AuthenticationBL = new AuthenticationBL();
            List<tbl_Location> Locations=new List<tbl_Location>();
            try
            {
                EmailID = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                if (EmailID == "admin@pinkyz.com")
                {
                    if (Locations == null)
                    {
                        if (Locations.Count == 0)
                        {
                            Locations = Context.Location.Get().ToList();
                        }
                    }
                    else
                    {
                        Locations = new List<tbl_Location>();
                        Locations = Context.Location.Get().ToList();
                    }
                }
                else
                {
                    if (UserAuthentication == "UserAuthentication")
                    {

                        List<Proc_AspNetManagerLocations_Result> Proc_AspNetManagerLocations_Result = new List<Entity.Entities.Proc_AspNetManagerLocations_Result>();
                        Proc_AspNetManagerLocations_Result = AuthenticationBL.AspNetManagerLocationAuthentication(EmailID);

                        foreach (Proc_AspNetManagerLocations_Result item in Proc_AspNetManagerLocations_Result)
                        {
                            tbl_Location UserLocation = new tbl_Location();
                            UserLocation.LocationID = item.LocationID;
                            UserLocation.LocationDesc = item.LocationDesc;
                            Locations.Add(UserLocation);
                        }
                    }
                    else
                    {
                        List<Proc_AspNetUsersLocations_Result> Proc_AspNetUsersLocations_Result = new List<Entity.Entities.Proc_AspNetUsersLocations_Result>();
                        Proc_AspNetUsersLocations_Result = AuthenticationBL.AspNetUserLocationAuthentication(EmailID);

                        foreach (Proc_AspNetUsersLocations_Result item in Proc_AspNetUsersLocations_Result)
                        {
                            tbl_Location UserLocation = new tbl_Location();
                            UserLocation.LocationID = item.LocationID;
                            UserLocation.LocationDesc = item.LocationDesc;
                            Locations.Add(UserLocation);
                        }
                    }
                }
               
                
                return Locations;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Locations = null;
            }

        }

        /// <summary>
        /// Get one loaction by location ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Location GetByID(string id)
        {
            tbl_Location Location;
            try
            {
                Location = Context.Location.GetByID(id);
                return Location;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                //Location = null;
                // Context = null;
            }

        }

        /// <summary>
        /// Insert location by location model
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string Insert(tbl_Location location)
        {
            try
            {
                Context.Location.Insert(location);
                Context.Location.Save();
                return location.LocationDesc + " Inserted Successfully!!";
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return "Error in saving details, Please try again!!";
            }
            finally
            {
                // Context = null;
            }

        }

        /// <summary>
        /// Update location by location model
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string Update(tbl_Location location)
        {
            try
            {
                Context.Location.Update(location);
                Context.Location.Save();
                return location.LocationDesc + " Updated Successfully!!";
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return "Error in saving details, Please try again!!";
            }
            finally
            {
                // Context = null;
            }

        }

        /// <summary>
        /// Delete location by id
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool DeleteByID(int id)
        {
            try
            {
                Context.Location.Delete(id);
                Context.Location.Save();
                return true;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return false;
            }
            finally
            {
                // Context = null;
            }

        }
        /// <summary>
        /// Get all City Recodrds -Vinod
        /// </summary>
        /// <returns></returns>
        public List<tbl_City> GetAllCity()
        {
            List<tbl_City> City;
            try
            {
                City = Context.City.Get().ToList();
                return City;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        /// <summary>
        /// Get all Region Records -Vinod
        /// </summary>
        /// <returns></returns>
        public List<tbl_Region> GetAllRegion()
        {
            List<tbl_Region> region;
            try
            {
                region = Context.Region.Get().ToList();
                return region;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public List<tbl_Country> GetallCountry()
        {
            List<tbl_Country> Country;
            try
            {
                Country = Context.Country.Get().ToList();
                return Country;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {

            }
            
        }
        /// <summary>
        /// Delete location by location model
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool DeleteByLocationDetails(tbl_Location location)
        {
            try
            {
                Context.Location.Delete(location);
                Context.Location.Save();
                return true;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return false;
            }
            finally
            {
                // Context = null;
            }

        }

        /// <summary>
        /// Insert or Update in tbl_Location table -Srikanth 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string InsertOrUpdate(LocationModel LM)
        {
            string result = string.Empty;
            bool isExist = false;
            tbl_Location location;
            location = this.GetByID(LM.LocationID.Trim());
            if (location != null)
            {
                isExist = true;
            }
            else
            {
                location = new tbl_Location();
            }
            location.LocationID = LM.LocationID;
            location.LocationDesc = LM.LocationDesc;
            location.Address1 = LM.Address1;
            location.Address2 = LM.Address2;
            location.Address3 = LM.Address3;
            location.POBox = LM.POBox;
            location.Contact = LM.Contact;
            location.Phone = LM.Phone;
            location.Fax = LM.Fax;
            location.Email = LM.Email;
            location.City = LM.City;
            location.Region = LM.Region;
            location.Country = LM.Country;
            location.FieldArea = LM.FieldArea;
            location.CashLoan = LM.CashLoan;
            if (!isExist)
            {

                return result = this.Insert(location);
            }
            else
            {
                return result = this.Update(location);
            }
        }

        /// <summary>
        /// Get All LocationModel
        /// </summary>
        /// <returns></returns>
        public LocationModel MLocationModel()
        {
            LocationModel LocationModel;
            List<tbl_City> City;
            List<tbl_Region> Region;
            List<tbl_Country> Country;
            List<tbl_Location> Location;
            try
            {
                LocationModel = new LocationModel();
                City = this.GetAllCity().ToList();
                Region = this.GetAllRegion().ToList();
                Country = this.GetallCountry().ToList();
                Location = this.GetAll().ToList();

                LocationModel.MCity = City;
                LocationModel.MRegion = Region;
                LocationModel.MCountry = Country;
                LocationModel.MLocation = Location;

                return LocationModel;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                City = null;
                Region = null;
                Country = null;
            }
        }

        public LocationModel MLocationModelById(string LocationID)
        {
            LocationModel LocationModel;
            List<tbl_City> City;
            List<tbl_Region> Region;
            List<tbl_Country> Country;
            List<tbl_Location> Location;
            tbl_Location LocationById;
            try
            {
                LocationModel = new LocationModel();
                City = this.GetAllCity().ToList();
                Region = this.GetAllRegion().ToList();
                Country = this.GetallCountry().ToList();
                Location = this.GetAll().ToList();
                LocationById = this.GetByID(LocationID);

                LocationModel.MCity = City;
                LocationModel.MRegion = Region;
                LocationModel.MCountry = Country;
                LocationModel.MLocation = Location;
                LocationModel.ByLocationID = LocationById;

                return LocationModel;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                City = null;
                Region = null;
                Country = null;
            }
        }
        public List<string> GetAllLocationID()
        {
            return Context.Location.Get().Select(e => e.LocationID.Trim()).ToList();
        }
    }
}

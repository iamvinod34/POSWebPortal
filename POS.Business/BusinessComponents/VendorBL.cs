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
   public class VendorBL
    {
        Context Context;
        public VendorBL()
        {
            Context = new Context();
        }
        /// <summary>
        /// Get all Vendor from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Vendor> GetVendorAll()
        {
            List<tbl_Vendor> Vendor;
            try
            {
                Vendor = Context.Vendor.Get().ToList();
                return Vendor;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Vendor = null;
            }

        }
        /// <summary>
        /// Get All City 
        /// </summary>
        /// <returns></returns>
        public List<tbl_City> GetCityAll()
        {
            List<tbl_City> City;
            try
            {
                City = Context.City.Get().ToList();
                return City;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                City = null;
            }

        }
        /// <summary>
        /// Get All Country
        /// </summary>
        /// <returns></returns>
        public List<tbl_Country> GetCountryAll()
        {
            List<tbl_Country> Country;
            try
            {
                Country = Context.Country.Get().ToList();
                return Country;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Country = null;
            }

        }
        public List<tbl_Region> GetRegionAll()
        {
            List<tbl_Region> Region;
            try
            {
                Region = Context.Region.Get().ToList();
                return Region;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Region = null;
            }

        }
        /// <summary>
        /// Get one Vendor by Vendor ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Vendor GetByID(string id)
        {
            tbl_Vendor Vendor;
            try
            {
                Vendor = Context.Vendor.GetByID(id);
                return Vendor;
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
        /// Insert Terminal by Terminal model
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public string Insert(tbl_Vendor vendor)
        {
            try
            {
                Context.Vendor.Insert(vendor);
                Context.Vendor.Save();
                return vendor.VendorID+ " Inserted Successfully!!";
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
        /// Update Vendir by Vendor model
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public string Update(tbl_Vendor vendor)
        {
            try
            {
                Context.Vendor.Update(vendor);
                Context.Vendor.Save();
                return vendor.VendorID+ " Updated Successfully!!";
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
        /// Delete Terminal by LocationID,TerminalID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool DeleteByID(string VendorId)
        {
            try
            {
                Context.Vendor.Delete(VendorId);
                Context.Vendor.Save();
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
        /// Insert or Update in tbl_Vendor table -Vinod 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string InsertOrUpdate(VendorModel VM)
        {
            string result = string.Empty;
            bool IsExist = false;
            tbl_Vendor Vendor;
            Vendor = this.GetByID(VM.VendorID);

            Vendor.VendorID = VM.VendorID;
            Vendor.Name1 = VM.Name1;
            Vendor.Address1 = VM.Address1;
            Vendor.Address2 = VM.Address2;
            Vendor.Address3 = VM.Address3;
            Vendor.POBox = VM.POBox;
            Vendor.Contact = VM.Contact;
            Vendor.Phone = VM.Phone;
            Vendor.Fax = VM.Fax;
            Vendor.Email = VM.Email;
            Vendor.City = VM.City;
            Vendor.Region = VM.Region;
            Vendor.Country = VM.Country;

            if (Vendor!=null)
            {
                IsExist = true;
            }
            else
            {
                Vendor = new tbl_Vendor();
            }
            if (!IsExist)
            {
                return result = this.Insert(Vendor);
            }
            else
            {
                 return result = this.Update(Vendor);
            }
        }
        /// <summary>
        /// Vendor Model Class Model Folder
        /// </summary>
        /// <returns></returns>
        public VendorModel GetVendor()
        {
            List<tbl_City> City;
            List<tbl_Vendor> Vendor;
            List<tbl_Region> Region;
            List<tbl_Country> Country;
            VendorModel VendorModel;
            try
            {
                VendorModel = new VendorModel();
                City = this.GetCityAll();
                Vendor = this.GetVendorAll();
                Region = this.GetRegionAll();
                Country = this.GetCountryAll();

                VendorModel.LCity = City;
                VendorModel.LVendor = Vendor;
                VendorModel.LRegion = Region;
                VendorModel.LCountry = Country;

                return VendorModel;

            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                City = null;
                Vendor = null;
                Region = null;
                Country = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Util.Model;
using POS.Repository.UnitOfWork;

namespace POS.Business.BusinessComponents
{
   public class CountryBL
    {
        Context Context;
        public CountryBL()
        {
            Context = new Context();
        }
        /// <summary>
        /// Get All Country -Vinod
        /// </summary>
        /// <returns></returns>
        public List<tbl_Country> GetAll()
        {
            List<tbl_Country> Country;
            try
            {
                Country = Context.Country.Get().ToList();
                return Country;
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
        /// Get By ID Country Table
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        public tbl_Country GetById(int CountryID)
        {
            tbl_Country Country;
            try
            {
                Country = Context.Country.GetByID(CountryID);
                return Country;
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
        /// Insert Region
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public string Insert(tbl_Country country)
        {
            try
            {
                Context.Country.Insert(country);
                Context.Country.Save();
                return country.CountryID + " Inserted Successfully!!";
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
        /// Update Region
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public string Update(tbl_Country country)
        {
            try
            {
                Context.Country.Update(country);
                Context.Country.Save();
                return country.CountryID + " Updated Successfully!!";
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
        public CountryModel CountryModel()
        {
            CountryModel MCountry;
            List<tbl_Country> Country;
            try
            {
                MCountry = new Util.Model.CountryModel();
                Country = this.GetAll();
                MCountry.lstCountry = Country;
               // MCountry.Country = Country;

                return MCountry;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                Country = null;
            }
        }
        public string InsertOrUpdate(CountryModel CM)
        {
            string result = string.Empty;
            bool IsExsit = false;
            tbl_Country Country;
            Country = this.GetById(CM.CountryID);
            if (Country != null)
            {
                IsExsit = true;
            }
            else
            {
                Country = new tbl_Country();
            }
            Country.CountryID = CM.CountryID;
            Country.CountryName = CM.CountryName;
            if (!IsExsit)
            {
                return result = this.Insert(Country);
            }
            else
            {
                return result = this.Update(Country);
            }
        }
    }
}

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
   public class CityBL
    {
        Context Context;
        public CityBL()
        {
            Context = new Context();
        }
        /// <summary>
        /// Get All City -Vinod
        /// </summary>
        /// <returns></returns>
        public List<tbl_City> GetAll()
        {
            List<tbl_City> City;
            try
            {
                City = Context.City.Get().ToList();
                return City;
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
        /// Get By ID City Table
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public tbl_City GetById(string CityID)
        {
            tbl_City City;
            try
            {
                City = Context.City.GetByID(CityID);
                return City;
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
        /// Insert City
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        public string Insert(tbl_City city)
        {
            try
            {
                Context.City.Insert(city);
                Context.City.Save();
                return city.CityID+ " Inserted Successfully!!";
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
        /// Update City
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        public string Update(tbl_City city)
        {
            try
            {
                Context.City.Update(city);
                Context.City.Save();
                return city.CityID+ " Updated Successfully!!";
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

        public CityModel MCity()
        {
            CityModel ModelCity;
            List<tbl_City> City;
            try
            {
                ModelCity = new CityModel();
                City = this.GetAll();
                ModelCity.lstCity = this.GetAll();
              //  ModelCity.City = City;

                return ModelCity;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                //City = null;
            }
        }
        public string InsertOrUpdate(CityModel CM)
        {
            string result = string.Empty;
            bool IsExsit = false;
            tbl_City City;
            City = this.GetById(CM.CityID.Trim());
            if(City!=null)
            {
                IsExsit = true;
            }
            else
            {
                City = new tbl_City();
            }
            City.CityID = CM.CityID;
            City.CityName = CM.CityName;
            if(!IsExsit)
            {
                return result = this.Insert(City);
            }
            else
            {
                return result = this.Update(City);
            }
        }
    }
}

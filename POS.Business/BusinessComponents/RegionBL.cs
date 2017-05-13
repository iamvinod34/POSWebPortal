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
   public class RegionBL
    {
        Context Context;
        public RegionBL()
        {
            Context = new Context();
        }
        /// <summary>
        /// Get All Region -Vinod
        /// </summary>
        /// <returns></returns>
        public List<tbl_Region> GetAll()
        {
            List<tbl_Region> Region;
            try
            {
                Region = Context.Region.Get().ToList();
                return Region;
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
        /// Get By ID Region Table
        /// </summary>
        /// <param name="RegionID"></param>
        /// <returns></returns>
        public tbl_Region GetById(int RegionID)
        {
            tbl_Region Region;
            try
            {
                Region = Context.Region.GetByID(RegionID);
                return Region;
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
        /// <param name="Region"></param>
        /// <returns></returns>
        public string Insert(tbl_Region region)
        {
            try
            {
                Context.Region.Insert(region);
                Context.Region.Save();
                return region.RegionID + " Inserted Successfully!!";
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
        /// <param name="Region"></param>
        /// <returns></returns>
        public string Update(tbl_Region region)
        {
            try
            {
                Context.Region.Update(region);
                Context.Region.Save();
                return region.RegionID + " Updated Successfully!!";
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
        public RegionModel RegionModel()
        {
            RegionModel MRegion;
            List<tbl_Region> Region;
            try
            {
                MRegion = new Util.Model.RegionModel();
                Region = this.GetAll();

                MRegion.Region = Region;

                return MRegion;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Region = null;
            }
        }
        public string InsertOrUpdate(RegionModel RM)
        {
            string result = string.Empty;
            bool IsExsit = false;
            tbl_Region Region;
            Region = this.GetById(RM.RegionID);
            if (Region != null)
            {
                IsExsit = true;
            }
            else
            {
                Region = new tbl_Region();
            }
            Region.RegionID = RM.RegionID;
            Region.RegionName = RM.RegionName;
            if (!IsExsit)
            {
                return result = this.Insert(Region);
            }
            else
            {
                return result = this.Update(Region);
            }
        }
    }
}

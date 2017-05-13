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
   public class SubCategoryBL
    {
        Context Context;
        public SubCategoryBL()
        {
            Context = new Context();
        }
        /// <summary>
        /// Get all Sub Category from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_SubCategory> GetSubCategoryAll()
        {
            List<tbl_SubCategory> SubCategory;
            try
            {
                SubCategory = Context.SubCategory.Get().ToList();
                return SubCategory;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
              //  SubCategory = null;
            }

        }

        /// <summary>
        /// Get all Category from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Category> GetCategoryAll()
        {
            List<tbl_Category> Category;
            try
            {
                Category = Context.Category.Get().ToList();
                return Category;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                //  SubCategory = null;
            }

        }
        /// <summary>
        /// Get one Sub Category by Category ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_SubCategory GetByID(string id)
        {
            tbl_SubCategory SubCategory;
            try
            {
                SubCategory = Context.SubCategory.GetByID(id);
                return SubCategory;
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
        /// Insert Sub Category
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public string Insert(tbl_SubCategory subcategory)
        {
            try
            {
                Context.SubCategory.Insert(subcategory);
                Context.SubCategory.Save();
                return subcategory.SubCategoryID + " Inserted Successfully!!";
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
        /// Update Sub Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public string Update(tbl_SubCategory subcategory)
        {
            try
            {
                Context.SubCategory.Update(subcategory);
                Context.SubCategory.Save();
                return subcategory.SubCategoryID + " Updated Successfully!!";
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
        /// Delete Sub Category ID by 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByID(string id)
        {
            try
            {
                Context.SubCategory.Delete(id);
                Context.SubCategory.Save();
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
        /// Insert or Update in tbl_Location table -vinod 
        /// </summary>
        /// <param name="Sub Category"></param>
        /// <returns></returns>
        public string InsertOrUpdate(SubCategoryModel SCM)
        {
            string result = string.Empty;
            bool isExist = false;
            tbl_SubCategory subcategory;
            subcategory = this.GetByID(SCM.SubCategoryID.Trim());
            if (subcategory != null)
            {
                isExist = true;
            }
            else
            {
                subcategory = new tbl_SubCategory();
            }
            subcategory.CategoryID = SCM.CategoryID;
            subcategory.SubCategoryID = SCM.SubCategoryID;
            subcategory.SubCategoryDesc = SCM.SubCategoryDesc;
            if (!isExist)
            {

                return result = this.Insert(subcategory);
            }
            else
            {
                return result = this.Update(subcategory);
            }
        }

        public SubCategoryModel SubCategoryM()
        {
            SubCategoryModel SubCategoryModel;
            List<tbl_Category> Category = null;
            List<tbl_SubCategory> SubCategory = null;
            try
            {
                SubCategoryModel = new SubCategoryModel();

                Category = this.GetCategoryAll();
                SubCategory = this.GetSubCategoryAll();

                SubCategoryModel.Category = Category;
                SubCategoryModel.SubCategory = SubCategory;

                return SubCategoryModel;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                Category = null;
                SubCategory = null;
            }
        }
    }
}

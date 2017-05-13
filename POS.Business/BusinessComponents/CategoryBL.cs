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
    public class CategoryBL
    {
        Context Context;
        public CategoryBL()
        {
            Context = new Context();
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
                Category = null;
            }

        }
        /// <summary>
        /// Get one Category by Category ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Category GetByID(string id)
        {
            tbl_Category Category;
            try
            {
                Category = Context.Category.GetByID(id);
                return Category;
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
        public string Insert(tbl_Category category)
        {
            try
            {
                Context.Category.Insert(category);
                Context.Category.Save();
                return category.CategoryID + " Inserted Successfully!!";
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
        public string Update(tbl_Category category)
        {
            try
            {
                Context.Category.Update(category);
                Context.Category.Save();
                return category.CategoryID + " Updated Successfully!!";
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
        /// Delete Category ID by 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool DeleteByID(string id)
        {
            try
            {
                Context.Category.Delete(id);
                Context.Category.Save();
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
        public string InsertOrUpdate(CategoryModel CM)
        {
            string result = string.Empty;
            bool isExist = false;
            tbl_Category category;
            category = this.GetByID(CM.CategoryID.Trim());
            if (category != null)
            {
                isExist = true;
            }
            else
            {
                category = new tbl_Category();
            }
            category.CategoryID = CM.CategoryID;
            category.CategoryDesc = CM.CategoryDesc;
            if (!isExist)
            {

                return result = this.Insert(category);
            }
            else
            {
                return result = this.Update(category);
            }
        }
    }
}

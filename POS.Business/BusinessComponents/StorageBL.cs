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
using POS.Util.Enum;

namespace POS.Business.BusinessComponents
{
    /// Created by Vinod kumar 16/08/2016
    /// <summary>
    /// Business Logic for Storage
    /// </summary>
    public class StorageBL : IStorage
    {
        Context Context;
        /// <summary>
        /// Initialize Base Context Model
        /// </summary>
        public StorageBL()
        {
            Context = new Context();
        }

        /// <summary>
        /// Get all storage from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Storage> GetAll()
        {
            List<tbl_Storage> storage;
            try
            {
                storage = Context.Storage.Get().ToList();
                return storage;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                storage = null;
            }

        }

        /// <summary>
        /// Get All Location 
        /// </summary>
        /// <returns></returns>
        public List<tbl_Location> GetAllLocation()
        {
            List<tbl_Location> location;
            try
            {
                location = Context.Location.Get().ToList();
                return location;
            }
            catch (Exception ex)
            {
                //POS Log Exception to db table

                return null;
            }
            finally
            {
                location = null;
            }
        }

        /// <summary>
        /// Get one storage by Storage ID and LocationID
        /// </summary>
        /// <param name="storageid"></param>
        /// <param name="locationid"></param>
        /// <returns></returns>
        public List<tbl_Storage> GetByID(string Slocationid)
        {
            List<tbl_Storage> storage;
            try
            {
                storage = Context.Storage.Get(e => e.LocationID == Slocationid.Trim()).ToList();
                return storage;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                // storage = null;
                // Context = null;
            }

        }

        public List<tbl_Storage> GetByParamId(string Slocationid, string StorageId)
        {
            List<tbl_Storage> storage;
            try
            {
                storage = Context.Storage.Get(e => e.LocationID == Slocationid.Trim() && e.StorageID == StorageId).ToList();
                return storage;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                // storage = null;
                // Context = null;
            }

        }

        /// <summary>
        /// Insert Storage by Storage model
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public string Insert(tbl_Storage storage)
        {
            try
            {
                Context.Storage.Insert(storage);
                Context.Storage.Save();
                return storage.LocationID + "," + storage.StorageID + " Inserted Successfully!!";
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
        /// Update storage by storage model
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public string Update(tbl_Storage storage)
        {
            try
            {
                Context.Storage.Update(storage);
                Context.Storage.Save();
                return storage.StorageID + "," + storage.LocationID + " Updated Successfully!!";
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
        /// Delete storage by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByID(int id)
        {
            try
            {
                Context.Storage.Delete(id);
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
        /// Delete storage by storage model
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public bool DeleteByLocationDetails(tbl_Storage storage)
        {
            try
            {
                Context.Storage.Delete(storage);
                Context.Storage.Save();
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
        /// Insert or Update in tbl_Storage table -Vinod 
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public string InsertOrUpdate(tbl_Storage storage)
        {
            if (storage.StorageID == "D")
            {
                storage.StorageName = StorageEnum.Display.ToString();
            }
            else if (storage.StorageID == "S")
            {
                storage.StorageName = StorageEnum.Store.ToString();
            }
            storage.StorageType = string.Empty;
            List<tbl_Storage> CurrentStorage = this.GetByParamId(storage.LocationID.Trim(), storage.StorageID.Trim());
            string result = string.Empty;
            if (CurrentStorage == null || CurrentStorage.Count == 0)
            {
                return result = this.Insert(storage);
            }
            else
            {
                //return result = this.Update(storage);
            }
            return result;
        }

        /// <summary>
        /// Get Storage
        /// </summary>
        /// <returns></returns>
        public LocationStorageModel GetStorage()
        {
            List<Proc_LoadGetLocationStorage_Result> LoadGetStorage;
            List<tbl_Storage> Storages;
            LocationStorageModel locStorageModel;
            try
            {
                LoadGetStorage = Context.GetAllStorage().ToList();
                Storages = Context.Storage.Get().ToList();
                locStorageModel = new LocationStorageModel();
                locStorageModel.StorageLocation = LoadGetStorage;
                locStorageModel.Storages = Storages;
                return locStorageModel;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                LoadGetStorage = null;
                Storages = null;
                locStorageModel = null;
            }
        }
        public LocationStorageModel GetStorageById(string LocationID)
        {
            List<Proc_LoadStorageGetById_Result> LoadGetStorage;
            List<tbl_Storage> Storages;
            LocationStorageModel locStorageModel;
            try
            {
                locStorageModel = new LocationStorageModel();

                LoadGetStorage = Context.GetStorageById(LocationID).ToList();
                Storages= this.GetByID(LocationID);

                locStorageModel.Storages = Storages;

                if (LoadGetStorage != null)
                {
                    locStorageModel.LocationID = LoadGetStorage.FirstOrDefault().LocationID;
                    locStorageModel.LocationDesc = LoadGetStorage.FirstOrDefault().LocationDesc;
                }
                else
                {
                    locStorageModel.LocationID = null;
                    locStorageModel.LocationDesc = null;
                }
                return locStorageModel;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //LoadGetStorage = null;
                //Storages = null;
                //locStorageModel = null;
            }
        }
    }
}

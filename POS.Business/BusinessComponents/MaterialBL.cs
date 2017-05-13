using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Repository;
using POS.Repository.UnitOfWork;
using POS.Util.Model;

namespace POS.Business.BusinessComponents
{
    public class MaterialBL
    {
        ///Created by Vinod
        ///<summary>
        ///Business logic for POS Terminal
        /// </summary>
        Context Context;

        public MaterialBL()
        {
            Context = new Context();
        }


        /// <summary>
        /// Get all Material from POS database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Material> GetAll()
        {
            List<tbl_Material> Material;
            try
            {
                Material = Context.Material.Get().ToList();
                return Material;
            }
            catch (Exception ex)
            {

                //POS Log Exception to db table

                return null;
            }
            finally
            {
                Material = null;
            }

        }
        /// <summary>
        /// Get one material by material ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<tbl_Material> GetByID(string id)
        {
            List<tbl_Material> Material;
            try
            {
                Material = Context.Material.Get(e => e.MaterialID == id).ToList();
                return Material;
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
        /// Insert material by material model
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public string Insert(tbl_Material material)
        {
            try
            {
                Context.Material.Insert(material);
                Context.Material.Save();
                return material.MaterialID + " Inserted Successfully!!";
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
        /// Update terminal by terminal model
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public string Update(tbl_Material material)
        {
            try
            {
                Context.Material.Update(material);
                Context.Material.Save();
                return material.MaterialID + " Updated Successfully!!";
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
        /// <param name="MaterialID"></param>
        /// <returns></returns>
        public bool DeleteByID(string MaterialID)
        {
            try
            {
                Context.Material.Delete(MaterialID);
                Context.Material.Save();
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
        /// Get All Category List
        /// </summary>
        /// <returns></returns>
        public List<tbl_Category> GetAllCategory()
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
                // Category = null;
            }
        }

        public List<tbl_SubCategory> GetAllSubCategory()
        {
            List<tbl_SubCategory> SubCategory;
            try
            {
                SubCategory = Context.SubCategory.Get().ToList();
                return SubCategory;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<tbl_Vendor> GetAllVendor()
        {
            List<tbl_Vendor> Vendor;
            try
            {
                Vendor = Context.Vendor.Get().ToList();
                return Vendor;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public List<tbl_UOM> GetAllUOM()
        {
            List<tbl_UOM> UOM;
            try
            {
                UOM = Context.UOM.Get().ToList();
                return UOM;
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
        /// Insert or Update in tbl_material table -Vinod 
        /// </summary>
        /// <param name="Material"></param>
        /// <returns></returns>
        public string InsertOrUpdate(tbl_Material material)
        {
            string result = string.Empty;

            return result;
        }

        public MaterialModel GetMterialModel()
        {
            List<tbl_Category> Category;
            List<tbl_SubCategory> SubCategory;
            List<tbl_Vendor> Vendor;
            MaterialModel MaterialModel;
            List<tbl_Material> Material;
            List<tbl_UOM> UOM;
            try
            {
                MaterialModel = new MaterialModel();
                Category = this.GetAllCategory();
                SubCategory = this.GetAllSubCategory();
                Vendor = this.GetAllVendor();
                Material = this.GetAll();
                UOM = this.GetAllUOM();

                MaterialModel.GetAllCategory = Category;
                MaterialModel.GetAllSubCategory = SubCategory;
                MaterialModel.GetAllVendor = Vendor;
                MaterialModel.GetAllMaterial = Material;
                MaterialModel.MUOM = UOM;

                return MaterialModel;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Category = null;
                SubCategory = null;
                Vendor = null;
            }
        }
        public string InsertMaterialEAN(tbl_MaterialEAN MaterialEAN)
        {
            try
            {
                Context.MaterialEAN.Insert(MaterialEAN);
                Context.MaterialEAN.Save();
                return MaterialEAN.EAN13 + " Inserted Successfully!!";
            }
            catch (Exception ex)
            {
                return "Error in saving details, Please try again!!";
            }
            finally
            {

            }
        }
        public string InsertPreforUOM(tbl_PreferUOM PreforUOM)
        {
            try
            {
                Context.PreforUOM.Insert(PreforUOM);
                Context.PreforUOM.Save();
                return PreforUOM.EAN13 + " Inserted Successfully!!";
            }
            catch (Exception ex)
            {
                return "Error in saving details, Please try again!!";
            }
            finally
            {

            }
        }
        public string InsertUpdateMaterial(MaterialModel MaterialModel)
        {
            List<tbl_Material> material;
            bool IsExsit = false;
            string result = string.Empty;
            try
            {
                material = this.GetByID(MaterialModel.MaterialID).ToList();

                if (material != null && material.Count != 0)
                {
                    IsExsit = true;
                }
                else
                {
                    material = new List<tbl_Material>();
                }

                material.FirstOrDefault().MaterialID = MaterialModel.MaterialID;
                material.FirstOrDefault().MaterialDesc1 = MaterialModel.MaterialDesc1;
                material.FirstOrDefault().MaterialDesc2 = MaterialModel.MaterialDesc2;
                material.FirstOrDefault().ProductURL = MaterialModel.ProductURL;
                material.FirstOrDefault().SubCategoryID = MaterialModel.SubCategoryID;
                material.FirstOrDefault().UpdDate = DateTime.Now;
                material.FirstOrDefault().UserID = MaterialModel.UserID;
                material.FirstOrDefault().VendorID = MaterialModel.VendorID;
                material.FirstOrDefault().AddDate = DateTime.Now;
                material.FirstOrDefault().BaseUOM = MaterialModel.BaseUOM;
                material.FirstOrDefault().CategoryID = MaterialModel.CategoryID;
                material.FirstOrDefault().Cost = MaterialModel.Cost;
               
                if (!IsExsit)
                {
                    Context.Material.Insert(material.FirstOrDefault());
                    Context.Material.Save();
                    result = MaterialModel.MaterialID + "Inserted Successfully";
                }
                else
                {
                    Context.Material.Update(material.FirstOrDefault());
                    Context.Material.Save();
                    result = MaterialModel.MaterialID + "Updated Successfully";
                }
                return result;
            }
            catch (Exception ex)
            {
                return "Error in saving details, Please try again!!";
            }
            finally
            {

            }
        }

        public List<tbl_MaterialEAN> GetByIdMaterialEAN(string EAN13)
        {
            List<tbl_MaterialEAN> MaterialEAN;
            try
            {
                MaterialEAN = Context.MaterialEAN.Get(e => e.EAN13 == EAN13).ToList();
                return MaterialEAN;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public List<tbl_MaterialEAN> GetByIdMaterialEANMaterial(string MaterialID)
        {
            List<tbl_MaterialEAN> MaterialEAN;
            try
            {
                MaterialEAN = Context.MaterialEAN.Get(e => e.MaterialID == MaterialID).ToList();
                return MaterialEAN;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }


        public string InsertUpdateMaterialEAN(MaterialModel MaterialModel)
        {
            try
            {
                List<tbl_MaterialEAN> LMaterialEAN = new List<tbl_MaterialEAN>();
                string result = string.Empty;
                bool IsExsit = false;
                LMaterialEAN = this.GetByIdMaterialEAN(MaterialModel.EAN13);

                tbl_MaterialEAN MaterialEAN = new tbl_MaterialEAN();
                MaterialEAN.MaterialID = MaterialModel.EMaterialID;
                MaterialEAN.UOM = MaterialModel.UOM;
                MaterialEAN.MaterialMix = MaterialModel.MaterialMix;
                MaterialEAN.EAN13 = MaterialModel.EAN13;
                MaterialEAN.ConvertValue = MaterialModel.ConvertValue;
                MaterialEAN.BaseUOM = MaterialModel.EBaseUOM;

                if (LMaterialEAN != null && LMaterialEAN.Count != 0)
                {
                    IsExsit = true;
                }
                else
                {
                    LMaterialEAN = new List<tbl_MaterialEAN>();
                }
                if (!IsExsit)
                {
                    this.InsertMaterialEAN(MaterialEAN);
                    result = MaterialModel.EAN13 + "Inserted SuccessFully";
                }
                else
                {
                    Context.MaterialEAN.Update(MaterialEAN);
                    Context.MaterialEAN.Save();
                    result = MaterialModel.EAN13 + "Updated SuccessFully";
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<tbl_PreferUOM> GetByIDPreforUOM(string MaterialID)
        {
            List<tbl_PreferUOM> PreforUOM;
            try
            {
                PreforUOM = Context.PreforUOM.Get(e => e.MaterialID == MaterialID).ToList();
                return PreforUOM;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<tbl_PriceFile> GetByIDPriceFile(string EAN13)
        {
            List<tbl_PriceFile> PriceFile;
            try
            {
                PriceFile = Context.PriceFile.Get(e => e.EAN13 == EAN13).ToList();
                return PriceFile;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public List<tbl_PriceFile> GetByIDPriceFileMaterial(string MaterialID)
        {
            List<tbl_PriceFile> PriceFile;
            try
            {
                PriceFile = Context.PriceFile.Get(e => e.MaterialID == MaterialID).ToList();
                return PriceFile;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public string InsertUpdatePreforUOM(MaterialModel MaterialModel)
        {
            try
            {
                string result = string.Empty;
                bool IsExsit = false;

                List<tbl_PreferUOM> PreforUOM = new List<tbl_PreferUOM>();
                PreforUOM = this.GetByIDPreforUOM(MaterialModel.MaterialID);

                if (PreforUOM != null && PreforUOM.Count != 0)
                {
                    IsExsit = true;
                }
                else
                {
                    PreforUOM = new List<tbl_PreferUOM>();
                }

                PreforUOM.FirstOrDefault().MaterialID = MaterialModel.MaterialID;
                PreforUOM.FirstOrDefault().UOM = MaterialModel.UOM;
                PreforUOM.FirstOrDefault().Conv = MaterialModel.ConvertValue;
                PreforUOM.FirstOrDefault().EAN13 = MaterialModel.EAN13;
               
                if (!IsExsit)
                {
                    this.InsertPreforUOM(PreforUOM.FirstOrDefault());
                }
                else
                {
                    Context.PreforUOM.Update(PreforUOM.FirstOrDefault());
                    Context.PreforUOM.Save();
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public string InsertUpdatePriceFile(MaterialModel MaterialModel)
        {
            try
            {
                List<tbl_PriceFile> PriceFile = new List<tbl_PriceFile>();
                string result = string.Empty;
                bool IsExsit = false;
                PriceFile = this.GetByIDPriceFile(MaterialModel.EAN13);

                tbl_PriceFile pricefile = new tbl_PriceFile();
                pricefile.MaterialID = MaterialModel.MaterialID;
                pricefile.UOM = MaterialModel.UOM;
                pricefile.EAN13 = MaterialModel.EAN13;
                pricefile.Price = MaterialModel.Price;

                if (PriceFile != null && PriceFile.Count != 0)
                {
                    IsExsit = true;
                }
                else
                {
                    PriceFile = new List<tbl_PriceFile>();
                }
                if (!IsExsit)
                {
                    Context.PriceFile.Insert(pricefile);
                    Context.PriceFile.Save();
                }
                else
                {
                    Context.PriceFile.Update(pricefile);
                    Context.PriceFile.Save();
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<Proc_LoadMaterialDetails_Result> GetByIDMaterial(string MaterialID)
        {
            List<Proc_LoadMaterialDetails_Result> MaterialDetails;
            try
            {
                MaterialDetails = Context.LoadMaterialDetails(MaterialID);
                return MaterialDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }

        }


        public List<tbl_ImageDetails> GetByIDImage(string MaterialID)
        {
            List<tbl_ImageDetails> Image;
            try
            {
                Image = Context.ImageDetails.Get(e => e.ID == MaterialID).ToList();
                return Image;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public string InsertUpdateImage(MaterialModel MaterialModel)
        {
            try
            {
                List<tbl_ImageDetails> Image = new List<tbl_ImageDetails>();
                string result = string.Empty;
                bool IsExsit = false;
                Image = this.GetByIDImage(MaterialModel.ID);

                if (Image != null && Image.Count != 0)
                {
                    IsExsit = true;
                }
                else
                {
                    Image = new List<tbl_ImageDetails>();
                }

                Image.FirstOrDefault().ID = MaterialModel.ID;
                Image.FirstOrDefault().Type = MaterialModel.Type;
                Image.FirstOrDefault().FileName = MaterialModel.FileName;
                Image.FirstOrDefault().RowCreatedDate = MaterialModel.RowCreatedDate;

                
                if (!IsExsit)
                {
                    Context.ImageDetails.Insert(Image.FirstOrDefault());
                    Context.ImageDetails.Save();
                }
                else
                {
                    Context.ImageDetails.Update(Image.FirstOrDefault());
                    Context.ImageDetails.Save();
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
    }
}

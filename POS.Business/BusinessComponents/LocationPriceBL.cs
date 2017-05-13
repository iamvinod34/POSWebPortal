using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Repository.UnitOfWork;
using POS.Util.Model;

namespace POS.Business.BusinessComponents
{
    public class LocationPriceBL
    {
        Context Context;
        public LocationPriceBL()
        {
            Context = new Context();
        }
        public List<tbl_LocationPrice> GetAll()
        {
            List<tbl_LocationPrice> LocationPrice;
            try
            {
                LocationPrice = Context.LocationPrice.Get().ToList();
                return LocationPrice;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<tbl_LocationPrice> GetById(string EAN13,string LocationID)
        {
            List<tbl_LocationPrice> LocationPrice;
            try
            {
                LocationPrice = Context.LocationPrice.Get(e => e.EAN13 == EAN13 && e.LocationID==LocationID).ToList();
                return LocationPrice;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }

        }
        public string Insert(tbl_LocationPrice LocationPrice)
        {
            try
            {
                Context.LocationPrice.Insert(LocationPrice);
                Context.LocationPrice.Save();
                return LocationPrice.EAN13 + " Inserted Successfully!!";
            }
            catch (Exception ex)
            {
                return "Error in saving details, Please try again!!";
            }
            finally
            {

            }
        }
        public string Update(tbl_LocationPrice LocationPrince)
        {
            try
            {
                Context.LocationPrice.Update(LocationPrince);
                Context.LocationPrice.Save();
                return LocationPrince.EAN13 + " Updated Successfully!!";
            }
            catch (Exception ex)
            {
                return "Error in updateing details, Please try again!!";
            }
            finally
            {

            }
        }
        public List<tbl_Material> GetMaterial()
        {
            List<tbl_Material> Material;
            try
            {
                Material = Context.Material.Get().ToList();
                return Material;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<tbl_MaterialEAN> MaterialEAN()
        {
            List<tbl_MaterialEAN> MaterialEAN;
            try
            {
                MaterialEAN = Context.MaterialEAN.Get().ToList();
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
        public List<tbl_Location> Location()
        {
            List<tbl_Location> Location;
            try
            {
                Location = Context.Location.Get().ToList();
                return Location;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<tbl_UOM> UOM()
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
        public LocationPriceModel MLocationPrice()
        {
            LocationPriceModel ModelLocationPrice;
            List<tbl_Material> MMaterial;
            List<tbl_LocationPrice> MLocationPrice;
            List<tbl_MaterialEAN> MMaterialEAN;
            List<tbl_Location> MLocation;
            List<tbl_UOM> MUOM;
            try
            {
                ModelLocationPrice = new LocationPriceModel();
                MMaterial = this.GetMaterial();
                MLocationPrice = this.GetAll();
                MMaterialEAN = this.MaterialEAN();
                MLocation = this.Location();
                MUOM = this.UOM();

                ModelLocationPrice.MLocation = MLocation;
                ModelLocationPrice.MLocationPrice = MLocationPrice;
                ModelLocationPrice.MMaterialEAN = MMaterialEAN;
                ModelLocationPrice.MMaterial = MMaterial;
                ModelLocationPrice.MUOM = MUOM;

                return ModelLocationPrice;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MMaterial = null;
                MLocationPrice = null;
                MMaterialEAN = null;
                MLocation = null;
                MUOM = null;
            }
        }
        public string InsertOrUpdate(LocationPriceModel LPM)
        {
            string result = string.Empty;
            bool IsExsit = false;
            List<tbl_LocationPrice> LocationPrice;
            LocationPrice = this.GetById(LPM.EAN13,LPM.LocationID).ToList();
            if (LocationPrice != null)
            {
                IsExsit = true;
            }
            else
            {
                LocationPrice = new List<tbl_LocationPrice>();
            }
            if (!IsExsit)
            {
                tbl_LocationPrice LocPrice = new tbl_LocationPrice();
                LocPrice.EAN13 = LPM.EAN13;
                LocPrice.LocationID = LPM.LocationID;
                LocPrice.MaterialID = LPM.MaterialID;
                LocPrice.Price = LPM.Price;
                LocPrice.UOM = LPM.UOM;
                LocationPrice.Add(LocPrice);
                return this.Insert(LocPrice);
            }
            else
            {
                tbl_LocationPrice LocPrice = new tbl_LocationPrice();
                LocPrice.EAN13 = LocationPrice.FirstOrDefault().EAN13;
                LocPrice.LocationID = LocationPrice.FirstOrDefault().LocationID;
                LocPrice.MaterialID = LocationPrice.FirstOrDefault().MaterialID;
                LocPrice.Price = LocationPrice.FirstOrDefault().Price;
                LocPrice.UOM = LocationPrice.FirstOrDefault().UOM;
                LocationPrice.Add(LocPrice);
                return this.Update(LocPrice);
            }
        }

        public tbl_MaterialEAN MaterialEANById(string EAN13)
        {
            tbl_MaterialEAN MaterialEAN;
            try
            {
                MaterialEAN = Context.MaterialEAN.GetByID(EAN13);
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
    }
}

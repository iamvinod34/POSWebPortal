using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using POS.Entity.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Util.Model
{
  public  class LocationStorageModel : UserAuthenticationModel
    {
        [Required(ErrorMessage = "* Please Select Storage ID")]
        public string StorageID { get; set; }

        [Required(ErrorMessage = "* Please Enter Location ID")]
        public string LocationID { get; set; }

        public string LocationDesc{ get; set; }

        public List<Proc_LoadGetLocationStorage_Result> StorageLocation;
        public List<tbl_Storage> Storages;
        public List<Proc_LoadStorageGetById_Result> GetStorageById;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }


    }
}

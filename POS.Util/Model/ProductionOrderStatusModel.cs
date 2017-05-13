using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Util.Model
{
  public   class ProductionOrderStatusModel:UserAuthenticationModel
    {
        public string MaterialDesc1 { get; set; }
        public string MaterialID { get; set; }
        public string UOM { get; set; }
        public string CategoryID { get; set; }
        public long ID { get; set; }
        public string UserID { get; set; }
        public string StorageID { get; set; }
        public string Status { get; set; }
        public string LocationID { get; set; }
        public Nullable<decimal> TotalTransQty { get; set; }
        public Nullable<decimal> TotalDeliveryQty { get; set; }

        //public UserAuthenticationModel PublicUserAuthenticationModel { set; get; }
    }
}

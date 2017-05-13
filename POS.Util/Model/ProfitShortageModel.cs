using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Util.Model
{
    public class ProfitShortageModel:UserAuthenticationModel
    {
        public Nullable<int> ID { get; set; }
        public string CategoryId { get; set; }
        public string CategotyDesc { get; set; }
        public Nullable<decimal> TotalTransAmount { get; set; }
        public Nullable<decimal> TotalTransDelAmont { get; set; }
        public Nullable<decimal> DeliveredPer { get; set; }
        public Nullable<decimal> ShortageAmount { get; set; }
        public Nullable<decimal> ShortagePer { get; set; }
        public Nullable<decimal> ProfitAmount { get; set; }
        public Nullable<decimal> ShareOnShortPer { get; set; }
        public Nullable<decimal> ShareonProfitPer { get; set; }

    }
}

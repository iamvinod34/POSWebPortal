using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Util.Model
{
   public class PrintDocument : UserAuthenticationModel
    {
        public List<Proc_DocumentdetailsTenderDetails_Result> SelectDocumentDetails { set; get; }
        public UserAuthenticationModel UserAuthenticationModel { set; get; }

    }
}

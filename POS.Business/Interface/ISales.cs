using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using POS.Util.Model;

namespace POS.Business.Interface
{
    public interface ISales
    {
        SalesEnquiryModel GetEnquiries();
    }
}

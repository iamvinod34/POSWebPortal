using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using POS.Util.Enum;

namespace POS.Util.Model
{
    public class TerminalModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="* Please Select Terminal ID")]
        public string TerminalID { get; set; }
        [Required(ErrorMessage ="* Please Enter Location ID")]
        public string LocationID { get; set; }
        public string LocationDesc { get; set; }

        public List<tbl_Terminal> Terminal;
        public List<Proc_GetAllLTerminal_Result> GetAllTerminal;
        public List<tbl_Location> GetAllLocation;
        public List<Proc_GetMasterTerminal_Result> GetMTerminal;
        public UserAuthenticationModel UserAuthenticationModel { set; get; }


    }
}

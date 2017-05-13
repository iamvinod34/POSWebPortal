using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Util.Model
{
   public class UserModel : UserAuthenticationModel
    {
        [Required(ErrorMessage ="Please Entry User Id")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Please Entry User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Entry 4 digit Password")]
        [MaxLength(4)]
        public string Password { get; set; }
        public string LocationID { get; set; }
        public string Payment { get; set; }
        public string ReturnInv { get; set; }
        public string ReturnNoInv { get; set; }
        public string DeleteInv { get; set; }
        public string Cash { get; set; }
        public string CreditCard { get; set; }
        public string DebitCard { get; set; }
        public string OnAccount { get; set; }
        public string Den1 { get; set; }
        public string Den5 { get; set; }
        public string Den10 { get; set; }
        public string Den20 { get; set; }
        public string Den50 { get; set; }
        public string Den100 { get; set; }
        public string Den500 { get; set; }
        public string HoldInv { get; set; }
        public string unholdInv { get; set; }
        public string Barcode { get; set; }
        public string Inventory { get; set; }
        public string POReceive { get; set; }
        public string ReturnSupp { get; set; }
        public string TransferDisp { get; set; }
        public string TransferIn { get; set; }
        public string TransferOut { get; set; }
        public string PhyInventory { get; set; }
        public string StockReport { get; set; }
        public string Settingbutt { get; set; }
        public string PrinterSetup { get; set; }
        public string EOD { get; set; }
        public string FavoritePannel { get; set; }
        public string LockUser { get; set; }
        public string DeleteItem { get; set; }
        public string Quantity { get; set; }
        public string OrderButton { get; set; }
        public string OrderTextBox { get; set; }
        public string SampleButton { get; set; }
        public string MaterialMenu { get; set; }
        public string ItemCardReportButton { get; set; }
        public string ProductionOrder { get; set; }
        public string Register { get; set; }
        public string TranfterOutToLocationID { get; set; }
        public string Button_Delivery { get; set; }
        public long Id { get; set; }
        public bool ConRead { get; set; }
        public Nullable<bool> DeleteUserId { get; set; }
    }
}

    

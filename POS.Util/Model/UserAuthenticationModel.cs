using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Util.Model
{
  public  class UserAuthenticationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select Email Id")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public System.DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public long Loc_Auth_Id { get; set; }
        public bool PhysicalInventory { get; set; }

        [Required(ErrorMessage = "Please Select Email")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="Please Select Role")]
        public string RoleId { get; set; }


        public bool SalesOrder { get; set; }
        public bool POReceive { get; set; }
        public bool ReturnToSupplier { get; set; }
        public bool TranfterToDisplay { get; set; }
        public bool TransfterIN { get; set; }
        public bool TransfterOUT { get; set; }
        public bool EOD { get; set; }

        public string User_Locations { get; set; }
        public string Manager_Locations { get; set; }

        public bool Location { get; set; }
        public bool Terminal { get; set; }
        public bool Storage { get; set; }
        public bool Vendor { get; set; }
        public bool Customer { get; set; }
        public bool Category { get; set; }
        public bool SubCategory { get; set; }
        public bool UOM { get; set; }
        public bool Material { get; set; }
        public bool Price { get; set; }
        public bool LocationPrice { get; set; }
        public bool Users { get; set; }
        public bool City { get; set; }
        public bool Region { get; set; }
        public bool Country { get; set; }

        public bool Reports { get; set; }

        public bool ChangePassword { get; set; }
        public bool AddUsers { get; set; }
        public bool UsersAuthentication { get; set; }
        public bool ProductionOrderStatusReport { get; set; }
        public bool LostOpporTunitySalesReport { get; set; }

        public bool TSalesOrder { get; set; }
        public bool TPOReceive { get; set; }
        public bool TReturnToSupplier { get; set; }
        public bool TTranfterToDisplay { get; set; }
        public bool TTransfterIN { get; set; }
        public bool TTransfterOUT { get; set; }
        public bool TPhysicalInventory { get; set; }
        public bool TPuchaseOrder { get; set; }
        public bool TCashCollection { get; set; }
        public bool TProductionOrder { get; set; }

        [Required(ErrorMessage ="Please Enter User EmailId")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Address")]
        public string User_EmailID { set; get; }
        [Required(ErrorMessage ="Please Enter Create User Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})",
            ErrorMessage = "must contains one digit from 0-9,one lowercase characters,one uppercase characters,one special symbols in the list '@#$%',length at least 6 characters and maximum of 20")]
        public string Password { set; get; }
        public string ManagerEmailID { set; get; }


        public List<tbl_Location> lstLocations;
        public List<AspNetUser> lstAspNetUsers;
        public List<tbl_ManagerUserAuthentication> lstAspNetManagerUsers;
        public List<Proc_SelectUserId_Result> lstUseridsbyManager;
        public List<AspNetRole> lstAspNetRole;
        public UserAuthenticationModel PublicUserAuthenticationModel { set; get; }

    }
}

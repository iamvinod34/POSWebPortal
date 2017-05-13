using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Business.Interface.ControlPanel
{
    public  interface IAuthentication
    {

        /// <summary>
        /// AspNetRole Interface
        /// </summary>
        /// <param name="AspNetRole"></param>
        /// <returns></returns>
        string AspNetRoleInsert(AspNetRole AspNetRole);
        AspNetRole AspNetRoleGetById(string id);
        List<AspNetRole> AspNetRoleGetAll();
        string AspNetRoleUpdate(AspNetRole AspNetRole);

        /// <summary>
        /// AspNetUser Interface
        /// </summary>
        /// <param name="AspNetRole"></param>
        /// <returns></returns>
        string AspNetUserInsert(AspNetUser AspNetUser);
        AspNetUser AspNetUserGetById(int id);
        List<AspNetUser> AspNetUserGetAll();
        string AspNetUserUpdate(AspNetUser AspNetUser);

        /// <summary>
        /// LocationAuthentication Interface
        /// </summary>
        /// <param name="AspNetRole"></param>
        /// <returns></returns>
        string LocationAuthenticationInsert(tbl_LocationAuthentication LocationAuthentication);
        tbl_LocationAuthentication LocationAuthenticationGetById(int id);
        List<tbl_LocationAuthentication> LocationAuthenticationGetAll();
        string LocationAuthenticationUpdate(tbl_LocationAuthentication LocationAuthentication);

        /// <summary>
        /// MasterDataAuthentication Interface
        /// </summary>
        /// <param name="MasterDataAuthentication"></param>
        /// <returns></returns>
        string MasterDataAuthenticationInsert(tbl_MasterDataAuthentication MasterDataAuthentication);
        tbl_MasterDataAuthentication MasterDataAuthenticationGetById(int id);
        List<tbl_MasterDataAuthentication> MasterDataAuthenticationGetAll();
        string MasterDataAuthenticationUpdate(tbl_MasterDataAuthentication MasterDataAuthentication);


        /// <summary>
        /// TrasactionsAuthentication Interface
        /// </summary>
        /// <param name="TrasactionsAuthentication"></param>
        /// <returns></returns>
        string TrasactionsAuthenticationInsert(tbl_TrasactionsAuthentication TrasactionsAuthentication);
        tbl_TrasactionsAuthentication TrasactionsAuthenticationGetById(int id);
        List<tbl_TrasactionsAuthentication> TrasactionsAuthenticationGetAll();
        string TrasactionsAuthenticationUpdate(tbl_TrasactionsAuthentication TrasactionsAuthentication);

        /// <summary>
        /// EnquiryAuthentication Interface
        /// </summary>
        /// <param name="EnquiryAuthentication"></param>
        /// <returns></returns>
        string EnquiryAuthenticationInsert(tbl_EnquiryAuthentication EnquiryAuthentication);
        tbl_EnquiryAuthentication EnquiryAuthenticationGetById(int id);
        List<tbl_EnquiryAuthentication> EnquiryAuthenticationGetAll();
        string EnquiryAuthenticationUpdate(tbl_EnquiryAuthentication EnquiryAuthentication);

        /// <summary>
        /// SetupAuthentication Interface
        /// </summary>
        /// <param name="SetupAuthentication"></param>
        /// <returns></returns>
        string SetupAuthenticationInsert(tbl_SetupAuthentication SetupAuthentication);
        tbl_SetupAuthentication SetupAuthenticationGetById(int id);
        List<tbl_SetupAuthentication> SetupAuthenticationGetAll();
        string SetupAuthenticationUpdate(tbl_SetupAuthentication SetupAuthentication);


        /// <summary>
        /// AspNetUserRole Interface
        /// </summary>
        /// <param name="AspNetUserRole"></param>
        /// <returns></returns>
        string AspNetUserRoleInsert(AspNetUserRole AspNetUserRole);
        AspNetUserRole AspNetUserRoleGetById(int id);
        List<AspNetUserRole> AspNetUserRoleGetAll();
        string AspNetUserRoleUpdate(AspNetUserRole AspNetUserRole);
    }
}

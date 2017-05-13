using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entity.Entities;

namespace POS.Util.Model
{
    public class SalesEnquiryModel : UserAuthenticationModel
    {
        private DateTime? fromDate;

        public DateTime? FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }


        private DateTime? toDate;

        public DateTime? ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }


        private string terminal;

        public string Terminal
        {
            get { return terminal; }
            set { terminal = value; }
        }

        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }


        private string ean;

        public string EAN
        {
            get { return ean; }
            set { ean = value; }
        }

        private string loacation;

        public string Location
        {
            get { return loacation; }
            set { loacation = value; }
        }


        private List<tbl_Category> category;

        public List<tbl_Category> Categories
        {
            get { return category; }
            set { category = value; }
        }

        private string selctedCategory;

        public string SelectedCategory
        {
            get { return selctedCategory; }
            set { selctedCategory = value; }
        }

        private string selectedSubCategory;

        public string SelectedSubCategory
        {
            get { return selectedSubCategory; }
            set { selectedSubCategory = value; }
        }


        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }


        private string amount;

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private List<pxSelectSalesEnquiry_Result> lstSalesEnquiry;

        public List<pxSelectSalesEnquiry_Result> SalesEnquiries
        {
            get { return lstSalesEnquiry; }
            set { lstSalesEnquiry = value; }
        }

        private List<pxSelectFilterEodEnquiry_Result> lsteodEnquiry;

        public List<pxSelectFilterEodEnquiry_Result> EODEnquiries
        {
            get { return lsteodEnquiry; }
            set { lsteodEnquiry = value; }
        }
        public UserAuthenticationModel UserAuthenticationModel { set; get; }

    }

}

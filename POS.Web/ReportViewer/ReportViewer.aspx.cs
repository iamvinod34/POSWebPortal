using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;
using System.Net;
using Microsoft.Reporting.WebForms;

namespace POS.Web.ReportViewer
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        public string Reportname{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Reportname"] != null)
                {
                    Reportname = Session["Reportname"].ToString();
                    Page.Title = "Report -" + Reportname;
                    CategotyReport(Reportname);
                }
                else
                {
                    Response.Redirect("/Home");
                }
            }
        }
        public void CategotyReport(string ReportName)
        {
            try
            {
                string UserName = ConfigurationManager.AppSettings["RtpUserName"].ToString();
                string Password = ConfigurationManager.AppSettings["RtpPwd"].ToString();
                string Domin = ConfigurationManager.AppSettings["RtpServer"].ToString();

                Microsoft.Reporting.WebForms.IReportServerCredentials irsc =
                new CustomReportCredentials(UserName, Password, Domin);

                rtpVwrCategory.ProcessingMode = ProcessingMode.Remote;

                rtpVwrCategory.ServerReport.ReportServerCredentials = irsc;
                string urlReportServer = "http://"+ Domin + "/ReportServer";
                rtpVwrCategory.ServerReport.ReportServerUrl = new Uri(urlReportServer);

               
                switch (ReportName)
                {
                    case "Category":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Category";
                        break;
                    case "Location":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Location";
                        break;
                    case "Material":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Material";
                        break;
                    case "PhysicalInventoryDetails":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/PhysicalInventory_Details";
                        break;
                    case "PhysicalInventoryDifferendeDetails":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/PhysicalInventory_Differende_Details";
                        break;
                    case "POReceive":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/POReceive";
                        break;
                    case "PriceFile":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/PriceFile";
                        break;
                    case "ReturnToSupplier":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Return_To_Supplier";
                        break;
                    case "StockReceiveDetails":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Stock_Receive_Details";
                        break;
                    case "SubCategory":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Sub_Category";
                        break;
                    case "Terminal":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Terminal";
                        break;
                    case "TransferToDisplay":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Transfer_To_Display";
                        break;
                    case "UOM":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/UOM";
                        break;
                    case "Vendor":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Vendor";
                        break;
                    case "Stock":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/StockReport";
                        break;
                    case "ItemCard":
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/ItemCardReport";
                        break;

                    default:
                        rtpVwrCategory.ServerReport.ReportPath = "/EASYPOS_Reports/Category";
                        break;
                }
               // rtpVwrCategory.ServerReport.Refresh();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
{
    // From: http://community.discountasp.net/default.aspx?f=14&m=15967
    // local variable for network credential.
    private string _UserName;
    private string _PassWord;
    private string _DomainName;
    public CustomReportCredentials(string UserName, string PassWord, string DomainName)
    {
        _UserName = UserName;
        _PassWord = PassWord;
        _DomainName = DomainName;
    }
    public System.Security.Principal.WindowsIdentity ImpersonationUser
    {
        get
        {
            return null;  // not use ImpersonationUser
        }
    }
    public ICredentials NetworkCredentials
    {
        get
        {
            // use NetworkCredentials
            return new NetworkCredential(_UserName, _PassWord, _DomainName);
        }
    }
    public bool GetFormsCredentials(out Cookie authCookie, out string user,
        out string password, out string authority)
    {

        // not use FormsCredentials unless you have implements a custom autentication.
        authCookie = null;
        user = password = authority = null;
        return false;
    }
}
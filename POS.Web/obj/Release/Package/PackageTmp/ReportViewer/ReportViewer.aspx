<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" MasterPageFile="~/ReportViewer/Report_Mater.Master" Inherits="POS.Web.ReportViewer.ReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>







<asp:Content ContentPlaceHolderID="Report" runat="server">
    <div class="container">
        <div class="col-lg-12">
          <%--  <rsweb:ReportViewer ID="rtpVwrCategory" runat="server" Font-Names="Verdana" CssClass="col-lg-12" Width="100%" Font-Size="8pt" Height="780px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False">
            </rsweb:ReportViewer>--%>
            <rsweb:ReportViewer ID="rtpVwrCategory" runat="server" Font-Names="Verdana" CssClass="col-lg-12" Width="100%" Font-Size="8pt" Height="780px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False"></rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>

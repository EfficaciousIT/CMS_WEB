<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmFeePaidTillDate.aspx.cs" Inherits="frmFeePaidTillDate" Title="E-Smarts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <style type="text/css">
        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .selectName
        {
            width: 200px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .search
        {
            border: 1px solid green !important;
            padding: 3px;
        }
        .efficacious_Submit
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 130% !important;
            background: #6cb200;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 36px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
            top: -6px;
        }
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .lalfont
        {
            font-family: Verdana;
            font-size: 12px;
        }
        .mGridnew
        {
            width: 100%;
            background-color: #fff;
            border: solid 0px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGridnew td
        {
            border: solid 1px #c1c1c1;
            color: #717171;
        }
        .mGridnew th
        {
            padding: 4px 2px;
            color: #fff;
            background: #3498db;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .mGridnew tr
        {
            height: 21px;
        }
        .mGridnew .alt
        {
            background: #fff;
        }
        .mGridnew .pgr
        {
            background: #424242;
        }
        .mGridnew .pgr table
        {
            margin: 5px 0;
        }
        .mGridnew .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 0px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGridnew .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGridnew .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
        a
        {
            text-decoration: none;
        }
        a
        {
            text-decoration: none;
        }
        .style1
        {
            margin: 0 auto;
            padding: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header1 pd-0">
       
        <ul class="top_navlg rpt_center">
        <li><a >Report Center <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>     
       
            <li> <a href="frmAdmListStudentDetails.aspx"> Student Details </a></li>
            
                  <li><a href="frmStandardWiseRpt.aspx"> Student Fee Collection</a></li>
                  <li><a href="frmRPTFeecollectionInDate.aspx">Date Wise Collection</a></li>   
                  <li><a href="frmHeadwiseFeeRpt.aspx"> Head Wise Collection</a></li>
                  <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
                  <li><a href="frpRptStdWise.aspx"> Standard wise Fee Collection</a></li>
                  <li class="active1"><a href="frmFeePaidTillDate.aspx"> Fee Collection Till Summary</a></li>
                  <li><a href="frmAbsentSummary.aspx"> Student Attendance Summary</a></li>
                  <li><a href="frmAttendanceSummary.aspx"> Staff Attendance Summary</a></li>                  
                  <li><a href="frmGenderwiseAttendence.aspx"> Gender Wise Abscent Summary</a></li>
                  <li><a href="frmTopScoresStudent.aspx"> Top 10 Scores Student</a></li>
                    <li><a href="TeacherWiseTimeTable.aspx"> Teacher Wise Time Table</a></li>                  
                      <li><a href="StudentWiseTimeTable.aspx"> Student Wise Time Table </a></li>                  
        </ul>
    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px" Visible="false">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Fee Details</HeaderTemplate>
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Head Entry" Visible="false">
                                    <HeaderTemplate>
                                        Head Entry</HeaderTemplate>
                                    <ContentTemplate>
                                        <table class="style1">
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <table width="100%">
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                     <td width="30%">
                                        <asp:Button ID="btnReport" runat="server" CssClass="efficacious_send" 
                                             Text="Report" onclick="btnReport_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="left">
                                        <asp:GridView ID="grdFeeM" ShowFooter="True" runat="server" AutoGenerateColumns="False"
                                            CssClass="table  tabular-table " EmptyDataText="No Fee Paid Yet" Width="100%"
                                            OnRowDataBound="grdFeeM_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Standard">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("Standard")%>'>
                                                        </asp:Label></ItemTemplate>
                                                   <%-- <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="Label2" Text="Grand Total" runat="server" /></div>
                                                    </FooterTemplate>--%>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Student">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("Total Student")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblGrandTotal" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Gross Fee">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrossFee" runat="server" Text='<%#Eval("Gross Fee")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblGross" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Concession" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConcessionH" runat="server" Text='<%#Eval("Concession")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblConcession" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Net fee">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNetFeeH" runat="server" Text='<%#Eval("Net Fee")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblNetFee" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="Due Till Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDueTillH" runat="server" Text='<%#Eval("Due Till Date")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblDueTill" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Recd till date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmountH" runat="server" Text='<%#Eval("Paid Fee")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblAmount" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pending till date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPendingH" runat="server" Text='<%#Eval("Pending Fee")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblPending" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>
                                              <%--  <asp:TemplateField HeaderText="Student">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentH" runat="server" Text='<%#Eval("Student")%>'>
                                                        </asp:Label></ItemTemplate>
                                                    <FooterTemplate>
                                                        <div>
                                                            <asp:Label ID="lblStudent" runat="server" /></div>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
                                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>

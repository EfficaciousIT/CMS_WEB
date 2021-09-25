<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmRPTFeecollectionInDate.aspx.cs" Inherits="frmRPTFeecollectionInDate"
    Title="e-Smarts - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management" %>

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
            background: #3498db;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
            top: 0px;
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
        .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 1px #525252;
            border-collapse: collapse;
            font: 12px Verdana, Helvetica, sans-serif;
        }
        *
        {
            margin: 0;
            padding: 0;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            text-align: center;
            background: rgb(3, 116, 3);
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .mGrid th
        {
            text-align: center !important;
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
        .unwatermarked
        {
            height: 20px;
            width: 100px;
        }
        .watermarked
        {
            height: 20px;
            width: 100px;
            padding: 2px 0 0 2px;
            border: 1px solid #BEBEBE;
            background-color: #F0F8FF;
            color: gray;
        }
        .style2
        {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header1 pd-0">
       
        <ul class="top_navlg rpt_center">
        <li><a >Report Center <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>     
       
            <li> <a href="frmAdmListStudentDetails.aspx"> Student Details </a></li>
            
                  <li><a href="frmStandardWiseRpt.aspx"> Student Fee Collection</a></li>
                  <li class="active1"><a href="frmRPTFeecollectionInDate.aspx">Date Wise Collection</a></li>   
                  <li><a href="frmHeadwiseFeeRpt.aspx"> Head Wise Collection</a></li>
                  <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
                  <li><a href="frpRptStdWise.aspx"> Standard wise Fee Collection</a></li>
                  <li><a href="frmFeePaidTillDate.aspx"> Fee Collection Till Summary</a></li>
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
                                Width="1024px">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Fee Details</HeaderTemplate>
                                    <ContentTemplate>
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
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="4" align="center">
                                                    <table class="style2">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDate" CssClass="input-blue" Width="100px" placeholder="From Date" runat="server"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDate"
                                                                    Enabled="True">
                                                                </asp:CalendarExtender>
                                                                <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFromDate"
                                                                    WatermarkText="From Date" WatermarkCssClass="watermarked" Enabled="True" />--%>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtToDate" runat="server" Width="100px" CssClass="input-blue" placeholder="To Date"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtToDate">
                                                                </asp:CalendarExtender>
                                                                <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                                                    TargetControlID="txtToDate" WatermarkCssClass="watermarked" WatermarkText="To Date">
                                                                </asp:TextBoxWatermarkExtender>--%>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="efficacious_Submit"
                                                                    onclick="btnSearch_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:GridView ID="grdFeeM" runat="server" CssClass="table  tabular-table " EmptyDataText="No Fee Paid Yet"
                                                        Width="80%">
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
                                            <tr><td></td><td></td><td></td><td></td><td></td><td>
                                                        &nbsp; Total Amount : <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                                    </td></tr>
                                        </table>
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

<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmSMSRpt.aspx.cs" Inherits="frmSMSRpt"
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
<div class="content-header">
        <h1>
            SMS Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Report</a></li>
            <li class="active">SMS Details</li>
        </ol>
    </div>
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
                                        SMS Details</HeaderTemplate>
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
                                                              
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtToDate" runat="server" Width="100px" CssClass="input-blue" placeholder="To Date"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtToDate">
                                                                </asp:CalendarExtender>
                                                               
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="efficacious_Submit"
                                                                    onclick="btnSearch_Click" />
                                                            </td>
                                                            <td style="padding-left: 30px;">
                                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                            <ContentTemplate>
                                                              <asp:Button ID="btnReport" runat="server" CssClass="efficacious_Submit" 
                                                                    Text="Excel" onclick="btnReport_Click"  />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnReport" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
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
                                                    <asp:GridView ID="gvSMS" runat="server" CssClass="table  tabular-table " EmptyDataText="No SMS Sent Yet"
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
                                                        &nbsp; Total SMS : <asp:Label ID="lblTotal" runat="server" ></asp:Label>
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
</asp:Content>

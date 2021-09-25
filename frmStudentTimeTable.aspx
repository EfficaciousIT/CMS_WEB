<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmStudentTimeTable.aspx.cs" Inherits="frmStudentTimeTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <link href="css/demo2.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            height: 16px;
        }
        
        .mGrid th
        {
            text-align: center !important;
        }
        
        
        /* default layout */
        .ajax__tab_default .ajax__tab_header
        {
            white-space: normal !important;
        }
        .ajax__tab_default .ajax__tab_outer
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_inner
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
        }
        /* xp theme */
        .ajax__tab_xp .ajax__tab_header
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 11px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_outer
        {
            padding-right: 4px;
            background: #fff;
            height: 21px;
            font-size: 12px;
            padding: 4px 0;
            border: 1px solid #D5D5D5;
            margin-right: 2px;
        }
        .ajax__tab_xp .ajax__tab_inner
        {
            padding-left: 3px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_tab
        {
            height: 13px;
            padding: 4px;
            margin: 0px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_outer
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_inner
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_tab
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_outer
        {
            background: #fff;
            border-right: 1px solid green;
            border-left: 1px solid green;
            border-top: 1px solid green;
            padding: 5px 0;
            border-radius: 5px 5px 0 0;
            margin-right: 2px;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_inner
        {
            background: #fff !important;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_tab
        {
            background: #fff !important;
            color: Green;
            font-size: 12px;
            font-weight: bold;
        }
        .ajax__tab_xp .ajax__tab_disabled
        {
            color: #A0A0A0;
        }
        .ajax__tab_xp .ajax__tab_body
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 10pt;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
        /* scrolling */
        .ajax__scroll_horiz
        {
            overflow-x: scroll;
        }
        .ajax__scroll_vert
        {
            overflow-y: scroll;
        }
        .ajax__scroll_both
        {
            overflow: scroll;
        }
        .ajax__scroll_auto
        {
            overflow: auto;
        }
        /* plain theme */
        .ajax__tab_plain .ajax__tab_outer
        {
            text-align: center;
            vertical-align: middle;
            border: 2px solid #999999;
        }
        .ajax__tab_plain .ajax__tab_inner
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_body
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_header
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_active .ajax__tab_outer
        {
            background: #FFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Time Table
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Study</a></li>
            <li class="active">Time Table</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<ContentTemplate>
            <br />
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" ID="tc1" Width="100%" Height="450px">
                            <asp:TabPanel runat="server" ID="tb1">
                                <HeaderTemplate>
                                    Detail
                                </HeaderTemplate>
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>--%>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textcss"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSTD" runat="server" CssClass="textcss" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDIV" runat="server" Text="DIV" CssClass="textcss"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textcss" OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" valign="top">
                        <asp:GridView ID="grvTimetable" runat="server" AllowPaging="false" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                            Width="100%" OnRowDataBound="grvTimetable_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No" HeaderStyle-Height="20%" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrno" Font-Bold="true" runat="server" Text='<%#Eval("SrNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period Time" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%#Eval("Time")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonday" runat="server" Text='<%#Eval("Monday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tuesday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTuesday" runat="server" Text='<%#Eval("Tuesday")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wednesday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWednesday" runat="server" Text='<%#Eval("Wednesday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thursday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThursday" runat="server" Text='<%#Eval("Thursday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Friday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFriday" runat="server" Text='<%#Eval("Friday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saturday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSaturday" runat="server" Text='<%#Eval("Saturday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BitRecess" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecess" runat="server" Text='<%#Eval("btrecess")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left"></RowStyle>
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

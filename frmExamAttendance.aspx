<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmExamAttendance.aspx.cs" Inherits="frmExamAttendance" Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input[type=text]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            width: 100% !important;
        }
        .style1 input[type=checkbox]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            width: 15px !important;
            float: left !important;
        }
        .efficacious_send
        {
            width: 100% !important;
            background: #9fd727;
            font-size: 16px;
            border: none !important;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            color: #fff;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center !important;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 65%;
            padding: 5px;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .style1 select
        {
            display: block;
            border: 1px solid #3498db;
            width: 20%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .chk
        {
            display: block;
            border: 1px solid #3498db;
            width: 10px;
            padding: 5px;
            float: left;
            height: auto !important;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            width: 16px;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            outline: 0;
            float: left;
        }
        .efficacious input[type=checklist], input[type=radio]
        {
            display: block;
            width: 16px;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            outline: 0;
            float: left;
        }
    </style>
    <style>
        input[type="image"]
        {
            width: 70% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Exam Attendance
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">Exam Attendance</li>
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
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Mark Attendance</HeaderTemplate>
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="padding-left: 70px">
                                                    <table width="80%">
                                                        <tr>
                                                        <td align="center">
                                                                <asp:Label ID="Label3" runat="server" Text="Academic Year"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:DropDownList ID="drpAcademiYear" runat="server" 
                                                                    AutoPostBack="True" 
                                                                    onselectedindexchanged="drpAcademiYear_SelectedIndexChanged">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:DropDownList ID="drpStandardDet" runat="server" OnSelectedIndexChanged="drpStandardDet_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:DropDownList ID="drpDate" AutoPostBack="True" runat="server" OnSelectedIndexChanged="drpDate_SelectedIndexChanged">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 3px; width: 50px;">
                                                    <asp:GridView ID="grdTestSchedule" EmptyDataText="No Records Found" runat="server"
                                                        AutoGenerateColumns="False" DataKeyNames="intTest_id" CssClass="table  tabular-table "
                                                        Width="840px">
                                                        <Columns>
                                                            <asp:TemplateField Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("intTest_id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCtrl" runat="server" AutoPostBack="true" Style="width: 10px;
                                                                        left: 20px;" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="candiateName" HeaderText="Candiate Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtfromTime" HeaderText="From Time">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtToTime" HeaderText="To Time">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="location" HeaderText="Location">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table runat="server" id="Table1">
                                                        <tr id="Tr1" runat="server">
                                                            <td id="Td1" style="padding-bottom: 0px; padding-left: 40px" runat="server">
                                                                <asp:Button ID="Button2" runat="server" CssClass="efficacious_send" Text="Mark "
                                                                    OnClick="Button2_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Visible="false">
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

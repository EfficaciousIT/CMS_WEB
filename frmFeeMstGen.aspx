<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmFeeMstGen.aspx.cs" Inherits="frmFeeMstGen" Title="Fee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 70%;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 70%;
        }
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
            width: 30%;
            background: #3498db;
            font-size: 16px;
            border: none !important;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
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
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .style1 select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
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
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
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
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                    Width="1015px">
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            Fee Master</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table class="style1">
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
                                                        <td align="right" style="position: relative; top: -5px;">
                                                            <asp:Label ID="Label2" runat="server" Text="Academic Year"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpAcademic" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="2015-2016"></asp:ListItem>
                                                                <asp:ListItem Text="2016-2017"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" style="position: relative; top: -5px;">
                                                            <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="drpStandard_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                            </asp:DropDownList>
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
                                                </table>
                                                <table class="style1">
                                                    <tr>
                                                        <td style="background: #3498db; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Particular
                                                        </td>
                                                        <td style="background: #3498db; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Type
                                                        </td>
                                                        <td style="background: #3498db; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Amount
                                                        </td>
                                                        <td>
                                                            &nbsp;
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
                                                        <td align="left">
                                                            <asp:Label ID="Label3" runat="server" Text="Tution"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpTution" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTution" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label4" runat="server" Text="Library"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpLibrary" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLibrary" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label5" runat="server" Text="Computer"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpComputer" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtComputer" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label6" runat="server" Text="Club Activity"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpClubActivity" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtClubActivity" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label7" runat="server" Text="Activity Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpActivityFee" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtActivityFee" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label8" runat="server" Text="Registration Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpRegistrationFee" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRegistrationFee" runat="server" Style="width: 50% !important;
                                                                margin-left: 4%; cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label9" runat="server" Text="Admission Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpAdmissionFee" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAdmissionFee" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label10" runat="server" Text="Security Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpSecurityFee" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSecurityFee" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label11" runat="server" Text="Annual Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpAnnualFee" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAnnualFee" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label12" runat="server" Text="Development Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpDevelopmentFee" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDevelopmentFee" runat="server" Style="width: 50% !important;
                                                                margin-left: 4%; cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label13" runat="server" Text="ID Card Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpICard" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtICard" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label14" runat="server" Text="Magazine Fee"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpMagazine" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMagazine" runat="server" Style="width: 50% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table class="style1">
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
                                                        <td style="background: #3498db; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Particular
                                                        </td>
                                                        <td style="background: #3498db; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Type
                                                        </td>
                                                        <td style="background: #3498db; width: 100px; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Amount
                                                        </td>
                                                        <td style="background: #3498db; color: #fff; font-size: 14px; padding-left: 5px;
                                                            height: 30px;">
                                                            Description
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
                                                        <td align="left">
                                                            <asp:Label ID="Label15" runat="server" Text="Other 1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpOther1" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther1" runat="server" Style="width: 80% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther1Des" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label16" runat="server" Text="Other 2"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpOther2" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther2" runat="server" Style="width: 80% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther2Des" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label17" runat="server" Text="Other 3"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpOther3" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther3" runat="server" Style="width: 80% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther3Des" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label18" runat="server" Text="Other 4"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpOther4" runat="server">
                                                                <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                                <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                <asp:ListItem Text="One Time"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther4" runat="server" Style="width: 80% !important; margin-left: 4%;
                                                                cursor: inherit;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther4Des" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table class="style1">
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
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnSubmit" runat="server" Style="width: 120px; margin-left: 110px;"
                                                                CssClass="efficacious_send" Text="Submit" OnClick="btnSubmit_Click" />
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
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
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel2" Visible="false" runat="server" HeaderText="TabPanel2">
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

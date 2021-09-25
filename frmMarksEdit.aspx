<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmMarksEdit.aspx.cs" Inherits="frmMarksEdit" Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
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
            background: #9fd727;
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
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div>
        <center>
            <table>
                <tr>
                    <td align="left">
                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                            Width="1024px">
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
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="position: relative; top: -5px;">
                                                    <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
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
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="grdCandidate" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                                                        OnRowCancelingEdit="grdCandidate_RowCancelingEdit" OnRowEditing="grdCandidate_RowEditing"
                                                        OnRowUpdating="grdCandidate_RowUpdating">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTest_id" runat="server" Text='<%# Eval("intTest_id") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Candidate Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("candiateName") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtcandiateName" runat="server" Text='<%# Eval("candiateName")%>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="30%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Marks 1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="marks1" runat="server" Text='<%# Eval("marks1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtmarks1" runat="server" Text='<%# Eval("marks1") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Marks 2">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="marks2" runat="server" Text='<%# Eval("marks2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtmarks2" runat="server" Text='<%# Eval("marks2") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Marks 3">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="marks3" runat="server" Text='<%# Eval("marks3") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtmarks3" runat="server" Text='<%# Eval("marks3") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Marks 4">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="marks4" runat="server" Text='<%# Eval("marks4") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtmarks4" runat="server" Text='<%# Eval("marks4") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Marks 5">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="marks5" runat="server" Text='<%# Eval("marks5") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtmarks5" runat="server" Text='<%# Eval("marks5") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" Text="Edit" runat="server" CommandName="Edit" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" Text="Update" runat="server" CommandName="Update" />
                                                                    <asp:LinkButton ID="LinkButton3" Text="Cancel" runat="server" CommandName="Cancel" />
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="20%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
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
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

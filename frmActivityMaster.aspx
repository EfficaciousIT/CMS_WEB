<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmActivityMaster.aspx.cs" Inherits="frmActivityMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>
        .efficacious span
        {
            margin: 0 !important;
            padding: 0 10px 0 0 !important;
            float: right;
            position: relative;
            top: -5px;
        }
        .efficacious_send
        {
            width: 40% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 12px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            text-align: center !important;
        }
    </style>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div style="padding: 5px 0 0 0">
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel ID="tabpanel2" runat="server">
                                    <HeaderTemplate>
                                        List of Activity</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="ssst" runat="server">Standard</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Stdrop1" runat="server" Style="width: 32%;" AutoPostBack="True"
                                                            OnSelectedIndexChanged="Stdrop1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:GridView ID="SubReport" runat="server" OnPageIndexChanging="SubReport_PageIndexChanging"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                            OnRowEditing="SubReport_RowEditing" DataKeyNames="id"
                                                            OnRowDeleting="SubReport_RowDeleting" Width="100%" PageSize="20">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="id" runat="server" Text='  <%# Eval("id")  %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                <%--<asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />--%>
                                                                <asp:BoundField DataField="VchName" HeaderText="Activity Name" ReadOnly="True" />
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 24px !important; outline: 0;"
                                                                            ImageUrl="~/images/edit.png" CommandName="Edit" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 24px !important; outline: 0;"
                                                                            ImageUrl="~/images/delete.png" CommandName="Delete" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                            CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                         Activity Entry</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table style="font-weight: bolder; width: 40%; margin: 10px 0 10px 15px;" align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Standard" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Standard_id" runat="server" Font-Bold="False" 
                                                            AutoPostBack="True" OnSelectedIndexChanged="Standard_id_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Standard_id"
                                                            InitialValue="0" Display="None" ErrorMessage="Please Select Standard"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                               <%-- <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Division" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Division_id" runat="server" Font-Bold="False" >
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Division_id"
                                                            InitialValue="0" Display="None" ErrorMessage="Please Select Division"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                            TargetControlID="RequiredFieldValidator7">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="subj1" runat="server" Text="Subject" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="text1" CssClass="input-blue" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text1"
                                                            Display="None" ErrorMessage="Please Enter Subject"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender1"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="left">
                                                        <table width="80%">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Button ID="Button1" Style="padding-left: 10px" runat="server" Text="Submit"
                                                                        OnClick="Button1_Click" CssClass="efficacious_send" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="Button2" runat="server" Text="Clear" OnClick="Button2_Click" CssClass="efficacious_send"
                                                                        Visible="False" /><asp:HiddenField ID="hid1" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


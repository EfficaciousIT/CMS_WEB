<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmBookType.aspx.cs" Inherits="frmBookType" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Book Type
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
            <li><a ><i ></i>Library Master</a></li>
            <li class="active">Book Type</li>
        </ol>
    </div>

 <style>
        .efficacious_send
        {
            width: 100% !important;
            background: #3498db;
            border: none;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            margin-right: 10px;
            float: none;
            text-align: center;
        }
        .textcss
        {
            font-size: 13px !important;
        }
        .textsize
        {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
    </style>
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="50%" 
                                                                DataKeyNames="intBookType_Id" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing"
                                                                >
                                                                <Columns>
                                                                 <asp:BoundField DataField="vchBookType_Name" HeaderText="Book Type" ReadOnly="True" />
                                                                 <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                           
                                               <table width="36%" style="text-align: right; margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify"> 
                                                            <asp:Label ID="Label2" runat="server" Text="Book Type"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" MaxLength="50" AutoComplete="Off"></asp:TextBox>
                                                            <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtName"
                                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" -" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                           
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>


</asp:Content>


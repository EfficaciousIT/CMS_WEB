<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmCardAssignment.aspx.cs" Inherits="frmCardAssignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
    <div class="content-header">
        <h1>
            Card Assignment
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Library</a></li>
            <li class="active">Card Assignment</li>
        </ol>
    </div>
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
                                                                CssClass="table  tabular-table " PageSize="20" Width="80%" 
                                                                DataKeyNames="intCard_assignment_id" onrowdeleting="grvDetail_RowDeleting1" onrowediting="grvDetail_RowEditing1"
                                                                >
                                                                <Columns>
                                                                 <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intStudent_id" HeaderText="Student Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intLib_card_id" HeaderText="Card No." ReadOnly="True" /> 
                                                                   
                                                                       
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
                                                        <td align="left">
                                                            Standard</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStandard_SelectedIndexChanged" 
                                                                >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                                ControlToValidate="ddlStandard" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Division</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDivisionId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlDivisionId_SelectedIndexChanged" 
                                                                >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                                ControlToValidate="ddlDivisionId" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label3" runat="server" Text="Student Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStudent" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                                ControlToValidate="ddlStudent" ErrorMessage="Please Select Name"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="left">
                                                            Card No.</td>
                                                        <td align="left">
                                                           <%-- <asp:TextBox ID="txtCardNo" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="20"></asp:TextBox>--%>
                                                                 <asp:DropDownList ID="ddlCardNum" runat="server">
                                                            </asp:DropDownList>
                                                                
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                                ControlToValidate="ddlCardNum" Display="None" 
                                                                ErrorMessage="Please Enter Card Number"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                             OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px"
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


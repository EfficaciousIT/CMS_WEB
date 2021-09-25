<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSchoolEquipmentMaster.aspx.cs" Inherits="frmSchoolEquipmentMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
        .efficacious_send
        {
            width: 50% !important;
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
    <div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Inventory Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="#">Store Master</a></li>
             <li class="active1"><a href="frmSchoolEquipmentMaster.aspx">Equipment Master</a></li>
            <li><a href="frmUnitMaster.aspx">Unit Master</a></li>
            <li><a href="frmSchoolInventory.aspx">Inventory Master</a></li>
        </ul>
    </div>
<section class="content">
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server"><HeaderTemplate>Detail
                                    </HeaderTemplate><ContentTemplate>
                                    <center><table width="100%">
                                    <tr><td align="left">
                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" 
                                            AutoGenerateColumns="False" CssClass="table  tabular-table " PageSize="20" Width="80%" 
                                                                DataKeyNames="intEquipment_id" 
                                            onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing" >
                                                                <Columns><asp:BoundField DataField="vchEquipment_name" HeaderText="Equipment Name" ReadOnly="True" />                                                                    
                                                                     <asp:BoundField DataField="vchEquipment_detail" HeaderText="Detail" ReadOnly="True" />                                                                     
                                                                     <asp:BoundField DataField="intSchoolStore_id" HeaderText="Store Name" ReadOnly="True" /> 
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
                                                                                
                                                                                
                                                                                </td></tr></table></center></ContentTemplate></asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>New Entry</HeaderTemplate><ContentTemplate><center><table width="36%" style="text-align: right"><tr><td align="justify">&nbsp;&nbsp;</td><td align="justify">&nbsp;&nbsp;</td></tr><tr><td align="justify">Equipment Name</td><td align="justify"><asp:TextBox 
                                        ID="txtEquipmentName" runat="server" CssClass="input-blue" 
                                                                MaxLength="50" AutoComplete="Off"></asp:TextBox><asp:FilteredTextBoxExtender 
                                        ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtEquipmentName"
                                                                
                                        FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" -" 
                                                                Enabled="True"></asp:FilteredTextBoxExtender></td></tr><tr><td align="left">&nbsp;&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEquipmentName"
                                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td align="left">Details</td><td align="left"><asp:TextBox 
                                            ID="txtEquipmentDetails" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="250" Height="86px" 
                                                TextMode="MultiLine" style = "resize:none" ></asp:TextBox></td></tr><tr><td align="left">&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator16" runat="server" 
                                                                ControlToValidate="txtEquipmentDetails" Display="None" 
                                                                ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td 
                                            align="left">Store name</td><td align="left"><asp:DropDownList 
                                                ID="ddlStoreName" runat="server"></asp:DropDownList></td></tr><tr><td 
                                            align="left">&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlStoreName" 
                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td align="left" colspan="2"><table width="100%"><tr><td align="right" style="padding-left:-20px">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                             OnClientClick="return ConfirmInsertUpdate();" 
                                                onclick="btnSubmit_Click" /></td><td align="left" style="padding-left:10px">
                                                <asp:Button ID="btnClear" runat="server" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" 
                                                    CausesValidation="False" onclick="btnClear_Click" /></td></tr></table></td></tr><tr><td align="center" class="auto-style5" colspan="2">&nbsp;&nbsp;</td></tr></table></center></ContentTemplate></asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</section>
</asp:Content>


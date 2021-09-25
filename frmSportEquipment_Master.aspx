<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSportEquipment_Master.aspx.cs" Inherits="frmSportEquipment_Master" %>
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
 <div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Sports Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmSport_Master.aspx">Teacher Master</a></li>
             <li><a href="frmSportCard_Master.aspx">Card Master</a></li>
            <li><a href="frmSportStore_Master.aspx">Store Master</a></li>
            <li class="active1"><a href="frmSportEquipment_Master.aspx">Equipment Master</a></li>
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
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server"><HeaderTemplate>Detail
                                    </HeaderTemplate><ContentTemplate>
                                    <center><table width="100%">
                                    <tr><td align="left">
                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="80%" 
                                                                DataKeyNames="intEquipment_id" 
                                            onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing"
                                                                >
                                                                <Columns>
                                                                    <asp:BoundField DataField="vchEquipment_name" HeaderText="Equipment Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intEquipment_quantity" HeaderText="Quantity" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intEquipment_price" HeaderText="Price" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchEquipment_detail" HeaderText="Detail" ReadOnly="True" /> 
                                                                     <asp:BoundField DataField="intSport_id" HeaderText="Sport Name" ReadOnly="True" /> 
                                                                     <asp:BoundField DataField="intStore_id" HeaderText="Store Name" ReadOnly="True" /> 
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
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>New Entry</HeaderTemplate><ContentTemplate>
                                    <table width="36%" style="text-align: right;margin:0 0 0 2%;"><tr><td align="justify">&nbsp;&nbsp;</td><td align="justify">&nbsp;&nbsp;</td></tr><tr><td align="justify">Equipment Name</td><td align="justify"><asp:TextBox 
                                        ID="txtEquipmentName" runat="server" CssClass="input-blue" 
                                                                MaxLength="50" AutoComplete="Off"></asp:TextBox><asp:FilteredTextBoxExtender 
                                        ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtEquipmentName"
                                                                
                                        FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" -" 
                                                                Enabled="True"></asp:FilteredTextBoxExtender></td></tr><tr><td align="left">&nbsp;&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEquipmentName"
                                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td align="left">Quantity</td><td align="left">
                                            <asp:TextBox 
                                            ID="txtEquipmentQuantity" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="5"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtEquipmentQuantity_FilteredTextBoxExtender" 
                                                                runat="server" Enabled="True" 
                                                                FilterType="Custom, Numbers" 
                                                                TargetControlID="txtEquipmentQuantity" 
                                            ValidChars="/.\ @:!$%*?"></asp:FilteredTextBoxExtender></td></tr><tr><td align="left">&nbsp;</td><td align="left">
                                            <asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator8" runat="server" 
                                                                ControlToValidate="txtEquipmentQuantity" Display="None" 
                                                                ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td align="left">Price</td><td align="left"><asp:TextBox 
                                            ID="txtEquipmentPrice" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="5"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtEquipmentPrice_FilteredTextBoxExtender" 
                                                                runat="server" Enabled="True" 
                                                                FilterType="Custom, Numbers" 
                                                                TargetControlID="txtEquipmentPrice" 
                                            ValidChars=".,/\ ?!@%&$+-_"></asp:FilteredTextBoxExtender></td></tr><tr><td align="left">&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator12" runat="server" 
                                                                ControlToValidate="txtEquipmentPrice" Display="None" 
                                                                ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td align="left">Details</td><td align="left"><asp:TextBox 
                                            ID="txtEquipmentDetails" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="250" Height="86px" 
                                                TextMode="MultiLine" style = "resize:none" ></asp:TextBox></td></tr><tr><td align="left">&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator16" runat="server" 
                                                                ControlToValidate="txtEquipmentDetails" Display="None" 
                                                                ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td align="left">Sport Name</td><td align="left"><asp:DropDownList 
                                            ID="ddlSportName" runat="server"></asp:DropDownList></td></tr><tr><td align="left">&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator14" runat="server" 
                                                                ControlToValidate="ddlSportName" Display="None" 
                                                                ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr><td 
                                            align="left">Store name</td><td align="left"><asp:DropDownList 
                                                ID="ddlStoreName" runat="server"></asp:DropDownList></td></tr><tr><td 
                                            align="left">&nbsp;</td><td align="left"><asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlStoreName" 
                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator></td></tr><tr>
                                                <td>&nbsp;</td>
                                                <td align="left" ><table width="100%"><tr><td align="right" style=""><asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();" /></td><td align="left" style="padding-left:10px"><asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" /></td></tr></table></td></tr><tr><td align="center" class="auto-style5" colspan="2">&nbsp;&nbsp;</td></tr></table></center></ContentTemplate></asp:TabPanel>
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


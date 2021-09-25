<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStockCheck.aspx.cs" Inherits="frmStockCheck" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.mywidth_td td
{
    width:25%; 
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="clearfix">
    </div>
  <div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Inventory Management <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li class="active1"> <a> Stock Details</a></li>                  
        </ul>
    </div>
<section class="content">
    <div>       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="tabcon" ActiveTabIndex="0"
                    Width="99%">
                    <asp:TabPanel ID="List" HeaderText="List" runat="server">
                        <ContentTemplate>
                          
                                <div class="efficacious">
                                    <table width="50%" style="margin-top: 15px; margin-left:2%;">
                                        <tr>
                                            <td align="center">
                                                <table runat="server" id="filtertable" width="100%">
                                                    <tr id="Tr1" runat="server">
                                                     <td id="Td3" runat="server">
                                                           
                                                        </td>
                                                        <td id="Td4"  align="left" runat="server">
                                                            
                                                        </td> 
                                                        <td id="Td1" runat="server">
                                                            <asp:Label ID="lblInventoryName" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Inventory Name"></asp:Label>
                                                        </td>
                                                        <td id="Td2"  align="left" runat="server">
                                                            <asp:DropDownList ID="ddlInventory" runat="server" 
                                                                Style="position: relative; top: 5px; text-align: right; left: 0px;" 
                                                                onselectedindexchanged="ddlInventory_SelectedIndexChanged" 
                                                                AutoPostBack="True" >
                                                                                </asp:DropDownList>
                                                        </td>    
                                                                                                                                                                  
                                                    </tr>
                                                      
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                <asp:GridView ID="gvList" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                        CssClass="table  tabular-table " EmptyDataText="Record not Found."  Width="100%" >
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns> 
                                                                            <asp:BoundField ReadOnly="True" DataField="Total_Inventory" HeaderText="Total Inventory" />
                                                                                <asp:BoundField ReadOnly="True" DataField="vchQty" HeaderText="Used" />    
                                                                            </Columns>
                                                                            <PagerStyle CssClass="pgr" />
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                               
                                                </div>
                                            </td>
                                         
                                        </tr>
                                    </table>
                                </div>
                          
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Entry">
                       <ContentTemplate>
                          
                                <div class="efficacious">
                                    <table  width="90%" style="margin-top: 15px; margin-left:2%;">
                                        <tr>
                                            <td align="left">
                                                <table class="mywidth_td" runat="server" id="Table1" width="80%">
                                                    <tr id="Tr2" runat="server">
                                                     <td id="Td11" runat="server" align="center">
                                                          <asp:Label ID="Label2" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Role"></asp:Label> 
                                                        </td>
                                                        <td id="Td12"  align="center" runat="server">
                                                            <asp:DropDownList ID="drpRole" runat="server" 
                                                                Style="position: relative; top: 5px; text-align: right;"                                                               
                                                                AutoPostBack="True" onselectedindexchanged="drpRole_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                        </td> 
                                                        <td id="Td13" runat="server" align="center">
                                                            <asp:Label ID="Label1" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Department"></asp:Label>
                                                        </td>
                                                        <td id="Td14"  align="left" runat="server">
                                                            <asp:DropDownList ID="drpDept" runat="server" 
                                                                Style="position: relative; top: 5px; text-align: right; left: 0px;"                                                               
                                                                AutoPostBack="True" onselectedindexchanged="drpDept_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                        </td>
                                                        </tr>
                                                        <tr runat="server">
                                                         <td id="Td5" runat="server" align="center">
                                                          <asp:Label ID="Label3" runat="server" Style="position: relative; margin-left:15px; top: 5px; text-align: right;"
                                                                Text="Designation"></asp:Label> 
                                                        </td>
                                                        <td id="Td6"  align="center" runat="server">
                                                            <asp:DropDownList ID="drpDesignation" runat="server" 
                                                                Style="position: relative; top: 5px; text-align: right;"                                                               
                                                                AutoPostBack="True" 
                                                                onselectedindexchanged="drpDesignation_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                        </td> 
                                                        <td id="Td7" runat="server" align="center">
                                                            <asp:Label ID="Label4" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Name"></asp:Label>
                                                        </td>
                                                        <td id="Td8"  align="center" runat="server">
                                                            <asp:DropDownList ID="drpName" runat="server" 
                                                                Style="position: relative; top: 5px; text-align: right;"                                                               
                                                                AutoPostBack="True" >
                                                                                </asp:DropDownList>
                                                        </td>        
                                                                                                                                                                  
                                                    </tr>
                                                       <tr id="Tr3" runat="server">
                                                     <td id="Td9" runat="server" align="center">
                                                          <asp:Label ID="Label5" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Inventory Name"></asp:Label> 
                                                        </td>
                                                        <td id="Td10"  align="center" runat="server">
                                                            <asp:DropDownList ID="drpInventory" runat="server" 
                                                                Style="position: relative; top: 5px; text-align: right;"                                                               
                                                                AutoPostBack="True" >
                                                                                </asp:DropDownList>
                                                        </td> 
                                                        <td id="Td15" runat="server" align="center">
                                                            <asp:Label ID="Label6" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Quantity"></asp:Label>
                                                        </td>
                                                        <td id="Td16"  align="left" runat="server">
                                                            <asp:TextBox ID="txtQty" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                        </tr>
                                                        <tr runat="server">
                                                         <td id="Td17" runat="server" align="center">
                                                          <asp:Label ID="Label7" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Unit of Measurement"></asp:Label> 
                                                        </td>
                                                        <td id="Td18"  align="left" runat="server">
                                                            <asp:DropDownList ID="drpUnit" runat="server" Style="position: relative; top: 5px; text-align: right;"  AutoPostBack="True" >
                                                              </asp:DropDownList>
                                                        </td> 
                                                        <td runat="server" >
                                                           
                                                        </td>
                                                        <td id="Td19" align="left" runat="server" >
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send"  style="width:100% !important;"
                                                            Text="Submit" onclick="btnSubmit_Click"   />
                                                        </td>
                                                        <td id="Td20"  align="left" runat="server">
                                                           
                                                        </td>        
                                                                                                                                                                  
                                                    </tr>
                                                      
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                <asp:GridView ID="grdDetails" runat="server" AllowSorting="True" 
                                                        AutoGenerateColumns="False"  DataKeyNames="intStock_Id,intUser_id"
                                                        CssClass="table  tabular-table " EmptyDataText="Record not Found."  
                                                        Width="100%" onrowdeleting="grdDetails_RowDeleting" 
                                                        onrowediting="grdDetails_RowEditing" >
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns> 
                                                                                <asp:BoundField ReadOnly="True" DataField="intRole_Id" HeaderText="Role" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="intDepartment" HeaderText="Department" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="intDesignation_Id" HeaderText="Designation" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="vchUserName" HeaderText="Name" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="intEquipment_id" HeaderText="Inventory" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="vchQty" HeaderText="Qty" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="intUnit_Id" HeaderText="Unit" />
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
                                                                            <PagerStyle CssClass="pgr" />
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                               
                                                </div>
                                            </td>
                                         
                                        </tr>
                                    </table>
                                </div>
                            
                        </ContentTemplate>
                    </asp:TabPanel>                   
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
</asp:Content>


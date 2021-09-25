<%@ Page Title="Complaint Entry" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmComplaintEntry.aspx.cs" Inherits="frmComplaintEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Complaint & Suggestion <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li class="active1"><a>Complaint Box</a></li>                     
        </ul>
    </div>
<section class="content">
    <div style="padding:5px 0 0 0">
        <asp:UpdatePanel ID="upda1" runat="server"><ContentTemplate>
    <table>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="928px" CssClass="MyTabStyle">
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Complaint Entry</HeaderTemplate>
                        <ContentTemplate>
                    
                        <div class="efficacious" style="background-color:White; float:left;width:100%;">
                            <table align="left" width="40%" style="margin:0 0 0 2%;" >

                             <tr>
                 
                                <td ID="Td3" runat="server" align="left"  >
                                    <asp:Label ID="lblddl" runat="server" Text="Role"></asp:Label>
                                </td>
                                <td ID="Td5" runat="server" align="left" nowrap="nowrap" >
                                    <asp:DropDownList ID="ddldrop" runat="server"  
                                                                                Font-Names="Verdana" ForeColor="Black"
                                                                                ValidationGroup="p1">
                <asp:ListItem Selected="True" Value="Select">--- Select ---</asp:ListItem>
                <asp:ListItem Value="1">Teacher</asp:ListItem>
                <asp:ListItem Value="2">Staff</asp:ListItem>
                <asp:ListItem Value="3">Principle</asp:ListItem>
            </asp:DropDownList>
                                </td>
                                <td >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="ddldrop"   ValidationGroup="v1" Display="None" 
                                        ErrorMessage="Select Role" Font-Bold="False"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                </tr>
                 
                          
                            <tr>
                 
                                <td ID="Td1" runat="server" align="left"  >
                                    <asp:Label ID="Lal1" runat="server" Text="Complaint Title"></asp:Label>
                                </td>
                                <td ID="Td2" runat="server" align="left" nowrap="nowrap" >
                                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="input-blue" ForeColor="Black" MaxLength="200"></asp:TextBox>   
                                </td>
                                <td >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="TextBox1"   ValidationGroup="v1" Display="None" 
                                        ErrorMessage="Enter Complaint Title" Font-Bold="False"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                </tr>
                 
                            <tr>
                            <td id="td9" runat="server" align="left"  >
                             <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                         
                            </td>
                                              
                                                <td ID="Td4" runat="server" align="left">
                                     
                                    <%--<textarea id="TextBox2" runat="server"  style="width: 100%; border: 1px solid #3498db;"   ForeColor="Black" rows="2"></textarea>--%>
                                    <asp:TextBox ID="TextBox2" runat="server"  CssClass="input-blue" ForeColor="Black" TextMode="MultiLine"></asp:TextBox>         
                                                </td>
                                                <td >
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="TextBox2"   ValidationGroup="v1" Display="None" 
                                                        ErrorMessage="Enter Discription" Font-Bold="False"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator2">
                                                    </asp:ValidatorCalloutExtender>                                  
                                                </td>
                                             
                                             </tr>
                                             <tr>
                                               

                                                 <td align="center" colspan="3">
                                                     <table width="30%">
                                                         <tr>
                                                              <td align="right">
                                                    
                                                    <asp:Button  ID="Button1" runat="server"   
                                                        OnClick="Button1_Click" Text="Submit" CssClass="efficacious_send"  ValidationGroup="v1" />
                                                        <asp:Button    ID="Button2" runat="server" Visible="False" OnClick="Button2_Click" Text="Update" ValidationGroup="v1" CssClass="efficacious_send"  />
                                                    <asp:TextBox ID="TextBox3" runat="server" Visible="False" ForeColor="Black"  Height="22px" ></asp:TextBox>&nbsp;</td>
                                                         </tr>
                                                     </table>

                                                 </td>
                                                </tr>
                                </table>
                           
                            </div>
                          
                            </ContentTemplate>
                            </asp:TabPanel>
                     <asp:TabPanel HeaderText="g" ID="TabPanel2" runat="server">
                        <HeaderTemplate>
                           Status</HeaderTemplate>
                        <ContentTemplate>
                     
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="table  tabular-table " PageSize="20" Width="100%" OnRowDataBound="GridView1_RowDataBound"
                                            OnRowEditing="GridView1_RowEditing" DataKeyNames="intcomplaint_id" OnRowDeleting="GridView1_RowDeleting"
                                            OnRowCommand="GridView1_RowCommand" HorizontalAlign="Center">
                                            <Columns>
                                             <asp:BoundField DataField="vchRole1" HeaderText="Role" ReadOnly="True" />
                                               <asp:BoundField DataField="vchComplaint_Title" HeaderText="Complaint Title" ReadOnly="True" />
                                                <asp:BoundField DataField="vchComplaint_Discr" HeaderText="Complaint Discription" ReadOnly="True" />
                                                <asp:BoundField DataField="ComplaintDate" HeaderText="Complaint Date" ReadOnly="True" />
                                                <asp:BoundField DataField="btAdminApproval" HeaderText="Status" ReadOnly="True" />
                                                <asp:BoundField DataField="intAction_by" HeaderText="Action Taken By" ReadOnly="True" />
                                                <asp:BoundField DataField="dtActionDate" HeaderText="Date" ReadOnly="True" />
                                                <asp:BoundField DataField="VchAdmin_Discr" HeaderText="Action Discription" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Id" Visible="False" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="intcomplaint_id" runat="server" Text='  <%# Eval("intcomplaint_id")  %>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                            CausesValidation="false" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                            OnClientClick="return messageConfirm('Do you want to Delete this Record ?');"
                                                            CausesValidation="false" /></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                
                                                
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                              <asp:TabPanel HeaderText="g" ID="tab" runat="server" Visible="false">
                        <HeaderTemplate>
                            Report</HeaderTemplate>
                        <ContentTemplate>
                     
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:GridView ID="CompDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="table  tabular-table " PageSize="20" Width="100%" OnRowDataBound="CompDetail_RowDataBound"
                                            OnRowEditing="CompDetail_RowEditing" DataKeyNames="intcomplaint_id" OnRowDeleting="CompDetail_RowDeleting"
                                            OnRowCommand="CompDetail_RowCommand" HorizontalAlign="Center" EnableModelValidation="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="intcomplaint_id" runat="server" Text='  <%# Eval("intcomplaint_id")  %>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                              <%--  <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                            OnClientClick="return messageConfirm('Do you want to Delete this Record ?');"
                                                            CausesValidation="false" /></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                            CausesValidation="false" /></ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="vchComplaint_Title" HeaderText="Complaint Title" ReadOnly="True" />
                                                <asp:BoundField DataField="vchComplaint_Discr" HeaderText="Complaint Discription" ReadOnly="True" />
                                                <asp:BoundField DataField="ComplaintDate" HeaderText="Complaint Date" ReadOnly="True" />
                                                <asp:BoundField DataField="btAdminApproval" HeaderText="Status" ReadOnly="True" />
                                                <asp:BoundField DataField="intAction_by" HeaderText="Action Taken By" ReadOnly="True" />
                                                <asp:BoundField DataField="dtActionDate" HeaderText="Date" ReadOnly="True" />
                                                <asp:BoundField DataField="VchAdmin_Discr" HeaderText="Action Discription" ReadOnly="True" />
                                                
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                            </asp:TabContainer>
                            </td>
                            </tr>
   </table>
</ContentTemplate></asp:UpdatePanel>
</div>
</section>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
 
</asp:Content>






<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" CodeFile="frmFees_For_Bus.aspx.cs" Inherits="frmFees_For_Bus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
        Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                
                Fees Structure Allocation</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
            <asp:UpdatePanel ID="upda1" runat="server">
            <ContentTemplate>
            <table align="center">
            <tr id="enara1" runat="server" >
                <td style="padding-bottom:20px" nowrap="true">
                <asp:Label ID="lab1" runat="server" Text="Select Area"></asp:Label>
                
                </td>
                <td style="padding-bottom:15px" >
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="140px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ReqFV1" ValidationGroup="b1" InitialValue=0 runat="server" 
                        ErrorMessage="Select Area" Display="None" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VadaCaExd1" runat="server" Enabled="True"
                                                        TargetControlID="ReqFV1">
                                                    </asp:ValidatorCalloutExtender>
                        
                </td>
            </tr>
                 <tr id="enara" runat="server" visible="false">
                <td style="padding-bottom:20px" nowrap="true">
                <asp:Label ID="Label6" runat="server" Text="Bus Route Area"></asp:Label>
                
                </td>
                <td style="padding-bottom:15px">
              
                    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
              
                    <asp:RequiredFieldValidator ID="ReqFVd24" ValidationGroup="b1" runat="server" 
                        ErrorMessage="Enter Amount" Display="None" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                        TargetControlID="ReqFVd24">
                                                    </asp:ValidatorCalloutExtender>
                        
                </td>
            </tr>
                 <tr>
                <td style="padding-bottom:20px" nowrap="true">
                <asp:Label ID="Label1" runat="server" Text="Enter Amount"></asp:Label>
                
                </td>
                <td style="padding-bottom:15px">
              
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              
                    <asp:RequiredFieldValidator ID="ReqFVd2" ValidationGroup="b1" runat="server" 
                        ErrorMessage="Enter Amount" Display="None" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                        TargetControlID="ReqFVd2">
                                                    </asp:ValidatorCalloutExtender>
                        
                </td>
            </tr>
                 <tr>
                <td style="padding-bottom:20px" nowrap="true">
                <asp:Label ID="Label2" runat="server" Text="Effective From"></asp:Label>
                
                </td>
                <td style="padding-bottom:15px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy"
                                        TargetControlID="TextBox2" runat="server" Enabled="True">
                                    </asp:CalendarExtender>
                               
                    
                    <asp:RequiredFieldValidator ID="ReqFiVadt3" ValidationGroup="b1" runat="server" 
                        ErrorMessage="Effective From" Display="None" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                        TargetControlID="ReqFiVadt3">
                                                    </asp:ValidatorCalloutExtender>
                        
                </td>
            </tr>
                 <tr>
                <td style="padding-bottom:20px">
                <asp:Label ID="Label5" runat="server" Text="Effective To"></asp:Label>
                
                </td>
                <td style="padding-bottom:15px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                       <asp:CalendarExtender ID="CalExt2" Format="dd/MM/yyyy"
                                        TargetControlID="TextBox3" runat="server" Enabled="True">
                                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="ReqFidVal4" ValidationGroup="b1" runat="server" 
                        ErrorMessage="Effective To" Display="None" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                        TargetControlID="ReqFidVal4">
                                                    </asp:ValidatorCalloutExtender>
                        
                </td>
            </tr>
            <tr>
            <td colspan="2" align="center">
                <table>
                    <tr>
                        <td width="40%"></td>
                        <td>
                            <asp:Button     ID="submit" ValidationGroup="b1" CssClass="efficacious_send" runat="server" 
                    Text="Submit" onclick="submit_Click"/>
                        <asp:TextBox id="labarea" runat="server" Visible="false" ></asp:TextBox>

                        </td>

                    </tr>
                       <tr>
                           <td width="40%"></td>
                            <td >
                                    <asp:Button ID="Update1" CssClass="efficacious_send" runat="server" 
                    Text="Update" Visible="false" onclick="Update1_Click"/>
                           </td>

                       </tr>

                </table>

            </td></tr>
            </table>

            </ContentTemplate></asp:UpdatePanel>
                    </div>
            </ContentTemplate>
            </asp:TabPanel>
             <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
             
                Bus Fees structure
                </HeaderTemplate>
            <ContentTemplate>
          <div class="efficacious">
            
                <table width="100%">
                   
                    <tr>
                        <td >
                          <asp:GridView ID="FeesDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="mGrid"  Width="100%" OnRowDataBound="FeesDetail_RowDataBound"
                                            OnRowEditing="FeesDetail_RowEditing"   
                                DataKeyNames="intBusFees_Id" OnRowDeleting="FeesDetail_RowDeleting"
                                            OnRowCommand="FeesDetail_RowCommand" 
                                            Font-Bold="False" 
                                onselectedindexchanged="FeesDetail_SelectedIndexChanged" 
                                HorizontalAlign="Center">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="intBusFees_Id" runat="server" Text='  <%# Eval("intBusFees_Id")  %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                            OnClientClick="return messageConfirm('Do you want to Delete this Record ?');"
                                                             /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                            /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="intArea_Id" HeaderText="Area Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intBus_Amount" HeaderText="Amount" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                                
                                            </Columns>
                                        </asp:GridView>
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
</asp:Content>


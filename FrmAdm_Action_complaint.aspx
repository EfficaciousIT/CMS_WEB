<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" CodeFile="FrmAdm_Action_complaint.aspx.cs" Inherits="FrmAdm_Action_complaint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 147px;
        }
        .style3
        {
            width: 162px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
  <table><tr><td><asp:Label ID="lab1" runat="server">User Complaint</asp:Label></td></tr></table>
    <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="900px"
         style="margin-bottom: 0px">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Complaint List
            </HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="233%" OnRowEditing="GridView1_RowEditing" 
                                 DataKeyNames="intcomplaint_id" 
                                onselectedindexchanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="alt"  ></AlternatingRowStyle>
                                <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="intcomplaint_id" runat="server" ></asp:Label>
                                                </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approval">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                                <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="vchcomplaint_title" HeaderText="Title" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchcomplaint_discr" HeaderText="Complaint Discription" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="intinsert_By" HeaderText="Complaint By" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dtinsertDate" HeaderText="Complaint Date" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                </Columns>
                                <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="True"/> 
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2" Visible="false">
            <HeaderTemplate>
                Complaint Status
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 70%" align="center">
                    <tr>
                        <td align="center" style="padding-bottom:10px">
      
                        <asp:Label ID='ComplStat' runat="server"  
                                CssClass="textheadcss" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                
                    </table>
                    <table style="width: 50%" align="center">
                    <tr><td colspan='2' align="center">
                    <asp:Label ID="lblcomplaint" runat="server" Text="Complaint Id" CssClass="textcss" 
                                                Font-Bold="False" Visible=False></asp:Label>
                                                </td></tr>
                     <tr>
            
                                        <td align="left" class="style3">
                                            <asp:Label ID="Label1" runat="server" Text="Complaint Title" CssClass="textcss" 
                                                Font-Bold="False"></asp:Label>
                                        </td>
                                        
                                        <td align="left" style="padding-bottom:10px">
                                            <asp:Label ID="la1" runat="server" CssClass="textcss" ></asp:Label>
                                        </td>
                                        
                                       
                                    </tr>
                                    <tr><td align="left" >
                                        <asp:Label ID="Label3" runat="server" Text="Complaint Discription" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td style="padding-bottom:20px" align="left"><asp:Label ID="la2" runat="server" nowrap="true"   CssClass="textcss"></asp:Label></td>
                                        </tr>
                                        <tr><td align="left" class="style3">
                                        <asp:Label ID="Label5" runat="server" Text="Complaint By" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td><asp:Label ID="la3" runat="server" CssClass="textcss"></asp:Label></td>
                                        </tr>
                                         <tr><td align="left" class="style3">
                                        <asp:Label ID="Label7" runat="server" Text="Complaint Date" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td><asp:Label ID="la4" runat="server" CssClass="textcss" ></asp:Label></td>
                                        </tr>
                                         <tr>
                                        <td colspan="2">
                                            <br />
                                        </td>
                                             <tr>
                                                 <td align="center" colspan='2'>
                                                 <asp:RadioButtonList ID="RadioApproved" runat="server" RepeatDirection="Horizontal" 
                                                         CssClass="textcss" Height="16px" Width="288px">
                                                         <asp:ListItem Value="1">Acceped</asp:ListItem>
                                                         
                                                         <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                         ControlToValidate="RadioApproved" ErrorMessage="Choose Approval Status"></asp:RequiredFieldValidator>
                                                </td>
                                                </tr>
                                             <tr>
                                                 <td align="left" class="style3">
                                                     <asp:Label ID="Label2" runat="server" CssClass="textcss" Text="Action"></asp:Label>
                                                 </td>
                                                 <td align="left">
                                                     <asp:TextBox ID="Discritxt" runat="server" CssClass="textcss" Height="47px" 
                                                         Font-Size="X-Small" Width="150px"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                         ControlToValidate="Discritxt" ErrorMessage="Please Enter Discription"></asp:RequiredFieldValidator>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td class="style3">
                                                     &nbsp;
                                                 </td>
                                                 <td align="left" class="style2">
                                                     &nbsp;
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td align="right" class="style3">
                                                     <asp:Button ID="btnSubmin" runat="server" OnClick="Submitval" Text="Submit" />
                                                 </td>
                                                 <td align="left" valign="middle">
                                                     <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" 
                                                         Text="Clear" />
                                                    
                                                 </td>
                                             </tr>
                                        
                                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Complaint Report
            </HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView5" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="160%" Height="117px" >
                                <AlternatingRowStyle CssClass="alt"  ></AlternatingRowStyle>
                                <Columns>
                                
                                <asp:BoundField DataField="intComplaint_id" HeaderText="ID" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchcomplaint_title" HeaderText="Title" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchcomplaint_discr" HeaderText="Complaint Discription" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="intinsert_By" HeaderText="Complaint By" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dtinsertDate" HeaderText="Complaint Date" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="btAdminApproval" HeaderText="Admin Approval" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="vchAdmin_Discr" HeaderText="Status" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="intAction_By" HeaderText="Action By" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="dtActionDate" HeaderText="Action Perform on" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                </Columns>
                                <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="True"/> 
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</td></tr></table>
</center>
</asp:Content>


<%@ Page Title="Bus Service request approval" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" CodeFile="FrmAdm_AppBusSerReq.aspx.cs" Inherits="FrmAdm_AppBusSerReq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"
        Width="930px" CssClass="MyTabStyle">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">

            <HeaderTemplate>
                Application Status
                    
</HeaderTemplate>

<ContentTemplate>
    <div class="efficacious">
                <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                   
                    <tr>
                        <td align="center">
                            <asp:GridView ID="Apbusre" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="100%" OnRowDataBound="Apbusre_RowDataBound"
                                OnRowEditing="Apbusre_RowEditing"
                                DataKeyNames="intService_id"
                                OnRowCommand="Apbusre_RowCommand"
                                Font-Bold="False"
                                OnSelectedIndexChanged="Apbusre_SelectedIndexChanged" HorizontalAlign="Center" EnableModelValidation="True"><Columns>
<asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate>
                                            <asp:Label ID="intService_id" runat="server" Text='  <%# Eval("intService_id")  %>'></asp:Label>
                                        
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Approval"><ItemTemplate>
                                            <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit" />
                                        
</ItemTemplate>
    <ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
<asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True" />
<asp:BoundField DataField="vchdivisionname" HeaderText="Division" ReadOnly="True" />
<asp:BoundField DataField="introllno" HeaderText="Roll No" ReadOnly="True" />
<asp:BoundField DataField="StudentName" HeaderText="Student Name" ReadOnly="True" />
<asp:BoundField DataField="ParentsName" HeaderText="Parents Name" ReadOnly="True" />
<asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" ReadOnly="True" />
<asp:BoundField DataField="dtAppli_Date" HeaderText="Application Date" ReadOnly="True" />
<asp:BoundField DataField="intBus_Amount" HeaderText="Bus Amount" ReadOnly="True" />
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
        <asp:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
            <HeaderTemplate>
                Approval
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <div class="efficacious">
                        <table align="center" width="50%">
                    
                    <tr>
                        <td style="padding-bottom:10px"><asp:Label ID="lab1" runat="server" Text="Student Name" ></asp:Label></td>
                        <td style="padding-bottom:10px"><asp:Label ID="lab2" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                       <td style="padding-bottom:10px"><asp:Label ID="lab3" runat="server" Text="Bus Service Area"></asp:Label></td>
                        <td style="padding-bottom:10px" ><asp:Label ID="lab4" runat="server" ></asp:Label></td>
                    </tr>
                   
                    <tr>
                        <td  style="padding-bottom:10px"><asp:Label ID="lab5" runat="server" Text="Effective From"></asp:Label></td>
                        <td  style="padding-bottom:10px"><asp:Label ID="lab6" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td  style="padding-bottom:10px"><asp:Label ID="lab7" runat="server" Text="Effective To"></asp:Label></td>
                        <td  style="padding-bottom:10px"><asp:Label ID="lab8" runat="server" ></asp:Label></td>
                    </tr>
                    <tr><td><asp:Label ID="d1" runat="server" Text="Remark" ></asp:Label></td>
                        <td><asp:TextBox  ID="remark1" runat="server" Height="49px" Width="123px"></asp:TextBox></td>
                    </tr>
              <tr><td colspan="2" align="center">
                  <table><tr><td>
                      <asp:Button    id="id1" runat="server" CssClass="efficacious_send"   Text="Approve" OnClick="id1_Click"/><asp:TextBox ID="txt1" Visible="false" runat="server"></asp:TextBox></td></tr>
                            </td></tr></table>
                    </table>
                   </div>
                         </center>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
        </td></tr></table>
</asp:Content>

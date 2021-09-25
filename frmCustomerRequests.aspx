<%@ Page EnableEventValidation="true" Language="C#" MasterPageFile="~/newMasterPage.master"
    AutoEventWireup="true" CodeFile="frmCustomerRequests.aspx.cs" Inherits="frmCustomerRequests"
    Title="School Request" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
         <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Request Details
</HeaderTemplate>
            
<ContentTemplate>
                <center>
        <table>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label8" runat="server" Text="Request Details"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                        CssClass="mGrid" Width="800px" OnRowEditing="GridView1_RowEditing">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Confirm">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                        <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Schoolname" HeaderText="School name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Shortname" HeaderText="Short name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Contactperson" HeaderText="Contact person">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Studentcapacity" HeaderText="Student capacity">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </center>
    </ContentTemplate></asp:TabPanel>
             </asp:TabContainer>
</asp:Content>

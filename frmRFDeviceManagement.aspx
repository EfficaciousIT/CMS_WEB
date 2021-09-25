<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmRFDeviceManagement.aspx.cs" Inherits="frmRFDeviceManagement" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 294px;
        }
        .style2
        {
            width: 123px;
        }
        .style3
        {
            width: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1" Width="850px"
        Height="218px">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Device Details
            </HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="800px" OnRowEditing="GridView1_RowEditing">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton OnClientClick="confirm('Are sure you want to delete this record')"
                                                ID="lnkBtndelete" runat="server">
                                                <asp:Image ID="ImgDelete" runat="server" ImageUrl="images/delete.png" /></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                                <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="devicenumer" HeaderText="Device number">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ip" HeaderText="IP">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="port" HeaderText="Port">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Add New Device
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td class="style1">
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="style2">
                        </td>
                        <td class="style3">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="style2" align="left">
                            <asp:Label ID="Label1" runat="server" Text="Device number"></asp:Label>
                        </td>
                        <td class="style3">
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDevicenumber" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="style2" align="left">
                            <asp:Label ID="Label2" runat="server" Text="IP"></asp:Label>
                        </td>
                        <td class="style3">
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="style2" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Port"></asp:Label>
                        </td>
                        <td class="style3">
                        </td>
                        <td valign="middle">
                            <table class="style4">
                                <tr>
                                    <td class="style5">
                                        <asp:TextBox ID="txtPort" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;
                        </td>
                        <td align="left" class="style2">
                            &nbsp;
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td align="left" valign="middle">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;
                        </td>
                        <td align="right" class="style2">
                            <asp:Button ID="btnSubmin" runat="server" Text="Submit" />
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td align="left" valign="middle">
                            <asp:Button ID="btnClear" runat="server" Text="Clear" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>

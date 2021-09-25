<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmServicesSMS.aspx.cs" Inherits="frmServiceSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 265px;
        }
        .style2
        {
            width: 121px;
        }
        .style3
        {
            width: 25px;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 67px;
        }
        .style6
        {
            width: 312px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="850px"
        Height="178px">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                SMS Service Details
            </HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="800px">
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
                                    <asp:BoundField DataField="servicename" HeaderText="Serivce Name">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="count" HeaderText="SMS count">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="period" HeaderText="Valid period">
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
                Add New service
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width:100%">
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
                        <td class="style2">
                            
                            <asp:Label ID="Label1" runat="server" Text="Serivce name"></asp:Label>
                            
                        </td>
                        <td class="style3">
                            
                        </td>
                        <td align="left">
                            
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            
                        </td>
                        <td class="style2">
                            
                            <asp:Label ID="Label2" runat="server" Text="SMS count"></asp:Label>
                            
                        </td>
                        <td class="style3">
                            
                        </td>
                        <td align="left">
                            
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            
                        </td>
                        <td class="style2">
                            
                            <asp:Label ID="Label3" runat="server" Text="Periods"></asp:Label>
                            
                        </td>
                        <td class="style3">
                            
                        </td>
                        <td valign="middle">
                            
                            <table class="style4">
                                <tr>
                                    <td class="style5">
                                        <asp:TextBox ID="txtMonth" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="style6" align="left">
                                        <asp:Label ID="Label4" runat="server" Text="(In Month)"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                        <td>
                            
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>

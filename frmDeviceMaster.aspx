<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmDeviceMaster.aspx.cs" Inherits="frmDeviceMaster" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table>
        <tr>
            <td align="left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="850px"
                            Height="375px">
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    Device Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table>
                                            <tr>
                                                <td class="style1">
                                                    <asp:GridView ID="GridView3" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                        CssClass="mGrid" Width="80%">
                                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        ImageUrl="images/delete.png" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                        Text="Delete" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        ImageUrl="images/edit.png" Text="Delete" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Devicenumber" HeaderText="Device Number" ReadOnly="True" />
                                                            <asp:BoundField DataField="IP" HeaderText="IP" ReadOnly="True" />
                                                            <asp:BoundField DataField="Port" HeaderText="Port" ReadOnly="True" />
                                                            <asp:BoundField DataField="SimNumber" HeaderText="Sim Number" ReadOnly="True" />
                                                            <asp:BoundField DataField="APNProvider" HeaderText="APN Provider" ReadOnly="True" />
                                                            <asp:BoundField DataField="APNName" HeaderText="APN Name" ReadOnly="True" />
                                                        </Columns>
                                                        <PagerStyle CssClass="pgr"></PagerStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table style="width: 371px; margin: 10px 0;" align="center">
                                            <tr height="35">
                                                <td align="left" width="230">
                                                    <asp:Label ID="lblvchno" runat="server">Device Number</asp:Label>
                                                </td>
                                                <td align="left" width="230">
                                                    <asp:TextBox ID="txtvchno" runat="server" Font-Names="Verdana" MaxLength="20" Font-Size="Small"
                                                        ForeColor="Black" Width="200px" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr height="35">
                                                <td align="left">
                                                    <asp:Label ID="lblvchmake" runat="server">IP</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana" MaxLength="20" Font-Size="Small"
                                                        Width="200px" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr height="35">
                                                <td align="left">
                                                    <asp:Label ID="lblvchdrivername" runat="server" Text="Port"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana" MaxLength="20"
                                                        Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr height="35">
                                                <td align="left">
                                                    <asp:Label ID="lbldrivermobno" runat="server" Text="SIM Number"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvchmake1" runat="server" Font-Names="Verdana" MaxLength="20"
                                                        Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr height="35">
                                                <td align="left">
                                                    <asp:Label ID="lbldrivermobno0" runat="server" Text="APN Provider"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvchmake2" runat="server" Font-Names="Verdana" MaxLength="20"
                                                        Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr height="35">
                                                <td align="left">
                                                    <asp:Label ID="lbldrivermobno1" runat="server" Text="APN Name"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvchmake3" runat="server" Font-Names="Verdana" MaxLength="20"
                                                        Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr height="35" valign="bottom">
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnsubmit" runat="server" ImageUrl="~/images/submit.png" ForeColor="#999999"
                                                                    Height="28px" Width="64px" ValidationGroup="b" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

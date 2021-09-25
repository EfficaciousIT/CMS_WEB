<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" CodeFile="frmRPTFee.aspx.cs" Inherits="frmRPTFee" 
Title="E-SMARTs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table width="100%">
                <tr>
                    <td align="center">
                        <table width="50%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label5" runat="server" Text="Standard"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpMain" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="drpMain_SelectedIndexChanged">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" ID="tc1" CssClass="MyTabStyle" Width="100%" Style="min-height: 450px"
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="tb1">
                                <HeaderTemplate>
                                    Fee Received
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr1" visible="False" runat="server">
                                            <td align="center" runat="server">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblSTD" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="drpStandard_SelectedIndexChanged" style="height: 20px">
                                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdReceived" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel1" Visible="false">
                                <HeaderTemplate>
                                    Pending Fee
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr2" visible="false" runat="server">
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStandardRegis" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdPending" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel2" Visible="false">
                                <HeaderTemplate>
                                    Marks
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr3" visible="false" runat="server">
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label2" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStand" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdRegistrationTaken" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>                          
                            <asp:TabPanel ID="TabPanel3" runat="server" Visible="false" HeaderText="TabPanel3">
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


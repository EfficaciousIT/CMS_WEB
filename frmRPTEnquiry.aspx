<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmRPTEnquiry.aspx.cs" Inherits="frmRPTEnquiry" Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                    <asp:DropDownList ID="drpMain" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMain_SelectedIndexChanged">
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
                                    Enquiry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr1" visible="false" runat="server">
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblSTD" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
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
                                                <asp:GridView ID="grdEnquiry" AutoGenerateColumns="false" CssClass="mGrid" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="Enquiry No" HeaderText="Enquiry No"/>
                                                    <asp:BoundField DataField="Date" HeaderText="Date"/>
                                                    <asp:BoundField DataField="Name" HeaderText="Name"/>
                                                    <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile"/>
                                                    <asp:BoundField DataField="Email" HeaderText="Email"/>
                                                    <asp:BoundField DataField="State" HeaderText="State"/>
                                                    <asp:BoundField DataField="City" HeaderText="City"/>
                                                </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel1">
                                <HeaderTemplate>
                                    Registration Form Yet to be Taken
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
                                                            <asp:DropDownList ID="drpStandardRegis" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandardRegis_SelectedIndexChanged">
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
                                                <asp:GridView ID="grdRegistrationNotTaken" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel2">
                                <HeaderTemplate>
                                    Registration Form Purchased
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
                                                            <asp:DropDownList ID="drpStand" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStand_SelectedIndexChanged">
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
                            <asp:TabPanel runat="server" ID="TabPanel3">
                                <HeaderTemplate>
                                    Registration Form Submitted
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr4" visible="false" runat="server">
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label3" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpAcceptance" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpAcceptance_SelectedIndexChanged">
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
                                                <asp:GridView ID="grdAcceptance" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel4">
                                <HeaderTemplate>
                                    Registration Form Yet to be Submitted
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr5" visible="False" runat="server">
                                            <td id="Td1" align="center" runat="server">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label4" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpNotAcceptance" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpNotAcceptance_SelectedIndexChanged">
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
                                                <asp:GridView ID="grdNotAcceptance" CssClass="mGrid" runat="server">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

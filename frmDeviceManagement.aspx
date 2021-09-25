<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmDeviceManagement.aspx.cs" Inherits="frmDeviceManagement" Title="Untitled Page" %>

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
        .auto-style1
        {
            width: 294px;
            height: 26px;
        }
        .auto-style2
        {
            width: 123px;
            height: 26px;
        }
        .auto-style3
        {
            width: 3px;
            height: 26px;
        }
        .auto-style4
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                            Width="100%">
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    Device Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <center>
                                                    <asp:GridView ID="grvDevice" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                        CssClass="mGrid" Width="80%" OnRowEditing="GridView1_RowEditing" OnRowDeleting="grvDevice_RowDeleting"
                                                        DataKeyNames="intDeviceId" AllowPaging="True" OnPageIndexChanging="grvDevice_PageIndexChanging">
                                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton CausesValidation="false" CommandName="Delete" OnClientClick="Confirm(Do You Really Want To Delete Selected Record?)"
                                                                        ID="lnkBtndelete" runat="server">
                                                                        <asp:Image ID="ImgDelete" runat="server" ImageUrl="images/delete.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server" CausesValidation="false">
                                                                        <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="vchDeviceNum" HeaderText="Device number" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchIp" HeaderText="IP" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchPort" HeaderText="Port" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchAPN" HeaderText="APN name" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchVPN_Provider" HeaderText="APN provider" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" Text='<%# Bind("intDeviceId") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                    <div class="efficacious">
                                    <center>
                                        <table style="width: 60%">
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="Label1" runat="server" Text="Device number" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtDevicenumber" runat="server" AutoComplete="Off" CssClass="textsize"
                                                        MaxLength="15"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ControlToValidate="txtDevicenumber"
                                                        runat="server" ErrorMessage="Please Enter Device Number" CssClass="textsize"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                                                        Enabled="True">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="Label2" runat="server" CssClass="textsize" Text="IP"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtIP" runat="server" AutoComplete="Off" CssClass="textsize" MaxLength="15"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIP"
                                                        CssClass="textsize" Display="None" ErrorMessage="Please Enter an IP Address"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="Label4" runat="server" Text="Port" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left" valign="middle" colspan="2">
                                                    <asp:TextBox ID="txtPort" runat="server" AutoComplete="Off" CssClass="textsize" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPort"
                                                        CssClass="textsize" Display="None" ErrorMessage="Please Enter Port Number"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator3">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                </td>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="Label5" runat="server" CssClass="textsize" Text="APN"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle" colspan="2">
                                                        <asp:TextBox ID="txtAPN" runat="server" CssClass="textsize" MaxLength="20"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="Label6" runat="server" CssClass="textsize" Text="APN Provider"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle" colspan="2">
                                                        <asp:TextBox ID="txtAPNprovider" runat="server" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" >
                                                        &nbsp;</td>
                                                    <td align="left" valign="top">
                                                        <asp:Button ID="btnSubmin" runat="server" CssClass="efficacious_send" 
                                                            OnClick="btnSubmin_Click" Text="Submit" />
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Button ID="btnClear" runat="server" CssClass="efficacious_send" 
                                                            OnClick="btnClear_Click"  Text="Clear" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                        </center>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

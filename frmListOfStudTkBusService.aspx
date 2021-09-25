<%@ Page Title="List Of Student Taken Bus Service" Language="C#" MasterPageFile="~/newMasterPage.master"
    AutoEventWireup="true" CodeFile="frmListOfStudTkBusService.aspx.cs" Inherits="frmListOfStudTkBusService" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
         .mGrid th{ text-align:center !important;}
         .efficacious span{ margin:0 !important; padding:0 !important; text-align:right; position:relative; top:-4px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upv1" runat="server">
        <ContentTemplate>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                CssClass="MyTabStyle">
                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                    <HeaderTemplate>
                        Student Taken Bus Services</HeaderTemplate>
                    <ContentTemplate>
                        <asp:UpdatePanel ID="upda1" runat="server">
                            <ContentTemplate>
                                <div class="efficacious">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <div id="efficacious" class="efficacious">
                                                    <table width="90%" style="margin:0 auto;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lab1" runat="server" Text="Standard"></asp:Label>
                                                                </td>
                                                                <td>
                                                                <asp:DropDownList ID="Drop11" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Drop11_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                </td>
                                                            
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Division"></asp:Label>
                                                                 </td>
                                                                <td>
                                                                <asp:DropDownList ID="Drop12" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Drop12_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                    CssClass="mGrid" Width="100%" OnRowEditing="GridView1_RowEditing" DataKeyNames="name">
                                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    <Columns>
                                                        <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="starttime" HeaderText="Start Time" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="endtime" HeaderText="End Time" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Route_name" HeaderText="Route Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Trip_name" HeaderText="Trip Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BusStop_name" HeaderText="Bus Stop Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" ForeColor="DarkBlue" Font-Bold="True" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

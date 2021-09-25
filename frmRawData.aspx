<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmRawData.aspx.cs" Inherits="frmRawData" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 5px 0 0 0">
                    <center>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="928px"
                                                ActiveTabIndex="0">
                                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                    <HeaderTemplate>
                                                        Detail</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <br />
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <center>
                                                                        <table width="50%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lbladmStandard" runat="server" Text="Month"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">
                                                                                        <asp:ListItem>---Select--</asp:ListItem>
                                                                                        <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                                                        <asp:ListItem Text="Fab" Value="02"></asp:ListItem>
                                                                                        <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                                                        <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                                                        <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                                                        <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                                                        <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                                                        <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                                                        <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                                                        <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                                        <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                                        <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="center" visible="False" runat="server">
                                                                                    Date
                                                                                </td>
                                                                                <td visible="False" runat="server">
                                                                                    <asp:DropDownList ID="drpDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDate_SelectedIndexChanged">
                                                                                        <asp:ListItem>---Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="center">
                                                                                    Device
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="drpDevice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDevice_SelectedIndexChanged">
                                                                                        <asp:ListItem>---Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CssClass="mGrid" Width="50%" EmptyDataText="No Examination schedule" 
                                                                        DataKeyNames="vchDeviceNumber,StartDate" 
                                                                        onrowdatabound="GridView1_RowDataBound">
                                                                         <Columns>
                                                                            <asp:BoundField DataField="intExamSchedule_id" HeaderText="Id" Visible="False" />
                                                                            <asp:BoundField DataField="StartDate" HeaderText="Date" ReadOnly="True">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Expected" HeaderText="Expected" ReadOnly="True">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Actual">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkIn" CommandName='Edit' runat="server" Text='<%# Eval("Actual") %>'
                                                                                        Width="25%"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Difference" HeaderText="Difference" ReadOnly="True">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <asp:GridView ID="grdRawdata" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CssClass="mGrid" Width="50%" EmptyDataText="No Examination schedule" DataKeyNames="Devicenumber,dtRecieveDatetime,Hour"
                                                                        OnRowDataBound="grdRawdata_RowDataBound">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="intExamSchedule_id" HeaderText="Id" Visible="False" />
                                                                            <asp:BoundField DataField="dtRecieveDatetime" HeaderText="Date" ReadOnly="True">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Hour" HeaderText="Hour" ReadOnly="True">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Count">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkIn" CommandName='Edit' runat="server" Text='<%# Eval("Ct") %>'
                                                                                        Width="25%"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
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
                    </center>
                </div>
            </td>
            <td align="right" width="100%" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="right" width="100%" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

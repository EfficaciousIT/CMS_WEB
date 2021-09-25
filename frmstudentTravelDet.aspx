<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmstudentTravelDet.aspx.cs" Inherits="frmstudentTravelDet" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table>
        <tr>
            <td align="left" style="padding:0 0 0 50px">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="927px"
                    Height="410px">
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Present Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table width="50%" style="left: auto">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Month"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">
                                                        <asp:ListItem>---Select---</asp:ListItem>
                                                        <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                        <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                                        <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                        <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                        <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                        <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                        <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                                        <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                        <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                        <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdBusAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                            Width="800px">
                                            <Columns>
                                                <asp:BoundField DataField="vchStudentFirst_name" HeaderText="Name" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="intRollNo" HeaderText="Roll No" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtAttendance_date" HeaderText="Date" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtInTime" HeaderText="In-Time" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtOutTime" HeaderText="Out-Time" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle CssClass="pgr" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Absent Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <center>
                                            <table width="50%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Month"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpAbsent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpAbsent_SelectedIndexChanged">
                                                            <asp:ListItem>---Select---</asp:ListItem>
                                                            <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                            <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                                            <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                            <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                            <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                            <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                                            <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                            <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdAbsent" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                            Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="vchStudentFirst_name" HeaderText="Name" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="intRollNo" HeaderText="Roll No" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtAttendance_date" HeaderText="Date" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle CssClass="pgr" />
                                            <AlternatingRowStyle CssClass="alt" />
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
</asp:Content>

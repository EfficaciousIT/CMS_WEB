<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmCalendar.aspx.cs" Inherits="frmCalendar" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <asp:TabContainer ID="TabContainer1" runat="server" Width="1116px" ActiveTabIndex="1"
            Height="1000px">
            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Calendar
                </HeaderTemplate>
                <ContentTemplate>
                    <center style="border: solid red 0px;">
                        <asp:Panel ID="panel_Calender" runat="server" Height="440px" Width="1097px">
                            <asp:Calendar ID="Calendar1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                ForeColor="Black" OnDayRender="Calendar1_DayRender" CellPadding="4" DayNameFormat="Full"
                                NextPrevFormat="FullMonth" FirstDayOfWeek="Monday" ShowGridLines="True" OnSelectionChanged="Calendar1_SelectionChanged"
                                Height="10px" Width="500px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BorderColor="#CCCCCC" BackColor="#E2E2E2"
                                    Height="28px" />
                                <DayStyle BorderColor="#CCCCCC" Height="50px" />
                                <NextPrevStyle VerticalAlign="Bottom" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="Gray" />
                                <SelectedDayStyle BackColor="#F0DCDD" BorderColor="#CCCCCC" ForeColor="Black" Font-Bold="True"
                                    Height="50px" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#7B7B7B" BorderColor="Black" ForeColor="White" Font-Bold="True"
                                    Height="28px" />
                                <TodayDayStyle BackColor="#EFECEC" BorderColor="#777777" BorderStyle="Ridge" BorderWidth="2px"
                                    ForeColor="Black" Font-Bold="True" Height="50px" />
                            </asp:Calendar>
                            <br />
                            <asp:HiddenField ID="hidForModel" runat="server" />
                        </asp:Panel>
                    </center>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Tabular
                </HeaderTemplate>
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="center">
                                Attendance Report
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                    Width="926px">
                                    <Columns>
                                        <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="reason" HeaderText="Reason" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="parentapproval" HeaderText="Parent approval" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="teacherapproval" HeaderText="Parent approval" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <cc1:TimeSelector ID="TimeSelector1" runat="server">
                                </cc1:TimeSelector>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
</asp:Content>

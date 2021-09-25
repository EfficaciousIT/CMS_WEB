<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmPlanLeave.aspx.cs" Inherits="frmPlanLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Calendar ID="CalHolidays" runat="server" BackColor="#FCFBFB" CellPadding="4"
                            DayNameFormat="Full" FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="Black" Height="350px" NextPrevFormat="FullMonth" ShowGridLines="True"
                            Width="500px" OnDayRender="Calendar1_DayRender" VisibleDate="2014-11-01">
                            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BorderColor="#CCCCCC" BackColor="#E2E2E2"
                                Height="28px" />
                            <DayStyle BorderColor="#CCCCCC" Height="50px" />
                            <OtherMonthDayStyle ForeColor="Gray" />
                            <SelectedDayStyle BackColor="#F0DCDD" BorderColor="#CCCCCC" ForeColor="Black" Font-Bold="True"
                                Height="50px" BorderStyle="Ridge" />
                            <SelectorStyle BackColor="#CCCCCC" BorderStyle="Ridge" />
                            <TitleStyle BackColor="#7B7B7B" BorderColor="Black" ForeColor="White" Font-Bold="True"
                                Height="28px" />
                            <TodayDayStyle BackColor="#EFECEC" BorderColor="#777777" BorderStyle="Ridge" Height="50px" />
                            <WeekendDayStyle Font-Names="Verdana" Font-Size="8pt" />
                        </asp:Calendar>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

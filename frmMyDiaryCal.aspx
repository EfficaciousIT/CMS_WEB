<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMyDiaryCal.aspx.cs" Inherits="frmMyDiaryCal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>My Diary</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="generator" content="Microsoft Visual Studio, see http://msdn.microsoft.com/vstudio/" />
    <meta name="Description" content="Select a date" />
    <meta name="copyright" content="Copyright (c) 2011 Eco Friend & Company. All rights reserved." />
    <style type="text/css">
        #Cal
        {
            background-color: #f2f2f2;
            height: 100px;
            border: 2px solid White !important;
            -webkit-box-shadow: 0 0 30px 2px black;
            border-top: 0px !important;
        }
        .Caltable
        {
            width: 65%;
            margin-top: 10px;
        }
        #Cal th
        {
            height: 38px;
            font-weight: normal;
            border-bottom: outset 2px #fbfbfb;
            border-right: outset 2px #fbfbfb;
            color: #000 !important;
            font-family: Verdana;
            font-size: 12px;
            padding: 0px 11px;
        }
        #Cal td
        {
            color: #666666;
            background-color: White;
            border-color: White;
            border-width: 2px;
            border-style: Solid;
            width: 16%;
            height: 32px;
        }
        #Cal a
        {
            text-decoration: none;
            font-family: Verdana;
            font-size: 12px;
        }
        .event-heading
        {
            width: 98%;
            float: left;
            height: auto;
            padding: 5px;
            font-size: 14px;
            font-family: Verdana;
        }
        .event1
        {
            width: 100%;
            float: left;
            height: auto;
            background: #f5f5f5;
            margin-bottom: 5px;
        }
        .event1 label
        {
            width: 100%;
            height: auto;
            padding: 5px 5px;
            float: left;
        }
        .event2 label
        {
            width: 98%;
            height: auto;
            padding: 5px 5px;
            float: left;
        }
        .event3 label
        {
            width: 98%;
            height: auto;
            padding: 5px 5px;
            float: left;
        }
        .event2
        {
            width: 98%;
            float: left;
            height: 114px;
            background: #f5f5f5;
            margin-bottom: 5px;
        }
        .event3
        {
            width: 98%;
            float: left;
            height: 114px;
            background: #f5f5f5;
            margin-bottom: 5px;
        }
        #calbg
        {
            width: 1320px;
        }
        .clearfix
        {
            clear: both;
            margin: 0;
        }
        .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 1px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGrid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            text-align: left;
            color: #717171;
        }
        .mGrid th
        {
            padding: 4px 13px;
            color: #fff;
            text-align: left;
            background: #3498db;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .mGrid tr
        {
            height: 21px;
        }
        .mGrid .alt
        {
            background: #fff;
        }
        .mGrid .pgr
        {
            background: #424242;
        }
        .mGrid .pgr table
        {
            margin: 5px 0;
        }
        .mGrid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGrid .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGrid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input id="datechosen" type="hidden" name="datechosen" runat="server">
    <div id="calbg">
       <%-- <div id="calcontent" style="width: 26%; height: auto; float: left;">--%>
           <%-- <label style="font-family: Verdana; font-size: 13px">
                Year</label>
            <asp:DropDownList ID="YearSelect" Style="width: 90px; height: 25px; border-radius: 1px;"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="YearSelect_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;<label style="font-family: Verdana; font-size: 13px">
                Month</label>
            <asp:DropDownList ID="MonthSelect" Style="width: 90px; height: 25px; border-radius: 1px;"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="MonthSelect_SelectedIndexChanged">
                <asp:ListItem Value="01" Text="Jan"></asp:ListItem>
                <asp:ListItem Value="02" Text="Feb"></asp:ListItem>
                <asp:ListItem Value="03" Text="Mar"></asp:ListItem>
                <asp:ListItem Value="04" Text="Apr"></asp:ListItem>
                <asp:ListItem Value="05" Text="May"></asp:ListItem>
                <asp:ListItem Value="06" Text="Jun"></asp:ListItem>
                <asp:ListItem Value="07" Text="Jul"></asp:ListItem>
                <asp:ListItem Value="08" Text="Aug"></asp:ListItem>
                <asp:ListItem Value="09" Text="Sep"></asp:ListItem>
                <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
            </asp:DropDownList>--%>
           <%-- <asp:Calendar ID="Cal" CssClass="Caltable" runat="server" ShowTitle="False" ShowNextPrevMonth="False"
                DayNameFormat="Shortest" FirstDayOfWeek="Sunday" OnSelectionChanged="Cal_SelectionChanged"
                Width="65%" OnDayRender="Cal_DayRender">
                <TodayDayStyle Font-Bold="True" ForeColor="White" BackColor="#990000"></TodayDayStyle>
                <DayStyle BorderWidth="2px" ForeColor="#666666" BorderStyle="Solid" BorderColor="White"
                    BackColor="#EAEAEA"></DayStyle>
                <DayHeaderStyle ForeColor="#649CBA"></DayHeaderStyle>
                <SelectedDayStyle Font-Bold="True" ForeColor="#333333" BackColor="#FAAD50"></SelectedDayStyle>
                <WeekendDayStyle ForeColor="White" BackColor="#BBBBBB"></WeekendDayStyle>
                <OtherMonthDayStyle ForeColor="#666666" BackColor="White"></OtherMonthDayStyle>
            </asp:Calendar>--%>
            <%--<asp:Label ID="lblDate" runat="server" Visible="false">
            </asp:Label>--%>
       <%-- </div>--%>
        <div style="width: 70%; height: auto; float: left;">
            <div class="event-heading">
                Details</div>
            <div class="clearfix">
            </div>
            <div class="event1">
                <table>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="grvDetail" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="true"
                                CssClass="mGrid" Width="100%">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

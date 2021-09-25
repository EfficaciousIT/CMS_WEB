<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

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
            width: 55%;
            margin-top: 10px;
        }
        #Cal th
        {
            height: 50px;
            font-weight: 550;
            border-bottom: outset 2px #fbfbfb;
            border-right: outset 2px #fbfbfb;
            color: #000 !important;
            font-family: Verdana;
            font-size: 12px;
            padding: 5px;
        }
        #Cal td
        {
            color: #666666;
            background-color: White;
            border-color: White;
            border-width: 2px;
            border-style: Solid;
            width: 16%;
            height: 41px;
        }
        #Cal a
        {
            text-decoration: none;
            font-family: Verdana;
            font-size: 12px;
        }
        .event-heading{ width: 98%;
            float: left;
            height: auto; padding:5px; font-size:14px; font-family:Verdana;}
        .event1
        {
            width: 98%;
            float: left;
            height: 114px;
            background: #f5f5f5;
            margin-bottom: 5px;
        }
        .event1 label
        {
            width: 98%;
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
        #calbg{ width:1320px;}
        .clearfix{ clear:both; margin:0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input id="datechosen" type="hidden" name="datechosen" runat="server">
    <div id="calbg">
        <div id="calcontent" style="width: 38%; height: auto; float: left;">
            <label>
                Month</label>
            <asp:DropDownList ID="MonthSelect" Style="width: 180px; height: 25px; border-radius: 5px;"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="MonthSelect_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;
            <label>
                Year</label>
            <asp:DropDownList ID="YearSelect" Style="width: 180px; height: 25px; border-radius: 5px;"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="YearSelect_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Calendar ID="Cal" CssClass="Caltable" runat="server" ShowTitle="False" ShowNextPrevMonth="False"
                DayNameFormat="Full" FirstDayOfWeek="Sunday" OnSelectionChanged="Cal_SelectionChanged">
                <TodayDayStyle Font-Bold="True" ForeColor="White" BackColor="#990000"></TodayDayStyle>
                <DayStyle BorderWidth="2px" ForeColor="#666666" BorderStyle="Solid" BorderColor="White"
                    BackColor="#EAEAEA"></DayStyle>
                <DayHeaderStyle ForeColor="#649CBA"></DayHeaderStyle>
                <SelectedDayStyle Font-Bold="True" ForeColor="#333333" BackColor="#FAAD50"></SelectedDayStyle>
                <WeekendDayStyle ForeColor="White" BackColor="#BBBBBB"></WeekendDayStyle>
                <OtherMonthDayStyle ForeColor="#666666" BackColor="White"></OtherMonthDayStyle>
            </asp:Calendar>
            <asp:Label ID="lblDate" runat="server" Visible="false">
            </asp:Label>
        </div>
        <div style="width: 34%; height: auto;  float: left;">
        <div class="event-heading">Today&#39;s Remark</div>
        <div class="clearfix"></div>
            <div class="event1">
                <asp:Label ID="lblTodaysStudy1" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblTodaysStudy2" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblTodaysStudy3" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblTodaysStudy4" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblTodaysStudy5" runat="server" Visible="false">
                </asp:Label>
            </div>
            <div class="clearfix"></div>
              <div class="event-heading">Homework</div>
        <div class="clearfix"></div>
            <div class="event2">
                <asp:Label ID="lblHomework1" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblHomework2" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblHomework3" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblHomework4" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblHomework5" runat="server" Visible="false">
                </asp:Label>
            </div>
            <div class="clearfix"></div>
              <div class="event-heading">Message</div>
        <div class="clearfix"></div>
            <div class="event3">
                <asp:Label ID="lblMessage1" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblMessage2" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblMessage3" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblMessage4" runat="server" Visible="false">
                </asp:Label>
                <asp:Label ID="lblMessage5" runat="server" Visible="false">
                </asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

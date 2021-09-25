<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmStudentDashboard.aspx.cs"
    Culture="en-Gb" Inherits="frmStudentDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/AdminCss.css" type="text/css" />
    <style type="text/css">
        .event-calender
        {
            width: 46%;
            height: 300px;
            float: left;
            margin: 0 1%;
            background: #8fc74a;
            padding: 1%;
            text-align: center;
            font-size: 16px;
            color: #fff;
        }
        .heading
        {
            background: #F9AE0E;
            border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            -moz-border-radius: 5px 5px 0 0;
            height: auto;
            padding: 3px 10px;
            float: left;
            color: #fff;
            font-size: 14px;
            text-align: center;
            margin-top: 10px;
            margin-bottom: 10PX;
            width: 210px;
        }
        .container-outer
        {
            overflow: auto;
            position: relative;
            width: 900px;
            height: 500px;
        }
        .style1
        {
            width: 562px;
        }
        
        .modal
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        .mGrid-1 {
    width: 100%;
    background-color: #fff;
    border: solid 0px #525252;
    border-collapse: collapse;
    font: 10px Verdana, Helvetica, sans-serif;
}
        .mGrid td
        {
            font-size: 11px !important;
        }
        
        .mGrid-1 th {
    padding: 4px 2px;
    color: #fff;
    background: #3498db;
    border-left: solid 1px #525252;
    font-size: 0.9em;
    font: 11px verdana;
    height: 29px;
}
        .mGrid-1 td {
    border: solid 1px #c1c1c1;
    color: #fff;
}
        
        /* default layout */
        .ajax__tab_default .ajax__tab_header
        {
            white-space: normal !important;
        }
        .ajax__tab_default .ajax__tab_outer
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_inner
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
        }
        /* xp theme */
        .ajax__tab_xp .ajax__tab_header
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 11px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_outer
        {
            padding-right: 4px;
            background: #fff !important;
            height: 21px;
            font-size: 12px;
            padding: 4px 0;
            border: 1px solid #D5D5D5;
            margin-right: 2px;
        }
        .ajax__tab_xp .ajax__tab_inner
        {
            padding-left: 3px;
            background: #fff !important;
        }
        .ajax__tab_xp .ajax__tab_tab
        {
            height: 13px;
            padding: 4px;
            margin: 0px;
            background: #fff !important;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_outer
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_inner
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_tab
        {
            cursor: pointer;
            background: #fff !important;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_outer
        {
            background: #fff !important;
            border-right: 1px solid green;
            border-left: 1px solid green;
            border-top: 1px solid green;
            padding: 5px 0;
            border-radius: 5px 5px 0 0;
            margin-right: 2px;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_inner
        {
            background: #fff !important;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_tab
        {
            background: #fff !important;
            color: Green;
            font-size: 12px;
            font-weight: bold;
        }
        .ajax__tab_xp .ajax__tab_disabled
        {
            color: #A0A0A0;
        }
        .ajax__tab_xp .ajax__tab_body
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 10pt;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
        /* scrolling */
        .ajax__scroll_horiz
        {
            overflow-x: scroll;
        }
        .ajax__scroll_vert
        {
            overflow-y: scroll;
        }
        .ajax__scroll_both
        {
            overflow: scroll;
        }
        .ajax__scroll_auto
        {
            overflow: auto;
        }
        /* plain theme */
        .ajax__tab_plain .ajax__tab_outer
        {
            text-align: center;
            vertical-align: middle;
            border: 2px solid #999999;
        }
        .ajax__tab_plain .ajax__tab_inner
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_body
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_header
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_active .ajax__tab_outer
        {
            background: #FFF;
        }
        .style2
        {
            width: 100%;
        }
        .myCalendar td.myCalendarDay
        {
            border: outset 2px #fbfbfb !important;
            padding: 9px 24px !important;
        }
        .myCalendar .myCalendarDayHeader a, .myCalendar .myCalendarDay a, .myCalendar .myCalendarSelector a, .myCalendar .myCalendarNextPrev a
        {
            display: inline-block;
            line-height: 10px;
            width: 8px;
            font-size: 13px;
        }
        tr td
        {
            border: 0px solid #8fc74a;
            font-size: 13px;
            font-family: verdana;
        }
    </style>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="js/script.js"></script>
    <script type="text/javascript" language="javascript">


        window.onload = function () {
            var UserType = document.getElementById("HFUserType").value;
            var UserId = document.getElementById("HFUserId").value;
            setInterval(function callUserDetail() {
                $.ajax({
                    type: "POST",
                    url: "frmStudentDashboard.aspx/Notification",
                    data: '{UserType: ' + UserType + ',Id: ' + UserId + ' }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });


            }, 1000);


        }

        function OnSuccess(response) {
            if (response.d != 'false') {
                //               document.getElementById("lblMsgCount").innerText=response.d.toString();
                if (response.d > 0) {
                    $("#lblMsgCount").html(response.d.toString())
                }
            }
        }


        function DivScroll() {
            //  var element = document.getElementById("dvScroll");
            $("#pannel").scrollTop() = document.getElementById("dvScroll").scrollHeight;
        }
        window.onload = DivScroll();

        window.onload = function () {
            $.ajax({
                type: "POST",
                url: "frmStudentDashboard.aspx/GetCalAttData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

        }
    </script>
    <script>
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            // m = checkTime(m);
            s = checkTime(s);

            if (m < 10)
                m = "0" + m;

            var suffix = "AM";
            if (h >= 12) {
                suffix = "PM";
                h = h - 12;
            }
            if (h == 0) {
                h = 12;
            }
            var current_time = h + ":" + m + ":" + s + " " + suffix;



            var d = new Date();
            document.getElementById('lblTime').innerHTML = d.toDateString() + "  " + current_time;
            var t = setTimeout(function () { startTime() }, 500);
        }

        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
            return i;
        }
    </script>
</head>
<body onload="startTime()">
    <form id="frm" runat="server" style="margin-bottom: 0px">
    <div>
        <asp:ToolkitScriptManager runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td colspan="2" align="center" valign="top">
                            <div class="efficacious" id="efficacious">
                                <table width="80%" border="0">
                                    <tr>
                                        <td align="left" valign="top" style="position: relative; top: -8px; font-weight: bold;
                                            font-family: verdana;">
                                            <asp:Label ID="lblWelCome" runat="server" Width="100%" Text="Label"></asp:Label>
                                        </td>
                                        <td align="left" valign="top" style="width: 26%; position: relative; top: -7px;">
                                            <asp:Image ID="ImgProfile" runat="server" Style="height: 37px; width: 40px; border-radius: 30px;" />
                                        </td>
                                        <td align="left" valign="top" style="width: 20%; position: relative; top: -7px;">
                                            <asp:Label runat="server" Width="100%" Text="" ID="lblTime"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" CssClass="textsize"
                                                OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" Visible="False">
                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                <asp:ListItem Value="9">Sept</asp:ListItem>
                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%" valign="top">
                                            <table width="5%">
                                                <tr>
                                                    <td width="50%" valign="top" style="position: relative; top: -4px; padding-left: 46px;">
                                                        <a href="frmSendGroupMsg.aspx" style="width: 30px; height: 10px;" title="Message Notification">
                                                            <div style="background-image: url(images/Message.png); background-repeat: no-repeat;">
                                                                <div style="padding-top: 26px; padding-left: 35px;">
                                                                    <%--<asp:Label ID="lblMsgCount" runat="server" Width="5%" Text="0" BackColor="Red" ForeColor="White" Font-Size="Small"></asp:Label>--%>
                                                                </div>
                                                            </div>
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <div class="home_btn" style="position: relative; top: -5px;">
                                                            <a href="frmMonthlyAttendance.aspx">
                                                                <img src="images/home.png" title="Home" /></a>
                                                        </div>
                                                    </td>
                                                    <td style="position: relative; top: -4px;" valign="top" width="50%">
                                                        <a href="index.aspx">
                                                            <asp:Image ID="Image3" Style="padding-left: 7px; cursor: pointer; position: relative;
                                                                top: -2px; cursor: pointer;" ToolTip="Logout" runat="server" ImageUrl="~/images/Logout.png" /></a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:HiddenField ID="HFUserType" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HFUserId" runat="server" />
                        </td>
                    </tr>
                </table>
                <div id="dvScroll" runat="server">
                    <table width="100%" style="border-top: 1px solid #8fc74a;">
                        <tr>
                            <td width="50%" valign="top" style="border-right: 1px solid #8fc74a; background: #f5f5f5;">
                                <table width="98%">
                                    <tr>
                                        <td valign="top">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                                Width="100%">
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        Attendance</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <div>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td rowspan="2" valign="top">
                                                                        <asp:Panel ID="panel1" runat="server">
                                                                            <br>
                                                                            <asp:Calendar ID="CalAttendance" runat="server"  CssClass="myCalendar" OnDayRender="Calendar1_DayRender"
                                                                                CellPadding="4" OnSelectionChanged="CalAttendance_SelectionChanged">
                                                                                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                                                                <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                                                                <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2D3338" />
                                                                                <SelectedDayStyle CssClass="myCalendarSelector" Font-Bold="True" />
                                                                                <TodayDayStyle CssClass="myCalendarToday" />
                                                                                <SelectorStyle CssClass="myCalendarSelector" />
                                                                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                                                <TitleStyle CssClass="myCalendarTitle" />
                                                                            </asp:Calendar>
                                                                            <br />
                                                                            <br />
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td rowspan="2" valign="top">
                                                                        <%--<asp:Chart ID="ChrtSchoolAtt" Visible="False" runat="server" Height="110px" ViewStateContent="Default, Data"
                                                                            Width="200px">
                                                                            <Series>
                                                                                <asp:Series ChartArea="ChartArea" ChartType="Pie" Legend="Present" Name="Present ">
                                                                                </asp:Series>
                                                                            </Series>
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="ChartArea">
                                                                                    <Area3DStyle Enable3D="True" Inclination="50" IsClustered="True" WallWidth="10" />
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                            <Legends>
                                                                                <asp:Legend Name="Present">
                                                                                </asp:Legend>
                                                                            </Legends>
                                                                            <Titles>
                                                                                <asp:Title Docking="Bottom" Font="Times New Roman, 11.25pt" Name="Title1" Text="School Attendance">
                                                                                </asp:Title>
                                                                            </Titles>
                                                                            <BorderSkin BackColor="DarkSeaGreen" BackImageTransparentColor="128, 255, 128" BorderColor="LightGreen" />
                                                                        </asp:Chart>--%>
                                                                        <div style="font-size: 12px; box-shadow: none; background: none; margin-top: 9px;
                                                                            padding-left: 10px; padding-top: 10px;">
                                                                            Total
                                                                            <asp:Label ID="lblPresent" runat="server" Text="Total : "></asp:Label></div>
                                                                        <div style="font-size: 12px; box-shadow: none; background: none; margin-top: 9px;
                                                                            padding-left: 10px; padding-top: 10px;">
                                                                            Present
                                                                            <asp:Label ID="lblTotal" runat="server" Text="Present : "></asp:Label></div>
                                                                        <div style="font-size: 12px; box-shadow: none; background: none; margin-top: 9px;
                                                                            padding-left: 10px; padding-top: 10px;">
                                                                            Percent (%)
                                                                            <asp:Label ID="lblPercent" runat="server" Text="Absent"></asp:Label></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel runat="server" ID="Tabular" Width="100%">
                                                    <HeaderTemplate>
                                                        Tabular</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <div style="overflow: scroll; height: 200px; width: 100%;">
                                                                <asp:GridView ID="grvAttendance" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    CssClass="mGrid" EmptyDataText="Record not Found." Width="100%" PageSize="15">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="dtinTime" HeaderText="In-Time" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="dtoutTime" HeaderText="Out-Time" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="vchlatestatus" HeaderText="Status" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                            </div>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel Visible="false" runat="server" ID="Chart">
                                                    <HeaderTemplate>
                                                        Chart</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center">
                                                                        &#160;&nbsp;
                                                                    </td>
                                                                    <td align="center">
                                                                        &#160;&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                            </asp:TabContainer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <div class="lable" style="text-align:left;font-weight:bold;padding-left:5px;">
                                                <asp:Label ID="Label5" runat="server" Text="Last Five Logins"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grvLastLogin" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                PageSize="5" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="InTime" HeaderText="Login Time" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OutTime" HeaderText="Logout Time" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <div class="lable" style="text-align:left;font-weight:bold;padding-left:5px;">
                                                <asp:Label ID="Label7" runat="server" Text="Time Table"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grvTimetable" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                OnRowDataBound="grvTimetable_RowDataBound" Width="100%">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                                <RowStyle HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <div class="lable" style="text-align:left;padding-left:5px;">
                                                <asp:Label ID="Label15" runat="server" Text="Achievement's"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="efficacious">
                                                <table width="100%" align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdMessage" runat="server" CssClass="mGrid">
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" width="50%">
                                <table width="100%" align="right">
                                    <tr>
                                        <td>
                                            <table runat="server" width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <div class="lable" id="divNoticeBoard">
                                                            <asp:Label ID="Label3" runat="server" Text="Notice Board"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:GridView ID="grdNotice" CssClass="mGrid" runat="server">
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div id="divNoticeBorad" visible="false" runat="server" style="overflow: scroll;
                                                            height: 70px; width: 100%">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <div class="lable" runat="server" id="divLeave">
                                                                <asp:Label ID="Label6" runat="server" Style="padding-right: 15px;" Text="Leave Status"></asp:Label>
                                                                <asp:LinkButton ID="lnkApply0" runat="server" Font-Italic="True" Font-Underline="True"
                                                                    PostBackUrl="~/frmStudentLeaveMenu.aspx">Apply Leave</asp:LinkButton>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                DataKeyNames="intLeaveApplocation_id" OnPageIndexChanging="grvLeaveStatus_PageIndexChanging"
                                                                Width="100%" PageSize="5">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchLeaveType_name" HeaderText="Type" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkstatus" Text='<%#Eval("Status") %>' runat="server" OnClick="lnkstatus_Click"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TabContainer runat="server" ID="TabLeave" ActiveTabIndex="0" Width="100%">
                                                                <asp:TabPanel runat="server" ID="tbApply">
                                                                    <HeaderTemplate>
                                                                        Applied Leaves</HeaderTemplate>
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grvParentLeave" runat="server" AllowPaging="True" AllowSorting="True"
                                                                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                            DataKeyNames="intLeaveApplocation_id" OnPageIndexChanging="grvLeaveStatus_PageIndexChanging"
                                                                            Width="100%" PageSize="5">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Id" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="vchLeaveType_name" HeaderText="Type" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                                                                <asp:TemplateField HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkstatus" Text='<%#Eval("TeacherStatus") %>' runat="server"
                                                                                            OnClick="lnkstatus_Click"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <PagerStyle CssClass="pgr" />
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:TabPanel>
                                                                <asp:TabPanel runat="server" ID="tbLeave">
                                                                    <HeaderTemplate>
                                                                        Leaves For Approval</HeaderTemplate>
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grvStudentLeave" runat="server" AllowPaging="True" AllowSorting="True"
                                                                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                            DataKeyNames="intLeaveApplocation_id" OnPageIndexChanging="grvLeaveStatus_PageIndexChanging"
                                                                            Width="100%" PageSize="5">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Action">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAction" Text='<%#Eval("Action") %>' runat="server" OnClick="lnkAction_Click"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="vchLeaveType_name" HeaderText="Type" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                                                                <asp:TemplateField HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkstatus" Text='<%#Eval("TeacherStatus") %>' runat="server"
                                                                                            OnClick="lnkstatus_Click"></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <PagerStyle CssClass="pgr" />
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:TabPanel>
                                                            </asp:TabContainer>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%">
                                                            <asp:Panel runat="server" ID="pnlLeave" Width="30%" BackColor="White">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" style="background-color: WindowText" colspan="2" width="90%">
                                                                            <asp:Label ID="lblLeaveAction" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="background-color: WindowText" width="10%">
                                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/cross.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" align="center">
                                                                            <table width="98%" align="center">
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <br />
                                                                                        <asp:Label ID="Label17" runat="server" Text="Action"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2" valign="top">
                                                                                        <br />
                                                                                        <asp:RadioButtonList ID="rdbAction" runat="server" RepeatDirection="Horizontal" Width="70%">
                                                                                            <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                                                                            <asp:ListItem Value="2" Text="Reject"></asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="Label18" runat="server" Text="Remark"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="txtRemark" Rows="3" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" align="center" style="padding-right: 15px">
                                                                                        <br />
                                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:Button ID="btnLeave" runat="server" Style="display: none" />
                                                            <asp:ModalPopupExtender ID="ModalLeaveRemark" runat="server" TargetControlID="btnLeave"
                                                                BackgroundCssClass="modal" PopupControlID="pnlLeave" OkControlID="Image2" Enabled="True"
                                                                DynamicServicePath="">
                                                            </asp:ModalPopupExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlStudLateAtt" Width="80%" runat="server">
                                                                <center>
                                                                    <table width="100%" style="background-color: White">
                                                                        <tr>
                                                                            <td align="center" style="background-color: WindowText">
                                                                                <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="White" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                            <td align="right" style="background-color: WindowText">
                                                                                <asp:Image ID="ImgBtn" runat="server" ImageUrl="~/images/cross.png" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <asp:GridView ID="grvLeaveDetail" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                                                                                    Width="90%" AllowPaging="True" BorderStyle="Dotted" PageSize="5">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="PStatus" HeaderText="Parent Status" />
                                                                                        <asp:BoundField DataField="PDate" HeaderText="Approved Date" />
                                                                                        <asp:BoundField DataField="Premark" HeaderText="Remark" />
                                                                                        <asp:BoundField DataField="TStatus" HeaderText="Teacher Status" />
                                                                                        <asp:BoundField DataField="TDate" HeaderText="Approved Date" />
                                                                                        <asp:BoundField DataField="TRemark" HeaderText="Remark" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </center>
                                                            </asp:Panel>
                                                            <asp:Button ID="btnPop" runat="server" Style="display: none" />
                                                            <asp:ModalPopupExtender ID="ModalStudLateAtt" runat="server" TargetControlID="btnPop"
                                                                BackgroundCssClass="modal" PopupControlID="pnlStudLateAtt" OkControlID="ImgBtn"
                                                                Enabled="True" DynamicServicePath="">
                                                            </asp:ModalPopupExtender>
                                                            <%-- <asp:Panel ID="pnlStudAbsentAtt" Width="70%" runat="server">
                                                <center>
                                                    <table width="100%" style="background-color: White">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="lblLeaveType" runat="server" Text=""  ForeColor="White"
                                                                     Font-Size="Small"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                            </tr>
                                                            <tr>
                                                            <td>

                                                            </td>
                                                            </tr>
                                                            </table>
                                                            </center>
                                                            </asp:Panel>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <div runat="server" id="divLibrary" class="lable">
                                                                <asp:Label ID="Label8" runat="server" Text="Library Details"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr style="color:#fff !important">
                                                        <td >
                                                            <asp:GridView ID="grvLibrary" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="mGrid-1" EmptyDataText="Record not Found."
                                                                PageSize="5" Width="100%" OnRowDataBound="grvLibrary_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Book" HeaderText="Book Name" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Category" HeaderText="Category" />
                                                                    <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Return Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReturn" Text='<%#Eval("Return") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <div id="divFees" runat="server" class="lable">
                                                                <asp:Label ID="Label4" runat="server" Text="Fees Details"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grvFees" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                PageSize="5" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Desc" HeaderText="Description" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Paid Amount" HeaderText="Paid" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <RowStyle HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grvFeesPending" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                PageSize="5" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="vchFee" HeaderText="Description" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AmtWidDiscount" HeaderText="Pending" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Discount" HeaderText="Discount" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <RowStyle HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <%--<div class="heading">
                                                          <img align="left"  src="img/attendance.png" />Inventory</div>--%>
                                                            <div id="divInventory" runat="server" class="lable" visible="true">
                                                                <asp:Label ID="Label9" runat="server" Text="Inventory Details"></asp:Label>
                                                            </div>
                </div>
                </td> </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grvInventory" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="mGrid-1" EmptyDataText="Record not Found."
                            PageSize="5" Width="100%" OnRowDataBound="grvInventory_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Item" HeaderText="Items" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Return" HeaderText="Return Date" Visible="false" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Return Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReturn" Text='<%#Eval("Return") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual Return Date" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActual" Text='<%#Eval("dtActualReturnDt") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="lable">
                            <asp:Label ID="Label13" runat="server" Text="Holiday Details"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grvHoliday" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                            OnPageIndexChanging="grvAttendance_PageIndexChanging" PageSize="5" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="vchHoliday_name" HeaderText="Name" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FromDate" HeaderText="Date" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Day" HeaderText="Day" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="lable" id="divVacation" runat="server">
                            <asp:Label ID="Label14" runat="server" Text="Vacation Details"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grvVacation" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                            OnPageIndexChanging="grvVacation_PageIndexChanging" PageSize="5" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="vchVacation_name" HeaderText="Name" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FromDt" HeaderText="From Date" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ToDt" HeaderText="To Date" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="intNoOfDay" HeaderText="Total Days" />
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="lable" runat="server" id="divExams">
                            <asp:Label ID="Label16" runat="server" Text="Exam Schedule"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grvExam" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="mGrid" EmptyDataText="Record not Found." DataKeyNames="intExam_id"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamId" Text='<%#Eval("intExam_id") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exam Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkExamName" Text='<%#Eval("vchExamination_name") %>' runat="server"
                                            OnClick="lnkExamName_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="startDate" HeaderText="Start Date" ReadOnly="true" />
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlExam" Width="70%" runat="server">
                            <center>
                                <table width="100%" style="background-color: White">
                                    <tr>
                                        <td align="center" style="background-color: WindowText">
                                            <asp:Label ID="lblExamName" runat="server" Text="" ForeColor="White" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td align="right" style="background-color: WindowText">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/cross.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:GridView ID="grvExamDetails" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                                                Width="90%" BorderStyle="Dotted" PageSize="5">
                                                <Columns>
                                                    <asp:BoundField DataField="vchSubjectName" HeaderText="Subject" />
                                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                                    <asp:BoundField DataField="From" HeaderText="From Time" />
                                                    <asp:BoundField DataField="To" HeaderText="To Time" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </asp:Panel>
                        <asp:Button ID="Button1" runat="server" Style="display: none" />
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button1"
                            BackgroundCssClass="modal" PopupControlID="pnlExam" OkControlID="Image1" Enabled="True"
                            DynamicServicePath="">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
                </table> </center> </td> </tr> </table> </td> </tr> </table>
                <%--  <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grvLoginLogs" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                            PageSize="5" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InTime" HeaderText="Login Time" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OutTime" HeaderText="Logout Time" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <div class="lable">
                            <asp:Label ID="Label8" runat="server"  
                                 Text="Attendance"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" align="center" valign="top">
                    </td>
                    <td colspan="1" align="center">
                    </td>
                </tr>
                <tr>
                    <td class="style2" valign="top" align="center">
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <div class="lable">
                                        <asp:Label ID="Label4" runat="server" 
                                            Text="Vacations" ></asp:Label>
                                        <asp:ImageButton ID="ImgVacation" runat="server" ImageUrl="~/images/button-calendar.gif"
                                            ToolTip="View Calendar" PostBackUrl="~/frmVacationMst.aspx" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grvVacation" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                        OnPageIndexChanging="grvVacation_PageIndexChanging" PageSize="5" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="vchVacation_name" HeaderText="Name" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromDt" HeaderText="From Date" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ToDt" HeaderText="To Date" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="intNoOfDay" HeaderText="Total Days" />
                                        </Columns>
                                        <RowStyle HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="alt" />
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" align="center">
                                    <br />
                                    <div class="lable">
                                        <asp:Label ID="Label3" runat="server" 
                                            Text="Holidays" ></asp:Label>
                                        <asp:ImageButton ID="ImgHoliday" runat="server" ImageUrl="~/images/button-calendar.gif"
                                            OnClick="ImgHoliday_Click" ToolTip="View Calendar" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="grvHoliday" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                        OnPageIndexChanging="grvAttendance_PageIndexChanging" PageSize="5" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="vchHoliday_name" HeaderText="Name" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromDate" HeaderText="Date" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Day" HeaderText="Day" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="alt" />
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" align="center">
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <div class="lable">
                                        <asp:Label ID="Label6" runat="server" 
                                            Text="Leave Status" ></asp:Label>
                                        <asp:LinkButton ID="lnkApply0" runat="server"  Font-Italic="True"
                                            Font-Underline="True" PostBackUrl="~/frmStudentLeaveMenu.aspx">Apply Leave</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                        OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" Width="80%" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                            <asp:BoundField DataField="parentapproval" HeaderText="Parent Approval" />
                                            <asp:BoundField DataField="teacherapproval" HeaderText="Teacher Approval" />
                                        </Columns>
                                        <RowStyle HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="alt" />
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div class="lable">
                                        <asp:Label ID="Label9" runat="server"  
                                             Text="Event Details"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding-left: 60px">
                                    <div class="event-calender" style="width: 80%">
                                        <asp:Panel ID="panel2" runat="server">
                                            <br>
                                            <asp:Calendar ID="CalTraining" runat="server" Font-Names="Tahoma" Height="250px"
                                                Width="500px" Font-Size="14px" NextMonthText="" PrevMonthText="." DayNameFormat="Full"
                                                NextPrevFormat="FullMonth" SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar"
                                                OnDayRender="Calendar1_DayRender" CellPadding="4">
                                                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                                <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                                <DayHeaderStyle CssClass="myCalendarDayHeader" />
                                                <SelectedDayStyle  Font-Size="12px" CssClass="myCalendarSelector" />
                                                <TodayDayStyle CssClass="myCalendarToday" />
                                                <SelectorStyle CssClass="myCalendarSelector" />
                                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                <TitleStyle CssClass="myCalendarTitle" />
                                            </asp:Calendar>
                                            <br />
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                        </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <div class="lable">
                            <asp:Label ID="Label7" runat="server"  
                                Font-Size="Large" Text="Time Table"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grvTimetable" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                            Height="500px" OnRowDataBound="grvTimetable_RowDataBound" Width="95%">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrno" runat="server"  Text='<%#Eval("SrNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%#Eval("Time")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonday" runat="server" Text='<%#Eval("Monday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tuesday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTuesday" runat="server" Text='<%#Eval("Tuesday")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wednesday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWednesday" runat="server" Text='<%#Eval("Wednesday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thursday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThursday" runat="server" Text='<%#Eval("Thursday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Friday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFriday" runat="server" Text='<%#Eval("Friday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saturday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSaturday" runat="server" Text='<%#Eval("Saturday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BitRecess" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecess" runat="server" Text='<%#Eval("btrecess")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <RowStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                </table>--%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

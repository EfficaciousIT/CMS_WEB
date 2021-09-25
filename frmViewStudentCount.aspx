<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmViewStudentCount.aspx.cs"
    Inherits="frmViewStudentCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Reference Page="~/NewAdminDashBoard.aspx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        @media all
        {
            .lightbox
            {
                position: fixed; /* keeps the lightbox window in the current viewport */
                top: 150;
                left: 200;
                width: 100%;
                background-color: #FFFFFF;
                height: 100%;
                text-align: center;
            }
            .fl-page h1, .fl-page h3, .fl-page h4
            {
                font-family: 'HelveticaNeue-UltraLight' , 'Helvetica Neue UltraLight' , 'Helvetica Neue' , Arial, Helvetica, sans-serif;
                font-weight: 100;
                letter-spacing: 1px;
            }
            .fl-page h1
            {
                font-size: 110px;
                margin-bottom: 0.5em;
            }
            .fl-page h1 i
            {
                font-style: normal;
                color: #ddd;
            }
            .fl-page h1 span
            {
                font-size: 30px;
                color: #333;
            }
            .fl-page h3
            {
                text-align: right;
            }
            .fl-page h3
            {
                font-size: 15px;
            }
            .fl-page h4
            {
                font-size: 2em;
            }
            .fl-page .jumbotron
            {
                margin-top: 2em;
            }
            .fl-page .doc
            {
                margin: 2em 0;
            }
            .fl-page .btn-download
            {
                float: right;
            }
            .fl-page .btn-default
            {
                vertical-align: bottom;
            }
            .fl-page .btn-lg span
            {
                font-size: 0.7em;
            }
            .fl-page .footer
            {
                margin-top: 3em;
                color: #aaa;
                font-size: 0.9em;
            }
            .fl-page .footer a
            {
                color: #999;
                text-decoration: none;
                margin-right: 0.75em;
            }
            .fl-page .github
            {
                margin: 2em 0;
            }
            .fl-page .github a
            {
                vertical-align: top;
            }
            .fl-page .marketing a
            {
                color: #999;
            }
            /* override default feather style... */    .fixwidth
            {
                background: rgba(256,256,256, 0.8);
            }
            .fixwidth .featherlight-content
            {
                width: 500px;
                padding: 25px;
                color: #fff;
                background: #111;
                display: }}}
            .fixwidth .featherlight-close
            {
                color: #fff;
                background: #333;
            }
        }@media(max-width:768px){
            .fl-page h1 span
            {
                display: block;
            }
            .fl-page .btn-download
            {
                float: none;
                margin-bottom: 1em;
            }
        }
        .efficacious_send
        {
            width: 100px;
            color: #fff;
            font-size: 14px;
            text-align: center;
            background: #6fb92e;
            border: none;
            padding: 5px;
            margin-top: 10px;
        }
        .eff ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
            position: relative;
            float: right;
            background: #eee;
            border-bottom: 1px solid #fff;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }
        .eff li
        {
            float: left;
            list-style: none;
        }
        .eff #login
        {
            padding: 0 35px 49px;
        }
        .eff #login-trigger, .eff #signup a
        {
            display: inline-block; *display:inline;*zoom:1;height:25px;line-height:25px;font-weight:normal;padding-top:5px;text-decoration:none;color:#242424;font-size:12px;}
        .eff #signup a
        {
            -moz-border-radius: 0 3px 3px 0;
            -webkit-border-radius: 0 3px 3px 0;
            border-radius: 0 3px 3px 0;
        }
        .eff #login-trigger
        {
        }
        .eff #login-trigger:hover, .eff #login .active, .eff #signup a:hover
        {
            color: #242424;
            font-size: 12px;
            font-weight: normal;
            padding-top: 5px;
        }
        .eff #login-content
        {
            display: none;
            position: absolute;
            top: 42px;
            right: 291px;
            z-index: 999;
            background: #fff;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#eee));
            background-image: -webkit-linear-gradient(top, #fff, #eee);
            background-image: -moz-linear-gradient(top, #fff, #eee);
            background-image: -ms-linear-gradient(top, #fff, #eee);
            background-image: -o-linear-gradient(top, #fff, #eee);
            background-image: linear-gradient(top, #fff, #eee);
            padding: 15px;
            -moz-box-shadow: 0 2px 2px -1px rgba(0,0,0,.9);
            -webkit-box-shadow: 0 2px 2px -1px rgba(0,0,0,.9);
            box-shadow: 0 2px 2px -1px rgba(0,0,0,.9);
            -moz-border-radius: 3px 0 3px 3px;
            -webkit-border-radius: 3px 0 3px 3px;
            border-radius: 3px 0 3px 3px;
            width: 252px;
        }
        #login-content select
        {
            width: 110px;
            color: #345d10;
            height: 25px;
            float: left;
            border: 1px solid #dedede;
            margin-right: 10px;
        }
        #login-content textarea
        {
            margin-top: 5PX;
            color: #242424;
            height: 25px;
            float: left;
            border: 1px solid #dedede;
            width: 230px;
            padding-left: 10px;
        }
        .login li #login-content
        {
            right: 0;
            width: 250px;
        }
        .myCalendar
        {
            background-color: #f2f2f2;
            width: 156px;
            height: 100px;
            border: 2px solid White !important;
            -webkit-box-shadow: 0 0 30px 2px black;
            border-top: 0px !important;
        }
        .myCalendar a
        {
            text-decoration: none;
            color: White;
        }
        .myCalendar .myCalendarTitle
        {
            font-weight: bold;
            font-size: xx-large;
            height: 30px;
            line-height: 30px;
            background-color: #218122;
            color: #ffffff !important;
        }
        .myCalendar th.myCalendarDayHeader
        {
            height: 30px;
            font-size: smaller;
            color: Black;
            background-color: #ADA9A9;
            border-bottom: outset 2px #fbfbfb;
            border-right: outset 2px #fbfbfb;
        }
        .myCalendar td.myCalendarDay
        {
            border: outset 2px #fbfbfb;
        }
        .myCalendar td.myCalendarDay:nth-child(7) a
        {
            color: White !important;
        }
        .myCalendar .myCalendarNextPrev
        {
            text-align: center;
            font-size: 40px;
        }
        .myCalendar .myCalendarNextPrev a
        {
            font-size: 13px;
        }
        .myCalendar .myCalendarNextPrev:nth-child(1) a
        {
            color: black !important;
            background: url("prevMonth.png") no-repeat center center;
        }
        .myCalendar .myCalendarNextPrev:nth-child(1) a:hover, .myCalendar .myCalendarNextPrev:nth-child(3) a:hover
        {
            background-color: transparent;
        }
        .myCalendar .myCalendarNextPrev:nth-child(3) a
        {
            color: black !important;
            background: url("nextMonth.png") no-repeat center center;
        }
        .myCalendar td.myCalendarSelector a
        {
            background-color: #E6C520;
        }
        .myCalendar .myCalendarDayHeader a, .myCalendar .myCalendarDay a, .myCalendar .myCalendarSelector a, .myCalendar .myCalendarNextPrev a
        {
            display: inline-block;
            line-height: 25px;
        }
        .myCalendar .myCalendarToday
        {
            background-color: #8FC74A;
            -webkit-box-shadow: 0 0 7px 3px black;
            box-shadow: 0 0 7px 3px black;
        }
        .myCalendar .myCalendarToday a
        {
            color: white !important;
            font-size: medium;
        }
        .myCalendar .myCalendarDay a:hover, .myCalendar .myCalendarSelector a:hover
        {
            background-color: #DADFDA;
        }
        .MyTabStyle .ajax__tab_header
        {
            font-family: "Helvetica Neue" , Arial, Sans-Serif;
            font-size: 14px;
            font-weight: bold;
            display: block;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            height: 25px;
            border: solid 1px #d7d7d7;
            background: #fdfdfd;
            padding-top: 5px;
            font-size: 12px;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_inner
        {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
            background-image: none !important;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            height: 25px;
            border: solid 1px #d7d7d7;
            background: #fdfdfd;
            padding-top: 5px;
            cursor: pointer;
            font-size: 12px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_inner
        {
            color: #222;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_outer
        {
            border-bottom-color: #ffffff;
            background-color: #FFF;
            height: 29px;
            border-radius: 5px 5px 0 0;
            border: 1px solid green;
            border-bottom: none;
            padding-top: 5px;
            font-size: 14px;
            font-family: Verdana;
            cursor: pointer;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: green;
            border-color: #333;
        }
        .MyTabStyle .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #d7d7d7;
        }
        .setting1 ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
            position: relative;
            float: right;
            background: #eee;
            border-bottom: 1px solid #fff;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }
        .setting1 li
        {
            float: left;
            list-style: none;
        }
        .setting1 #set
        {
            padding: 0 35px 49px;
        }
        .setting1 #set-trigger, .eff #sign a
        {
            display: inline-block; *display:inline;*zoom:1;height:25px;line-height:25px;font-weight:normal;padding-top:5px;text-decoration:none;color:#242424;font-size:12px;}
        .setting1 #sign a
        {
            -moz-border-radius: 0 3px 3px 0;
            -webkit-border-radius: 0 3px 3px 0;
            border-radius: 0 3px 3px 0;
        }
        .setting1 #set-trigger
        {
            padding-top: 8px;
            cursor: pointer;
        }
        .setting1 #set-trigger:hover, .eff #set .active, .eff #sign a:hover
        {
            color: #242424;
            font-size: 12px;
            font-weight: normal;
            padding-top: 8px;
        }
        .setting1 #set-content
        {
            display: none;
            position: absolute;
            top: 42px;
            width: 100px !important;
            right: 329px;
            z-index: 999;
            background: #fff;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#eee));
            background-image: -webkit-linear-gradient(top, #fff, #eee);
            background-image: -moz-linear-gradient(top, #fff, #eee);
            background-image: -ms-linear-gradient(top, #fff, #eee);
            background-image: -o-linear-gradient(top, #fff, #eee);
            background-image: linear-gradient(top, #fff, #eee);
            padding: 15px;
            -moz-box-shadow: 0 2px 2px -1px rgba(0,0,0,.9);
            -webkit-box-shadow: 0 2px 2px -1px rgba(0,0,0,.9);
            box-shadow: 0 2px 2px -1px rgba(0,0,0,.9);
            -moz-border-radius: 3px 0 3px 3px;
            -webkit-border-radius: 3px 0 3px 3px;
            border-radius: 3px 0 3px 3px;
            width: 252px;
        }
        #set-content select
        {
            width: 110px;
            color: #345d10;
            height: 25px;
            float: left;
            border: 1px solid #dedede;
            margin-right: 10px;
        }
        #set-content textarea
        {
            margin-top: 5PX;
            color: #242424;
            height: 25px;
            float: left;
            border: 1px solid #dedede;
            width: 230px;
            padding-left: 10px;
        }
        .set li #set-content
        {
            right: 0;
            width: 250px;
        }
        .ajax__tab_tab
        {
            width: 74px;
            height: 23px;
            background: #71b338 !important;
            font-size: 12PX;
            color: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_tab
        {
            background: #345d0f !important;
        }
        .ajax__tab_xp .ajax__tab_inner
        {
            background-image: NONE !important;
        }
        th
        {
            background: #3498db;
            font-size: 13px;
            font-weight: normal;
            color: fff;
            height: 25px;
        }
        header, footer, aside, section, article, nav
        {
            display: block;
        }
        *
        {
            padding: 0;
            margin: 0;
        }
        body
        {
            font-family: Verdana, Geneva, sans-serif;
            background: #eeeeee;
        }
        .wrapper
        {
            width: 100%;
            height: auto;
        }
        .pagewrapper
        {
            width: 100%;
            margin: 0 auto;
            height: auto;
        }
        .logo
        {
            width: 15%;
            height: 40px;
            padding: 0 1%;
            float: left;
            background: url(img/logo-bg.jpg) repeat-x;
        }
        .logo img
        {
            width: 100%;
        }
        .user-profile
        {
            width: 80%;
            height: 40px;
            float: left;
            padding: 9px 16px 9px 14px;
            background: url(img/profile-bg.jpg) repeat-x;
        }
        .line
        {
            width: 100%;
            float: left;
            height: 6px;
            background: #43d5ca;
            float: left;
        }
        .clearfix
        {
            clear: both;
            margin: 0 auto;
        }
        .admin-gm
        {
            width: 20%;
            float: left;
            height: auto;
            padding: 10px 3px;
            font-size: 13px;
            color: #3d740d;
        }
        .admin-image
        {
            width: 6%;
            float: left;
            height: auto;
        }
        .admin-logout
        {
            width: 4%;
            float: left;
            height: auto;
            padding: 10px 1px;
            margin-right: 82px;
        }
        .admin-home
        {
            width: 4%;
            float: left;
            height: auto;
            padding: 4px 1px;
            margin-right: 50px;
        }
        .notification
        {
            width: 9%;
            height: auto;
            float: left;
            font-size: 12px;
            color: #242424;
            padding: 11px;
        }
        .notification-img
        {
            width: 1%;
            float: left;
            height: 15px;
            background: #356809;
            font-size: 12px;
            color: #fff;
            padding: 5px;
            margin-top: 5px;
        }
        .message-img
        {
            width: 1%;
            height: 15px;
            background: #356809;
            float: left;
            font-size: 12px;
            color: #fff;
            padding: 5px;
            margin-top: 5px;
        }
        .message
        {
            width: 7%;
            height: auto;
            float: left;
            font-size: 12px;
            color: #242424;
            padding: 11px;
        }
        .heading
        {
            background: #345d10;
            height: auto;
            padding: 3px 10px;
            float: left;
            color: #fff;
            font-size: 14px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10PX;
        }
        .ajax__tab_inner
        {
            background-image: none !important;
            padding-left: 0px !important;
        }
        .ajax__tab_outer
        {
            background-image: none !important;
        }
        .heading img
        {
            padding-right: 10px;
        }
        .left
        {
            width: 375px;
            height: auto;
            float: left;
            padding-left: 10px;
        }
        .right
        {
            width: 620px;
            height: auto;
            float: left;
        }
        .left-content
        {
            width: 350px;
            height: auto;
            float: left;
            background: #fff;
            box-shadow: 0px 10px 0px 0 #ccc;
            margin-bottom: 5px;
        }
        .right-content
        {
            height: auto;
            float: left;
            background: #fff;
            box-shadow: 0px 10px 0px 0 #ccc;
            margin-bottom: 5px;
        }
        .ajax__tab_xp .ajax__tab_header
        {
            background: none !important;
        }
        .ajax__tab_xp .ajax__tab_outer
        {
            padding-right: 1px !important;
        }
        td
        {
            text-align: center;
            font-size: 12px;
            height: 25px;
        }
        .ajax__tab_xp .ajax__tab_body
        {
            border: 1px solid #345d0f !important;
            padding: 0px !imporatnt;
        }
        #TabConAttendance_body
        {
            padding: 0px !important;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div >
        </div>
        <div>
            <asp:GridView ID="grvStaff" runat="server" Width="50%" EmptyDataText="No Record Found">
            </asp:GridView>
        </div>
        <div>
        </div>
        </form>
    </center>
</body>
</html>

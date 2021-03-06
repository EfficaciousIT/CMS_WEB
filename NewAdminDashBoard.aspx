<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="NewAdminDashBoard.aspx.cs"
    EnableEventValidation="false" Culture="en-Gb" Inherits="NewAdminDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html>
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <script type="text/javascript" src="jquery/jquery.min.js"></script>
    <script src="js/jquery-1.7.0.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- stylesheet for demo and examples -->
    <link rel="stylesheet" href="css/stylenew.css">
    <!--[if lt IE 9]>
	<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
	<![endif]-->
    <!-- custom scrollbar stylesheet -->
    <link rel="stylesheet" href="css/jquery.mCustomScrollbar.css">
    <!-- Google CDN jQuery with fallback to local -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>        window.jQuery || document.write('<script src="../js/minified/jquery-1.11.0.min.js"><\/script>')</script>
    <!-- custom scrollbar plugin -->
    <script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
    <script>
        (function ($) {
            $(window).load(function () {

                $("#content-3").mCustomScrollbar({
                    scrollButtons: { enable: true },
                    theme: "light-thick",
                    scrollbarPosition: "outside"
                });

                $("#content-4").mCustomScrollbar({
                    theme: "rounded-dots",
                    scrollInertia: 400
                });

                $("#content-5").mCustomScrollbar({
                    axis: "x",
                    theme: "dark-thin",
                    autoExpandScrollbar: true,
                    advanced: { autoExpandHorizontalScroll: true }
                });

                $("#content-6").mCustomScrollbar({
                    axis: "x",
                    theme: "light-3",
                    advanced: { autoExpandHorizontalScroll: true }
                });

                $("#content-7").mCustomScrollbar({
                    scrollButtons: { enable: true },
                    theme: "3d-thick"
                });

                $("#content-8").mCustomScrollbar({
                    axis: "yx",
                    scrollButtons: { enable: true },
                    theme: "3d",
                    scrollbarPosition: "outside"
                });

                $("#content-9").mCustomScrollbar({
                    scrollButtons: { enable: true, scrollType: "stepped" },
                    keyboard: { scrollType: "stepped" },
                    mouseWheel: { scrollAmount: 188 },
                    theme: "rounded-dark",
                    autoExpandScrollbar: true,
                    snapAmount: 188,
                    snapOffset: 65
                });

            });
        })(jQuery);

        // $(document).ready(function () { $('#content-3').mCustomScrollbar({ scrollButtons: { enable: true }, theme: 'light-thick', scrollbarPosition: 'outside' }); $('#content-4').mCustomScrollbar({ theme: 'rounded-dots', scrollInertia: 400 }); $('#content-5').mCustomScrollbar({ axis: 'x', theme: 'dark-thin', autoExpandScrollbar: true, advanced: { autoExpandHorizontalScroll: true} }); $('#content-6').mCustomScrollbar({ axis: 'x', theme: 'light-3', advanced: { autoExpandHorizontalScroll: true} }); $('#content-7').mCustomScrollbar({ scrollButtons: { enable: true }, theme: '3d-thick' }); $('#content-8').mCustomScrollbar({ axis: 'yx', scrollButtons: { enable: true }, theme: '3d', scrollbarPosition: 'outside' }); $('#content-9').mCustomScrollbar({ scrollButtons: { enable: true, scrollType: 'stepped' }, keyboard: { scrollType: 'stepped' }, mouseWheel: { scrollAmount: 188 }, theme: 'rounded-dark', autoExpandScrollbar: true, snapAmount: 188, snapOffset: 65 }); });
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $(".lightbox").hide();

            $("#SetTime").click(function () {

                $(".lightbox").fadeIn(500);
            });

            $("#closeLightbox").click(function () {

                $(".lightbox").fadeOut(500);
            });

        });
      
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
    <script src="js/featherlight.js" type="text/javascript" charset="utf-8"></script>
    <link type="text/css" rel="stylesheet" href="css/featherlight.css" title="Featherlight Styles" />
    <script src="jquery/main.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#login-trigger').click(function () {
                $(this).next('#login-content').slideToggle();
                $(this).toggleClass('active');

                if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
                else $(this).find('span').html('&#x25BC;')
            });


            $('#set-trigger').click(function () {
                $(this).next('#set-content').slideToggle();
                $(this).toggleClass('active');

                if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
                else $(this).find('span').html('&#x25BC;')
            });
        });
         



    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Admin Dashboard</title>
    <style type="text/css">
        .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 0px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGrid td
        {
            border: solid 1px #c1c1c1;
            color: #717171;
            text-align: left;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
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
            border-left: solid 0px #666;
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
            padding: 0 15px;
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
            background-color: #3498db;
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
            font-family: verdana, tahoma, helvetica;
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
            padding: 0 15px;
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
            right: 300px;
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
            background: #999 !important;
            font-size: 12PX;
            color: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_tab
        {
            background: #3498db !important;
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
            background: url(img/profile-bg.jpg) repeat-x;
            border-bottom: 6px solid #43d5ca;
        }
        .pagewrapper
        {
            width: 1024px;
            margin: 0 auto;
            height: auto;
            background: url(img/profile-bg.jpg) repeat-x;
        }
        .logo
        {
            width: 151px;
            height: auto;
            padding: 10px 1%;
            float: left;
            border-right: 1px solid #d5d5d5;
        }
        .logo img
        {
            width: 100%;
        }
        .user-profile
        {
            width: 813px;
            height: 40px;
            float: left;
            padding: 9px 11px 9px 11px;
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
            width: 180px;
            float: left;
            height: auto;
            padding: 10px 3px;
            font-size: 12px;
            color: #3d740d;
        }
        .admin-image
        {
            width: 6%;
            float: left;
            height: auto;
        }
        .admin-Time
        {
            padding: 10px 0px;
            float: left;
            height: auto;
            margin-right: 15px;
            font-family: verdana;
            font-size: 12px;
        }
        .admin-logout
        {
            width: 4%;
            float: left;
            height: auto;
            padding: 4px 1px;
            margin-right: 0px;
        }
        .admin-home
        {
            width: 4%;
            float: left;
            height: auto;
            padding: 4px 1px 4px 53px;
            margin-right: 0px;
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
            width: auto;
            height: 15px;
            background: #356809;
            float: left;
            font-size: 12px;
            color: #fff;
            padding: 5px 10px;
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
            background: #999;
            border-radius: 5px 5px 0 0;
            -webkit-border-radius: 5px 5px 0 0;
            -moz-border-radius: 5px 5px 0 0;
            height: auto;
            padding: 3px 10px;
            float: left;
            color: #fff;
            font-size: 14px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10PX;
            width: 210px;
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
            box-shadow: 0px 3px 0px 0 #ccc;
        }
        .right-content
        {
            width: 610px;
            height: auto;
            float: left;
            background: #fff;
            box-shadow: 0px 3px 0px 0 #ccc;
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
            font-size: 11px;
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
        .top-right
        {
            width: 50%;
            float: right;
        }
        .top-left
        {
            width: 50%;
            float: right;
        }
        /******** media 1920 start*******/@media only screen and (min-width: 1280px) and (max-width: 1920px)
        {
            .user-profile
            {
                width: 84%;
                height: 40px;
                float: left;
                padding: 9px 11px 9px 11px;
                background: url(img/profile-bg.jpg) repeat-x;
            }
            .pagewrapper
            {
                width: 100%;
                margin: 0 auto;
                height: auto;
                background: url(img/profile-bg.jpg) repeat-x;
            }
            .left
            {
                width: 48%;
                height: auto;
                float: left;
                padding: 0 1%;
            }
            .right
            {
                width: 48%;
                height: auto;
                float: left;
                padding: 0 1%;
            }
            .left-content
            {
                width: 100%;
                height: auto;
                float: left;
                background: #fff;
                box-shadow: 0px 3px 0px 0 #ccc;
            }
            .right-content
            {
                width: 100%;
                height: auto;
                float: left;
                background: #fff;
                box-shadow: 0px 3px 0px 0 #ccc;
            }
            .cal-left
            {
                width: 70%;
                float: left;
            }
            .cal-right
            {
                width: 30%;
                float: left;
            }
            .top-right
            {
                width: 50%;
                float: right;
            }
            .top-left
            {
                width: 50%;
                float: right;
            }
        }
        /******** media 1920 end*******//******** media 320 start*******/@media only screen and (min-width: 320px) and (max-width: 768px)
        {
            .pagewrapper
            {
                width: 100%;
                margin: 0 auto;
                height: auto;
                background: url(img/profile-bg.jpg) repeat-x;
            }
            .left
            {
                width: 98%;
                height: auto;
                float: left;
                padding: 0 1%;
            }
            .right
            {
                width: 98%;
                height: auto;
                float: left;
                padding: 0 1%;
            }
            .eff #login
            {
                padding: 0 8px 0px;
            }
            .left-content
            {
                width: 100%;
                height: auto;
                float: left;
                background: #fff;
                box-shadow: 0px 3px 0px 0 #ccc;
            }
            .right-content
            {
                width: 100%;
                height: auto;
                float: left;
                background: #fff;
                box-shadow: 0px 3px 0px 0 #ccc;
            }
            .cal-left
            {
                width: 70%;
                float: left;
            }
            .cal-right
            {
                width: 30%;
                float: left;
            }
            .user-profile
            {
                width: 98% !important;
                height: 40px;
                float: left;
                padding: 1% !important; ;}
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
                width: 70% !important;
            }
            .logo
            {
                width: 30% !important;
                height: auto;
                padding: 1% 1%;
                float: left;
                border-right: 1px solid #d5d5d5;
            }
            .logo img
            {
                width: 100%;
            }
            .admin-gm
            {
                width: 21% !important;
                float: left;
                height: auto;
                padding: 1% 1%;
                font-size: 12px;
                color: #3d740d;
            }
            .admin-Time
            {
                padding: 1% 1% !important;
                float: left;
                height: auto;
                margin-right: 15px;
                font-family: verdana;
                font-size: 12px;
                width: 31% !important;
            }
            .top-right
            {
                width: 50%;
                float: right;
            }
            .top-left
            {
                width: 50%;
                float: right;
            }
            
        }
        /******** media 320 end*******/</style>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"> </script>
    <script type="text/javascript" src="js/script.js"></script>
    <script language="javascript" type="text/javascript">

        function DivScroll() {
            //  var element = document.getElementById("dvScroll");
            $("#pannel").scrollTop() = document.getElementById("dvScroll").scrollHeight;
        }
        window.onload = function () {
            setInterval(function callUserDetail() {
                $.ajax({
                    type: "POST",
                    url: "NewAdminDashBoard.aspx/Notification",
                    data: '{UserType: "1",Id: "1" }',
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

                //                     $('<%# lblMsgCount.ClientID%>').html(response.d.toString())
                document.getElementById("lblMsgCount").innerText = response.d.toString();

            }
        }

        function SendMessage() {
            var Msg = $("#txtMsg").val()
            var Name = $("#ddlName").val()

            $.ajax({
                type: "POST",
                url: "NewAdminDashBoard.aspx/btnSend_Click",
                data: '{txtMsg: "' + Msg + '" ,ddlName: "' + Name + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessMsg,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function OnSuccessMsg(response) {
            if (response.d == 'false') {

                alert('Message cant be sent');

            }
            else {
                alert('Message has been sent successfully');
            }
        }


        function FillStaff(id) {
            $.ajax({
                type: "POST",
                url: "NewAdminDashBoard.aspx/FillStaff",
                data: '{Dept: "' + id + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#ddlName").empty();
                    $.each(data.d, function (key, value) {
                        $("#ddlName").append($("<option></option>").val(value.DataValueField).html(value.DataTextField));
                    });
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    </script>
</head>
<body onload="startTime()">
    <form id="frm" runat="server" style="background-color: #FFFFFF">
    <asp:ToolkitScriptManager runat="server" ID="T">
    </asp:ToolkitScriptManager>
    <div class="wrapper">
        <div class="pagewrapper">
            <header>
                    
      <div class="logo"><a href="frmAttendance.aspx"> <img src="img/logo.png" /></a> </div>
      <!--logo -->
      <div class="user-profile">
        <div class="admin-gm">
          <asp:Label ID="lblWelcomeName" runat="server" Text="Good"></asp:Label>
        </div><!--admin-gm -->

        <div class="admin-image">
        <img id="ImgAdmin" runat="server" style="padding:4px 0 0 0;border-radius: 20px; height:40px; width:40px;-moz-border-radius: 20px;
-webkit-border-radius: 20px;" src="images\Admin.jpg"  width="35" height="35"/>
        </div><!--admin-image -->
        <div class="admin-Time">
        <asp:Label runat="server" Text="" ID="lblTime"></asp:Label>
        </div>

        <ul class="eff">
       
		<li id="login">
			<a id="login-trigger" title="Send Message" style="padding:8px 0px;"  style="cursor: pointer;">
				<img src="img/message32.png" style="cursor: pointer;"/>
			</a>
			<div id="login-content">
				
                    <%--<select name="drpUserType" id="drpUserType" class="w-select">
	<option value="---Select---">---Select---</option>
	<option value="Student">Student</option>
	<option value="Parent">Parent</option>
	<option value="Teacher">Teacher</option>
	<option value="Staff">Staff</option>
	<option value="Administrator">Administrator</option>

</select>--%>
                    <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="false" 
                       onchange="return FillStaff(this.value);" >
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtMsg" runat="server" Height="40px" Rows="8" 
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="txtWater" runat="server" 
                        TargetControlID="txtMsg" WatermarkText="Enter Message Here">
                    </asp:TextBoxWatermarkExtender>
                    <asp:Button ID="btnSend" runat="server" CssClass="efficacious_send" 
                        Text="Send" OnClientClick="return SendMessage();" Width="80px" />
               
			</div>                     
		</li>
		
	</ul>
         <asp:HiddenField ID="HFUserType" runat="server" />
      <asp:HiddenField ID="HFUserId" runat="server" />
        <%--<div class="notification"><label>Notification</label></div>
        <div class="notification-img"><asp:Label ID="lblNotification" runat="server" Text="5"></asp:Label></div>--%>
        
        <div class="message"><label>Message</label></div>
        <div class="message-img"><a style="cursor:pointer;" href="frmSendGroupMsg.aspx"><asp:Label ID="lblMsgCount" runat="server" ForeColor="#FFFFFF" ></asp:Label></a></div>

         <ul class="setting1">
       
		<li id="set" style="position: relative;
  top: -8px;">
			<a id="set-trigger">
				<a id="SetTime" style="font-family:verdana;font-size:11px; cursor: pointer;;font-style:underline;"  data-featherlight="ajax"><img src="img/setting.png" /></a>
			</a>
			 <%--<div id="set-content">
				 <div class="Setting" style="padding: 5px 0px;"> Auto Refresh</div>
                <div class="Setting" style="padding: 5px 0px;" > <a id="LogOut" href="index.aspx" class="btn btn-default" style="font-family:verdana;font-size:11px; cursor: pointer;"  data-featherlight="ajax">Logout</a></div>
               
			</div>   --%>                  
		</li>
		
	</ul>
    <div class="admin-home">
        <a href="frmMonthlyAttendance.aspx" style="padding:5px;" title="Logout"><img src="img/home.png"  /></a>
        </div>
     <div class="admin-logout">
        <a href="index.aspx" style="padding:5px;" title="Logout"><img src="img/logout.png"  /></a>
        </div><!--admin-logout -->

      
      <!--user-profile -->
          </header>
            <div class="clearfix">
            </div>
            <section>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
      <div class="left">
      

      <!--------Calendar Start-------->
      
       <div class="heading">
      <img align="left" />Calendar</div>
      
      <div class="left-content">
      
      <div class="cal-left">
      
          <asp:Calendar ID="CalEvents" runat="server"  CssClass="myCalendar" 
              style=" margin:0 auto;border-collapse: inherit;" align="center" ondayrender="CalEvents_DayRender" 
              Width="100%"  onvisiblemonthchanged="CalEvents_VisibleMonthChanged1">
              
                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                              <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                              <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2D3338" />
                                              <SelectedDayStyle CssClass="myCalendarSelector" Font-Bold="True" />
                                              <TodayDayStyle CssClass="myCalendarToday" />
                                              <SelectorStyle CssClass="myCalendarSelector" />
                                              <NextPrevStyle CssClass="myCalendarNextPrev" />
                                              <TitleStyle CssClass="myCalendarTitle" />
              </asp:Calendar>
      
      </div>

      <div class="cal-right">
      <div class="left-content" style="font-size: 12px;
box-shadow: none;
background: none;
margin-top: 9px;
padding-left: 53px;
">
      <img src="img/green.png" /> Vacation </div><div class="left-content" style="font-size: 12px;
box-shadow: none;
background: none;
margin-top: 9px;
padding-left: 53px;
"> <img src="img/skyblue.png" /> Holiday</div> <div class="left-content" style="font-size: 12px;
box-shadow: none;
background: none;
margin-top: 9px;
padding-left: 53px;
"> <img src="img/traning.png" />
              Training      </div>
</div>


 </div>
      
    
      <!--------Calendar END-------->


      <!--------Attendance Start-------->
      <div class="heading">
      <img align="left"  />Attendance</div>
      
      <div class="left-content">
      <asp:TabContainer ID="TabConAttendance" runat="server" width="100%"  Visible="true"
              ActiveTabIndex="0">
      <asp:TabPanel ID="TBStudent" runat="server" ><HeaderTemplate>Staff</HeaderTemplate><ContentTemplate><asp:GridView ID="grvStaff" runat="server" AutoGenerateColumns="False" 
              Width="100%" CssClass="mGrid" onrowdatabound="grvStaff_RowDataBound"><Columns><asp:BoundField DataField="Count" HeaderText="Total " /><asp:TemplateField HeaderText="Present"><ItemTemplate><asp:LinkButton ID="lnkPresent" Text='<%#Eval("Present") %>' runat="server"></asp:LinkButton></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Absent"><ItemTemplate><asp:LinkButton ID="lnkAbsent" Text='<%#Eval("Absent") %>' runat="server"></asp:LinkButton></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Leave"><ItemTemplate><asp:LinkButton ID="lnkLeave" Text='<%#Eval("Leave") %>' runat="server"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></ContentTemplate></asp:TabPanel>
       <asp:TabPanel ID="TabPanel1" runat="server" ><HeaderTemplate>Teacher</HeaderTemplate><ContentTemplate><asp:GridView ID="grvTeacher" runat="server" AutoGenerateColumns="False" 
              Width="100%" OnRowDataBound="grvTeacher_RowDataBound"><Columns><asp:BoundField DataField="Count" HeaderText="Total " /><asp:TemplateField HeaderText="Present"><ItemTemplate><asp:LinkButton ID="lnkPresent" Text='<%#Eval("Present") %>' runat="server">0</asp:LinkButton></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Absent"><ItemTemplate><asp:LinkButton ID="lnkAbsent" Text='<%#Eval("Absent") %>' runat="server">0</asp:LinkButton></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Leave"><ItemTemplate><asp:LinkButton ID="lnkLeave" Text='<%#Eval("Leave") %>' runat="server">0</asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></ContentTemplate></asp:TabPanel>
       <asp:TabPanel ID="TabPanel2" runat="server" ><HeaderTemplate>Student</HeaderTemplate><ContentTemplate><asp:GridView ID="grvStudent" runat="server" AutoGenerateColumns="False" 
              Width="100%"><Columns><asp:BoundField DataField="Count" HeaderText="Total " /><asp:BoundField DataField="Present" HeaderText="Present" /><asp:BoundField DataField="Absent" HeaderText="Absent" /><asp:BoundField DataField="Leave" HeaderText="Leave" /></Columns></asp:GridView></ContentTemplate></asp:TabPanel>
      </asp:TabContainer>
      
      </div>
       <!--------Attendance END-------->

       <!--------Upcoming Events start-------->

        <div class="heading">
      <img align="left"  />Upcoming Events</div>

       <div class="left-content" style="height:100px;">
       <asp:GridView ID="grdUpcomingEvents" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                PageSize="5" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Event" HeaderText="Event" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="dtStartDate" HeaderText="Start Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="dtEndDate" HeaderText="End Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
       </div>



       <!--------Upcoming Events END-------->


        <!--------Last Five Logins start-------->

         <div class="heading">
      <img align="left" />Last Five Logins</div>

        <div class="left-content" style="height:100px; overflow:auto">
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
        </div>



       <!--------Last Five Logins END-------->
       
    
      
      
      
     </div><!--left -->
     
     
     <div class="right">


      <!--------Notice Start-------->
       <div class="heading">
      <img align="left" />Notice Board</div>
      
      <div class="left-content">
       <div id="divNoticeBorad" runat="server" style="overflow:scroll;height:100px;width:100%">
       <asp:GridView ID="grdNotice" CssClass="mGrid" runat="server">
       </asp:GridView>
       </div>
      
      
      </div>
      <!--------Notice END-------->

      <!--------Bus Status start-------->

        <div class="heading">
      <img align="left" />Bus Status</div>

       <div class="right-content" style="height:100px;">
       <asp:GridView ID="grdBusCnt" DataKeyNames="intdevice_id,dtStartTime,dtEndTime" runat="server" AutoGenerateColumns="False" 
              Width="100%" onrowdatabound="grdBusCnt_RowDataBound">
              <Columns>
                <asp:BoundField DataField="vchbusnumber" HeaderText="Bus No " />
                <asp:BoundField DataField="intime" HeaderText="In Time" />
                <asp:TemplateField HeaderText="Present">
                <ItemTemplate><asp:LinkButton ID="lnkPresent" Text='<%#Eval("inCount") %>' runat="server">0</asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="lefttime" HeaderText="Out Time" />
                <asp:TemplateField HeaderText="Present">
                <ItemTemplate><asp:LinkButton ID="lnkAbsent" Text='<%#Eval("outCount") %>' runat="server">0</asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                
              </Columns>
              </asp:GridView>
       </div>



       <!--------Bus Status END-------->


        <!--------Message start-------->

         <div class="heading">
      <img align="left" />Message</div>

        <div class="right-content" style="height:200px;">
            <table>                               
                                <tr>
                                    <td align="left" width="80px" style=" text-align:left;">
                                        <asp:Label ID="lblUserType" runat="server" Text="User type"></asp:Label>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:DropDownList ID="drpUserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpUserType_SelectedIndexChanged">
                                            <asp:ListItem>---select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr style=" text-align:left;">
                                <tr visible="false" runat="server" id="trStudent">
                                    <td align="left" style=" text-align:left;">
                                        <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                            <asp:ListItem>---select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:Label ID="Label11" runat="server" Text="Division"></asp:Label>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDivision_SelectedIndexChanged"
                                            Style="height: 22px">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:Label ID="Label12" runat="server" Text="Student"></asp:Label>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:DropDownList ID="drpStudent" runat="server">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    
                                </tr>
                                <tr  visible="false" runat="server" id="trStaff">
                                    <td  align="left" style=" text-align:left;">
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                            <asp:ListItem>---select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:Label ID="Label13" runat="server" Text="Staff"></asp:Label>
                                    </td>
                                    <td align="left" style=" text-align:left;">
                                        <asp:DropDownList ID="drpStaff" runat="server">
                                            <asp:ListItem>---select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="left" style=" text-align:left;">
                                        <asp:Label ID="Label16" runat="server" Text="Notice"></asp:Label>
                                    </td>
                                    <td colspan="5" style=" text-align:left;">
                                        <asp:TextBox ID="txtNotice" runat="server" Height="68px" Width="335px"></asp:TextBox>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                    </td>
                                    <td style=" text-align:left;">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                               
                            </table>
        </div>



       <!--------Message END-------->

        <!--------Chat start-------->

         <div class="heading">
      <img align="left" />Chat</div>

        <div class="right-content" style="height:100px;"></div>



       <!--------Chat END-------->



     <!--------Pending Start-------->
     
     <div class="heading">
      <img align="left" />Pending Leave</div>
      
      <div class="right-content">
      <div id="content" runat="server" style="height:100px; overflow:scroll;" class="content mCustomScrollbar light" data-mcs-theme="minimal-dark">

      <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" 
              EmptyDataText="Record not Found." DataKeyNames="intLeaveApplocation_id" PageSize="6" 
              Width="100%" Font-Names="Microsoft Sans Serif" 
              onrowdatabound="grvLeaveStatus_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserId" Text='<%#Eval("intUser_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserTypeID" Text='<%#Eval("intUserType_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Dept" HeaderText="Department" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Type" HeaderText="Type Of Leave" />
                                                    <asp:BoundField DataField="Dt" HeaderText="Date" ReadOnly="True"></asp:BoundField>
                                                    <asp:BoundField DataField="intTotalDays" HeaderText="Total Days" />                                                   
                                                    <asp:TemplateField HeaderText="Detail">
                                                        <ItemTemplate>
                                                         <asp:LinkButton ID="lnkDetail" Text="View" 
                                                                runat="server" onclick="lnkDetail_Click"  ></asp:LinkButton>
                                                  <%--              <a class="btn btn-default" id="as1" runat="server" href="javascript:__doPostBack('grvLeaveStatus$ctl02$lnkDetail','')" data-featherlight="#fl1">View</a--%>&gt;
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                            </div>
      
      
      </div>
       <!--------Pending END-------->
       
        <!--------Pending Start-------->
     
     <div class="heading" style="display:none">
      <img align="center"  src="img/attendance.png" />Live Lecture Details</div>
      
      <div class="right-content" style="display:none">
       <div id="content-6" style="height:126px; " class="content mCustomScrollbar light" data-mcs-theme="minimal-dark">

      <asp:GridView ID="grvLectureAtt" runat="server" AllowPaging="True" 
          AllowSorting="True" AutoGenerateColumns="False" 
       EmptyDataText="Record not Found."  
              PageSize="8"   Width="100%">
    <Columns>
        <asp:BoundField DataField="vchStandard_name" HeaderText="STD" ReadOnly="True" />
        <asp:BoundField DataField="vchDivisionName" HeaderText="DIV" ReadOnly="True" />
        <asp:BoundField DataField="vchRoom_name" HeaderText="Room No">
        </asp:BoundField>
        <asp:BoundField HeaderText="Subject" DataField="vchSubjectName">
        </asp:BoundField>
        <asp:BoundField DataField="Name" HeaderText="Teacher" ReadOnly="True" />
        <asp:BoundField DataField="Present" HeaderText="Present" ReadOnly="True" />
        <asp:BoundField HeaderText="Absent"  Visible="False"/>
                                                    
        <asp:TemplateField HeaderText="Out Of Class">
            <ItemTemplate>
                <asp:LinkButton ID="lnkOutOf" runat="server" Text='<%#Eval("OutOf") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                                                    
        <asp:BoundField DataField="Temp" HeaderText="Temporary Teacher" 
            ReadOnly="True" />
    </Columns>
    <RowStyle HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="alt" />
    <PagerStyle CssClass="pgr" />
</asp:GridView>
      
      </div>
      </div>
       <!--------Pending END-------->
       
        <!--------Pending Start-------->
     
     <div class="heading" style="display:none">
      <img align="center"  src="img/attendance.png" />Bus Attendance Details</div>
      
      <div class="right-content"style="display:none">
       <div id="content-6" style="height:126px; " class="content mCustomScrollbar light" data-mcs-theme="minimal-dark">
      <asp:GridView ID="grvBusAtt" runat="server" AllowPaging="True" AllowSorting="True"
       AutoGenerateColumns="False"  DataKeyNames="intBus_id"
              CssClass="mGrid" EmptyDataText="Record not Found." PageSize="8" 
              Width="100%" onrowdatabound="grvBusAtt_RowDataBound" 
              onrowdeleting="grvBusAtt_RowDeleting" onrowediting="grvBusAtt_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="BusId" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblBusId"  Text='<%#Eval("intBus_id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="vchBusNumber"  HeaderText="Bus Name" ReadOnly="True" />
                    <asp:BoundField HeaderText="Departure" ReadOnly="true" DataField="Departure"/>
                    <asp:BoundField HeaderText="Arrival" ReadOnly="true" DataField="Arrival">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Present">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPresent" Text='<%#Eval("Present") %>'  CommandName="Edit" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Absent">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAbsent" Text='<%#Eval("Absent") %>' CommandName="Delete" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Speed" ReadOnly="true" DataField="Speed"/>
                </Columns>
    <RowStyle HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="alt" />
    <PagerStyle CssClass="pgr" />
</asp:GridView>
      </div>
      </div>
       <!--------Pending END-------->
 
     
     </div><!--right -->
      </section>
                </div>
                <!--pagewrapper -->
            </div>

                 <div class="lightbox" style=" background:url(img/bg.png) repeat-x; width:100%; top:64; left:0; min-height:auto;">
                 <div style="width:30%; position:relative; top:100PX; margin:0 auto; min-height:160px;background:#FFFFFF;opacity:none;" >
			<table width="100%" align="right">
            <tr>
            <td colspan="2" align="right" width="100%" style="text-align:right;">
                 <img alt=""  src="img/closed.png" id="closeLightbox" />
            </td>
            </tr>
            <tr>
            <td>
            <asp:Label ID="lblSetTime" runat="server" Text="Set Timer"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSet" style="width: 170px;height: auto;padding: 5px;border-radius: 5px;" runat="server">
                <asp:ListItem Text="2 min" Value="120000"></asp:ListItem>
                <asp:ListItem Text="3 min" Value="180000"></asp:ListItem>
                <asp:ListItem Text="5 min" Value="300000"></asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td colspan="2">
            </td>
            </tr>
            <tr>
            <td colspan="2">
                <asp:Button ID="btnSet" OnClientClick="RefreshPage();" 
                    style="width: 70px;height: auto;padding: 5px;border-radius: 5px;border: none;background-color: #f99d36;color: #fff;font-size: 14px;font-family: verdana;" 
                    runat="server" Text="Set" onclick="btnSet_Click" />
            </td>
            </tr>
            </table>
            </div>
      </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlDept" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <!--wrapper -->
    </form>
</body>
</html>

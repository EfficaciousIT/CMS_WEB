<%@ Page Title="Equiry Form" Language="C#" AutoEventWireup="true"
    CodeFile="FrmEquiry_Form.aspx.cs" Inherits="FrmEquiry_Form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">--%>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
    <title></title>
     <link href="styles/styles.css" rel="stylesheet" type="text/css" />
     <link href="sty/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        @charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset"utf-8";/* CSS Document */
        .efficacious label
        {
            display: block;
            height: auto;
            padding: 10px 0px;
            font-size: 18px;
            border: 1px solid #242424;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 120px;
            color: #000;
        }


        #efficacious
        {
            background: #e5e5e5;
            border-radius: 7px;
            height: 30px;
            padding: 2px;
            width: 90%;
            margin-bottom: 5px;
        }
        .efficacious span
        {
            display: block;
            height: auto;
            padding: 10px 0px;
            font-size: 12px;
            margin: 2% 5%;
            padding: 2%;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 120px;
            color: #000;
        }
        .efficacious input, form.winner-inside textarea
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            font-family: 'verdana';
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .efficacious input.winner-inside
        {
            width: 100%;
            background: #ffff;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin-top: 10px;
        }
        .efficacious select
        {
            width: 100%;
            border: 1px solid #3498db;
            padding: 2px 5px;
            height: 26px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            font-size: 13px;
            margin-bottom: 10px;
        }
        .efficacious textarea
        {
            width: 100%;
            border: 1px solid #3498db;
            padding: 5px 5px;
            height: 32px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            font-size: 13px;
            margin-bottom: 10px;
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
            height: 50px;
            line-height: 50px;
            background-color: #3498db;
            color: #ffffff;
        }
        .myCalendar th.myCalendarDayHeader
        {
            height: 50px;
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
            line-height: 40px;
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
         .efficacious input[type="image"] {
           border:0px;
           padding:0px;
        }


.efficacious input.efficacious_send
        {
            
            background: #3498db;
            border: 1px solid #00000;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center;
        }
        .efficacious input[type=checkbox]:checked + label:after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=100);
            opacity: 1;
        }
        
               .efficacious input[type=checkbox]:checked + label:after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=100);
            opacity: 1;
        }
        
        
        .efficacious input[type=checkbox], input[type=radio]
{
      display          : block;
    width            : 1.1em;
    height           : 1.3em;
    border           : 0.0625em solid rgb(192,192,192);
    border-radius    : 0.25em;
    background       : black;

    
    vertical-align   : middle;
    line-height      : 1em;
    font-size        : 14px;
}

.efficacious label
{
    display: inline;
    float: left;
    color: #000;
    cursor: pointer;
    text-indent: 20px;
    white-space: nowrap;
}

.efficacious input[type=checkbox] + label
{
    display          : block;
    width            : 1.1em;
    height           : 0.3em;
    border           : 0.0625em solid rgb(192,192,192);
    border-radius    : 0.25em;
    background       : black;

    
    vertical-align   : middle;
    line-height      : 1em;
    font-size        : 14px;
}



.efficacious input[type=radio] + label  
{
    display          :block;
    width            : 8em;
    height           : 1em;
    border           : 0.0625em solid rgb(192,192,192);
    border-radius    : 1em;
    background       : rgb(211,168,255);
    background-image : -moz-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -ms-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -o-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -webkit-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : linear-gradient(rgb(240,240,240),rgb(211,168,255));
    vertical-align   : middle;
    line-height      : 1em;
    font-size        : 14px;
}

        *
        {
            margin: 0;
            padding: 0;
        }
        header, section, article, nav, aside, footer, video, audio, datalist, details
        {
            display: block;
        }
        img
        {
            display: block;
        }
        p
        {
            font-size: 14px;
            line-height: 18px;
            text-align: left;
        }
        h1, h2, h3, h4, h5
        {
            font-size: 18px;
            color: blue;
        }
        .wrapper
        {
            width: 100%;
            height: auto;
        }
        .pagewrapper
        {
            width: 1024px;
            min-height: 630px;
            margin: 0 auto;
            padding-top: 10px;
            background: #fff;
        }
        .top
        {
            width: 1024px;
            height: 60px;
        }
        .clearfix
        {
            clear: both;
            margin: 0;
        }
        .topmenu
        {
            width: 1024px;
            height: auto;
            float: left;
            border-top: 1px solid #b3d89c;
            border-bottom: 1px solid #b3d89c;
            margin-bottom: 8px;
        }
        #menu, #menu ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        #menu
        {
            width: 1024px;
            margin: 0px auto;
            background-image: -moz-linear-gradient(#444, #111);
            background-image: -o-linear-gradient(#444, #111);
            background-image: -ms-linear-gradient(#444, #111);
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            -moz-box-shadow: 0 1px 1px #777, 0 1px 0 #666 inset;
        }
        #menu:before, #menu:after
        {
            content: "";
            display: table;
        }
        #menu:after
        {
            clear: both;
        }
        #menu
        {
            zoom: 1;
        }
        #div1
        {
            background-color: red;
            width: 300px;
            height: 200px;
            z-index: 99999999999;
        }
        #menu li
        {
            float: left;
            border-right: 1px solid #429c06;
            position: relative;
        }
        #menu a
        {
            float: left;
            padding: 70px 33px 5px 37px;
            color: #429c06;
            text-transform: capitalize;
            font: 12px verdana, Arial, Helvetica;
            text-decoration: none;
        }
        #menu li:hover > a
        {
            color: #429c06;
        }
        *html #menu li a:hover
        {
            /* IE6 only */
            color: #fafafa;
        }
        #menu ul
        {
            margin: 20px 0 0 0;
            _margin: 0; /*IE6 only*/
            opacity: 0;
            visibility: hidden;
            position: absolute;
            top: 89px;
            left: 0;
            z-index: 1;
            background: #f5f5f5;
            -webkit-transition: all .2s ease-in-out;
            -moz-transition: all .2s ease-in-out;
            -ms-transition: all .2s ease-in-out;
            -o-transition: all .2s ease-in-out;
            transition: all .2s ease-in-out;
        }
        #menu li:hover > ul
        {
            opacity: 1;
            visibility: visible;
            margin: 0;
        }
        #menu ul ul
        {
            top: 0;
            left: 150px;
            margin: 0 0 0 20px;
            _margin: 0; /*IE6 only*/
            -moz-box-shadow: -1px 0 0 rgba(255,255,255,.3);
            -webkit-box-shadow: -1px 0 0 rgba(255,255,255,.3);
            box-shadow: -1px 0 0 rgba(255,255,255,.3);
        }
        #menu ul li
        {
            float: none;
            display: block;
            border: 0;
            _line-height: 0; /*IE6 only*/
        }
        #menu ul li:last-child
        {
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
        #menu ul a
        {
            padding: 10px;
            width: 130px;
            _height: 10px; /*IE6 only*/
            display: block;
            white-space: nowrap;
            float: none;
            text-transform: none;
        }
        #menu ul a:hover
        {
        }
        #menu ul li:first-child > a
        {
            -moz-border-radius: 3px 3px 0 0;
            -webkit-border-radius: 3px 3px 0 0;
            border-radius: 3px 3px 0 0;
        }
        #menu ul li:first-child > a:after
        {
            content: '';
            position: absolute;
            left: 40px;
            top: -6px;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            border-bottom: 1px solid #429c06;
        }
        #menu ul ul li:first-child a:after
        {
            left: -6px;
            top: 50%;
            margin-top: -6px;
            border-left: 0;
            border-bottom: 6px solid transparent;
            border-top: 6px solid transparent;
            border-right: 6px solid #3b3b3b;
        }
        #menu ul li:first-child a:hover:after
        {
            border-bottom-color: #429c06;
        }
        #menu ul ul li:first-child a:hover:after
        {
            border-right-color: #0299d3;
            border-bottom-color: transparent;
        }
        #menu ul li:last-child > a
        {
            -moz-border-radius: 0 0 3px 3px;
            -webkit-border-radius: 0 0 3px 3px;
            border-radius: 0 0 3px 3px;
        }
        #DivPrivacy
        {
            font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 10px solid #ccc;
            border-radius: 3px 3px 3px 3px;
            color: #333333;
            display: none;
            left: 50%;
            margin-left: -480px;
            margin-top: -100px;
            position: fixed;
            top: 20%;
            width: 930px;
            z-index: 2;
        }
        /* Mobile */#menu-trigger
        {
            display: none;
        }
        @media screen and (max-width: 600px)
        {
            /* nav-wrap */    #menu-wrap
            {
                position: relative;
            }
            #menu-wrap *
            {
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
                box-sizing: border-box;
            }
            /* menu icon */    #menu-trigger
            {
                display: block; /* show menu icon */
                height: 40px;
                line-height: 40px;
                cursor: pointer;
                padding: 0 0 0 35px;
                border: 1px solid #222;
                color: #fafafa;
                font-weight: bold;
                -moz-border-radius: 6px;
                -webkit-border-radius: 6px;
                border-radius: 6px;
                -moz-box-shadow: 0 1px 1px #777, 0 1px 0 #666 inset;
                -webkit-box-shadow: 0 1px 1px #777, 0 1px 0 #666 inset;
                box-shadow: 0 1px 1px #777, 0 1px 0 #666 inset;
            }
            /* main nav */    #menu
            {
                margin: 0;
                padding: 10px;
                position: absolute;
                top: 40px;
                width: 100%;
                z-index: 1;
                background-color: #444;
                display: none;
                -moz-box-shadow: none;
                -webkit-box-shadow: none;
                box-shadow: none;
            }
            #menu:after
            {
                content: '';
                position: absolute;
                left: 25px;
                top: -8px;
                border-left: 8px solid transparent;
                border-right: 8px solid transparent;
                border-bottom: 1px solid #429c06;
            }
            #menu ul
            {
                position: static;
                visibility: visible;
                opacity: 1;
                margin: 0;
                background: none;
                -moz-box-shadow: none;
                -webkit-box-shadow: none;
                box-shadow: none;
            }
            #menu ul ul
            {
                margin: 0 0 0 20px !important;
                -moz-box-shadow: none;
                -webkit-box-shadow: none;
                box-shadow: none;
            }
            #menu li
            {
                position: static;
                display: block;
                float: none;
                border: 0;
                margin: 5px;
                -moz-box-shadow: none;
                -webkit-box-shadow: none;
                box-shadow: none;
            }
            #menu ul li
            {
                margin-left: 20px;
                -moz-box-shadow: none;
                -webkit-box-shadow: none;
                box-shadow: none;
            }
            #menu a
            {
                display: block;
                float: none;
                padding: 0;
                color: #999;
            }
            #menu a:hover
            {
                color: #fafafa;
            }
            #menu ul a
            {
                padding: 0;
                width: auto;
            }
            #menu ul a:hover
            {
                background: none;
            }
            #menu ul li:first-child a:after, #menu ul ul li:first-child a:after
            {
                border: 0;
            }
        }
        @media screen and (min-width: 600px)
        {
            #menu
            {
                display: block !important;
            }
        }
        /* iPad */.no-transition
        {
            -webkit-transition: none;
            -moz-transition: none;
            -ms-transition: none;
            -o-transition: none;
            transition: none;
            opacity: 1;
            visibility: visible;
            display: none;
        }
        #menu li:hover > .no-transition
        {
            display: block;
        }
        .loginNew
        {
            background: url(images/Layer5.png) no-repeat -500px 0px;
        }
        .loginNew:hover
        {
            background: url(images/Layer6.png) no-repeat -500px 0px;
        }
        .logout
        {
            background: url(images/Layer5.png) no-repeat -500px 0px;
        }
        .logout:hover
        {
            background: url(images/Layer6.png) no-repeat -500px 0px;
        }
        .logo
        {
            width: 349px;
            height: auto;
            float: left;
            padding-left: 161px;
        }
        .home_btn
        {
            width: 30px;
            height: 30px;
            padding: 05px 10px 16px 10px;
            float: left;
            background: url(images/Layer6.png) no-repeat -500px 0px;
        }
        .home_btn:hover
        {
            width: 30px;
            height: 30px;
            padding: 05px 10px 16px 10px;
            float: left;
            background: url(images/Layer6.png) no-repeat -500px 0px;
        }
        .btn_logout
        {
            width: 30px;
            height: 30px;
            padding: 05px 10px 16px 10px;
            float: left;
        }
        .attendace
        {
            background: url(images/menu-bg.png) no-repeat -3px 0px;
        }
        .attendace:hover
        {
            background: url(images/menu-bg1.png) no-repeat -3px 0px;
        }
        .leave
        {
            background: url(images/menu-bg.png) no-repeat -148px 0px;
        }
        .leave:hover
        {
            background: url(images/menu-bg1.png) no-repeat -148px 0px;
        }
        .calendar
        {
            background: url(images/menu-bg.png) no-repeat -260px 0px;
        }
        .calendar:hover
        {
            background: url(images/menu-bg1.png) no-repeat -260px 0px;
        }
        .services
        {
            background: url(images/menu-bg.png) no-repeat -376px 0px;
        }
        .services:hover
        {
            background: url(images/menu-bg1.png) no-repeat -376px 0px;
        }
        .messege
        {
            background: url(images/menu-bg.png) no-repeat -500px 0px;
        }
        .messege:hover
        {
            background: url(images/menu-bg1.png) no-repeat -500px 0px;
        }
        .view-profile
        {
            background: url(images/menu-bg.png) no-repeat -643px 0px;
        }
        .view-profile:hover
        {
            background: url(images/menu-bg1.png) no-repeat -643px 0px;
        }
        .settting
        {
            background: url(images/menu-bg.png) no-repeat -772px 0px;
        }
        .settting:hover
        {
            background: url(images/menu-bg1.png) no-repeat -772px 0px;
        }
        .transport
        {
            background: url(images/menu-bg.png) no-repeat -887px 0px;
        }
        .transport:hover
        {
            background: url(images/menu-bg1.png) no-repeat -887px 0px;
        }
        .teacher
        {
            background: url(images/menu-bg.png) no-repeat -20px 0px;
            height: 70px;
            width: 79px;
        }
        .teacher:hover
        {
            background: url(images/menu-bg1.png) no-repeat -20px 0px;
            height: 70px;
            width: 79px;
        }
        .parents
        {
            background: url(images/menu-bg.png) no-repeat -20px 0px;
            height: 70px;
            width: 79px;
        }
        .parents:hover
        {
            background: url(images/menu-bg1.png) no-repeat -20px 0px;
            height: 70px;
            width: 79px;
        }
        .student
        {
            background: url(images/menu-bg.png) no-repeat -20px 0px;
            height: 70px;
            width: 79px;
        }
        .student:hover
        {
            background: url(images/menu-bg1.png) no-repeat -20px 0px;
            height: 70px;
            width: 79px;
        }
        .content
        {
            width: 100%;
            height: 100%;
            float: left;
            padding: 15px 0 0 15px;
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
            color: #717171;
            text-align: center;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            background: rgb(3, 116, 3);
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
        .textcss
        {
            font-family: Verdana, MS Reference Sans Serif, Arial;
            font-size: 11px;
            text-align: left;
        }
        .textsize
        {
            font-family: Verdana, Arial, Sans-Serif;
            font-size: 11px;
        }
        .loginNew
        {
            background: url(images/Layer5.png) no-repeat -500px 0px;
        }
        .loginNew:hover
        {
            background: url(images/Layer6.png) no-repeat -500px 0px;
        }
        .logout
        {
            background: url(images/Layer5.png) no-repeat -500px 0px;
        }
        .logout:hover
        {
            background: url(images/Layer6.png) no-repeat -500px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
 <div style="padding:05px 0 0 0">
       <asp:UpdatePanel ID="upd1" runat="server"><ContentTemplate>
           <div class="efficacious">
<table><tr><td align="left">

    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="928px" CssClass="MyTabStyle" >
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Enquiry Form
            </HeaderTemplate>
            <ContentTemplate>
               <asp:UpdatePanel ID="UpdateP1" runat="server">
                    <ContentTemplate>
                <center>
                    <div class="efficacious">
                            <table style="font-weight: bolder; width: 60%;" align="center">
                            
                            <tr>
                 
                                <td ID="Td1" runat="server" align="left" nowrap="nowrap" >
                                    <asp:Label ID="Lal1" runat="server"   Font-Bold="False">School Name <font size="1px" color="red">*</font></asp:Label>
                                    

                                </td>

                                <td ID="Td2" runat="server" align="left" nowrap="nowrap" >
                              
                                    <asp:TextBox ID="TextBox1" runat="server" 
                                          ForeColor="Black" MaxLength="200"></asp:TextBox>

                                </td>

                                <td >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="TextBox1"   Display="None" 
                                        ErrorMessage="Enter School Name" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator1"></asp:ValidatorCalloutExtender>

                                        <asp:RegularExpressionValidator ID="RegEV1"  ValidationGroup="a" runat="server"
                                                    ControlToValidate="TextBox1" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="^[a-zA-Z ]+$"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RegEV1">
                                         </asp:ValidatorCalloutExtender>


                                </td>
                 
                            </tr>
                            
                            <tr>
                            <td align="left">
                            <asp:Label ID="Lal2" runat="server"   Font-Bold="False">Contact Name<font size="1px" color="red">*</font></asp:Label>
                            


                            </td>
                                              
                                                <td ID="Td4" runat="server" align="left" >
                                    
                                              <asp:TextBox ID="TextBox2" runat="server" 
                                                    ForeColor="Black" MaxLength="200" ></asp:TextBox>
                    


                                                </td>
                                                <td>
                                                   <asp:RequiredFieldValidator ID="ReFiVa2" runat="server" 
                                        ControlToValidate="TextBox2"   Display="None" 
                                        ErrorMessage="Enter Contact Name" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                        Enabled="True" TargetControlID="ReFiVa2"></asp:ValidatorCalloutExtender>

                                                    <asp:RegularExpressionValidator ID="RegEV2" ValidationGroup="a" runat="server"
                                                    ControlToValidate="TextBox2" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="^[a-zA-Z ]+$"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RegEV2">
                                                    </asp:ValidatorCalloutExtender>

                                                 
                                                </td>
                                             
                                             </tr>
                                                  <tr>
                            <td align="left">
                            <asp:Label ID="Lal3" runat="server"   Font-Bold="False">Address<font size="1px" color="red">*</font></asp:Label>
                            


                            </td>
                                              
                                                <td ID="Td3" runat="server" align="left">
                                   
                                              <asp:TextBox ID="TextBox3" runat="server" 
                                                    ForeColor="Black" MaxLength="200"></asp:TextBox>
                                         


                                                </td>


                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="TextBox3"   Display="None" 
                                                        ErrorMessage="Enter School Address" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator3"></asp:ValidatorCalloutExtender>

                                                        <asp:RegularExpressionValidator ID="RegEV3" ValidationGroup="a" runat="server"
                                                    ControlToValidate="TextBox3" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="^[a-zA-Z ]+$"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RegEV3">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                             
                                             </tr>
                                                  <tr>
                            <td align="left">
                            <asp:Label ID="Lal4" runat="server"   Font-Bold="False">City<font size="1px" color="red">*</font></asp:Label>
                            


                            </td>
                                              
                                                <td ID="Td5" runat="server" align="left">
                                     
                                              <asp:TextBox ID="TextBox4" runat="server"
                                                    ForeColor="Black" MaxLength="200" 
                                                   ></asp:TextBox>
                                          


                                                </td>


                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="TextBox4"   Display="None" 
                                                        ErrorMessage="Enter City" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator4"></asp:ValidatorCalloutExtender>
                                                    
                                                    <asp:RegularExpressionValidator ID="RegEV4" ValidationGroup="a" runat="server"
                                                    ControlToValidate="TextBox4" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="^[a-zA-Z ]+$"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator>

                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RegEV4">
                                                    </asp:ValidatorCalloutExtender>

                                                </td>
                                             
                                             </tr>
                                                  <tr>
                            <td align="left">
                            <asp:Label ID="Lal5" runat="server"   Font-Bold="False">State <font size="1px" color="red">*</font></asp:Label>
                           


                            </td>
                                              
                                                <td ID="Td6" runat="server" align="left">
                                     
                                              <asp:TextBox ID="TextBox5" runat="server" 
                                                    ForeColor="Black" MaxLength="200" 
                                                  ></asp:TextBox>
                                          


                                                </td>


                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                        ControlToValidate="TextBox5"   Display="None" 
                                                        ErrorMessage="Enter State"  ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator5"></asp:ValidatorCalloutExtender>

                                                    <asp:RegularExpressionValidator ID="RegEV5" ValidationGroup="a" runat="server"
                                                    ControlToValidate="TextBox5" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="^[a-zA-Z ]+$"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator>

                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RegEV5">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                             
                                             </tr>
                                                  <tr>
                            <td align="left">
                            <asp:Label ID="Lal6" runat="server"   Font-Bold="False">Country <font size="1px" color="red">*</font></asp:Label>
                           


                            </td>
                                              
                                                <td ID="Td7" runat="server" align="left" >
                                    
                                              <asp:TextBox ID="TextBox6" runat="server" 
                                                    ForeColor="Black" MaxLength="200" ></asp:TextBox>
                                          


                                                </td>


                                                <td >
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                        ControlToValidate="TextBox6"   Display="None" 
                                                        ErrorMessage="Enter Country" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator6"></asp:ValidatorCalloutExtender>

                                            <asp:RegularExpressionValidator ID="RegEV6" ValidationGroup="a" runat="server"
                                                    ControlToValidate="TextBox6" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="^[a-zA-Z ]+$"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator>

                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="RegEV6">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                             
                                             </tr>
                                                  <tr>
                            <td align="left" >
                            <asp:Label ID="Lal7" runat="server"   Font-Bold="False">Telephone No<font size="1px" color="red">*</font></asp:Label>
                            


                            </td>
                                              
                                                <td ID="Td8" runat="server" align="left" >
                                     
                                              <asp:TextBox ID="TextBox7" runat="server" 
                                                    ForeColor="Black" MaxLength="200" 
                                                   ></asp:TextBox>
                                         

                                                </td>


                                                <td >
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="TextBox7"   Display="None" 
                                                        ErrorMessage="Enter Telephone No" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator7"></asp:ValidatorCalloutExtender>

                                                     <asp:RegularExpressionValidator id="RFV11"
                   ControlToValidate="TextBox7"
                   ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"
                   Display="None"
                   EnableClientScript="true"
                   ErrorMessage="Enter valid Phone number"
                   runat="server"   Font-Bold="False"/>

                                                <asp:ValidatorCalloutExtender ID="Re_VCE5" 
                                                    runat="server" Enabled="True" TargetControlID="RFV11">
                                                </asp:ValidatorCalloutExtender>

                                                </td>
                                             
                                             </tr>
                                                  <tr>
                            <td align="left" >
                            <asp:Label ID="Lal8" runat="server"   Font-Bold="False">Email<font size="1px" color="red">*</font></asp:Label>
             
                            </td>
                                              
                                                <td ID="Td9" runat="server" align="left">
                                    
                                              <asp:TextBox ID="TextBox8" runat="server" 
                                                    ForeColor="Black" MaxLength="200"></asp:TextBox>
                                         

                                                </td>


                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                        ControlToValidate="TextBox8"   Display="None" 
                                                        ErrorMessage="Enter Email" ValidationGroup="a" Font-Bold="False"></asp:RequiredFieldValidator>


                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" 
                                                        Enabled="True" TargetControlID="RequiredFieldValidator8"></asp:ValidatorCalloutExtender>
                                                    
                                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="TextBox8" Display="None" ValidationGroup="a" ErrorMessage="Invalid Email Format" Font-Bold="False"></asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                             
                                             </tr>
                                             <tr>
                                                <td align="center" colspan="3" >
                                                    <table ><tr><td>
                                                    <asp:Button    ID="Button1" CssClass="efficacious_send" ValidationGroup="a" runat="server"   
                                                        OnClick="Button1_Click" Text="Submit" />
                                                        </td></tr></table>

                                       

                                                    &nbsp;</td>
                                                </tr>
                            
                            </table>
                        </div>
                           </center>
            </ContentTemplate>
            </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </td></tr></table>
               </div>
           </ContentTemplate></asp:UpdatePanel>
    </div>
        </form>
    </body>
</html>


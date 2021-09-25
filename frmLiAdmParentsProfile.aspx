<%@ Page Language="C#"  AutoEventWireup="true"
    CodeFile="frmLiAdmParentsProfile.aspx.cs" Inherits="frmLiAdmParentsProfile" Title="Parents Details" %>


    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            padding: 0px;
            font-size: 12px;
            margin: 0% 2%;
           
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: auto;
            color: #000; float:left;
        }
        .efficacious input, form.winner-inside textarea
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            font-family: Verdana;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom:5px;
           
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
            font-family: Verdana;
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
            font-family: Verdana;
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
            text-align: center; width:100px;
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
            font-family: Verdana;
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
            font-family: Verdana;
            font-size: 11px;
            text-align: left;
        }
        .textsize
        {
            font-family: Verdana;
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
        /* default layout */
.ajax__tab_default .ajax__tab_header {
	white-space: normal !important
}
.ajax__tab_default .ajax__tab_outer {
	display: -moz-inline-box;
	display: inline-block
}
.ajax__tab_default .ajax__tab_inner {
	display: -moz-inline-box;
	display: inline-block
}
.ajax__tab_default .ajax__tab_tab {
	overflow: hidden;
	text-align: center;
	display: -moz-inline-box;
	display: inline-block
}
/* xp theme */
.ajax__tab_xp .ajax__tab_header {
	font-family: Verdana;
	font-size: 11px;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_outer {
	  padding-right: 4px;
  background: #fff  !important;
  height: 21px;
  font-size: 12px;
  padding: 4px 0;
  border: 1px solid #D5D5D5; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_inner {
	padding-left: 3px;
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_tab {
	height: 13px;
	padding: 4px;
	margin: 0px;
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_hover .ajax__tab_outer {
	cursor: pointer;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_hover .ajax__tab_inner {
	cursor: pointer;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_hover .ajax__tab_tab {
	cursor: pointer;
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_outer {
  background: #fff;
  border-right: 1px solid green;
  border-left: 1px solid green;
  border-top: 1px solid green;
  padding: 5px 0; border-radius:5px 5px 0 0; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_inner {
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_tab {
	background:#fff !important; color:Green; font-size:12px; font-weight:bold;
}
.ajax__tab_xp .ajax__tab_disabled {
	color: #A0A0A0;
}
.ajax__tab_xp .ajax__tab_body {
	font-family: Verdana;
	font-size: 10pt;
	border: 1px solid #999999;
	
	padding: 8px;
	background-color: #ffffff;
}
/* scrolling */
.ajax__scroll_horiz {
	overflow-x: scroll;
}
.ajax__scroll_vert {
	overflow-y: scroll;
}
.ajax__scroll_both {
	overflow: scroll
}
.ajax__scroll_auto {
	overflow: auto
}
/* plain theme */
.ajax__tab_plain .ajax__tab_outer {
	text-align: center;
	vertical-align: middle;
	border: 2px solid #999999;
}
.ajax__tab_plain .ajax__tab_inner {
	text-align: center;
	vertical-align: middle;
}
.ajax__tab_plain .ajax__tab_body {
	text-align: center;
	vertical-align: middle;
}
.ajax__tab_plain .ajax__tab_header {
	text-align: center;
	vertical-align: middle;
}
.ajax__tab_plain .ajax__tab_active .ajax__tab_outer {
	background: #FFF;
}
    </style>
</head>
<body>
    <form id="form1" runat="server" >
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
 
    <div style="padding:05px 0 0 0">
    <asp:UpdatePanel ID="up2" runat="server">
        <ContentTemplate>
                
<table ><tr><td>
    <asp:Label ID="ivLab1" runat="server" ></asp:Label>
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="99%">
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate >
             
                Academic Details
             
                   </HeaderTemplate>
            <ContentTemplate>
                
                <center>
     
                    <fieldset style="width: 500px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold ">
                            Academic Details</legend>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center" class="efficacious">
                            <tr>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label26" runat="server"   Font-Bold="False" Text="Standard"></asp:Label>
                                 <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    
                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="100px"
                                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Req8" runat="server" InitialValue="0" ErrorMessage="Please select Standerd"
                                                  ControlToValidate="DropDownList1" ValidationGroup="a1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                                runat="server" TargetControlID="Req8" Enabled="True">
                                            </asp:ValidatorCalloutExtender>

                                       
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" width="240">
                                    <asp:Label ID="Label27" runat="server"   Font-Bold="False" Text="Division Id"></asp:Label>
                                 <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap" width="240">
                                    
                                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Width="100px"
                                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"  >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Req9" runat="server" ErrorMessage="Please select Division"
                                                  ControlToValidate="DropDownList2" ValidationGroup="a1" InitialValue="0" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender16"
                                                runat="server" TargetControlID="Req9" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" width="240">
                                    <asp:Label ID="Label28" runat="server"   Font-Bold="False" Text="Roll No"></asp:Label>
                                 <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap" width="240">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="100px"
                                                OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"  >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Req10" runat="server" ErrorMessage="Please select Roll No"
                                                  ControlToValidate="DropDownList3" ValidationGroup="a1" InitialValue="0" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender17"
                                                runat="server" TargetControlID="Req10" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" width="240">
                                    <asp:Button    runat="server" Text="next"
                                        ID="Button4" OnClick="checknextval4" ValidationGroup="a1"></asp:Button   >
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </center>
       
                </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                Father Details</HeaderTemplate>
            <ContentTemplate>
             
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold">
                            Father Details</legend>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center" class="efficacious">
                            <tr>
                                <td rowspan="6" valign="top" >
                                    <asp:Image ID="FatherImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                        runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                        border="2" ToolTip="Image" />
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">Father First Name</asp:Label>
                                 <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:TextBox ID="txtp1" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                               <asp:RequiredFieldValidator
                                                        ID="RequFieator1" runat="server" ValidationGroup="b1" ErrorMessage="Please Enter First Name"
                                                          ControlToValidate="txtp1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender
                                                            ID="ValidatorCalloutExtender18" runat="server" TargetControlID="RequFieator1"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegEV1" ValidationGroup="b1" runat="server"
                                                    ControlToValidate="txtp1" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RegEV1">
                                                    </asp:ValidatorCalloutExtender>
                                     </td>
                            </tr>
                            <tr>
                                <td align="left" width="240">
                                    <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Father Middle Name</asp:Label>
                                </td>
                                <td align="left" width="240">
                                    <asp:TextBox ID="txtp2" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="240">
                                    <asp:Label ID="lblvchdrivername" runat="server" Text="Father Last Name"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:TextBox ID="txtp3" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                                              <asp:RequiredFieldValidator
                                                        ID="ReqFdV2" runat="server" ValidationGroup="b1" ErrorMessage="Please Enter Last Name"
                                                          ControlToValidate="txtp3" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender
                                                            ID="ValidatorCalloutExtender19" runat="server" TargetControlID="ReqFdV2"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegExpValr3" ValidationGroup="b1" runat="server"
                                                    ControlToValidate="txtp1" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+"   Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender21" runat="server" Enabled="True" TargetControlID="RegExpValr3">
                                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="lblpalceofbirth1" runat="server" Text="Father Mobile No"  
                                        Font-Bold="False"></asp:Label>
                                    <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap" width="240">
                                    <asp:TextBox ID="txtp4" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtp4"
                                          Display="None" ValidationGroup="b1" ErrorMessage="Please Enter Father Mobile No"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14"
                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtp4"
                                        Display="None" ErrorMessage="Enter Valid Mobile no" ValidationGroup="b1" Font-Bold="False" 
                                        ValidationExpression="[0-9]{10}"  ></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender15" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator5">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="lblpalceofbirth4" runat="server" Text="Father DOB"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap" width="240" >
                                    <asp:TextBox ID="txtp5" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtp5"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtp5"
                                          Display="None" ValidationGroup="b1" ErrorMessage="Please Enter Dob Name" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator12">
                                        </asp:ValidatorCalloutExtender>
                                    
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtp5"
                                          Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)"
                                        Font-Bold="False" Operator="GreaterThan" ValidationGroup="b1" SetFocusOnError="True" Type="Date"
                                        ValueToCompare="1/1/1100"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender60"
                                            runat="server" Enabled="True" TargetControlID="CompareValidator1">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label20" runat="server" Text="Father Email Id"  
                                        Font-Bold="False"></asp:Label>
                                    <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:TextBox ID="txtp6" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                  <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="txtp6" Display="None" ValidationGroup="b1" ErrorMessage="Invalid Email Format" Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RequFiVa8" runat="server" ControlToValidate="txtp6"
                                          Display="None" ValidationGroup="b1" ErrorMessage="Please Enter Valid Email id"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender22"
                                            runat="server" Enabled="True" TargetControlID="RequFiVa8">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label37" runat="server"   Font-Bold="False">Father Address</asp:Label>
                                <font size="1px" color="red">*</font>

                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:TextBox ID="txtp7" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b1"  ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequFietor10" runat="server" 
                                                    ControlToValidate="txtp7"   Display="None" 
                                                    ErrorMessage="Please Enter Address" Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" Enabled="True" TargetControlID="RequFietor10">
                                                </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label62" runat="server"   Font-Bold="False">Father Passport No</asp:Label>
                                </td>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:TextBox ID="txtp8" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="ReExpV251" runat="server"
                                                    ControlToValidate="txtp8"    ErrorMessage="Only alphabets are allowed"
                                                    Font-Bold="False" ForeColor="Red" ValidationGroup="b1" ValidationExpression="[[A-Z][0-9][0-9] [0-9][0-9][0-9][0-9][0-9]]"
                                                    Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender42"
                                                        runat="server" Enabled="True" TargetControlID="ReExpV251">
                                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" width="230">
                                    <asp:Label ID="Label2" runat="server"   Font-Bold="False">Father Company Name</asp:Label>
                               <font size="1px" color="red">*</font>
                                     </td>
                                <td align="left" width="230" nowrap="nowrap">
                                    <asp:TextBox ID="txtp9" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                               <asp:RegularExpressionValidator ID="ReEV13" runat="server"
                                                    ControlToValidate="txtp9"   ValidationGroup="b1" ErrorMessage="Only alphabets are allowed"
                                                    ForeColor="Red" ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="ReEV13">
                                                    </asp:ValidatorCalloutExtender>
                                     </td>
                            </tr>
                            <tr>
                                <td >
                                </td>
                                <td align="left" >
                                    <asp:Label ID="Label5" runat="server"   Font-Bold="False">Father Designation</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp10" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Father Company Address"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp11" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RedFdVor8" runat="server" ControlToValidate="txtp11"
                                          Display="None" ErrorMessage="Please Enter Company Address"
                                        Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender26"
                                            runat="server" Enabled="True" TargetControlID="RedFdVor8">
                                        </asp:ValidatorCalloutExtender>
                                     </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="Telephone No (Office)"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp12" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtp12"
                                          Display="None" ErrorMessage="Please Enter Telephone No"
                                        Font-Bold="False"  ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender5"
                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label8" runat="server" Text="Income Details"   Font-Bold="False"></asp:Label>
                                <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp13" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqdVat8" runat="server" ControlToValidate="txtp13"
                                          Display="None" ErrorMessage="Please Enter Income Details"
                                        Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender27"
                                            runat="server" Enabled="True" TargetControlID="ReqdVat8">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label64" runat="server" Text="Father Vehicle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp14" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label66" runat="server" Text="Father Vehicle No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp15" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                </td>
                                <td align="left" >
                                    <asp:Label ID="Label68" runat="server" Text="Father PAN No"   Font-Bold="False"></asp:Label>
                                 <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp16" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtp13"
                                          Display="None" ErrorMessage="Please Enter PAN No"
                                        Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender28"
                                            runat="server" Enabled="True" TargetControlID="ReqdVat8">
                                        </asp:ValidatorCalloutExtender>
                                     </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label70" runat="server" Text="Father Blood Group"  
                                        Font-Bold="False"></asp:Label> <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp17" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFiVator9" runat="server" ControlToValidate="txtp13"
                                          Display="None" ErrorMessage="Please Enter blood Group"
                                        Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender29"
                                            runat="server" Enabled="True" TargetControlID="ReqFiVator9">
                                        </asp:ValidatorCalloutExtender>
                                 
                                     </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="Label90" runat="server" Text="Father Highest Qualification"  
                                        Font-Bold="False"></asp:Label> <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp18" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqdFiVtor10" runat="server" ControlToValidate="txtp13"
                                          Display="None" ErrorMessage="Please Enter Highest Qualification"
                                        Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender30"
                                            runat="server" Enabled="True" TargetControlID="ReqdFiVtor10">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td id="img" runat="server" align="left" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="width: 245px; float: right;"  ChildrenAsTriggers="False" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:FileUpload ID="FileUpload1" runat="server"   /><br />
                                            <br />
                                            <asp:Button    ID="Button1" runat="server" CssClass="efficacious_send"   OnClick="Button1_Click"
                                                OnClientClick="if (!validatePage()) {return true;}" Text="Upload File" />&#160;<br />
                                            <br />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="Button1" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button    ID="checkprivious1" runat="server" OnClick="checkPrivious1" CssClass="efficacious_send"  OnClientClick="if (!validatePage()) {return true;}"
                                        Text="Back" />
                                </td>
                                <td align="right">
                                    <asp:Button    runat="server" Text="next"
                                        ID="ButN1" OnClick="checknextval1" ValidationGroup="b1"></asp:Button   >
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </center>
                  
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
            <HeaderTemplate>
                Mother Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                   
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Mother Details</legend>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center" class="efficacious">
                            <tr>
                                <td rowspan="6" valign="top" >
                                    <asp:Image ID="MotherImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                        runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                        border="2" ToolTip="Image" />
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lbldrivermobno" runat="server" Text="Mother First Name"  
                                        Font-Bold="False"></asp:Label>
                                    <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:TextBox ID="txtp19" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ReqFiVd9" runat="server" ControlToValidate="txtp19"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter First Name"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender31"
                                            runat="server" Enabled="True" TargetControlID="ReqFiVd9">
                                        </asp:ValidatorCalloutExtender>
                                   
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtp19"
                                        ErrorMessage="Only alphabets are allowed" ForeColor="Red" ValidationGroup="C1" ValidationExpression="[a-zA-Z]+"
                                          Font-Bold="False" Display="None"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" Enabled="True"
                                        TargetControlID="RegularExpressionValidator4">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lblmother" runat="server" Text="Mother Middle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp20" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Gender" runat="server" Text="Mother Last Name"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp21" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ReqVadt11" runat="server" ControlToValidate="txtp19"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Last Name"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender32"
                                            runat="server" Enabled="True" TargetControlID="ReqVadt11">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth2" runat="server" Text="Mother Mobile No"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp22" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                          ></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="ReqFiVr1" runat="server" ControlToValidate="txtp22"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Mobile No"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                            runat="server" Enabled="True" TargetControlID="ReqFiVr1">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReExpreVa23" runat="server"
                                        ControlToValidate="txtp22" Display="None" ValidationGroup="C1" ErrorMessage="Enter Valid Mobile no"
                                        Font-Bold="False" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="ReExpreVa23">
                                        </asp:ValidatorCalloutExtender>

                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth5" runat="server" Text="Mother DOB"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:TextBox ID="txtp23" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                           ReadOnly="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtp23"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtp23"
                                          Display="None" ErrorMessage="Please Enter Dob" ValidationGroup="C1" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                        </asp:ValidatorCalloutExtender>
                                    
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtp23"
                                          Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)"
                                        Font-Bold="False" Operator="GreaterThan" SetFocusOnError="True" Type="Date" ValidationGroup="C1"
                                        ValueToCompare="1/1/1100"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11"
                                            runat="server" Enabled="True" TargetControlID="CompareValidator2">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label21" runat="server" Text="Mother Email Id"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp24" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" width="230">
                                    <asp:Label ID="Label1" runat="server"   Font-Bold="False">Mother Address</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    <asp:TextBox ID="txtp25" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server"   Font-Bold="False">Mother Passport No</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp26" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="Label9" runat="server" Text="Mother Company Name"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp27" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ReqFiVr12" runat="server" ControlToValidate="txtp27"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Company Name"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender33"
                                            runat="server" Enabled="True" TargetControlID="ReqFiVr12">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label10" runat="server" Text="Mother Designation"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp28" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" >
                                    <asp:Label ID="Label11" runat="server" Text="Mother Company Address"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp29" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RedFilor1" runat="server" ControlToValidate="txtp27"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Company Address "
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender34"
                                            runat="server" Enabled="True" TargetControlID="RedFilor1">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label13" runat="server" Text="Telephone No (Office)"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp30" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RiFdVr1" runat="server" ControlToValidate="txtp27"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Telephone No"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                            runat="server" Enabled="True" TargetControlID="RiFdVr1">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegEssr3" runat="server" ControlToValidate="txtp30"
                                        Display="None" ErrorMessage="Enter Telephone no" ValidationGroup="C1" Font-Bold="False" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RegEssr3">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label14" runat="server" Text="Income Details"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp31" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label72" runat="server" Text="Mother Vehicle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp32" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label74" runat="server" Text="Mother Vehicle No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp33" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label76" runat="server" Text="Mother PAN No"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp34" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label78" runat="server" Text="Mother Blood Group"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp35" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFdr1" runat="server" ControlToValidate="txtp35"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Blood Group"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender35"
                                            runat="server" Enabled="True" TargetControlID="RFdr1">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label92" runat="server" Text="Mother Highest Qualification"  
                                        Font-Bold="False"></asp:Label><font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp36" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtp36"
                                          Display="None" ValidationGroup="C1" ErrorMessage="Please Enter Highest Qualification"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender36"
                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td id="Td1" runat="server" align="center" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" CssClass="efficacious_send" style="width:181px; float: right;"  ChildrenAsTriggers="False" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:FileUpload ID="FileUpload2" runat="server"    /><br />
                                            <br />
                                            <asp:Button    ID="Button2" runat="server"   OnClick="Button2_Click" CssClass="efficacious_send" 
                                                OnClientClick="if (!validatePage()) {return true;}" Text="Upload File" />&#160;<br />
                                            <br />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="Button2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button    runat="server" OnClientClick="if (!validatePage()) {return true;}" Text="Back"
                                        ID="ButP2" OnClick="checkPrivious2"></asp:Button   >
                                </td>
                                <td align="right">
                                    <asp:Button    runat="server" Text="Next"
                                        ID="ButN2" OnClick="checknextval2" ValidationGroup="C1"></asp:Button   >
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                  
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Guardian Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                   
                    <fieldset style="width: 624px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Guardian Details</legend>
                        <table style="font-weight: bolder; width: 612px; margin: 10px 0; height: 667px;" align="center" class="efficacious">
                            <tr>
                                <td rowspan="6" valign="top" >
                                    <asp:Image ID="GuardianImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                        runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                        border="2" ToolTip="Image" />
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lblbob" runat="server" Text="Guardian First Name"  
                                        Font-Bold="False"></asp:Label>
                                       <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp37" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="Rqr2" runat="server" ControlToValidate="txtp37"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter First Name"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender37"
                                            runat="server" Enabled="True" TargetControlID="Rqr2">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lblpalceofbirth" runat="server" Text="Guardian Middle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp38" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth0" runat="server" Text="Guardian Last Name"  
                                        Font-Bold="False"></asp:Label>   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp39" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="Rdr3" runat="server" ControlToValidate="txtp39"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Last Name"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender38"
                                            runat="server" Enabled="True" TargetControlID="Rdr3">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Text="Gaurdian Mobile No"  
                                        Font-Bold="False"></asp:Label>   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp40" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ReVor2" runat="server" ControlToValidate="txtp40"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Mobile No"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6"
                                            runat="server" Enabled="True" TargetControlID="ReVor2">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegExpVdr3" runat="server" ControlToValidate="txtp40"
                                        Display="None" ErrorMessage="Enter Valid Mobile no" Font-Bold="False" ValidationGroup="d1" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RegExpVdr3">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="left">
                                    <asp:Label ID="Label34" runat="server" Text="Guardian DOB"   Font-Bold="False"></asp:Label>
                                   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left"  nowrap="nowrap">
                                    <asp:TextBox ID="txtp41" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="d1"   ReadOnly="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtp41"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="ReFVato4" runat="server" ControlToValidate="txtp41"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Dob"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12"
                                            runat="server" Enabled="True" TargetControlID="ReFVato4">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtp41"
                                          Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)"
                                        Font-Bold="False" Operator="GreaterThan" SetFocusOnError="True" Type="Date" ValidationGroup="d1"
                                        ValueToCompare="1/1/1100"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13"
                                            runat="server" Enabled="True" TargetControlID="CompareValidator3">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label12" runat="server"   Font-Bold="False">Guardian Address</asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp42" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label22" runat="server" Text="Guardian Email Id"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp43" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                </td>
                                <td align="left"  nowrap="nowrap">
                                    <asp:Label ID="Label15" runat="server"   Font-Bold="False">Guardian Company Name</asp:Label>
                                  <font size="1px" color="red">*</font>
                                     </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp44" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="Reqddl4" runat="server" ControlToValidate="txtp44"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Company Name"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender39"
                                            runat="server" Enabled="True" TargetControlID="Reqddl4">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label16" runat="server"   Font-Bold="False">Guardian Designation</asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp45" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label17" runat="server" Text="Company Address"  
                                        Font-Bold="False"></asp:Label>   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp46" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ReFV5" runat="server" ControlToValidate="txtp44"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Company Address"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender40"
                                            runat="server" Enabled="True" TargetControlID="ReFV5">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label88" runat="server" Text="Guardian Passport No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp47" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label18" runat="server" Text="Telephone No (Office)"  
                                        Font-Bold="False"></asp:Label>   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp48" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                        ValidationGroup="b"  ></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RqFV6" runat="server" ControlToValidate="txtp48"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Telephone No"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                            runat="server" Enabled="True" TargetControlID="RqFV6">
                                        </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RerEiaor8" runat="server" ControlToValidate="txtp48"
                                        Display="None" ErrorMessage="Enter Valid Telephone no" Font-Bold="False" ValidationGroup="d1" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                            ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RerEiaor8">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label19" runat="server" Text="Income Details"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp49" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label80" runat="server" Text="Guardian Vehicle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp50" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label82" runat="server" Text="Guardian Vehicle No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp51" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                         ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label84" runat="server" Text="Guardian PAN No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp52" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                          ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label86" runat="server" Text="Guardian Blood Group"  
                                        Font-Bold="False"></asp:Label>   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtp53" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="Rqrd7" runat="server" ControlToValidate="txtp48"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Blood Group "
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender41"
                                            runat="server" Enabled="True" TargetControlID="Rqrd7">
                                        </asp:ValidatorCalloutExtender>
                                     </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="Label94" runat="server" Text="Guardian Highest Qualification"  
                                        Font-Bold="False"></asp:Label>   <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtp54" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                        ValidationGroup="b"  ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RrFdVd8" runat="server" ControlToValidate="txtp54"
                                          Display="None" ValidationGroup="d1" ErrorMessage="Please Enter Highest Qualification"
                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender44"
                                            runat="server" Enabled="True" TargetControlID="RrFdVd8">
                                        </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td id="Td2" runat="server" align="left" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" CssClass="efficacious_send" style="width: 225px; float: right;"  ChildrenAsTriggers="False" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:FileUpload ID="FileUpload3" runat="server"   /><br />
                                            <br />
                                            <asp:Button    ID="Button3" runat="server"   OnClick="Button3_Click" CssClass="efficacious_send" 
                                                OnClientClick="if (!validatePage()) {return true;}" Text="Upload File" />&#160;<br />
                                            <br />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="Button3" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button    ID="ButP3" runat="server" OnClick="checkPrivious3" OnClientClick="if (!validatePage()) {return true;}"
                                        Text="Back" />
                                </td>
                                <td align="left">
                                    <asp:Button    ID="ButN3" runat="server" OnClientClick="if (!validatePage()) {return true;}"
                                        OnClick="submit" Text="Submit" Height="26px" ValidationGroup="d1"></asp:Button   >
                                        <asp:Button    ID="Button5" runat="server" CssClass="efficacious_send"  OnClientClick="if (!validatePage()) {return true;}"
                                        OnClick="Updatev" Text="Update" Height="26px" ValidationGroup="d1"></asp:Button   >
                               <asp:Label id="idvp1" runat="server" Visible="False" Font-Bold="False"></asp:Label>                                     </td>
                            </tr>
                        </table>
                    </fieldset>
             
                         </center>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</td></tr></table>
</ContentTemplate>

    </asp:UpdatePanel>
        </div>
        </form>
    </body>
    </html>

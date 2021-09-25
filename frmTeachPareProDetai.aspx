<%@ Page Title="Parents Profile Details" Language="C#"  AutoEventWireup="true" CodeFile="frmTeachPareProDetai.aspx.cs" Inherits="frmTeachPareProDetai" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css"/>
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>

    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="sty/styles.css" rel="stylesheet" type="text/css" />

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <script src="sty/script.js"></script>
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
    text-indent:20px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center></center>
    <div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%>

    <table>
        <tr id="id1h" runat="server" >
            <td>
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="450px"
                    Width="928px" >
                    <asp:TabPanel runat="server" HeaderText="TabPanelcardentry" ID="TabPanelcardentry"
                        Style="display: none;">
                        <HeaderTemplate>
                            Father Details</HeaderTemplate>
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanelprfil" runat="server">
                                <ContentTemplate>
                                    <table style="font-weight: bolder; width: 800px; margin: 10px 0;" align="center">
                                        <tr>
                                            <td style="padding: 10px 0 20px 0;">
                                            <center>
                                                <fieldset style="width: 622px; height: 380px;">
                                                    <legend style="color: #000000; font: 13px verdana; margin-left: 190px;">Father Details</legend>
                                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td rowspan="6">
                                                                &nbsp;&nbsp;
                                                                <img src="images/Sample%20Photo.jpg" 
                                                                    style="line-height: normal; height: 109px;" />&#160;&nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblvchdrivername" runat="server" Text="Father Name"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana" MaxLength="20"
                                                                    ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label
                                                                        ID="Label58" runat="server"   Font-Bold="False">Ramesh jivan Shinde</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">Father Email Id</asp:Label>
                                                            </td>
                                                            <td align="left" width="230">
                                                                <asp:TextBox ID="txtvchno" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label59" runat="server"
                                                                          Font-Bold="False">Ramesh@gmail.com</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Father DOB</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label60" runat="server"
                                                                          Font-Bold="False">15-jun-1980</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" nowrap="nowrap">
                                                                <asp:Label ID="lbldrivermobno" runat="server"   Font-Bold="False">Father Company Name</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake1" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label61"
                                                                        runat="server"   Font-Bold="False">Sisco Hospital</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server"   Font-Bold="False">Father Designation</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake2" runat="server" Font-Names="Verdana" MaxLength="20"
                                                                    ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label
                                                                        ID="Label62" runat="server"   Font-Bold="False">Dentist</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            
                                                            <td align="left">
                                                                <asp:Label ID="Label38" runat="server" Text="Company address"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake3" runat="server" Font-Names="Verdana" MaxLength="20"
                                                                    ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label
                                                                        ID="Label63" runat="server"   Font-Bold="False">Millennium Plaza,Sec-30,Dadar</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                            </td>
                                                            <td align="left" class="style1">
                                                                <asp:Label ID="Label37" runat="server" Text="Telphone No (Office)"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style1">
                                                                <asp:TextBox ID="txtvchmake4" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label64"
                                                                        runat="server"   Font-Bold="False">051-22587895</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr valign="bottom">
                                                            <td>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblpalceofbirth1" runat="server"   Font-Bold="False">Father Mobile No</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake7" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label65"
                                                                        runat="server"   Font-Bold="False">9970485478</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr valign="bottom">
                                                            <td>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblpalceofbirth0" runat="server" Text="Present Address"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvchmake6" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label66"
                                                                        runat="server"   Font-Bold="False">Sec-4,Vashi,Navi Mumbai</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanelIdcard" runat="server" HeaderText="TabPanelIdcard" Style="display: none;">
                        <HeaderTemplate>
                            Mother Details</HeaderTemplate>
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                                     
                                        <tr>
                                            <td style="padding: 10px 0 20px 0;">
                                            <center>
                                                <fieldset style="width: 622px; height: 380px;" >
                                                
                                                    <legend style="color: #000000; font: 13px verdana; margin-left: 190px;">Mother Details</legend>
                                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td rowspan="6">
                                                                &nbsp;&nbsp;
                                                                <img src="images/Sample%20Photo.jpg" 
                                                                    style="line-height: normal; height: 109px;" />&nbsp;&nbsp;
                                                            </td>
                                                            <td align="left" class="style2">
                                                                <asp:Label ID="Label2" runat="server" Text="Mother Name"   Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style2">
                                                                <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label67" runat="server"
                                                                          Font-Bold="False">Shila Ramesh Shinde</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server"   Font-Bold="False">Mother Email Id</asp:Label>
                                                            </td>
                                                            <td align="left" width="230">
                                                                <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label76" runat="server"
                                                                          Font-Bold="False">Shila@gmail.com</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server"   Font-Bold="False">Mother DOB</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label69" runat="server"
                                                                          Font-Bold="False">20-JUN-1984</asp:Label>&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server"   Font-Bold="False">Mother Company Name</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label70"
                                                                        runat="server"   Font-Bold="False">Eff Infotech</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server"   Font-Bold="False">Mother Designation</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox5" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label71" runat="server"
                                                                          Font-Bold="False">S/w Engg.</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Company address"   Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox6" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label72" runat="server"
                                                                          Font-Bold="False">Sai Plazza,Sec-4,Vashi</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label9" runat="server" Text="Telphone No (Office)"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox7" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label73"
                                                                        runat="server"   Font-Bold="False">022-65789658</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr valign="bottom">
                                                            <td>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server"   Font-Bold="False">Mother Mobile No</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox8" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label74"
                                                                        runat="server"   Font-Bold="False">8888589658</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr valign="bottom">
                                                            <td>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label11" runat="server" Text="Present Address"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox9" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label75"
                                                                        runat="server"   Font-Bold="False">Sec-4,Vashi,Navi Mumbai</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                </fieldset>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanelIdcard">
                        <HeaderTemplate>
                            Guardian Details</HeaderTemplate>
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel82" runat="server">
                                <ContentTemplate>
                                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                                       <tr>
                                            <td style="padding: 10px 0 20px 0;">
                                            <center>
                                                <fieldset style="width: 622px; height: 380px;">
                                                    <legend style="color: #000000; font: 13px verdana; margin-left: 190px;">Guardian Details</legend>
                                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                                                        <tr runat="server" id="gur1">
                                                            <td align="left" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr id="gri1" runat="server">
                                                            <td rowspan="6">
                                                                &nbsp;&nbsp;
                                                                <img src="images/Sample%20Photo.jpg" 
                                                                    style="line-height: normal; height: 109px;" />&#160;&nbsp;
                                                            </td>
                                                            <td align="left" class="style5">
                                                                <asp:Label ID="Label12" runat="server" Text="Guardian Name"   Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left" nowrap="nowrap">
                                                                <asp:TextBox ID="TextBox10" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label77" runat="server"
                                                                          Font-Bold="False">Jayesh Ramesh Shinde</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri2" runat="server">
                                                            <td align="left" class="style5">
                                                                <asp:Label ID="Label13" runat="server"   Font-Bold="False">Guardian Email Id</asp:Label>
                                                            </td>
                                                            <td align="left" width="230">
                                                                <asp:TextBox ID="TextBox11" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label78" runat="server"
                                                                          Font-Bold="False">Jayesh@gmail.com</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri3" runat="server">
                                                            <td align="left" class="style5">
                                                                <asp:Label ID="Label14" runat="server"   Font-Bold="False">Guardian DOB</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label79" runat="server"
                                                                          Font-Bold="False">14-APR-1982</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri4" runat="server">
                                                            <td align="left" class="style5" nowrap="nowrap">
                                                                <asp:Label ID="Label15" runat="server"   Font-Bold="False">Guardian Company Name</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox13" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label80"
                                                                        runat="server"   Font-Bold="False">Gmatricx Ltd.</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri5" runat="server">
                                                            <td class="style5" align="left" nowrap="nowrap">
                                                                <asp:Label ID="Label16" runat="server"   Font-Bold="False">Guardian Designation</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label81" runat="server"
                                                                          Font-Bold="False">Manager</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri6" runat="server">
                                                           
                                                            <td align="left" class="style5">
                                                                <asp:Label ID="Label17" runat="server" Text="Company address"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox15" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                    ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label82" runat="server"
                                                                          Font-Bold="False">Millennium Park,Sec-15,Andheri,mumbai-410206</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri7" runat="server">
                                                            <td>
                                                            </td>
                                                            <td align="left" class="style5" nowrap="nowrap">
                                                                <asp:Label ID="Label18" runat="server" Text="Telphone No (Office)"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label83"
                                                                        runat="server"   Font-Bold="False">022-665894585</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr valign="bottom" id="gri8" runat="server">
                                                            <td>
                                                            </td>
                                                            <td align="left" class="style5" nowrap="nowrap">
                                                                <asp:Label ID="Label19" runat="server"   Font-Bold="False">Guardian Mobile No</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox17" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label84"
                                                                        runat="server"   Font-Bold="False">9025487512</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr valign="bottom" id="gri9" runat="server">
                                                            <td>
                                                            </td>
                                                            <td align="left" class="style5">
                                                                <asp:Label ID="Label20" runat="server" Text="Present Address"  
                                                                    Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="TextBox18" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                    MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox><asp:Label ID="Label85"
                                                                        runat="server"   Font-Bold="False">Sec-3,Vashi,Navi Mumbai</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="gri10" runat="server">
                                                            <td colspan="4">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                                </center>
                                            </td>
                                        </tr>
                                        </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
        </div>
        </center>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultStudent.aspx.cs" Inherits="ResultStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="css/templeat.min.css" type="text/css">
    <link rel="stylesheet" href="css/style12.css" type="text/css">
    <link rel="stylesheet" href="css/them-color.css" type="text/css">
    <style type="text/css">
        .word
        {
            width: 30px;
            height: 30px;
            float: left;
            left: -148px;
            top: 10px;
            position: relative;
        }
        .excel
        {
            width: 30px;
            height: 30px;
            float: left;
            left: -142px;
            top: 10px;
            position: relative;
        }
        .pdf
        {
            width: 30px;
            height: 30px;
            float: left;
            position: relative;
            top: 4px;
            left: -146px;
        }
        top
        {
            width: 1024px;
            height: 110px;
        }
        
        @charset"utf-8";/* CSS Document */
        
             
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
            background-color:#3c8dbc;
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
            font-size: 13px;            
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
            border-radius: 2px 2px 0 0;
            border: 1px solid #3c8dbc;
            border-bottom: none;
            padding-top: 5px;
            font-size: 15px;
            font-family: Verdana;
            cursor: pointer;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: #3c8dbc;
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
            margin-top:-1px;
        } 
        .textcss
        {
            font-family: Verdana;
            font-size: 12px;
            text-align: left;
        }
        .textsize
        {
            font-family: Verdana;
            font-size: 12px;
        }
        
    </style>
    <style type="text/css">
        .style1
        {
            width: 60%;
            margin: 0 auto;
        }
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input[type=text]
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .input-blue
        {
            width: 100%;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 30px;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .style1 select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
        }
        .efficacious_send
        {
            width: 60% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        .style1 input[type="radio"]
        {
            width: 100%;
        }
    </style>
     <style type="text/css">
        .main-report-box
        {
            width: 1000px;
            margin: 0 auto;
            border: 2px solid #3498db !important;
            position: relative;
        }
        .element.style {
        border: none;
        height: 557px;
        width: 100%;
         }
        

        .main-report-box
        {
            width: 1000px;
            margin: 0 auto;
            border: 2px solid #000;
            position: relative;
        }

        .school-logo
        {
            width: 120px;
            text-align: center;
            height: auto;
            position: absolute;
            left: 10px;
            top: 20px;
        }

            .school-logo img
            {
                width: 100%;
            }

        .main-report-box h2, .main-report-box h4, .main-report-box p, .main-report-box h3
        {
            font-weight: bold;
            text-align: center;
        }

        .main-report-box h3
        {
            font-size: 20px;
            line-height: 20px;
        }

        .main-report-box h2
        {
            font-size: 26px;
        }

        .main-report-box h4
        {
            font-size: 18px;
        }

        .student-details
        {
            padding: 10px;
            font-size: 14px;
        }

            .student-details table tr td
            {
                padding: 5px;
            }

        .repot-div
        {
            width: 100%;
            font-size: 12px;
        }

        .blackcolor
        {
            background: #000;
            color: #fff;
            border: 1px solid #fff;
        }

        .repot-div table tr td
        {
            padding: 5px;
        }

        .repot-div table .blackcolor td
        {
            border: 1px solid #fff;
        }

        .repot-div table .whitecolor td
        {
            border: 1px solid #000;
        }

        .ptag
        {
            text-align: left !important;
            width: 98%;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
             <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
<div><asp:Button ID="btnPDF" runat="server" Text="Export to PDF" OnClick="btnExport_Click"  Visible="false"/>
     <table width="100%">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 0px" valign="middle">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblDIV" runat="server" Text="DIV" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlDIV" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>                                                   
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="bottom">                                                     
                                                        <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="textsize" 
                                                            OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                        </asp:DropDownList>                                                     
                                                    </td>                                                   
                                                </tr>
                                            </table>
    </div>
    <asp:Panel ID="pnlPerson" runat="server" Visible="false">
    
    <div class="main-report-box">
    <div></div>
        <div class="school-logo">
            <img src="images\logo-home.png"> </div>
       
        <h2 style="font-family:Verdana; font-size:20px;">Modern School & Jr. College - Vashi</h2>
        <h4 style="font-family:Verdana; font-size:13px;">Sector 7, Vashi, Navi Mumbai. 400 703</h4>
        <h4 style="font-family:Verdana; margin-left: 27px; font-size:13px;" >E-mail: modernschoolvashi@gmail.com, www.modernschoolvashi.org.org Phone + Fax : 022 27821346</h4>
        <p style="font-family:Verdana; font-size:12px;">Affiliated to Maharashtra State Board</p>
        <h3 style="font-family:Verdana; font-size:12px;">Record of Academic Performance<br>
            2015-16</h3>
        <div class="student-details">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font-family:Verdana; font-size:12px;">
                <tr >
                    <td width="18%" align="left" valign="top"><strong>Registration No.</strong></td>
                    <td width="32%" align="left" valign="top"><asp:Label ID="lblRegistration" runat="server" Text="Label"></asp:Label></td>
                    <td width="19%" align="left" valign="top">&nbsp;</td>
                    <td width="16%" align="left" valign="top"><strong>Admission No.</strong></td>
                    <td width="15%" align="left" valign="top"><asp:Label ID="lblAdmision" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" valign="top"><strong>Name of student</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblFullnameNext" runat="server" Text="Label"></asp:Label></td>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top"><strong>Roll No.</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblRoll" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" valign="top"><strong>Father Name</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblFather" runat="server" Text="Label"></asp:Label></td>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top"><strong>Class</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblDivison" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" valign="top"><strong>Mother Name</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblMother" runat="server" Text="Label"></asp:Label></td>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top"><strong>DOB</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" valign="top"><strong>Address</strong></td>
                    <td align="left" valign="top"><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></td>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top"></td>
                    <td align="left" valign="top">&nbsp;</td>
                </tr>
            </table>



        </div>

        <div class="repot-div">


            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="11" align="center">
                        <asp:GridView ID="grdResult" runat="server"
                            AutoGenerateColumns="true" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                            PageSize="5" Width="100%">                            
                            <RowStyle HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr class="blackcolor" style="display:none">
                    <td width="24%" rowspan="2" align="center" valign="middle">Subject Code and Name</td>
                    <td colspan="3" align="center" valign="middle">Term2</td>
                    <td colspan="3" align="center" valign="middle">Term2</td>
                    <td width="8%" rowspan="2" align="center" valign="middle">TOTAL<br>
                        SA
                        <br>
                        40</td>
                    <td width="8%" rowspan="2" align="center" valign="middle">TOTAL<br>
                        SA
                        <br>
                        60</td>
                    <td colspan="2" align="center" valign="middle">Overall Grade (FA + SA)</td>
                </tr>
                <tr class="blackcolor" style="display:none">
                    <td width="7%" align="center" valign="middle">FA1<br>
                        10</td>
                    <td width="7%" align="center" valign="middle">FA2<br>
                        10</td>
                    <td width="7%" align="center" valign="middle">SA1<br>
                        20</td>
                    <td width="7%" align="center" valign="middle">FA3<br>
                        10<br>
                    </td>
                    <td width="7%" align="center" valign="middle">FA4<br>
                        10<br>
                    </td>
                    <td width="7%" align="center" valign="middle">SA2<br>
                        40</td>
                    <td width="8%" align="center" valign="middle">Grade<br>
                        100</td>
                    <td width="8%" align="center" valign="middle">Grade Point (GP)</td>
                </tr>
                <tr class="whitecolor" style="display:none">
                    <td>SCIENCE</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="whitecolor" style="display:none">
                    <td>ENGLISH</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="whitecolor" style="display:none">
                    <td>HINDI</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="whitecolor" style="display:none">
                    <td>sOCIAL sCIENCE</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="whitecolor" style="display:none">
                    <td>MATHEMATICS</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="whitecolor" style="display:none">
                    <td colspan="10">CGPA</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <br>
            <br>
            <p class="ptag" style="display:none">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
            <br>
            <br>
            <br>
            <br>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font-size: 10px; font-family:Verdana;">
                <tr>
                    <td width="20%" align="center " valign="bottom"><strong>Class Teacher</strong></td>
                    <td width="60%">&nbsp;</td>
                    <td width="20%" align="center" valign="bottom"><strong>Principal</strong></td>
                </tr>
            </table>
        </div>
    </div>
    </asp:Panel></ContentTemplate> </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

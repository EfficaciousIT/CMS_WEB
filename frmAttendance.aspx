<%@ Page Language="C#" MasterPageFile="~/MasterPageBoostrap.master" AutoEventWireup="true"
    Culture="en-Gb" EnableEventValidation="false" CodeFile="frmAttendance.aspx.cs"
    Inherits="frmAttendance" Title="Attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link rel="stylesheet" type="text/css" media="all" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" media="all" href="css/default.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/modals.js"></script>--%>
   <%--<style type="text/css">
        .style1
        {
            height: 16px;
        }
            .mGrid th {
  padding: 4px 2px;
  color: #fff;
  text-align: center !important;
  background: rgb(3, 116, 3);
  border-left: solid 1px #525252;
  font-size: 0.9em;
  font: 12px verdana;
  height: 29px;
}
 .pdf {
  
  top: 5px !important;
  left: -137px !important;}
        .slidediv
        {
            width: 80%;
            padding: 20px;
            background: #FFAA;
            color: #fff;
            margin-top: 10px;
            border-bottom: 5px solid #FFF;
            display: none;
        }
        .pagewrapper {
            width: 1024px;
            min-height: inherit !IMPORTANT;
            margin: 0 auto;
            padding-top: 10px;
            background: #fff;
}
#efficacious {
  background: #e5e5e5;
  border-radius: 5px;
  height: 40px !important;
  padding: 2px;
  width: 90%;
  margin-bottom: 5px;
}
.efficacious select {
  width: 80% !important;
  border: 1px solid #3498db;
  padding: 2px 5px;
  height: 26px;
  border-radius: 5px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  font-size: 13px;
  margin: 3px 5px 10px 5px;
  outline: 0;
}
      #footer {
  width: 1024px !important;
  margin: 0px auto;
  padding: 20px 27px;
  BACKGROUND: #e5e5e5;
  /* height: 36px; */
}
        .excel {
  width: 30px;
  height: 30px;
  float: left;
  
  top: 10px !important;
  position: relative;
}
.word {
  width: 30px;
  height: 30px;
  float: left;
  
  top: 10px !important;
  position: relative;
}
.nav-imgbox {
    width: 50px !important;
    height: 50px !important;
    border-radius: 50%;
    background: #6e6e6e;
    text-align: center;
    padding: 11px 10px 0 10px;
    margin: -5px auto 8px !important; 
}
    </style>
    <script type="text/jscript">


        $(function () {
            $('.divClass').click(function () {
                $(".slidediv").slideToggle();
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%">
        <table width="100%">
            <tr>
                <td>
                    <div style="padding: 5px 0 0 0">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                                ActiveTabIndex="0">
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        Calendar</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="padding-left: 80px;">
                                                                        <asp:Panel ID="panel1" runat="server">
                                                                            <br>
                                                                            <asp:Calendar ID="CalAttendance" runat="server" Font-Names="Tahoma" Height="250px"
                                                                                Width="500px" Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full"
                                                                                SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar" OnDayRender="Calendar1_DayRender"
                                                                                CellPadding="4">
                                                                                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                                                                <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                                                                <DayHeaderStyle CssClass="myCalendarDayHeader" />
                                                                                <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
                                                                                <TodayDayStyle CssClass="myCalendarToday" />
                                                                                <SelectorStyle CssClass="myCalendarSelector" />
                                                                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                                                <TitleStyle CssClass="myCalendarTitle" />
                                                                            </asp:Calendar>
                                                                            <br />
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td valign="top" width="80%" align="center">
                                                                        <br />
                                                                        <asp:Image ID="Image1" ImageUrl="~/images/LEGEND.png" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                    <HeaderTemplate>
                                                        Tabular</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <div class="efficacious">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center" class="style1">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <div class="efficacious" id="efficacious">
                                                                            <table width="40%">
                                                                                <tr>
                                                                                    <td align="right" valign="top">
                                                                                        <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
                                                                                            ToolTip="Previous" Width="30px" />
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        <asp:DropDownList ID="ddlMonth" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                                                            <asp:ListItem>--Select Month--</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" runat="server" ImageUrl="~\images\next.png"
                                                                                            ToolTip="Next" Width="30px" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <br />
                                                                        <asp:GridView ID="grvAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                                                            AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                            Width="100%" OnPageIndexChanging="grvAttendance_PageIndexChanging" PageSize="31">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="dtinTime" HeaderText="In-Time " ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="dtoutTime" HeaderText="Out-Time" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="vchlatestatus" HeaderText="Status" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Latetime" HeaderText="Late (HH:MM)" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="AttendanceMode" HeaderText="Attendance Mode" ReadOnly="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <PagerStyle CssClass="pgr" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID="Summery" runat="server">
                                                    <HeaderTemplate>
                                                        Summary</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                        <tr>
                                                                    <td align="center" class="style1">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <div class="efficacious" id="efficacious" style="width:90%;">
                                                                        <table width="40%">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="Label2" runat="server" CssClass="textsize" Text="Year"></asp:Label>
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlYear1" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                        OnSelectedIndexChanged="ddlYear1_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:GridView ID="grvSummery" ShowFooter="True" runat="server" AllowPaging="True"
                                                                        AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                        PageSize="12" Width="100%" OnRowDataBound="grvSummery_RowDataBound">
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="Month" HeaderText="Month" FooterText="Total" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Justify" />
                                                                                <FooterStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Att" HeaderText="Present" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center"  />
                                                                                <FooterStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Late" HeaderText="Late" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <FooterStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Absent" HeaderText="Absent">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <FooterStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Leave" HeaderText="Leave">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <FooterStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="TotDays" HeaderText="Total Days" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <FooterStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                        <PagerStyle CssClass="pgr" />
                                                                        <RowStyle HorizontalAlign="Left" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        </div></ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID="Top5" runat="server">
                                                    <HeaderTemplate>
                                                        Top 5</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <div class="efficacious">
                                                                <table width="100%">
                                                                 <tr>
                                                                    <td align="center" class="style1">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <div id="efficacious" style="width:90%;">
                                                                                <table width="40%">
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="Label3" runat="server" CssClass="textsize" Text="Year"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:DropDownList ID="ddlYear2" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                                OnSelectedIndexChanged="ddlYear2_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table width="100%">
                                                                                
                                                                                <tr>
                                                                                <td valign="top">
                                                                                <div style="width:23%; margin:0 auto;">

                                                                                        <asp:Label ID="lblNm" runat="server" style="float:left;  width:auto !IMPORTANT;" CssClass="textcss" Font-Bold="True"></asp:Label>
                                                                                        <asp:Label ID="lblCount" runat="server" style="float:left; width:auto !IMPORTANT;" CssClass="textcss" Font-Bold="True"></asp:Label>
                                                                                   
                                                                                   </div>
                                                                                    </td>
                                                                                    
                                                                                    </tr>
                                                                                <tr>
                                                                                    
                                                                                    <td width="100%" align="right">
                                                                                        <asp:GridView ID="grvTopAtt" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                            CssClass="mGrid" EmptyDataText="Record not Found." Width="100%" PageSize="5">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="Rank" HeaderText="Rank">
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Name" HeaderText="Student Name">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="Present\Total" DataField="Day">
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                            </Columns>
                                                                                            <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                                            <PagerStyle CssClass="pgr" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                    
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                            </asp:TabContainer>
                                        </td>
                                        <td align="right" width="100%" valign="top">
                                         <div class="pdf">   
                                            <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" ImageUrl="~/images/pdfImg.gif"
                                                runat="server" OnClick="ImgPdf_Click" />
                                                </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td align="right" width="100%" valign="top">
                    <table width="100%">
                        <tr>
                            <td align="center" width="100%" valign="top" colspan="2">
                            <div class="excel">
                                <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" ImageUrl="~/images/xlsImg.gif"
                                    runat="server" OnClick="ImgXls_Click" />
                                    </div>
                            </td>
                            <td align="center" width="100%" valign="top" colspan="2">
                            <div class="word">    <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" ImageUrl="~/images/docImg.gif"
                                    runat="server" OnClick="ImgDoc_Click" />
                                    </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

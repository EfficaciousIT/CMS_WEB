<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    Title="Students Absent Report" Culture="en-gb" CodeFile="frmStudentAbsent.aspx.cs"
    Inherits="frmStudentAbsent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style type="text/css">
     
         
         


.mGrid{ margin:0 auto;}
     
    .excel {
width: 30px;
height: 30px;
float: left;
left: -114px !important;
top: 53px !important;
position: relative;
}
.mGrid th{ text-align:center !important;}
.pdf {
width: 30px;
height: 30px;
float: left;
position: relative;
top: 1px !important;
left: -146px !important;}
.word {top:21px !important;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <table width="100%">
            <tr>
                <td>
                    <div style="padding: 5px 0 0 0">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                              
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <div class="efficacious" id="efficacious">
                                                <table width="90%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblDIV" runat="server" Text="DIV" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDIV" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-right: 20px">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="padding-right: 20px">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                                                Width="1015px">
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        Calendar</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="right" style="padding-left: 80px;">
                                                                    <asp:Panel ID="panel1" runat="server">
                                                                        <br>
                                                                        <asp:Calendar ID="CalAttendance" runat="server" Font-Names="Tahoma" Height="250px"
                                                                            Width="500px" Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full"
                                                                             SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar"
                                                                            OnDayRender="CalAttendance_DayRender" CellPadding="4">
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
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                    <HeaderTemplate>
                                                        Tabular</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <div class="efficacious" id="efficacious">
                                                                        <table width="30%">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:ImageButton ID="lnkPrevious" style="position:relative; top:-5px;" runat="server" ImageUrl="~/images/previous.png"
                                                                                        ToolTip="Previous" Width="30px" OnClick="lnkPrevious_Click" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:DropDownList ID="ddlMonth1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlMonth1_SelectedIndexChanged">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
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
                                                                                <td align="left">
                                                                                    <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" style="position:relative; top:-5px;" runat="server" ImageUrl="~\images\next.png"
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
                                                                        Width="100%" PageSize="30" OnPageIndexChanging="grvAttendance_PageIndexChanging">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="RollNo" HeaderText="Roll No" ReadOnly="True" Visible="False">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" Visible="False">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="AbsentDate" HeaderText="Date" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="reason" HeaderText="Reason" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="parentapproval" HeaderText="Parent Approval" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="PApproveDt" HeaderText="Approved Date">
                                                                                <HeaderStyle Width="110px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="teacherapproval" HeaderText="Teacher Approval" ReadOnly="True">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="TApproveDt" HeaderText="Approved Date">
                                                                                <HeaderStyle Width="110px" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                        <PagerStyle CssClass="pgr" />
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID='AllSummery' runat="server">
                                                    <HeaderTemplate>
                                                        Summary
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <br />
                                                            <br />
                                                            <center>
                                                                <div class="efficacious" id="efficacious">
                                                                    <table width="70%">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label3" runat="server" CssClass="textsize" Text="Month"></asp:Label>
                                                                            </td>
                                                                            <td align="left" width="65%">
                                                                                <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="True" style="width: 60%;" CssClass="textsize"
                                                                                    OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged">
                                                                                    <asp:ListItem>--Select--</asp:ListItem>
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
                                                                             <td align="center">
                                                                                <asp:Label ID="lblYear" runat="server" Text="Year" CssClass="textsize"></asp:Label>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                    OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">

                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <asp:GridView ID="grvStudSumm" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                    Width="100%" PageSize="30" OnPageIndexChanging="grvStudSumm_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" Visible="False">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Roll" HeaderText="Roll No" />
                                                                        <asp:BoundField DataField="Name" HeaderText="Student Name" />
                                                                        <asp:BoundField DataField="Absent" HeaderText="Absent"></asp:BoundField>
                                                                        <asp:BoundField DataField="Att" HeaderText="Total Attendance" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="TotDays" HeaderText="Total Days" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                            </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                            </asp:TabContainer>
                                        </td>
                                        <td align="right" width="100%" valign="top">
                                        <div class="pdf" style="top:7px !important;">
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
                            <td>
                            <div class="excel">
                                <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" ImageUrl="~/images/xlsImg.gif"
                                    runat="server" OnClick="ImgXls_Click" />
                                    </div>
                            </td>
                        </tr>
                        <tr>

                            <td align="center" width="100%" valign="top" colspan="2">
                            <div class="word">
                                <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" ImageUrl="~/images/docImg.gif"
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

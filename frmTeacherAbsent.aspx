<%@ Page Title="Teacher Absent Report" Language="C#" MasterPageFile="~/newMasterPage.master"
    AutoEventWireup="true" CodeFile="frmTeacherAbsent.aspx.cs" Inherits="frmTeacherAbsent"
    Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style type="text/css">
      
       .mGrid{ margin:0 auto;}  
    .excel {
width: 30px;
height: 30px;
float: left;
left: -114px !important;
top: 43px !important;
position: relative;
}
.pdf {
width: 30px;
height: 30px;
float: left;
position: relative;
top: 1px !important;
left: -146px !important;}
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td table width="100%">
                                        <div class="efficacious" id="efficacious">
                                            <table width="90%">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblType" runat="server" Text="Type" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblDept" runat="server" Text="Department" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblTeacherNm" runat="server" Text="Teacher Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlTeacher_SelectedIndexChanged">
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
                                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
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
                                                                                <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" style="  position: relative;
  top: -5px;
  right: 5px;" runat="server" ImageUrl="~\images\previous.png"
                                                                                    ToolTip="Previous" Width="30px" />
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
                                                                                <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" style="  position: relative;
  top: -5px;
  left: 5px;" runat="server" ImageUrl="~\images\next.png"
                                                                                    ToolTip="Next" Width="30px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <br />
                                                                <asp:GridView ID="grvAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                    Width="100%" PageSize="30">
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
                                                                        <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="AdminApproveDt" HeaderText="Approved Date"></asp:BoundField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="pgr" />
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                </td>
                <td align="right" width="1%" valign="top">
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

<%@ Page Language="C#" MasterPageFile="~/MasterPageBoostrap.master" AutoEventWireup="true" Culture="en-gb"
    CodeFile="frmAbsentReport.aspx.cs" Inherits="frmAbsentReport" Title="Absent Report" %>
  

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>

.mGrid{ margin:0 auto;}
</style>
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 5px 0 0 0">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="left">
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
                                                                            <asp:Calendar ID="Calendar1" runat="server" Font-Names="Tahoma" Height="250px"
                                                                                Width="500px" Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full"
                                                                                 SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar"
                                                                                OnDayRender="Calendar1_DayRender" CellPadding="4">
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
                                                    </center>
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
                                                                                <asp:Label ID="Label1" runat="server" Text="Travel Details" Visible="False"></asp:Label>
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
                                                                                    ToolTip="Previous" Width="30px" />
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:DropDownList ID="ddlMonth" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                                                                                <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" runat="server" ImageUrl="~\images\next.png"
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
                                                                <br />
                                                                <asp:GridView ID="gridAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                    Width="100%" PageSize="30">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True">
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
                                                                        <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" />
                                                                        <asp:BoundField DataField="AdminApproveDt" HeaderText="Approve Date" />
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
                                        <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" CausesValidation="false"
                                            ImageUrl="~/images/pdfImg.gif" runat="server" OnClick="ImgPdf_Click" />
                                            </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td align="right" width="100%" valign="top">
            <div class="excel">
                <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" CausesValidation="false"
                    ImageUrl="~/images/xlsImg.gif" runat="server" OnClick="ImgXls_Click" /></div>
                     <div class="word">
                                <img src="/images/docImg.gif"
                                    />
                                    </div>
            </td>
            <td>
            
                                    
            </td>
            
        </tr>


    </table>
     <style type="text/css">
               
        .efficacious select{ margin-bottom:0px;}
        #efficacious{ height:34px;}
                   .mGrid th {
  padding: 4px 2px;
  color: #fff;
  text-align: center !important;
  background: #3498db;
  border-left: solid 1px #525252;
  font-size: 0.9em;
  font: 12px verdana;
  height: 29px;
}
.word {
  width: 30px;
  height: 30px;
  float: left;
left: -114px;
  top: -12px; outline:none;
  position: relative;
}
.excel 
{
    outline:none; top:18px !important;
    }
 .pdf {
 outline:none;
  left: -133px !important;     top: 11px !important;
}
   </style>
</asp:Content>

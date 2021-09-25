<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    Title="Students Late Days Reports" Culture="en-Gb" CodeFile="frmStudentLateDays.aspx.cs"
    Inherits="frmStudentLateDays" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
.mGrid th{ text-align:center !important; }
.mGrid{margin:0 auto;}
</style>
<script language="javascript" type="text/javascript">
    function Confirm34() {
        var update = confirm('Do You Really Want To Update Current Status ?');

        if (update) {
            return true;
        }
        else {
            return false;
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    <div class="efficacious" id="efficacious">
                                        <table width="90%">
                                            <tr>
                                                <td align="left" style="padding-right: 20px">
                                                    <asp:Label ID="lblSTD" runat="server" style="text-align:right" Text="STD" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="padding-right: 20px">
                                                    <asp:Label ID="lblDIV" runat="server" style="text-align:right" Text="DIV" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlDIV" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStudName" runat="server" style="text-align:right; padding-right:10px;"  Text="Student Name" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100%">
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
                                                                            <asp:ImageButton ID="lnkPrevious" style="position:relative; top:-5px; right:5px;" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
                                                                                ToolTip="Previous" Width="30px" />
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:DropDownList ID="ddlMonth1" runat="server" Font-Names="Verdana" Font-Size="13px"
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
                                                                            <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" style="position:relative; top:-5px; left:5px;" runat="server" ImageUrl="~\images\next.png"
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
                                                            <asp:GridView ID="grvLate" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                Width="100%" OnPageIndexChanging="grvLate_PageIndexChanging" PageSize="30">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" Visible="False" />
                                                                    <asp:BoundField DataField="Name" HeaderText="Name" Visible="False" />
                                                                    <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True"></asp:BoundField>
                                                                    <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True"></asp:BoundField>
                                                                    <asp:BoundField DataField="reason" HeaderText="Reason" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="InTime" HeaderText="In Time" />
                                                                    <asp:BoundField DataField="Login" HeaderText="Attendance Time" />
                                                                    <asp:BoundField DataField="parentapproval" HeaderText="Parent Approval" ReadOnly="True"
                                                                        Visible="False">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="PApproveDt" HeaderText="Parent Approval Date" Visible="False">
                                                                        <HeaderStyle Width="90px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="teacherapproval" HeaderText="Teacher Approval" ReadOnly="True"
                                                                        Visible="False">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="110px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TApproveDt" HeaderText="Teacher Approval Date" Visible="False">
                                                                        <HeaderStyle Width="100px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="LateTime" HeaderText="Late Time (HH:MM)" />
                                                                </Columns>
                                                                <PagerStyle CssClass="pgr" />
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
                                                    <center>
                                                        <div class="efficacious" id="efficacious" style="margin-top:15px;">
                                                            <table width="70%">

                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Label ID="Label3" runat="server" CssClass="textsize" Text="Month"></asp:Label>
                                                                    </td>
                                                                    <td align="center" style="padding-right: 20px">
                                                                        <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="True" CssClass="textsize"
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
                                                                        <asp:Label ID="Label1" runat="server" CssClass="textsize" Text="Year"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" Style="padding-right: 20px"
                                                                            CssClass="textsize" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
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
                                                                Width="100%" OnPageIndexChanging="grvStudSumm_PageIndexChanging" 
                                                                PageSize="7">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" Visible="False">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Roll" HeaderText="Roll No" />
                                                                    <asp:BoundField DataField="Name" HeaderText="Student Name" />
                                                                    <asp:BoundField DataField="Late" HeaderText="Late" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                    </asp:BoundField>
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
                                <td align="right"  valign="top">
                                    <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" style="  position: relative;
  left: -135px;" CssClass="export" ImageUrl="~/images/pdfImg.gif"
                                        runat="server" OnClick="ImgPdf_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="right" width="100%" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImgXls" CssClass="export" style="  position: relative;
  top: 41px;
  left: -103px;" ToolTip="Export in Excel" ImageUrl="~/images/xlsImg.gif"
                                runat="server" OnClick="ImgXls_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" style="  position: relative;
  top: 16px;
  left: -132px;" CssClass="export" ImageUrl="~/images/docImg.gif"
                                runat="server" OnClick="ImgDoc_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

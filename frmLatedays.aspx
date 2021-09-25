<%@ Page Language="C#" MasterPageFile="~/MasterPageBoostrap.master" AutoEventWireup="true"
    CodeFile="frmLatedays.aspx.cs" Inherits="frmLatedays" Title="Late Days Report"
    Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .mGrid
        {
            margin: 0 auto;
        }
        
        .efficacious select
        {
            margin-bottom: 0px;
            width: 90%;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            text-align: center !important;
            background: #3498db;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .word
        {
            width: 30px;
            height: 30px;
            float: left;
            left: -86px;
            top: -16px;
            position: relative;
        }
        
        #efficacious
        {
            height: 34PX;
        }
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
                                                                        <asp:Calendar ID="Calendar1" runat="server" Font-Names="Tahoma" Height="250px" Width="500px"
                                                                            Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full" SelectMonthText="»"
                                                                            SelectWeekText="›" CssClass="myCalendar" OnDayRender="Calendar1_DayRender" CellPadding="4">
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
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <div id="efficacious" class="efficacious">
                                                                    <table width="40%">
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
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
                                                                                <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" runat="server" ImageUrl="~\images\next.png"
                                                                                    ToolTip="Next" Width="30px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%">
                                                                <br />
                                                                <asp:GridView ID="grvLate" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                    Width="1011px" OnPageIndexChanging="grvLate_PageIndexChanging" PageSize="30">
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" Visible="False" />
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" Visible="False" />
                                                                        <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True"></asp:BoundField>
                                                                        <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True"></asp:BoundField>
                                                                        <asp:BoundField DataField="reason" HeaderText="Reason" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
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
                                        </asp:TabContainer>
                                    </td>
                                    <td align="right" width="100%" valign="top">
                                        <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" CausesValidation="false"
                                            ImageUrl="~/images/pdfImg.gif" runat="server" Style="position: relative; left: -106px;
                                            outline: none;" OnClick="ImgPdf_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td align="right" width="100%" valign="top">
                <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" CausesValidation="false"
                    ImageUrl="~/images/xlsImg.gif" runat="server" Style="position: relative; left: -116px;
                    top: 6px; outline: none;" OnClick="ImgXls_Click" />
                <%--<div class="word">
                    <img src="/images/docImg.gif" style="position: relative; left: -5px;" />
                </div>--%>
               
            </td>
        </tr>
    </table>
</asp:Content>

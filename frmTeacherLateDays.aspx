<%@ Page Title="Teacher Late Days Report" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" Culture="en-Gb"
    CodeFile="frmTeacherLateDays.aspx.cs" Inherits="frmTeacherLateDays" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>
    .mGrid{ margin:0 auto;}
    .mGrid th{ text-align:center !important;}
    </style>
    <br />
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                    <div class="efficacious" id="efficacious">
                        <table width="90%">
                          
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblType" runat="server" style="text-align:right" Text="Type" CssClass="textsize"></asp:Label>
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
                                                        NextPrevFormat="FullMonth" SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar"
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
                                                &nbsp;</td>
                                        </tr>
                                          <tr>
                                            <td align="right">
                                            <div class="efficacious" id="efficacious">
                                                <table width="30%">
                                                
                                                    <tr>
                                                      
                                                        <td align="right">
                                                        <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" style="position:relative; top:-5px;" runat="server" ImageUrl="~\images\previous.png" ToolTip="Previous"
                                                            Width="30px" />
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
                                                        <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" style="position:relative; top:-5px;" runat="server" ImageUrl="~\images\next.png" ToolTip="Next"
                                                            Width="30px" />
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
                                                        <asp:BoundField DataField="InTime" HeaderText="In Time"></asp:BoundField>
                                                        <asp:BoundField DataField="reason" HeaderText="Reason" ReadOnly="True"></asp:BoundField>
                                                        <asp:BoundField DataField="parentapproval" HeaderText="Parent Approval" ReadOnly="True"
                                                            Visible="False"></asp:BoundField>
                                                        <asp:BoundField DataField="PApproveDt" HeaderText="Parent Approval Date" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="teacherapproval" HeaderText="Teacher Approval" ReadOnly="True"
                                                            Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TApproveDt" HeaderText="Teacher Approval Date" Visible="False">
                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
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
                        
                           
                            <asp:TabPanel Visible="false" ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                            </asp:TabPanel>
                        
                           
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

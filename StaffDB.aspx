<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="StaffDB.aspx.cs" Inherits="StaffDB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="Update1" runat="server">
        <ContentTemplate>
            <div class="content">
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-aqua">
                            <div class="inner">
                                <h4>
                                    <asp:Label ID="lastLogin" runat="server" Text="Label"></asp:Label></h4>
                                <p>
                                    Last seen</p>
                            </div>
                            <div class="icon">
                                <i class="ion">
                                    <img src="img/dashboard-img/attendance-img.png"></i>
                            </div>
                            <a href="FrmStudentLog.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-green">
                            <div class="inner">
                                <h4>
                                    <asp:Label ID="Label2" runat="server" Text="Fee Collection"></asp:Label></h4>
                                <%--<h6>
                                    <asp:Label ID="lblDue" runat="server" Text="Due Till Date : "></asp:Label></h6>--%>
                                    <h6>
                                    <asp:Label ID="lblDue" runat="server" Text="Gross Till Date : "></asp:Label></h6>
                                <h6>
                                    <asp:Label ID="lblRecd" runat="server" Text="Recd Till Date : "></asp:Label></h6>
                                    <h6>
                                    <asp:Label ID="lblPending" runat="server" Text="Pending Till Date : "></asp:Label></h6>
                            </div>
                            <div class="icon">
                                <i class="ion">
                                    <img src="img/dashboard-img/Exams-mg.png"></i>
                            </div>
                            <a href="frmFeePaidTillDate.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-yellow">
                            <div class="inner">
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text="Attendance"></asp:Label></h4>
                                <h5>
                                    <asp:Label ID="lblStudentCnt" Visible="false" runat="server" Text="Student : "></asp:Label></h5>
                                <h5>
                                    <asp:Label ID="lblTeacherCnt" runat="server" Text="Teacher : "></asp:Label></h5>
                                <h5>
                            <asp:Label ID="lblStaffCnt" runat="server" Text="Staff : "></asp:Label></h5>
                        </div>
                            <div class="icon">
                                <i class="ion">
                                    <img src="img/dashboard-img/homework-img.png"></i>
                            </div>
                            <a href="frmTeacherStaffAtt.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-red">
                            <div class="inner">
                                <h4>
                                    Attendance</h4>
                                <p>
                                    Self % :
                                    <asp:Label ID="lblcumulative" runat="server" Text="Label"></asp:Label>
                                </p>
                            </div>
                            <div class="icon">
                                <i class="ion ">
                                    <img src="img/dashboard-img/Fee-img.png"></i>
                            </div>
                            <a href="frmMonthlyAttendance.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="nav-tabs-custom">
                            <!-- Tabs within a box -->
                            <ul class="nav nav-tabs pull-right">
                                <li class="active"><a href="#Month" data-toggle="tab">Month </a></li>
                                <li><a href="#graph" data-toggle="tab" style="display: none">Graph </a></li>
                                <li class="pull-left header">Calendar</li>
                            </ul>
                            <div class="tab-content">
                                <!-- Morris chart - Sales -->
                                <div class="chart tab-pane active" id="Month">
                                    <div id='calendar'>
                                        <%--<asp:Calendar ID="CalAttendance" runat="server" Height="300px" Font-Size="14px" TodayDayStyle-BackColor="Yellow"
                                            TodayDayStyle-ForeColor="Red" CssClass="fc-body CalAttendance" 
                                            CellPadding="4" OnDayRender="Calendar1_DayRender"></asp:Calendar>--%>
                                        <asp:Calendar ID="CalAttendance" runat="server" Font-Names="Tahoma" Height="250px"
                                                Width="500px" Font-Size="14px" NextMonthText=">>" PrevMonthText="<<"
                                                SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar1" OnDayRender="Calendar1_DayRender"
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
                                    </div>
                                    <ul class="color-code">
                                       <li><span class="color-box Absent"></span>Absent </li>
                                        <li><span class="color-box Present1"></span>Present </li> 
                                        <li><span class="color-box Present"></span>Vacation </li>       
                                        <%--<li><span class="color-box Leave"></span>Leave </li>
                                <li><span class="color-box Holiday"></span>Holiday</li>--%>
                                    </ul>
                                </div>
                                <div class="chart tab-pane" id="graph" style="width: 300px; margin: 0px auto; display: none">
                                </div>
                            </div>
                        </div>
                        <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
                        <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.2/raphael-min.js"></script>
                        <script src="js/morris.js"></script>
                        <script>                            Morris.Donut({
                                element: 'graph',
                                colors: ["#00a65a  ", "#f56954 ", "#3c8dbc"],

                                data: [
                                    { value: 70, label: 'Present', formatted: '70%' },
                                    { value: 30, label: 'Absent', formatted: '30%' },
                              ],
                                formatter: function (x, data) { return data.formatted; }
                            });</script>
                        <!-- chart screen -->
                        <div class="box topborder direct-chat direct-chat-warning">
                            <div class="box-header with-border">
                                <h3 class="box-title">
                                    Send Message</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <div class="inner-panel">
                                    <table>
                                        <tr>
                                            <td align="left" width="80px" style="text-align: left;">
                                                <asp:Label ID="lblUserType" runat="server" Text="User type"></asp:Label>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:DropDownList ID="drpUserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpUserType_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                            </td>
                                            <td align="left" style="text-align: left;">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr visible="false" runat="server" id="trStudent">
                                            <td align="left" style="text-align: left;">
                                                <asp:Label ID="Label3" runat="server" tyle="margin-top:10px" Text="Std"></asp:Label>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:DropDownList ID="drpStandard" runat="server" tyle="margin-top:10px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:Label ID="Label11" runat="server" Text="Div" tyle="margin-top:10px"></asp:Label>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:DropDownList ID="drpDivision" runat="server" tyle="margin-top:10px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="drpDivision_SelectedIndexChanged" >
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="text-align: left; padding-left: 10px">
                                                <asp:Label ID="Label12" runat="server" Text="Student"></asp:Label>
                                            </td>
                                            <td align="left" style="text-align: left; padding-left: 10px; margin-bottom: 10px">
                                                <asp:DropDownList ID="drpStudent" runat="server" Width="130px">
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr visible="false" runat="server" id="trStaff">
                                            <td align="left" style="text-align: left;">
                                                <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:Label ID="Label13" runat="server" Text="Staff"></asp:Label>
                                            </td>
                                            <td align="left" style="text-align: left;">
                                                <asp:DropDownList ID="drpStaff" runat="server">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" style="text-align: left;">
                                                <asp:Label ID="Label16" runat="server" Text="Notice"></asp:Label>
                                            </td>
                                            <td colspan="5" style="text-align: left; margin-top: 10px">
                                                <asp:TextBox ID="txtNotice" runat="server" TextMode="MultiLine" Height="68px" Width="335px"
                                                    placeholder="Message"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="text-align: left; margin-top: 10px">
                                                <asp:Button ID="btnSubmit" Style="margin-top: 10px" class="btn btn-primary btn-xs send-sms"
                                                    runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                                <asp:GridView ID="grvLibrary" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False" 
                                                    CssClass="table  tabular-table " EmptyDataText="Record not Found." PageSize="5" 
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Book" HeaderText="Book Name" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Category" HeaderText="Category" />
                                                        <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Return Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReturn" runat="server" Text='<%#Eval("Return") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <!-- /.box-footer-->
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Library Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Inventory Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <asp:GridView ID="grvInventory" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                                    PageSize="5" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Item" HeaderText="Items" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Return" HeaderText="Return Date" Visible="false" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Return Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReturn" Text='<%#Eval("Return") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual Return Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActual" Text='<%#Eval("dtActualReturnDt") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Leave Status</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CssClass="table  tabular-table " EmptyDataText="Record not Found." DataKeyNames="intLeaveApplocation_id"
                                    Width="100%" PageSize="5">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vchLeaveType_name" HeaderText="Type" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                        <asp:BoundField DataField="Status" HeaderText="Total Days" />
                                        <%--<asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkstatus" Text='<%#Eval("Status") %>' runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="box  topborder">
                            <div class="box-header with-border">
                                <h3 class="box-title">
                                    Notice Board
                                </h3>
                            </div>
                            <div class="box-body chart-responsive">
                              <div id="" style="overflow:scroll; height:300px;">
                                <ul class="notice">
                                    <li id="Notice1" visible="false" runat="server">                                        
                                        <div class="board">
                                        <p class="time">
                                               <strong> Issue Date:
                                                <asp:Label ID="lblIssueDate1" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate1" runat="server"></asp:Label> </strong>
                                            </p>
                                            <p><strong> Subject :  <asp:Label ID="lblSubject1" runat="server"></asp:Label> </strong></p>
                                            <p><strong> Notice :  <asp:Label ID="lblNotice1" runat="server"></asp:Label> </strong></p>
                                        </div>
                                    </li>
                                    <li id="Notice2" visible="false" runat="server">
                                        <asp:Label ID="lblSubject2" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice2" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate2" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate2" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice3" visible="false" runat="server">
                                        <asp:Label ID="lblSubject3" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice3" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate3" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate3" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice4" visible="false" runat="server">
                                        <asp:Label ID="lblSubject4" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice4" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate4" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate4" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice5" visible="false" runat="server">
                                        <asp:Label ID="lblSubject5" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice5" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate5" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate5" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice6" visible="false" runat="server">
                                        <asp:Label ID="lblSubject6" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice6" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate6" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate6" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice7" visible="false" runat="server">
                                        <asp:Label ID="lblSubject7" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice7" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate7" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate7" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice8" visible="false" runat="server">
                                        <asp:Label ID="lblSubject8" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice8" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate8" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate8" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice9" visible="false" runat="server">
                                        <asp:Label ID="lblSubject9" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice9" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate9" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate9" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice10" visible="false" runat="server">
                                        <asp:Label ID="lblSubject10" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice10" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate10" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate10" runat="server"></asp:Label></p>
                                        </div>
                                    </li>                                   
                                </ul>
                            </div> </div>
                        </div>
                        <div class="box  topborder">
                            <div class="box-header with-border">
                                <h3 class="box-title">
                                    ..........
                                </h3>
                            </div>
                            <div class="box-body no-padding">
                                <asp:GridView ID="grdBusCnt" CssClass="table  tabular-table " DataKeyNames="intdevice_id,dtStartTime,dtEndTime" runat="server"
                                    AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdBusCnt_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="vchbusnumber" HeaderText="Bus No " />
                                        <asp:BoundField DataField="intime" HeaderText="In Time" />
                                        <asp:TemplateField HeaderText="Present">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPresent" Text='<%#Eval("inCount") %>' runat="server">0</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="lefttime" HeaderText="Out Time" />
                                        <asp:TemplateField HeaderText="Present">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkAbsent" Text='<%#Eval("outCount") %>' runat="server">0</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Device Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <asp:GridView ID="grvHoliday" runat="server" AllowPaging="True" AllowSorting="false"
                                    AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                                    PageSize="5" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="vchHoliday_name" HeaderText="Name" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromDate" HeaderText="Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Day" HeaderText="Day" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


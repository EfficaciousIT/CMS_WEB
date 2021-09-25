<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="studentDB.aspx.cs" Inherits="studentDB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
       .Leave {
    background: #FF6600;
    width: 8px;
    height: 8px;
    margin-right: 5px;
    margin-top: 6px;
    display: block;
    float: left;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                            <asp:Label ID="lblExamDate" runat="server" Text="Label"></asp:Label></h4>
                        <p>
                            <asp:Label ID="lblSubject" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></p>
                    </div>
                    <div class="icon">
                        <i class="ion">
                            <img src="img/dashboard-img/Exams-mg.png"></i>
                    </div>
                    <a href="frmExaminationSchedule.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h4>
                            Homework on
                        </h4>
                        <p>
                            <asp:Label ID="lblHomework" runat="server" Text="Label"></asp:Label></p>
                    </div>
                    <div class="icon">
                        <i class="ion">
                            <img src="img/dashboard-img/homework-img.png"></i>
                    </div>
                    <%--<a href="frmMyDiary.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">--%>
                    <a href="frmMyDiaryStudent.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
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
                    <a href="frmMonthlyAttendance.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i>
                    </a>
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
                        <li><a href="#graph" data-toggle="tab" style="display:none">Graph </a></li>
                        <li class="pull-left header">Calendar</li>
                    </ul>
                    <div class="tab-content">
                        <!-- Morris chart - Sales -->
                        <div class="chart tab-pane active" id="Month">
                            <div id='calendar'>
                               <%-- <asp:Calendar ID="CalAttendance" runat="server" Height="300px" Font-Size="14px" NextMonthText=">>"
                                    PrevMonthText="<<" DayNameFormat="Short" SelectMonthText="»" SelectWeekText="›"
                                    CssClass="fc-body CalAttendance" OnDayRender="Calendar1_DayRender" CellPadding="4">
                                </asp:Calendar>--%>
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
                               <!-- <li><span class="color-box Holiday"></span>Holiday</li>
                                <li><span class="color-box Leave"></span>Leave </li>
                               <li><span class="color-box Present"></span>Vacation </li>-->
                            </ul>
                        </div>
                        <div class="chart tab-pane" id="graph" style="width: 300px; margin: 0px auto; display:none">
                        </div>
                    </div>
                </div>
                <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
                <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.2/raphael-min.js"></script>
                <script src="js/morris.js"></script>
                <script>                    Morris.Donut({
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
                            Fee Chart</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                    <asp:GridView ID="grv1Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table" Width="100%"  AllowPaging="True"
                                                                DataKeyNames="intFeeDetId" >
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="FeeDetId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFeeDetId") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" ReadOnly="True" />
                                                                    <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                                                                    <asp:BoundField DataField="feetype" HeaderText="Type" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intCat_Id" HeaderText="Category" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField DataField="FrmDt" HeaderText="Effective From Date" ReadOnly="True"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="ToDt" HeaderText="Effective To Date" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField DataField="vchFeeDesc" HeaderText="Description" ReadOnly="True" Visible="False" />
                                                                </Columns>
                                                            </asp:GridView>
                        <asp:GridView ID="grdFeeDetails" runat="server" AutoGenerateColumns="true" CssClass="table  tabular-table " Visible="false"
                            EmptyDataText="Record not Found." PageSize="5" Width="100%">
                        </asp:GridView>
                    </div>
                    <!-- /.box-body -->
                    <!-- /.box-footer-->
                </div>
                <div class="box border-blue">
                    <div class="box-header">
                        <h3 class="box-title">
                            Library Details</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <asp:GridView ID="grvLibrary" runat="server"  
                            AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                            PageSize="5" Width="100%" OnRowDataBound="grvLibrary_RowDataBound">
                            <Columns>
                            <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" Visible="false" />
                            <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" Visible="false" />
                            <asp:BoundField DataField="intStudent_id" HeaderText="Student Name" ReadOnly="True" Visible="false" />
                            <asp:BoundField DataField="intBookDetails_id" HeaderText="Book Name" ReadOnly="True" />
                            <asp:BoundField DataField="dtAssigned_Date" HeaderText="Issue Date" ReadOnly="True" />
                            <asp:BoundField DataField="dtReturn_date" HeaderText="Returned Date" ReadOnly="True" />
                              <%--  <asp:BoundField DataField="Book" HeaderText="Book Name" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Return Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReturn" Text='<%#Eval("Return") %>' runat="server"></asp:Label>
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
               <!-- <div class="box border-blue">
                    <div class="box-header">
                        <h3 class="box-title">
                            Inventory Details</h3>
                    </div>
                    
                    <div class="box-body no-padding">
                        <asp:GridView ID="grvInventory" runat="server" 
                            AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                            PageSize="5" Width="100%" OnRowDataBound="grvInventory_RowDataBound">
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
                   
                </div>-->
                <div class="box border-blue">
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
                                <asp:BoundField DataField="Action" HeaderText="Status" />
                                <%--<asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkstatus" Text='<%#Eval("Action") %>' runat="server"></asp:LinkButton>
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
                    </div>
                </div>
                <div class="box  topborder">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Time Table
                        </h3>
                    </div>
                    <div class="box-body chart-responsive">
                        <asp:GridView ID="grvTimetable" runat="server" AllowPaging="false" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                            Width="40%" OnRowDataBound="grvTimetable_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No" HeaderStyle-Height="20%" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrno" Font-Bold="true" runat="server" Text='<%#Eval("SrNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonday" runat="server" Text='<%#Eval("Monday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tuesday">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTuesday" runat="server" Text='<%#Eval("Tuesday")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wednesday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWednesday" runat="server" Text='<%#Eval("Wednesday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thursday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThursday" runat="server" Text='<%#Eval("Thursday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Friday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFriday" runat="server" Text='<%#Eval("Friday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saturday" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSaturday" runat="server" Text='<%#Eval("Saturday")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BitRecess" HeaderStyle-Height="20%" HeaderStyle-Width="13.5%"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecess" runat="server" Text='<%#Eval("btrecess")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="20%" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left"></RowStyle>
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="box border-blue">
                    <div class="box-header">
                        <h3 class="box-title">
                            Holiday Details</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <%--<table class="table">
                            <tr bgcolor="3498db" style="color: #fff">
                                <th style="width: 10px">
                                    #
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Date
                                </th>
                                <th style="width: 150px">
                                    Day
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    1.
                                </td>
                                <td>
                                    Independence Day
                                </td>
                                <td>
                                    15/08/2015
                                </td>
                                <td>
                                    Saturday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2.
                                </td>
                                <td>
                                    Parsi New Year
                                </td>
                                <td>
                                    18/08/2015
                                </td>
                                <td>
                                    Tuesday
                                </td>
                            </tr>
                        </table>--%>
                        <asp:GridView ID="grvHoliday" runat="server" 
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
</div>
</asp:Content>

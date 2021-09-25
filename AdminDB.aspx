<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="AdminDB.aspx.cs" Inherits="AdminDB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<body >--%>
<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
    prm.add_beginRequest(BeginRequestHandler);
    // Raised after an asynchronous postback is finished and control has been returned to the browser.
    prm.add_endRequest(EndRequestHandler);
    function BeginRequestHandler(sender, args) {
        //Shows the modal popup - the update progress
        var popup = $find('<%= modalPopup.ClientID %>');
        if (popup != null) {
            popup.show();
        }
    }

    function EndRequestHandler(sender, args) {
        //Hide the modal popup - the update progress
        var popup = $find('<%= modalPopup.ClientID %>');
        if (popup != null) {
            popup.hide();
        }
    }
    </script>
    <style type="text/css">   
        .Leave {
    background: #FF6600;
    width: 8px;
    height: 8px;
    margin-right: 5px;
    margin-top: 6px;
    display: block;
    float: left;
}    
.table-height
{   height: 350px !important;
    min-height: 340px;
    overflow-y: auto;
    width: 100%;} 
        .modalPopup
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 10000;
            width: 100%;
            height: 100%;
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            z-index:-1;
           
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
 <!-- Main content -->

   <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/hourglass.gif"></asp:Image>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
            Enabled="True">
        </asp:ModalPopupExtender>

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
                            <a href="frmStandardWiseRpt.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
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
                                    <asp:Label ID="lblStudentCnt" runat="server" Text="Student : "></asp:Label></h5>
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
                        <div class="box topborder direct-chat direct-chat-warning" style="display: none">
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
                                                  
                                                     <asp:ListItem>---ALL---</asp:ListItem>
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
                                    PageSize="5" Width="100%" Visible="False">
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
                                            <p><strong> Subject : </strong> <asp:Label ID="lblSubject1" runat="server"></asp:Label> </p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice1" runat="server"></asp:Label> </p>
                                        </div>
                                    </li>
                                    <li id="Li1" visible="false" runat="server">                                        
                                        <div class="board">
                                        <p class="time">
                                               <strong>Issue Date:
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="Label5" runat="server"></asp:Label></strong>  
                                            </p>
                                            <p><strong> Subject : </strong> <asp:Label ID="Label6" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="Label7" runat="server"></asp:Label></p>

                                            
                                            
                                        </div>
                                    </li>
                                    <li id="Notice2" visible="false" runat="server">
                                        
                                        <div class="board">
                                           
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate2" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate2" runat="server"></asp:Label> </strong></p>
                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject2" runat="server"></asp:Label></p>
                                               <p><strong> Notice : </strong> <asp:Label ID="lblNotice2" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice3" visible="false" runat="server">
                                        
                                        <div class="board">
                                           
                                            <p class="time">
                                               <strong> Issue Date:
                                                <asp:Label ID="lblIssueDate3" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate3" runat="server"></asp:Label> </strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject3" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice3" runat="server"></asp:Label></p>

                                        </div>
                                    </li>
                                    <li id="Notice4" visible="false" runat="server">
                                        
                                        <div class="board">
                                           
                                            <p class="time">
                                               <strong> Issue Date:
                                                <asp:Label ID="lblIssueDate4" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate4" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject4" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice4" runat="server"></asp:Label></p>

                                        </div>
                                    </li>
                                    <li id="Notice5" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                               <strong> Issue Date:
                                                <asp:Label ID="lblIssueDate5" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate5" runat="server"></asp:Label> </strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject5" runat="server"></asp:Label></p>
                                                <p><strong> Notice : </strong> <asp:Label ID="lblNotice5" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice6" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate6" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate6" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject6" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice6" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice7" visible="false" runat="server">
                                        <asp:Label ID="lblSubject7" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice7" runat="server"></asp:Label></p>
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate7" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate7" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="Label18" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="Label19" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice8" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                               <strong> Issue Date:
                                                <asp:Label ID="lblIssueDate8" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate8" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject8" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice8" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice9" visible="false" runat="server">
                                       
                                        <div class="board">
                                           
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate9" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate9" runat="server"></asp:Label></p>

                                                <p><strong> Subject : </strong>  <asp:Label ID="lblSubject9" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice9" runat="server"></asp:Label></p>
                                        </div>
                                    </li>
                                    <li id="Notice10" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate10" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate10" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject10" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice10" runat="server"></asp:Label></p>

                                        </div>
                                    </li>      
                                     <li id="Notice11" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate11" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate11" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject11" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice11" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice12" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate12" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate12" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject12" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice12" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                      <li id="Notice13" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate13" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate13" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject13" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice13" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice14" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate14" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate14" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject14" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice14" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice15" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate15" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate15" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject15" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice15" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice16" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate16" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate16" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject16" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice16" runat="server"></asp:Label></p>

                                        </div>
                                    </li>      
                                    <li id="Notice17" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate17" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate17" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject17" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice17" runat="server"></asp:Label></p>

                                        </div>
                                    </li> 
                                    <li id="Notice18" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate18" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate18" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject18" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice18" runat="server"></asp:Label></p>

                                        </div>
                                    </li>        
                                     <li id="Notice19" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate19" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate19" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject19" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice19" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice20" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate20" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate20" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject20" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice20" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice21" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate21" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate21" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject21" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice21" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                     <li id="Notice22" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate22" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate22" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject22" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice22" runat="server"></asp:Label></p>

                                        </div>
                                    </li>     
                                    <li id="Notice23" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate23" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate23" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject23" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice23" runat="server"></asp:Label></p>

                                        </div>
                                    </li>   
                                     <li id="Notice24" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate24" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate24" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject24" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice24" runat="server"></asp:Label></p>

                                        </div>
                                    </li>       
                                     <li id="Notice25" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate25" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate25" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject25" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice25" runat="server"></asp:Label></p>

                                        </div>
                                    </li>          
                                    <li id="Notice26" visible="false" runat="server">
                                        
                                        <div class="board">
                                            
                                            <p class="time">
                                                <strong>Issue Date:
                                                <asp:Label ID="lblIssueDate26" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate26" runat="server"></asp:Label></strong></p>

                                                <p><strong> Subject : </strong> <asp:Label ID="lblSubject26" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="lblNotice26" runat="server"></asp:Label></p>

                                        </div>
                                    </li>          
                                </ul>
                            </div> </div>
                        </div>
                         <div class="box topborder">
                            <div class="box-header with-border">
                                <h3 class="box-title">
                                   Standard Wise Student
                                </h3>
                            </div>
                            <div class="box-body no-padding">
                            <div class=" table-height">
                                <asp:GridView ID="grdStudentCnt" CssClass="table tabular-table" runat="server"
                                    AutoGenerateColumns="False" Width="100%" ShowFooter="True" >
                                    <Columns>
                                        <asp:BoundField DataField="Standard" HeaderText="Standard" />
                                        <asp:BoundField DataField="Division" HeaderText="Division" />
                                        <asp:BoundField DataField="Male" HeaderText="Male" />
                                       <asp:BoundField DataField="Female" HeaderText="Female" />
                                       <asp:BoundField DataField="Total" HeaderText="Total" />
                                    </Columns>
                                </asp:GridView>
                                </div>
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
     <%-- </body>--%>
</asp:Content>

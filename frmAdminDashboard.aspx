<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmAdminDashboard.aspx.cs" Culture="en-Gb"
    Inherits="frmAdminDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html>
<head>
    <title>Dashboard</title>
     <link rel="stylesheet" href="css/AdminCss.css" type="text/css" />
    <style type="text/css">
        .textcss
        {
            font-family: Verdana;
            font-size: 11px;
            text-align: left;
        }
        .textsize
        {
           font-family: Verdana;
            font-size: 11px;
        }
        
       
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: gray;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .container-outer
        {
            overflow: auto;
            position: relative;
            width: 900px;
            height: 450px;
        }
        .style9
        {
            width: 185px;
        }
        .style1
        {
            width: 58px;
        }
        .style11
        {
            width: 117px;
        }
        .style12
        {
            width: 339px;
        }
        </style>
    <script language="javascript" type="text/javascript">
        function DivScroll() {
            //  var element = document.getElementById("dvScroll");
            $("#pannel").scrollTop() = document.getElementById("dvScroll").scrollHeight;
        }
        window.onload = DivScroll();

        window.onload = function () {
            setInterval(function callUserDetail() {
                $.ajax({
                    type: "POST",
                    url: "frmStaffDashboard.aspx/Notification",
                    data: '{UserType: "' + $("#<%=HFUserType.ClientID%>")[0].value + '",Id: "' + $("#<%=HFUserId.ClientID%>")[0].value + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });


            }, 1000);



        }

        function OnSuccess(response) {
            if (response.d != 'false') {
                //               document.getElementById("lblMsgCount").innerText=response.d.toString();
                if (response.d > 0) {
                    $('#<%= lblMsgCount.ClientID%>').html(response.d.toString())
                }
            }


        }

        window.onload = startInterval;
        function startInterval() {
            setInterval("startTime();", 1000);
        }

        function startTime() {
            var now = new Date();
            document.getElementById('lblTime').innerHTML = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
        }
    </script>
</head>
<body>
    <form id="frm" runat="server" style="background-color: #FFFFFF">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <div style="background-image: url('images/MenuBarBackground.png');">
                            <table width="100%">
                                <tr>
                                <td>
                                </td>
                                        <td valign="top">
                                            <div class="home_btn">
                                                <a href="frmAttendance.aspx">
                                                    <img src="images/home.png" title="Home" /></a>
                                            </div>
                                        </td>
                                    <td class="style1">
                                        <asp:HiddenField ID="HFUserType" runat="server" />
                                        <asp:HiddenField ID="HFUserId" runat="server" />
                                    </td>
                                    <td align="right">
                                        <a href="frmSendGroupMsg.aspx" style="width: 50px; height: 50px">
                                            <div style="background-image: url(images/Message.png); background-repeat: repeat;
                                                width: 35px; height: 26px">
                                                <div style="padding-top: 13px; padding-left: 17px">
                                                    <asp:Label ID="lblMsgCount" runat="server" Font-Bold="True" BackColor="Red" ForeColor="White"
                                                        Font-Size="Small"></asp:Label>
                                                </div>
                                            </div>
                                        </a>
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div id="dvScroll" class="container-oute" runat="server" style="background-color: #FFFF;
                            width: 100%">
                            <center>
                                <table width="100%">
                                    <tr>
                                        <td colspan="2" align="center">
                                            <br />
                                            <table width="70%" align="center" border="1" style="background-color: White; border: 2px solid #000;">
                                                <tr>
                                                    <td align="center" class="style1" rowspan="2" bgcolor="Silver">
                                                        <asp:Image ID="Image2" runat="server" Height="49px" ImageUrl="~/images/no of students.png"
                                                            Width="49px" />
                                                    </td>
                                                    <td valign="bottom" align="center" class="style9">
                                                        <asp:Label ID="lblNoOfStudent" runat="server" CssClass="textsize" Font-Size="XX-Large"
                                                            Text="0"></asp:Label>
                                                    </td>
                                                    <td align="center" class="style1" rowspan="2" bgcolor="Silver">
                                                        <asp:Image ID="Image3" runat="server" Height="49px" ImageUrl="~/images/no of admin users.png"
                                                            Width="49px" />
                                                    </td>
                                                    <td valign="bottom" align="center" style="width: 39%;">
                                                        <asp:Label ID="lblNoOfAdmin" runat="server" CssClass="textsize" Font-Size="XX-Large"
                                                            Text="0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="bottom" align="center" class="style9">
                                                        <asp:Label ID="NoOfStudent" runat="server" CssClass="textsize" Text="Total Number Of Students"></asp:Label>
                                                    </td>
                                                    <td valign="bottom" align="center">
                                                        <asp:Label ID="NoOfAdmin" runat="server" CssClass="textsize" Text="Total Number Of Admins"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style1" colspan="4" style="border:1px solid #000">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1" rowspan="2" align="center" bgcolor="Silver">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/no of staff.png" Height="50px"
                                                            Width="50px" />
                                                    </td>
                                                    <td valign="bottom" align="center" class="style9">
                                                        <asp:Label ID="lblNoOfStaff" runat="server" CssClass="textsize" Font-Size="XX-Large"
                                                            Text="0"></asp:Label>
                                                    </td>
                                                    <td align="center" class="style1" rowspan="2" bgcolor="Silver">
                                                        <asp:Image ID="Image4" runat="server" Height="49px" ImageUrl="~/images/no of departments.png"
                                                            Width="49px" />
                                                    </td>
                                                    <td valign="bottom" align="center">
                                                        <asp:Label ID="lblNoOfDept" runat="server" CssClass="textsize" Font-Size="XX-Large"
                                                            Text="0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="bottom" align="center" class="style9">
                                                        <asp:Label ID="NoOfStaff" runat="server" CssClass="textsize" Text="Total Number Of Staff"></asp:Label>
                                                    </td>
                                                    <td valign="bottom" align="center">
                                                        <asp:Label ID="lblYear7" runat="server" CssClass="textsize" Text="Total Number Of Department"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2" style="border-bottom:1px solid">
                                    <table width="100%" >
                                    <tr>
                                        <td colspan="4" align="center" style="border-bottom:2px dotted">
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" rowspan="2" bgcolor="#CCCCCC" >
                                            <asp:Image ID="Image7" runat="server" Height="79px" ImageUrl="~/images/teacher present.png"
                                                Width="79px" />
                                        </td>
                                        <td align="center" colspan="1">
                                            <asp:Label ID="lblTotStaffPresent" runat="server" Text="0" Font-Size="X-Large"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text="/" Font-Size="X-Large"></asp:Label>
                                            <asp:Label ID="lblTotStaff" runat="server" Text="0" Font-Size="X-Large"></asp:Label>
                                        </td>
                                        <td rowspan="7" valign="top" align="center">
                                            <div>
                                            <asp:Chart ID="ChrtSchoolAtt" runat="server" BorderlineDashStyle="DashDot" 
                                                    Width="400px" Height="200px" AlternateText="Department">
                                                <Series>
                                                    <asp:Series ChartType="Pie" Name="Series1" ChartArea="ChartArea" Legend="Legend1">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <asp:Legend Name="Legend1">
                                                    </asp:Legend>
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Alignment="BottomCenter" BackColor="128, 255, 128" 
                                                        Font="Microsoft Sans Serif, 8pt, style=Bold" Name="Title1" Text="Department">
                                                    </asp:Title>
                                                </Titles>
                                                <BorderSkin SkinStyle="Sunken" />
                                            </asp:Chart>
                                                </div>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12" colspan="1" align="center" valign="top">
                                            <asp:Label ID="lblAbsentStud1" runat="server" Text="These shows number of staff present today."></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style11" rowspan="3" bgcolor="#CCCCCC">
                                            <asp:Image ID="Image6" runat="server" Height="76px" ImageUrl="~/images/student present.png"
                                                Width="79px" />
                                        </td>
                                        <td align="center" colspan="1">
                                            <div class="efficacious" id="efficacious" style="width:100%;">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left" >
                                                            <asp:Label ID="lblAbsentStud3" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSTD" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged" Width="100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAbsentStud5" runat="server" Text="DIV" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged" Width="100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td colspan="1" align="center">
                                            <asp:Label ID="lblTotPresentStud" runat="server" Font-Size="X-Large" Text="0"></asp:Label>
                                            <asp:Label ID="Label5" runat="server" Font-Size="X-Large" Text="/"></asp:Label>
                                            <asp:Label ID="lblTotStud" runat="server" Font-Size="X-Large" Text="0"></asp:Label>
                                        </td>
                                      
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="1">
                                            <asp:Label ID="lblAbsentStud2" runat="server" 
                                                Text="These shows number of students present today."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" 
                                            style="border-bottom-style: none; border-top-style: dotted;">
                                            <br />
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    </table>
                                    </td>
                                    </tr>
                                    
                                    <tr>
                                        <td align="center" style="border-right:1px solid">
                                        <div class="lable" style="width:50%;">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Applied Leaves Of Staff"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="center">
                                        <div class="lable" style="width:50%;">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                                                Text="Students Out Of The Class "></asp:Label>
                                               </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="border-right:1px solid">
                                            <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found." DataKeyNames="intLeaveApplocation_id"
                                                OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" PageSize="6" Width="100%"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="4" Font-Names="Verdana" Font-Size="10px" ForeColor="Black" 
                                                GridLines="Horizontal">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserId" Text='<%#Eval("intUser_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserTypeID" Text='<%#Eval("intUserType_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Dept" HeaderText="Department" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="FrmDt" HeaderText="From Date" ReadOnly="True"></asp:BoundField>
                                                    <asp:BoundField DataField="ToDt" HeaderText="To Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="intTotalDays" HeaderText="Total Days" />
                                                   
                                                    <asp:TemplateField HeaderText="Approval">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkLeaveApproved" Text='<%#Eval("status") %>' 
                                                                runat="server" onclick="lnkLeaveApproved_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle CssClass="pgr" BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                            </asp:GridView>
                                        </td>
                                        <td align="center" rowspan="1" valign="top" >
                                            
                                            <asp:GridView ID="grvStudentOutOfClass" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                CssClass="mGrid" EmptyDataText="Record not Found." Font-Names="Verdana" 
                                                Font-Overline="False" Font-Size="10px" ForeColor="Black" GridLines="Horizontal" 
                                                OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" PageSize="6" 
                                                Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Roll" HeaderText="Roll No" ReadOnly="True" />
                                                    <asp:BoundField DataField="Name" HeaderText="Student Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="STD" HeaderText="STD" ReadOnly="True" />
                                                    <asp:BoundField DataField="DIV" HeaderText="DIV" ReadOnly="True" />
                                                </Columns>
                                               
                                                <AlternatingRowStyle CssClass="alt" />
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" CssClass="pgr" ForeColor="Black" 
                                                    HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                            </asp:GridView>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" style="border-right:1px solid">
                                              <div class="lable" style="width:50%;">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Today's Attendance"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="center" valign="bottom">
                                           <div class="lable" style="width:50%;">
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Today's Staff Attendance"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="border-right:1px solid">
                                            <asp:GridView ID="grvAttendanceDetail" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" PageSize="8" Width="100%"
                                                DataKeyNames="intDivision_id" OnRowEditing="grvAttendanceDetail_RowEditing" OnRowDeleting="grvAttendanceDetail_RowDeleting"
                                                OnSelectedIndexChanged="grvAttendanceDetail_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="STD" HeaderText="STD" ReadOnly="True" />
                                                    <asp:BoundField DataField="DIV" HeaderText="DIV" ReadOnly="True" />
                                                    <asp:BoundField DataField="Present" HeaderText="Present" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Late">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkLate" runat="server" CommandName="Edit" Text='<%#Eval("Late") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Absent">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkAbsent" runat="server" CommandName="Delete" Text='<%#Eval("Absent") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                        <td align="center" valign="top">
                                            <asp:GridView ID="grvStaffAtt" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                DataKeyNames="intTeacher_id" OnPageIndexChanging="grvLeaveStatus_PageIndexChanging"
                                                PageSize="8" Width="100%" OnRowCommand="grvStaffAtt_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="UserType" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserType" Text='<%#Eval("intUserType_id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Dept" HeaderText="Department" ReadOnly="True" />
                                                    <asp:BoundField DataField="Name" HeaderText="Staff Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Monthly Attendance" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkView" CommandName="View" CommandArgument='<%#((GridViewRow) Container).RowIndex %>'
                                                                runat="server">Detail</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkCal" runat="server" CommandName="Calendar" CommandArgument='<%#((GridViewRow) Container).RowIndex %>'>Calendar</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="border-right:1px solid">
                                            <asp:Panel ID="pnlStudLateAtt" runat="server" Width="70%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" 
                                                                    Font-Names="Times New Roman" Font-Size="Small" ForeColor="White" 
                                                                    Text="Late Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="ImgBtn" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:GridView ID="grvStudLate" runat="server" AllowPaging="True" 
                                                                    AutoGenerateColumns="False" BorderStyle="Dotted" CssClass="mGrid" PageSize="5" 
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="intRollNo" HeaderText="Roll No" />
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                        <asp:BoundField DataField="Latetime" HeaderText="Late (HH:MM)" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="btnPop" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalStudLateAtt" runat="server" 
                                                BackgroundCssClass="modal" DynamicServicePath="" Enabled="True" 
                                                OkControlID="ImgBtn" PopupControlID="pnlStudLateAtt" TargetControlID="btnPop">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlStudAbsentAtt" runat="server" Width="70%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                                                                    Font-Names="Times New Roman" Font-Size="Small" ForeColor="White" 
                                                                    Text="Absent Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:GridView ID="grvStudAbsent" runat="server" AllowPaging="True" 
                                                                    AutoGenerateColumns="False" BorderStyle="Dotted" CssClass="mGrid" PageSize="5" 
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                             
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button1" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalStudAbsentAtt" runat="server" 
                                                BackgroundCssClass="modal" DynamicServicePath="" Enabled="True" 
                                                OkControlID="Image1" PopupControlID="pnlStudAbsentAtt" 
                                                TargetControlID="Button1">
                                            </asp:ModalPopupExtender>
                                        </td>
                                        <td valign="top" align="center">
                                            <asp:Panel ID="pnlCalendar" runat="server" Width="70%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" 
                                                                    Font-Names="Times New Roman" Font-Size="Small" ForeColor="White" 
                                                                    Text="Monthly Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image13" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Calendar ID="CalStaffAtt" runat="server" BackColor="#FCFBFB" 
                                                                    CellPadding="4" DayNameFormat="Full" FirstDayOfWeek="Monday" 
                                                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="10px" 
                                                                    NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender" 
                                                                    ShowGridLines="True" Width="100%" 
                                                                    onselectionchanged="CalStaffAtt_SelectionChanged">
                                                                    <DayHeaderStyle BackColor="#E2E2E2" BorderColor="#CCCCCC" Font-Bold="True" 
                                                                        Font-Size="7pt" Height="28px" />
                                                                    <DayStyle BorderColor="#CCCCCC" Height="50px" />
                                                                    <OtherMonthDayStyle ForeColor="Gray" />
                                                                    <SelectedDayStyle BackColor="#F0DCDD" BorderColor="#CCCCCC" BorderStyle="Ridge" 
                                                                        Font-Bold="True" ForeColor="Black" Height="50px" />
                                                                    <SelectorStyle BackColor="#CCCCCC" BorderStyle="Ridge" />
                                                                    <TitleStyle BackColor="#7B7B7B" BorderColor="Black" Font-Bold="True" 
                                                                        ForeColor="White" Height="28px" />
                                                                    <TodayDayStyle BackColor="#EFECEC" BorderColor="#777777" BorderStyle="Ridge" 
                                                                        BorderWidth="2px" Height="50px" />
                                                                    <WeekendDayStyle Font-Names="Verdana" Font-Size="8pt" />
                                                                </asp:Calendar>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button7" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalCalendar" runat="server" 
                                                BackgroundCssClass="modal" DynamicServicePath="" Enabled="True" 
                                                OkControlID="Image13" PopupControlID="pnlCalendar" TargetControlID="Button7">
                                            </asp:ModalPopupExtender>
                                            <br />
                                            <asp:Panel ID="pnlMonthLy" runat="server" Width="75%">
                                                <center>
                                                    <table style="background-color: White" width="70%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                                                                    Font-Names="Times New Roman" Font-Size="Small" ForeColor="White" 
                                                                    Text="Monthly Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image8" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:GridView ID="grvMonthyAtt" runat="server" AllowPaging="True" 
                                                                    AutoGenerateColumns="False" BorderStyle="Dotted" CssClass="mGrid" PageSize="5" 
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="dtDate" HeaderText="Date" />
                                                                        <asp:BoundField DataField="vchlatestatus" HeaderText="Status" />
                                                                        <asp:BoundField DataField="dtinTime" HeaderText="Time" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button2" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalStaffAtt" runat="server" 
                                                BackgroundCssClass="modal" DynamicServicePath="" Enabled="True" 
                                                OkControlID="Image8" PopupControlID="pnlMonthLy" TargetControlID="Button2">
                                            </asp:ModalPopupExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" valign="top" align="center" style="border-right:1px solid">
                                           <asp:Panel runat="server" ID="pnlLeave" Width="30%" BackColor="White">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" style="background-color: WindowText" colspan="2" width="90%">
                                                                            <asp:Label ID="lblLeaveAction" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="background-color: WindowText" width="10%">
                                                                            <asp:Image ID="Image14" runat="server" ImageUrl="~/images/cross.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" align="center">
                                                                            <table width="98%" align="center">
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <br />
                                                                                        <asp:Label ID="Label11" runat="server" Text="Action"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2" valign="top">
                                                                                        <br />
                                                                                        <asp:RadioButtonList ID="rdbAction" runat="server" RepeatDirection="Horizontal" Width="70%">
                                                                                            <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                                                                            <asp:ListItem Value="2" Text="Reject"></asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="Label18" runat="server" Text="Remark"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="txtRemark" Rows="3" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" align="center" style="padding-right: 15px">
                                                                                        <br />
                                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                                                                            onclick="btnSubmit_Click"  />
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:Button ID="btnLeave" runat="server" Style="display: none" />
                                                            <asp:ModalPopupExtender ID="ModalLeaveRemark" runat="server" TargetControlID="btnLeave"
                                                                BackgroundCssClass="modal" PopupControlID="pnlLeave" OkControlID="Image14" Enabled="True"
                                                                DynamicServicePath="">
                                                            </asp:ModalPopupExtender>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td align="center" style="border-right:1px solid">
                                        <div class="lable" style="width:50%;">
                                            <asp:Label ID="Label22" runat="server" Font-Bold="True" 
                                                Text="Events"></asp:Label>
                                        </div>
                                        </td>
                                        <td colspan="" valign="top" align="center" >
                                                                                      <div class="lable" style="width:50%;">
                                            
                                            <asp:Label ID="Label21" runat="server" Font-Bold="True" 
                                                Text="Live Lecture Details"></asp:Label>
                                            </div>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                      <td align="center" valign="top" style="border-right:1px solid">
                                          <asp:Calendar ID="CalAttendance" runat="server" CellPadding="1" 
                                              CssClass="myCalendar" DayNameFormat="Full" Font-Names="Tahoma" Height="200px" 
                                              NextMonthText="&gt;&gt;" OnDayRender="CalAttendance_DayRender" 
                                              PrevMonthText="&lt;&lt;" SelectMonthText="»" SelectWeekText="›" 
                                              Width="80%">
                                              <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                              <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                              <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2D3338" />
                                              <SelectedDayStyle CssClass="myCalendarSelector" Font-Bold="True" />
                                              <TodayDayStyle CssClass="myCalendarToday" />
                                              <SelectorStyle CssClass="myCalendarSelector" />
                                              <NextPrevStyle CssClass="myCalendarNextPrev" />
                                              <TitleStyle CssClass="myCalendarTitle" />
                                          </asp:Calendar>
                                        </td>
                                        <td colspan="1" valign="top">
                                            <asp:GridView ID="grvLectureAtt" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" 
                                                EmptyDataText="Record not Found." 
                                                OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" PageSize="8" 
                                                Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="STD" HeaderText="STD" ReadOnly="True" />
                                                    <asp:BoundField DataField="DIV" HeaderText="DIV" ReadOnly="True" />
                                                    <asp:BoundField DataField="Staff" HeaderText="Teacher Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="Lec" HeaderText="Lecture" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Time" HeaderText="Lecture Time" ReadOnly="True" />
                                                    <asp:BoundField DataField="TempStaff" HeaderText="Temporary Teacher" 
                                                        ReadOnly="True" />
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                      
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" valign="top" 
                                            style="border-color: #000000; border-width: 1px; border-style: solid none none none;">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" valign="top">
                                            <div class="lable" style="width:50%;">
                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" 
                                                    Text="Bus Travel Detail"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" valign="top">
                                            <asp:GridView ID="grvBusAtt" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" PageSize="8" Width="100%"
                                                OnRowEditing="grvBusAtt_RowEditing" OnRowDeleting="grvBusAtt_RowDeleting">
                                                <Columns>
                                                    <asp:BoundField DataField="Route" HeaderText="Route" ReadOnly="True" />
                                                    <asp:BoundField DataField="Trip" HeaderText="Trip" ReadOnly="True" />
                                                    <asp:BoundField DataField="BusName" HeaderText="Bus Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="Driver" HeaderText="Driver Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="STD" HeaderText="STD" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ATD" HeaderText="ATD" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Present">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkPresent" Text="25" CommandName="Edit" runat="server"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Absent">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkAbsent" Text="05" CommandName="Delete" runat="server"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Panel ID="pnlBusPresnt" runat="server" Width="90%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                                                    Font-Size="Small" ForeColor="White" Text="Present Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image11" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:GridView ID="grvBusPresentDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    BorderStyle="Dotted" CssClass="mGrid" PageSize="5" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="STD" HeaderText="STD" />
                                                                        <asp:BoundField DataField="DIV" HeaderText="DIV" />
                                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                                                        <asp:BoundField DataField="StudName" HeaderText="Student Name" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button5" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalBusPresnt" runat="server" BackgroundCssClass="modal"
                                                DynamicServicePath="" Enabled="True" OkControlID="Image11" PopupControlID="pnlBusPresnt"
                                                TargetControlID="Button5">
                                            </asp:ModalPopupExtender>
                                        </td>
                                        <td valign="top">
                                            <asp:Panel ID="pnlBusAbsent" runat="server" Width="90%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                                                    Font-Size="Small" ForeColor="White" Text="Absent Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image12" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:GridView ID="grvBusAbsentDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    BorderStyle="Dotted" CssClass="mGrid" PageSize="5" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="STD" HeaderText="STD" />
                                                                        <asp:BoundField DataField="DIV" HeaderText="DIV" />
                                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                                                        <asp:BoundField DataField="StudName" HeaderText="Student Name" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button6" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalBusAbsnt" runat="server" BackgroundCssClass="modal"
                                                DynamicServicePath="" Enabled="True" OkControlID="Image12" PopupControlID="pnlBusAbsent"
                                                TargetControlID="btnPop">
                                            </asp:ModalPopupExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="center">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" valign="top" align="center">
                                         <div class="lable" style="width:50%">
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" 
                                                Text="School Notification Package Detail"></asp:Label>
                                                </div>
                                        </td>
                                        <td valign="top" align="center">
                                        <div class="lable" style="width:50%">
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" 
                                                Text="Parent Notification Package Detail"></asp:Label>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:GridView ID="grvSchoolNotify" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                DataKeyNames="intPackage_id" OnPageIndexChanging="grvLeaveStatus_PageIndexChanging"
                                                PageSize="8" Width="100%" OnRowDeleting="grvSchoolNotify_RowDeleting">
                                                <Columns>
                                                    <asp:BoundField DataField="vchPackage_name" HeaderText="Package" />
                                                    <asp:BoundField DataField="dtStartDate" HeaderText="Started From" />
                                                    <asp:BoundField DataField="dtEndate" HeaderText="Exprired On" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Details">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDetail" runat="server" CommandName="Delete" ImageUrl="~/images/action_success.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                        <td valign="top">
                                            <asp:GridView ID="grvParentNotify" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                DataKeyNames="intPackage_id" OnPageIndexChanging="grvLeaveStatus_PageIndexChanging"
                                                PageSize="8" Width="100%" OnRowDeleting="grvParentNotify_RowDeleting">
                                                <Columns>
                                                    <asp:BoundField DataField="vchPackage_name" HeaderText="Package" />
                                                    <asp:BoundField DataField="dtStartDate" HeaderText="Started From" />
                                                    <asp:BoundField DataField="dtEndate" HeaderText="Exprired On" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Details">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDetail" runat="server" CommandName="Delete" ImageUrl="~/images/action_success.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Panel ID="pnlSchoolNotify" runat="server" Width="90%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" style="background-color: WindowText">
                                                                <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                                                                    Font-Names="Times New Roman" Font-Size="Small" ForeColor="White" Text="Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image9" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:GridView ID="grvSchoolNotifyDetail" runat="server" AllowPaging="True" 
                                                                    AutoGenerateColumns="False" BorderStyle="Dotted" CssClass="mGrid" PageSize="5" 
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="intNoOfPackage" HeaderText="No Of Package" />
                                                                        <asp:BoundField DataField="availablePack" HeaderText="Balance Package" />
                                                                        <asp:BoundField DataField="TotSMS" HeaderText="No Of SMS" />
                                                                        <asp:BoundField DataField="BalSMS" HeaderText="Balance SMS" />
                                                                        <asp:BoundField DataField="TotEmail" HeaderText="No Of Email" />
                                                                        <asp:BoundField DataField="BalEmail" HeaderText="Balance Email" />
                                                                        <asp:BoundField DataField="fltDataSpace" HeaderText="Data" />
                                                                        <asp:BoundField DataField="flatAmount" HeaderText="Package Amount" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button3" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalSchool" runat="server" 
                                                BackgroundCssClass="modal" DynamicServicePath="" Enabled="True" 
                                                OkControlID="Image9" PopupControlID="pnlSchoolNotify" TargetControlID="Button3">
                                            </asp:ModalPopupExtender>
                                        </td>
                                        <td valign="top">
                                            <asp:Panel ID="pnlParentNotify" runat="server" Width="100%">
                                                <center>
                                                    <table style="background-color: White" width="100%">
                                                        <tr>
                                                            <td align="center" colspan="3" style="background-color: WindowText">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                                                                    Font-Names="Times New Roman" Font-Size="Small" ForeColor="White" Text="Details"></asp:Label>
                                                            </td>
                                                            <td align="right" style="background-color: WindowText">
                                                                <asp:Image ID="Image10" runat="server" ImageUrl="~/images/cross.png" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <table border="1" width="50%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblPackageSTD" runat="server" CssClass="textsize" 
                                                                                Font-Bold="True" Text="STD"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlPSTD" runat="server" AutoPostBack="True" 
                                                                                CssClass="textsize" OnSelectedIndexChanged="ddlPSTD_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblPackageIDV" runat="server" CssClass="textsize" 
                                                                                Font-Bold="True" Text="DIV"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlPDIV" runat="server" AutoPostBack="True" 
                                                                                CssClass="textsize" OnSelectedIndexChanged="ddlPDIV_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:GridView ID="grvParentNotifyDetail" runat="server" AllowPaging="True" 
                                                                    AutoGenerateColumns="False" BorderStyle="Dotted" CssClass="mGrid" 
                                                                    OnPageIndexChanging="grvParentNotifyDetail_PageIndexChanging" PageSize="5" 
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="STD" HeaderText="STD" />
                                                                        <asp:BoundField DataField="DIV" HeaderText="DIV" />
                                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                                                        <asp:BoundField DataField="Pname" HeaderText="Parent Name" />
                                                                        <asp:BoundField DataField="intNoOfSMS" HeaderText="No Of SMS" />
                                                                        <asp:BoundField DataField="BalSMS" HeaderText="Balance SMS" />
                                                                        <asp:BoundField DataField="intNoOfEmails" HeaderText="No Of Email" />
                                                                        <asp:BoundField DataField="BalEmail" HeaderText="Balance Email" />
                                                                        <asp:BoundField DataField="flatAmount" HeaderText="Price" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                            <asp:Button ID="Button4" runat="server" Style="display: none" />
                                            <asp:ModalPopupExtender ID="ModalPopupExtender5" runat="server" 
                                                BackgroundCssClass="modal" DynamicServicePath="" Enabled="True" 
                                                OkControlID="Image10" PopupControlID="pnlParentNotify" 
                                                TargetControlID="Button4">
                                            </asp:ModalPopupExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                         <table width="100%">
                                          <tr>
                                        <td align="center">
                                            <div class="lable">
                                                <asp:Label ID="Label13" runat="server" Text="Messaging"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="efficacious">
                                                <table width="100%" align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label19" runat="server" Text="Department"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label23" runat="server" Text="Staff Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" valign="top">
                                                            <asp:Label ID="Label24" runat="server" Text="Message"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="8" Height="40px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSend" CssClass="efficacious_send" runat="server" Text="Send" Width="80px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                         </table>
                                         
                                         </td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                        </div>
                        </center>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

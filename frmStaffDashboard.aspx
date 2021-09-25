<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmStaffDashboard.aspx.cs" Inherits="frmStudentDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 420px;
        }
        .style3
        {
            width: 304px;
        }
        .style4
        {
            width: 348px;
        }
        .style5
        {
            width: 194px;
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
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
        
        .container-outer
        {
            overflow: auto;
            position: relative;
            width: 900px;
            height: 500px;
        }
        
        .floating_label
        {
            position: absolute;
            z-index: 200;
            top: 50px;
            left: 50px;
        }
    </style>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
      google.load("visualization", "1", {packages:["corechart"]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = google.visualization.arrayToDataTable([
         
        ]);

        var options = {
          title: 'Indian Language Use',
          legend: 'none',
          pieSliceText: 'label',
          slices: {  4: {offset: 0.2},
                    12: {offset: 0.3},
                    14: {offset: 0.4},
                    15: {offset: 0.5},
          },
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));
        chart.draw(data, options);
      }
      window.onload = function(){setInterval( function callUserDetail()
      {
          $.ajax({
                    type: "POST",
                    url: "frmStaffDashboard.aspx/Notification",
                    data: '{UserType: "' + $("#<%=HFUserType.ClientID%>")[0].value + '",Id: "' + $("#<%=HFUserId.ClientID%>")[0].value + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,                
                    failure: function(response) {
                        alert(response.d);
                    }
                });
             

        },1000);


         
        }
        
             function OnSuccess(response) {
            if (response.d!= 'false') {
//               document.getElementById("lblMsgCount").innerText=response.d.toString();
                if(response.d>0)
                {
               $('#<%= lblMsgCount.ClientID%>').html(response.d.toString())
               }
            }
            }
             function DivScroll(){
           //  var element = document.getElementById("dvScroll");
                 $("#pannel").scrollTop() = document.getElementById("dvScroll").scrollHeight;
                  }
            window.onload=DivScroll();
            
    </script>
    <script type="text/javascript">
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            xPos = $get('dvScroll').scrollLeft;
            yPos = $get('dvScroll').scrollTop;
        }
        function EndRequestHandler(sender, args) {
            $get('dvScroll').scrollLeft = xPos;
            $get('dvScroll').scrollTop = yPos;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table width="100%">
                <tr>
                    <td align="center">
                        <input type="hidden" id="div_position" name="div_position" />
                        <div>
                            <table width="50%">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="Year" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" CssClass="textsize"
                                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Month" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" CssClass="textsize"
                                            OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sept</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
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
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- <div id="dvScroll" class="container-outer" runat="server">--%>
                        <table width="100%">
                            <tr>
                                <td colspan="2" align="center">
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:HiddenField ID="HFUserType" runat="server" />
                                </td>
                                <td>
                                    <asp:HiddenField ID="HFUserId" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style1" colspan="2">
                                    <asp:Chart ID="ChrtSchoolAtt" runat="server" ViewStateContent="Default, Data" Height="400px"
                                        Width="600px">
                                        <Series>
                                            <asp:Series Name="Present " ChartType="Pie" ChartArea="ChartArea" Legend="Present">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea">
                                                <Area3DStyle Enable3D="True" Inclination="35" IsClustered="True" WallWidth="10" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Name="Present">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title Docking="Bottom" Font="Times New Roman, 11.25pt" Name="Title1" Text="School Attendance">
                                            </asp:Title>
                                        </Titles>
                                        <BorderSkin BackColor="DarkSeaGreen" BorderColor="LightGreen" SkinStyle="FrameThin5"
                                            BackImageTransparentColor="128, 255, 128" />
                                    </asp:Chart>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            <br />
                                                <asp:Label ID="Label3" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                                                    Text="Holidays"></asp:Label>
                                                &nbsp;<asp:ImageButton ID="ImgHoliday" runat="server" ImageUrl="~/images/button-calendar.gif"
                                                    OnClick="ImgHoliday_Click" ToolTip="View Calendar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grvHoliday" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                    OnPageIndexChanging="grvAttendance_PageIndexChanging" PageSize="5" Width="100%">
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:Label ID="Label4" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                                                    Text="Vacations"></asp:Label>
                                                &nbsp;<asp:ImageButton ID="ImgVacation" runat="server" ImageUrl="~/images/button-calendar.gif"
                                                    ToolTip="View Calendar" PostBackUrl="~/frmVacationMst.aspx" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grvVacation" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                    OnPageIndexChanging="grvVacation_PageIndexChanging" PageSize="5" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="vchVacation_name" HeaderText="Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FromDt" HeaderText="From Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ToDt" HeaderText="To Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="intNoOfDay" HeaderText="Total Days" />
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                       
                                    </table>
                                    <br />
                                </td>
                                <td valign="top">
                                    <br />
                                    <table width="100%">
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:Label ID="Label5" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                                                    Text="Leave Status"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:LinkButton ID="lnkApply" runat="server" Font-Underline="True" Font-Bold="True"
                                                    Font-Italic="True" PostBackUrl="~/frmTeacherLeaveMenu.aspx">Apply Leave</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="center" style="height:155px"  colspan="2">
                                                <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                    OnPageIndexChanging="grvLeaveStatus_PageIndexChanging" Width="80%" PageSize="8">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Leave Type" DataField="Type" />
                                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                                        <asp:BoundField HeaderText="Admin Approval" DataField="AdminApproval"></asp:BoundField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right"  colspan="2" valign="top">
                                                <br />
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="50%">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label13" runat="server" CssClass="textsize" Text="Year" 
                                                                            Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlYear2" runat="server" AutoPostBack="True" 
                                                                            CssClass="textsize" Visible="False">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="2">
                                                                        <asp:Label ID="Label14" runat="server" Font-Names="Times New Roman" 
                                                                            Font-Size="Medium" Text="Best 5 Attendance of Students"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grvTopAtt" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                Width="60%" PageSize="5">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Rank" HeaderText="Rank"></asp:BoundField>
                                                                    <asp:BoundField DataField="Name" HeaderText="Student Name"></asp:BoundField>
                                                                </Columns>
                                                                <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <table width="40%">
                                        <tr>
                                            <td align="left" class="style1">
                                                <asp:Label ID="Label6" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:DropDownList ID="ddlSTD" runat="server" CssClass="textsize">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label7" runat="server" Text="DIV" CssClass="textsize"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" class="style3">
                                                <asp:Label ID="Label8" runat="server" Text="Student Name" CssClass="textsize" Visible="False"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlStudent" runat="server" CssClass="textsize" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <table width="40%" border="1" id="Detail" runat="server">
                                        <tr>
                                            <td align="left" valign="top" class="style5">
                                                <asp:Label ID="Label9" runat="server" Text="Total Present Students" CssClass="style4"
                                                    Style="font-size: small; font-family: 'Times New Roman', Times, serif"></asp:Label>
                                            </td>
                                            <td valign="top" align="left">
                                                &nbsp;<asp:Label ID="lblPresent" runat="server" CssClass="style4" Style="font-size: small;
                                                    font-family: 'Times New Roman', Times, serif"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" class="style5">
                                                <asp:Label ID="Label10" runat="server" Text="Total Absent Students" CssClass="style4"
                                                    Style="font-size: small; font-family: 'Times New Roman', Times, serif"></asp:Label>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:LinkButton ID="lnkAbsent" runat="server" CssClass="style4" Style="font-size: small;
                                                    font-family: 'Times New Roman', Times, serif" Font-Underline="True" OnClick="lnkAbsent_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" class="style5">
                                                <asp:Label ID="Label11" runat="server" Text="Total Late Reported Students" CssClass="style4"
                                                    Style="font-size: small; font-family: 'Times New Roman', Times, serif"></asp:Label>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:LinkButton ID="lnkLate" runat="server" CssClass="style4" Style="font-size: small;
                                                    font-family: 'Times New Roman', Times, serif" Font-Underline="True" OnClick="lnkLate_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" class="style5">
                                                <asp:Label ID="Label12" runat="server" Text="Pending Leave Approvals" CssClass="style4"
                                                    Style="font-size: small; font-family: 'Times New Roman', Times, serif"></asp:Label>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:LinkButton ID="LnkPending" runat="server" CssClass="style4" Style="font-size: small;
                                                    font-family: 'Times New Roman', Times, serif" Font-Underline="True" OnClick="LnkPending_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" class="style5">
                                                &nbsp;
                                                <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" />
                                            </td>
                                            <td align="left" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Panel ID="pnlPopUp" Width="60%" runat="server">
                                        <center>
                                            <table width="70%" style="background-color: White">
                                                <tr>
                                                    <td align="center" style="background-color: WindowText">
                                                        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="White" Font-Names="Times New Roman"
                                                            Font-Size="Small"></asp:Label>
                                                    </td>
                                                    <td align="right" style="background-color: WindowText">
                                                        <asp:Image ID="ImgBtn" runat="server" ImageUrl="~/images/cross.png" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:GridView ID="grvStatus" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" AllowPaging="True" BorderStyle="Dotted" OnPageIndexChanging="grvStatus_PageIndexChanging"
                                                            PageSize="5">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Roll No" DataField="RollNo" />
                                                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                                                <asp:BoundField HeaderText="Date" DataField="Date" />
                                                                <asp:BoundField HeaderText="From Date" DataField="FromDate" />
                                                                <asp:BoundField HeaderText="To Date" DataField="ToDate" />
                                                                <asp:BoundField HeaderText="Total Days" DataField="TotDt" />
                                                                <asp:BoundField DataField="Latetime" HeaderText="Late (HH:MM)" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                    </asp:Panel>
                                    <asp:Button ID="btnPop" runat="server" Style="display: none" />
                                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnPop"
                                        BackgroundCssClass="modal" PopupControlID="pnlPopUp" OkControlID="ImgBtn" Enabled="True"
                                        DynamicServicePath="">
                                    </asp:ModalPopupExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    <br />
                                    <asp:Chart ID="ChrtStudentsAttendance" runat="server" Width="900px" BackColor="GreenYellow"
                                        BackGradientStyle="DiagonalRight">
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                                <Area3DStyle Inclination="10" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Titles>
                                            <asp:Title Docking="Bottom" Font="Times New Roman, 12pt" Name="Student Attendance"
                                                Text="Student Absent Chart">
                                            </asp:Title>
                                        </Titles>
                                        <BorderSkin BackGradientStyle="LeftRight" SkinStyle="Emboss" />
                                    </asp:Chart>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Literal ID="lt" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    <asp:Chart ID="ChrtLate" runat="server" ViewStateContent="Default, Data" Height="400px"
                                        Width="600px">
                                        <Series>
                                            <asp:Series Name="Present " ChartType="Pie" ChartArea="ChartArea" Legend="Present">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea">
                                                <Area3DStyle Enable3D="True" Inclination="35" IsClustered="True" WallWidth="10" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Name="Present">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title Docking="Bottom" Font="Times New Roman, 11.25pt" Name="Title1" Text="Students Attendance">
                                            </asp:Title>
                                        </Titles>
                                        <BorderSkin BackColor="DarkSeaGreen" BorderColor="LightGreen" SkinStyle="Sunken"
                                            BackImageTransparentColor="128, 255, 128" />
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

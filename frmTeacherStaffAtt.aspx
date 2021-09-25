<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTeacherStaffAtt.aspx.cs" Inherits="frmTeacherStaffAtt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_outer
        {
            background: #FFF;
        }
        
        .mGrid th
        {
            text-align: center !important;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }
        .excel
        {
            width: 30px;
            height: 30px;
            float: left;
            left: -114px !important;
            top: 43px !important;
            position: relative;
        }
        .pdf
        {
            width: 30px;
            height: 30px;
            float: left;
            position: relative;
            top: 1px !important;
            left: -146px !important;
        }
        .mGrid
        {
            margin: 0 auto;
        }
        .table>tbody>tr>td, .table>tbody>tr>th, .table>tfoot>tr>td, .table>tfoot>tr>th, .table>thead>tr>td, .table>thead>tr>th {
        padding: 6px;
        line-height: 1.42857143;
        vertical-align: top;
        border-top: 1px solid #ddd;
        }
    </style>
    
    <style type="text/css">
    .modalPopup
    {
    background-color: #696969;
    filter: alpha(opacity=40);
    opacity: 0.7;
    xindex:-1;
    }
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Attendance Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Attendance</a></li>
            <li class="active">Teacher</li>
        </ol>
    </div>
    <div style="width: 100%">
        <table width="100%">
            <tr>
                <td width="100%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%" class="tabular">
                                <tr>
                                    <td>
                                        <div id="efficacious">
                                            <table width="90%" style="margin: 0 auto;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblType" runat="server" Text="Type" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlType" Style="width: 70%;" runat="server" AutoPostBack="True"
                                                            CssClass="textsize" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblDept" runat="server" Text="Department" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlDept" Style="width: 70%;" runat="server" AutoPostBack="True"
                                                            CssClass="textsize" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td>
                                                    <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblTeacherNm" runat="server" Text="Teacher Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" CssClass="efficacious_send">


                                                    <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                                           <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate> 
                                                        <asp:DropDownList ID="ddlTeacher" Style="width: 70%;" runat="server" AutoPostBack="True" 
                                                            CssClass="textsize" OnSelectedIndexChanged="ddlTeacher_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        </ContentTemplate>
						                            </asp:UpdatePanel>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" width="100%">
                                        <asp:TabContainer ID="TabContainer2" CssClass="MyTabStyle" runat="server" ActiveTabIndex="2"
                                            Width="1111px" Visible="true" Style="padding-top: 10px;">
                                            <asp:TabPanel runat="server" ID="Calendar">
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
                                                                        SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar" OnDayRender="CalAttendance_DayRender"
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
                                                                    <br />
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                </asp:Panel>
                                                            </td>
                                                            <td valign="top" width="80%" align="center">
                                                                <br />
                                                                <asp:Image ID="Image1" ImageUrl="~/images/LEGEND.png" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel runat="server" ID="Tabular123">
                                                <HeaderTemplate>
                                                    Tabular</HeaderTemplate>
                                                <ContentTemplate>
                                                    <center>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                    <div id="efficacious" class="efficacious" style="width: 90%;">
                                                                        <table width="30%" style="margin: 0 auto; float: right;">
                                                                            <tr>
                                                                                <td align="right" valign="top">
                                                                                    <asp:ImageButton ID="lnkPrevious" Style="position: relative; top: -3px; right: 10px;"
                                                                                        OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png" ToolTip="Previous"
                                                                                        Width="30px" />
                                                                                </td>
                                                                                <td align="center" valign="top">
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
                                                                                <td align="left" valign="top">
                                                                                    <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" Style="position: relative;
                                                                                        left: 7px; top: -2px;" runat="server" ImageUrl="~\images\next.png" ToolTip="Next"
                                                                                        Width="30px" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:GridView ID="grvAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                            Width="100%" PageSize="31">
                                                            <Columns>
                                                                <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dtinTime" HeaderText="In-Time" ReadOnly="True" Visible = "false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dtoutTime" HeaderText="Out-Time" ReadOnly="True" Visible = "false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="vchlatestatus" HeaderText="Status" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Latetime" HeaderText="Working Hrs" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <RowStyle HorizontalAlign="Left"></RowStyle>
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <PagerStyle CssClass="pgr" />
                                                        </asp:GridView>
                                                    </center>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="All" runat="server">
                                                <HeaderTemplate>
                                                    Attendance</HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <div class="efficacious" id="efficacious" style="width: 90%;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding-right: 12px;">
                                                                                <asp:Label ID="lblYear" runat="server" Style="text-align: right" Text="Year" CssClass="textsize"
                                                                                    Width="100%"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                    OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblMonth" runat="server" Style="text-align: right; margin-left: 40px;
                                                                                    padding-right: 12px;" Text="Month" CssClass="textsize"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                    OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" Width="80%">
                                                                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Style="text-align: right" Text="From Date"
                                                                                    CssClass="textsize"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFrmDate" runat="server" Width="50%" Style="position: relative;
                                                                                    top: 0px;" AutoPostBack="True" OnTextChanged="txtFrmDate_TextChanged" CssClass="input-blue"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="CalFrmDate" runat="server" TargetControlID="txtFrmDate" Format="dd/MM/yyyy"
                                                                                        Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                                <asp:TextBoxWatermarkExtender ID="txtF" runat="server" TargetControlID="txtFrmDate"
                                                                                    WatermarkText="From Date" Enabled="True">
                                                                                </asp:TextBoxWatermarkExtender>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text="To Date" Style="text-align: right" CssClass="textsize"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtToDate" runat="server" Style="position: relative; top: 0px;"
                                                                                    Width="50%" OnTextChanged="txtToDate_TextChanged" AutoPostBack="True" CssClass="input-blue"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="CalToDate" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"
                                                                                        Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtToDate"
                                                                                    WatermarkText="To Date" Enabled="True">
                                                                                </asp:TextBoxWatermarkExtender>
                                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFrmDate"
                                                                                    ControlToValidate="txtToDate" CssClass="textsize" Display="None" ErrorMessage="FromDate Should Be Less Than Or Equal To ToDate"
                                                                                    Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator><asp:ValidatorCalloutExtender
                                                                                        ID="CompareValidator2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                                        TargetControlID="CompareValidator2">
                                                                                    </asp:ValidatorCalloutExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="grdattendance" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                                    CellPadding="4" DataKeyNames="UserId" EmptyDataText="No Record Found" ForeColor="Black"
                                                                    Width="100%" OnRowDataBound="grdattendance_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                                                        <asp:TemplateField HeaderText="1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn01" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    Text='<%# Eval("01") %>' OnClick="lnkbtn_Click"></asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="2">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn02" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("02") %>'>2</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="3">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn03" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("03") %>'>3</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="4">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn04" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("04") %>'>4</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="5">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn05" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("05") %>'>5</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="6">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn06" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("06") %>'>6</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="7">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn07" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("07") %>'>7</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="8">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn08" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("08") %>'>8</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="9">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn09" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("09") %>'>9</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="10">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn10" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("10") %>'>10</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="11">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn11" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("11") %>'>11</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="12">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn12" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("12") %>'>12</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="13">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn13" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("13") %>'>13</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="14">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn14" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("14") %>'>14</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="15">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn15" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("15") %>'>15</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="16">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn16" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("16") %>'>16</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="17">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn17" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("17") %>'>17</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="18">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn18" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("18") %>'>18</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="19">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn19" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("19") %>'>19</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="20">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn20" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("20") %>'>20</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="21">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn21" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("21") %>'>22</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="22">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn22" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("22") %>'>22</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="23">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn23" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("23") %>'>23</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="24">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn24" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("24") %>'>24</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="25">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn25" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("25") %>'>25</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="26">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn26" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("26") %>'>26</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="27">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn27" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("27") %>'>27</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="28">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn28" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("28") %>'>28</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="29">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn29" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("29") %>'>29</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="30">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn30" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("30") %>'>30</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="31">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtn31" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                                                    OnClick="lnkbtn_Click" Text='<%# Eval("31") %>'>30</asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                    <RowStyle HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Button ID="btnPop" runat="server" Style="display: none" /><asp:ModalPopupExtender
                                                                    ID="ModalPopupExtender1" runat="server" TargetControlID="btnPop" PopupControlID="pnlPopUp"
                                                                    OkControlID="btnPop" DynamicServicePath="" Enabled="True">
                                                                </asp:ModalPopupExtender>
                                                                <asp:Panel ID="pnlPopUp" Width="40%" runat="server" BackColor="White" BorderWidth="1px">
                                                                    <table bgcolor="" width="100%">
                                                                        <tr align="right">
                                                                            <td valign="middle" style="background-color: Gray">
                                                                                <asp:Label ID="lbltitle" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="White"
                                                                                    Text="Change Attendance Status"></asp:Label><asp:ImageButton ID="btnOk" runat="server"
                                                                                        Height="22px" ImageUrl="~/images/cross.png" Width="25px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table bgcolor="white" width="100%">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td>
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="lblAttendanceStatus" runat="server" Text="Attendance Status" CssClass="textsize"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:DropDownList ID="drpselect" runat="server" CssClass="textsize">
                                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Present" Value="Present"></asp:ListItem>
                                                                                                <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                                                                                                <asp:ListItem Text="Late" Value="Late"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="left" class="style1">
                                                                                            &#160;&#160;<asp:Label ID="lblRemark" runat="server" CssClass="textsize" Text="Remark"></asp:Label>
                                                                                        </td>
                                                                                        <td class="style1" align="left">
                                                                                            <asp:TextBox ID="txtRemark" runat="server" CssClass="textsize" Width="150px"></asp:TextBox>&#160;&#160;
                                                                                        </td>
                                                                                        <td class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="center" class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="4">
                                                                                            &#160;&#160;<asp:Button ID="btnUpload" runat="server" OnClientClick="return Confirm();"
                                                                                                Text="Upload" OnClick="btnUpload_Click" />&#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Button ID="btnClose" runat="server" BackColor="White" ForeColor="White" BorderStyle="None" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="Summery" runat="server">
                                                <HeaderTemplate>
                                                    Summary</HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div class="efficacious" id="efficacious">
                                                                    <table width="30%">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label2" runat="server" Style="text-align: right;" CssClass="textsize"
                                                                                    Text="Year"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlYear1" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                    OnSelectedIndexChanged="ddlYear1_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:GridView ID="grvSummery" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                                    Width="100%" PageSize="12">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Present" HeaderText="Present" ReadOnly="True"></asp:BoundField>
                                                                        <asp:BoundField DataField="Late" HeaderText="Late" ReadOnly="True" Visible = "false">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Absent" HeaderText="Absent"></asp:BoundField>
                                                                        <asp:BoundField DataField="Leave" HeaderText="Leave"></asp:BoundField>
                                                                        <asp:BoundField DataField="TotAtt" HeaderText="Total Attendance" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="TotDays" HeaderText="Total Days" ReadOnly="True" Visible = "false">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </td>
                                    <%--<td align="right" width="100%" valign="top">
                                        <div class="pdf">
                                            <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" ImageUrl="~/images/pdfImg.gif"
                                                runat="server" OnClick="ImgPdf_Click" />
                                        </div>
                                    </td>--%>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td align="right" width="100%" valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="excel">
                                    <asp:ImageButton ID="ImgXls" Style="padding-top: 8px" CssClass="export" ToolTip="Export in Excel"
                                        ImageUrl="~/images/xlsImg.gif" runat="server" OnClick="ImgXls_Click" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <%--<td align="center" width="100%" valign="top" colspan="2">
                                <div class="word">
                                    <asp:ImageButton Style="padding-top: 12px" ID="ImgDoc" ToolTip="Export in DOC" CssClass="export"
                                        ImageUrl="~/images/docImg.gif" runat="server" OnClick="ImgDoc_Click" />
                                </div>
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>


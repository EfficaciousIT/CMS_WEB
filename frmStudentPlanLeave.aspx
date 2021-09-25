<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-gb" CodeFile="frmStudentPlanLeave.aspx.cs" Inherits="frmStudentPlanLeave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
          .modal
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        .lable
        {
            width: 70%; /*margin-top: 11px;*/
            height: auto;
            padding: 5px;
            background: #3498db;
            text-align: center;
            color: #fff;
            font-family: Times New Roman;
            font-size: Medium;
            font-size: 15px;
            float: center;
        }
        
        .Calendar
        {
            border-left: 2px solid White !important;
            border-right: 2px solid White !important;
            border-bottom: 2px solid White !important;
            background-color: #f2f2f2;
            -webkit-box-shadow: 0 0 30px 2px black;
            border-top-style: none !important;
            border-top-color: inherit !important;
            border-top-width: 0px !important;
        }
        .Calendar a
        {
            text-decoration: none;
            color: White;
            width: 18px;
        }
        .mGrid th{text-align: center !important;}
        .Calendar .myCalendarTitle
        {
            font-weight: bold;
            font-size: x-large;
            height: 30px;
            line-height: 15px;
            background-color: #3498db;
            color: #ffffff;
        }
        .Calendar th.myCalendarDayHeader
        {
            height: 10px;
            width: 10px;
            font-weight: normal;
            font-size: xx-small;
            color: Black;
            background-color: #ADA9A9;
            border-bottom: outset 1px #fbfbfb;
            border-right: outset 1px #fbfbfb;
        }
        .Calendar td.myCalendarDay
        {
            border: outset 2px #fbfbfb;
        }
        .Calendar td.myCalendarDay:nth-child(7) a
        {
            color: White !important;
            height: 7px;
            width: 5px;
        }
        .Calendar .myCalendarNextPrev
        {
            text-align: left;
            font-size: 10px;
        }
        .Calendar .myCalendarNextPrev a
        {
            font-size: 10px;
        }
        .Calendar .myCalendarNextPrev:nth-child(1) a
        {
            color: black !important;
            background: url("prevMonth.png") no-repeat center center;
        }
        .Calendar .myCalendarNextPrev:nth-child(1) a:hover, .myCalendar .myCalendarNextPrev:nth-child(3) a:hover
        {
            background-color: transparent;
        }
        .Calendar .myCalendarNextPrev:nth-child(3) a
        {
            color: black !important;
            background: url("nextMonth.png") no-repeat center center;
        }
        .Calendar td.myCalendarSelector a
        {
            background-color: #E6C520;
        }
        .Calendar .myCalendarDayHeader a, .myCalendar .myCalendarDay a, .myCalendar .myCalendarSelector a, .myCalendar .myCalendarNextPrev a
        {
            display: inline-block;
            line-height: 10px;
            width: 8px;
            font-size: 10px;
        }
        .Calendar .myCalendarToday
        {
            background-color: #3498db;
            -webkit-box-shadow: 0 0 7px 3px black;
            box-shadow: 0 0 7px 3px black;
        }
        .Calendar .myCalendarToday a
        {
            color: white !important;
            font-size: medium;
        }
        .Calendar .myCalendarDay a:hover, .myCalendar .myCalendarSelector a:hover
        {
            background-color: #DADFDA;
        }
        .efficacious span{ text-align:center;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" align="center">
                    <tr>
                        <td align="center">
                            <div class="lable">
                                <asp:Label ID="Label13" runat="server" Text="Holiday Details"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div class="lable" id="divVacation" runat="server">
                                <asp:Label ID="Label14" runat="server" Text="Vacation Details"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" valign="top" align="center" rowspan="2">
                            <asp:Panel ID="panel1" runat="server">
                                <br />
                                <asp:Calendar ID="CalHoliday" runat="server" CssClass="fc-body CalAttendance" DayNameFormat="Full"
                                    Font-Names="Tahoma" Height="200px" NextMonthText="&gt;&gt;" OnDayRender="Calendar1_DayRender"
                                    OnSelectionChanged="CalHoliday_SelectionChanged" OnVisibleMonthChanged="CalHoliday_VisibleMonthChanged"
                                    PrevMonthText="&lt;&lt;" SelectMonthText="»" SelectWeekText="›">                                    
                                </asp:Calendar>
                                <br />
                                <br />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </asp:Panel>
                        </td>
                        <td  valign="top" style="height: 45px;" align="center">
                            <div class="efficacious" id="Div1">
                                <table width="30%">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
                                                ToolTip="Previous" Width="30px" CausesValidation="False" />
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="ddlMonth" runat="server" Font-Names="Verdana" Font-Size="8pt" style=" margin-top:3px;"
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
                                        <td align="left" valign="top">
                                            <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" runat="server" ImageUrl="~\images\next.png"
                                                ToolTip="Next" Width="30px" CausesValidation="False" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="50%">
                            <asp:GridView ID="grvVacation" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="intVacation_id" EmptyDataText="No Records Found For Selected Month."
                                HeaderStyle-Width="5px" PageSize="6" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblid" runat="server" Text='  <%# Eval("intVacation_id")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                                                ImageUrl="~/images/delete.png" OnClientClick="return ConfirmDelete();" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="FilePath" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPath" runat="server" Text='  <%# Eval("vchDocPath")  %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Document">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgView" runat="server" CausesValidation="false"  CommandArgument='<%#Bind("vchDocPath") %>'
                                                                                  ImageUrl="~/images/action_success.png" CommandName="Detail"
                                                                              /></ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="TypeOfVacation" HeaderText="Vacation Type" ReadOnly="True" />
                                    <asp:BoundField DataField="vchVacation_name" HeaderText="Name" ReadOnly="True" />
                                    <asp:BoundField DataField="dtFromDate" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="dtToDate" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="intNoOfDay" HeaderText="No Of Days" ReadOnly="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="width: 100%" valign="top" width="50%">
                            <div class="efficacious" id="efficacious">
                                <table width="80%">
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtFrmDt" runat="server" CssClass="textsize" AutoComplete="Off"
                                                AutoPostBack="True" OnTextChanged="txtFrmDt_TextChanged"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" PopupPosition="BottomLeft" runat="server"
                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFrmDt">
                                            </asp:CalendarExtender>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtFrmDt" WatermarkText="From Date">
                                            </asp:TextBoxWatermarkExtender>
                                            <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="txtToDate">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter From Date"
                                                Display="None" ControlToValidate="txtFrmDt" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtToDate" Width="200px" runat="server" AutoComplete="Off" CssClass="textsize"
                                                AutoPostBack="True" OnTextChanged="txtToDate_TextChanged"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtToDate" CssClass="textsize"
                                                    Display="None" ErrorMessage="Please Enter To Date"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator12">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFrmDt"
                                                ControlToValidate="txtToDate" CssClass="textsize" Display="None" ErrorMessage="FromDate Should Be Less Than Or Equal To ToDate"
                                                Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator><asp:ValidatorCalloutExtender
                                                    ID="CompareValidator2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                    TargetControlID="CompareValidator2">
                                                </asp:ValidatorCalloutExtender>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtToDate" WatermarkText="To Date">
                                            </asp:TextBoxWatermarkExtender>
                                        </td>
                                        <td valign="top">
                                            <asp:Button ID="btnSubmit" Style="width: 174%; text-align: center; background: #3498db;
                                                color: white;" runat="server" Text="Check" OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="grvDetail" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No Records Found For Selected Month. Please Check All CheckBox To View All Vacationss"
                                HeaderStyle-Width="5px" PageSize="6" Width="100%">
                                <Columns>
                                    
                                   
                                    <asp:BoundField DataField="FrmDate" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="Tot" HeaderText="No Of Days" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="No Of Lecture">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkNoOfLec" Text=' <%# Eval("cnt")  %>' runat="server" 
                                                onclick="lnkNoOfLec_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Width="5px" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                     <asp:Panel ID="pnlStudLateAtt" Width="80%" runat="server">
                                                                <center>
                                                                    <table width="100%" style="background-color: White">
                                                                        <tr>
                                                                            <td align="center" style="background-color: WindowText">
                                                                                <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="White" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                            <td align="right" style="background-color: WindowText">
                                                                                <asp:Image ID="ImgBtn" runat="server" ImageUrl="~/images/cross.png" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <asp:GridView ID="grvLecDetail" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                                                                                    Width="90%" AllowPaging="True" BorderStyle="Dotted" PageSize="5">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                                        <asp:BoundField DataField="Day" HeaderText="Day" />
                                                                                        
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
                                                            <asp:Button ID="btnPop" runat="server" Style="display: none" />
                                                            <asp:ModalPopupExtender ID="ModalStudLateAtt" runat="server" TargetControlID="btnPop"
                                                                BackgroundCssClass="modal" PopupControlID="pnlStudLateAtt" OkControlID="ImgBtn"
                                                                Enabled="True" DynamicServicePath="">
                                                            </asp:ModalPopupExtender>
                    </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

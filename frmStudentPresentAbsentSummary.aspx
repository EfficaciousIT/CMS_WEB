<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    EnableEventValidation="false" Culture="en-GB" Title="Student Attendance Report"
    CodeFile="frmStudentPresentAbsentSummary.aspx.cs" Inherits="frmStudentPresentAbsentSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function ChangeStatus() {
            <%-- var value = document.getElementById('<%=drpselect.ClientID %>').value;--%>
           <%-- var txt = document.getElementById('<%=txtTime.ClientID %>');
            var lbl = document.getElementById('<%=lblTime.ClientID %>');--%>
            if (value == 'Late') {
                txt.style.visibility = 'visible';
                lbl.style.visibility = 'visible';
            }
            else {
                txt.style.visibility = 'hidden';
                lbl.style.visibility = 'hidden';
            }
        }

        <%--function Confirm() {
            var txt = document.getElementById('<%=txtTime.ClientID %>');
            if (txt.style.visibility == 'visible') {
                if (txt.value == '') {
                    alert('Please enter Late Time');
                    return false;
                }
            }--%>


        <%--  var update = confirm('Do You Really Want To Update Current Status ?');

            if (update) {
                return true;
            }
            else {
                return false;
            }
        }

        function UpdateStatus() {
            var value = document.getElementById('<%=drpselect.ClientID %>').value;
            var txt = document.getElementById('<%=txtTime.ClientID %>');
            if (txt.visible == true) {
                alert('Please enter Late Time');
                return false;
            }
            return true;
        }--%>
    </script>
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
        .efficacious input, form.winner-inside textarea {
            margin-bottom: 10PX;
        }

        .excel {
            width: 30px;
            height: 30px;
            float: left;
            left: -114px !important;
            top: 50px !important;
            position: relative;
        }

        .word {
            top: 18px !important;
        }

        .pdf {
            width: 30px;
            height: 30px;
            float: left;
            position: relative;
            top: 9px !important;
            left: -146px !important;
        }

        .mGrid th {
            text-align: center !important;
        }

        .ajax__tab_default .ajax__tab_tab {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }

        .MyTabStyle .ajax__tab_body {
            /* font-family: Verdana; */
            /* font-size: 10pt; */
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #d7d7d7;
            margin-top: -1px;
        }

        .style1 input, form.winner-inside textarea, select {
            display: block;
            border: 1px solid #3498db;
            /* width: 100%; */
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .table > thead > tr > th {
            padding: 5px;
            line-height: 1.42857143;
            vertical-align: top;
            border-top: 1px solid #ddd;
        }

        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
            padding: 6px;
            line-height: 1.42857143;
            vertical-align: top;
            border-top: 1px solid #ddd;
        }
    </style>

    <style type="text/css">
        .modalPopup {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix">
    </div>
    <div class="content-header pd-0">
        <ul class="top_nav1 sp">
            <li><a>Attendance <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmTeacherAttendance.aspx">Teacher Attendance</a></li>
            <li><a href="frmStaffAttendance.aspx">Staff Attendance</a></li>
            <li class="active1"><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
            <li><a href="frmAttendanceMarkAdmin.aspx">Admin Attendance Mark</a></li>
            <li><a href="frmAttendanceMarkTeacher.aspx">Teacher Attendance Mark</a></li>
            <li><a href="frmAttendanceMarkStaff.aspx">Staff Attendance Mark</a></li>
            <li><a href="frmAttendanceMark.aspx">Student Attendance Mark</a></li>
        </ul>
    </div>
    <section class="content">
    <div style="width: 100%">
        <table width="100%">
            <tr>
                <td width="100%">
                    <asp:UpdatePanel runat="server" ID="Up">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="left" valign="top">
                                        <div class="tabular">
                                            <table width="100%">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 0px" valign="middle">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" CssClass="textsize" AutoPostBack="true" 
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblDIV" runat="server" Text="DIV" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize" AutoPostBack="true" 
                                                            OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td>
                                                    <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="bottom" CssClass="efficacious_send">
                                                     <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                                           <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                        <asp:DropDownList ID="ddlStudent" runat="server" CssClass="textsize" 
                                                            OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
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
                                    <td align="left" colspan="6" width="100%">
                                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                            Width="1110px" Visible="true" AutoPostBack="True">
                                            <asp:TabPanel ID='AllSummery' runat="server">
                                                <HeaderTemplate>
                                                    Monthly</HeaderTemplate>
                                                <ContentTemplate>
                                                    <center>
                                                        <br />
                                                        <br />
                                                        <center>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="70%">
                                                                    <tr valign="top">
                                                                        <td align="left" style="padding-left: 20px;">
                                                    <asp:Label ID="Label1" runat="server" Text="Type"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:DropDownList ID="ddlFilter" runat="server" class="form-control searchable" AutoPostBack="True" 
                                                     onselectedindexchanged="ddlFilter_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Absent" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Present" Value="2"></asp:ListItem>
                                                   </asp:DropDownList>
                                                </td>  
                                                                        <td align="left" style="padding-left: 20px;" colspan="3">
                                                    <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="True" CssClass="selectf" Font-Names="Verdana" ForeColor="Black" Style="padding-right: 30px;"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CaltxtFromDate" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <asp:Label ID="Label3" runat="server" Text="To Date" Style="padding-right: 30px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="selectf" Font-Names="Verdana"
                                                        ForeColor="Black" OnTextChanged="txtDate_TextChanged" AutoPostBack="True" Style="padding-right: 30px;"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="txtDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                                                   
                          <%--  <td>
                                
                                   <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" ImageUrl="~/images/docImg.gif"
                                        runat="server" OnClick="ImgDoc_Click" />
                             
                            </td>--%>
                       
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="left">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <asp:GridView ID="grdAbsent" runat="server" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                                Width="100%" PageSize="30"  OnSelectedIndexChanged="grdAbsent_SelectedIndexChanged">
                                                                <Columns>
                                                                      <asp:BoundField DataField="intstudent_id" HeaderText="Student ID" />
                                                                    <%--  <asp:BoundField DataField="Name" HeaderText="Student ID" />--%>
                                                                    <asp:BoundField DataField="vchStudentName" HeaderText="Student Name" />
                                                                    <asp:BoundField DataField="Att_Status" HeaderText="PRESENT ABSENT COUNT" />

                                                                  <%--  <asp:BoundField DataField="ABSENT_STUD" HeaderText="Absent" ReadOnly="True"></asp:BoundField>--%>
                                                                   <%-- <asp:BoundField DataField="Late" HeaderText="Late" ReadOnly="True" Visible="False">--%>
                                                                       <%-- <HeaderStyle HorizontalAlign="Center" Width="120px" />--%>
                                                                  <%--  </asp:BoundField>--%>
                                                                    <%--<asp:BoundField DataField="Absent" HeaderText="Absent"></asp:BoundField>--%>
                                                                    <%--<asp:BoundField DataField="Leave" HeaderText="Leave"></asp:BoundField>--%>
                                                                   <%-- <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True">--%>
                                                                        <%--<HeaderStyle HorizontalAlign="Center" />--%>
                                                                      <%--  <ItemStyle HorizontalAlign="Left" />--%>
                                                                 <%--   </asp:BoundField>--%>
                                                                    <asp:BoundField DataField="TotDays" HeaderText="Total Days" ReadOnly="True" Visible="False">
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
                                    <td align="right" width="100%" valign="top">
                                        <%--<div class="pdf">
                                            <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" ImageUrl="~/images/pdfImg.gif"
                                                runat="server" OnClick="ImgPdf_Click" style="margin-top:-18px;" />
                                        </div>--%>
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
                                <%--<div class="excel">
                                    <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" ImageUrl="~/images/xlsImg.gif"
                                        runat="server" OnClick="ImgXls_Click" />
                                </div>--%>
                            </td>
                        </tr>
                        <tr>
                            <%--<td align="center" width="100%" valign="top" colspan="2">
                                <div class="word">
                                    <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" ImageUrl="~/images/docImg.gif"
                                        runat="server" OnClick="ImgDoc_Click" />
                                </div>
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</section>
</asp:Content>

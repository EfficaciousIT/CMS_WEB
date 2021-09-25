<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAbsentSummary.aspx.cs" Inherits="frmAbsentSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-family: Verdana;
        }

            .style1 select
            {
                display: block;
                border: 1px solid #3498db;
                width: 100%;
                padding: 5px;
                height: auto !important;
                -webkit-border-radius: 7px;
                -moz-border-radius: 7px;
                border-radius: 0px;
                padding: 6px 0px;
                font-size: 13px;
                text-align: left;
                margin-top: 10px;
                margin-right: 30px;
            }

        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }

        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }

        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }

        .search
        {
            border: 1px solid #078DB9 !important;
            padding: 3px;
        }

        .efficacious_Submit
        {
            border: none;
            width: 130% !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
        }

        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }

        .td, th
        {
            padding: 0;
            padding-right: 300px;
        }
        .style1 input[type=text] {
            display: block;
            border: 1px solid #3498db;
            width: 70%;
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header1 pd-0">
       
        <ul class="top_navlg rpt_center">
        <li><a >Report Center <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>     
       
            <li> <a href="frmAdmListStudentDetails.aspx"> Student Details </a></li>
            
                  <li><a href="frmStandardWiseRpt.aspx"> Student Fee Collection</a></li>
                  <li><a href="frmRPTFeecollectionInDate.aspx">Date Wise Collection</a></li>   
                  <li><a href="frmHeadwiseFeeRpt.aspx"> Head Wise Collection</a></li>
                  <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
                  <li><a href="frpRptStdWise.aspx"> Standard wise Fee Collection</a></li>
                  <li><a href="frmFeePaidTillDate.aspx"> Fee Collection Till Summary</a></li>
                  <li class="active1"><a href="frmAbsentSummary.aspx"> Student Attendance Summary</a></li>
                  <li><a href="frmAttendanceSummary.aspx"> Staff Attendance Summary</a></li>                  
                  <li><a href="frmGenderwiseAttendence.aspx"> Gender Wise Abscent Summary</a></li>
                  <li><a href="frmTopScoresStudent.aspx"> Top 10 Scores Student</a></li>
                    <li><a href="TeacherWiseTimeTable.aspx"> Teacher Wise Time Table</a></li>                  
                      <li><a href="StudentWiseTimeTable.aspx"> Student Wise Time Table </a></li>                  
        </ul>
    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                                Width="850px" Visible="false">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>Mark Attendance</HeaderTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"
                                    Visible="False">
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <table class="style1">
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <table width="100%" style="padding-right: 30px;">
                                            <tr>   
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
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:GridView ID="grdAbsent" runat="server" AutoGenerateColumns="False"
                                            CssClass="table  tabular-table " EmptyDataText="No Fee Paid Yet" Width="100%" OnRowDataBound="grdAbsent_RowDataBound" >
                                            <Columns>                                                
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>                                                        
                                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                              
                                                <asp:TemplateField HeaderText="Count">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkAbsent" runat="server" CommandName="Delete" Text='<%#Eval("Count") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>


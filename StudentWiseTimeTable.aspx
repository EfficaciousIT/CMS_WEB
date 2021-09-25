<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="StudentWiseTimeTable.aspx.cs" Inherits="StudentWiseTimeTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script runat="server">

</script>
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
        .style1 input[type=text]
        {
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
                  <li><a href="frmAbsentSummary.aspx"> Student Attendance Summary</a></li>
                  <li><a href="frmAttendanceSummary.aspx"> Staff Attendance Summary</a></li>                  
                  <li><a href="frmGenderwiseAttendence.aspx"> Gender Wise Abscent Summary</a></li>
                  <li><a href="frmTopScoresStudent.aspx"> Top 10 Scores Student</a></li>
                    <li><a href="TeacherWiseTimeTable.aspx"> Teacher Wise Time Table</a></li>                  
                      <li class="active1"><a href="StudentWiseTimeTable.aspx"> Student Wise Time Table </a></li>                  
        </ul>

    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px" Visible="false">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Standard WISE TIME TABLE</HeaderTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Visible="False">
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <table class="style1">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" style="padding-right: 30px;">
                                           <%-- <tr>
                                                <td valign="middle" align="center" style="width: 12%">
                                                    <asp:Label ID="lblTEACHER" runat="server" Text="TEACHER" CssClass="textsize" Style="padding-left: 20px;"></asp:Label>
                                                </td>
                                                <td style="width: 27%">
                                                    <asp:DropDownList ID="ddlTEACHER" runat="server" AutoPostBack="True" Style="padding-right: 30px;"
                                                        CssClass="textsize" OnSelectedIndexChanged="ddlTEACHER_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td valign="middle" align="center" style="width: 12%">
                                                    <asp:Label ID="lblSTD" runat="server" Text="STANDARD" CssClass="textsize" Style="padding-left: 20px;"></asp:Label>
                                                </td>
                                                <td style="width: 27%">
                                                    <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" Style="padding-right: 30px;"
                                                        CssClass="textsize" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="width: 12%">
                                                    <asp:Label ID="lblDIV" runat="server" Text="DIVISION" CssClass="textsize" Style="padding-left: 20px;"></asp:Label>
                                                </td>
                                                <td style="width: 27%">
                                                    <asp:DropDownList ID="ddlDIV" runat="server" AutoPostBack="True" Style="padding-right: 30px;"
                                                        CssClass="textsize" OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:GridView ID="grdTeach" runat="server" AutoGenerateColumns="true" CssClass="table  tabular-table "
                                            EmptyDataText="No Data Found" Width="100%" OnRowDataBound="grdTeach_RowDataBound">
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
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnExcel" CssClass="efficacious_send" runat="server" Text="EXPORT"
                                                    OnClick="btnExcel_Click" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnExcel" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStandardWiseRpt.aspx.cs" Inherits="frmStandardWiseRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious textarea
        {
            width: 97% !important;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .efficacious input[type=checkbox] + label {
            display: block;
            /* width: auto !important; */
            /* height: auto !important; */
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            /* background: white !important; */
            vertical-align: middle;
            line-height: 1em;
            /* font-size: 14px; */
            /* color: #000; */
            padding: 1px 0px;
            text-align: center;
            width: 30px;
            /* height: 50px; */
            margin-top: 3px;
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
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header1 pd-0">
       
        <ul class="top_navlg rpt_center">
        <li><a >Report Center <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>     
       
            <li> <a href="frmAdmListStudentDetails.aspx"> Student Details </a></li>
            
                  <li class="active1"><a href="frmStandardWiseRpt.aspx"> Student Fee Collection</a></li>
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
                      <li><a href="StudentWiseTimeTable.aspx"> Student Wise Time Table </a></li>                  
        </ul>
    </div>
<section class="content">
    <div style="padding: 10px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                    PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="70%">
                                                                    <tr>
                                                                    <td align="center">                                                                          
                                                                            <asp:Label ID="Label6" runat="server" Text="Standard" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlSTD" runat="server"  
                                                                                AutoPostBack="True" onselectedindexchanged="ddlSTD_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>  
                                                                         <td width="30%">
                                                                            <asp:Button ID="btnReport" runat="server" CssClass="efficacious_send" 
                                                                                 Text="Report" onclick="btnReport_Click"  />
                                                                        </td>                                                                      
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table" Width="70%"  
                                                                DataKeyNames="intStudent_id">
                                                                <Columns>                                                                
                                                                    <asp:BoundField DataField="Student_Name" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Total_Fee" HeaderText="Total Fee" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid_Amt" HeaderText="Paid Fee" ReadOnly="True" />                                                                   
                                                                    <asp:BoundField DataField="Pending_Amount" HeaderText="Pending Fee" ReadOnly="True" />  
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                                </div></center>
                                        </ContentTemplate>
                                    </asp:TabPanel>                                
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>


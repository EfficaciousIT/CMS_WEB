<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frpRptStdWise.aspx.cs" Inherits="frpRptStdWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header1 pd-0">
       
        <ul class="top_navlg rpt_center">
        <li><a >Report Center <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>     
       
            <li> <a href="frmAdmListStudentDetails.aspx"> Student Details </a></li>
            
                  <li><a href="frmStandardWiseRpt.aspx"> Student Fee Collection</a></li>
                  <li><a href="frmRPTFeecollectionInDate.aspx">Date Wise Collection</a></li>   
                  <li><a href="frmHeadwiseFeeRpt.aspx"> Head Wise Collection</a></li>
                  <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
                  <li class="active1"><a href="frpRptStdWise.aspx"> Standard wise Fee Collection</a></li>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="50%">
                                                 <tr>
                                                        <td>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="70%">
                                                                    <tr>
                                                                    <td align="center">
                                                                            <asp:Label ID="Label7" runat="server" Text="Standard" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpSTD" runat="server"  AutoPostBack="True" onselectedindexchanged="drpSTD_SelectedIndexChanged" 
                                                                                >
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label6" runat="server" Text="Category" Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpCAT" runat="server"  Visible="false"
                                                                                AutoPostBack="True" onselectedindexchanged="drpCAT_SelectedIndexChanged" >
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                      
                                                                        </td>
                                                                        <td></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td>
                                                            <div class="efficacious" id="Div2">
                                                                <table width="70%">
                                                                <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label3" runat="server" CssClass="lalfont" Text="Total Student"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtStudent" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label13" runat="server" CssClass="lalfont" Text="Total Fee"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtTotalFee" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>

                                                                    <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label1" runat="server" CssClass="lalfont" Text="Paid Fee"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPaidFee" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>

                                                                    <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label2" runat="server" CssClass="lalfont" Text="Pending Fee"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPendingFee" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>


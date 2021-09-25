<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAttendanceMarkStaff.aspx.cs" Inherits="frmAttendanceMarkStaff" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript">
        function checkDate() {
            var idate = document.getElementById("<%=txtDate.ClientID %>").value;
            var myDate = new Date(idate);
            alert(myDate);
            var today = new Date();
            alert(today);
            if (myDate > today) {
                alert("Please check date.");
                document.forms.form1.date.focus();
                return false;
            }

        }
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
        .style1
        {
            width: 100%;
            font-family: Verdana;
        }
        .style1 select {
            display: block;
            border: 1px solid #3498db;
            width: 133%;
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
            width: 133px;
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
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 130% !important;
            background: #3498db;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: 14px;
            text-align: center;
        }
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .td, th {
            padding: 0;
            padding-right:300px;
        }
        button, html input[type=button], input[type=reset], input[type=submit] {
            -webkit-appearance: button;
            cursor: pointer;
            /* top: -4px; */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header pd-0">       
        <ul class="top_nav1 sp">
        <li><a >Attendance <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li><a href="frmTeacherAttendance.aspx">Teacher Attendance</a></li>
            <li><a href="frmStaffAttendance.aspx">Staff Attendance</a></li>
            <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
            <li><a href="frmAttendanceMarkAdmin.aspx">Admin Attendance Mark</a></li>   
            <li><a href="frmAttendanceMarkTeacher.aspx">Teacher Attendance Mark</a></li>   
            <li class="active1"><a href="frmAttendanceMarkStaff.aspx">Staff Attendance Mark</a></li>   
            <li><a href="frmAttendanceMark.aspx">Student Attendance Mark</a></li>            
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
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>Mark Attendance</HeaderTemplate></asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" 
                                    Visible="False"></asp:TabPanel>
                            </asp:TabContainer>
                            <table width="100%">
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
                                    <td colspan="6">
                                        <table width="100%" style="padding-right:30px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" style="padding-right: 30px;" Text="Date"></asp:Label></td>
                                                <td align="left">
                                                   <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" CssClass="selectf" Font-Names="Verdana" ForeColor="Black" OnTextChanged="txtDate_TextChanged" style="padding-right: 30px;"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                                                    </asp:CalendarExtender></td>
                                                <td>
                                                    
                                                </td>
                                                <td align="center">
                                                    
                                                </td>
                                                <td style="padding-left:20px;">                                                    
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                    <td colspan="4">
                                        <asp:GridView ID="grdMarkAttendance" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                            DataKeyNames="intStaff_id,FCMToken"
                                            EmptyDataText="No Records Found" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Edit" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("intStaff_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:CheckBox ID="chkCtrl" Checked="<%# bool.Parse(Eval("status").ToString()) %>" runat="server" AutoPostBack="true" Style="width: 10px;
                                                                        left: 20px;" />--%>
                                                        <asp:CheckBox ID="chkCtrl" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server"
                                                            AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("status").ToString())%>'>
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="vchfirst_name" HeaderText="Staff Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAttstatus" runat="server" Text='<%#Eval("Attstatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("status") %>' Visible="false" />
                                                        <asp:DropDownList ID="drpStatus" runat="server" AutoPostBack="true" CssClass="selectf"
                                                            OnSelectedIndexChanged="Status_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Present" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Absent" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="efficacious_Submit" Text="Update"
                                                        Visible="False" OnClick="btnUpdate_Click" style="top:1px;"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSMS" runat="server" CssClass="efficacious_Submit" Text="SMS" Visible="False"
                                                        OnClick="btnSMS_Click" />
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


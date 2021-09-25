<%@ Page Title="E-Smarts" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmExamType.aspx.cs" Inherits="frmExamType" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        .efficacious input[type=checkbox] + label
        {
            display: block;
            width: auto !important;
            height: auto !important;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: white !important;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            color: #000;
            padding: 1px 0px;
            text-align: center;
        }
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
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
    <script language="javascript" type="text/javascript">
        function confirm() {
            if (Page_ClientValidate() == false) {
                return false;
            }
            else {

                var atLeast = 1;
                var count = 0;
                var chkLst = document.getElementById('<%=chkSTD.ClientID %>');
                var chk = chkLst.getElementsByTagName("input");
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked) {
                        count++;
                    }
                }
                if (atLeast > count) {
                    alert('Please Select Atleast One Standard');
                    return false;
                }
                //ConfMsg();

            }
        }

        function ConfMsg() {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {

                if (confirm('Do You Really Want To Save Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (confirm('Do You Really Want To Update Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >School Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmSchoolEntry.aspx">School Master</a></li>
             <li><a href="frmNetworkAdmMaster.aspx">SMS Master</a></li>
            <li><a href="frmAcademicYearMaster.aspx">Academic Year Master</a></li>
            <li><a href="frmCategoryMaster.aspx">Category Master</a></li>
            <li><a href="frmLectureTypeMaster.aspx">Lecture Type Master</a></li>
            <li><a href="frmDepartmentMaster.aspx">Department Master</a></li>
            <li><a href="frmDesignationMaster.aspx">Designation Master</a></li>
            <li><a href="frmExamMaster.aspx">Exam Master</a></li>
            <li class="active1"><a>Exam Type Master</a></li>
            <li><a href="frmExamSubjectLink.aspx">Exam Passing Criteria</a></li>
            <li><a href="frmLeaveTypeMaster.aspx">Leave Type Master</a></li>
            <li><a href="frmHolidayTypeMaster.aspx">Holiday Type Master</a></li>
            <li><a href="frmVacationTypeMaster.aspx">Vacation Type Master</a></li>
            <li><a href="frmStatusMaster.aspx">Status Master</a></li>
            <li><a href="frmSessionMaster.aspx">Session Master</a></li>
            <li><a href="frmPeriod_Master.aspx">Period Master</a></li>
            <li><a href="frmStandardMaster.aspx">Standard Master</a></li>
            <li><a href="frmDivision_master.aspx">Division Master</a></li>
            <li><a href="frmSubject_Entry.aspx">Subject Master</a></li>
            <li><a href="frmAdmLectureAssign.aspx">Lecture Schedule</a></li>
            <li><a href="FrmRouteMaster.aspx">Route Master</a></li>
            <li><a href="frmBloodGroupMaster.aspx">Blood Group Master</a></li>
            <li><a href="frmCountryMaster.aspx">Country Master</a></li>
            <li><a href="frmStateMaster.aspx">State Master</a></li>
            <li><a href="frmCityMaster.aspx">City Master</a></li>
            <li><a href="frmAdmStudentProfile.aspx">Student Master</a></li>
            <li><a href="FrmAdmTeacherProfile.aspx">Teacher Master</a></li>
            <li><a href="FrmAdminStaffProfile.aspx">Staff Master</a></li>
            <li><a href="FrmAdminMaster.aspx">Admin Master</a></li>
        </ul>

    </div>
<section class="content">
    <div style="padding: 10px 0 0 0; ">
        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%" style="background-color:White;">                                                    
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server"
                                                              AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="50%"  
                                                                OnRowDataBound="grvDetail_RowDataBound"
                                                                DataKeyNames="intExamType_id" OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                                                <Columns>
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                 <asp:BoundField DataField="ExamTypeName" HeaderText="Exam Type" ReadOnly="True" />
                                                                    
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete ?');" 
                                                                                ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div></center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                        
                                                <div class="style1"  style="background-color:White;">
                                                    <table width="30%" style="margin:0 0 0 2%;">
                                                        <tr id="TrExam" visible="False" runat="server">
                                                            <td class="style4" align="left" runat="server" >
                                                                <asp:Label ID="Label7" runat="server" CssClass="textcss" Text="Exam"></asp:Label>
                                                            </td>
                                                            <td align="left" runat="server">
                                                                <asp:DropDownList ID="drpExam" runat="server" AutoPostBack="True" CssClass="selectf">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                        <asp:Label ID="lblSTD1" runat="server" Text="Standard" CssClass="col-md-12 p-rl5"></asp:Label>
                                                        </td>
                                                        <td>
                                                                                                 <asp:DropDownList ID="ddlSTD1" runat="server" AutoPostBack="True"
                                                                 CssClass="form-control">
                                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style4" align="left" runat="server" >
                                                                <asp:Label ID="Label1" runat="server" Text="Type" style="text-align: left"></asp:Label>
                                                            </td>
                                                            <td >
                                                             <asp:TextBox ID="txtExamType" runat="server" AutoPostBack="True" CssClass="selectf"
                                                              Font-Names="Verdana" ForeColor="Black" MaxLength="30"></asp:TextBox>
                                                               
                                                                <asp:FilteredTextBoxExtender ID="txtExamType_FilteredTextBoxExtender" runat="server"
                                                                    Enabled="True" FilterType="Custom, UppercaseLetters, LowercaseLetters,numbers" TargetControlID="txtExamType"
                                                                    ValidChars=".- ">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>

                                                        </tr>
                                                        <tr id="TrSubject" visible="False" runat="server">
                                                            <td  class="style5" align="left" runat="server">
                                                                <asp:Label ID="Label2" runat="server" CssClass="textcss" Text="Subject"></asp:Label>
                                                            </td>
                                                            <td class="auto-style6" align="left" valign="top" runat="server">
                                                                <div id="divId" style="overflow: scroll; height: 190px;">
                                                                    <asp:CheckBoxList ID="chkSTD" runat="server" CssClass="selectf">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr2" visible="False" runat="server">
                                                            <td class="style6" align="left" runat="server">
                                                                <asp:Label ID="Label8" runat="server" CssClass="textcss" Text="Max Marks"></asp:Label>
                                                            </td>
                                                            <td align="left" runat="server">
                                                                <asp:TextBox ID="txtExamMax" runat="server" CssClass="selectf" Width="96%" 
                                                                    MaxLength="3"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="txtExamMax_FilteredTextBoxExtender" runat="server"
                                                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtExamMax" ValidChars=".">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
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
                                                                <table width="80%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                                                OnClientClick="return confirm();" Text="Submit" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                                                                CssClass="efficacious_send" Visible="False"
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                       
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
      
    </div>
</section>
</asp:Content>

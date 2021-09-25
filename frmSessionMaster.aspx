<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmSessionMaster.aspx.cs" Inherits="frmSessionMaster" Title="Session Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function validation() {

            var txtName = document.getElementById("<%=txtName.ClientID %>").value;
            var txtFrmTime = document.getElementById("<%=txtFrmTime.ClientID %>").value;
            var txttotime = document.getElementById("<%=txttotime.ClientID %>").value;

            if (txtName == '') {

                alert('Please provide session');
                return false;
            }

            if (txtFrmTime == 'Start Time') {

                alert('From time should not be blank');
                return false;
            }

            if (txttotime == 'End Time') {

                alert('To time should not be blank');
                return false;
            }







            return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        
        .btn
        {
            width: 94px;
            padding: 8px 5px;
            background: #3498db;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border: none;
            color: #fff;
        }
    </style>
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
            <li><a href="frmExamType.aspx">Exam Type Master</a></li>
            <li><a href="frmExamSubjectLink.aspx">Exam Passing Criteria</a></li>
            <li><a href="frmLeaveTypeMaster.aspx">Leave Type Master</a></li>
            <li><a href="frmHolidayTypeMaster.aspx">Holiday Type Master</a></li>
            <li><a href="frmVacationTypeMaster.aspx">Vacation Type Master</a></li>
            <li><a href="frmStatusMaster.aspx">Status Master</a></li>
            <li class="active1"><a href="frmSessionMaster.aspx">Session Master</a></li>
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
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
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
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="70%" DataKeyNames="intSession_id"
                                                                OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing">
                                                                <Columns>
                                                                <asp:BoundField DataField="vchSessionName" HeaderText="Session" ReadOnly="True">
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                  <asp:BoundField DataField="dtStartTime" HeaderText="Start Time" ReadOnly="True" />
                                                                    <asp:BoundField DataField="dtEndTime" HeaderText="End Time" ReadOnly="True" />
                                                                   
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return ConfirmDelete();" ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                  
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <table width="36%" style="text-align: right;margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &#160;&#160;
                                                        </td>
                                                        <td align="justify">
                                                            &#160;&#160;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server" Text="Session" ></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" MaxLength="50"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server" TargetControlID="txtName"
                                                                FilterType="Numbers, UppercaseLetters, LowercaseLetters" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblfrmtime" runat="server" Text="Time"></asp:Label>
                                                        </td>
                                                        <td align="left" class="textsize">
                                                            <asp:TextBox ID="txtFrmTime" runat="server" MaxLength="10" 
                                                                CssClass="input-blue" Width="95px"></asp:TextBox><asp:MaskedEditExtender
                                                                ID="txtMaskedFrmTime" runat="server" AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder=""
                                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" AcceptAMPM="True" CultureDatePlaceholder=""
                                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtFrmTime">
                                                            </asp:MaskedEditExtender>
                                                            <asp:TextBox ID="txttotime" runat="server" CssClass="input-blue"
                                                                Width="98px" MaxLength="10"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                                    AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                    CultureDateFormat="" AcceptAMPM="True" CultureDatePlaceholder="" CultureDecimalPlaceholder=""
                                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99:99"
                                                                    MaskType="Time" TargetControlID="txtToTime">
                                                                </asp:MaskedEditExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFrmTime"
                                                                Display="None" ErrorMessage="Please Enter Start Time"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RequiredFieldValidator7_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                    TargetControlID="RequiredFieldValidator7">
                                                                </asp:ValidatorCalloutExtender>
                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender0"
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txttotime"
                                                                Display="None" ErrorMessage="Please Enter To Time"></asp:RequiredFieldValidator><asp:TextBoxWatermarkExtender
                                                                    ID="TextBoxWatermarkExtender3" runat="server" WatermarkText="Start Time" TargetControlID="txtFrmTime"
                                                                    Enabled="True">
                                                                </asp:TextBoxWatermarkExtender>
                                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkText="End Time"
                                                                TargetControlID="txttotime" Enabled="True">
                                                            </asp:TextBoxWatermarkExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify" class="auto-style5">
                                                        </td>
                                                        <td align="justify" class="auto-style5">
                                                            &#160;&#160;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="btnSubmit_Click"
                                                                OnClientClick="return validation();" />&#160;&#160;
                                                            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" CssClass="btn"
                                                                CausesValidation="False" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &#160;&#160;
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
        </center>
    </div>
</section>
</asp:Content>

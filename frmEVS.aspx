<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmEVS.aspx.cs" Inherits="frmEVS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >School Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li class="active1"><a href="frmSchoolEntry.aspx">School Master</a></li>
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
            <li><a href="frmExamSubjectEntry.aspx">Exam Subject</a></li>
            <li><a href="frmExamAttendanceMaster.aspx">Exam Attendence Master</a></li>
            <li><a href="FrmSkillsEntry.aspx">Skill Master</a></li>
            <li><a href="frmWorkHabit.aspx">Work Habit Master</a></li>
            <li><a href="frmPersonalTraits.aspx">Personal Traits Master</a></li>
            <li><a href="frmEnglishActivity.aspx">English Activity Master</a></li>
            <li><a href="frmEnglishReader.aspx">English Reader Master</a></li>
            <li><a href="frmNumberWork.aspx">Number Work Master</a></li>
            <li><a href="frmSecondLanguage.aspx">Second Language Master</a></li>
            <li><a href="frmSecondLangBengali.aspx">Second Lang Bengali Master</a></li>
            <li><a href="frmEVS.aspx">EVS Master</a></li>
            <li><a href="frmComputer.aspx">Computer Master</a></li>
        </ul>
            </div>
    <style>
        .efficacious span
        {
            margin: 0 !important;
            padding: 0 10px 0 0 !important;
            float: right;
            position: relative;
            top: -5px;
        }
        .efficacious_send
        {
            width: 40% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 12px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            text-align: center !important;
        }
    </style>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div style="padding: 5px 0 0 0">
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel ID="tabpanel2" runat="server">
                                    <HeaderTemplate>
                                        List of Discipline</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="ssst" runat="server">Standard</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Stdrop1" runat="server" Style="width: 32%;" AutoPostBack="True"
                                                            OnSelectedIndexChanged="Stdrop1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:GridView ID="SubReport" runat="server" OnPageIndexChanging="SubReport_PageIndexChanging"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                            OnRowEditing="SubReport_RowEditing" DataKeyNames="id"
                                                            OnRowDeleting="SubReport_RowDeleting" Width="100%" PageSize="20">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="id" runat="server" Text='  <%# Eval("id")  %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                <%--<asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />--%>
                                                                <asp:BoundField DataField="VchName" HeaderText="Discipline Name" ReadOnly="True" />
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 24px !important; outline: 0;"
                                                                            ImageUrl="~/images/edit.png" CommandName="Edit" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 24px !important; outline: 0;"
                                                                            ImageUrl="~/images/delete.png" CommandName="Delete" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                            CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Discipline Entry</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table style="font-weight: bolder; width: 40%; margin: 10px 0 10px 15px;" align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Standard" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Standard_id" runat="server" Font-Bold="False" 
                                                            AutoPostBack="True" OnSelectedIndexChanged="Standard_id_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Standard_id"
                                                            InitialValue="0" Display="None" ErrorMessage="Please Select Standard"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                               <%-- <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Division" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Division_id" runat="server" Font-Bold="False" >
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Division_id"
                                                            InitialValue="0" Display="None" ErrorMessage="Please Select Division"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                            TargetControlID="RequiredFieldValidator7">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="subj1" runat="server" Text="Subject" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="text1" CssClass="input-blue" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text1"
                                                            Display="None" ErrorMessage="Please Enter Subject"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender1"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="left">
                                                        <table width="80%">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Button ID="Button1" Style="padding-left: 10px" runat="server" Text="Submit"
                                                                        OnClick="Button1_Click" CssClass="efficacious_send" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="Button2" runat="server" Text="Clear" OnClick="Button2_Click" CssClass="efficacious_send"
                                                                        Visible="False" /><asp:HiddenField ID="hid1" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


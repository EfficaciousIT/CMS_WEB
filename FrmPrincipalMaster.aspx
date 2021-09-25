<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="FrmPrincipalMaster.aspx.cs" Inherits="FrmPrincipalMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
        .style1
        {
            height: 24px;
        }
        .style3
        {
            height: 39px;
        }
        .auto-style1
        {
            width: 241px;
        }
        .auto-style2
        {
            width: 455px;
        }
        .auto-style3
        {
            width: 494px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>
        .btn
        {
            border: none;
            width: 110px !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: left;
            text-align: center !important;
        }
        .efffield
        {
            display: block;
            border: 1px solid #3498db;
            width: 70%;
            padding: 5px 5px 5px 10px;
            font-family: Verdana;
            outline: none;
            font-size: 13px;
            text-align: left;
            outline: none;
            float: right;
            border-radius: 5px !important;
            margin-bottom: 6px;
            -webkit-border-radius: 2px !important;
            -moz-border-radius: 2px !important;
        }
        .ajax__tab_default .ajax__tab_header
        {
            white-space: normal !important;
        }
        .ajax__tab_default .ajax__tab_outer
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_inner
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
        }
        /* xp theme */
        .ajax__tab_xp .ajax__tab_header
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 11px;
            background: #fff;
            height: 26px;
        }
        .textcss
        {
            font-size: 13px !important;
        }
        .ajax__tab_xp .ajax__tab_outer
        {
            padding-right: 4px;
            background: #fff;
            height: 25px;
            font-size: 12px;
            padding: 4px 0;
            border: 1px solid #D5D5D5;
            margin-right: 2px;
        }
        .ajax__tab_xp .ajax__tab_inner
        {
            padding-left: 3px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_tab
        {
            height: 20px;
            padding-bottom: 15px;
            padding: 4px;
            margin: 0px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_outer
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_inner
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_tab
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_outer
        {
            background: #fff;
            border-right: 1px solid #3498db;
            border-left: 1px solid #3498db;
            border-top: 1px solid #3498db;
            padding: 5px 0;
            border-radius: 1px 1px 0 0;
            margin-right: 2px;
            height: 26px;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_inner
        {
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_tab
        {
            background: #fff;
            color: #3498db;
            font-size: 12px;
            font-weight: bold;
            padding-bottom: 15px;
        }
        .ajax__tab_xp .ajax__tab_disabled
        {
            color: #A0A0A0;
        }
        .ajax__tab_xp .ajax__tab_body
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 10pt;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
        /* scrolling */
        .ajax__scroll_horiz
        {
            overflow-x: scroll;
        }
        .ajax__scroll_vert
        {
            overflow-y: scroll;
        }
        .ajax__scroll_both
        {
            overflow: scroll;
        }
        .ajax__scroll_auto
        {
            overflow: auto;
        }
        /* plain theme */
        .ajax__tab_plain .ajax__tab_outer
        {
            text-align: center;
            vertical-align: middle;
            border: 2px solid #999999;
        }
        .ajax__tab_plain .ajax__tab_inner
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_body
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_header
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_active .ajax__tab_outer
        {
            background: #FFF;
        }
        .input-blue
        {
            width: 50%;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 30px;
            padding-right: 10px;
            margin-left: -100px;
        }
        .input-blue_Qualification
        {
            width: 50%;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 30px;
            padding-right: 10px;
            margin-left: 0px;
        }
        .input-blue_Brower
        {
            /* width: 40%; */
            border: 1px solid #3498db; /* margin: 8px 0px; */
            padding: 10px 10px; /* height: 40px; */ /* padding-right: 10px; */
            margin-left: 228px;
            width: 10px;
        }
        . .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 50%;
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
        select
        {
            margin-left: -100px !important;
            width: 50%;
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
            <li class="active1"><a href="FrmAdminMaster.aspx">Admin Master</a></li>
        </ul>

    </div>
 <section class="content">
    <div style="padding: 05px 0 0 0">
        <asp:UpdatePanel ID="up2" runat="server">
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
                        <td>
                            <asp:Label ID="Labnorecord" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Personal Details</HeaderTemplate>
                                    <ContentTemplate>
                                        <div>
                                            <center>
                                                <table style="font-weight: bolder; width: 100%" align="center">
                                                    <tr>
                                                        <td rowspan="6">
                                                            <asp:Image ID="TeacherImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                                runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                                border="2" ToolTip="Image" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblvchno" runat="server" Font-Bold="False">First Name</asp:Label>
                                                            <br />
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" CssClass="input-blue"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox1"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter First Name" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="Reg30" runat="server" ValidationGroup="a1" ControlToValidate="TextBox1"
                                                                Display="None" ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red"
                                                                ValidationExpression="^[a-zA-Z]$+"></asp:RegularExpressionValidator>
                                                            &nbsp;&nbsp;
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" Enabled="True"
                                                                TargetControlID="Reg30">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblvchmake" runat="server" Font-Bold="False">Middle Name</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" CssClass="input-blue"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana" CssClass="input-blue"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter last Name" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator5">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="Regg2" runat="server" ControlToValidate="TextBox3"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Only alphabets are allowed"
                                                                Font-Bold="False" ForeColor="Red" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator>
                                                            &nbsp;&nbsp;
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                                                TargetControlID="Regg2">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr >
                                                        <td align="left">
                                                            <asp:Label ID="Label9" runat="server" Text="Preferred Subjects" 
                                                                Font-Bold="False" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" 
                                                                CssClass="input-blue" Visible="False"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label35" runat="server" Text="Academic Year" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlAcademicYear" runat="server" 
                                                                DataTextField="AcademicYear" DataValueField='intAcademic_id'  >
                                                            </asp:DropDownList>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label12" runat="server" Text="Department Name" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label10" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:DropDownList ID="TextBox5" runat="server" DataTextField="vchDepartment_name"
                                                                DataValueField='intDepartment' 
                                                                OnSelectedIndexChanged="TextBox5_SelectedIndexChanged" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Department"
                                                                ValidationGroup="a1" ControlToValidate="TextBox5" InitialValue="Select" Display="None"
                                                                Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td></td>
                                                        <td align="left">
                                                            <asp:Label ID="Label7" runat="server" Text="Designation" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label8" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlDesignation" runat="server" DataTextField="vchDesignation"
                                                                DataValueField='intDesignation_Id'>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Designation"
                                                                ValidationGroup="a1" ControlToValidate="ddlDesignation" InitialValue="Select" Display="None"
                                                                Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator3">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td></td>
                                                        <td align="left">
                                                            <asp:Label ID="Label13" runat="server" Text="Gender" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel runat="server" ID="uid1" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="False"></asp:Label>
                                                                    <asp:DropDownList ID="TextBox6" runat="server">
                                                                        <asp:ListItem Value="Select" Selected="True">---Select---</asp:ListItem>
                                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Gender"
                                                                        ControlToValidate="TextBox6" InitialValue="Select" Display="None" ValidationGroup="a1"
                                                                        Font-Bold="False"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                        TargetControlID="RequiredFieldValidator1">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label14" runat="server" Text="Date of Birth" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label22" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox7" Format="dd/MM/yyyy"
                                                                Enabled="True">
                                                            </asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter Dob Name" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                                                </asp:ValidatorCalloutExtender>
                                                            &nbsp;&nbsp;
                                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox7"
                                                                Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)" Font-Bold="False"
                                                                Operator="LessThan" SetFocusOnError="True" Type="Date" ValidationGroup="a1"></asp:CompareValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="CompareValidator3">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="lbldrivermobno" runat="server" Text="Email" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label23" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="50" ValidationGroup="b"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ControlToValidate="TextBox8" Display="None" ValidationGroup="p1" ErrorMessage="Invalid Email Format"
                                                                Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label15" runat="server" Text="Highest Qualification" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label24" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox9" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label16" runat="server" Text="Home Telephone Number 1" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label25" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="12" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server"
                                                                ValidationGroup="a1" ControlToValidate="TextBox10" Display="None" ErrorMessage="Enter valid Phone number"
                                                                Font-Bold="False" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True"
                                                                TargetControlID="RegularExpressionValidator29">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label17" runat="server" Text="Home Telephone Number 2" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label26" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="12" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="a1"
                                                                ControlToValidate="TextBox10" Display="None" ErrorMessage="Enter valid Phone number"
                                                                Font-Bold="False" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RegularExpressionValidator29">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label18" runat="server" Text="Mobile Number" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label27" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox12"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter Father Mobile No"
                                                                Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator4">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="Regg33" runat="server" ControlToValidate="TextBox12"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Enter Valid Mobile no" Font-Bold="False"
                                                                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                                                TargetControlID="Regg33">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label19" runat="server" Text="Facebook Url" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label28" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegE22" runat="server" ControlToValidate="TextBox13"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Enter Valid facebook id" Font-Bold="False"
                                                                ValidationExpression="^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                                TargetControlID="Regg33">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label20" runat="server" Text="Twitter Url" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label29" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label21" runat="server" Text="Other Url" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label30" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label34" runat="server" Text="Time To Contact" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td style="padding-top: 10px" align="left" class="auto-style3">
                                                            <asp:Label ID="Label33" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox18" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                MaxLength="20" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="bro1" runat="server">
                                                        <td id="Td1" runat="server">
                                                        </td>
                                                        <td id="img" runat="server" align="left" colspan="2">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input-blue_Brower" Style="width: 43.8%" />
                                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn" Style="position: relative;
                                                                        left: 260px;" OnClientClick="if (!validatePage()) {return true;}" Text="Upload Image" />
                                                                    &nbsp;<br />
                                                                    <br />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="Button1" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 10px">
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            &nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <asp:Button runat="server" Text="Next" ID="ButN1" OnClick="checknextval1" CssClass="btn"
                                                                Style="position: relative; left: 75px;" ValidationGroup="a1"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Address Details
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div>
                                            <center>
                                                <table style="font-weight: bolder; width: 70%; margin: 10px 0;" align="center">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="False">Present Address</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label31" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox16" Style="float: left;" runat="server" Font-Names="Verdana"
                                                                Font-Size="Small" ForeColor="Black" MaxLength="250" ValidationGroup="b" Width="212px"
                                                                CssClass="input-blue" Height="45px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="style3" nowrap="nowrap">
                                                            <asp:Label ID="Label4" runat="server" Text="Permanent Address" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="style3" nowrap="nowrap">
                                                            <asp:Label ID="Label32" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox17" Style="float: left;" runat="server" Font-Names="Verdana"
                                                                Font-Size="Small" ForeColor="Black" MaxLength="250" ValidationGroup="b" Width="212px"
                                                                CssClass="input-blue" Height="48px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button runat="server" OnClientClick="if (!validatePage()) {return true;}" Text="Back"
                                                                ID="ButP2" Style="margin-right: 10px;" CssClass="btn" OnClick="checkPrivious2">
                                                            </asp:Button>
                                                            <asp:Button runat="server" OnClientClick="if (!validatePage()) {return true;}" Text="Next"
                                                                ID="ButN2" CssClass="btn" OnClick="checknextval2"></asp:Button>
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel3" runat="server">
                                    <HeaderTemplate>
                                        Education Details</HeaderTemplate>
                                    <ContentTemplate>
                                        <div>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDegree1"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtInstitution1"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPassingYear1"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtPercent1"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtMajorSubject1"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDegree2"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtInstitution2"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPassingYear2"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPercent1"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtMajorSubject2"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtDegree3"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtInstitution3"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtPassingYear3"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtPercent3"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtMajorSubject3"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txtDegree4"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txtInstitution4"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" TargetControlID="txtPassingYear4"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" TargetControlID="txtPercent4"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" TargetControlID="txtMajorSubject4"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txtDegree5"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" TargetControlID="txtInstitution5"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" TargetControlID="txtPassingYear5"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtPercent5"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" TargetControlID="txtMajorSubject5"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:CalendarExtender ID="cal1" runat="server" TargetControlID="txtPassingYear1"
                                                Format="yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPassingYear2"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPassingYear3"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtPassingYear4"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtPassingYear5"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <table cellpadding="6" cellspacing="6">
                                                <tr>
                                                    <td class="style6">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        Degree / Diploma / Other
                                                    </td>
                                                    <td align="center">
                                                        Institution
                                                    </td>
                                                    <td align="center" class="auto-style1">
                                                        University
                                                    </td>
                                                    <td align="center" class="style4">
                                                        Year of Passing
                                                    </td>
                                                    <td align="center" class="style5">
                                                        % Score / Grade
                                                    </td>
                                                    <td align="center">
                                                        Major Subjects
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server">
                                                    <td id="Td2" align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button4" runat="server" CssClass="btn" Style="width: 50px !important;
                                                            margin: 0;" Text="+" OnClientClick="if (!validatePage()) {return true;}" OnClick="Button4_Click" />
                                                    </td>
                                                    <td id="Td3" valign="top" align="center" runat="server" style="white-space: nowrap">
                                                        <asp:TextBox ID="txtDegree1" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td4" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution1" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td5" valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity1" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td6" valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox runat="server" MaxLength="5" CssClass="input-blue_Qualification" Width="45px" ID="txtPassingYear1"
                                                            oncopy="return false" oncut="return false" AutoComplete="Off" onpaste="return false"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td7" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent1" oncopy="return false" CssClass="input-blue_Qualification" oncut="return false"
                                                            AutoComplete="Off" onpaste="return false" runat="server" Width="45px" MaxLength="5"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td8" valign="top" runat="server" aling="center">
                                                        <asp:TextBox ID="txtMajorSubject1" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td9" valign="top" runat="server">
                                                    </td>
                                                </tr>
                                                <tr id="tr2" runat="server" visible="False">
                                                    <td id="Td10" align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button5" runat="server" Text="+" CssClass="btn" OnClick="Button5_Click"
                                                            OnClientClick="if (!validatePage()) {return true;}" />
                                                    </td>
                                                    <td id="Td11" align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree2" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="150px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td12" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution2" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td13" valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity2" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td14" valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear2" runat="server" Width="45px" CssClass="input-blue_Qualification"
                                                            MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td15" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent2" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="45px" MaxLength="5"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td16" valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject2" runat="server" CssClass="input-blue" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td17" valign="top" runat="server">
                                                    </td>
                                                </tr>
                                                <tr id="tr3" runat="server" visible="False">
                                                    <td id="Td18" align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button6" runat="server" Text="+" CssClass="btn" OnClick="Button6_Click"
                                                            OnClientClick="if (!validatePage()) {return true;}" Style="height: 26px" />
                                                    </td>
                                                    <td id="Td19" align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree3" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="150px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td20" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution3" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td21" valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity3" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td22" valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear3" runat="server" Width="45px" CssClass="input-blue_Qualification"
                                                            MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td23" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent3" runat="server" oncopy="return false" oncut="return false"
                                                            CssClass="input-blue" onpaste="return false" Width="45px" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td24" valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject3" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td25" valign="top" runat="server">
                                                    </td>
                                                </tr>
                                                <tr id="tr4" runat="server" visible="False">
                                                    <td id="Td26" align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button7" runat="server" Text="+" CssClass="btn" OnClick="Button7_Click"
                                                            OnClientClick="if (!validatePage()) {return true;}" />
                                                        &nbsp;
                                                    </td>
                                                    <td id="Td27" align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree4" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="150px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td28" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td29" valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            CssClass="formlbl" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td30" valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear4" runat="server" Width="45px" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td31" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            runat="server" Width="45px" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td32" valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td33" valign="top" runat="server">
                                                    </td>
                                                </tr>
                                                <tr id="tr5" runat="server" visible="False">
                                                    <td id="Td34" align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        &nbsp;
                                                    </td>
                                                    <td id="Td35" align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree5" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="150px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td36" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution5" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td37" valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity5" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td38" valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear5" runat="server" Width="45px" CssClass="input-blue_Qualification"
                                                            MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td39" valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent5" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="45px" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td40" valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject5" oncopy="return false" oncut="return false" CssClass="input-blue_Qualification"
                                                            onpaste="return false" runat="server" Width="160px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td id="Td41" valign="top" runat="server">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="7">
                                                        <asp:UpdatePanel ID="updat1" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button runat="server" OnClientClick="if (!validatePage()) {return true;}" Text="Back"
                                                                                ID="Button3" CssClass="btn" OnClick="checkPrivious3"></asp:Button>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Button2" CssClass="btn" Style="margin: 10px;" runat="server" OnClientClick="if (!validatePage()) {return true;}"
                                                                                OnClick="submit" Text="Submit"></asp:Button>
                                                                            <asp:Button ID="Button8" CssClass="btn" runat="server" OnClick="Updateval" Text="Update">
                                                                            </asp:Button>
                                                                            <asp:Label ID="lab1" runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lab2" runat="server" Visible="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                  <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Details
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="80%" 
                                                                DataKeyNames="intPrincipal_id" onrowediting="grvDetail_RowEditing"  >
                                                                <Columns>
                                                                 <asp:BoundField DataField="vchFirst_name" HeaderText="First Name" ReadOnly="True" />
                                                                 <asp:BoundField DataField="vchLast_name" HeaderText="Last Name" ReadOnly="True" />  
                                                                 <asp:BoundField DataField="intDepartment_id" HeaderText="Department" ReadOnly="True" />
                                                                 <asp:BoundField DataField="intMobileNo" HeaderText="Mobile" ReadOnly="True" />  
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="Delete" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
    </asp:Content>



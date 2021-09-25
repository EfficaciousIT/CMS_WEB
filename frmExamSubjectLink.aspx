<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmExamSubjectLink.aspx.cs" Inherits="frmExamSubjectLink" %>

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
    </style>
    <script language="javascript" type="text/javascript">
        

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
            <li><a href="frmExamType.aspx">Exam Type Master</a></li>
            <li class="active1"><a href="frmExamSubjectLink.aspx">Exam Passing Criteria</a></li>
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
    <div style="padding: 10px 0 0 0">
        <center>
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
                                            
                                                <table width="100%">  
                                                    <tr>
                                                        <td>
                                                          
                                                                <table width="70%" style="margin:0 0 0 2%;">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label12" CssClass="textcss" runat="server" Text="Standard"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpStdSelect" CssClass="textsize" runat="server" 
                                                                                onselectedindexchanged="drpStdSelect_SelectedIndexChanged" 
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label13" CssClass="textcss" runat="server" Text="Exam"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpExamSelect" CssClass="textsize" runat="server" 
                                                                                AutoPostBack="True" onselectedindexchanged="drpExamSelect_SelectedIndexChanged">
                                                                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            
                                                        </td>
                                                    </tr>                                                  
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="mGrid" Width="70%" OnRowDataBound="grvDetail_RowDataBound" AllowPaging="True"
                                                                DataKeyNames="intID" OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                                                <Columns>                                                                  
                                                                    <asp:BoundField DataField="vchSubjectName" HeaderText="Subject" ReadOnly="True" />
                                                                    <asp:BoundField DataField="ExamTypeName" HeaderText="Exam Type" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intMaxmarks" HeaderText="Total Marks" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intMarks" HeaderText="Marks" ReadOnly="True" />   
                                                                      <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="False"
                                                                                ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
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
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <div class="efficacious" style="background-color:white;">
                                                    <table width="50%" style="margin:0 0 0 2%;">
                                                        <tr id="TrExam" runat="server">
                                                            <td class="style4" align="left" valign="top" runat="server">
                                                                <asp:Label ID="Label7" runat="server" CssClass="textcss" Text="Exam"></asp:Label>
                                                            </td>
                                                            <td align="left" runat="server">
                                                                <asp:DropDownList ID="drpExam" runat="server" AutoPostBack="True" CssClass="textsize">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style4" valign="top">
                                                                <asp:Label ID="Label11" runat="server" CssClass="textcss" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" 
                                                                    CssClass="textsize" onselectedindexchanged="drpStandard_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style4" valign="top">
                                                                <asp:Label ID="Label1" runat="server" CssClass="textcss" Text="Subject"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="drpSubject" runat="server" AutoPostBack="True" 
                                                                    CssClass="textsize" 
                                                                    onselectedindexchanged="drpSubject_SelectedIndexChanged1">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style4" valign="top">
                                                                <asp:Label ID="Label10" runat="server" CssClass="textcss" Text="Total Marks"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTotalMarks" runat="server" CssClass="input-blue" 
                                                                    Width="100%" MaxLength="3"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="txtExamMax0_FilteredTextBoxExtender" 
                                                                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                                                    TargetControlID="txtTotalMarks" ValidChars=".">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style4" valign="top">
                                                                <asp:Label ID="Label9" runat="server" CssClass="textcss" Text="Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="drpExamType" runat="server" AutoPostBack="True" 
                                                                    CssClass="textsize">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr2" runat="server">
                                                            <td id="Td1" class="style6" valign="top" align="left" runat="server">
                                                                <asp:Label ID="Label8" runat="server" CssClass="textcss" Text="Marks"></asp:Label>
                                                            </td>
                                                            <td id="Td2" align="left" runat="server">
                                                                <asp:TextBox ID="txtExamMax" runat="server" CssClass="input-blue" Width="100%" 
                                                                    MaxLength="3"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="txtExamMax_FilteredTextBoxExtender" runat="server"
                                                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtExamMax" ValidChars=".">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                                                Text="Submit" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="efficacious_send"
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
        </center>
    </div>
</section>
</asp:Content>

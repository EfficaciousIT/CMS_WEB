<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmDivision_master.aspx.cs" Inherits="frmDivision_master" Title="Division Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 40%;
            padding-left: 2%;
        }
        .style2
        {
            width: 40%;
            padding-left: 2%;
        }
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .mGrid th {
         text-align: center !important;
            }
          
        .style1 input[type=text]
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
         .btn{ width:100px !important; padding:8px 5px; float:left; background:#3498db; -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px; text-align:center !important; outline:0; border:none; color:#fff;}
        
    </style>
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
            <li><a href="frmExamSubjectLink.aspx">Exam Passing Criteria</a></li>
            <li><a href="frmLeaveTypeMaster.aspx">Leave Type Master</a></li>
            <li><a href="frmHolidayTypeMaster.aspx">Holiday Type Master</a></li>
            <li><a href="frmVacationTypeMaster.aspx">Vacation Type Master</a></li>
            <li><a href="frmStatusMaster.aspx">Status Master</a></li>
            <li><a href="frmSessionMaster.aspx">Session Master</a></li>
            <li><a href="frmPeriod_Master.aspx">Period Master</a></li>
            <li><a href="frmStandardMaster.aspx">Standard Master</a></li>
            <li class="active1"><a href="frmDivision_master.aspx">Division Master</a></li>
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
        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" CssClass="efficacious" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" DataKeyNames="intDivision_id" OnRowDeleting="grvDetail_RowDeleting"
                                                                OnRowEditing="grvDetail_RowEditing">
                                                                <Columns>                                                                 
                                                                    <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchDivisionName" HeaderText="Division" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchSessionName" HeaderText="Session" ReadOnly="True">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="vchFloor_name" HeaderText="Floor" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchRoom_name" HeaderText="Room No" ReadOnly="True" />
                                                                  
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" style="  width: 22% !important; outline:0;" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" style="  width: 22% !important; outline:0;" CommandName="Delete" CausesValidation="false"
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
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table width="40%"  style="text-align: right; margin:0 0 0 2%;">
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        &nbsp;
                                                    </td>
                                                    <td align="justify">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label3" runat="server" Text="Session"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                        <asp:DropDownList ID="drpSession" runat="server">
                                                           <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                       <asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="Please Select Floor"
                                                            Display="None" ControlToValidate="drpSession" InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                ID="VC" runat="server" TargetControlID="R1" Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label4" runat="server" Text="Standard"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                        <asp:DropDownList ID="drpStandard" runat="server">
                                                           <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpStandard"
                                                            Display="None" ErrorMessage="Please Enter Division"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label2" runat="server" Text="Division"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                        <asp:TextBox ID="txtName" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="75"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                            Display="None" ErrorMessage="Please Enter Division"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lblfrmtime" runat="server" Text="Floor"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpFloor_SelectedIndexChanged">
                                                           <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lblfrmtime0" runat="server" Text="Room No"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpRoom" runat="server">
                                                            <%--<asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="style1">
                                                    </td>
                                                    <td align="left">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();"
                                                            Text="Submit"/>
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" OnClick="btnClear_Click"
                                                            Text="Clear" Visible="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="auto-style5" colspan="2">
                                                        &nbsp;
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

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSchoolEntry.aspx.cs" Inherits="frmSchoolEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="99%" DataKeyNames="intschool_id"
                                                                onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing">
                                                                <Columns>
                                                                    <asp:BoundField DataField="vchSchool_name" HeaderText="School Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchSchool_shortname" HeaderText="Short Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="numPhoneNo1" HeaderText="Phone" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True" />
                                                                    
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
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="36%" style="text-align: right">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                        <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label1" runat="server" Text="Type"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                             <asp:DropDownList ID="ddlType" runat="server">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem>School</asp:ListItem>
                                                                <asp:ListItem>College</asp:ListItem>
                                                                <asp:ListItem>Institute</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server" Text="School Name"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtSchoolName" runat="server" CssClass="input-blue" 
                                                                MaxLength="50" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RFVSCHOOL" runat="server" ControlToValidate="txtSchoolName"
                                                                Display="None" ErrorMessage="Please Enter School Name"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                 
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label3" runat="server" Text="Short Name" 
                                                                style="text-align: left"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtShortSchoolName" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="input-blue" 
                                                                MaxLength="250" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label5" runat="server" Text="Landmark"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtLandmark" runat="server" CssClass="input-blue" 
                                                                MaxLength="250" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label6" runat="server" Text="State"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                             <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="ddlState_SelectedIndexChanged">
                                                              
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlCity" runat="server">
                                                               
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label8" runat="server" Text="Pin code"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtPinCode" runat="server" CssClass="input-blue" 
                                                                MaxLength="10" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label9" runat="server" Text="Phone No 1"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="input-blue" MaxLength="20" 
                                                                AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label10" runat="server" Text="Phone No 2"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label11" runat="server" Text="Phone No 3"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtPhone3" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label12" runat="server" Text="Website"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label13" runat="server" Text="Fax"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtFax" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label14" runat="server" Text="Contact Person1"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtContactPerson1" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label15" runat="server" Text="Designation"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDesignation1" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label16" runat="server" Text="Mobile No"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtMobile1" runat="server" CssClass="input-blue" 
                                                                MaxLength="10" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label17" runat="server" Text="Email"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtEmail1" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label18" runat="server" Text="Contact Person2"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtContactPerson2" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label19" runat="server" Text="Designation"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDesignation2" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label20" runat="server" Text="Mobile No"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtMobile2" runat="server" CssClass="input-blue" 
                                                                MaxLength="10" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label21" runat="server" Text="Email"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtEmail2" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label22" runat="server" Text="Contact Person3"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtContactPerson3" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label23" runat="server" Text="Designation"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDesignation3" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label24" runat="server" Text="Mobile No"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtMobile3" runat="server" CssClass="input-blue" 
                                                                MaxLength="10" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                       <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label25" runat="server" Text="Email"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtEmail3" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                <td align="justify">
                                                               
                                                                </td>
                                                                    <td align="right" style="padding-left:-20px">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                                                            CssClass="efficacious_send" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
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
        </center>
    </div>
</section>
</asp:Content>


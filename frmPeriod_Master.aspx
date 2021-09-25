<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmPeriod_Master.aspx.cs" Inherits="frmPeriod_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious input
        {
            margin-bottom: 10px;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .efficacious input[type=checkbox] + label
        {
            background: inherit;
            position: relative;
            top: -8px;
            left: 5px;
            margin-right: 10px;
            margin-top: 10px;
        }
        .efficacious input[type=checkbox] + label
        {
            background: inherit;
            position: relative;
            top: -8px;
            left: 5px;
            margin-right: 10px;
            margin-top: 10px;
        }
    </style>
    <script type="text/javascript">
        function messageConfirm(msg) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(msg)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }

            document.forms[0].reset();
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmDelete() {
            var del = confirm('Do You Really Want To Delete Selected Record?');
            if (del) {
                return true;
            }
            else {
                return true;
            }
        }
    </script>
    <style>
        .efficacious span
        {
            margin: 0 !important;
            padding: 0 !important;
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
            <li class="active1"><a href="frmPeriod_Master.aspx">Period Master</a></li>
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
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1015px"
                CssClass="MyTabStyle">
                <asp:TabPanel ID="tabpanel2" runat="server">
                    <HeaderTemplate>
                        Period Time Display</HeaderTemplate>
                    <ContentTemplate>
                        <div class="efficacious" style="margin-top: 10px;">
                            <center>
                                <asp:GridView ID="PeriodReport" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table  tabular-table" OnPageIndexChanging="PeriodReport_PageIndexChanging"
                                    OnRowDataBound="PeriodReport_RowDataBound" OnRowEditing="PeriodReport_RowEditing"
                                    DataKeyNames="intPeriod_id" OnRowDeleting="PeriodReport_RowDeleting" OnRowCommand="PeriodReport_RowCommand"
                                    HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="PeriodReport_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="intPeriod_id" runat="server" Text='  <%# Eval("intPeriod_id")  %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="dtFromTime" HeaderText="From Time" ReadOnly="True" />
                                        <asp:BoundField DataField="dtToTime" HeaderText="To Time" ReadOnly="True" />
                                        <asp:BoundField DataField="intSession_id" HeaderText="Session" ReadOnly="True" />
                                        <asp:BoundField DataField="btrecess" HeaderText="Recess" ReadOnly="True" />
                                      
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 16px;" ImageUrl="~/images/edit.png"
                                                    CommandName="Edit" CausesValidation="false" /></ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Delete" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 16px;" ImageUrl="~/images/delete.png"
                                                    CommandName="Delete" OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');"
                                                    CausesValidation="false" /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                    <HeaderTemplate>
                        Period Entry</HeaderTemplate>
                    <ContentTemplate>
                     
                            <div class="efficacious">
                                <table style="font-weight: bolder; width: 40%; margin: 10px 0;" align="center">
                                    <tr>
                                        <td align="center" rowspan="3" width="50px">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="From Time" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" Width="90%" CssClass="input-blue" Style="float: left"
                                                runat="server" AutoPostBack="True" Font-Bold="False"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="refvdt1" runat="server" ControlToValidate="TextBox1" ValidationGroup="p1"
                                                    Display="None" ErrorMessage="Please Enter Period From Time" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValiCaEr1" runat="server" Enabled="True" TargetControlID="refvdt1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TextBox1"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" ErrorTooltipEnabled="True" Century="2000"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="mark1" runat="server" Display="None" InvalidValueMessage="Enter Valid From Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox1" ControlExtender="MaskedEditExtender2"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="VrCEer2" runat="server" Enabled="True" TargetControlID="mark1">
                                                </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="To Time" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="input-blue" Width="90%" Style="float: left"
                                                Font-Bold="False" TabIndex="1"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                    runat="server" ControlToValidate="TextBox2" Display="None" ErrorMessage="Please Enter Period To Time"
                                                    ValidationGroup="p1" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="VatCatEx2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextBox2"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" DisplayMoney="Left" ErrorTooltipEnabled="True"
                                                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="MaEVor1" runat="server" Display="None" InvalidValueMessage="Enter Valid To Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox2" ControlExtender="MaskedEditExtender1"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="MaEVor1">
                                                </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="labsess1" runat="server" Text="Session" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td style="padding-bottom: 10px">
                                            <asp:DropDownList runat="server" ID="drop1" Width="90%" Style="float: left; font-weight: normal;"
                                                OnSelectedIndexChanged="drop1_SelectedIndexChanged" TabIndex="2">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                               <%-- <asp:ListItem Value="1">Morning</asp:ListItem>
                                                <asp:ListItem Value="2">Afternoon</asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Reqor2" runat="server" ControlToValidate="drop1"
                                                ValidationGroup="p1" InitialValue="0" Display="None" ErrorMessage="Please Enter Session Value"
                                                Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                    runat="server" Enabled="True" TargetControlID="Reqor2">
                                                </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBox1" Style="margin-top: 10px; margin-left: 10px; left: 0px"
                                                runat="server" Text="Recess" Value="1" Font-Bold="False" TabIndex="3" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="2" align="center" style="padding-top: 15px">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="efficacious_send"
                                                ValidationGroup="p1" OnClick="Button1_Click" TabIndex="4" /><asp:Button ID="Button2" Visible="False"
                                                    runat="server" Text="Update" CssClass="efficacious_send" OnClick="Button2_Click" /><asp:HiddenField
                                                        ID="hid1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        
    </style>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAdmOnlineLectureCreation.aspx.cs" Inherits="frmAdmOnlineLectureCreation" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious_send {
            width: 60% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 1px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        
    </style>

    <script type="text/javascript">
        function allowOnlyNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>

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
            <li class="active1"><a href="frmAdmLectureAssign.aspx">Lecture Schedule</a></li>
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
    <div style="padding: 05px 0 0 0">
        <asp:UpdatePanel ID="updpan1" runat="server">
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
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                    <HeaderTemplate>
                                        Online Class List</HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <table width="80%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblStandard" runat="server" Text="Standard"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:DropDownList ID="drpStandard" runat="server" CssClass="select" AutoPostBack="True"
                                                            OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                                            <asp:ListItem>---Select---</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label1" runat="server" Text="Division" style="padding-left:10px"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:DropDownList ID="drpDivision" runat="server" OnSelectedIndexChanged="drpDivision_SelectedIndexChanged"
                                                            CssClass="select" AutoPostBack="True">
                                                            <asp:ListItem>---Select---</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CssClass="table  tabular-table " AllowPaging="True" Width="100%" OnRowDataBound="grvDetail_RowDataBound"
                                                            OnRowEditing="grvDetail_RowEditing" OnPageIndexChanging="grvDetail_OnPageIndexChanging"
                                                            DataKeyNames="intOnlinelecture_id" OnRowDeleting="grvDetail_RowDeleting" 
                                                            OnRowCommand="grvDetail_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="intLecture_id" runat="server" Text='  <%# Eval("intOnlinelecture_id")  %>'></asp:Label></ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:BoundField DataField="vchLecture_name" HeaderText="Lecture Number" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchstandard_name" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchDivisionName" HeaderText="Division" ReadOnly="True" />
                                                                <asp:BoundField DataField="dtLecture_date" HeaderText="Online Class Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="dtFromTime" HeaderText="From Time" ReadOnly="True" />
                                                                <asp:BoundField DataField="dtToTime" HeaderText="To Time" ReadOnly="True" />
                                                                <asp:BoundField DataField="Teacher_name" HeaderText="Teacher Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchSubjectName" HeaderText="Subject Name" ReadOnly="True" />
                                                              
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                                            CausesValidation="false" /></ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                            OnClientClick="return messageConfirm('Do you want to Delete this Record ?');"
                                                                            CausesValidation="false" /></ItemTemplate>
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
                                        Assignment</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            
                                                <br />
                                                <table width="40%" style="margin:0 0 0 2%;">
                                                    <tr>
                                                        <td id="Td1" align="left" runat="server" nowrap="nowrap" style="padding-top: 5px">
                                                            <asp:Label ID="Lal1" runat="server">Lecture Number</asp:Label>
                                                        </td>
                                                        <td id="Td2" align="right" runat="server">
                                                            <asp:TextBox ID="TextBox1" runat="server" Style="width:100%;" CssClass="input-blue" AutoPostBack="True" onkeypress="return allowOnlyNumber(event);"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                                                Display="None" ErrorMessage="Enter Lecture Name" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                                </asp:ValidatorCalloutExtender>
                                                            &#160;&#160;
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td id="Td5" align="left" runat="server" nowrap="nowrap">
                                                            <asp:Label ID="Lal3" runat="server">Standard</asp:Label>
                                                        </td>
                                                        <td id="Td6" align="left" runat="server">
                                                            <asp:DropDownList ID="DropDownList3" Style="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList3"
                                                                Display="None" ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="R4" runat="server" style="padding-top: 10px">
                                                        <td id="Td9" align="left" runat="server" nowrap="nowrap">
                                                            <asp:Label ID="Lal4" runat="server">Division</asp:Label>
                                                        </td>
                                                        <td id="Td11" align="left" runat="server">
                                                            <asp:DropDownList ID="DropDownList4" runat="server" Style="" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td id="Td7" style="padding-top: 10px" runat="server">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList4"
                                                                Display="None" ErrorMessage="Select Division" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr1" runat="server" style="padding-top: 10px">
                                                        <td id="Td3" align="left" runat="server" nowrap="nowrap">
                                                            <asp:Label ID="Label3" runat="server">Date</asp:Label>
                                                        </td>
                                                        <td id="Td4" align="left" runat="server">
                                                            <asp:TextBox ID="txtDate" runat="server" Style="width:100%;" CssClass="input-blue" AutoPostBack="True"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                                 <asp:CalendarExtender ID="calfrom" runat="server" Enabled="True" 
                                                                        Format="dd/MM/yyyy" TargetControlID="txtDate">
                                                                    </asp:CalendarExtender>
                                                        </td>
                                                        <td id="Td8" style="padding-top: 10px" runat="server">
                                                            
                                                        </td>
                                                    </tr>
                                                   
                                                     <tr id="Tr2" runat="server" style="padding-top: 10px">
                                                        <td id="Td10" align="left" runat="server" nowrap="nowrap">
                                                            <asp:Label ID="Label4" runat="server">From Time</asp:Label>
                                                        </td>
                                                        <td id="Td12" align="left" runat="server">
                                                             <asp:TextBox ID="TextBox3" Width="100%" CssClass="input-blue" Style="float: left"
                                                runat="server" AutoPostBack="True" Font-Bold="False"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="refvdt1" runat="server" ControlToValidate="TextBox3" ValidationGroup="p1"
                                                    Display="None" ErrorMessage="Please Enter Period From Time" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValiCaEr1" runat="server" Enabled="True" TargetControlID="refvdt1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TextBox3"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" ErrorTooltipEnabled="True" Century="2000"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="mark1" runat="server" Display="None" InvalidValueMessage="Enter Valid From Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox3" ControlExtender="MaskedEditExtender2"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="VrCEer2" runat="server" Enabled="True" TargetControlID="mark1">
                                                </asp:ValidatorCalloutExtender>
                                                                
                                                        </td>
                                                        <td id="Td13" style="padding-top: 10px" runat="server">
                                                            
                                                        </td>
                                                    </tr> 


                                                    <tr id="Tr3" runat="server" style="padding-top: 10px">
                                                        <td id="Td14" align="left" runat="server" nowrap="nowrap">
                                                            <asp:Label ID="Label5" runat="server">To Time</asp:Label>
                                                        </td>
                                                        <td id="Td20" align="left" runat="server">
                                                             <asp:TextBox ID="TextBox4" Width="100%" CssClass="input-blue" Style="float: left"
                                                runat="server" AutoPostBack="True" Font-Bold="False"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ValidationGroup="p1"
                                                    Display="None" ErrorMessage="Please Enter Period From Time" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="refvdt1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextBox4"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" ErrorTooltipEnabled="True" Century="2000"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Display="None" InvalidValueMessage="Enter Valid From Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox4" ControlExtender="MaskedEditExtender2"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="mark1">
                                                </asp:ValidatorCalloutExtender>
                                                                
                                                        </td>
                                                        <td id="Td21" style="padding-top: 10px" runat="server">
                                                            
                                                        </td>
                                                    </tr> 

                                                   
                                                    <tr id="Temp2" runat="server">
                                                        <td id="Td25" align="left" runat="server" nowrap="nowrap" style="padding-top: 10px">
                                                            <asp:Label ID="Lal8" runat="server" Font-Bold="False">Teacher Name</asp:Label>
                                                        </td>
                                                        <td id="Td15" runat="server" align="left" style="padding-top: 10px">
                                                            <asp:DropDownList ID="DropDownList8" Style="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td id="Td16" runat="server">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Select Teacher Name"
                                                                ControlToValidate="DropDownList8" Display="None"></asp:RequiredFieldValidator>
                                                            &#160;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="Temp3" runat="server">
                                                        <td id="Td17" align="left" runat="server" nowrap="nowrap" style="padding-top: 10px">
                                                            <asp:Label ID="Lal9" runat="server" Font-Bold="False">Subject</asp:Label>
                                                        </td>
                                                        <td id="Td18" runat="server" align="left" style="padding-top: 10px">
                                                            <asp:DropDownList ID="DropDownList9" Style="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td id="Td19" runat="server">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Subject"
                                                                ControlToValidate="DropDownList9" Display="None"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9">
                                                                </asp:ValidatorCalloutExtender>
                                                            &#160;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td colspan="2" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td valign="top" align="left">
                                                                        <asp:Button ID="Button1" runat="server" Text="Submit"
                                                                            CssClass="efficacious_send" OnClick="Button1_Click" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:Button ID="Button2" runat="server" Style="margin-left: 45px;" Visible="False"
                                                                            Text="Update" CssClass="efficacious_send" OnClick="Button2_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                            ForeColor="Black" MaxLength="20" Visible="False" ValidationGroup="b" Width="130px"></asp:TextBox>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #TextArea1
        {
            width: 125px;
            margin-left: 10px;
        }
        .style1
        {
            height: 20px;
        }
    </style>
    <script type="text/javascript">
        function CheckDate(ctrl) {
            var dt = new Date();
            var cdt = Date.parse(ctrl.value);
            if (cdt > dt) {
                alert('Date greater than Today');
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
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
</asp:Content>

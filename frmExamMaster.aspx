<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmExamMaster.aspx.cs" Inherits="frmExamMaster" Title="E-Smarts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript">
        function checkvalidation() {
            var txtParticular = document.getElementById("<%=txtExam.ClientID %>").value;
            if (txtParticular == '') {
                alert('Exam field should not be blank');
                return false;
            }

            function ConfirmDelete() {
                var del = confirm('Do You Really Want To Delete Selected Record?');
                if (del) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }
    </script>

    <style type="text/css">
        .style1
        {
            width: 50%;
            font-family: Verdana;
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
            border: 1px solid green;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .search
        {
            border: 1px solid green !important;
            padding: 3px;
        }
        .efficacious_Submit
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 130% !important;
            background: #6cb200;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 36px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
            top: -6px;
        }
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .mGridnew
        {
            width: 100%;
            background-color: #fff;
            border: solid 0px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGridnew td
        {
            border: solid 1px #c1c1c1;
            color: #717171;
            text-align:center;
        }
        .mGridnew th
        {
            padding: 4px 2px;
            color: #fff;
            background: #3498db;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .mGridnew tr
        {
            height: 21px;
        }
        .mGridnew .alt
        {
            background: #fff;
        }
        .mGridnew .pgr
        {
            background: #424242;
        }
        .mGridnew .pgr table
        {
            margin: 5px 0;
        }
        .mGridnew .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 0px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGridnew .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGridnew .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
        a
        {
            text-decoration: none;
        }
        a
        {
            text-decoration: none;
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
            <li class="active1"><a >Exam Master</a></li>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Details</HeaderTemplate>
                                    <ContentTemplate>
                                        <table width="30%">
                                           <tr>
                                                
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Standard"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:DropDownList ID="drpSTD" runat="server" CssClass="form-control" 
                                                          AutoPostBack="True" onselectedindexchanged="drpSTD_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                      </asp:DropDownList>
                                                </td>
                                               
                                            </tr>
                                            </table>
                                             <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grdExam" runat="server"
                                                    AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="70%" 
                                                        DataKeyNames="intExam_id" EmptyDataText="No Records Found" 
                                                        onrowdeleting="grdExam_RowDeleting" onrowediting="grdExam_RowEditing">
                                                        <Columns>
                                                         <asp:BoundField DataField="vchExamination_name" HeaderText="Examination" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="intMaxMark" HeaderText="Total Marks" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="intMinMark" HeaderText="Passing Marks" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                        ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                                        ImageUrl="~/images/delete.png" OnClientClick="return ConfirmDelete();" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image></ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                                        PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                                        Enabled="True">
                                                    </asp:ModalPopupExtender>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Exam Entry" Visible="true">
                                    <HeaderTemplate>
                                        Exam Entry</HeaderTemplate>
                                    <ContentTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
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
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:DropDownList ID="ddlSTD" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                      </asp:DropDownList>

                                                       <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                          </div>      
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>

                                                  <tr>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Examination Type"></asp:Label>
                                                </td>
                                                <td>
                                          <asp:DropDownList ID="ddlExamType" runat="server" AutoPostBack="True"   CssClass="form-control ">
                                          <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Exam"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExam" runat="server" AutoPostBack="True" CssClass="selectf"
                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Passing Marks"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassing" runat="server" AutoPostBack="True" CssClass="selectf"
                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="3"></asp:TextBox>
                                                         <asp:FilteredTextBoxExtender ID="Fbte1" runat="server" TargetControlID="txtPassing"
                                                                FilterType="Numbers" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text="Total Marks"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMax" runat="server" AutoPostBack="True" CssClass="selectf"
                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="3"></asp:TextBox>
                                                         <asp:FilteredTextBoxExtender ID="Fbte2" runat="server" TargetControlID="txtMax"
                                                                FilterType="Numbers" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    &nbsp;
                                                </td>
                                                <td>
                                               

                                                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" OnClientClick="return checkvalidation();"
                                                       CssClass="efficacious_send"  Text="Sumbit" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>

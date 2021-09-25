<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmNewInquiry.aspx.cs" Inherits="frmNewInquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Admission <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li class="active1"><a>Registration Form</a></li>
            <%--<li><a href="frmAdmStudentProfile.aspx">Student Admission</a></li>
            <li><a href="FrmStaffResignation.aspx">Staff Resignation</a></li>--%>
            <li><a href="frmPromotionDemotion.aspx">Student Promotion/Demotion</a></li>
            <li><a href="frmAdmissionCancel.aspx">Admission Cancelation</a></li>            
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
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <left>
<table width="100%">
    <tr>
        <td align="left">
            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                
                CssClass="table  tabular-table " PageSize="20" Width="100%" 
                                                                
                DataKeyNames="intInquiry_id" onrowdeleting="grvDetail_RowDeleting" 
                onrowediting="grvDetail_RowEditing">
                <Columns>
                    <asp:BoundField DataField="vchInquiry_no" HeaderText="Enquiry No" 
                        ReadOnly="True" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="dtInquiryDate" HeaderText="Enquiry Date" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchName" HeaderText="First Name" ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchMiddleName" HeaderText="Middle Name" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchLastName" HeaderText="Last Name" ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="intstandard_id" HeaderText="Standard" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="dtDOB" HeaderText="D.O.B." ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchFatherMobile" HeaderText="Mobile" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" ImageUrl="~/images/edit.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Selected Student" >
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="true"                                                                           
                                                                            ImageUrl="~/images/action_success.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</left>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="50%" style="text-align: right">
                                                    <tr>
                                                        <td align="justify" class="style1">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>

                                <td class="style1" align="left">
                                    <asp:Label ID="lblInquiryNo" runat="server" Text="Enquiry No" Font-Size="12px" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td class="style2" align="left">
                                    <asp:TextBox ID="txtInquiryNo" Width="320px" runat="server" 
                                        CssClass="input-blue" Visible="False" MaxLength="20"></asp:TextBox>


                                </td>
                            </tr>
                             <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="Label7" runat="server" Font-Size="12px" Text="Academic Year"></asp:Label>


                                    &nbsp;<asp:Label ID="Label8" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left" style="padding-left: 4px" >
                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" Width="320px">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo18" runat="server" Font-Size="12px" Text="Standard"></asp:Label>


                                    &nbsp;<asp:Label ID="Label1" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left" style="padding-left: 4px">
                                    <asp:DropDownList ID="drpStandard" runat="server" Width="320px" >
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
</asp:DropDownList>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo0" runat="server" Text="Candidate First Name" Font-Size="12px"></asp:Label>


                                    &nbsp;<asp:Label ID="Label3" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCondidatename" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="321px"></asp:TextBox>


                                </td>
                            </tr>
                              <%--<tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="Label9" runat="server" Text="Candidate Middle Name" Font-Size="12px"></asp:Label>


                                   
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMiddleName" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="320px"></asp:TextBox>


                                </td>
                            </tr>--%>
                              <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="Label12" runat="server" Text="Candidate Last Name" Font-Size="12px"></asp:Label>


                                    &nbsp;<asp:Label ID="Label13" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLastName" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="320px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo15" runat="server" Text="Date Of Birth" Font-Size="12px"></asp:Label>


                                    &nbsp;<asp:Label ID="Label4" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDOB" CssClass="input-blue" runat="server" MaxLength="50" 
                                        Width="320px"></asp:TextBox>


                                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtDOB"
                                        runat="server" Enabled="True"></asp:CalendarExtender>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo17" runat="server" Text="Gender" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpGender" runat="server" Width="320px">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
<asp:ListItem Text="Male" Value="1"></asp:ListItem>
<asp:ListItem Text="Female" Value="2"></asp:ListItem>
</asp:DropDownList>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo1" runat="server" Text="Telephone No" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTelNo" CssClass="input-blue" runat="server" MaxLength="12" 
                                        Width="320px"></asp:TextBox>


                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtTelNo"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo2" runat="server" Text="Father name" Font-Size="12px"></asp:Label>

                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfatherName" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="320px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo3" runat="server" Text="Father Mobile" Font-Size="12px"></asp:Label>


                                    &nbsp;<asp:Label ID="Label6" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFatherMobile" CssClass="input-blue" runat="server" MaxLength="10"
                                        Width="320px"></asp:TextBox>


                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtFatherMobile"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo4" runat="server" Text="Father Email" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFatherEmail" CssClass="input-blue" runat="server" 
                                        Width="320px" MaxLength="50"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo5" runat="server" Text="Father Occupation" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFatherOccupation" CssClass="input-blue" runat="server" 
                                        Width="321px" MaxLength="50"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo6" runat="server" Text="Mother name" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherName" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="320px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo7" runat="server" Text="Mother Mobile" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherMobile" CssClass="input-blue" runat="server" MaxLength="10"
                                        Width="320px"></asp:TextBox>


                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtMotherMobile"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo8" runat="server" Text="Mother Email" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherEmail" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="319px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo9" runat="server" Text="Mother Occupation" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherOccupation" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="320px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo10" runat="server" Text="Address" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAddress" CssClass="input-blue" runat="server" Height="50px" 
                                        Width="320px" TextMode="MultiLine"
                                        MaxLength="250"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo11" runat="server"  Text="Pincode" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPincode" runat="server" MaxLength="10" Width="320px" 
                                        CssClass="input-blue"></asp:TextBox>


                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtPincode"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo12" runat="server" Text="State" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtState" CssClass="input-blue" runat="server" MaxLength="20" 
                                        Width="321px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo13" runat="server" Text="City" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCity" CssClass="input-blue" runat="server" MaxLength="20" 
                                        Width="320px"></asp:TextBox>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblInquiryNo16" runat="server" Text="Remark" Font-Size="12px"></asp:Label>


                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRemark" CssClass="input-blue" runat="server" Width="320px" 
                                        Height="50px" TextMode="MultiLine"
                                        MaxLength="250"></asp:TextBox>


                                </td>
                            </tr>
                                       
                                        <tr>
                                            <td align="left" class="style1">
                                                <asp:Label ID="Label2" runat="server" Text="Amount" Font-Size="12px"></asp:Label>


                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAmount" CssClass="input-blue" runat="server" MaxLength="4" 
                                                    Width="320px"></asp:TextBox>


                                </td>
                            </tr>             <tr>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="padding-left:-20px">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click"  />


                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px" 
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" 
                                                                            onclick="btnClear_Click" />


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


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTCForm.aspx.cs" Inherits="frmTCForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <title>Transfer Certificate</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style>
        body {font-family: verdana;}.frm_heading h1 {text-align:center;margin:40px 00;}
        td, th {}
        .txt_cls{border:1px solid #3498db; margin:5px; padding:5px;
        }
       .label_cls{float:left}
        .auto-style1 {height: 22px;}
        #DropDownList1 {border:1px solid #3498db}
        table{text-align:left}
        .auto-style2 {float:left;margin-left:100px}
        .clr{clear:both}
       .sign_panel h4{text-align:center}
   </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel runat="server" ID="Up">
                        <ContentTemplate>
<div class="tabular">
                                            <table width="100%">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 0px" valign="middle">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged" >
                                                            <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            
                                                            <%--<asp:ListItem Value="1" Text="I"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="II"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="III"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="IV"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="V"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblDIV" runat="server" Text="Section" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize" AutoPostBack="True" onselectedindexchanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
<%--                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="textsize"></asp:Label>
                                                    </td>--%>
<%--                                                    <td align="left" valign="middle">
                                                         <asp:DropDownList ID="ddlGender" runat="server"  
                                                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    <asp:ListItem  Value="2">Female</asp:ListItem>
                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                </asp:DropDownList>
                                                    </td>--%>
                                                     <td>
                                                    <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="bottom" CssClass="efficacious_send">
                                                     <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                                           <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                        <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="textsize" 
                                                            OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    </td>
                                                     <td align="center" valign="middle">
                                                    <asp:Label ID="Label27" runat="server" Text="Exam" CssClass="textsize" Visible="false"></asp:Label>

                                                    </td>

                                                     <td align="left" valign="bottom" CssClass="efficacious_send">
                                                     <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" CssClass="textsize" Visible="false" ></asp:DropDownList>
                                                    
                                                    </td>
                                                    <td style="padding-left: 12px;">
                                                    <asp:Button ID="show" runat="server" CssClass="btn btn-sm btn-primary" Text="Show" onclick="show_Click" Visible="false" />
                                                    </td>
                                                    
                                                   
                                                </tr>
                                            </table>
                                        </div>

      <div>
    <CR:CrystalReportViewer ID="AdmissionReport" runat="server" AutoDataBind="true" />
    </div>                    

    <div class="content-header">
       <div class="frm_heading"><h1>TRANSFER CERTIFICATE</h1></div>
<div class="main_content">   <center>
         <div class="frm_content" style="width:100%">
             
<div class="sr_no">
     <tr>
            <div style="float:left; margin-left:40px">
            <td align="left" class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Sl No." Visible="false"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Admission No."></asp:Label>
                </td>
                <td nowrap="nowrap" align="left">
                    <asp:TextBox class="txt_cls" ID="txtsrno" runat="server" Width="137px" Visible="false"></asp:TextBox>
                    <asp:TextBox  class="txt_cls" ID="txtAdmission" runat="server" style="width:200px"></asp:TextBox>
                    </td>
                    </div>
                    <div style="float:right; margin-right:50px">
               <tr>
                   <td align="left" class="auto-style2">
                   <asp:Label ID="Label30" runat="server" Text="Board Registration No."></asp:Label>
                </td>
            <td nowrap="nowrap" align="left">
            <asp:TextBox  class="txt_cls" ID="txtBoardRegi" runat="server" style="width:200px"></asp:TextBox>
                </td>
               </tr>
        </div>

        
            
        </tr>
           
        
</div>
     <table style="width:100%">
         <tbody>
       
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="1. Name of pupil"></asp:Label></td>
            <td nowrap="nowrap" align="left">
                <asp:TextBox class="txt_cls" ID="txtnameofpupil" AutoPostBack="True" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="2. Father's Guardian's Name"></asp:Label></td>
            <td nowrap="nowrap" align="left">
                <asp:TextBox class="txt_cls" ID="txtfathername" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label5" runat="server" Text="3. Nationality"></asp:Label></td>
            <td nowrap="nowrap" align="left" class="auto-style1">
                <asp:TextBox class="txt_cls" ID="txtNationality" runat="server" AutoPostBack="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label6" runat="server" Text="4. Whether the candidate belongs to Schedule Caste or Schedule Tribe"></asp:Label></td>
            <td nowrap="nowrap" align="left">
                <asp:DropDownList ID="ddlscst" runat="server" style="width:26%; height:40px; margin-left:5px"  >
                    
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label7" runat="server" Text="5. Date of first admission in the School with class"></asp:Label></td>
            <td nowrap="nowrap" align="left">
                <asp:TextBox class="txt_cls" ID="txtDOA" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDOA" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>
             <asp:Label ID="Label31" runat="server" Text="(Class)"></asp:Label> 
                <asp:TextBox ID="txtAdmissionClass" runat="server"  class="txt_cls"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label8" runat="server" Text="6. Date of birth (in Christian Era) according to Admission Register"></asp:Label></td>
            <td nowrap="nowrap" align="left">
                <asp:TextBox class="txt_cls" ID="txtDOBfig" runat="server"></asp:TextBox>
                <asp:Label ID="Label28" runat="server" Text="(in words)" Visible="false"></asp:Label> 
                <asp:TextBox ID="txtDOBword" runat="server"  class="txt_cls" Visible="false"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOBfig" Format="dd/MMMM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>

            </td>
        </tr>
        <tr>
            <td align="left" class="auto-style2">
                <asp:Label ID="Label9" runat="server" Text="7. Class in which the pupil last studied (in figures)"></asp:Label></td>
            <td nowrap="nowrap" align="left">
                <asp:TextBox class="txt_cls" ID="txtlastclassfig" runat="server"></asp:TextBox>
                <asp:Label ID="Label29" runat="server" Text="(in words)"></asp:Label> 
                <asp:TextBox ID="txtlastclassword" runat="server"  class="txt_cls"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label10" runat="server" Text="8. School / Board Annual examination last taken with result"></asp:Label></td>
            <td>
               <asp:TextBox class="txt_cls" ID="txtannualexamlast" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label11" runat="server" Text="9. Whether failed, if so once/ twice in the same class"></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtsameclass" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2" style="float:left">
                <asp:Label ID="Label12" runat="server" Text="10. Subjects studied."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="subjectStudied1" runat="server"></asp:TextBox>
                <asp:TextBox class="txt_cls" ID="subjectStudied2" runat="server"></asp:TextBox>
                <asp:TextBox class="txt_cls" ID="subjectStudied3" runat="server"></asp:TextBox>
                <asp:TextBox class="txt_cls" ID="subjectStudied4" runat="server"></asp:TextBox>
                <asp:TextBox class="txt_cls" ID="subjectStudied5" runat="server"></asp:TextBox>
                <asp:TextBox class="txt_cls" ID="subjectStudied6" runat="server"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="auto-style2" style="float:left">
                <asp:Label ID="Label13" runat="server" Text="11. Whether qualified for promotion to the higher class"></asp:Label>
            <td><asp:TextBox ID="txtpromo" runat="server"  class="txt_cls"></asp:TextBox>
                <asp:Label ID="Label14" runat="server" Text="&nbsp If so in which class(In fig)"></asp:Label>
                <asp:TextBox ID="txtHigherclassFig" runat="server"  class="txt_cls"></asp:TextBox>
                <asp:TextBox ID="txtHigherclassWord" runat="server"  class="txt_cls"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Text="(in words)"></asp:Label>                                                       
            </td>
            </tr>
            
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label16" runat="server" Text="12. Month upto which the (pupil has paid) school dues paid."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtduepaid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label17" runat="server" Text="13. Any fee concession availed of: if so, the nature of such concession"></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtAny" runat="server"></asp:TextBox></td>
        </tr>  
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label18" runat="server" Text="14. Total No. of working days."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txttotalday" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label19" runat="server" Text="15. Total No. of working days present."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtWorkingDays" runat="server"></asp:TextBox></td>
        </tr>  
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label20" runat="server" Text="16. Whether NCC Cadet / Boy Scout / Girl Guide (details may be given)."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtNCC" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label21" runat="server" Text="17. Games played or extra curricular activities in which the pupil usually took part(mention achievement level there in)."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtCurricular" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label22" runat="server" Text="18. General conduct"></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtGeneral" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label23" runat="server" Text="19. Date of application for certificate."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtDOAC" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDOAC" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>

                </td>

        </tr>  
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label24" runat="server" Text="20. Date of issue of certificate."></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtDOIC" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDOIC" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>

                </td>
        </tr>                                          
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label25" runat="server" Text="21. Reasons for leaving the school"></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtReasons" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label26" runat="server" Text="22. Any other remarks"></asp:Label></td>
            <td>
                <asp:TextBox class="txt_cls" ID="txtRemarks" runat="server" style="Height:auto" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
         </tbody>
        </table>
    <br />
    
    <div>
    <table>
    <tr>
    <td>
    <asp:Button ID="btnview" runat="server" CssClass="btn btn-sm btn-primary" Text="Preview" onclick="view_Click"  />
    </td>
    <td>
    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" onclick="Submit_Click" Visible="false"  />
    </td>
    <td>
    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-primary" Text="Update" onclick="Update_Click" Visible="false"  />
    </td>
    </tr>
    </table>
    
    </div>

    

   
    
    </div>
</div>
        <%--<div class="clr"></div>     
        <div class="sign_panel" style="padding-top:70px; width:100%">
        <div class="clsTeachSign" style="width:33%; float:left;"><h4>Signature of Class Teacher</h4></div>
        <div class="chkBy" style="width:33%; float:left;"><h4>Checked By<br />(state full name and designation)</h4></div>
        <div class="pSeal" style="width:33%; float:left;"><h4>Principal<br />Seal</h4></div> --%>  
   </div>
  
        </div>

        </ContentTemplate>
                                        </asp:UpdatePanel>

</asp:Content>


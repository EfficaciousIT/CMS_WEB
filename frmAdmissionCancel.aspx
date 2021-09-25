<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAdmissionCancel.aspx.cs" Inherits="frmAdmissionCancel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<style type="text/css">
    .modalPopup
    {
    background-color: #696969;
    filter: alpha(opacity=40);
    opacity: 0.7;
    xindex:-1;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clearfix">
    </div>
    <div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Admission <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li><a>Registration Form</a></li>
            <%--<li><a href="frmAdmStudentProfile.aspx">Student Admission</a></li>
            <li><a href="FrmStaffResignation.aspx">Staff Resignation</a></li>--%>
            <li><a href="frmPromotionDemotion.aspx">Student Promotion/Demotion</a></li>
            <li class="active1"><a href="frmAdmissionCancel.aspx">Admission Cancelation</a></li>            
        </ul>
    </div>
<section class="content">
    <div>       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="tabcon" ActiveTabIndex="1"
                    Width="99%">
                    <asp:TabPanel ID="List" HeaderText="List" runat="server">
                        <ContentTemplate>
                            <center>
                                <div class="efficacious">
                                    <table width="90%" style="margin-top: 15px;">
                                        <tr>
                                            <td align="center">
                                                <table runat="server" id="filtertable" width="100%">
                                                    <tr id="Tr1" runat="server">
                                                        <td id="Td1" runat="server">
                                                            <asp:Label ID="lblAcademicYear" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Academic Year"></asp:Label>
                                                        </td>
                                                        <td id="Td2"  align="left" runat="server">
                                                            <asp:DropDownList ID="ddlAcademiYear" runat="server" Enabled="True" Style="position: relative; top: 5px; text-align: right;" >
                                                             </asp:DropDownList>
                                                        </td>                                                        
                                                        <td id="Td5" runat="server">
                                                            <asp:Label ID="lblStdf" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                              Text="Standard"></asp:Label>
                                                        </td>
                                                        <td id="Td6" align="left" runat="server">
                                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlSTD_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td id="Td11" runat="server">
                                                           
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            Text="Submit" onclick="btnSubmit_Click" />
                                                            
                                                        </td>
                                                    </tr>
                                                      
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                <asp:GridView ID="gvList" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                   CssClass="table  tabular-table " DataKeyNames="intStudent_id" EmptyDataText="Record not Found."  Width="100%" >
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>                                                                                
                                                                                <asp:BoundField ReadOnly="True" DataField="StudentName" HeaderText="Name" />                                                                                    
                                                                                 <asp:TemplateField>                                                                                
                                                                                    <ItemTemplate>                                                                    
                                                                                    <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true">  </asp:CheckBox>                                                                    
                                                                                    </ItemTemplate>
                                                                                 </asp:TemplateField>                                                                            
                                                                            </Columns>
                                                                            <PagerStyle CssClass="pgr" />
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                          <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                                <ProgressTemplate>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                                                PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                                                Enabled="True">
                                                            </asp:ModalPopupExtender>
                                                </div>
                                            </td>
                                         
                                        </tr>
                                    </table>
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="Details" runat="server" HeaderText="Cancel Details"  >
                       <ContentTemplate>
                            <center>
                                <div class="efficacious">
                                    <table width="90%" style="margin-top: 15px;">
                                        <tr>
                                            <td align="center">
                                                <table runat="server" id="Table1" width="100%">
                                                    <tr id="Tr2" runat="server">
                                                        <td id="Td3" align="left" runat="server">
                                                            <asp:Label ID="Label1" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Academic Year"></asp:Label>
                                                        </td>
                                                        <td id="Td4"  align="center" runat="server">
                                                            <asp:DropDownList ID="drpAcademicYear" runat="server" Style="position: relative; top: 5px; text-align: right;" >
                                                             </asp:DropDownList>
                                                        </td>                                                        
                                                        <td id="Td7" align="center" runat="server">
                                                            <asp:Label ID="Label2" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                              Text="Standard"></asp:Label>
                                                        </td>
                                                        <td id="Td8" align="left" runat="server">
                                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" onselectedindexchanged="drpStandard_SelectedIndexChanged" 
                                                                 >
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td >
                                                           
                                                        &nbsp;
                                                            
                                                        </td>
                                                        <td id="Td9" runat="server">
                                                           
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" 
                                                            Text="Submit" onclick="btnCancel_Click" />
                                                            
                                                        </td>
                                                    </tr>
                                                      
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                <asp:GridView ID="gvCancelDet" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                   CssClass="table  tabular-table " DataKeyNames="intStudent_id" EmptyDataText="Record not Found."  Width="100%" >
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>                                                                                
                                                                                <asp:BoundField ReadOnly="True" DataField="StudentName" HeaderText="Name" />                                                                                    
                                                                                 <asp:TemplateField>                                                                                
                                                                                    <ItemTemplate>                                                                    
                                                                                    <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true">  </asp:CheckBox>                                                                    
                                                                                    </ItemTemplate>
                                                                                 </asp:TemplateField>                                                                            
                                                                            </Columns>
                                                                            <PagerStyle CssClass="pgr" />
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                       
                                                </div>
                                            </td>
                                         
                                        </tr>
                                    </table>
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>                   
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
</asp:Content>


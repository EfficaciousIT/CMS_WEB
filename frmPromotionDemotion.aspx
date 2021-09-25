<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmPromotionDemotion.aspx.cs" Inherits="frmPromotionDemotion" %>

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
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[id*=chkCtrlAll]").live("click", function () {
        var chkCtrlAll = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkCtrlAll.is(":checked")) {
                $(this).attr("checked", "checked");
                $("td", $(this).closest("tr")).addClass("selected");
            } else {
                $(this).removeAttr("checked");
                $("td", $(this).closest("tr")).removeClass("selected");
            }
        });
    });
    $("[id*=chkRow]").live("click", function () {
        var grid = $(this).closest("table");
        var chkCtrlAll = $("[id*=chkCtrlAll]", grid);
        if (!$(this).is(":checked")) {
            $("td", $(this).closest("tr")).removeClass("selected");
            chkCtrlAll.removeAttr("checked");
        } else {
            $("td", $(this).closest("tr")).addClass("selected");
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkCtrlAll.attr("checked", "checked");
            }
        }
    });
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
            <li class="active1"><a href="frmPromotionDemotion.aspx">Student Promotion/Demotion</a></li>
            <li><a href="frmAdmissionCancel.aspx">Admission Cancelation</a></li>            
        </ul>
    </div>
<section class="content">
    <div>       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="tabcon" ActiveTabIndex="0"
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
                                                        <td id="Td1" align="left" runat="server">
                                                            <asp:Label ID="lblAcademicYear"   runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Academic Year"></asp:Label>
                                                        </td>
                                                        <td id="Td2"  align="left" runat="server">
                                                            <asp:DropDownList ID="ddlAcademiYear" runat="server" Enabled="False" Style="position: relative; top: 5px; text-align: right;" >
                                                                                </asp:DropDownList>
                                                        </td>                                                        
                                                        <td id="Td5"  align="center" runat="server">
                                                            <asp:Label ID="lblStdf" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="From Standard"></asp:Label>
                                                        </td>
                                                        <td id="Td6" align="left" runat="server">
                                                            <asp:DropDownList ID="ddlFromSTD" runat="server"
                                                                AutoPostBack="True" 
                                                                onselectedindexchanged="ddlFromSTD_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>


                                                           <td id="Td9"  align="center" runat="server">
                                                            <asp:Label ID="Label2" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="From Division"></asp:Label>
                                                        </td>
                                                        <td id="Td10" align="left" runat="server">
                                                            <asp:DropDownList ID="ddlfromdiv" runat="server">
                                                                
                                                                 
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0"
                                                                                ErrorMessage="Please select Division" ControlToValidate="ddlfromdiv" ValidationGroup="g1"
                                                                                Font-Bold="False" ></asp:RequiredFieldValidator>
                                                        </td>
                                                       
                                                    </tr>
                                                      <tr id="Tr2" runat="server">
                                                        <td id="Td7"  align="left" runat="server">
                                                            <asp:Label ID="Label1" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="To Academic Year"></asp:Label>
                                                        </td>
                                                        <td id="Td8"  align="left" runat="server">
                                                            <asp:DropDownList ID="ddlToAcademiYear" runat="server" Style="position: relative; top: 5px; text-align: right;" >
                                                                                </asp:DropDownList>
                                                        </td>   
                                                        <td id="Td3" align="center" runat="server">
                                                            <asp:Label ID="lblStdt" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="To Standard"></asp:Label>
                                                        </td>
                                                        <td id="Td4" align="left" runat="server">
                                                            <asp:DropDownList ID="ddlToSTD" runat="server"
                                                                AutoPostBack="True" onselectedindexchanged="ddlToSTD_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>

                                                          <td id="Td13"  align="center" runat="server">
                                                            <asp:Label ID="Label3" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="To Division"></asp:Label>
                                                        </td>
                                                        <td id="Td14" align="left" runat="server">
                                                            <asp:DropDownList ID="ddltodiv" runat="server"
                                                                 >
                                                            </asp:DropDownList>

                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                                                                ErrorMessage="Please select Division" ControlToValidate="ddltodiv" ValidationGroup="g1"
                                                                                Font-Bold="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td runat="server">
                                                           
                                                        &nbsp;
                                                            
                                                        </td>
                                                        <td id="Td11" runat="server">
                                                           
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            Text="Promote" onclick="btnSubmit_Click"  ValidationGroup ="Group1"/>
                                                            
                                                        </td>
                                                        <td id="Td12" align="left" runat="server">
                                                          
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                <asp:GridView ID="gvList" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                   CssClass="table  tabular-table " DataKeyNames="intStudent_id,StudentName" EmptyDataText="Record not Found."  Width="100%" >
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>                                                                                
                                                                                <asp:BoundField ReadOnly="True" DataField="StudentName" HeaderText="Name" />                                                                                    
                                                                                 <asp:TemplateField>
                                                                                 <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkCtrlAll" runat="server" />
                                                                                </HeaderTemplate>
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
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Details" Visible="false">
                       
                    </asp:TabPanel>                   
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
</asp:Content>


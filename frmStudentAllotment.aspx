<%@ Page Title="StudentAllotment" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStudentAllotment.aspx.cs" Inherits="frmStudentAllotment" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-header">
        <h1>
            Standard Allotment
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i></a>Admission</li>
            <li class="active">Standard Allotment</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                 <tr>
                                                        <td>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="70%">
                                                                    <tr>
                                                                        <td align="center">
                                                                                <asp:Label ID="Label7" runat="server" Text="Acedemic Year" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlAcademiYear" runat="server"  AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlAcademiYear_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                         <td align="center">
                                                                                <asp:Label ID="Label6" runat="server" Text="Standard" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlSTD" runat="server"  
                                                                                    AutoPostBack="True" onselectedindexchanged="ddlSTD_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                      
                                                                       <td align="center">
                                                                                <asp:Label ID="Label10" runat="server" Text="Cast" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlCast" runat="server"  
                                                                                    AutoPostBack="True" onselectedindexchanged="ddlCast_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                                         </td>

                                                                    </tr>
                                                                </table>
                                                     
                                            
                                                                <table width="70%">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="70%" 
                                                                DataKeyNames="intTest_id,intStandard_id,vchFirstName,vchLastName,intAcademic_id,intCat_Id" onrowediting="grvDetail_RowEditing" >
                                                                <Columns>
                                                                    <asp:BoundField DataField="intTest_id" HeaderText="Admission ID" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchSTD" HeaderText="Standard" ReadOnly="True" />
                                                                    <asp:BoundField DataField="candiateName" HeaderText="Student Name" ReadOnly="True"/>
                                                                    <asp:BoundField DataField="intAcademic_id" HeaderText="Academic year"    ReadOnly="True" Visible="False"/>
                                                                    <asp:BoundField DataField="intCat_Id" HeaderText="Category" ReadOnly="True"  Visible="False"  />
                                                                   <asp:TemplateField>
                                                                    <ItemTemplate>                                                                    
                                                                        <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true">
                                                                        </asp:CheckBox>
                                                                    </ItemTemplate>
                                                                 </asp:TemplateField>
                                                                </Columns>
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
                                                            </table>
                                                      </div>
                                                        </td>
                                                 </tr>
                                                     <tr >
                                                   
                                                      <td align="right" >
                                                                <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                                    Text="Assign" onclick="btnSubmit_Click" />
                                                       </td>  <td></td>
                                                     </tr>      
                                                          
                                      
                                                 
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Visible="false">
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
           </table>
              
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


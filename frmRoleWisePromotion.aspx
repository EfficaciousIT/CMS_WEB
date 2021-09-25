<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmRoleWisePromotion.aspx.cs" Inherits="frmRoleWisePromotion" %>

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
<div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Setting <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li> <a href="frmChanegePassword.aspx"> Change Password </a></li>
             <li class="active1"><a href="frmRoleWisePromotion.aspx"> Promotion</a></li>             
        </ul>
    </div>
<section class="content">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" Width="100%" 
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="100%">
                                         <tr>
                                            <td align="center">
                                                    <asp:Label ID="Label3" runat="server" Text="Role" ></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                    <asp:DropDownList ID="drpRole" runat="server"  AutoPostBack="True" 
                                                        onselectedindexchanged="drpRole_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="80%" AllowPaging="false" 
                                                        DataKeyNames="intTransUser_id" onrowediting="grvDetail_RowEditing">
                                                        <Columns>
                                                        <asp:BoundField DataField="intUserType_id" HeaderText="Role" ReadOnly="True" 
                                                                Visible="False"/>
                                                        <asp:BoundField DataField="intUser_id" HeaderText="Name" ReadOnly="True" />
                                                        <asp:BoundField DataField="intAcademic_id" HeaderText="Academic Year" ReadOnly="True" />
                                                        <asp:BoundField DataField="intDepartment_id" HeaderText="Department" ReadOnly="True" />
                                                        <asp:BoundField DataField="intDesignation_Id" HeaderText="Designation" ReadOnly="True" />
                                                         <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" />
                                                        <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate> 
                                                                    <asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" ImageUrl="~/images/edit.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>                                                          
                                                           <asp:TemplateField HeaderText="Delete" >
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="true"
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record ?');"
                                                                        ImageUrl="~/images/delete.png" />
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
                            <asp:TabPanel runat="server" ID="TB2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious">
                                            <table width="50%">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                 
                                                 <tr>
                                                    <td align="center">
                                                                                <asp:Label ID="Label2" runat="server" Text="From Academic Year" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlAcademiYear" runat="server" Enabled="False" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                         </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label1" runat="server" Text="To Academic Year"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlToAcademicYear" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    <tr>
                                                                        <td align="center">
                                                                                <asp:Label ID="Label7" runat="server" Text="Role" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlRole" runat="server"  AutoPostBack="True" onselectedindexchanged="ddlRole_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                         </tr>
                                                                        
                                                                         <tr>
                                                                         <td align="center">
                                                                                <asp:Label ID="lblDept" runat="server" Text="Department" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlDepartment" runat="server"  
                                                                                    AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlDepartment_SelectedIndexChanged" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                        </tr>
                                                                         <tr>
                                                                       <td align="center">
                                                                                <asp:Label ID="lblDesi" runat="server" Text="Designation" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlDesignation" runat="server"  
                                                                                    AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlDesignation_SelectedIndexChanged"  >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                           </tr>
                                                                         <tr>
                                                                          <td align="center">
                                                                                <asp:Label ID="lblTchr" runat="server" Text="Name" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlName" runat="server"  
                                                                                    AutoPostBack="True" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                    </tr>
                                                                      <tr>
                                                                         <td align="center">
                                                                                <asp:Label ID="lblStd" runat="server" Text="Standard" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlSTD" runat="server"  AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlSTD_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                        </tr>
                                                                        <tr>
                                                                         <td align="center">
                                                                                <asp:Label ID="lblDiv" runat="server" Text="Division" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlDIV" runat="server" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                        </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            Text="Submit" onclick="btnSubmit_Click"/>
                                                    </td>
                                                    <td align="right">
                                                      
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>


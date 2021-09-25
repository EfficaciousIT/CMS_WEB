<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmModuleAssignment.aspx.cs" Inherits="frmModuleAssignment" %>

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
            Module Assignment
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li class="active">Module Assignment</li>
        </ol>
    </div>
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
                                            List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                <table width="50%">
                                                <tr>
                                                                        <td align="center">
                                                                                <asp:Label ID="Label2" runat="server" Text="Academic Year" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlAcademiYear" runat="server" Enabled="False" >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                         </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                                <asp:Label ID="Label7" runat="server" Text="Role" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlRole" runat="server"  AutoPostBack="True" onselectedindexchanged="ddlRole_SelectedIndexChanged" 
                                                                                    >
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
                                                                                <asp:Label ID="lblTchr" runat="server" Text="Teacher" ></asp:Label>
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlTeacher" runat="server"  
                                                                                    AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlTeacher_SelectedIndexChanged"  >
                                                                                </asp:DropDownList>
                                                                         </td>
                                                                    </tr>
                                                                     
                                                                         <tr>
                                                                          <td align="center">
                                                                                
                                                                         </td>
                                                                         <td align="left" valign="top">
                                                                               <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                                                   Text="Assign" onclick="btnSubmit_Click" />
                                                                         </td>
                                                                    </tr>
                                                                </table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="50%" 
                                                                DataKeyNames="intModule_Id" >
                                                                <Columns>
                                                                 <asp:BoundField DataField="vchModule" HeaderText="Module" ReadOnly="True" />
                                                                    
                                                                   <asp:TemplateField>
                                                                    <ItemTemplate>                                                                    
                                                                    <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true">  </asp:CheckBox>
                                                                      <%--  <asp:CheckBox ID="chkCtrl" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server"
                                                                        AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("status").ToString())%>'>--%>
                                                                    </ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Status" Visible="False">
                                                            <ItemTemplate>
                                                               <%-- <asp:Label ID="Label1" runat="server" Text='<%# Eval("status") %>' Visible="false" />--%>
                                                                <asp:DropDownList ID="drpStatus" runat="server" AutoPostBack="true" CssClass="selectf"
                                                                    OnSelectedIndexChanged="Status_OnSelectedIndexChanged">
                                                                    <asp:ListItem Text="Y" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="N" Value="1"></asp:ListItem>
                                                                </asp:DropDownList>
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
                                                        </td>
                                                        <td>    </td>
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
        </center>
    </div>
</asp:Content>


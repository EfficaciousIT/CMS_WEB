<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmOnlineNotice.aspx.cs" Inherits="frmOnlineNotice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input[type=text]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .style1 select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .efficacious_send
        {
            width: 20% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <style>
        input[type="image"]
        {
            width: 50% !important;
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
                return false;
            }
        }

        function ConfirmInsertUpdate() {
            //            if (Page_ClientValidate()) {
            var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
            if (btn == 'Submit') {
                var del = confirm('Do You Really Want To Save Entered Record?');
                if (del) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var del = confirm('Do You Really Want To Update Entered Record?');
                if (del) {
                    return true;
                }
                else {
                    return false;
                }

            }
            //            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix">
    </div>
    <div class="content-header pd-0">
        <ul class="top_nav1">
            <li><a>Online Class Details <i class="fa fa-angle-double-right" aria-hidden="true"></i>
            </a></li>
            <li class="active1"><a>Online Class Details</a></li>
        </ul>
    </div>
    <section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="left">
                         <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                   Online Class Details</HeaderTemplate>
                                <ContentTemplate>
                                     <table width="100%">
                                        
                                         <tr>
                                             <td align="left">
                                            
                                                 <asp:GridView ID="grdNotice" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="table  tabular-table " PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                     DataKeyNames="intOnlineNotice_id" 
                                                     EmptyDataText="No Records Found" OnRowDeleting="grdNotice_RowDeleting" 
                                                     OnRowEditing="grdNotice_RowEditing">
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="Subject" HeaderText="Meeting Details" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="Notice" HeaderText="Description/Link" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="vchDivisionName" HeaderText="Division" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>

                                                          <asp:BoundField DataField="vchMeetingId" HeaderText="Meeting ID" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>

                                                           <asp:BoundField DataField="vchpassword" HeaderText="Password" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>

                                                        <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                ImageUrl="~/images/edit.png" />
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     </Columns>
                                                 </asp:GridView>
                                             </td>
                                         </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1" >
                                <HeaderTemplate>
                                    New Entry</HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                           
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                        &nbsp;
                                        </td>
                                            <td>
                                                <asp:Label ID="lblUserType" runat="server" Text="User Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpUserType" runat="server" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="drpUserType_SelectedIndexChanged" Width="40%">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                     <asp:ListItem Value="1" Selected="True">Student</asp:ListItem>
                                                </asp:DropDownList >
                                            </td>
                                            </tr>
                                             
                                            <tr>
                                            <td>
                                            &nbsp;
                                            </td>
                                            <td align="left" >
                                                <asp:Label ID="lblStandard" runat="server" Text="Standard" Visible="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged" Width="40%">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            </tr>
                                             <tr>
                                            <td>
                                            &nbsp;
                                            </td>
                                            <td align="left" >
                                                <asp:Label ID="Label3" runat="server" Text="Division" Visible="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="drpDivision_SelectedIndexChanged" Width="40%" Visible="true">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            </tr>
                                      
                                       <tr>
                                         <td>
                                        &nbsp;
                                        </td>
                                             
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Lecture Number"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="drpLectureName" runat="server" AutoPostBack="True" Width="40%" OnSelectedIndexChanged="drpLectureName_SelectedIndexChanged" Visible="true">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                               
                                        </tr>
                                      
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Online Class Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlecturedate" CssClass="input-blue" runat="server" Width="40%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                </tr>
                                                
                                                      <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" CssClass="input-blue" runat="server" Width="40%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                </tr>
                                                      <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox2" CssClass="input-blue" runat="server" Width="40%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                </tr>

                                         <tr>
                                                  <td>
                                                    &nbsp;
                                                </td>
                                                  <td id="Td1" align="left" runat="server" nowrap="nowrap" style="padding-top: 10px">
                                                            <asp:Label ID="Lal8" runat="server" Font-Bold="False">Teacher Name</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList8" Style="" runat="server" AutoPostBack="True" Enabled="false"  Width="40%">
                                                            </asp:DropDownList>
                                                        </td>
                                                          <td>
                                                    &nbsp;
                                                </td>
                                                        </tr>

                                                          <tr>
                                                  <td>
                                                    &nbsp;
                                                </td>
                                                  <td id="Td2" align="left" runat="server" nowrap="nowrap" style="padding-top: 10px">
                                                            <asp:Label ID="Label8" runat="server" Font-Bold="False">Subject</asp:Label>
                                                            <font color="red" style="position: relative; top: -8px;" size="1px">*</font>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpsubject" Style="" runat="server" AutoPostBack="True" Enabled="false"  Width="40%">
                                                            </asp:DropDownList>
                                                        </td>
                                                          <td>
                                                    &nbsp;
                                                </td>
                                                        </tr>
                                        <tr>
                                         <td>
                                        &nbsp;
                                        </td>
                                           <%-- <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Issue Date" ></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfromdate" CssClass="input-blue" runat="server" Width="40%"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calfrom" runat="server" Enabled="True" 
                                                        Format="dd/MM/yyyy" TargetControlID="txtfromdate">
                                                    </asp:CalendarExtender>
                                                </td>
                                                </tr>--%>
                                              <%--  <caption>
                                                    &nbsp;
                                            </caption>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label17" runat="server" Text="End Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTodate" CssClass="input-blue" runat="server" Width="40%"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtTodate">
                                                </asp:CalendarExtender>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Meeting Details"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtSubject" CssClass="input-blue" runat="server" Height="30px" 
                                                        Width="40%" MaxLength="50"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="Label16" runat="server" Text="Description/Link"></asp:Label>
                                                        <font color="red" style="position: relative; top: -8px;" size="1px">*</font>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtNotice" CssClass="input-blue" runat="server" Height="68px" TextMode="MultiLine" 
                                                            Width="40%" MaxLength="500"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Meeting ID"></asp:Label>
                                                    <font color="red" style="position: relative; top: -8px;" size="1px">*</font>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtusername" CssClass="input-blue" runat="server" Height="30px" 
                                                        Width="40%" MaxLength="50"></asp:TextBox>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtpassword" CssClass="input-blue" runat="server" Height="30px" 
                                                        Width="40%" MaxLength="50"></asp:TextBox>
                                                </td>
                                            </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                                                            BackgroundCssClass="modalPopup" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="UpdateProgress1" TargetControlID="UpdateProgress1">
                                                        </asp:ModalPopupExtender>
                                                        <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                                    OnClick="btnSubmit_Click" Text="Submit" />
                                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="efficacious_send" 
                                                            OnClick="btnUpdate_Click" Text="Update" />
                                                            </ContentTemplate>

                                                             <Triggers>

                                                               <asp:PostBackTrigger ControlID = "btnSubmit" />
                                                            <asp:PostBackTrigger ControlID = "btnUpdate" />
                                                        </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </tr>
                                        </tr>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
                prm.add_beginRequest(BeginRequestHandler);
                // Raised after an asynchronous postback is finished and control has been returned to the browser.
                prm.add_endRequest(EndRequestHandler);
                function BeginRequestHandler(sender, args) {
                    //Shows the modal popup - the update progress
                    var popup = $find('<%= ModalPopupExtender1.ClientID %>');
                    if (popup != null) {
                        popup.show();
                    }
                }

                function EndRequestHandler(sender, args) {
                    //Hide the modal popup - the update progress
                    var popup = $find('<%= ModalPopupExtender1.ClientID %>');
                    if (popup != null) {
                        popup.hide();
                    }
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
    <center>
    </center>
</asp:Content>

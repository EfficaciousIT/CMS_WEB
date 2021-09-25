<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" Culture="en-Gb" CodeFile="frmSchoolAdminPackageMaster.aspx.cs" Inherits="frmSchoolAdminPackageMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 22px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function Confirm() {
            var del = confirm('Do You Want To Delete Selected Record ?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }


        function submitform() {
            if (!Page_ClientValidate()) {
                return false;
            }
            else {
                if (validation() == 1) {
                    return SaveUpdate();
                }
            }
        }

        function validation() {
            var MaxSMS = document.getElementById('<%= HSMS.ClientID %>').value;
            var SMS = document.getElementById('<%= txtSms.ClientID %>').value;
            var MaxNotify = document.getElementById('<%= HNotification.ClientID %>').value;
            var Notify = document.getElementById('<%= txtNotification.ClientID %>').value;
            var MaxEmail = document.getElementById('<%= HEmail.ClientID %>').value;
            var Email = document.getElementById('<%= txtEmail.ClientID %>').value;
            var MaxData = document.getElementById('<%= Hdata.ClientID %>').value;
            var Data = document.getElementById('<%= txtSpace.ClientID %>').value;

            if (Number(MaxSMS) < Number(SMS)) {
                alert('SMS should not be exceed than ' + MaxSMS);
                document.getElementById('<%= txtSms.ClientID %>').focus();
                return 0;
            }
            if (Number(MaxNotify) < Number(Notify)) {
                alert('Notification should not be exceed than ' + MaxNotify);
                document.getElementById('<%= txtNotification.ClientID %>').focus();
                return 0;
            }
            if (Number(MaxEmail) < Number(Email)) {
                alert('Emails should not be exceed than ' + MaxEmail);
                document.getElementById('<%= txtEmail.ClientID %>').focus();
                return 0;
            }
            if (Number(MaxData) < Number(Data)) {
                alert('Data space should not be exceed than ' + MaxData);
                document.getElementById('<%= txtSpace.ClientID %>').focus();
                return 0;
            }
            return 1;
                      
        }


        function SaveUpdate() {
            var button = document.getElementById('<%= btnSubmit.ClientID %>').value;

            var DataSpace = document.getElementById('<%= txtSpace.ClientID %>').value;
            if (DataSpace == 0) {
                alert('Data Space Should Be Greater Than 0')
                return false;
            }
            if (button == 'Submit') {
                var sub = confirm('Do You Want To Save Entered Record?');
                if (sub) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (button == 'Update') {


                var sub = confirm('Do You Want To Update Entered Record?');
                if (sub) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
       <ContentTemplate>
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0" 
                        Width="928px">
                        <asp:TabPanel runat="Server" ID="tb1">
                            <HeaderTemplate>
                                Details
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="grvPackage" runat="server" AllowPaging="True" AllowSorting="True" 
                                    AutoGenerateColumns="False" CssClass="mGrid" 
                                   PageSize="7" Width="100%" 
                                    DataKeyNames="intSchoolPackage_id" onrowediting="grvPackage_RowEditing" 
                                    onrowdeleting="grvPackage_RowDeleting" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" OnClientClick="return Confirm();"
                                                    CommandName="Delete" ImageUrl="~/images/delete.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit" ImageUrl="~/images/edit.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="intPackage_id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackageId" runat="server" Text='<% #Bind("intSchoolPackage_id") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vchPackage_name" HeaderText="Package" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="dtStartDate" HeaderText="Start Date" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="dtEndate" HeaderText="End Date" ReadOnly="True" />
                                        <asp:BoundField DataField="intNoOfSMS" HeaderText="SMS" ReadOnly="True" />
                                        <asp:BoundField DataField="intNoOfEmails" HeaderText="Email" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="intNoOfNotification" 
                                            HeaderText="Notification" ReadOnly="True" />
                                        <asp:BoundField DataField="fltDataSpace" HeaderText="Data Space" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="vchActiveStatus" HeaderText="Active Status" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="flatAmount" HeaderText="Amount" ReadOnly="True" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:TabPanel >
                        <asp:TabPanel runat="server" ID="tb2">
                            <HeaderTemplate>
                            New Entry
                            </HeaderTemplate>
                            <ContentTemplate>
                            <br />
                            <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                               <ContentTemplate>
                               <table width="100%">
                               <tr>
                               <td align="center">
                               <div class="efficacious">
                                <table width="50%">
                                    <tr>
                                        <td colspan="3">

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1" align="left" valign="top">
                                            <asp:Label ID="lblPackageType" runat="server" Text="Package" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="style1" align="left" colspan="2" width="80%">
                                            <asp:DropDownList ID="ddlPackage" runat="server" CssClass="textsize" 
                                                AutoPostBack="True" onselectedindexchanged="ddlPackage_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                <asp:ListItem Value="Free" Text="Free"></asp:ListItem>
                                                <asp:ListItem Value="Paid" Text="Paid"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="textsize"
                                                Display="None" ErrorMessage="Please Select Package Type" InitialValue="0" ControlToValidate="ddlPackage"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                                TargetControlID="RequiredFieldValidator1" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1" align="left" valign="top">
                                            <asp:Label ID="lblPackageNm" runat="server" Text="Package Name" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="style1" align="left" colspan="2" width="80%">
                                            <asp:TextBox ID="txtPackageNm" CausesValidation="true" runat="server" 
                                                CssClass="textsize" AutoComplete="Off"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="textsize"
                                                Display="None" ErrorMessage="Please Select Package Type" ControlToValidate="txtPackageNm"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                                TargetControlID="RequiredFieldValidator2" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <asp:Label ID="lblDesc" runat="server" Text="Description" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2" width="80%">
                                            <asp:TextBox ID="txtDesc" runat="server" MaxLength="100" CssClass="textsize" Height="50px" AutoComplete="Off"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblNoOfSms" runat="server" Text="No Of SMS" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2" width="80%">
                                            <asp:TextBox ID="txtSms" runat="server" CssClass="textsize" AutoComplete="Off" 
                                                Width="50%"></asp:TextBox>

                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtSms" runat="server" ValidChars="0123456789">
                                            </asp:FilteredTextBoxExtender>


                                            <asp:HiddenField ID="HSMS" runat="server" />


                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1" align="left" valign="top">
                                            <asp:Label ID="lblEmails" runat="server" Text="No Of Emails" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="style1" align="left" colspan="2">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textsize" 
                                                AutoComplete="Off" Width="50%"></asp:TextBox>

                                             <asp:HiddenField ID="HEmail" runat="server" />

                                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtEmail" runat="server" ValidChars="0123456789">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1" align="left" valign="top">
                                            <asp:Label ID="lblNotification" runat="server" Text="No Of Notification" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="style1" align="left" colspan="2">
                                            <asp:TextBox ID="txtNotification" runat="server" CssClass="textsize" 
                                                AutoComplete="Off" Width="50%"></asp:TextBox>

                                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtNotification" runat="server" ValidChars="0123456789">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:HiddenField ID="HNotification" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblSpace" runat="server" Text="Data Space" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="textsize" align="left" colspan="2">
                                            <asp:TextBox ID="txtSpace" runat="server" CssClass="textsize" 
                                                AutoComplete="Off" Width="50%"></asp:TextBox> &nbsp;<asp:HiddenField 
                                                ID="Hdata" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSpace" Display="None"  ErrorMessage="Please Enter Data Space"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RequiredFieldValidator7">
                                        </asp:ValidatorCalloutExtender>
                                         <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtSpace" runat="server" ValidChars=".0123456789">
                                            </asp:FilteredTextBoxExtender>
                                            </td>
                                              <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtSpace"
                                                WatermarkText="GB" runat="server" Enabled="True">
                                            </asp:TextBoxWatermarkExtender>
                                           
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblDate" runat="server" Text="Date" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                        <table width="100%">
                                        <tr>
                                        <td valign="top">
                                          <asp:TextBox ID="txtFrmDate" runat="server" CssClass="textsize" 
                                                AutoComplete="Off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFrmDate" Format="dd/MM/yyyy"
                                                runat="server" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="textsize"
                                                Display="None" ErrorMessage="Please Enter From Date" ControlToValidate="txtFrmDate"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                                TargetControlID="RequiredFieldValidator3" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtFrmDate"
                                                WatermarkText="From Date" runat="server" Enabled="True">
                                            </asp:TextBoxWatermarkExtender>
                                        </td>
                                            <td valign="top">
                                                &nbsp;</td>
                                        <td>
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="textsize"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtToDate" Format="dd/MM/yyyy"
                                                runat="server" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="textsize"
                                                Display="None" ErrorMessage="Please Enter To Date" ControlToValidate="txtToDate"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                                TargetControlID="RequiredFieldValidator4" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtToDate"
                                                WatermarkText="To Date" runat="server" Enabled="True">
                                            </asp:TextBoxWatermarkExtender>


                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" 
                                                ErrorMessage="From Date Should Be Less Than ToDate" 
                                                ControlToCompare="txtToDate" ControlToValidate="txtFrmDate" 
                                                Operator="LessThanEqual" Display="None" CssClass="textsize"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="CompareValidator1">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        </tr>
                                        </table>
                                          
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" align="left" valign="top">
                                            <asp:Label ID="lblActive" runat="server" Text="Activate" CssClass="textcss" AutoComplete="Off"></asp:Label>
                                        </td>
                                        <td  align="left" colspan="2">
                                            <asp:CheckBox ID="chkActive" runat="server" CssClass="textsize" 
                                                AutoPostBack="True" oncheckedchanged="chkActive_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblCurrency" runat="server" Text="Currency " CssClass="textcss" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="textsize" 
                                                Visible="False" Width="50%">

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                CssClass="textsize" Display="None" ErrorMessage="Please Select Currency " 
                                                InitialValue="0" ControlToValidate="ddlCurrency" Visible="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                                                TargetControlID="RequiredFieldValidator5" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblAmt" runat="server" Text="Amount" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="txtAmt" runat="server" CssClass="textsize" AutoComplete="Off" 
                                                Width="50%"></asp:TextBox>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                CssClass="textsize" Display="None" ErrorMessage="Please Enter Amount "  ControlToValidate="txtAmt"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" 
                                                TargetControlID="RequiredFieldValidator6" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left" valign="top">
                                          
                                            <asp:Button ID="btnSubmit" runat="server" CausesValidation="true"  
                                                CssClass="efficacious_send"
                                                OnClientClick="return submitform();" Text="Submit" 
                                                onclick="btnSubmit_Click" />
                                        </td>
                                        <td align="right" valign="top">
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                                CssClass="efficacious_send"  Text="Cancel" onclick="btnCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                                </div>
                                </td>
                               </tr>
                               </table>
                                </ContentTemplate>
                                 </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
        </table>
        </ContentTemplate>
         </asp:UpdatePanel>
    </div>
</asp:Content>


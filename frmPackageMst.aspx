<%@ Page  Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" Culture="en-gb" Title="Package Master"
    CodeFile="frmPackageMst.aspx.cs" Inherits="frmPackageMst" %>

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
                
                return SaveUpdate();
            }
        }



        function SaveUpdate() {
            var button = document.getElementById('<%= btnSubmit.ClientID %>').value;

            var DataSpace = document.getElementById('<%= txtSpace.ClientID %>').value;
            if (DataSpace == 0 ) {
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
       <ContentTemplate>
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1" 
                        Width="928px">
                        <asp:TabPanel runat="Server" ID="tb1">
                            <HeaderTemplate>
                                Details
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="grvPackage" runat="server" AllowPaging="True" AllowSorting="True" 
                                    AutoGenerateColumns="False" CssClass="mGrid" 
                                    OnPageIndexChanging="grvAdd_PageIndexChanging" 
                                    OnRowDeleting="grvAdd_RowDeleting" PageSize="7" Width="100%" 
                                    DataKeyNames="intPackage_id" onrowediting="grvPackage_RowEditing">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" OnClientClick="return Confirm();"
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
                                                <asp:Label ID="lblPackageId" runat="server" Text='<% #Bind("intPackage_id") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vchPackage_type" HeaderText="Package Type" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="vchPackage_name" HeaderText="Package Name" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="dtStartDate" HeaderText="Start Date" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="dtEndate" HeaderText="End Date" ReadOnly="True" />
                                        <asp:BoundField DataField="intNoOfSMS" HeaderText="No Of SMS" ReadOnly="True" />
                                        <asp:BoundField DataField="intNoOfEmails" HeaderText="No Of Email" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="intNoOfNotification" 
                                            HeaderText="No Of Notification" ReadOnly="True" />
                                        <asp:BoundField DataField="fltDataSpace" HeaderText="Data Space" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="vchActiveStatus" HeaderText="Active Status" 
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="Currency" HeaderText="Currency" ReadOnly="True" />
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
                                            <asp:Label ID="lblPackageType" runat="server" Text="Package Type" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="style1" align="left" colspan="2" width="80%">
                                            <asp:DropDownList ID="ddlPackageType" runat="server" CssClass="textsize">
                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                <asp:ListItem Value="Free" Text="Free"></asp:ListItem>
                                                <asp:ListItem Value="Paid" Text="Paid"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="textsize"
                                                Display="None" ErrorMessage="Please Select Package Type" InitialValue="0" ControlToValidate="ddlPackageType"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txtDesc" runat="server" CssClass="textsize" Height="50px" AutoComplete="Off"
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


                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1" align="left" valign="top">
                                            <asp:Label ID="lblEmails" runat="server" Text="No Of Emails" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="style1" align="left" colspan="2">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textsize" 
                                                AutoComplete="Off" Width="50%"></asp:TextBox>

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
                                                AutoComplete="Off"></asp:TextBox>

                                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtNotification" runat="server" ValidChars="0123456789">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblSpace" runat="server" Text="Data Space" CssClass="textcss"></asp:Label>
                                        </td>
                                        <td class="textsize" align="left" colspan="2">
                                            <asp:TextBox ID="txtSpace" runat="server" CssClass="textsize" 
                                                AutoComplete="Off" Width="50%"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSpace" Display="None"  ErrorMessage="Please Enter Data Space"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RequiredFieldValidator7">
                                        </asp:ValidatorCalloutExtender>
                                            </td>
                                              <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtSpace"
                                                WatermarkText="GB" runat="server" Enabled="True">
                                            </asp:TextBoxWatermarkExtender>
                                           
                                    </tr>
                                    <tr>
                                        <td align="left">
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
                                                ControlToCompare="txtFrmDate" ControlToValidate="txtToDate" 
                                                Operator="GreaterThanEqual" Display="None" CssClass="textsize"></asp:CompareValidator>
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
                                            <asp:Label ID="lblCurrency" runat="server" Text="Currency " CssClass="textcss"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="textsize">

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                CssClass="textsize" Display="None" ErrorMessage="Please Select Currency " InitialValue="0" ControlToValidate="ddlCurrency"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txtAmt" runat="server" CssClass="textsize" AutoComplete="Off"></asp:TextBox>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                CssClass="textsize" Display="None" ErrorMessage="Please Enter Amount "  ControlToValidate="txtAmt"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" 
                                                TargetControlID="RequiredFieldValidator6" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td align="left" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left" valign="top">
                                          
                                            <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" 
                                                CssClass="efficacious_send" OnClick="btnSubmit_Click" 
                                                OnClientClick="return submitform();" Text="Submit" />
                                        </td>
                                        <td align="right" valign="top">
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" 
                                                CssClass="efficacious_send" onclick="btnCancel_Click" Text="Cancel" />
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

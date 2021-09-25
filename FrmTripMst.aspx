<%@ Page Title="Trip Master" Language="C#" MasterPageFile="~/MasterPage2.master"
    AutoEventWireup="true" CodeFile="FrmTripMst.aspx.cs" Inherits="FrmTripMst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .INP
        {
            width: 94% !important;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function delete_confirm() {
            var del = confirm('Do You Really Want To Delete Selected Record?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }

        function confirm() {
            if (Page_ClientValidate()) {
                var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
                // alert(btn);
                if (btn == 'Submit') {
                    var save = confirm('Do You To Want Entered Record?');
                    if (save) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                else {

                    var updt = confirm('Do You To Want Update Record?');
                    if (updt) {
                        return true;
                    }
                    else {
                        return false;
                    }

                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Trip Master
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Transporter</a></li>
            <li class="active">Trip Master</li>
        </ol>
    </div>
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015"
                                ActiveTabIndex="1">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                                    <HeaderTemplate>
                                        Trip Details
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <asp:GridView DataKeyNames="intTrip_id" ID="grvTrip" runat="server" AllowSorting="True"
                                                Width="100%" AutoGenerateColumns="False" CssClass="table  tabular-table " OnRowDeleting="grvTrip_RowDeleting"
                                                OnRowEditing="grvTrip_RowEditing" OnPageIndexChanging="grvTrip_PageIndexChanging">
                                                <Columns>
                                                     <asp:BoundField DataField="intTrip_id" HeaderText="TripId" Visible="False" />
                                                    <asp:BoundField DataField="vchTrip_name" HeaderText="Trip" ReadOnly="True" />
                                                    <asp:BoundField DataField="vchRoute_name" HeaderText="Route" ReadOnly="True" />
                                                    <asp:BoundField DataField="vchTripStart_from" HeaderText="Start Point" ReadOnly="True" />
                                                    <asp:BoundField DataField="vchEnd" HeaderText="End Point" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtstarttime" HeaderText="From Time" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtendtime" HeaderText="To Time" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                ImageUrl="images/edit.png" Text="Delete" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                ImageUrl="images/delete.png" OnClientClick="confirm('Are you sure you want delete this record ?');"
                                                                Text="Delete" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                  
                                                </Columns>
                                            </asp:GridView>
                                        </center>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        New Trip Entry
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table width="60%">
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="textsize" >
                                                            <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                                                        </td>
                                                        <td align="left" class="textsize" colspan="2">
                                                            <asp:DropDownList ID="ddlRoute" Style="width: 100%;" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server"
                                                                ErrorMessage="Please Select Route" ControlToValidate="ddlRoute" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="textsize" >
                                                            <asp:Label ID="lblTrip" runat="server" Text="Trip"></asp:Label>
                                                        </td>
                                                        <td align="left" class="textsize" colspan="2">
                                                            <asp:TextBox ID="txtTrip" runat="server" AutoComplete="Off" Style="margin-left: 0px"
                                                                CssClass="input-blue"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Trip"
                                                                ControlToValidate="txtTrip" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="textsize" >
                                                            <asp:Label ID="lblPlace" runat="server" Text="Place"></asp:Label>
                                                        </td>
                                                        <td align="left" class="textsize" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtStartPoint" runat="server" AutoComplete="Off" CssClass="input-blue"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter From Place"
                                                                            ControlToValidate="txtStartPoint" Display="None"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" PopupPosition="BottomRight"
                                                                            TargetControlID="RequiredFieldValidator3" Enabled="True">
                                                                        </asp:ValidatorCalloutExtender>
                                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="From Place"
                                                                            TargetControlID="txtStartPoint" Enabled="True">
                                                                        </asp:TextBoxWatermarkExtender>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEndPoint" CssClass="input-blue" runat="server" AutoComplete="Off"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="txtEndPoint_TextBoxWatermarkExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txtEndPoint" WatermarkText="To Place">
                                                                        </asp:TextBoxWatermarkExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndPoint"
                                                                            Display="None" ErrorMessage="Please Enter To Place"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                                            TargetControlID="RequiredFieldValidator4">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="textsize" >
                                                            <asp:Label ID="lblfrmtime" runat="server" Text="Time"></asp:Label>
                                                        </td>
                                                        <td align="left" class="textsize" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFrmTime" runat="server" AutoComplete="Off" CssClass="input-blue"></asp:TextBox>
                                                                        <asp:MaskedEditExtender ID="txtMaskedFrmTime" runat="server" AutoCompleteValue="99:99 AM"
                                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                            AcceptAMPM="True" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                            CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtFrmTime">
                                                                        </asp:MaskedEditExtender>
                                                                        <asp:MaskedEditValidator ID="MaskID" runat="server" Display="None" ControlExtender="txtMaskedFrmTime"
                                                                            MinimumValue="00:00" ControlToValidate="txtFrmTime" SetFocusOnError="True" MaximumValueMessage="Wrong Input"
                                                                            InvalidValueMessage="Please enter a valid time." ErrorMessage="MaskID"></asp:MaskedEditValidator>
                                                                        <asp:ValidatorCalloutExtender ID="MskV" runat="server" Enabled="True" TargetControlID="MaskID">
                                                                        </asp:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFrmTime"
                                                                            Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                                        </asp:ValidatorCalloutExtender>
                                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkText="Start Time"
                                                                            TargetControlID="txtFrmTime" Enabled="True">
                                                                        </asp:TextBoxWatermarkExtender>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txttotime" runat="server" CssClass="input-blue"></asp:TextBox>
                                                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoCompleteValue="99:99 AM"
                                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                            AcceptAMPM="True" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                            CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txttotime">
                                                                        </asp:MaskedEditExtender>
                                                                        <asp:MaskedEditValidator ID="MaskID2" runat="server" Display="None" ControlExtender="MaskedEditExtender1"
                                                                            ControlToValidate="txttotime" MinimumValue="00:00" SetFocusOnError="True" MaximumValueMessage="Wrong Input"
                                                                            InvalidValueMessage="Please enter a valid time." ErrorMessage="MaskID2"></asp:MaskedEditValidator>
                                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                                            TargetControlID="MaskID2">
                                                                        </asp:ValidatorCalloutExtender>
                                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender0"
                                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                                                                        </asp:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txttotime"
                                                                            Display="None" ErrorMessage="Please Enter To Time"></asp:RequiredFieldValidator>
                                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkText="To Time"
                                                                            TargetControlID="txttotime" Enabled="True">
                                                                        </asp:TextBoxWatermarkExtender>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="textsize">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" class="textsize" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                                OnClientClick="return confirm();" Text="Submit" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Button ID="btnCancel0" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                OnClick="btnCancel_Click" Text="Cancel" />
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
    </div>
</asp:Content>

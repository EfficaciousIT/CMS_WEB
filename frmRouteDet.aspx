<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmRouteDet.aspx.cs" Inherits="frmRouteDet" Title="Route Details" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <script language="javascript">
        function confirmValidation() {

            var start = document.getElementById("<%=txtfromtime.ClientID %>").value;
            var end = document.getElementById("<%=txttotime0.ClientID %>").value;

            if (start == 'From Time') {
                alert('From time should not be blank')
                return false;
            }
            if (end == 'To Time') {
                alert('To time should not be blank')
                return false;
            }
            if (start == end) {
                alert('Invalid time. From time and To time should not be same')
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Route Master
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Transporter</a></li>
            <li class="active">Route Master</li>
        </ol>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="left">
                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                            Width="1015px" Height="365px">
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Width="100%">
                                <HeaderTemplate>
                                    Route Details</HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grdRoute" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                        EmptyDataText="No Records Found" DataKeyNames="intRoute_id,vchRoute_name,vchStart_from,vchEnd,dtstarttime,dtendtime"
                                                        Width="100%" OnRowDeleting="grdRoute_RowDeleting" OnRowEditing="grdRoute_RowEditing"
                                                        OnPageIndexChanging="grdRoute_PageIndexChanging">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <Columns>
                                                         <asp:BoundField DataField="vchRoute_name" HeaderText="Route Name" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchStart_from" HeaderText="From" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchEnd" HeaderText="To" ReadOnly="True" />
                                                            <asp:BoundField DataField="dtstarttime" HeaderText=" From Time" ReadOnly="True" />
                                                            <asp:BoundField DataField="dtendtime" HeaderText="To Time" ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="intRoute_id" Visible="False"></asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        ImageUrl="images/edit.png" Text="Delete" /></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        ImageUrl="images/delete.png" OnClientClick="return confirm('Are you sure you want delete this record ?');"
                                                                        Text="Delete" /></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                           
                                                        </Columns>
                                                        <PagerStyle CssClass="pgr" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    New Entry</HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <br />
                                        <div class="efficacious">
                                            <table width="70%">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label3" runat="server" Text="Route Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtRouteName" runat="server" AutoComplete="Off" CssClass="input-blue"
                                                            MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="route" ControlToValidate="txtRouteName"
                                                                Display="None" runat="server" ErrorMessage="Please Enter Route Name" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender3" runat="server" TargetControlID="route" Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label6" runat="server" Text="Place" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtRouteFrom" runat="server" AutoComplete="Off" CssClass="input-blue"
                                                                        Style="width: 94%;" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator ID="a"
                                                                            ControlToValidate="txtRouteFrom" CssClass="textsize" Display="None" runat="server"
                                                                            ErrorMessage="Please Enter From Place"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="ValidatorCalloutExtender1" runat="server" TargetControlID="a" Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    <asp:TextBoxWatermarkExtender ID="b" runat="server" TargetControlID="txtRouteFrom"
                                                                        WatermarkText="Start Point" Enabled="True">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRouteTo" runat="server" AutoComplete="Off" CssClass="input-blue"
                                                                        MaxLength="25"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="c" runat="server" ControlToValidate="txtRouteTo"
                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Enter To Place"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                        TargetControlID="c">
                                                                    </asp:ValidatorCalloutExtender>
                                                                    <asp:TextBoxWatermarkExtender ID="d" runat="server" Enabled="True" TargetControlID="txtRouteTo"
                                                                        WatermarkText="End Point">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label8" runat="server" Text="Time" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtfromtime" runat="server" AutoComplete="Off" Style="width: 94%;"
                                                                        CssClass="input-blue"></asp:TextBox>
                                                                    <asp:MaskedEditExtender ID="txtMaskedEdie" runat="server" Enabled="True" Mask="99:99"
                                                                        MaskType="Time" AcceptAMPM="True" TargetControlID="txtfromtime" AutoCompleteValue="00:00 AM"
                                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                        CultureTimePlaceholder="" />
                                                                    <asp:MaskedEditValidator ID="MskFrmValid" runat="server" Display="None" ControlToValidate="txtfromtime"
                                                                        ControlExtender="txtMaskedEdie" SetFocusOnError="True" InvalidValueMessage="Please Enter Valid Time"
                                                                        ErrorMessage="MskFrmValid"></asp:MaskedEditValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="MskFrmValid"
                                                                        Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                    <asp:RequiredFieldValidator ID="as" ControlToValidate="txtfromtime" CssClass="textsize"
                                                                        Display="None" runat="server" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="as"
                                                                        Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtfromtime"
                                                                        WatermarkText="From Time" Enabled="True">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txttotime0" runat="server" AutoComplete="Off" CssClass="input-blue"></asp:TextBox>
                                                                    <asp:MaskedEditExtender ID="txttotime0_MaskedEditExtender" runat="server" AcceptAMPM="True"
                                                                        AutoCompleteValue="00:00 AM" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                        CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txttotime0">
                                                                    </asp:MaskedEditExtender>
                                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                                                        TargetControlID="txttotime0" WatermarkText="End Time">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                    <asp:RequiredFieldValidator ID="bs" runat="server" ControlToValidate="txttotime0"
                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Enter To Time"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                                        TargetControlID="bs">
                                                                    </asp:ValidatorCalloutExtender>
                                                                    <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Display="None"
                                                                        ControlToValidate="txttotime0" ControlExtender="txttotime0_MaskedEditExtender"
                                                                        SetFocusOnError="True" InvalidValueMessage="Please Enter Valid Time" ErrorMessage="MaskedEditValidator1"></asp:MaskedEditValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="MaskedEditValidator1"
                                                                        Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return confirmValidation()"
                                                            OnClick="btnSubmit_Click" CssClass="efficacious_send" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td align="right" valign="top" width="35%">
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" Text="Cancel"
                                                            OnClick="btnCancel_Click" Visible="False" />
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
</asp:Content>

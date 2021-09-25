<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" Culture="en-gb"
    CodeFile="frmTripwiseOverSpeedingRpt.aspx.cs" Inherits="frmTripwiseOverSpeedingRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 417px;
        }
        .style3
        {
            width: 417px;
            height: 16px;
        }
        .style4
        {
            height: 16px;
        }
        .style5
        {
            width: 417px;
            height: 24px;
        }
        .style6
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="style1" width="100%">
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="lblRptNm" runat="server" Text="Over Speeding Reports" Font-Bold="True"
                                Font-Size="Medium" CssClass="textcss"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style3">
                        </td>
                        <td align="justify" class="style4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                             <table width="100%">
                        <tr>
                            
                             <td align="left" style="padding-right:20px";>
                                    <asp:Label ID="lblRoute" runat="server" Text="Route" CssClass="textcss"></asp:Label>
                                </td>
                                <td align="left" style="padding-right:40px";>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="150px" AutoPostBack="True"
                                      CssClass="textsize" onselectedindexchanged="ddlRoute_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        Display="None" ControlToValidate="ddlRoute" InitialValue="0" 
                                        ErrorMessage="Please Select Route" CssClass="textcss"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender>

                                </td>

                             <td align="left" style="padding-right:20px";>
                                    <asp:Label ID="lblTrip" runat="server" Text="Trip" CssClass="textcss"></asp:Label>
                                </td>
                                <td align="left" style="padding-right:40px";>
                                    <asp:DropDownList ID="ddlTrip" runat="server" Width="150px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlTrip_SelectedIndexChanged" CssClass="textsize" 
                                        CausesValidation="True">
                                     
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        Display="None" ControlToValidate="ddlTrip" InitialValue="0" 
                                        ErrorMessage="Please Select Trip" CssClass="textcss"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender>
                                </td>

                                <td align="left" style="padding-right:20px";>
                                    <asp:Label ID="lblDate" runat="server" Text="From Date" CssClass="textcss"></asp:Label>
                                </td>
                                <td align="left" style="padding-right:40px"; >
                                    <asp:TextBox ID="txtFrmDate" runat="server" Style="margin-left: 0px" Width="75px" 
                                        CssClass="textsize" ontextchanged="txtFrmDate_TextChanged" 
                                        AutoPostBack="True" CausesValidation="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDate"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>


                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        Display="None" ControlToValidate="txtFrmDate"  
                                        ErrorMessage="Please Enter From Date" CssClass="textcss"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>

                                </td>

                                <td align="left" style="padding-right:30px";>
                                    <asp:Label ID="lblToDate" runat="server" Text="To Date" CssClass="textcss"></asp:Label>
                                </td>
                                <td align="left" style="padding-right:50px";>
                                    <asp:TextBox ID="txtToDate" runat="server" Style="margin-left: 0px" 
                                        Width="75px" CssClass="textsize" ontextchanged="txtToDate_TextChanged" 
                                        AutoPostBack="True" CausesValidation="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        Display="None" ControlToValidate="txtToDate"  
                                        ErrorMessage="Please Enter To Date" CssClass="textcss"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4" PopupPosition="BottomLeft">
                                    </asp:ValidatorCalloutExtender>

                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ErrorMessage="From Date Should Be Less Than To Date" 
                                        ControlToCompare="txtToDate" ControlToValidate="txtFrmDate" 
                                        Operator="LessThanEqual" Display="None" CssClass="textcss"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="CompareValidator1">
                                    </asp:ValidatorCalloutExtender>
                                </td>

                               
                            
                        </tr>
                    </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style2">
                            &nbsp;
                        </td>
                        <td align="justify">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:GridView ID="grvTripDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CssClass="mGrid" EmptyDataText="No Record Found !" PageSize="20" 
                                Width="90%" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                    <asp:BoundField DataField="vchTrip_name" HeaderText="Trip" />
                                    <asp:BoundField DataField="vchBusNumber" HeaderText="Vehicle No" />
                                    <asp:BoundField DataField="DriverName" HeaderText="DriverName" />
                                    <asp:BoundField DataField="ActualSpeed" HeaderText="Speed Limit" />
                                    <asp:BoundField DataField="OverSpeed" HeaderText="Over Speed" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

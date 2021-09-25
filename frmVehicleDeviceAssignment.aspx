<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmVehicleDeviceAssignment.aspx.cs" Inherits="frmVehicleDeviceAssignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-family: Verdana;
            font-size: 10px;
            text-transform: capitalize;
            width: 120px;
            margin-right: 0px;
        }
        .style2
        {
            width: 120px;
        }
        
        trans .ajax__tab_xp .ajax__tab_outer
        {
            background: none !important;
        }
        .ajax__tab_xp .ajax__tab_inner
        {
            background: none !important;
        }
        .ajax__tab_xp .ajax__tab_tab
        {
            background: none !important;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            background: none !important;
        }
        .ajax__tab_xp .ajax__tab_tab
        {
            background: none !important;
        }
    </style>
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .input
        {
            width: 96% !important;
        }
    </style>
    <script src="index/scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function CallAssign() {
            var TripdId = document.getElementById('<%=ddlTrip.ClientID %>').value;
            var BusId = document.getElementById('<%=ddlBuses.ClientID %>').value;
            var bus = $("#ddlTrip").val();
            alert(bus);

            $.ajax({
                type: "POST",
                url: "frmVehicleDeviceAssignment.aspx/callAssignButton",
                data: '{TripId: "' + $("#<%=txtTrip.ClientID%>")[0].value + '",BusId: "' + $("#<%=txtBus.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

        }
        function OnSuccess(response) {
            if (response.d == "true") {
                var msg = confirm('Selected Bus Already Assigned To Another Trip with Same Time. Are you sure that update with new trip?');
                if (msg) {

                    $('#<%=Button1.ClientID%>').click();
                }
                else {
                    return false;
                }
            }
            else {

                $('#<%=Button1.ClientID%>').click();
            }
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

        function ConfirmAssign() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Update data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmInsertUpdate() {
            if (Page_ClientValidate()) {
                var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
                if (btn == 'Submit' || btn == 'Assign') {

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
            }
        }



    
    </script>
    <script language="javascript" type="text/javascript">
        function BusStopValidation() {
            var ddlRoute = document.getElementById('<%=ddlRoute.ClientID %>').value;
            if (ddlRoute == '0') {
                alert('Please Select Route');

                return false;
            }
            var ddlTrips = document.getElementById('<%=ddlTrips.ClientID %>').value;
            if (ddlTrips == '0') {
                alert('Please Select Trip');

                return false;
            }
            var ddlBusStop = document.getElementById('<%=ddlBusStop.ClientID %>').value;
            if (ddlBusStop == '0') {
                alert('Please Select Bus Stop');

                return false;
            }
            var txtFrmTime = document.getElementById('<%=txtFrmTime.ClientID %>').value;

            if (txtFrmTime == 'From Time') {
                alert('Please Enter From Time');

                return false;
            }
            var txtToTime = document.getElementById('<%=txtToTime.ClientID %>').value;
            if (txtToTime == 'To Time') {
                alert('Please Enter To Time');

                return false;
            }
            return true;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function BusStopValidationEntry() {
            var ddlRoute = document.getElementById('<%=txtBusNum.ClientID %>').value;
            if (ddlRoute == '') {
                alert('Please Enter Bus Number');

                return false;
            }
            var ddlTrips = document.getElementById('<%=txtNoOfSeat.ClientID %>').value;
            if (ddlTrips == '') {
                alert('Please Select Trip');

                return false;
            }
            var ddlBusStop = document.getElementById('<%=ddlTranporterNm.ClientID %>').value;
            if (ddlBusStop == '0') {
                alert('Please Select Transporter');

                return false;
            }


            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Setting
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Transporter</a></li>
            <li class="active">Setting</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                            Visible="true" ondemand="True" AutoPostBack="true" ActiveTabIndex="2">
                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                <HeaderTemplate>
                                    Vehicle Details</HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:TabContainer ID="TabContainer2" CssClass="MyTabStyle" runat="server" Width="100%"
                                                    ondemand="True" AutoPostBack="True" ActiveTabIndex="1">
                                                    <asp:TabPanel ID="tbVehicle" runat="server">
                                                        <HeaderTemplate>
                                                            Details</HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="15" Width="100%" OnRowEditing="grvDetail_RowEditing"
                                                                DataKeyNames="intBus_id" OnRowDeleting="grvDetail_RowDeleting" AllowPaging="True"
                                                                OnPageIndexChanging="grvDetail_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" runat="server" Text='  <%# Eval("intBus_id")  %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   
                                                                    <asp:BoundField DataField="vchBusNumber" HeaderText="Bus Number" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intNoOfSeater" HeaderText="No Of Seat" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchTransporter_name" HeaderText="Transporter's Name" ReadOnly="True" />
                                                                     
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                                                CausesValidation="false" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                                OnClientClick="return ConfirmDelete();" CausesValidation="false" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:TabPanel>
                                                    <asp:TabPanel ID="tbEntry" runat="server">
                                                        <HeaderTemplate>
                                                            Entry</HeaderTemplate>
                                                        <ContentTemplate>
                                                            <center>
                                                                <br />
                                                                <br />
                                                                <div class="efficacious">
                                                                    <table width="60%">
                                                                        <tr>
                                                                            <td align="left" class="style1">
                                                                                <asp:Label ID="lblBusNum" runat="server" Text="Bus Number" CssClass="textsize"></asp:Label>
                                                                            </td>
                                                                            <td align="left" class="textsize" colspan="2">
                                                                                <asp:TextBox ID="txtBusNum" AutoComplete="Off" runat="server" CssClass="input-blue" MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBusNum" ValidationGroup="BusMst"
                                                                                    Display="None" CssClass="textsize" ErrorMessage="Please Enter Bus Number"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                        runat="server" ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator1"
                                                                                        Enabled="True">
                                                                                    </asp:ValidatorCalloutExtender>
                                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBusNum"
                                                                                    FilterType="Custom, UppercaseLetters, LowercaseLetters, Numbers" ValidChars="- " Enabled="True">
                                                                                </asp:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="style1">
                                                                                <asp:Label ID="lblNoOfSeat" runat="server" Text="No Of Seat" CssClass="textsize"></asp:Label>
                                                                            </td>
                                                                            <td align="left" class="textsize" colspan="2">
                                                                                <asp:TextBox ID="txtNoOfSeat" runat="server" AutoComplete="Off" CssClass="input-blue"
                                                                                    MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                                        runat="server" ControlToValidate="txtNoOfSeat" ValidationGroup="BusMst" Display="None"
                                                                                        CssClass="textsize" ErrorMessage="Please Enter Total Number Of Seat"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            runat="server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator2"
                                                                                            Enabled="True">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                <asp:FilteredTextBoxExtender runat="server" ID="txtNoSeat" TargetControlID="txtNoOfSeat"
                                                                                    FilterType="Numbers" Enabled="True">
                                                                                </asp:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="style1">
                                                                                <asp:Label ID="lblTranporterNm" runat="server" CssClass="textsize" Text="Transporter"></asp:Label>
                                                                            </td>
                                                                            <td align="left" class="textsize" colspan="2">
                                                                                <asp:DropDownList ID="ddlTranporterNm" runat="server" Style="width: 99.6%;" CssClass="textsize"
                                                                                    AutoComplete="Off">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                                                                    ControlToValidate="ddlTranporterNm" Display="None" CssClass="textsize" ValidationGroup="BusMst"
                                                                                    ErrorMessage="Please Select Transporter"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                        runat="server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator3"
                                                                                        Enabled="True">
                                                                                    </asp:ValidatorCalloutExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style2">
                                                                                &#160;&#160;
                                                                            </td>
                                                                            <td colspan="2">
                                                                                &#160;&#160;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style2">
                                                                                &#160;&#160;
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="BusMst"
                                                                                    OnClick="Button1_Click" CausesValidation="False" OnClientClick="return BusStopValidationEntry();"
                                                                                    CssClass="efficacious_send" />
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Button ID="btnCancel2" runat="server" CausesValidation="False" CssClass="efficacious_send"
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
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="tb4">
                                <HeaderTemplate>
                                    Vehicle-Device Assignment</HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <asp:TabContainer ID="TabContainer3" CssClass="MyTabStyle" runat="server" Width="100%"
                                        ActiveTabIndex="0">
                                        <asp:TabPanel ID="TabPanel2" runat="server">
                                            <HeaderTemplate>
                                                Details</HeaderTemplate>
                                            <ContentTemplate>
                                                <center>
                                                    <asp:GridView ID="grvBUSDevice" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " PageSize="15" Width="100%" OnRowEditing="grvBUSDevice_RowEditing"
                                                        DataKeyNames="intVD_id" AllowPaging="True" OnRowDeleting="grvBUSDevice_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" runat="server" Text='  <%# Eval("intVD_id")  %>'></asp:Label></ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:BoundField DataField="vchBusNumber" HeaderText="Bus Number" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchDeviceNum" HeaderText="Device" ReadOnly="True" />
                                                           
                                                            <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                                        CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                        OnClientClick="return ConfirmDelete();" CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel3" runat="server">
                                            <HeaderTemplate>
                                                Entry</HeaderTemplate>
                                            <ContentTemplate>
                                                <center>
                                                    <br />
                                                    <br />
                                                    <div class="efficacious">
                                                        <table width="60%">
                                                            <tr>
                                                                <td align="left" class="style1" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="lblBus" runat="server" CssClass="textsize">Bus</asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2" valign="top">
                                                                    <asp:DropDownList ID="ddlBus" runat="server" AutoComplete="Off" CssClass="textsize">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBus"
                                                                        InitialValue="0" ValidationGroup="BusDevice" Display="None" CssClass="textsize"
                                                                        ErrorMessage="Please Enter Bus Number"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            runat="server" ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator4"
                                                                            Enabled="True">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="lblDevice" runat="server" Text="Device" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2" valign="top">
                                                                    <asp:DropDownList ID="ddlDevice" runat="server" AutoComplete="Off" CssClass="textsize">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="BusDevice"
                                                                        runat="server" ControlToValidate="ddlDevice" CssClass="textsize" Display="None"
                                                                        ErrorMessage="Please Select Device" InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="RequiredFieldValidator7_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                            TargetControlID="RequiredFieldValidator7">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1">
                                                                    &#160;&#160;
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    &#160;&#160;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">
                                                                    &#160;&#160;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Button ID="btnAssign" runat="server" OnClick="Button1_Click1" Text="Assign"
                                                                        ValidationGroup="BusDevice" CausesValidation="False" CssClass="efficacious_send" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Button ID="btnCan0" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                        OnClick="btnCancel_Click" Text="Cancel" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </center>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer></ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel4">
                                <HeaderTemplate>
                                    Vehicle-Driver-Trip Assignment
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <asp:TabContainer ID="TabContainer4" CssClass="MyTabStyle" runat="server" Width="100%"
                                        ActiveTabIndex="1">
                                        <asp:TabPanel ID="TabPanel5" runat="server">
                                            <HeaderTemplate>
                                                Details</HeaderTemplate>
                                            <ContentTemplate>
                                                <center>
                                                    <asp:GridView ID="grvBusTripDriver" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " PageSize="15" Width="100%" OnRowEditing="grvBusTripDriver_RowEditing"
                                                        DataKeyNames="int_VDT_id" AllowPaging="True" OnRowDeleting="grvBusTripDriver_RowDeleting"
                                                        OnPageIndexChanging="grvBusTripDriver_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" runat="server" Text='  <%# Eval("int_VDT_id")  %>'></asp:Label></ItemTemplate>
                                                            </asp:TemplateField>
                                                              <asp:BoundField DataField="vchBusNumber" HeaderText="Bus Number" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchTransporter_name" HeaderText="Transporter " ReadOnly="True" />
                                                            <asp:BoundField DataField="DriverNm" HeaderText="Driver" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchTrip_name" HeaderText="Trip" ReadOnly="True" />
                                                           
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                                        CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                        OnClientClick="return ConfirmDelete();" CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel6" runat="server">
                                            <HeaderTemplate>
                                                Entry</HeaderTemplate>
                                            <ContentTemplate>
                                                <center>
                                                    <br />
                                                    <br />
                                                    <div class="efficacious">
                                                        <table width="60%">
                                                            <tr>
                                                                <td align="left" class="style1" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="textsize">Bus</asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlBuses" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                        OnSelectedIndexChanged="ddlBuses_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlBuses"
                                                                        InitialValue="0" ValidationGroup="BusDevice" Display="None" CssClass="textsize"
                                                                        ErrorMessage="Please Enter Bus Number"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            runat="server" ID="ValidatorCalloutExtender5" TargetControlID="RequiredFieldValidator5"
                                                                            Enabled="True">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <input id="Hidden1" type="hidden" /><input id="Hidden2" type="hidden" /><asp:HiddenField
                                                                        ID="txtBus" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="Label4" runat="server" Text="Trip" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlTrip" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                        OnSelectedIndexChanged="ddlTrip_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="txtTrip" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="Label3" runat="server" Text="Transporter" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlTranspoter" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlTranspoter_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTranspoter"
                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Select Device" InitialValue="0"
                                                                        ValidationGroup="BusDevice"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="RequiredFieldValidator8_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                            TargetControlID="RequiredFieldValidator8">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="Label2" runat="server" Text="Driver" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlDriver" runat="server" AutoComplete="Off" CssClass="textsize">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="BusDevice"
                                                                        runat="server" ControlToValidate="ddlDriver" CssClass="textsize" Display="None"
                                                                        ErrorMessage="Please Select Device" InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1">
                                                                    &#160;&#160;
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    &#160;&#160;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">
                                                                    <asp:Label ID="lbl" runat="server"></asp:Label>
                                                                    &#160;&#160;<asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None"
                                                                        CausesValidation="False" OnClick="btnAssign1_Click" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Button ID="btnAssign1" runat="server" Text="Assign" ValidationGroup="BusDevice"
                                                                        CausesValidation="False" OnClick="btnAssign1_Click" CssClass="efficacious_send" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Button ID="btnCancel1" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                        OnClick="btnCancel_Click" Text="Cancel" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </center>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel50">
                                <HeaderTemplate>
                                    Stop-Trip Assignment
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <asp:TabContainer ID="TabContainer5" CssClass="MyTabStyle" runat="server" Width="100%"
                                        ActiveTabIndex="1">
                                        <asp:TabPanel ID="TabPanel7" runat="server">
                                            <HeaderTemplate>
                                                Details</HeaderTemplate>
                                            <ContentTemplate>
                                                <center>
                                                    <asp:GridView ID="grvBusStop" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " PageSize="15" Width="100%" OnRowEditing="grvBusStop_RowEditing"
                                                        DataKeyNames="int_BT_id" AllowPaging="True" OnRowDeleting="grvBusStop_RowDeleting"
                                                        OnPageIndexChanging="grvBusStop_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" runat="server" Text='  <%# Eval("int_BT_id")  %>'></asp:Label></ItemTemplate>
                                                            </asp:TemplateField>
                                                              <asp:BoundField DataField="vchBusStop_name" HeaderText="Bus Stop" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchRoute_name" HeaderText="Route" ReadOnly="True" />
                                                            <asp:BoundField DataField="vchTrip_name" HeaderText="Trip" ReadOnly="True" />
                                                            <asp:BoundField DataField="dtFromTime" HeaderText="From Time" ReadOnly="True" />
                                                            <asp:BoundField DataField="dtToTime" HeaderText="To Time" />
                                                          
                                                            <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                                        CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                        OnClientClick="return ConfirmDelete();" CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel8" runat="server">
                                            <HeaderTemplate>
                                                Entry</HeaderTemplate>
                                            <ContentTemplate>
                                                <center>
                                                    <br />
                                                    <br />
                                                    <div class="efficacious">
                                                        <table width="60%">
                                                            <tr>
                                                                <td align="left" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="lblRoute" runat="server" Text="Route" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlRoute" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                        OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="R10" runat="server" ControlToValidate="ddlRoute"
                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Select Route" InitialValue="0"
                                                                        ValidationGroup="BusDevice"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender"
                                                                        runat="server" Enabled="True" TargetControlID="R10">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="lblTrip" runat="server" CssClass="textsize" Text="Trip"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlTrips" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                        OnSelectedIndexChanged="ddlTrips_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="R11" runat="server" ControlToValidate="ddlTrips"
                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Select Trip" InitialValue="0"
                                                                        ValidationGroup="BusDevice"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender"
                                                                        runat="server" Enabled="True" TargetControlID="R11">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="lblBusStop" runat="server" CssClass="textsize">Bus Stop</asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <asp:DropDownList ID="ddlBusStop" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                        OnSelectedIndexChanged="ddlBuses_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="R0" runat="server" ControlToValidate="ddlBusStop"
                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Select Bus Stop" InitialValue="0"
                                                                        ValidationGroup="BusDevice"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                                                        TargetControlID="R0">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" style="padding-top:15px;">
                                                                    <asp:Label ID="lblTime" runat="server" Text="Time" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFrmTime" runat="server" Width="95%" CssClass="input-blue"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="R13" runat="server" ControlToValidate="txtFrmTime"
                                                                                    CssClass="textsize" Display="None" ErrorMessage="Please Enter From Time" ValidationGroup="BusDevice"></asp:RequiredFieldValidator>
                                                                                <asp:ValidatorCalloutExtender ID="R13_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                                    TargetControlID="R13">
                                                                                </asp:ValidatorCalloutExtender>
                                                                                <asp:TextBoxWatermarkExtender runat="server" TargetControlID="txtFrmTime" WatermarkText="From Time"
                                                                                    ID="txt00120" Enabled="True">
                                                                                </asp:TextBoxWatermarkExtender>
                                                                                <asp:MaskedEditExtender ID="txtMaskedFrmTime" runat="server" AutoCompleteValue="99:99 AM"
                                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                    AcceptAMPM="True" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                    CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtFrmTime">
                                                                                </asp:MaskedEditExtender>
                                                                                <asp:MaskedEditValidator runat="server" Display="None" ID="MskValid" ControlExtender="txtMaskedFrmTime"
                                                                                    ControlToValidate="txtFrmTime" InvalidValueMessage="Please Enter Valid Time"
                                                                                    ErrorMessage="MskValid"></asp:MaskedEditValidator>
                                                                                <asp:ValidatorCalloutExtender runat="server" ID="Valid23" TargetControlID="MskValid"
                                                                                    Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                            </td>
                                                                            <td width="6%">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtToTime" Width="93.6%" runat="server" CssClass="input-blue"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="R12" runat="server" ControlToValidate="txtToTime"
                                                                                    CssClass="textsize" Display="None" ErrorMessage="Please To Time" InitialValue="0"
                                                                                    ValidationGroup="BusDevice"></asp:RequiredFieldValidator>
                                                                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender"
                                                                                    runat="server" Enabled="True" TargetControlID="R12">
                                                                                </asp:ValidatorCalloutExtender>
                                                                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtToTime"
                                                                                    WatermarkText="To Time" Enabled="True">
                                                                                </asp:TextBoxWatermarkExtender>
                                                                                <asp:MaskedEditValidator runat="server" Display="None" ID="MaskedEditValidator1"
                                                                                    ControlExtender="txtMaskedFrmTime" ControlToValidate="txtFrmTime" InvalidValueMessage="Please Enter Valid Time"
                                                                                    ErrorMessage="MaskedEditValidator1"></asp:MaskedEditValidator>
                                                                                <asp:ValidatorCalloutExtender ID="ValidExtend" runat="server" TargetControlID="MaskedEditValidator1"
                                                                                    Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoCompleteValue="99:99 AM"
                                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                    AcceptAMPM="True" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                    CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtToTime">
                                                                                </asp:MaskedEditExtender>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style1">
                                                                    &#160;&#160;
                                                                </td>
                                                                <td align="left" class="textsize" colspan="2">
                                                                    &#160;&#160;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">
                                                                    &#160;&#160;
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btnAssign2" runat="server" Text="Assign" ValidationGroup="BusDevice"
                                                                        OnClientClick="return BusStopValidation();" CausesValidation="False" OnClick="btnAssign2_Click"
                                                                        CssClass="efficacious_send" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="Button4" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                        OnClick="btnCancel_Click" Text="Cancel" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </center>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

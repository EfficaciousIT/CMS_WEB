<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmAdmStudent_Allocation.aspx.cs" Inherits="frmAdmStudent_Allocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .efficacious input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .efficacious input[type=checkbox] + label
        {
            background: inherit !important;
            position: relative;
            top: 1px;
        }
        .efficacious span
        {
            padding: 0 !important;
            margin: 2% 0 !important;
            float: left;
        }
        .label
        {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 3px; /* font-weight: 700; */
        }
        .efficacious_send
        {
            width: 100% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Bus Stop Allocation
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Transporter</a></li>
            <li class="active">Bus Stop Allocation</li>
        </ol>
    </div>
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="updat1" runat="server">
            <ContentTemplate>
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015PX"
                    CssClass="MyTabStyle">
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Student Bus Allocation
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="efficacious">
                                <center>
                                    <table style="margin-top: 20px;">
                                        <tr id="trLeaveType" runat="server" style="padding: 0 0 10px 0">
                                            <td id="Td1" align="left" runat="server">
                                                <asp:Label ID="lblvchno" runat="server" Style="position: relative; top: -8px;">Select Route</asp:Label>
                                            </td>
                                            <td id="Td2" runat="server" style="padding: 0 0 10px 0">
                                                <asp:DropDownList ID="DropDownList1" runat="server" MaxLength="50" ValidationGroup="b"
                                                    Width="200px" DataTextField="vchRoute_name" DataValueField="intRoute_id" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Req15" runat="server" ControlToValidate="DropDownList1"
                                                    ErrorMessage="Select Route" InitialValue="0" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="Req15"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server" style="padding: 0 0 10px 0">
                                            <td id="Td3" align="left" runat="server">
                                                <asp:Label ID="Label1" runat="server" Style="position: relative; top: -8px;">Select Trip</asp:Label>
                                            </td>
                                            <td id="Td4" runat="server" style="padding: 0 0 10px 0">
                                                <asp:DropDownList ID="DropDownList2" runat="server" MaxLength="50" ValidationGroup="b"
                                                    AutoPostBack="True" Width="200px" DataTextField="vchTrip_name" 
                                                    DataValueField="intTrip_id" 
                                                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqFV11" runat="server" ControlToValidate="DropDownList2"
                                                    ErrorMessage="Select Trip" InitialValue="0" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="ReqFV11"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr id="tr2" runat="server" style="padding: 0 0 10px 0">
                                            <td id="Td5" align="left" runat="server">
                                                <asp:Label ID="Label2" runat="server" Style="position: relative; top: -8px;">Select Bus Stop</asp:Label>
                                            </td>
                                            <td id="Td6" runat="server" style="padding: 0 0 10px 0">
                                                <asp:DropDownList ID="DropDownList3" runat="server" MaxLength="50" ValidationGroup="b"
                                                    Width="200px" DataTextField="vchBusStop_name" 
                                                    DataValueField="intBusStop_id" 
                                                    onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqFV12" runat="server" ControlToValidate="DropDownList3"
                                                    ErrorMessage="Select Bus Stop" InitialValue="0" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="ReqFV12"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr id="tr3" runat="server" style="padding: 0 0 10px 0">
                                            <td id="Td7" align="left" runat="server">
                                                <asp:Label ID="Label3" runat="server" Style="position: relative; top: -8px;">Standard</asp:Label>
                                            </td>
                                            <td id="Td8" runat="server" style="padding: 0 0 10px 0">
                                                <asp:DropDownList ID="DropDownList4" runat="server" MaxLength="50" ValidationGroup="b"
                                                    Width="200px" DataTextField="intStandard_id" DataValueField="intStandard_id"
                                                    OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqFV13" runat="server" ControlToValidate="DropDownList4"
                                                    ErrorMessage="Select Standard" InitialValue="0" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="ReqFV13"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr id="tr4" runat="server" style="padding: 0 0 10px 0">
                                            <td id="Td9" align="left" runat="server">
                                                <asp:Label ID="Label4" runat="server" Style="position: relative; top: -8px;">Division</asp:Label>
                                            </td>
                                            <td id="Td10" runat="server" class="style1" style="padding: 10 0 10px 0">
                                                <asp:DropDownList ID="DropDownList5" runat="server" MaxLength="50" ValidationGroup="b"
                                                    Width="200px" AutoPostBack="True" DataTextField="intDivision_id" DataValueField="vchDivisionName"
                                                    OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqFV14" runat="server" ControlToValidate="DropDownList5"
                                                    ErrorMessage="Select Division" InitialValue="0" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="ReqFV14"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-top: 10px">
                                                <asp:Label ID="Label5" runat="server" Text="Bus No" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-top: 10px">
                                                <asp:Label ID="Label7" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-top: 10px">
                                                <asp:Label ID="idv1" runat="server" Text="Available Seats" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-top: 10px">
                                                <asp:Label ID="lab1" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="std1" runat="server" style="padding: 0 0 10px 0">
                                            <td colspan="2" align="left" runat="server">
                                                <br />
                                                <asp:Label ID="Label6" runat="server" CssClass="textheadcss">Select Student</asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr id="std2" runat="server" style="padding: 0 0 10px 0">
                                            <td id="Td11" align="left" runat="server">
                                                <div runat="server" id="theDiv" style='overflow: scroll; width: 190px; height: 180px;'>
                                                    <asp:CheckBox ID="chkAll" Style="margin-top: 10px; margin-left: 7px;" runat="server"
                                                        Text="All" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" CssClass="textsize" />
                                                    <asp:CheckBoxList ID="chkSubmodule" Style="margin-top: 20px; margin-left: 10px;"
                                                        runat="server" AutoPostBack="True" CssClass="textsize" DataTextField="name" DataValueField="intStudent_id"
                                                        OnSelectedIndexChanged="chkSubmodule_SelectedIndexChanged">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </td>
                                            <td runat="server">
                                                <div runat="server" id="Div1" style='overflow: scroll; width: 220px; height: 182px;'>
                                                    <asp:TextBox ID="txt1" runat="server" Style='overflow: scroll; width: 230px; border: none;
                                                        height: 180px;' TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Button runat="server" Style="position: relative; left: 32px;" ID="submit" CssClass="efficacious_send"
                                                                Text="Submit" ValidationGroup="a" OnClick="submit_Click" />
                                                            <asp:HiddenField ID="hid1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

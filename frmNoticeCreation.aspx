<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmNoticeCreation.aspx.cs" Inherits="frmNoticeCreation" Title="Notice Board"
    Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="930px">
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Notice Creation</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <asp:UpdatePanel ID="upd1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td align="left" nowrap="nowrap">
                                                    <asp:Label ID="Label2" runat="server" CssClass="textcss">Type of User</asp:Label>
                                                </td>
                                                <td align="left" runat="server" class="style1">
                                                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Width="100px"
                                                        OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" CssClass="textcss">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="DropDownList4"
                                                        CssClass="textcss" Display="None" ErrorMessage="Select Type Of User" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="R1" runat="server">
                                                <td align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label6" runat="server" CssClass="textcss">Standard Id</asp:Label>
                                                </td>
                                                <td align="left" runat="server" class="style1">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="100px"
                                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="textcss">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req2" runat="server" ControlToValidate="DropDownList1"
                                                        CssClass="textcss" Display="None" ErrorMessage="Select Standard" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="Vali2" runat="server" Enabled="True" TargetControlID="Req2">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R2" runat="server">
                                                <td align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label11" runat="server" CssClass="textcss">Division Id</asp:Label>
                                                </td>
                                                <td align="left" runat="server" class="style1">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Width="100px"
                                                        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="textcss">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req3" runat="server" ControlToValidate="DropDownList2"
                                                        CssClass="textcss" Display="None" ErrorMessage="Select Division" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                        TargetControlID="Req3">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R3" runat="server">
                                                <td align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label18" runat="server" CssClass="textcss">Student Roll No</asp:Label>
                                                </td>
                                                <td align="left" runat="server" class="style1">
                                                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="100px"
                                                        Height="16px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CssClass="textcss">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req4" runat="server" ControlToValidate="DropDownList3"
                                                        CssClass="textcss" Display="None" ErrorMessage="Select Student Roll No" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="Vali4" runat="server" Enabled="True" TargetControlID="Req4">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R4" runat="server">
                                                <td id="Td9" align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label3" runat="server" CssClass="textcss">Department</asp:Label>
                                                </td>
                                                <td id="Td11" align="left" runat="server" class="style1">
                                                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" Width="100px"
                                                        OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" CssClass="textcss">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req6" runat="server" ControlToValidate="DropDownList3"
                                                        CssClass="textcss" Display="None" ErrorMessage="Select Department" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                                        TargetControlID="Req6">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R5" runat="server">
                                                <td id="Td12" align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label5" runat="server" CssClass="textcss">Staff Id</asp:Label>
                                                </td>
                                                <td id="Td14" align="left" runat="server" class="style1">
                                                    <asp:DropDownList ID="DropDownList6" runat="server" Width="100px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" CssClass="textcss">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req10" runat="server" ControlToValidate="DropDownList6"
                                                        CssClass="textcss" Display="None" ErrorMessage="Select Staff Id" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                                        TargetControlID="Req10">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="Temp2" runat="server">
                                                <td id="Td1" align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label12" runat="server" CssClass="textcss" Font-Bold="False">Date of Issue</asp:Label>
                                                </td>
                                                <td id="Td2" runat="server" align="left" class="style1">
                                                    <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="100px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="TextBox5"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req7" runat="server" ErrorMessage="Select Date Of Issue"
                                                        CssClass="textcss" ControlToValidate="TextBox5" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                                        TargetControlID="Req7">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="ComValidator" Operator="GreaterThanEqual" Type="Date" ControlToValidate="TextBox5"
                                                        ControlToCompare="HiddenTodayDate" ErrorMessage="'Date Of Issue' must be After today's date"
                                                        runat="server" Display="None" CssClass="textcss" />
                                                    <asp:ValidatorCalloutExtender ID="Val11" runat="server" Enabled="True" TargetControlID="ComValidator">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="Temp3" runat="server">
                                                <td id="Td3" align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label13" runat="server" CssClass="textcss" Font-Bold="False">Date of Expire</asp:Label>
                                                </td>
                                                <td id="Td4" runat="server" align="left" class="style1">
                                                    <asp:TextBox ID="TextBox7" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="100px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="TextBox7"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req8" runat="server" CssClass="textcss" ErrorMessage="Select Date Of Expired"
                                                        ControlToValidate="TextBox7" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                                        TargetControlID="Req8">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="ComValidator1" Operator="GreaterThanEqual" Type="Date"
                                                        ControlToValidate="TextBox7" ControlToCompare="HiddenTodayDate" ErrorMessage="'Date Of Expire' must be After today's date"
                                                        runat="server" Display="None" CssClass="textcss" />
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                                        TargetControlID="ComValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="Temp4" runat="server">
                                                <td id="Td5" align="left" runat="server" nowrap="nowrap">
                                                    <asp:Label ID="Label14" runat="server" CssClass="textcss" Font-Bold="False">Date of Activation</asp:Label>
                                                </td>
                                                <td id="Td6" runat="server" align="left" class="style1">
                                                    <asp:TextBox ID="TextBox12" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="100px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="TextBox12"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="Req9" runat="server" CssClass="textcss" ErrorMessage="Select Date Of Activation"
                                                        ControlToValidate="TextBox12" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                                        TargetControlID="Req9">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="CompValidator2" Operator="GreaterThanEqual" Type="Date"
                                                        ControlToValidate="TextBox12" ControlToCompare="HiddenTodayDate" ErrorMessage="'Date Of Expire' must be After today's date"
                                                        runat="server" Display="None" CssClass="textcss" />
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True"
                                                        TargetControlID="CompValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:TextBox ID="HiddenTodayDate" Visible="false" runat="server" />
                                                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="textcss" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #TextArea1
        {
            width: 125px;
            margin-left: 10px;
        }
        .style1
        {
        }
    </style>

    <script type="text/javascript">
        function CheckDate(ctrl) {
            var dt = new Date();
            var cdt = Date.parse(ctrl.value);
            if (cdt > dt) {
                alert('Date greater than Today');
            }
        }
    </script>

</asp:Content>

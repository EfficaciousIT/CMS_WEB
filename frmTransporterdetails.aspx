<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmTransporterdetails.aspx.cs" Inherits="frmTransporterdetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style2
        {
            width: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <fieldset style="width: 500px;">
            <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                Add Vehicle Details</legend>
            <table style="width: 373px; margin: 10px 0; font-family: Verdana" align="center">
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lblvchno" runat="server">Transporter name</asp:Label>
                    </td>
                    <td align="left" width="230">
                        <asp:TextBox ID="txtvchno" runat="server" Font-Names="Verdana" MaxLength="20" Font-Size="Small"
                            ForeColor="Black" Width="200" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;<asp:Label
                                ID="lblvn" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lblvchmake" runat="server">Contact Person</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana" MaxLength="20" Font-Size="Small"
                            Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;<%--<asp:Label ID ="lblvm" runat="server" Text="*" ForeColor="Red"></asp:Label>--%><%--<asp:RequiredFieldValidator ValidationGroup="b" ID="RequiredFieldValidator1" runat="server" SetFocusOnError="True"
                            ControlToValidate="txtvchmake" Display="None" ErrorMessage="Enter Vehicle Make"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator1"
                            HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lblvchdrivername" runat="server" Text="Telphone 1"></asp:Label>
                    </td>
                    <td align="left">
                        <%--<asp:Label ID ="lbldn" runat="server" Text="*" ForeColor="Red"></asp:Label>--%><%--<asp:RequiredFieldValidator ValidationGroup="b" ID="RequiredFieldValidator15" runat="server" SetFocusOnError="True"
                            ControlToValidate="txtvchdrivername" Display="None" ErrorMessage="Enter Driver Name "></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="RequiredFieldValidator15"
                            HighlightCssClass="validatorCalloutHighlight">
                        </asp:ValidatorCalloutExtender>--%><asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana"
                            MaxLength="20" Font-Size="Small" Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lbldrivermobno" runat="server" Text="Telphone 2"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtvchmake1" runat="server" Font-Names="Verdana" MaxLength="20"
                            Font-Size="Small" Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lbldrivermobno0" runat="server" Text="Mobile No"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtvchmake2" runat="server" Font-Names="Verdana" MaxLength="20"
                            Font-Size="Small" Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lbldrivermobno1" runat="server" Text="Email ID"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtvchmake3" runat="server" Font-Names="Verdana" MaxLength="20"
                            Font-Size="Small" Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lbldrivermobno2" runat="server" Text="Contract start date"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtvchmake4" runat="server" Font-Names="Verdana" MaxLength="20"
                            Font-Size="Small" Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                    </td>
                </tr>
                <tr height="35">
                    <td align="left" class="style1">
                        <asp:Label ID="lbldrivermobno3" runat="server" Text="Contract end date"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtvchmake5" runat="server" Font-Names="Verdana" MaxLength="20"
                            Font-Size="Small" Width="200" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                    </td>
                </tr>
                <tr height="35" valign="bottom">
                    <td align="center" class="style1">
                        &nbsp;
                    </td>
                    <td align="left">
                        <table style="width: 100%">
                            <tr>
                                <td class="style2">
                                    <asp:Button ID="Button2" runat="server" Text="Submit" />
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </fieldset>
    </center>
</asp:Content>

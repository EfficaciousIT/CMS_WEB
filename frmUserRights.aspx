<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmUserRights.aspx.cs" Inherits="frmUserRights" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {            
            font-family:Verdana;
            
        }
        .style2
        {
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table class="style1">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Type"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpType" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpDepartment" runat="server" 
                        onselectedindexchanged="drpDepartment_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label2" runat="server" Text="User"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpUser" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label3" runat="server" Text="Parent"></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:DropDownList ID="drpParent" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="drpParent_SelectedIndexChanged1">
                        <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label4" runat="server" Text="Module"></asp:Label>
                </td>
                <td align="left">
                    <asp:CheckBoxList ID="chkModule" runat="server" Width="161px">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr visible="false" runat="server">
                <td align="left">
                    <asp:Label ID="Label5" runat="server" Text="Sub-Module"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpSubmodule" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" />
                </td>
                
            </tr>
        </table>
    </center>
</asp:Content>

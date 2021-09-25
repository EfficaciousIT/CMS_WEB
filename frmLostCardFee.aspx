<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmLostCardFee.aspx.cs" Inherits="frmLostCardFee" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 5px;
        }
        .style2
        {
            width: 149px;
        }
        .style3
        {
            width: 293px;
        }
        .style4
        {
            height: 26px;
        }
        .style5
        {
            width: 293px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" OnRowDataBound="GridView1_RowDataBound" Width="800px" OnRowEditing="GridView1_RowEditing">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Payment">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkpay" runat="server" Font-Underline="true" CommandName="Edit">Pay</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="adate" HeaderText="Apply date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ldate" HeaderText="Lost date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reason" HeaderText="Reason">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="amount" HeaderText="Amount">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>                                    
                                </Columns>
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdpayment" runat="server" visible="false">
                            <table class="style1" align="left">
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="Label1" runat="server" Text="Select Payment"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Debit card" AutoPostBack="True"
                                            GroupName="drp" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                    </td>
                                    <td align="center" class="style3">
                                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Credit card" AutoPostBack="True"
                                            GroupName="drp" OnCheckedChanged="RadioButton2_CheckedChanged" />
                                    </td>
                                    <td align="center">
                                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Net banking" AutoPostBack="True"
                                            GroupName="drp" OnCheckedChanged="RadioButton3_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style4">
                                        &nbsp;
                                    </td>
                                    <td class="style5">
                                        &nbsp;
                                        <table class="style1">
                                            <tr>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="Label2" runat="server" Text="Select provider / Bank"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drppayment" runat="server" Height="22px" Width="135px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="drppayment_SelectedIndexChanged">
                                                        <asp:ListItem>---Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="style4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style3" align="center">
                                        <asp:Button ID="btnproceed" runat="server" Text="Proceed" Visible="False" />
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

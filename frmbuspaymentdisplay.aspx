<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmbuspaymentdisplay.aspx.cs" Inherits="frmbuspaymentdisplay" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="efficacious">
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
                            <asp:BoundField DataField="route" HeaderText="Route name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Startpoint" HeaderText="Start point">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="endpoint" HeaderText="End point">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="btype" HeaderText="Bill Type">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="Amount">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="duedate" HeaderText="Due date">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td id="tdpayment" runat="server" visible="false">
                    <table  align="left">
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Label ID="Label1" runat="server" Text="Select Payment"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="Debit card" 
                                    AutoPostBack="True" GroupName="drp" 
                                    oncheckedchanged="RadioButton1_CheckedChanged" />
                            </td>
                            <td align="center">
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="Credit card" 
                                    AutoPostBack="True" GroupName="drp" 
                                    oncheckedchanged="RadioButton2_CheckedChanged" />
                            </td>
                            <td align="center">
                                <asp:RadioButton ID="RadioButton3" runat="server" Text="Net banking" 
                                    AutoPostBack="True" GroupName="drp" 
                                    oncheckedchanged="RadioButton3_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td >
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td c>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                                <table >
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label2" runat="server" Text="Select provider / Bank"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drppayment" runat="server" Height="22px" Width="135px" 
                                                AutoPostBack="True" onselectedindexchanged="drppayment_SelectedIndexChanged">
                                                <asp:ListItem>---Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table><tr><td>
                              
                           
                                <asp:Button    ID="btnproceed" runat="server" CssClass="efficacious_send" Text="Proceed" Visible="False" />
                                &nbsp;
                            </td>
                          </td></tr></table>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
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
        </div>
</asp:Content>

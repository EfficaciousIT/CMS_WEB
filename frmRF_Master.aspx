<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmRF_Master.aspx.cs" Inherits="frmRF_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function validation() {
            if (Page_ClientValidate()) {
                var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
                if (btn == 'Submit') {
                    var msg = confirm('Do You Want To Save Entered Record?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    var msg = confirm('Do You Want To Update Entered Record?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }

        }

        function ConfirmDelete() {
            var msg = confirm('Do You Really Want To Delete Selected Record?');
            if (msg) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ActiveTabIndex="1" ID="tbc1" Width="100%">
                            <asp:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    Detail
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="60%">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvRF" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="mGrid" EmptyDataText="Record not Found." OnPageIndexChanging="grvRF_PageIndexChanging"
                                                        PageSize="5" DataKeyNames="intRFid" Width="100%" OnRowEditing="grvRF_RowEditing"
                                                        OnRowDeleting="grvRF_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" CausesValidation="false"
                                                                        OnClientClick="return ConfirmDelete();" ImageUrl="~/images/delete.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" CausesValidation="false"
                                                                        ImageUrl="~/images/edit.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="vchRF_No" HeaderText="RF Number" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="intPort" HeaderText="Port" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchIP" HeaderText="IP" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <RowStyle HorizontalAlign="Left" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <PagerStyle CssClass="pgr" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel2" runat="server">
                                <HeaderTemplate>
                                    Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="60%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblRFNum" runat="server" Text="RF Number" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtRFNo" runat="server" AutoComplete="Off" CssClass="textsize" MaxLength="20"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="txtRFNo" ErrorMessage="Please Enter RF Number"
                                                        Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="V1" runat="server" TargetControlID="R1" Enabled="True">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPort" runat="server" Text="Port" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPort" runat="server" AutoComplete="Off" CssClass="textsize" MaxLength="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="txtPort" ErrorMessage="Please Enter Port Number"
                                                        Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="V2" runat="server" TargetControlID="R2" Enabled="True">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPort"
                                                        FilterType="Numbers" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblIP" runat="server" Text="IP" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtIP" runat="server" AutoComplete="Off" CssClass="textsize" MaxLength="20"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="R3" runat="server" ControlToValidate="txtIP" ErrorMessage="Please Enter IP Address"
                                                        Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="V3" runat="server" TargetControlID="R3" Enabled="True">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:FilteredTextBoxExtender runat="server" TargetControlID="txtIP" FilterType="Custom, Numbers"
                                                        ValidChars="." ID="F1" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    <br />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnSubmit" runat="server" OnClientClick="return validation();" OnClick="btnSubmit_Click"
                                                        Text="Submit" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                        CausesValidation="False" onclick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
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

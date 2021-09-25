<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmBookStatus.aspx.cs" Inherits="frmBookStatus" Title="Library Management"
    Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>
.mGrid th{ text-align:center !important;}
.efficacious span{ margin-bottom:0px !important;     margin: 2% 5% !important;}

</style>
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 5px 0 0 0">
                    <center>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                                ActiveTabIndex="1">
                                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                    <HeaderTemplate>
                                                        Book Detail</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <br />
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <center>
                                                                        <table width="50%">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblCategory" style="font-size:13px; color:000;" runat="server" Text="Category"></asp:Label>
                                                                                </td>
                                                                                <td style="padding: 0 0 0 10px">
                                                                                    <asp:DropDownList ID="drpCategory" runat="server" style=" width:130px; padding:5px; border:1px solid #3498db; border-radius:5px; -webkit-border-radius:5px;  -moz-border-radius:5px;" AutoPostBack="True" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                                                                        <asp:ListItem>---Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="center">
                                                                                    &#160;&#160;
                                                                                </td>
                                                                                <td>
                                                                                    &#160;&#160;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grgBooks" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CssClass="mGrid" Width="100%" EmptyDataText="No Books available" DataKeyNames="intbook_id,intBookRef_no,vchBook_name,vchAuthor,vchPublication,vchcategory_name,available"
                                                                        OnRowEditing="grgBooks_RowEditing">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="intbook_id" HeaderText="Id" Visible="False" />
                                                                            <asp:TemplateField HeaderText="Assign">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                                                        ImageUrl="~/images/assign.png" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="intBookRef_no" HeaderText="Book No" ReadOnly="True" />
                                                                            <asp:BoundField DataField="vchBook_name" HeaderText="Title" ReadOnly="True" />
                                                                            <asp:BoundField DataField="vchAuthor" HeaderText="Author" ReadOnly="True" />
                                                                            <asp:BoundField DataField="vchPublication" HeaderText="Publication" ReadOnly="True" />
                                                                            <asp:BoundField DataField="vchcategory_name" HeaderText="Category" ReadOnly="True" />
                                                                            <asp:BoundField DataField="available" HeaderText="Availabilty" ReadOnly="True" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        Assign</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <div id="divEntry" class="efficacious" runat="server">
                                                                <table width="50%" style="text-align: right">
                                                                    <tr>
                                                                        <td align="justify">
                                                                            <asp:Label ID="Label1" runat="server" Text="Book Reff" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:Label ID="lblBookReff" runat="server" CssClass="textcss" Text="Book Reff"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify">
                                                                            <asp:Label ID="Label2" runat="server" Text="Title" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:Label ID="lblTitle" runat="server" CssClass="textcss" Text="Title"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style3">
                                                                            <asp:Label ID="Label5" runat="server" CssClass="textcss" Text="Author"></asp:Label>
                                                                        </td>
                                                                        <td align="left" class="auto-style4" colspan="2">
                                                                            <asp:Label ID="lblAuthor" runat="server" CssClass="textcss" Text="Author"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label4" runat="server" Text="Publication" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="left" class="auto-style6" colspan="2">
                                                                            <asp:Label ID="lblPublication" runat="server" CssClass="textcss" Text="Publication"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label6" runat="server" Text="Category" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="left" class="auto-style6" colspan="2">
                                                                            <asp:Label ID="lblCategoryText" runat="server" Text="Category" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label11" runat="server" CssClass="textcss" style="    position: relative;  top: 6px;" Text="Library Card"></asp:Label>
                                                                        </td>
                                                                        <td align="left" class="auto-style6" style="padding-left: 27px" colspan="2">
                                                                            <asp:TextBox ID="txtLibrarycard" runat="server" AutoPostBack="True" OnTextChanged="txtLibrarycard_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label7" runat="server" Text="Assign To" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="left" class="auto-style6" colspan="2">
                                                                            <asp:Label ID="lblAssignTo" runat="server" CssClass="textcss" Text="Assign"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label8" runat="server" Text="Issue Date" style="    position: relative;  top: 9px;" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" class="auto-style6" style="padding-left: 27px" colspan="2">
                                                                            &#160;&#160;<asp:TextBox ID="txtAssignDate" runat="server" AutoComplete="Off" AutoPostBack="True"
                                                                                CssClass="textsize" MaxLength="10"></asp:TextBox><asp:CalendarExtender ID="txtAssignDate_CalendarExtender"
                                                                                    runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtAssignDate">
                                                                                </asp:CalendarExtender>
                                                                            <asp:TextBoxWatermarkExtender ID="txtAssignDate_TextBoxWatermarkExtender" runat="server"
                                                                                Enabled="True" TargetControlID="txtAssignDate" WatermarkText="Assign Date">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label9" runat="server" Text="Return Date" style="    position: relative;  top: 9px;" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" class="auto-style6" style="padding-left: 27px" colspan="2">
                                                                            &#160;&#160;<asp:TextBox ID="txtReturnDate" runat="server" AutoComplete="Off" AutoPostBack="True"
                                                                                CssClass="textsize" MaxLength="10"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2"
                                                                                    runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtReturnDate">
                                                                                </asp:CalendarExtender>
                                                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                                                TargetControlID="txtReturnDate" WatermarkText="Return Date">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style6">
                                                                            <asp:Label ID="Label10" runat="server" CssClass="textcss" style="    position: relative;  top: 9px;" Text="Actual Return Date"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" colspan="2" style="padding-left: 27px" class="auto-style6">
                                                                            &#160;&#160;<asp:TextBox ID="txtActReturnDate" runat="server" AutoComplete="Off"
                                                                                AutoPostBack="True" CssClass="textsize" MaxLength="10"></asp:TextBox><asp:CalendarExtender
                                                                                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtActReturnDate">
                                                                                </asp:CalendarExtender>
                                                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                                                                TargetControlID="txtActReturnDate" WatermarkText="Actual Return Date">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style3">
                                                                            &#160;
                                                                        </td>
                                                                        <td width="100%" align="left" valign="top" colspan="2">
                                                                            &#160;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td align="left" dir="rtl" valign="top" width="50%" style="position:relative; left:25px">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send"  OnClientClick="return ConfirmInsertUpdate();"
                                                                                Text="Submit" OnClick="btnSubmit_Click" />&#160;&#160;&#160;&#160;&#160;
                                                                        </td>
                                                                        <td align="left" dir="rtl" valign="top" width="50%">
                                                                            &#160;&#160;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style5">
                                                                        </td>
                                                                        <td align="justify" class="auto-style5" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="auto-style5" colspan="3">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
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
                    </center>
                </div>
            </td>
            <td align="right" width="100%" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="right" width="100%" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

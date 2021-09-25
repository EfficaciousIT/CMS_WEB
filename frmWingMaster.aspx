<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmWingMaster.aspx.cs" Inherits="frmWingMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function confirmMsg() {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {
                var msg = confirm('Do You Really Want To Save Entered Record ?');
                if (msg) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var msg = confirm('Do You Really Want To Update Entered Record ?');
                if (msg) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Asset Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li> <a href="frmBuildingMaster.aspx"> Building Master </a></li>
                  <li class="active1"><a href="frmWingMaster.aspx"> Wing Master</a></li>
                  <li><a href="frmFloorMaster.aspx">Floor Master</a></li>   
                  <li><a href="frmRoomMaster.aspx"> Room Master</a></li>
                  <li><a href="frmEquipItemMaster.aspx">Item Master</a></li>
                  <li><a href="frmItemTypeMaster.aspx"> Item Details Master</a></li>
        </ul>
    </div>
<section class="content">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" Width="70%" 
                            ActiveTabIndex="1">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <left>
                                        <table width="100%">
                                            <caption>
                                                &nbsp;
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowPaging="True" 
                                                        AllowSorting="True" AutoGenerateColumns="False" 
                                                        CssClass="table  tabular-table " DataKeyNames="intWing_id" 
                                                        OnPageIndexChanging="grvDetail_PageIndexChanging" 
                                                        OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing" 
                                                        Width="50%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Floor_Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("intWing_id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="intBuilding_id" HeaderText="Building Name" 
                                                                ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Building_wing" HeaderText="Wing Name" 
                                                                ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" 
                                                                        ImageUrl="~/images/edit.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="true" 
                                                                        CommandName="Delete" ImageUrl="~/images/delete.png" 
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record ?');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
</caption></table>
                                    </left>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TB2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <left>
                                        <div class="efficacious">
                                            <table width="50%">
                                                <tr>
                                                    <td hei>
                                                    </td>
                                                    <td colspan="2">
                                                    &nbsp
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td align="Left" width="50%">
                                                        <asp:Label ID="Label7" runat="server" Text="Building Name"></asp:Label>
                                                    </td>
                                                    <td align="left" width="100%">
                                                        <asp:DropDownList ID="drpBuilding" 
                                                            runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td align="Left">
                                                        <asp:Label ID="Label2" runat="server" Text="Wing"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtWing" runat="server" CssClass="input-blue" MaxLength="50" ToolTip="Enter Wing Here "></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtWing"
                                                            FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" 
                                                            ValidChars=" " Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                     <td align="right">
                                                       
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            Text="Submit" onclick="btnSubmit_Click">
                                                        </asp:Button>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" Visible="False"
                                                            Text="Cancel" 
                                                           />
                                                    </td>
                                                </tr>
                                            </table>
</div>
                                    </left>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>


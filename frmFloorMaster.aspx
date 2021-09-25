<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmFloorMaster.aspx.cs" Inherits="frmFloorMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function confirmMsg() {
            var txt = document.getElementById("<%=txtFloor.ClientID %>").value;
            if (txt.trim() == '') {
                alert('Please Enter Floor Name');
                return false
            }
            else {
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
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Asset Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li> <a href="frmBuildingMaster.aspx"> Building Master </a></li>
                  <li><a href="frmWingMaster.aspx"> Wing Master</a></li>
                  <li class="active1"><a href="frmFloorMaster.aspx">Floor Master</a></li>   
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
                            ActiveTabIndex="0">
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
                                                        CssClass="table  tabular-table " DataKeyNames="intFloor_id" 
                                                        OnPageIndexChanging="grvDetail_PageIndexChanging" 
                                                        OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing" 
                                                        Width="50%"><Columns>
<asp:TemplateField HeaderText="Floor_Id" Visible="False">
    <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFloor_id") %>'></asp:Label>
                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="intBuilding_id" HeaderText="Building Name" 
                                                                ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="intWing_id" HeaderText="Wing Name" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="vchFloor_name" HeaderText="Floor Name" 
                                                                ReadOnly="True"></asp:BoundField>
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
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                &nbsp;
                                                </tr>
                                                 <tr>
                                                  <td width="10%">
                                                     
                                                    </td>
                                                    <td align="left"  width="50%">
                                                        <asp:Label ID="Label7" runat="server" Text="Building Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="drpBuilding" 
                                                            runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpBuilding_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                     
                                                    </td>
                                                </tr>

                                                 <tr>
                                                 <td width="10%">
                                                      
                                                    </td>
                                                    <td align="left"  width="50%">
                                                        <asp:Label ID="Label1" runat="server" Text="Wing Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="drpWing" 
                                                            runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td width="10%">
                                                       
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblFloor" runat="server" Text="Floor Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtFloor" runat="server" CssClass="input-blue" MaxLength="50" ToolTip="Enter Floor Name Here "></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server" TargetControlID="txtFloor"
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
                                                    <td>
                                                       &nbsp
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                             Text="Submit" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" Text="Cancel"
                                                            OnClick="btnCancel_Click" Visible="False" />
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

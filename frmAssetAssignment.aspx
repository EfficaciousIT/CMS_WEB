<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmAssetAssignment.aspx.cs" Inherits="frmAssetAssignment" %>

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
            if (Page_ClientValidate() == false) {
                return false;
            }
            else {
                var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
                if (btn == 'Submit') {
                    var msg = confirm('Do You Really Want To Save Entered Records ?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    var msg = confirm('Do You Really Want To Update Entered Records ?');
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
    <style type="text/css">
        .efficacious span
        {
            margin: 5px 0 5px 0 !important;
            padding: 0 !important;
        }
        .style1
        {
            height: 22px;
        }
        .style4
        {
            width: 107px;
        }
        .style6
        {
            height: 22px;
            width: 207px;
        }
        .style7
        {
            width: 207px;
        }
        .style8
        {
            width: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Asset Management <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li class="active1"> <a> Asset Management</a></li>                  
        </ul>
    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer CssClass="MyTabStyle" ID="TBC" Width="100%" runat="server" 
                            ActiveTabIndex="1">
                            <asp:TabPanel ID="TB1" runat="server">
                                <HeaderTemplate>
                                    Details</HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <center>
                                        <asp:GridView ID="grvDetail" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                            Width="100%" DataKeyNames="intAsset_id" AllowPaging="false" OnPageIndexChanging="grvDetail_PageIndexChanging"
                                            OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="intBuilding_id" HeaderText="Building" ReadOnly="True" />
                                                <asp:BoundField DataField="intWing_id" HeaderText="Wing" ReadOnly="True" />
                                                <asp:BoundField DataField="intFloor_id" HeaderText="Floor" ReadOnly="True" />
                                                <asp:BoundField DataField="intRoom_id" HeaderText="Room" ReadOnly="True" />
                                                <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" />
                                                <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />
                                                <asp:BoundField DataField="intEquipItem_id" HeaderText="Item" ReadOnly="True" />
                                                <asp:BoundField DataField="vchQuantity" HeaderText="Quantity" ReadOnly="True" />
                                                <asp:BoundField DataField="intType_id" HeaderText="Item Details" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="intAsset_id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("intAsset_id") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                            OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');"
                                                            ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TB2" runat="server">
                                <HeaderTemplate>
                                    New Entry</HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <center>
                                        <div class="efficacious">
                                            <table width="55%">
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label7" runat="server" Text="Building Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="drpBuilding" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBuilding_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label3" runat="server" Text="Wing Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="drpWing" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpWing_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label1" runat="server" Text="Floor"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label2" runat="server" Text="Room"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlRoom" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label4" runat="server" Text="Standard"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label5" runat="server" Text="Division"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label6" runat="server" Text="Item"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="lblqty" runat="server" Text="Quantity"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:TextBox ID="txtQty" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:Label ID="Label8" runat="server" Text="Item Details"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlItemDetails" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td class="style7" align="right">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" valign="top" width="30%">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                            OnClientClick="return confirmMsg();" Text="Submit" />
                                                    </td>
                                                    <td align="left" width="50%">
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                            Visible="False" Text="Clear" />
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;&nbsp;
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
</section>
</asp:Content>

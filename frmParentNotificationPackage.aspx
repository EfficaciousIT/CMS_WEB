<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmParentNotificationPackage.aspx.cs" Inherits="frmParentNotificationPackage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type"text/css">
     <style type="text/css">
     
         .mGrid th { text-align:center !important;}
   
   
 .efficacious input[type="radio"] {
  width: 24px;
  float: left;
  margin: 0 auto;
  margin-right: 10px;
  margin-top: 10px;
}
.mGrid th{ text-align:center !important;}
.efficacious input[type=radio] + label {
  display: block;
  padding: 11px 0px;
  border: 0.0625em solid rgb(192,192,192);
  border-radius: 5px;
  background: #9fd727 !important;
  vertical-align: middle;
  line-height: 1em;
  font-size: 14px;
  outline: 0; width:115px;
  margin-left: 20px;   float: inherit !important;
}
<!--[if IE 11]>
.efficacious input[type=checkbox], input[type=radio]{ background:#f5f5f5 !important; border:0 !important;}
.efficacious input[type=radio]{ width:18px !important; height:18px !important; background:#f5f5f5 !important;}
<![endif]-->

.efficacious input[type=radio] + label{   background: rgb(248, 158, 54) !important; color:#fff !important; font-weight:bold; width:115px !important; height:auto; border-radius:5px !important; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server"    ActiveTabIndex="1"
                            Width="1015px">
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    New Package</HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center" class="style1">
                                                        <asp:Label ID="Label8" runat="server" Text="Travel Details" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                    <div class="efficacious">
                                                        <table width="50%" style="height: 270px">
                                                            <tr>
                                                                <td class="style5">
                                                                    &#160;&nbsp;
                                                                </td>
                                                                <td colspan="2">
                                                                    &#160;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="Label10" runat="server" Text="Package" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:DropDownList ID="ddlPackage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"
                                                                        CssClass="textsize">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="R3" InitialValue="0" ControlToValidate="ddlPackage"
                                                                        Display="None" runat="server" ErrorMessage="Please Select Package First" CssClass="textsize"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="Label11" runat="server" Text="No of SMS" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:Label ID="lblSMS" runat="server" Text="0" CssClass="textsize"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="Label12" runat="server" Text="No of Email" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:Label ID="lblEmail" runat="server" Text="0" CssClass="textsize"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="Label13" runat="server" Text="Data Space" CssClass="textsize"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:Label ID="lblSpace" runat="server" Text="0" CssClass="textsize"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="lblCurrency" runat="server" CssClass="textsize">Currency</asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:Label ID="lblCurr" runat="server" CssClass="textsize" Text="0"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="lblAmount" runat="server" CssClass="textsize">Amount</asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:Label ID="lblAmt" runat="server" CssClass="textsize" Text="0"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="lblNoOfPackage" runat="server" CssClass="textsize" Visible="False">No Of Package</asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:TextBox ID="txtNoOfPackage" runat="server" CssClass="textsize" 
                                                                        AutoComplete="Off" AutoPostBack="True" MaxLength="4" Visible="False"></asp:TextBox><asp:RequiredFieldValidator
                                                                            ID="R1" ControlToValidate="txtNoOfPackage" Display="None" runat="server" ErrorMessage="Please Enter No Of Packages To Be Buy"
                                                                            CssClass="textsize" Visible="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="ValidatorCalloutExtender7" runat="server" PopupPosition="Right" TargetControlID="R1">
                                                                            </asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="middle">
                                                                    <asp:Label ID="lblTot" runat="server" CssClass="textsize" Visible="False">Total Amount</asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:Label ID="lblTotalAmount" runat="server" CssClass="textsize" Visible="False">0</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblPayMode" runat="server" CssClass="textsize">Payment Mode</asp:Label>
                                                                </td>
                                                                <td align="left" class="style1" valign="top" colspan="2">
                                                                    <asp:RadioButtonList ID="RDB" runat="server" CssClass="textsize" RepeatDirection="Horizontal"
                                                                        Height="18px" OnSelectedIndexChanged="RDB_SelectedIndexChanged" 
                                                                        AutoPostBack="True">
                                                                        <asp:ListItem Selected="True">Cheque</asp:ListItem>
                                                                        <asp:ListItem>Cash</asp:ListItem>
                                                                        <asp:ListItem>Online</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblMode" runat="server" CssClass="textsize">Cheque No.</asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <asp:TextBox ID="txtMode" AutoComplete="Off" runat="server" CssClass="textsize"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style5" align="left">
                                                                    &nbsp;</td>
                                                                <td align="left" width="50%">
                                                                    <asp:Button ID="btnBuy" runat="server" CausesValidation="true" 
                                                                        CssClass="efficacious_send" OnClick="btnBuy_Click" 
                                                                        OnClientClick="return Confirm();" Text="Buy" />
                                                                </td>
                                                                <td align="left" width="50%">
                                                                    <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" 
                                                                        OnClick="btnCancel_Click" Text="Cancel" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                <HeaderTemplate>
                                    Current Package</HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="style2">
                                                            <asp:Label ID="Label1" runat="server" Text="Travel Details" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left" class="style2">
                                                            <asp:LinkButton ID="lnkPrevious" runat="server" Font-Underline="True" OnClick="lnkPrevious_Click"
                                                                Visible="False">Previous</asp:LinkButton>
                                                        </td>
                                                        <td align="left" class="style2">
                                                            <asp:LinkButton ID="lnkNext" runat="server" Font-Underline="True" OnClick="lnkNext_Click"
                                                                Visible="False">Next</asp:LinkButton>
                                                        </td>
                                                        <td align="right" class="style2">
                                                            <asp:DropDownList ID="ddlMonth" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" Visible="False">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grvCurrentPkg" EmptyDataText="No Records Found" runat="server"
                                                    AutoGenerateColumns="False" CssClass="mGrid" Width="100%" AllowPaging="True"
                                                    AllowSorting="True">
                                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    <Columns>
                                                        <asp:BoundField DataField="vchPackage_type" Visible="false" HeaderText="Type">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="vchPackage_name" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="intNoOfSMS" HeaderText="No of SMS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="intNoOfEmails" HeaderText="No of Email">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="fltDataSpace" HeaderText="Data Space">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dtStartDate" HeaderText="Start Date"></asp:BoundField>
                                                        <asp:BoundField DataField="dtEndate" HeaderText="End Date">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel3">
                                <HeaderTemplate>
                                    Expired Package</HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label2" runat="server" Text="Bus Service" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:LinkButton ID="lnkPrev1" runat="server" Font-Underline="True" OnClick="lnkPrev1_Click"
                                                                Visible="False">Previous</asp:LinkButton>
                                                        </td>
                                                        <td align="left">
                                                            <asp:LinkButton ID="lnkNxt" runat="server" Font-Underline="True" OnClick="lnkNxt_Click1"
                                                                Visible="False">Next</asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlMonth1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlMonth1_SelectedIndexChanged" Visible="False">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grvExpirePkg" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                    CssClass="mGrid" Width="1009px" AllowPaging="True" AllowSorting="True">
                                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    <Columns>
                                                        <asp:BoundField DataField="vchPackage_type" HeaderText="Type">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="vchPackage_name" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="intNoOfSMS" HeaderText="No of SMS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="intNoOfEmails" HeaderText="No of Email">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="fltDataSpace" HeaderText="Data Space">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dtStartDate" HeaderText="Start Date">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dtEndate" HeaderText="End Date">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

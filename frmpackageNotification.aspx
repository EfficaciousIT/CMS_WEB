<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmpackageNotification.aspx.cs" Inherits="frmpackageNotification" Title="Package Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
    <style type="text/css">
        .style1
        {
            height: 16px;
        }
        .style2
        {
            height: 21px;
        }
    </style>
 
 <script type="text/javascript" language="javascript">
     function Confirm() {
         if (Page_ClientValidate()) {
             var pack = document.getElementById("<%=ddlPackage.ClientID %>").value;
             var ChkList = document.getElementById("<%=RDB.ClientID %>").value;
             //alert(pack);
             if (pack == 0) {
                 alert('Please Select Package First');
                 return false;
             }
             else {
                 var save = confirm('Do You Really Want To Buy Selected Package?');
                 if (save == true) {
                     //   alert(save);
                     return true;
                 }
                 else {
                     //    alert(save);
                     return false;
                 }
             }
         }
     }

     function AmtCal() {
         var Amt = document.getElementById("<%=lblAmt.ClientID %>").innerText;
         var NoOFPack = document.getElementById('<%=txtNoOfPackage.ClientID %>').value;
         var cal = Amt * NoOFPack;
         document.getElementById("<%=lblTotalAmount.ClientID %>").innerText = cal;
     }
</script>
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <table width="100%">
    <tr>
    <td align="left">
    
    <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0" 
            Width="849px" >
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                New Package
            </HeaderTemplate>
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
                            <table width="40%" style="height:270px">
                                <tr>
                                    <td class="style5">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="Label10" runat="server" Text="Package" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left" valign="top" colspan="2" width="50%">
                                        <asp:DropDownList ID="ddlPackage" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" CssClass="textsize">
                                          
                                        </asp:DropDownList>

                                         <asp:RequiredFieldValidator ID="R2" InitialValue="0" ControlToValidate="ddlPackage" Display="None"
                                            runat="server" ErrorMessage="Please Select Package First" 
                                            CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="V2" runat="server" PopupPosition="Right"
                                            TargetControlID="R2">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="Label9" runat="server" Text="Type" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left" valign="top" colspan="2" width="50%">
                                        <asp:DropDownList ID="ddlPackageType" runat="server" CssClass="textsize" 
                                            Enabled="False">
                                          <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Free" Value="Free"></asp:ListItem>
                                            <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="Label11" runat="server" Text="No of SMS" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left" valign="top" colspan="2" width="50%">
                                        <asp:Label ID="lblSMS" runat="server" Text="0" CssClass="textsize"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="Label12" runat="server" Text="No of Email" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left" valign="top" colspan="2" width="50%">
                                        <asp:Label ID="lblEmail" runat="server" Text="0" CssClass="textsize"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="left" valign="top" width="40%">
                                        <asp:Label ID="Label13" runat="server" Text="Data Space" CssClass="textsize"></asp:Label>
                                    </td>
                                    <td align="left"  valign="top" colspan="2" width="50%">
                                        <asp:Label ID="lblSpace" runat="server" Text="0" CssClass="textsize"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="lblCurrency" runat="server" CssClass="textsize">Currency</asp:Label>
                                    </td>
                                    <td  align="left" valign="top" colspan="2" width="50%">
                                        <asp:Label ID="lblCurr" runat="server" CssClass="textsize" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="left" valign="top" width="40%">
                                        <asp:Label ID="lblAmount" runat="server" CssClass="textsize">Amount</asp:Label>
                                    </td>
                                    <td  align="left" valign="top" colspan="2" width="50%">
                                        <asp:Label ID="lblAmt" runat="server" CssClass="textsize" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                       
                                        <asp:Label ID="lblNoOfPackage" runat="server" CssClass="textsize">No Of Package</asp:Label>
                                       
                                    </td>
                                    <td align="left" valign="top" colspan="2" width="50%">
                                        <asp:TextBox ID="txtNoOfPackage" runat="server"  CssClass="textsize" 
                                            AutoComplete="Off" on AutoPostBack="True" 
                                            ontextchanged="txtNoOfPackage_TextChanged" MaxLength="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="R1" ControlToValidate="txtNoOfPackage" Display="None"
                                            runat="server" ErrorMessage="Please Enter No Of Packages To Be Buy" 
                                            CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server"  PopupPosition="Right" 
                                            TargetControlID="R1">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="lblTot" runat="server" CssClass="textsize">Total Amount</asp:Label>
                                    </td>
                                    <td align="left" valign="top" colspan="2" width="50%">
                                        <asp:Label ID="lblTotalAmount" runat="server" CssClass="textsize">0</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="lblPayMode" runat="server" CssClass="textsize">Payment Mode</asp:Label>
                                    </td>
                                    <td align="left" class="style1" valign="top" colspan="2" width="40%">
                                        <asp:RadioButtonList ID="RDB" runat="server" CssClass="textsize" 
                                            RepeatDirection="Horizontal" Height="18px" 
                                            onselectedindexchanged="RDB_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="0" Text="Cheque"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Cash"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Online"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                                        <asp:Label ID="lblRef" runat="server" CssClass="textsize" Visible="False"></asp:Label>
                                    </td>
                                    <td align="left" class="style1" valign="top" colspan="2" width="50%">
                                        <asp:TextBox ID="txtPayment" runat="server" CssClass="textsize" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="40%">
                                        &nbsp;</td>
                                    <td align="left" width="50%">
                                        <asp:Button ID="btnBuy" runat="server" CausesValidation="true" 
                                            CssClass="efficacious_send" onclick="btnBuy_Click" 
                                            OnClientClick="return Confirm();" Text="Buy" />
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" 
                                            onclick="btnCancel_Click" Text="Cancel" />
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
                Current package
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                   
                    <tr>
                        <td>
                            <asp:GridView ID="grvCurrentPkg" EmptyDataText="No Records Found" 
                                runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="100%" AllowPaging="True" AllowSorting="True">
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
                                    <asp:BoundField DataField="intNoOfPackage" HeaderText="Number Of Package">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="availablePack" HeaderText="Available Packages" />
                                    <asp:BoundField DataField="dtStartDate" HeaderText="Start Date">
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
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel3">
            <HeaderTemplate>
                Expired package
            </HeaderTemplate>
            <ContentTemplate>
                <table>
                    
                    <tr>
                        <td>
                            <asp:GridView ID="grvExpirePkg" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="800px" AllowPaging="True" AllowSorting="True">
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
                                    <asp:BoundField DataField="intNoOfPackage" HeaderText="No OF Package" />
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

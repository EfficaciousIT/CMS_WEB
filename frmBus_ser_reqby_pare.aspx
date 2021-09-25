<%@ Page Title="BusService Request" Language="C#" MasterPageFile="~/newMasterPage.master"
    AutoEventWireup="true" CodeFile="frmBus_ser_reqby_pare.aspx.cs" Inherits="frmBus_ser_reqby_pare" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=BusRequestDetail.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }    
    </script>
    <style type="text/css">
    
        .mGrid th {
 
  text-align: center !important;
 
}
.efficacious input[type="image"]{     width: 28%;
    margin: 0 auto;}
    .efficacious span {
    display: block;
    height: auto;
    padding: 3px 0px !important; 
    font-size: 12px;
   margin: 0 !important; 
   
    border-radius: 5px;
    -webkit-border-radius: 5px;
    -moz-border-radius: 5px;
    margin-bottom: 0px !important; 
    width: auto !important;  
    color: #000;
}
    </style>
    <table>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                    CssClass="MyTabStyle">
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Bus Service Request
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="efficacious">
                                <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                    <tr>
                                        <td style="padding: 10px 0 20px 0;" align="center">
                                            <asp:GridView ID="BusRequestDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="mGrid" Width="100%" DataKeyNames="intBusFees_Id" Font-Bold="False"
                                                OnSelectedIndexChanged="BusRequestDetail_SelectedIndexChanged" HorizontalAlign="Center"
                                                EnableModelValidation="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="intBusFees_Id" runat="server" Text='<%# Eval("intBusFees_Id")  %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="id11" onclick="RadioCheck(this);" AutoPostBack="true" DataTextField="intBusFees_Id"
                                                                DataValueField="intBusFees_Id" runat="server" />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("intBusFees_Id")  %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="intArea_Id" HeaderText="Area Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="intBus_Amount" HeaderText="Amount" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Submit" Text="Submit" runat="server" CssClass="efficacious_send"
                                                            OnClick="Submit_Click" />
                                                        <asp:TextBox ID="td1" runat="server" Visible="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Application Status
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="efficacious">
                                <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                    <tr>
                                        <td style="padding: 10px 0 20px 0;" align="center">
                                            <asp:GridView ID="GridVApp" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="mGrid" Width="100%" DataKeyNames="intService_id" Font-Bold="False"
                                                OnRowDeleting="GridVApp_RowDeleting" OnSelectedIndexChanged="GridVApp_SelectedIndexChanged"
                                                HorizontalAlign="Center">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="intService_id" runat="server" Text='<%# Eval("intService_id")  %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                OnClientClick="return messageConfirm('Do you want to Delete this Record ?');" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="intbus_amount" HeaderText="Amount" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtAppli_Date" HeaderText="Application Date" ReadOnly="True" />
                                                    <asp:BoundField DataField="vchApprovaStatus" HeaderText="Approval Status" ReadOnly="True" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Report
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="efficacious">
                                <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                    <tr>
                                        <td style="padding: 10px 0 20px 0;" align="center">
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="mGrid" Width="100%" DataKeyNames="intService_id" Font-Bold="False"
                                                OnRowDeleting="GridVApp_RowDeleting" OnSelectedIndexChanged="GridVApp_SelectedIndexChanged"
                                                HorizontalAlign="Center" EnableModelValidation="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="intService_id" runat="server" Text='<%# Eval("intService_id")  %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="intbus_amount" HeaderText="Amount" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtAppli_Date" HeaderText="Application Date" ReadOnly="True" />
                                                    <asp:BoundField DataField="vchApprovaStatus" HeaderText="Approval Status" ReadOnly="True" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                    <td align="center">
                                        <asp:Button    ID="Button2" Text="Submit" runat="server" OnClick="Submit_Click" />
                                        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>

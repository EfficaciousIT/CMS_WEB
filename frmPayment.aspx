<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmPayment.aspx.cs" Inherits="frmPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
    prm.add_beginRequest(BeginRequestHandler);
    // Raised after an asynchronous postback is finished and control has been returned to the browser.
    prm.add_endRequest(EndRequestHandler);
    function BeginRequestHandler(sender, args) {
        //Shows the modal popup - the update progress
        var popup = $find('<%= modalPopup.ClientID %>');
        if (popup != null) {
            popup.show();
        }
    }

    function EndRequestHandler(sender, args) {
        //Hide the modal popup - the update progress
        var popup = $find('<%= modalPopup.ClientID %>');
        if (popup != null) {
            popup.hide();
        }
    }
    </script>
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
    <style>
.input-blue {
    width: 100%;
    border: 1px solid #3498db;
    margin: 8px 0px;
    /* padding: 10px 10px; */
    height: 30px;
}
.btns
{
    float: right;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-header">
        <h1>
            Online Payment
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>           
            <li class="active">Payment</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>         
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                    PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
        <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">                               
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            Fees Transaction
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                         <table width="100%">
                                            
                                            <tr>
                                        <div class="efficacious" id="Div1">
                                                                <table width="70%">
                                                                <tr>
                                                                   <td align="center"></td>
                                                                    <td align="left" valign="top"></td>
                                                                </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="Label1" runat="server" Text="Student Name"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                             <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" 
                                                                                Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="Label3" runat="server" Text="Total Fee"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtTotalFee" runat="server" CssClass="input-blue" 
                                                                                Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="Label11" runat="server" Text="Type"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlDurationType" runat="server" AutoPostBack="True" 
                                                                                OnSelectedIndexChanged="ddlDurationType_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="Label4" runat="server" Text="Fee Head"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 50%">
                                                                            <asp:GridView ID="gvHead" runat="server" AutoGenerateColumns="False" 
                                                                                CssClass="mGrid" DataKeyNames="intTutionId" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="intTutionId" HeaderText="Id" ReadOnly="True" />
                                                                                    <asp:TemplateField HeaderText="Particulars">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFee_Id") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                            <asp:DropDownList ID="ddlFeeHead" runat="server" AutoPostBack="True" 
                                                                                OnSelectedIndexChanged="ddlFeeHead_SelectedIndexChanged" Visible="False">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="lblMonths" runat="server" Text="Month" Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlMonths" runat="server" Visible="False" 
                                                                                onselectedindexchanged="ddlMonths_SelectedIndexChanged" 
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="Label8" runat="server" Text="Head Amt" Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtHeadAmt" runat="server" CssClass="input-blue" 
                                                                                Visible="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="Left">
                                                                            <asp:Label ID="Label5" runat="server" Text="Amount"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtEnterAmt" runat="server" CssClass="input-blue" 
                                                                                Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td  >
                                                                        </td>
                                                                        <td width="30%">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                                                OnClick="btnSubmit_Click" Text="Pay Online" />
                                                                       
                                                                        </td>
                                                                        <td width="30%">
                                                                            <asp:Button ID="btnReport" runat="server" CssClass="efficacious_send" 
                                                                                OnClick="btnReport_Click" Text="Receipt" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="3">
                                                                            <asp:GridView ID="grdTrans" runat="server" AutoGenerateColumns="False" 
                                                                                CssClass="table  tabular-table " DataKeyNames="intID" 
                                                                                EmptyDataText="No Data Found" OnRowDeleting="grdTrans_RowDeleting" Width="90%">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="feeFate" HeaderText="Date" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="intTutionID" HeaderText="Head" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="feeType" HeaderText="Pay Type" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="intMonth_ID" HeaderText="Month" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="intPaidAmt" HeaderText="Paid Amount" 
                                                                                        ReadOnly="True" />
                                                                                    <asp:BoundField DataField="intPayMode" HeaderText="Pay Mode" ReadOnly="True" />
                                                                                   
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Fee Received :
                                                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    </td>
                                                                        </tr>
                                                    </table>
                                                            </div>
                                        </table>
                                    </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


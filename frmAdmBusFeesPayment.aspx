<%@ Page Title="Bus Fees Payment" Language="C#" MasterPageFile="~/newMasterPage.master"
    AutoEventWireup="true" CodeFile="frmAdmBusFeesPayment.aspx.cs" Inherits="frmAdmBusFeesPayment"
    Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=Buspay.ClientID%>");
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
    <style>
    .efficacious input[type="image"]{     width: 48%;
    margin: 0 auto;}
    .efficacious input{ float:left;}
    .efficacious_send{ margin-right:10px !important;}
    </style>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="left" class="auto-style1">
                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="1015px"
                            CssClass="MyTabStyle">
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                <HeaderTemplate>
                                    Bus Fees Payment</HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious">
                                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                                <tr>
                                                    <td align="center">
                                                        <asp:GridView ID="Buspay" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CssClass="mGrid" Width="99%" Height="40px" OnRowEditing="Buspay_RowEditing" DataKeyNames="intService_id"
                                                            Font-Bold="False" OnSelectedIndexChanged="Buspay_SelectedIndexChanged" HorizontalAlign="Center">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="intService_id" runat="server" Text='  <%# Eval("intService_id")  %>'>

                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Select">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButton ID="Radi1" onclick="RadioCheck(this);" AutoPostBack="true" DataTextField="intService_id"
                                                                            DataValueField="intService_id" runat="server" /><asp:HiddenField ID="HiddenField1"
                                                                                runat="server" Value='<%# Eval("intService_id")  %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchdivisionname" HeaderText="Division" ReadOnly="True" />
                                                                <asp:BoundField DataField="introllno" HeaderText="Roll No" ReadOnly="True" />
                                                                <asp:BoundField DataField="StudentName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBus_Amount" HeaderText="Bus Amount" ReadOnly="True" />
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
                                                                    <asp:Button ID="paymentid" runat="server" Text="Payment" CssClass="efficacious_send"
                                                                        OnClick="paymentid_Click" Width="100%" />
                                                                    <asp:TextBox ID="txd1" runat="server" Visible="False"></asp:TextBox>
                                                                </td>
                                                    </td>
                                                </tr>
                                            </table>
                                            </tr> </table>
                                        </div>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel2" runat="server">
                                <HeaderTemplate>
                                    Payment Details</HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious">
                                            <table width="50%">
                                                <tr>
                                                    <td style="padding-top: 10px" align="left">
                                                        <asp:Label ID="Lab1" runat="server" Text="Student Name"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px">
                                                        <asp:Label ID="Lab2" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 10px" align="left">
                                                        <asp:Label ID="Lab3" runat="server" Text="Bus Services Area"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px">
                                                        <asp:Label ID="Lab4" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 10px" align="left">
                                                        <asp:Label ID="Lab5" runat="server" Text="Fees"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px">
                                                        <asp:Label ID="Lab6" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="eff1" runat="server">
                                                    <td style="padding-top: 10px" align="left" runat="server">
                                                        <asp:Label ID="Lab7" runat="server" Text="Effective From"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px" runat="server">
                                                        <asp:Label ID="Lab8" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="eff2" runat="server">
                                                    <td style="padding-top: 10px" align="left" runat="server">
                                                        <asp:Label ID="Lab9" runat="server" Text="Effective To"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px" runat="server">
                                                        <asp:Label ID="Lab10" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 10px" align="left">
                                                        <asp:Label ID="Lab11" runat="server" Text="Payment Mode"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px">
                                                        <asp:DropDownList ID="drop1" runat="server" Width="153px" AutoPostBack="True" OnSelectedIndexChanged="drop1_SelectedIndexChanged">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReirFiVa1" runat="server" ControlToValidate="drop1"
                                                            Display="None" ErrorMessage="Select Payment Mode" Font-Bold="False" InitialValue="Select"
                                                            ValidationGroup="pp"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                            TargetControlID="ReirFiVa1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr id="cheq1" runat="server" visible="False">
                                                    <td style="padding-top: 10px" runat="server" align="left">
                                                        <asp:Label ID="Lab12" runat="server" Text="Cheque No."></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px" runat="server">
                                                        <asp:TextBox ID="TEXT1" runat="server" Width="136px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFVd1" runat="server" ErrorMessage="Please Enter Cheque No"
                                                            ControlToValidate="TEXT1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="Reqder" runat="server" TargetControlID="ReqFVd1"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="ReExV12" runat="server" ControlToValidate="TEXT1"
                                                            ErrorMessage="Only 4 Digit's Numeric No's are allowed" ForeColor="Red" ValidationExpression="^[0-9]{4}$"
                                                            Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="ReExV12">
                                                            </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr id="cheq2" runat="server" visible="False">
                                                    <td style="padding-top: 10px" runat="server" align="left">
                                                        <asp:Label ID="Lab13" runat="server" Text="Cheque Date"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px" runat="server">
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="136px"></asp:TextBox><asp:CalendarExtender
                                                            ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="TextBox1" runat="server"
                                                            Enabled="True">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="Req1" runat="server" ErrorMessage="Please Enter Cheque Date"
                                                            ControlToValidate="TextBox1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="Req1"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr id="cheq3" runat="server" visible="False">
                                                    <td style="padding-top: 10px" align="left" runat="server" class="auto-style3">
                                                        <asp:Label ID="Lab15" runat="server" Text="Amount"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px" runat="server" class="auto-style3">
                                                        <asp:TextBox ID="TextBox2" runat="server" Width="136px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Req7" runat="server" ErrorMessage="Please Enter Amount"
                                                            ControlToValidate="TextBox2" Display="None" ValidationGroup="pp" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="Req7"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="Reg5" runat="server" ControlToValidate="TextBox2"
                                                            ErrorMessage="Only Number's are allowed" ForeColor="Red" ValidationExpression="\d+"
                                                            Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="Reg5">
                                                            </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr id="cheq4" runat="server" visible="False">
                                                    <td style="padding-top: 10px" runat="server" align="left">
                                                        <asp:Label ID="Lab17" runat="server" Text="Clearing Date"></asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px" runat="server">
                                                        <asp:TextBox ID="TextBox3" runat="server" Width="136px"></asp:TextBox><asp:CalendarExtender
                                                            ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="TextBox3" runat="server"
                                                            Enabled="True">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="Req2" runat="server" ErrorMessage="Please Enter Cheque Date"
                                                            ControlToValidate="TextBox3" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="Req2"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ControlToCompare="TextBox1" ControlToValidate="TextBox3" Display="None"
                                                            ErrorMessage="Clearing Date must be Greater then Cheque Date" ID="CompareValidator1"
                                                            Operator="GreaterThan" Type="Date" runat="server" Font-Bold="False" />
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="CompareValidator1"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding-top: 15px; position:relative; left:13px;">
                                                        <asp:Button ID="b1" runat="server" ValidationGroup="pp" CssClass="efficacious_send"
                                                            Text="Submit" OnClick="b1_Click" />
                                                        <asp:Button ID="Update1" runat="server" CssClass="efficacious_send" Text="Update"
                                                            ValidationGroup="pp" OnClick="Update1_Click" />
                                                        <asp:HiddenField ID="hid1" runat="server" />
                                                        <asp:HiddenField ID="hid2" runat="server" />
                                                        <asp:HiddenField ID="hid3" runat="server" />
                                                        <asp:HiddenField ID="hid4" runat="server" />
                                                        <asp:HiddenField ID="hid5" runat="server" />
                                                        <asp:HiddenField ID="hid6" runat="server" />
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel HeaderText="g" ID="TabPanel3" runat="server">
                                <HeaderTemplate>
                                    Bus Fees Payment Report</HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious" >
                                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                                <tr runat="server">
                                                    <td runat="server">
                                                        <div id="efficacious" class="efficacious" style="display:none;">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="Drop11" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Drop11_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text="Division"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="Drop12" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Drop12_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="textcss">
                                                        <asp:GridView ID="PayReport" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CssClass="mGrid" OnRowDataBound="PayReport_RowDataBound" OnRowEditing="PayReport_RowEditing"
                                                            DataKeyNames="intPayment_Id" OnRowDeleting="PayReport_RowDeleting" OnRowCommand="PayReport_RowCommand"
                                                            HorizontalAlign="Center" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="intPayment_Id" runat="server" Text='  <%# Eval("intPayment_Id")  %>'></asp:Label></ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                                            OnClientClick="return messageConfirm('Do you want to Delete this Record ?');"
                                                                            CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                                            CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchDivisionName" HeaderText="Division" ReadOnly="True" />
                                                                <asp:BoundField DataField="intRollNo" HeaderText="Roll No" ReadOnly="True" />
                                                                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchArea_Name" HeaderText="Area" ReadOnly="True" />
                                                                <asp:BoundField DataField="intamount" HeaderText="Amount" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchPayment_Mode" HeaderText="Payment Mode" ReadOnly="True" />
                                                                <asp:BoundField DataField="dtCheckDate" HeaderText="Cheque Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchCheck_No" HeaderText="Cheque No" ReadOnly="True" />
                                                                <asp:BoundField DataField="dtCheque_delivery" HeaderText="Cheque Delivery" ReadOnly="True" />
                                                            </Columns>
                                                        </asp:GridView>
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
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1
        {
            width: 377px;
        }
        .auto-style3
        {
            height: 31px;
        }
         .mGrid th {
         text-align: center !important;
            }
    </style>
</asp:Content>

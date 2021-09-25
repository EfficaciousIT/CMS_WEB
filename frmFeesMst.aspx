<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-GB" CodeFile="frmFeesMst.aspx.cs" Inherits="frmFeesMst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious textarea
        {
            width: 97% !important;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .efficacious input[type=checkbox] + label {
            display: block;
            /* width: auto !important; */
            /* height: auto !important; */
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            /* background: white !important; */
            vertical-align: middle;
            line-height: 1em;
            /* font-size: 14px; */
            /* color: #000; */
            padding: 1px 0px;
            text-align: center;
            width: 30px;
            /* height: 50px; */
            margin-top: 3px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function confirm() {
            if (Page_ClientValidate() == false) {
                return false;
            }
            else {

                var atLeast = 1;
                var count = 0;
                var chkLst = document.getElementById('<%=chkSTD.ClientID %>');
                var chk = chkLst.getElementsByTagName("input");
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked) {
                        count++;
                    }
                }
                if (atLeast > count) {
                    alert('Please Select Atleast One Standard');
                    return false;
                }
                //ConfMsg();

            }
        }

        function ConfMsg() {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {

                if (confirm('Do You Really Want To Save Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (confirm('Do You Really Want To Update Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Fee Assignment
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
            <li class="active">Fee Assignment</li>
        </ol>
    </div>
    <div style="padding: 10px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="50%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label6" runat="server" Text="Standard" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlSTD" runat="server"  OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table" Width="70%" OnRowDataBound="grvDetail_RowDataBound" AllowPaging="True"
                                                                DataKeyNames="intFeeDetId" OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="False"
                                                                                ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="FeeDetId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFeeDetId") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" ReadOnly="True" />
                                                                    <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                                                                    <asp:BoundField DataField="feetype" HeaderText="Type" ReadOnly="True" />
                                                                    <asp:BoundField DataField="FrmDt" HeaderText="Effective From Date" ReadOnly="True"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="ToDt" HeaderText="Effective To Date" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField DataField="vchFeeDesc" HeaderText="Description" ReadOnly="True" Visible="False" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div></center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <div class="efficacious">
                                                    <table width="50%">
                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label1" runat="server"  Text="Particulars "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlParticular" runat="server"  OnSelectedIndexChanged="ddlParticular_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="ddlParticular"
                                                                     Display="None" ErrorMessage="Please Select Valid Particular"
                                                                    InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="V2"
                                                                        runat="server" Enabled="True" TargetControlID="R1">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="style5" align="left">
                                                                <asp:Label ID="Label2" runat="server"  Text="Standard"></asp:Label>
                                                            </td>
                                                            <td class="auto-style6" align="left" valign="top">
                                                                <div id="divId" style="overflow: scroll; height: 190px;">
                                                                    <asp:CheckBoxList ID="chkSTD" runat="server" >
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label3" runat="server"  Text="Amount"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAmt" runat="server" Width="96%" CssClass="input-blue"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="R2" runat="server" ControlToValidate="txtAmt" Display="None" ErrorMessage="Please Enter Amount"
                                                                   ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="V3"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:FilteredTextBoxExtender ID="FT" runat="server" FilterType="Custom, Numbers"
                                                                    ValidChars="." TargetControlID="txtAmt" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr visible="False" runat="server">
                                                            <td class="style5" align="left" valign="top" runat="server">
                                                                <asp:Label ID="Label4" runat="server"  Text="Effective Date"></asp:Label>
                                                            </td>
                                                            <td width="100%" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top" width="50%">
                                                                            <asp:TextBox ID="txtFrmDt" runat="server" Style="width: 91%;" ></asp:TextBox><asp:CalendarExtender
                                                                                ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt" Format="dd/MM/yyyy"
                                                                                Enabled="True">
                                                                            </asp:CalendarExtender>
                                                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFrmDt"
                                                                                WatermarkText="From Date" Enabled="True">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                            <asp:RequiredFieldValidator ID="R4" runat="server" ControlToValidate="txtFrmDt" Display="None"
                                                                                ErrorMessage="Please Enter From Date" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="V4" TargetControlID="R4" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                        <td>
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td align="left" valign="top" width="70%">
                                                                            <asp:TextBox ID="txtToDt" runat="server" Width="94%" CssClass="input-blue"></asp:TextBox><asp:TextBoxWatermarkExtender
                                                                                ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtToDt" WatermarkText="To Date"
                                                                                Enabled="True">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDt"
                                                                                Format="dd/MM/yyyy" Enabled="True">
                                                                            </asp:CalendarExtender>
                                                                            <asp:CompareValidator ID="CV1" runat="server" Display="None" ControlToValidate="txtToDt"
                                                                                ControlToCompare="txtFrmDt" Type="Date" Operator="GreaterThanEqual" ErrorMessage="From Date Should Be Less Than Or Equal To ToDate"
                                                                                ></asp:CompareValidator><asp:ValidatorCalloutExtender ID="V1"
                                                                                    TargetControlID="CV1" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                            <asp:RequiredFieldValidator ID="R5" runat="server" ControlToValidate="txtToDt" Display="None"
                                                                                ErrorMessage="Please Enter To Date" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="V5" TargetControlID="R5" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr visible="False" runat="server">
                                                            <td class="style6" valign="top" align="left" runat="server">
                                                                <asp:Label ID="Label5" runat="server"  Text="Description"></asp:Label>
                                                            </td>
                                                            <td align="left" runat="server">
                                                                <asp:TextBox ID="txtDesc" runat="server" CssClass="input-blue" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                                                OnClientClick="return confirm();" Text="Submit" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
        </center>
    </div>
</asp:Content>

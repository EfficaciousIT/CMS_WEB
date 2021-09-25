<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmStudentLeaveMenu.aspx.cs" Inherits="frmStudentLeaveMenu" Title="Apply Leave"
    Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .efficacious input[type=radio] + label
        {
            background: #3498db !important;
        }
        .efficacious input[type=radio] + label
        {
            background: #3498db !important;
            color: #fff !important;
            font-weight: bold;
            width: 115px !important;
            height: 31px;
            text-align: center;
            border-radius: 5px !important;
            padding-top: 6px;
        }
        .input-blue {
            width: 25% !important;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 30px;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }
    </style>
    
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Leave
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Leave</a></li>
            <li class="active">Apply Leave</li>
        </ol>
    </div>
    <div>
        <asp:UpdatePanel ID="upda1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Application</HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table width="70%">
                                                    <tr>
                                                        <td colspan="3">
                                                            <div class="efficacious">
                                                                <table align="center" width="100%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:RadioButtonList ID="Radioleave" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                                                OnSelectedIndexChanged="Radioleave_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0" Text="Normal"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Emergency"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                            <asp:RequiredFieldValidator ID="ReqFiVd5" runat="server" ControlToValidate="Radioleave"
                                                                                Display="None" ErrorMessage="Choose Leave Type"></asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                                TargetControlID="ReqFiVd5">
                                                                            </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="radio1" runat="server" visible="False">
                                                        <td align="left" runat="server">
                                                            <asp:Label ID="Label6" runat="server">Leave Type</asp:Label>
                                                        </td>
                                                        <td align="left" runat="server">
                                                            <asp:DropDownList ID="droptype" runat="server" Style="width: 50%;" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td nowrap="nowrap" runat="server">
                                                            <asp:RequiredFieldValidator ID="RFVd3" InitialValue="0" runat="server" ErrorMessage="Select Leave Type"
                                                                Display="None" ControlToValidate="droptype"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="VCE1" runat="server" Enabled="True" TargetControlID="RFVd3">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblvchmake" runat="server">From</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtfromdate" CssClass="input-blue" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                AutoPostBack="True" OnTextChanged="cleartodata"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtfromdate"
                                                                runat="server" Enabled="True">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td nowrap="nowrap">
                                                            <asp:RequiredFieldValidator ID="RequFivd1" runat="server" ErrorMessage="From Date cannot be null "
                                                                Display="None" ControlToValidate="txtfromdate"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="VCE2" runat="server" Enabled="True" TargetControlID="RequFivd1">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:CompareValidator ID="Comp1" runat="server" ControlToValidate="txtfromdate" ErrorMessage="From Date Must Be Greater Than or Equal to Today"
                                                                SetFocusOnError="True" Operator="GreaterThanEqual" Display="None" Height="168px"></asp:CompareValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="Comp1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblvchdrivername" runat="server" Text="To"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txttodate" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                AutoPostBack="True"  CssClass="input-blue" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txttodate"
                                                                runat="server" Enabled="True">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td nowrap="nowrap">
                                                            <asp:RequiredFieldValidator ID="RFV22" runat="server" ErrorMessage="To Date cannot be null"
                                                                Display="None" ControlToValidate="txttodate"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="VCE22" runat="server" Enabled="True" TargetControlID="RFV22">
                                                            </asp:ValidatorCalloutExtender>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="lbldrivermobno" runat="server" Text="Total Leave Days"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNoofDays"  CssClass="input-blue" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                AutoPostBack="True" OnTextChanged="check_val" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td align="center" nowrap="nowrap">
                                                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="Label1" runat="server" Text="Reason"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <%--<textarea id="content" style="width: 101.6%;" rows="3" runat="server" class="input-blue" maxlength="250"></textarea>--%>
                                                            <asp:TextBox ID="content" TextMode="MultiLine" style="height:70px;width:335px !important;"  runat="server" ForeColor="Black" ValidationGroup="b"
                                                                AutoPostBack="True" CssClass="input-blue"  ReadOnly="false"  maxlength="250"></asp:TextBox>
                                                        </td>
                                                        <td nowrap="nowrap">
                                                            <asp:RequiredFieldValidator ID="ReFV4" runat="server" ErrorMessage="Leave Reason cannot be null "
                                                                Display="None" ControlToValidate="content"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="VaCaEx2" runat="server" Enabled="True" TargetControlID="ReFV4">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <table width="42%">
                                                                <tr>
                                                                    <td align="ceneter" nowrap="true">
                                                                        <asp:Button CssClass="efficacious_send" ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button CssClass="efficacious_send" ID="Button2" runat="server" Text="Clear"
                                                                            CausesValidation="False" OnClick="Button2_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </center>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                    <HeaderTemplate>
                                        Status
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                                <tr>
                                                    <td style="padding: 10px 0 20px 0;" align="center">
                                                        <asp:GridView ID="GridView5" runat="server" __designer:wfdid="w36" HorizontalAlign="Center"
                                                            AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                            DataKeyNames="ApplicationDate" EmptyDataText="Record not Found." Width="100%"
                                                            Font-Bold="False">
                                                            <Columns>
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="ParentsApproval" HeaderText="Parents Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="TeacherApproval" HeaderText="Teacher Approval" ReadOnly="True" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                                    <HeaderTemplate>
                                        Reports</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                                <tr>
                                                    <td align="center">
                                                        <div class="efficacious" id="efficacious">
                                                            <table>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Label ID="Label4" Style="padding-right: 10px;" runat="server" Font-Bold="False">Select Month</asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList5" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                                                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="01">Jan</asp:ListItem>
                                                                            <asp:ListItem Value="02">Feb</asp:ListItem>
                                                                            <asp:ListItem Value="03">Mar</asp:ListItem>
                                                                            <asp:ListItem Value="04">Apr</asp:ListItem>
                                                                            <asp:ListItem Value="05">May</asp:ListItem>
                                                                            <asp:ListItem Value="06">June</asp:ListItem>
                                                                            <asp:ListItem Value="07">July</asp:ListItem>
                                                                            <asp:ListItem Value="08">Aug</asp:ListItem>
                                                                            <asp:ListItem Value="09">Sep</asp:ListItem>
                                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:GridView ID="GridViewRepo" HorizontalAlign="Center" runat="server" __designer:wfdid="w36"
                                                            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                            DataKeyNames="ApplicationDate" EmptyDataText="Record not Found." Width="100%"
                                                            Font-Bold="False" EnableModelValidation="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="ParentsApproval" HeaderText="Parents Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="ParentsApprovaldate" HeaderText="Approval Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ParentsRemark" HeaderText="Parents Remark" ReadOnly="True" />
                                                                <asp:BoundField DataField="TeacherApproval" HeaderText="Teacher Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="TeacherApprovaldate" HeaderText="Approval Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="TeacherRemark" HeaderText="Teacher Remark" ReadOnly="True" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .mGrid .pgr td{ line-height:0px !important;}
        .mGrid .pgr table{ margin:0px !important;}
        .mGrid .pgr{ display:none;}
        .style10
        {
            width: 100%;
        }
        #TextArea1
        {
            width: 125px;
            margin-left: 10px;
        }

        #content
        {
            height: 36px;
            width: 108px;
        }

        .textsize
        {
            margin-left: 19px;
        }
        .style13
        {
            width: 151px;
        }

        .auto-style1 {
            width: 144px;
        }
        .mGrid th{ text-align:center !important}
        .efficacious input[type=radio] + label {
  display: block;
  padding: 11px 0px;
  border: 0.0625em solid rgb(192,192,192);
  border-radius: 5px !important;
  background: #3498db  !important;
  vertical-align: middle;
  line-height: 1em;
  font-size: 13px;
  outline: 0; 
}
.efficacious input[type=radio] {
  width: 18px !important;
  height: 18px !important;
  background: #3498db !important; margin-top: 10px !important; float: left; margin-right:10px; margin-left:5px;
}
.efficacious input.efficacious_send {
 
  background: #3498db !important;
  border:none !important;
  font-size: 16px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
  color: #fff;
  margin: 7px auto !important;
  padding: 3px;
  cursor: pointer;
  height: 28px !important;
  float: left;
  text-align: center;
}
  .mGrid td { padding:6px 11px !important;   color: #242424 !important;
  FONT-SIZE: 12px !important;}
  .mGrid th { padding:4px 10px !important;}
  .efficacious span { margin:0 0 10px 0 !important; }
  .efficacious label {
  display: inline;
  float: left;
  color: #000;
  cursor: pointer;
  text-indent: 0px !important; text-align:center;
  white-space: nowrap;
}
<!--[if IE 11]>
.efficacious input[type=checkbox], input[type=radio]{ background:#f5f5f5 !important; border:0 !important;}
.efficacious input[type=radio]{ width:18px !important; height:18px !important; background:#f5f5f5 !important;}
<![endif]-->

.efficacious input[type=radio] + label { background: #3498db; color:#fff !important; font-weight:bold; width:115px !important; height:auto; border-radius:5px !important; }
    
    </style>
    <script type="text/javascript">
        function CheckDate(ctrl) {
            var dt = new Date();
            var cdt = Date.parse(ctrl.value);
            if (cdt > dt) {
                alert('Date greater than Today');
            }
        }
    </script>
</asp:Content>

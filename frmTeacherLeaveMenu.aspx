<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmTeacherLeaveMenu.aspx.cs" Inherits="frmTeacherLeaveMenu" Title="Apply Leave"
    Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="clearfix">
    </div>

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
    </style>
    <div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Leave <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li class="active1"> <a href="frmTeacherLeaveMenu.aspx"> Apply Leave </a></li>
                  <li><a href="frmTeachLeavAppro.aspx"> Leave Approval</a></li>                 
        </ul>
    </div>
<section class="content">
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="updat1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Leave Application
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table width="60%">
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <br />
                                                            <table style="width: 311px">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList ID="Radioleave" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="0">Normal</asp:ListItem>
                                                                            <asp:ListItem Value="1">Emergency</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None"
                                                                            ControlToValidate="Radioleave" ErrorMessage="Choose Leave Type"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                            TargetControlID="RequiredFieldValidator5">
                                                                        </asp:ValidatorCalloutExtender>
                                                                        <br />
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" nowrap="nowrap" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="Lal2" runat="server" Style="width: 100% !important; color: #000 !important;">Leave Type</asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:DropDownList ID="drop1" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drop1"
                                                                Display="None" ErrorMessage="Select Leave Type" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator3">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lblvchmake" runat="server" Style="width: 100% !important; color: #000 !important;">From Date</asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txtfromdate" runat="server" ForeColor="Black" MaxLength="20" Style="width: 96%;"
                                                                ValidationGroup="b" AutoPostBack="True" OnTextChanged="cleartodata"></asp:TextBox><asp:CalendarExtender
                                                                    ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtfromdate" runat="server"
                                                                    Enabled="True">
                                                                </asp:CalendarExtender>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date cannot be null "
                                                                ControlToValidate="txtfromdate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lblvchdrivername" runat="server" Text="To Date" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txttodate" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                Style="width: 96%;" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txttodate"
                                                                runat="server" Enabled="True">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="To Date cannot be null "
                                                                ControlToValidate="txttodate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lbldrivermobno" runat="server" Text="Total Leave Days" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txtNoofDays" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                AutoPostBack="True" OnTextChanged="check_val" Style="width: 96%;" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="Label1" runat="server" Text="Reason" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 15px">
                                                            <textarea id="content" runat="server" style="width: 97%;" class="textcss"></textarea>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Leave Reason cannot be null "
                                                                ControlToValidate="content" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator4">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td align="left" style="padding-top: 15px">
                                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="efficacious_send"
                                                                Text="Save" OnClick="Button1_Click" />
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
                                        Application Status
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table>
                                                <tr>
                                                    <td style="padding: 10px 0 20px 0;" align="center">
                                                        <asp:GridView ID="GridView5" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                            DataKeyNames="intLeaveApplocation_id,ApplicationDate" EmptyDataText="Record not Found." 
                                                            Width="100%" onrowediting="GridView5_RowEditing">
                                                            <Columns>
                                                              <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApprovaldate" HeaderText="Approval Date" 
                                                                    ReadOnly="True" Visible="False"/>
                                                                <asp:BoundField DataField="AdminRemark" HeaderText="Admin Remark" 
                                                                    ReadOnly="True" Visible="False"/>
                                                                     <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>  
                                                                                <asp:RadioButtonList ID="rdbAction" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="Reject"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Submit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
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
                                        Reports
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table>
                                                <tr>
                                                    <td style="padding: 10px 0 20px 0;" align="center">
                                                        <asp:GridView ID="GridViewRepo" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                            DataKeyNames="ApplicationDate" EmptyDataText="Record not Found." Width="100%">
                                                            <Columns>
                                                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApprovaldate" HeaderText="Approval Date" ReadOnly="True" Visible="false"/>
                                                                <asp:BoundField DataField="AdminRemark" HeaderText="Admin Remark" ReadOnly="True" Visible="false"/>
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
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Pending Leave
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table>
                                                <tr>
                                                    <td style="padding: 10px 0 20px 0;" align="center">
                                                        <asp:GridView ID="GridView1" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_OnPageIndexChanging"
                                                            CssClass="table  tabular-table" DataKeyNames="vchLeaveType_name" EmptyDataText="Record not Found."
                                                            Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <Columns>
                                                                <asp:BoundField DataField="vchLeaveType_name" HeaderText="Leave Type" ReadOnly="True" />
                                                                <asp:BoundField DataField="inttotal" HeaderText="Total Leave" ReadOnly="True" />
                                                                <asp:BoundField DataField="pending" HeaderText="Pending Leave" ReadOnly="True" />
                                                                <asp:BoundField DataField="taken" HeaderText="Leave Taken " ReadOnly="True" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
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
</section>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style10
        {
            width: 100%;
        }
        #TextArea1
        {
            width: 125px;
            margin-left: 10px;
        }
        
        .style11
        {
            height: 16px;
        }
        #content
        {
            height: 40px;
            width: 125px;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious span
        {
            width: 15px !important;
            color: #fff !important;
            margin-bottom: 0px !important;
        }
        .efficacious input.efficacious_send
        {
            border: none;
        }
        .efficacious input[type="radio"]
        {
            width: 24px;
            float: left;
            margin: 0 auto;
            margin-right: 10px;
            margin-top: 10px;
        }
        .efficacious label
        {
            border: none !important;
        }
        .efficacious input[type=radio] + label
        {
            background: rgb(248, 158, 54) !important;
            color: #fff !important;
            font-weight: bold;
            width: 115px !important;
            height: auto;
            border-radius: 5px !important;
        }
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

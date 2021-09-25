<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master"
    AutoEventWireup="true" CodeFile="FrmPareLeavAppro.aspx.cs" Inherits="FrmPareLeavAppro"
    Culture="es-MX" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .efficacious label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 0px !important;
            white-space: nowrap;
            text-align: center;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }
        .efficacious input[type=radio] + label
        {
            display: block;
            width: 110px !important;
            height: 2em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 1em;
            background: #3498db !important;
            background-image: none !important;
            vertical-align: middle;
            line-height: 26px;
            font-size: 14px;
            float: left;
            margin-right: 40px;
            color: #FFF;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 1px !important;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            float: left;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            text-align: center !important;
            background: rgb(3, 116, 3);
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .efficacious input[type=radio]
        {
            margin-top: 8px;
            margin-right: 13px;
        }
        .efficacious_send
        {
            width: 25% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .style2
        {
            height: 101%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Leave Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Leave</a></li>
            <li class="active">Apply Leave</li>
        </ol>
    </div>
    <div style="padding: 05px 0 0 0">
        <table>
            <tr>
                <td align="left">
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                        Style="margin-bottom: 0px" CssClass="MyTabStyle">
                        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                            <HeaderTemplate>
                                Approval Request</HeaderTemplate>
                            <ContentTemplate>
                                <div class="efficacious">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                    CssClass="table  tabular-table " Width="100%" DataKeyNames="lblid" OnRowEditing="GridView1_RowEditing"
                                                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server"></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approval">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                                                    <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" />
                                                                </asp:LinkButton></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TypeOfLeave" HeaderText="Type Of Leave" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotalLeaveDays" HeaderText="Total Leave Days" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Reson" HeaderText="Reason" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" ForeColor="DarkBlue" Font-Bold="True" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Visible="false">
                            <HeaderTemplate>
                                Approval Assignment</HeaderTemplate>
                            <ContentTemplate>
                                <div class="efficacious" style="display: none;">
                                    <table style="width: 70%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID='headtext' runat="server" Style="width: auto !important;" Text="Leave Approval"
                                                    CssClass="textheadcss" Font-Bold="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="efficacious">
                                    <table style="width: 50%; margin: 0 Auto; border: 0px solid #242424;">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="LblApplication" runat="server" Text="Application Id" Font-Bold="False"
                                                    Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label1" runat="server" Text="Type Of Leave" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="leaveType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label3" runat="server" Text="From Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="FromLbl" runat="server" Text="From Date"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label5" runat="server" Text="To Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="ToLbl" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label7" runat="server" Text="Total No Of Days"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TotalLbl" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:RadioButtonList ID="RadioApproved" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Approved</asp:ListItem>
                                                        <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioApproved"
                                                        Style="padding: 0px; margin: 0px;" ErrorMessage="Choose Approval Status"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="Label2" runat="server" Text="Remark"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Resontxt" runat="server" AutoPostBack="True" ForeColor="Black" Height="68px"
                                                        MaxLength="250" TextMode="MultiLine" Width="335px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Resontxt"
                                                        ErrorMessage="Please Enter Reson" Style="padding: 0px; margin: 0px;"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <asp:Button ID="btnClear" Visible="false" runat="server" CssClass="efficacious_send" OnClick="btnClear_Click"
                                                        Text="Clear" />
                                                </td>
                                                <td align="left" valign="middle">
                                                    <asp:Button ID="btnSubmin" runat="server" CssClass="efficacious_send" OnClick="Submitval"
                                                        Text="Submit" />
                                                </td>
                                            </tr>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3">
                            <HeaderTemplate>
                                Leave Application</HeaderTemplate>
                            <ContentTemplate>
                                <center>
                                    <div class="efficacious">
                                        <table width="70%" style="position: relative;">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <table width="100%" style="position: relative; left: 54px;">
                                                        <tr>
                                                            <td align="center" nowrap="nowrap">
                                                                <asp:RadioButtonList ID="Radioleave" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0" Text="Normal"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Emergency"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="Radioleave"
                                                        ErrorMessage="Choose Leave Type" ValidationGroup="grp1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblvchmake" runat="server">From Date</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtfromdate1" runat="server" Style="width: 39%;" ForeColor="Black"
                                                        MaxLength="20" ValidationGroup="b" CssClass="input-blue" AutoPostBack="True"
                                                        OnTextChanged="cleartodata"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1"
                                                            Format="dd/MM/yyyy" TargetControlID="txtfromdate1" runat="server" Enabled="True">
                                                        </asp:CalendarExtender>
                                                </td>
                                                <td nowrap="nowrap">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="From Date cannot be null "
                                                        ControlToValidate="txtfromdate1" ValidationGroup="grp1"></asp:RequiredFieldValidator>
                                                </td>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtfromdate1"
                                                    ErrorMessage="From Date Must Be Greater Then or Equal to Today" SetFocusOnError="True"
                                                    Operator="GreaterThanEqual"></asp:CompareValidator></tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblvchdrivername" runat="server" Text="To Date"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txttodate" Style="width: 39%;" runat="server" ForeColor="Black"
                                                        MaxLength="20" ValidationGroup="b" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"
                                                        CssClass="input-blue"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2"
                                                            Format="dd/MM/yyyy" TargetControlID="txttodate" runat="server" Enabled="True">
                                                        </asp:CalendarExtender>
                                                </td>
                                                <td nowrap="nowrap">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="To Date cannot be null "
                                                        ControlToValidate="txttodate" ValidationGroup="grp1"></asp:RequiredFieldValidator><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" nowrap="nowrap">
                                                    <asp:Label ID="lbldrivermobno" runat="server" Text="Total Leave"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtNoofDays" Style="width: 39%;" runat="server" ForeColor="Black"
                                                        MaxLength="20" ValidationGroup="b" AutoPostBack="True" OnTextChanged="check_val"
                                                        CssClass="input-blue" ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td nowrap="nowrap">
                                                    <asp:Label ID="Label4" runat="server" ForeColor="Red" ValidationGroup="grp1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="Label6" runat="server" Text="Reason"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="content" TextMode="MultiLine" Height="68px" Width="250px" runat="server"
                                                        ForeColor="Black" AutoPostBack="True" MaxLength="250"></asp:TextBox>
                                                </td>
                                                <td nowrap="nowrap">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Leave Reason cannot be null "
                                                        ControlToValidate="content" ValidationGroup="grp1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td align="center">
                                                    <br />
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Save" CssClass="efficacious_send"
                                                        ValidationGroup="grp1" OnClick="Button1_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </center>
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
                                                <asp:GridView ID="GridViewRepo" HorizontalAlign="Center" runat="server" __designer:wfdid="w36"
                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " DataKeyNames="ApplicationDate"
                                                    EmptyDataText="Record not Found." Width="100%" Font-Bold="False">
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
                                                        <asp:BoundField DataField="TeacherApprovaldate" HeaderText="Approval date" ReadOnly="True" />
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
    </div>
</asp:Content>

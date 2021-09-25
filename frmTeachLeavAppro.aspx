<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master"
    Culture="en-Gb" AutoEventWireup="true" CodeFile="frmTeachLeavAppro.aspx.cs" Inherits="frmTeachLeavAppro"
    Title="E-Smarts - Student attendance management system, Fees management, School bus tracking, Exam schedule, time table management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious span
        {
            margin-bottom: 0 !important;
            width: 13px !important;
        }
        .textcss
        {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Leave <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li> <a href="frmTeacherLeaveMenu.aspx"> Apply Leave </a></li>
           <li class="active1"><a href="frmTeachLeavAppro.aspx"> Leave Approval</a></li>                 
        </ul>
    </div>
<section class="content">
    <center>
        <table>
            <tr>
                <td align="left">
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                        Style="margin-bottom: 0px" CssClass="MyTabStyle">
                        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                            <HeaderTemplate>
                                Approval Request
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="efficacious">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                    DataKeyNames="lblid" OnPageIndexChanging="GridView1_OnPageIndexChanging" EmptyDataText="No Records Found"
                                                    OnRowEditing="GridView1_RowEditing" Width="100%" AllowPaging="True">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approval">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtn" runat="server" CommandName="Edit">
                                                                    <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="studrollno" HeaderText="Roll No" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
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
                                                        <asp:BoundField DataField="parentsapproval" HeaderText="Parents Approval" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="pareapprdate" HeaderText="Approval Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" Font-Bold="True" ForeColor="DarkBlue" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Visible="False">
                            <HeaderTemplate>
                                Approval
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="efficacious">
                                    <center>
                                        <br />
                                        <table style="width: 50%">
                                            <tr>
                                                <td colspan='2'>
                                                    <asp:Label ID="LblApplication" runat="server" Text="Application Id" Font-Bold="False"
                                                        Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Name" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Type Of Leave" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="leaveType" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="From Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="FromLbl" runat="server"></asp:Label>
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
                                                    <td align="center" colspan='2'>
                                                        <asp:RadioButtonList ID="RadioApproved" runat="server" RepeatDirection="Horizontal"
                                                            Height="16px" Width="288px">
                                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                                            <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="a1"
                                                            ControlToValidate="RadioApproved" ErrorMessage="Choose Approval Status"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label2" runat="server" Text="Remark"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="Resontxt" runat="server" Height="47px" Font-Size="X-Small" Width="152px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="a1" runat="server"
                                                            ControlToValidate="Resontxt" ErrorMessage="Please Enter Reson"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" class="style2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button CssClass="efficacious_send" ID="btnSubmin" runat="server" ValidationGroup="a1"
                                                            OnClick="Submitval" Text="Submit" Width="60%" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="efficacious_send" ID="btnClear" runat="server" OnClientClick="if (!validatePage()) {return true;}"
                                                            OnClick="btnClear_Click" Text="Clear" Width="60%" />
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                            <HeaderTemplate>
                                Report
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="efficacious">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridViewRepo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CssClass="table  tabular-table" DataKeyNames="lblid" OnPageIndexChanging="GridViewRepo_OnPageIndexChanging"
                                                    EmptyDataText="No Records Found" Width="100%" EnableModelValidation="True">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:BoundField DataField="studrollno" HeaderText="Roll No" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
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
                                                        <asp:BoundField DataField="parentsapproval" HeaderText="Parents Approval" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="pareapprdate" HeaderText="Approval Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Teacherapproval" HeaderText="Teacher Approval" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Teacherappdate" HeaderText="Approval Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TeacherRemark" HeaderText="Remark" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" Font-Bold="True" ForeColor="DarkBlue" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <input type="button" class="efficacious_send" onclick=" window.print()" value="Print" style="display:none" />
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
    </center>
</asp:Content>

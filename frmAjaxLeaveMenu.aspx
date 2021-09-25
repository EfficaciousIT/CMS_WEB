<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAjaxLeaveMenu.aspx.cs" Inherits="frmAjaxLeaveMenu" Title="Apply Leave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="368px"
        Width="868px">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Leave Applicaation
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <table>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label7" runat="server" Text="New Application"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                                <table class="style10">
                                    <tr>
                                        <td align="left">
                                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Leave" GroupName="grp" />
                                        </td>
                                        <td align="left">
                                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Emergency" GroupName="grp" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="trLeaveType" runat="server" visible="False">
                            <td id="Td3" align="right" runat="server">
                                <asp:Label ID="lblvchno" runat="server">Select Leave Type:</asp:Label>
                            </td>
                            <td id="Td4" runat="server">
                                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" MaxLength="50" ValidationGroup="b"
                                    Width="200px">
                                </asp:DropDownList>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblvchmake" runat="server">From Date</asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txtfromdate" runat="server" Width="200px" ForeColor="Black" MaxLength="20"
                                    ValidationGroup="b"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy" TargetControlID="txtfromdate"
                                    runat="server" Enabled="True">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblvchdrivername" runat="server" Text="To Date"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txttodate" runat="server" Width="200px" ForeColor="Black" MaxLength="20"
                                    ValidationGroup="b" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" Format="MM/dd/yyyy" TargetControlID="txttodate"
                                    runat="server" Enabled="True">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbldrivermobno" runat="server" Text="Total Leave Days"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNoofDays" runat="server" Width="73px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Reason"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" Height="60px" MaxLength="20"
                                    ValidationGroup="b" Width="220px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Save" />
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <%--<asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Emergency Leave</HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="New Application"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr1" runat="server" visible="False">
                        <td id="Td1" align="right" runat="server">
                            <asp:Label ID="Label3" runat="server">Select Leave Type:</asp:Label>
                        </td>
                        <td id="Td2" runat="server">
                            <asp:DropDownList ID="DropDownList2" runat="server" MaxLength="50" ValidationGroup="b"
                                Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server">From Date</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="To Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" MaxLength="20" ValidationGroup="b" Width="200px"
                                ForeColor="Black"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Total Leave Days"></asp:Label>
                        </td>
                        <td align="left" style="padding: 0 0 0 20px">
                            <asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                Width="82px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" Text="Reason"></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox6" runat="server" Height="60px" MaxLength="20" ValidationGroup="b"
                                Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                ID="Button2" runat="server" Text="Save" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>--%>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Application Status</HeaderTemplate>
            <ContentTemplate>
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td align="center">
                            Application Status
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="GridView5" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Application Date"
                                EmptyDataText="Record not Found." Width="850px">
                                <Columns>
                                    <asp:BoundField DataField="Application Date" HeaderText="Application Date" ReadOnly="True" />
                                    <asp:BoundField DataField="From Date" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="To Date" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                    <asp:BoundField DataField="Total no of Days" HeaderText="Total no of Days" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval date" HeaderText="Parent Approval date"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="Teachers Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Teachers Approval date" HeaderText="Teachers Approval date"
                                        ReadOnly="True" />
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>
                Pending Leave Approval&#39;s</HeaderTemplate>
            <ContentTemplate>
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="ApplicationDate" EmptyDataText="Record not Found."
                                Width="833px" OnRowEditing="GridView4_RowEditing" OnDataBound="GridView4_DataBound"
                                OnRowDataBound="GridView4_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                ImageUrl="images/icon_edit.png" Text="Delete" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                    <asp:BoundField DataField="TotalnofDays" HeaderText="Total no of Days" ReadOnly="True" />
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Application Date"
                                EmptyDataText="Record not Found." Width="856px">
                                <Columns>
                                    <asp:BoundField DataField="Application Date" HeaderText="Application Date" ReadOnly="True" />
                                    <asp:BoundField DataField="From Date" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="To Date" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                    <asp:BoundField DataField="Total no of Days" HeaderText="Total no of Days" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval date" HeaderText="Parent Approval date"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Teachers Approval date" HeaderText="Teachers Approval date"
                                        ReadOnly="True" />
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>
                Reports</HeaderTemplate>
            <ContentTemplate>
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td>
                            Reports
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="GridView1" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Application Date"
                                EmptyDataText="Record not Found." Width="843px">
                                <Columns>
                                    <asp:BoundField DataField="Application Date" HeaderText="Application Date" ReadOnly="True" />
                                    <asp:BoundField DataField="From Date" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="To Date" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                    <asp:BoundField DataField="Total no of Days" HeaderText="Total no of Days" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval date" HeaderText="Parent Approval date"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Teachers Approval date" HeaderText="Teachers Approval date"
                                        ReadOnly="True" />
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>
                Admin panel</HeaderTemplate>
            <ContentTemplate>
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td>
                            Reports
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="right">
                        <td>
                            <table class="style1">
                                <tr>
                                    <td class="style3">
                                        From date
                                    </td>
                                    <td align="left" class="style8">
                                        <asp:TextBox ID="TextBox7" runat="server" Height="18px" Width="82px"></asp:TextBox>
                                    </td>
                                    <td class="style4">
                                        To date
                                    </td>
                                    <td align="left" class="style7">
                                        <asp:TextBox ID="TextBox8" runat="server" Height="16px" Width="91px"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style6">
                                        &nbsp;<span class="style9"> Month</span>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Verdana" Font-Size="8pt">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>Jan</asp:ListItem>
                                            <asp:ListItem>Feb</asp:ListItem>
                                            <asp:ListItem>Mar</asp:ListItem>
                                            <asp:ListItem>Apr</asp:ListItem>
                                            <asp:ListItem>May</asp:ListItem>
                                            <asp:ListItem>June</asp:ListItem>
                                            <asp:ListItem>July</asp:ListItem>
                                            <asp:ListItem>Aug</asp:ListItem>
                                            <asp:ListItem>Sep</asp:ListItem>
                                            <asp:ListItem>Oct</asp:ListItem>
                                            <asp:ListItem>Nov</asp:ListItem>
                                            <asp:ListItem>Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="GridView2" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Application Date"
                                EmptyDataText="Record not Found." Width="849px">
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:BoundField DataField="Application Date" HeaderText="Application Date" ReadOnly="True" />
                                    <asp:BoundField DataField="From Date" HeaderText="From Date" ReadOnly="True" />
                                    <asp:BoundField DataField="To Date" HeaderText="To Date" ReadOnly="True" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                    <asp:BoundField DataField="Total no of Days" HeaderText="Total no of Days" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval date" HeaderText="Parent Approval date"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="Parent Approval" HeaderText="Parent Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Teachers Approval date" HeaderText="Teachers Approval date"
                                        ReadOnly="True" />
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style10
        {
            width: 100%;
        }
    </style>
</asp:Content>

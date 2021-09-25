<%@ Page Title="Admin Leave Approval" Language="C#" MasterPageFile="~/newMasterPage.master"
    AutoEventWireup="true" CodeFile="FrmAdminLeavAppro.aspx.cs" Inherits="FrmAdminLeavAppro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            height: 52px;
        }
         .mGrid th { text-align:center !important;}
         .efficacious span{ width:80px !important; margin:0 !important; padding:0 10px 0 10px !important; position:relative; top:-5px;} 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 05px 0 0 0">
        <asp:UpdatePanel ID="upda1" runat="server">
            <ContentTemplate>
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
                                                    <td align="center">
                                                        <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                            CssClass="mGrid" Width="100%" OnRowEditing="GridView1_RowEditing" 
                                                            DataKeyNames="lblid">
                                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approval">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                                                            <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True">
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
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True">
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
                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2" Visible="false">
                                    <HeaderTemplate>
                                        Approval Assignment
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table style="width: 50%" align="center">
                                                    <tr>
                                                        <td colspan='2' align="center">
                                                            <asp:Label ID="LblApplication" runat="server" Text="Application Id" Font-Bold="False"
                                                                Visible="False"></asp:Label>
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
                                                            <asp:Label ID="FromLbl" runat="server" Text="From Date"></asp:Label>
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
                                                        <td colspan="2" >
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                ControlToValidate="RadioApproved" ErrorMessage="Choose Approval Status" 
                                                                ValidationGroup="h1"></asp:RequiredFieldValidator>
                                                            <br />
                                                        </td>
                                                        <tr>
                                                            <td align="center" colspan='2'>
                                                                <asp:RadioButtonList ID="RadioApproved" runat="server" RepeatDirection="Horizontal"
                                                                    Height="16px" Width="288px">
                                                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="Label2" runat="server" Text="Remark"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="Resontxt" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Resontxt"
                                                                    ValidationGroup="h1" ErrorMessage="Please Enter Reson"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <table width="50%">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:Button ID="btnSubmin" runat="server" ValidationGroup="h1" CssClass="efficacious_send"
                                                                                OnClick="Submitval" Text="Submit" />
                                                                        </td>
                                                                        <td valign="top">
                                                                            <asp:Button ID="btnClear" runat="server" CssClass="efficacious_send" OnClientClick="if (!validatePage()) {return true;}"
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </tr>
                                                </table>
                                            </div>
                                        </center>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                                    <HeaderTemplate>
                                        Reports
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="SelecName" runat="server" Text="Select Name" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DropName" AutoPostBack="True" runat="server" Font-Names="Verdana"
                                                            Font-Size="13px" style="width:220px;" OnSelectedIndexChanged="DropName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" width="50">
                                                        <asp:Label ID="month1" runat="server" Text="Select Month" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="droMonth" AutoPostBack="True" runat="server" Font-Names="Verdana"
                                                            Font-Size="13px" style="width:220px;" OnSelectedIndexChanged="droMonth_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Text="--All--" Value="All"></asp:ListItem>
                                                            <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                            <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                                            <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                            <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                            <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                            <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                                            <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                            <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 10px 0 20px 0;" align="center" colspan="4">
                                                        <asp:GridView ID="GridViewRepo" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="ApplicationDate"
                                                            EmptyDataText="Record not Found." Width="100%" EnableModelValidation="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="TeachName" HeaderText="Teacher Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApprovaldate" HeaderText="Approval Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminRemark" HeaderText="Admin Remark" ReadOnly="True" />
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

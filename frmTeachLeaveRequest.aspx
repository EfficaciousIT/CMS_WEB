<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmTeachLeaveRequest.aspx.cs" Inherits="frmTeachLeaveRequest" Title="Apply Leave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2"
        Width="940px" CssClass="MyTabStyle">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Leave Applicaation</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <table>
                        <tr>
                            <td align="center" colspan="2" >
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label7" runat="server" Text="New Application" CssClass="textheadcss"
                                    Font-Bold="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;&nbsp;<table >
                                    <tr>
                                        <td align="left">
                                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Leave" GroupName="grp"   />
                                        </td>
                                        <td align="left">
                                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Emergency" GroupName="grp"
                                                  />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr id="trLeaveType" runat="server" visible="False">
                            <td id="Td3" align="right" runat="server">
                                <asp:Label ID="lblvchno" runat="server"  >Select Leave Type</asp:Label>
                            </td>
                            <td id="Td4" runat="server">
                                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" MaxLength="50" ValidationGroup="b"
                                    CssClass="dropdowncs" 
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblvchmake" runat="server"  >From Date</asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txtfromdate" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                    CssClass="textsize"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy"
                                        TargetControlID="txtfromdate" runat="server" Enabled="True">
                                    </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblvchdrivername" runat="server" Text="To Date"  ></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txttodate" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                    AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" 
                                    CssClass="textsize"></asp:TextBox><asp:CalendarExtender
                                        ID="CalendarExtender2" Format="MM/dd/yyyy" TargetControlID="txttodate" runat="server"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbldrivermobno" runat="server" Text="Total Leave Days"  ></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txtNoofDays" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                    AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" 
                                    CssClass="textsize"></asp:TextBox><asp:CalendarExtender
                                        ID="CalendarExtender3" Format="MM/dd/yyyy" TargetControlID="txttodate" runat="server"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Reason"  ></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<textarea id="TextArea1" name="S1" rows="2" class="textboxcs" style="width: 130px; height: 55px;"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;&nbsp;
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<asp:Button    ID="Button1" runat="server" Text="Save" 
                                    onclick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Application Status</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td align="center">
                            <asp:Label ID="Label3" runat="server" CssClass="textheadcss" Font-Bold="False">Application Status</asp:Label>
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
                                    <asp:BoundField DataField="Admin Approval" HeaderText="Admin Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Admin Approval date" HeaderText="Admin Approval date"
                                        ReadOnly="True" />
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
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textheadcss" Font-Bold="False">Reports</asp:Label>
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
                                    <asp:BoundField DataField="Admin Approval" HeaderText="Admin Approval" ReadOnly="True" />
                                    <asp:BoundField DataField="Admin Approval date" HeaderText="Admin Approval date"
                                        ReadOnly="True" />
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

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
       
        #TextArea1
        {
            width: 125px;
            margin-left: 10px;
        }

      

    </style>
</asp:Content>

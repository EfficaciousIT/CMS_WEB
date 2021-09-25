<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmStudentTrainingReq.aspx.cs" Inherits="frmStudentTrainingReq" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 86px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <center>
        <table style="width: 690px; margin: 10px 0; height: 70px;" align="center">
            <tr height="35">
                <td align="left" width="230" colspan="2" style="width: 460px">
                    <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                        CssClass="mGrid" Width="674px">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Edit" OnClientClick="confirmation('Are sure you want to apply for training')"
                                        ID="lnkBtn" runat="server">
                                        <asp:Image ID="Img" runat="server" ImageUrl="images/success-arrow.png" /></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="synopsis">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkview" Visible="true" Font-Underline="true" runat="server">View</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="training" HeaderText="Training">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="startdate" HeaderText="Start date">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="endate" HeaderText="End date">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="time" HeaderText="Time">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="roomno" HeaderText="Room No.">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr height="35">
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </center>
    <%--<asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="850px"
        Height="525px">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                New Entry
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <table style="width: 513px; margin: 10px 0;" align="center">
                        <tr height="35">
                            <td align="left" class="style2">
                                <asp:Label ID="lblvchno" runat="server">Title</asp:Label>
                            </td>
                            <td align="left" width="230">
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="35">
                            <td align="left" class="style2" valign="top">
                                <asp:Label ID="lblvchmake" runat="server">Description</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDriverMName" runat="server" Font-Names="Verdana" MaxLength="20"
                                    Font-Size="Small" Width="366px" ForeColor="Black" ValidationGroup="b" Height="151px"></asp:TextBox>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr height="35" valign="bottom">
                            <td align="center" class="style2">
                                &nbsp;
                            </td>
                            <td align="left">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="style1">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="Clear" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Approval Status
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 690px; margin: 10px 0; height: 70px;" align="center">
                    <tr height="35">
                        <td align="left" width="230" colspan="2" style="width: 460px">
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="800px">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="Title">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="parentapproval" HeaderText="Parent Approval">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pdate" HeaderText="Approved Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="teacherapproval" HeaderText="Teacher Approval">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdate" HeaderText="Approved Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="adminaproval" HeaderText="Admin Approval">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="adate" HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr height="35">
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Training Notification
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 690px; margin: 10px 0; height: 70px;" align="center">
                    <tr height="35">
                        <td align="left" width="230" colspan="2" style="width: 460px">
                            <asp:GridView ID="GridView2" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="800px">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="Title">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="startdate" HeaderText="Start Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="enddate" HeaderText="End Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="applicationdate" HeaderText="Application Last Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr height="35">
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>--%>
</asp:Content>

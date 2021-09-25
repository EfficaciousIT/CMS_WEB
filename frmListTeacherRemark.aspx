<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmListTeacherRemark.aspx.cs" Inherits="frmListTeacherRemark" Title="Teacher Remark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 93%;
        }
        .style2
        {
            width: 463px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
     <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="900px">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Remark List
            </HeaderTemplate>
            <ContentTemplate>

                <div id="efficacious" class="efficacious">
        <table width="100%">
                    <tr>
                                                                <td align="left" nowrap="nowrap">
                                                                    <asp:Label ID="Label6" runat="server"   Font-Bold="False">Select Month</asp:Label>&nbsp;&nbsp;
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="dropdowncs" 
                                                                        Font-Names="Verdana">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem>Jan</asp:ListItem>
                                                                        <asp:ListItem>Feb</asp:ListItem>
                                                                        <asp:ListItem>Mar</asp:ListItem>
                                                                        <asp:ListItem>Apr</asp:ListItem>
                                                                        <asp:ListItem>May</asp:ListItem>
                                                                        <asp:ListItem>June</asp:ListItem>
                                                                        <asp:ListItem>July</asp:ListItem>
                                                                        <asp:ListItem>Aug</asp:ListItem>
                                                                        <asp:ListItem Selected="True">Sep</asp:ListItem>
                                                                        <asp:ListItem>Oct</asp:ListItem>
                                                                        <asp:ListItem>Nov</asp:ListItem>
                                                                        <asp:ListItem>Dec</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td align="left"  nowrap="nowrap">
                                                                    <asp:Label ID="Label7" runat="server"   Font-Bold="False">Select Date</asp:Label>&nbsp;&nbsp;
                                                                    <asp:TextBox ID="TextBox1" runat="server" 
                                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="20" Text="01-09-2014" 
                                                                        ValidationGroup="b"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                                        Format="MM/dd/yyyy" TargetControlID="TextBox1">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td align="right">
                                                                </td>
                                                            </tr>
        </table>
                   
        <table align="center" width="100%">
        <tr>
            <td colspan="5">
                <asp:GridView ID="GridViewremark" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    EmptyDataText="No Records Found" Width="100%" EnableModelValidation="True">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                ImageUrl="images/delete.png" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                Text="Delete" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                ImageUrl="images/icon_edit.png" Text="Delete" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                    <asp:BoundField DataField="dtRoll" HeaderText="Roll No">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dtName" HeaderText="Name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="teachername" HeaderText="Teacher name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="subject" HeaderText="Subject">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remark" HeaderText="Remark">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="date" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" />                            
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
         </asp:TabContainer>
</asp:Content>

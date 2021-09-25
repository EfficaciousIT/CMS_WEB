<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmCompalaintsManage.aspx.cs" Inherits="frmCompalaintsManage" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 489px;
        }
        .style2
        {
            width: 123px;
        }
        .style3
        {
            width: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="928px"
        CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Complaints Details
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="878px" OnRowEditing="GridView1_RowEditing">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton OnClientClick="confirm('Are sure you want to delete this record')"
                                                ID="lnkBtndelete" runat="server">
                                                <asp:Image ID="ImgDelete" runat="server" ImageUrl="images/delete.png" /></asp:LinkButton></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                                <asp:Image ID="Img" runat="server" ImageUrl="images/ServiceManager.png" /></asp:LinkButton></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="schoolname" HeaderText="School name">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Complaint" HeaderText="Complaint">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="datetime" HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="time" HeaderText="Time">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="name" HeaderText="Complaints name">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Action
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <table class="style1">
                        <tr>
                            <td class="style3">
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
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td class="style2" align="left">
                                <asp:Label ID="Label26" runat="server" Text="School name"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                            </td>
                            <td align="left" class="style2">
                                <asp:Label ID="Label1" runat="server" Text="Complaint"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td align="left" class="style2">
                                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td align="left" class="style2" valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Time"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td align="left" class="style2">
                                <asp:Label ID="Label4" runat="server" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;
                            </td>
                            <td align="left" >
                                <asp:Label ID="Label6" runat="server" Text="Remark"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Height="57px" Width="245px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                              <table width="25%">
                                  <tr>
                                      <td>

                                <asp:Button    ID="Button1" CssClass="efficacious_send" runat="server" Text="Submit" />
                            
                                <asp:Button    ID="Button2" CssClass="efficacious_send" runat="server" Text="Clear" />
                            </td>
                            
                                      
                                  </tr>
                              </table>
                        </tr>
                    </table>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>

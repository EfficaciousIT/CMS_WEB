<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmTeacherRemark.aspx.cs" Inherits="frmTeacherRemark" Title="Teacher Remark" %>

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
     <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="928px" CssClass="MyTabStyle">
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Remark
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="efficacious">
                            <center>
                                
     <table class="style1">
     
<tr>
            <td colspan="5">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    EmptyDataText="No Records Found" Width="928px" >
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
 
    </table>
                                   
                                </center>
                                 </div>
                            </ContentTemplate>
                        </asp:TabPanel>
         </asp:TabContainer>
</asp:Content>

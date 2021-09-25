<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="FrmTeacherLog.aspx.cs" Inherits="FrmTeacherLog" Title="Teacher Login Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding:5px,0,0,0">
        <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Last 5 Logins
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="width: 100%" align="center">
                    
                    <tr>
                        <td align="right">
                            <asp:GridView ID="Gridlog1" DataKeyNames="dtLoginDate" runat="server" EmptyDataText="Record not Found."
                                AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="True"
                                OnPageIndexChanging="Gridlog1_PageIndexChanging" OnRowCancelingEdit="Gridlog1_RowCancelingEdit"
                                CssClass="mGrid" OnRowDeleting="Gridlog1_RowDeleting" OnRowEditing="Gridlog1_RowEditing">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                 
                                    <asp:BoundField DataField="dtLoginDate" HeaderText="Date"  />
                                    <asp:BoundField DataField="dtLoginTime" HeaderText="LogInTime"  />
                                    <asp:BoundField DataField="dtLogoutTime" HeaderText="LogOutTime"  />
                                    <asp:BoundField DataField="vchIPaddress" HeaderText="IpAddress"  />
                                </Columns>
                                <PagerStyle CssClass="pgr"></PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                History
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="width: 100%;">
                    <tr>
                        
                        <td align="right">
                     
                            <asp:Label ID="Label4" runat="server"   Font-Bold="False">Month</asp:Label>
                       
                            <asp:DropDownList ID="DropDownList5" AutoPostBack="True" runat="server" Height="16px" Width="146px" 
                                onselectedindexchanged="DropDownList5_SelectedIndexChanged">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                                <asp:ListItem Value="01">Jan</asp:ListItem>
                                <asp:ListItem Value="02">Feb</asp:ListItem>
                                <asp:ListItem Value="03" >Mar</asp:ListItem>
                                <asp:ListItem Value="04">Apr</asp:ListItem>
                                <asp:ListItem Value="05">May</asp:ListItem>
                                <asp:ListItem Value="06">June</asp:ListItem>
                                <asp:ListItem Value="07">July</asp:ListItem>
                                <asp:ListItem Value="08">Aug</asp:ListItem>
                                <asp:ListItem Value="09">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                        
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                       
                            <asp:GridView ID="Gridlog2" runat="server" designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="dtLoginDate"
                                EmptyDataText="Record not Found." OnPageIndexChanging="Gridlog2_PageIndexChanging"
                                OnRowCancelingEdit="Gridlog2_RowCancelingEdit" OnRowDeleting="Gridlog2_RowDeleting"
                                OnRowEditing="Gridlog2_RowEditing" Width="100%" EnableModelValidation="True" >
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>                                                                        
                                    <asp:BoundField DataField="dtLoginDate" HeaderText="Date"  />
                                    <asp:BoundField DataField="dtLoginTime" HeaderText="LogInTime"  />
                                    <asp:BoundField DataField="dtLogoutTime" HeaderText="LogOutTime"  />
                                    <asp:BoundField DataField="vchIPaddress" HeaderText="IpAddress"  />
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
</td></tr></table>
</div>
</asp:Content>

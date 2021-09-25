<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="FrmParentsLog.aspx.cs" Inherits="FrmParentsLog" Title="FrmParentsLog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>
 .mGrid th {
         text-align: center !important;
            }


                     
</style>
    <div style="padding:5px,0,0,0">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
    <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="3"
        Width="1015px" CssClass="MyTabStyle">
        
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Last 5 Logins
            </HeaderTemplate>
            <ContentTemplate>
              <div class="efficacious" style="  margin-top: 15px;">
                <table style=" width: 100%;" align="center" >
                
                    <tr>
                        <td align="right">
                            <asp:GridView ID="Gridlog1" DataKeyNames="dtLoginDate" runat="server" EmptyDataText="Record not Found."
                                AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="True"
                                OnPageIndexChanging="Gridlog1_PageIndexChanging" OnRowCancelingEdit="Gridlog1_RowCancelingEdit"
                                CssClass="mGrid" OnRowDeleting="Gridlog1_RowDeleting" OnRowEditing="Gridlog1_RowEditing" EnableModelValidation="True">
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
                <div class="efficacious" >
                <table style="width: 100%;" align="center">
                    <tr>
                        
                        <td align="right" style="padding: 10px 320px;">
                       
                            <asp:Label ID="Label4" runat="server" style="float:left; padding:5px 5px; margin:0;"  Font-Bold="False">Month</asp:Label>
                      
                            <asp:DropDownList ID="DropDownList5" AutoPostBack="true" runat="server" style="float:left;" Height="24" Width="146px" 
                                onselectedindexchanged="DropDownList5_SelectedIndexChanged">
                                <asp:ListItem Selected="True">--Select--</asp:ListItem>
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
                     
                            <asp:GridView ID="Gridlog2" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="dtLoginDate"
                                EmptyDataText="Record not Found." OnPageIndexChanging="Gridlog2_PageIndexChanging"
                                OnRowCancelingEdit="Gridlog2_RowCancelingEdit" OnRowDeleting="Gridlog2_RowDeleting"
                                OnRowEditing="Gridlog2_RowEditing" Width="100%">
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
                </table></div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Student Last 5 Logins
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious" style="  margin-top: 15px;">
            <center>
                <table style="font-weight: bolder; width: 100%" align="center">
                   
                    <tr>
                        <td>
                            <asp:GridView ID="Gridlog3" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="dtLoginDate"
                                EmptyDataText="Record not Found." OnPageIndexChanging="Gridlog3_PageIndexChanging"
                                OnRowCancelingEdit="Gridlog3_RowCancelingEdit" OnRowDeleting="Gridlog3_RowDeleting"
                                OnRowEditing="Gridlog3_RowEditing" Width="100%">
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
                </table>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
           <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Student Logins History
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                                <center>
                <table style="width: 100%" align="center">
                   
                        <tr>
                            <td align="right" style="padding: 10px 320px;">
                               
                                        <asp:Label ID="Label2" runat="server"  style="float:left; padding:5px 5px; margin:0;"  Font-Bold="False">Month</asp:Label>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Height="24px" style="float:left;" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="146px">
                                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                            <asp:ListItem Value="01">Jan</asp:ListItem>
                                            <asp:ListItem Value="02">Feb</asp:ListItem>
                                            <asp:ListItem Value="03">Mar</asp:ListItem>
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
                            <tr>
                                <td>
                                  
                                            <asp:GridView ID="Gridlog4" runat="server" __designer:wfdid="w36" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="dtLoginDate" EmptyDataText="Record not Found." OnPageIndexChanging="Gridlog4_PageIndexChanging" OnRowCancelingEdit="Gridlog4_RowCancelingEdit" OnRowDeleting="Gridlog4_RowDeleting" OnRowEditing="Gridlog4_RowEditing" width="100%">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:BoundField DataField="dtLoginDate" HeaderText="Date" />
                                                    <asp:BoundField DataField="dtLoginTime" HeaderText="LogInTime" />
                                                    <asp:BoundField DataField="dtLogoutTime" HeaderText="LogOutTime" />
                                                    <asp:BoundField DataField="vchIPaddress" HeaderText="IpAddress" />
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                       
                                </td>
                            </tr>
                        </tr>
                  
                </table>
                </center>
                    </div>

            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</td></tr></table>
                    </ContentTemplate>
         </asp:UpdatePanel>
</div>
</asp:Content>

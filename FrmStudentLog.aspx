<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="FrmStudentLog.aspx.cs" Inherits="FrmStudentLog" Title="Student Login Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <h1>
            Login Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>DashBoard</a></li>
            <li><a ><i ></i>Login Details</a></li>
           
        </ol>
    </div>
<style>
.mGrid th{ text-align:center !important;}
</style>
    <div style="padding:5px,0,0,0">
        <asp:UpdatePanel ID="upda4" runat="server"><ContentTemplate>
        <table><tr><td align="left">

              
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"
        Width="1015px" CssClass="MyTabStyle">
        <div class="clearfix">
    </div>
  
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Last 5 Logins
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="width:100%">
                    
                    <tr>
                        <td align="right">
                            <asp:GridView ID="Gridlog1" DataKeyNames="dtLoginDate" runat="server" EmptyDataText="Record not Found."
                                AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="True"
                                OnPageIndexChanging="Gridlog1_PageIndexChanging" OnRowCancelingEdit="Gridlog1_RowCancelingEdit"
                                CssClass="table  tabular-table" OnRowDeleting="Gridlog1_RowDeleting" OnRowEditing="Gridlog1_RowEditing" EnableModelValidation="True">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                 
                                    <asp:BoundField DataField="dtLoginDate" HeaderText="Date"  />
                                    <asp:BoundField DataField="dtLoginTime" HeaderText="LoginTime"  />
                                    <asp:BoundField DataField="dtLogoutTime" HeaderText="LogOutTime" Visible="false"  />
                                    <asp:BoundField DataField="vchIPaddress" HeaderText="URLAddress"  />
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
                <table width="100%">
                    <tr>
                        <td >
                            <div class="efficacious" id="efficacious">
                       <table  align="right">
                       
                       <tr>

                           <td width="400">
                           
                           </td>
                            <td width="100">
                            <asp:Label ID="Label4" runat="server"   Font-Bold="False">Month</asp:Label>
                       </td>
                           <td width="300">
                            <asp:DropDownList ID="DropDownList5" Width="80%" AutoPostBack="True" runat="server" onselectedindexchanged="DropDownList5_SelectedIndexChanged">
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
                         
                           <td width="300">
                           
                           </td>
                         </tr></table>
                                </div>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                        <br />
                            <asp:GridView ID="Gridlog2" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="dtLoginDate"
                                EmptyDataText="Record not Found." OnPageIndexChanging="Gridlog2_PageIndexChanging"
                                OnRowCancelingEdit="Gridlog2_RowCancelingEdit" OnRowDeleting="Gridlog2_RowDeleting"
                                OnRowEditing="Gridlog2_RowEditing" Width="100%">
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>                                                                        
                                    <asp:BoundField DataField="dtLoginDate" HeaderText="Date"  />
                                    <asp:BoundField DataField="dtLoginTime" HeaderText="LoginTime"  />
                                    <asp:BoundField DataField="dtLogoutTime" HeaderText="LogOutTime"  
                                        Visible="False"/>
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
</ContentTemplate></asp:UpdatePanel>
    </div>
</asp:Content>

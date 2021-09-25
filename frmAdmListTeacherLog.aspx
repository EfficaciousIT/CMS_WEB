<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmListTeacherLog.aspx.cs" Inherits="frmAdmListTeacherLog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updat4" runat="server"><ContentTemplate>
  
            <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
               Teacher Login's Details
</HeaderTemplate>           
<ContentTemplate>
<center>
    <div class="efficacious">
    <table style="font-weight: bolder; width: 35%; margin: 10px 0;" align="center">
    
       <tr><td colspan="5"><br /></td></tr>
     <tr>
            <td align="center" >
                <asp:Label ID="Label11" runat="server"   Font-Bold="False">Select Department</asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Verdana" 
                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    ValidationGroup="b"  AutoPostBack="True" >
                </asp:DropDownList>
                <br/>  
            </td>
        </tr>
        <tr>
       <td align="center" >
                <asp:Label ID="Label1" runat="server"   Font-Bold="False">Select Teacher ID</asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Verdana"
                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                    ValidationGroup="b" AutoPostBack="True" >  
                </asp:DropDownList> 
            </td>
            </tr>
        
    </table>

    <table width="100%">
        <tr align="center" id="listparengrid" runat="server">
            <td class="style10" runat="server">
               Teacher Login's Details
            </td>
        </tr>
        <tr id="listparengrid1" runat="server">
            <td align="right" runat="server">
                            <asp:GridView ID="GridViliTeachdvl" DataKeyNames="intLogin_id" runat="server" EmptyDataText="Record not Found." AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="True"
                                OnPageIndexChanging="GridViliTeachdvl_OnPageIndexChanging" OnRowCancelingEdit="GridViliTeachdvl_RowCancelingEdit" CssClass="mGrid" OnRowDeleting="GridViliTeachdvl_RowDeleting" OnRowEditing="GridViliTeachdvl_RowEditing" EnableModelValidation="True" OnSelectedIndexChanged="GridViliTeachdvl_SelectedIndexChanged">
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
    </center>
      </ContentTemplate>
    </asp:TabPanel>
    </asp:TabContainer>
    </td>
    </tr>
    </table>   

        </ContentTemplate></asp:UpdatePanel>                          
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
 
</asp:Content>

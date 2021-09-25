<%@ Page Title="List Of Student Present in School But Absent in Bus" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmPreSchoAbseBus.aspx.cs" Inherits="frmPreSchoAbseBus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style type="text/css">
       
         .mGrid th{ text-align:center !important;}
         td{colspan="1"}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="left" >
                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
                            Width="1015px" CssClass="MyTabStyle">
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                <HeaderTemplate>Present in school Absent in bus</HeaderTemplate>
                                <ContentTemplate>
                                    <div class="efficacious">
                                    <center>
                <table width="100%">
             <tr>
             <td align="right" >
                                        <asp:Label ID="Label1" runat="server" Text="Travel Details" Visible="False"></asp:Label>
                                    </td>
             <table width=""310">
             
                                    <td align="left" width="90">
                                        <asp:LinkButton ID="lnkPrevious" runat="server" style=" position:relative; top:-4px; color:#000; font-size:12px;" Font-Underline="True" 
                                            >Previous</asp:LinkButton>
                                    </td>
                                    <td align="left" width="130" >
                                        <asp:DropDownList ID="ddlMonth" runat="server" Font-Names="Verdana" 
                                            Font-Size="13px" style="width:100%;" AutoPostBack="True" 
                                            onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">June</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="90" >
                                        <asp:LinkButton ID="lnkNext" runat="server" style=" position:relative; top:-4px; color:#000; font-size:12px; right:18px" Font-Underline="True" 
                                            >Next</asp:LinkButton>
                                    </td>
             </table>
                                    
                                    
                                </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:GridView ID="GridView1" EmptyDataText="No Records Found" runat="server" AllowPaging="True"  AutoGenerateColumns="False"
                                CssClass="mGrid" Width="100%" OnRowEditing="GridView1_RowEditing" 
                                 DataKeyNames="RollNo" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="Gridview1_OnPageIndexChanging">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="Rollno" HeaderText="Roll No" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   
                                    <asp:BoundField DataField="Name" HeaderText="Name" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Route_name" HeaderText="Route Name" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BusStop" HeaderText="Bus Stop Name" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="True"/> 
                            </asp:GridView>
                        </td>
                        
                    </tr>
                    
                </table>
                                        
          
</center>
                                        </div>
                                    </ContentTemplate>
                                    </asp:TabPanel>
                                    </asp:TabContainer>
                                    </td>
                                    </tr>
                                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>

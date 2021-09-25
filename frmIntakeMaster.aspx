<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmIntakeMaster.aspx.cs" Inherits="frmIntakeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 530px;
        }
        .tabular-table
        {}
        .style3
        {
            width: 86px;
        }
        .style4
        {
            width: 103px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Intake Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
             <li><a ><i ></i>Master</a></li>
            <li><a ><i ></i>School Master</a></li>
            <li class="active">Intake Details</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="80%">
                                                <tr>
                                        <td align="right" class="style2">
                                            <asp:Label ID="Label2" runat="server" Text="Academic Year"></asp:Label>

                                        </td>
                                        <td style="padding-left: 4px" class="style4">
                                            <asp:DropDownList ID="ddlAcademic" runat="server" AutoPostBack="True" width="100%"
                                                onselectedindexchanged="ddlAcademic_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    
                                        <td align="center" class="style3">
                                            <asp:Label ID="Label4" runat="server" Text="Standard"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlSTD" runat="server"  AutoPostBack="True"
                                                onselectedindexchanged="ddlSTD_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                       
                                    </tr>
                                                    <tr>
                                                        <td align="left" class="style2">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" 
                                                                DataKeyNames="intIntake_Id" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing" >
                                                                <Columns>
                                                                   <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:BoundField DataField="intAcademic_id" HeaderText="Academic Year" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                      <asp:BoundField DataField="intCat_Id" HeaderText="Category" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchSeat" HeaderText="Seat" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchTotalSeat" HeaderText="Total Seat" ReadOnly="True" />
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                      <td align="right" class="style2">
                                                       <asp:Label ID="lblTotalSeat" runat="server" Text="Total Seat :"></asp:Label>
                                                    </td>
                                                    <td class="style4" >
                                                       <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                                    </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
            <center>
                <br />
                <div>
                    <table width="60%">
                        <tr>
                            <td align="left">
                                <table width="60%">
                                 <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="Label5" runat="server" Text="Academic Year"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpAcademicYear" runat="server" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="lblSTD1" runat="server" Text="Standard"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpStandard" runat="server" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpCategory" runat="server">
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Seat"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:TextBox ID="txtSeat" runat="server" CssClass="input-blue" MaxLength="3"></asp:TextBox>
                                             <asp:FilteredTextBoxExtender ID="FBTE1" runat="server" TargetControlID="txtSeat"
                                                                FilterType="Numbers" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Total Seat"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:TextBox ID="txtTotalSeat" runat="server" CssClass="input-blue" MaxLength="4"></asp:TextBox>
                                             <asp:FilteredTextBoxExtender ID="FBTE2" runat="server" TargetControlID="txtTotalSeat"
                                                                FilterType="Numbers" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                      
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;
                            </td>
                        </tr>
                    </table>                   
                    <table width="28%">
                        <tr>
                            
                            <td width="50%" align="right">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                    Text="Submit" onclick="btnSubmit_Click"  />
                            </td>
                            <td width="50%" align="right">
                                <asp:Button ID="btnClear1" CssClass="efficacious_send" runat="server" Text="Clear"
                                    Visible="False"  />
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


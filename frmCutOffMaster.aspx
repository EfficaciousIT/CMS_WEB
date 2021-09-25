<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmCutOffMaster.aspx.cs" Inherits="frmCutOffMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Cut Off Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
             <li><a ><i ></i>School Master</a></li>
            <li class="active">Cut Off Details</li>
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
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Academic Year"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="ddlAcademic" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="ddlAcademic_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    
                                        <td align="left">
                                            <asp:Label ID="Label4" runat="server" Text="Standard"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="ddlSTD_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="60%" 
                                                                DataKeyNames="intCutOff_Id" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing"  >
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
                                                                     <asp:BoundField DataField="vchPercentage" HeaderText="Percentage" ReadOnly="True" />
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
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
                                            <asp:Label ID="Label1" runat="server" Text="Percentage"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:TextBox ID="txtPercentage" runat="server" CssClass="input-blue"></asp:TextBox>
                                             <asp:FilteredTextBoxExtender ID="FBTE1" runat="server" TargetControlID="txtPercentage"
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


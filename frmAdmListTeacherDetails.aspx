<%@ Page Title="Teacher Details" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmListTeacherDetails.aspx.cs" Inherits="frmAdmListTeacherDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>.efficacious input[type="image"]{ width:40% !important;}</style>
    <div style="padding:5px 0 0 0" >
        <table><tr><td align="left">
    <asp:UpdatePanel ID="Updapn1" runat="server"><ContentTemplate>
    <asp:TabContainer ID="TabContainer1" runat="server"  ActiveTabIndex="0"
        Width="1015px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                Teacher Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <div class="efficacious">
        <table width="35%">

     <tr>
            <td align="center" nowrap="nowrap">
                <asp:Label ID="Label11" runat="server"  >Select Department</asp:Label>
                </td><td>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Verdana" 
                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    ValidationGroup="b" AutoPostBack="True" >
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
       <td align="center" >
                <asp:Label ID="Label1" runat="server"  >Select Teacher ID</asp:Label>
             </td><td>
                <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Verdana"
                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                    ValidationGroup="b"  AutoPostBack="True">  
                </asp:DropDownList> 
            </td>
            </tr>
           
    </table>
                        </div>
                    <div class="efficacious">
    <table>
        <tr id="id1h1" runat="server" visible="False">
            <td runat="server">
            </td>
        </tr>
    </table>
                        </div>
                    <div class="efficacious">
    <table width="100%">
        <tr align="center" id="listTeachgrid" runat="server" visible="False">
            <td style="padding-bottom:25px" runat="server">
                List Of Teacher Profile Details
            </td>
        </tr>
        <tr id="listTeacggrid1" runat="server" visible="False">
            <td style="padding: 10px 0 20px 0;" runat="server">
                <asp:GridView ID="GridViewlistTeach" runat="server" designer:wfdid="w36" AllowPaging="True"
                    AllowSorting="True" OnRowDeleting="GridViewlistTeach_RowDeleting" OnRowEditing="GridViewlistTeach_RowEditing" OnDataBound="GridViewlistTeach_DataBound" OnRowDataBound="GridViewlistTeach_RowDataBound" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="intTeacher_id"
                    EmptyDataText="Record not Found." Width="100%" EnableModelValidation="True">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="images/delete.png" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                    Text="Delete" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" Style="width:20px !important;" CommandName="Edit"
                                    ImageUrl="images/icon_edit.png" Text="Delete" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                ImageUrl="images/icon_edit.png" Text="Delete" AlternateText="Details" ToolTip="Click"
                                                Style="width:20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                        <asp:BoundField DataField="intTeacher_id" HeaderText="Teacher Id" ReadOnly="True"/>
                        <asp:BoundField DataField="Name" HeaderText="Teacher Name" ReadOnly="True"/>
                        <asp:BoundField DataField="vchPreferedSubject" HeaderText="Subject" ReadOnly="True"/>
                        <asp:BoundField DataField="DepartmentId" HeaderText="Department" ReadOnly="True"/>
                        <asp:BoundField DataField="intMobileNo" HeaderText="Mobile No" ReadOnly="True"/>
                        <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True"/>
                        <asp:BoundField DataField="dtTimeToContact" HeaderText="Time To Contact" ReadOnly="True"/>
                        
                    </Columns>
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </td>
        </tr>
    </table>
                        </div>
                    </center>
                 </ContentTemplate>
                </asp:TabPanel>
                </asp:TabContainer>
        </ContentTemplate></asp:UpdatePanel>
        </td></tr></table>
         </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style6
        {
            height: 16px;
        }
        .style7
        {
            width: 162px;
            height: 26px;
        }
        .style8
        {
            width: 162px;
            height: 22px;
        }
        .style9
        {
            height: 22px;
        }
         .mGrid th {
         text-align: center !important;
            }

    </style>
</asp:Content>

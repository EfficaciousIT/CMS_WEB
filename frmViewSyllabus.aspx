<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" Title="E-Smarts - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management" AutoEventWireup="true" CodeFile="frmViewSyllabus.aspx.cs"
    Inherits="frmViewSyllabus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Syllabus
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Study</a></li>
            <li class="active">Syllabus</li>
        </ol>
    </div>
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 5px 0 0 0">
                    <center>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                                ActiveTabIndex="0">
                                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                    <HeaderTemplate>
                                                        Detail</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <div id="div1" runat="server">
                                                                <table width="70%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table class="style2">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="Label1" runat="server" Text="Exam"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:DropDownList ID="drpExam" runat="server">
                                                                                            <asp:ListItem>---Select---</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:DropDownList ID="drpSubject" runat="server" 
                                                                                            OnSelectedIndexChanged="drpSubject_SelectedIndexChanged" AutoPostBack="True">
                                                                                            <asp:ListItem>---Select---</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                CssClass="table  tabular-table" DataKeyNames="intSyllabus_id,FilePath" PageSize="20"
                                                                                Width="100%" 
                                                                                EmptyDataText="No Records Found" 
                                                                                onrowcommand="grvDetail_RowCommand">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="vchTopicName" HeaderText="Topic" ReadOnly="True">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="vchSyllabusNm" HeaderText="Syllabus" ReadOnly="True">
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>                                                                                    
                                                                                    <asp:TemplateField HeaderText="Document">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImgView" CommandName="View" OnClientClick="SetTarget();" CausesValidation="false"
                                                                                                runat="server" CommandArgument='<%#Bind("FilePath") %>' ImageUrl="~/images/action_success.png" /></ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Visible="false">
                                                </asp:TabPanel>
                                            </asp:TabContainer>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </center>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

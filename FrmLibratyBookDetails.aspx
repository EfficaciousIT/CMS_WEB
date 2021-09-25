<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="FrmLibratyBookDetails.aspx.cs" Inherits="frmBookIssue" Title="E-Smarts - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Library
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li class="active">Library</li>
        </ol>
    </div>
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
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
                                                        Book Detail</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <br />
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:GridView ID="grgBooks" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CssClass="table  tabular-table" Width="90%" EmptyDataText="No Books available">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                            <asp:BoundField DataField="intStandard_id" HeaderText="Division" ReadOnly="True" />
                                                                            <asp:BoundField DataField="intBookQuantity" HeaderText="Book Quantity" ReadOnly="True" />
                                                                            <asp:BoundField DataField="vchBookDetails_bookName" HeaderText="Book Name" ReadOnly="True" />
                                                                            <asp:BoundField DataField="intBookPrice" HeaderText="Book Prize" ReadOnly="True" />
                                                                            <asp:BoundField DataField="intCategory_id" HeaderText="Book Category" ReadOnly="True" />

                                                                             <asp:BoundField DataField="intBookEdition_id" HeaderText="Book Edition" ReadOnly="True" />
                                                                            <asp:BoundField DataField="intBook_publication_id" HeaderText="Book Publication Name" ReadOnly="True" />
                                                                            <asp:BoundField DataField="intBook_Author_id" HeaderText="Book Auther" ReadOnly="True" />
                                                                        
                                                                           <%-- <asp:BoundField DataField="dtReturnDate" HeaderText="Last Date" ReadOnly="True" />
                                                                            <asp:BoundField DataField="dtActualRetDate" HeaderText="Returned Date" ReadOnly="True" />--%>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </ContentTemplate>
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
            <td align="right" width="100%" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="right" width="100%" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

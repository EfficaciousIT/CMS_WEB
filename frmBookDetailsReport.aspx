<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmBookDetailsReport.aspx.cs" Inherits="frmBookDetailsReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <h1>
            Book Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Report</a></li>
            <li class="active">Book Details</li>
        </ol>
    </div>
    <style>
        .efficacious_send {
            width: 100% !important;
            background: #3498db;
            border: none;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            margin-right: 10px;
            float: none;
            text-align: center;
        }

        .textcss {
            font-size: 13px !important;
        }

        .textsize {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0px;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 0px;
            border: 1px solid #888;
            width: 30%;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }
    </style>
        <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="80%">
                                                <tr>
                                                        <td align="left" width="5%">
                                                            Category</td>
                                                        <td align="left" width="17%">
                                                            <asp:DropDownList ID="ddlBookCategory" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="getResult">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" width="5%">
                                                            Edition</td>
                                                        <td align="left" width="17%">
                                                            <asp:DropDownList ID="ddlBookEdition" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="getResult">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" width="5%">
                                                            Publication</td>
                                                        <td align="left" width="17%">
                                                            <asp:DropDownList ID="ddlBookPublication" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="getResult">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" width="5%">
                                                            Author</td>
                                                        <td align="left" width="17%">
                                                            <asp:DropDownList ID="ddlBookAuthor" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="getResult">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="5%" style="padding: 5px;">
                                                            <asp:Button ID="Button1" runat="server" CssClass="efficacious_send" 
                                                                    Text="Export to Excel" onclick="ExportToExcel_Click"  />
                                                        </td>
                                                    </tr>
                                                 <table width="100%">
                                                <tr>
                                                 <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " PageSize="20" Width="99%"   AllowPaging="True"  OnPageIndexChanging="grvDetail_OnPageIndexChanging"
                                                        DataKeyNames="intBookDetails_id">
                                                        <Columns>
                                                        <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchAccessionNo" HeaderText="Accessio No." ReadOnly="True" />
                                                        <asp:BoundField DataField="intCategory_id" HeaderText="Category" ReadOnly="True" />
                                                        <asp:BoundField DataField="intBookEdition_id" HeaderText="Edition" ReadOnly="True" />
                                                        <asp:BoundField DataField="intBook_publication_id" HeaderText="Publication" ReadOnly="True" />
                                                        <asp:BoundField DataField="intBook_Author_id" HeaderText="Author" ReadOnly="True" />
                                                        <asp:BoundField DataField="intBookLanguage_id" HeaderText="Subject" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchBookDetails_bookName" HeaderText="Book Name" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchBookDetails_Status" HeaderText="Status" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchBookDetails_Remark" HeaderText="Remark" ReadOnly="True" />
                                                        <asp:BoundField DataField="intBookQuantity" HeaderText="Qty" ReadOnly="True" 
                                                                Visible="False" />
                                                        <asp:BoundField DataField="intBookPrice" HeaderText="Price" ReadOnly="True"  
                                                                Visible="False"/>                                                                       
                                                                   
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                </tr>
                                                </table>
                                            </center>
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
</asp:Content>


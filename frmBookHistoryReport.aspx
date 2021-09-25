<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmBookHistoryReport.aspx.cs" Inherits="frmBookHistoryReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <h1>
            Book History
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Report</a></li>
            <li class="active">Book History</li>
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
                                                <table width="99%">
                                                <tr>
                                                        <td align="left" width="1%">
                                                            Student</td>
                                                        <td align="left" width="9%">
                                                            <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="ddlStudent_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="1%"></td>
                                                        <td width="1%"> OR </td>
                                                        <td align="center" width="1%">
                                                            Teacher</td>
                                                        <td align="left" width="9%">
                                                            <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="True" 
                                                                 onselectedindexchanged="ddlTeacher_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" width="1%">
                                                            Accession No</td>
                                                        <td align="left" width="9%"> 
                                                         <asp:TextBox ID="txtSearchAccession" runat="server"  width="100%"
                                                                CssClass="input-blue" AutoPostBack="True" 
                                                                ontextchanged="txtSearchAccession_TextChanged" >
                                                         </asp:TextBox>
                                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchAccession"
                                                                    MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="10" ServiceMethod="GetSearchAccession" DelimiterCharacters="" 
                                                                    Enabled="True" ServicePath="">
                                                                </asp:AutoCompleteExtender>
                                                   
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
                                                                <asp:BoundField DataField="Role" HeaderText="Role" ReadOnly="True" />
                                                                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="Standard" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="Division" HeaderText="Division" ReadOnly="True" />
                                                                <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="True" />
                                                                <asp:BoundField DataField="Designation" HeaderText="Designation" ReadOnly="True" />
                                                                <asp:BoundField DataField="BookName" HeaderText="Book Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ExpectedReturnDate" HeaderText="Expected Return Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ReturnedDate" HeaderText="Returned Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True"  />                                                                     
                                                                   
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


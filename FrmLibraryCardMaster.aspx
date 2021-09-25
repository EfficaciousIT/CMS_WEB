<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="FrmLibraryCardMaster.aspx.cs" Inherits="FrmLibraryCardMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Accession Creation
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li class="active">Master</li>
            <li class="active">Library Master</li>
            <li class="active">Accession Master</li>
        </ol>
    </div>
<style>
        .efficacious_send
        {
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
        .textcss
        {
            font-size: 13px !important;
        }
        .textsize
        {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
    </style>
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="80%">
                                                <tr>
                                                        <td align="left">
                                                            Standard</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDetStandard" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDetStandard_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center">
                                                            Subject</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDetSubject" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDetSubject_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center">
                                                            Book Name</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDetBookName" runat="server" 
                                                                onselectedindexchanged="ddlDetBookName_SelectedIndexChanged" 
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" 
                                                                DataKeyNames="intLib_card_id" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing"
                                                                >
                                                                <Columns>
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="intCategory_id" HeaderText="Category" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookEdition_id" HeaderText="Edition" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBook_publication_id" HeaderText="Publication" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBook_Author_id" HeaderText="Author" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookLanguage_id" HeaderText="Subject" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookDetails_id" HeaderText="Book Name" ReadOnly="True" />

                                                                   <asp:BoundField DataField="intCard_no" HeaderText="Accession Number" ReadOnly="True" />
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
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
                                            
                                                <table width="36%" style="text-align: right; margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Standard</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlStandard_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                ControlToValidate="ddlStandard" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Category</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlBookCategory" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                ControlToValidate="ddlBookCategory" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Edition</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlBookEdition" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                ControlToValidate="ddlBookEdition" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Publication</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlBookPublication" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                                ControlToValidate="ddlBookPublication" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Author</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlBookAuthor" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlBookAuthor_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="ddlBookAuthor" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Subject</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlSubject_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                ControlToValidate="ddlSubject" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Name</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlBookName" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="ddlBookName" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify"> 
                                                            <asp:Label ID="Label2" runat="server" Text="Accession Number"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtAccessionNo" runat="server" CssClass="input-blue" MaxLength="8" 
                                                                AutoComplete="Off"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAccessionNo"
                                                                Display="None" ErrorMessage="Please Enter Accession Number"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left" >
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            
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


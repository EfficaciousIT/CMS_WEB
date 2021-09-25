<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmRegistrationFormCollection.aspx.cs" Inherits="frmRegistrationFormCollection"
    Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-family: Verdana;
        }
        .inputf
        {
            width: 120px;
            height: auto;
            padding: 5px;
            border: 1px solid #3498db;
        }
        .search
        {
            border: 1px solid #3498db !important;
            padding: 0px;
        }
        .efficacious_send
        {
            width: 100px;
            background: #3498db;
            font-size: 16px;
            border: none;
            margin-left: 10px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center;
        }
        .style1 input, form.winner-inside textarea, select {
            display: block;
            border: 1px solid #3498db;
            width: 21%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
            margin-left: 10px;
        }        
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=grdcandidate.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
         
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Form Acceptance
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">Form Acceptance</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                                Width="1015px">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Form Acceptance</HeaderTemplate>
                                    <ContentTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="180">
                                                    <asp:Label ID="Label1" runat="server" Style="padding-left: 10px;" Text="Registration Form No"></asp:Label>
                                                </td>
                                                <td width="130">
                                                    <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="input-blue"></asp:TextBox>
                                                </td>
                                                <td width="100" align="center">
                                                    <asp:ImageButton ID="btnSearch" runat="server" CssClass="search" ImageUrl="~/images/search.png"
                                                        OnClick="btnSearch_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td width="30">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="grdcandidate" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                        DataKeyNames="No" CssClass="table  tabular-table " Width="840px">
                                                        <Columns>
                                                            <asp:TemplateField Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="chkCtrl" runat="server" onclick="RadioCheck(this);" Style="left: 20px; width:0px" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="No" HeaderText="Form No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Candidate Name" HeaderText="Candidate Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Father Name" HeaderText="Father Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Father Mobile" HeaderText="Father Mobile">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSub" runat="server" CssClass="efficacious_send" OnClick="btnSub_Click"
                                                        Text="Submit" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Reff No" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblReffNo" runat="server" Text="Label" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" >
                                <HeaderTemplate>
                                            Accepted List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="90%" 
                                                                DataKeyNames="intRF_id"   >
                                                                <Columns>
                                                                    <%--<asp:TemplateField HeaderText="Delete">
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
                                                                    </asp:TemplateField>--%>
                                                                    <asp:BoundField DataField="vchRF_no" HeaderText="Registration No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchInquiry_no" HeaderText="Inquiry No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchCandiadateName" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchFatherMobile" HeaderText="Mobile" ReadOnly="True" />
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
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

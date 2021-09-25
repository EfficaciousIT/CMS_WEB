<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmRegistrationSearch.aspx.cs" Inherits="frmRegistrationSearch" Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .efficacious input
        {
            width: 95% !important;
            border: 1px solid #d5d5d5 !important;
            font-size: 16px;
            background: #f8f8f8;
            color: #242424;
            float: left;
            text-align: left;
            padding: 5px;
            margin: 5px;
            border-radius: 0 !important;
            -webkit-border-radius: 0 !important;
        }
        .efficacious input[type=checkbox]:checked + label:after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=100);
            opacity: 1;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            width: 17px !important;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
        }
        .efficacious label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            white-space: nowrap;
        }
        .efficacious input[type=checkbox] + label
        {
            display: block;
            width: 1.1em;
            height: 0.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
        }
        .efficacious input[type=checkbox]:checked + label::before
        {
            content: "\2714";
            color: #fff;
            height: 1em;
            line-height: 1.1em;
            width: 1.1em;
            font-weight: 900;
            margin-right: 6px;
            margin-left: -20px;
        }
        .efficacious input[type=radio] + label
        {
            display: block;
            width: 5em;
            height: 2em;
            background: #3498db !important;
            border-radius: 2px !important;
            border: none !important;
            vertical-align: middle;
            line-height: 1em;
            font-size: 13px;
            text-indent: 0px !important;
            text-align: center;
            margin-top: 2px;
            font-weight: normal;
        }
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input[type=text]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            width: 100% !important;
        }
        .style1 input[type=checkbox]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            width: 15px !important;
            float: left !important;
        }
        .efficacious_send
        {
            width: 30%;
            background: #9fd727;
            font-size: 16px;
            border: none !important;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 2px;
            color: #fff;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center !important;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 2px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .style1 select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .chk
        {
            display: block;
            border: 1px solid #3498db;
            width: 10px;
            padding: 5px;
            float: left;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            width: 16px;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            outline: 0;
            float: left;
        }
        .efficacious input[type=checklist], input[type=radio]
        {
            display: block;
            width: 16px;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            outline: 0;
            float: left;
        }
        .inquiry-name
        {
            width: 180px;
            float: left;
            margin: 5px;
            padding: 7px;
        }
        .inquiry-field
        {
            width: 730px;
            float: left;
        }
        .efficacious input.efficacious_sends
        {
            width: 100px;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;            
            padding: 6px;
            cursor: pointer;
            height: 38px;
            float: left;
            text-align: center;
        }
    </style>
    <style>
        input[type="image"]
        {
            width: 70% !important;
        }
    </style>
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=grdTestSchedule.ClientID%>");
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
        function validation() {
            var txtCandidateName = document.getElementById("<%=txtCandidateName.ClientID %>").value;
            if (txtCandidateName == '') {
                alert('Please provide candidate name or enquiry no');
                return false;
            }
        }    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Registration Form
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">Registration Form</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px" Visible="false">
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Search</HeaderTemplate>
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Visible="false">
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <table class="efficacious">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="Enquiry No"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="btnYes" GroupName="grp" Text="Yes" runat="server" OnCheckedChanged="btnYes_CheckedChanged"
                                                        AutoPostBack="True" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="btnNo" GroupName="grp" Text="No" runat="server" AutoPostBack="True"
                                                        OnCheckedChanged="btnNo_CheckedChanged" />
                                                </td>
                                                <td align="center">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server" id="trSearch" visible="False">
                                    <td id="Td1" runat="server" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblCandidate" runat="server" Text="Candidate Name / Enquiry No"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtCandidateName" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btnSearch" OnClientClick="return validation();" runat="server" Width="30%" CssClass="efficacious_sends"
                                                        Text="Search" OnClick="BbtnSearch_Click" />
                                                </td>
                                                <td align="center">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-left: 3px; width: 50px;" colspan="4">
                                        <asp:GridView ID="grdTestSchedule" EmptyDataText="No Records Found" runat="server"
                                            AutoGenerateColumns="False" DataKeyNames="intInquiry_id" CssClass="table  tabular-table " Width="740px">
                                            <Columns>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("vchInquiry_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="chkCtrl" runat="server" onclick="RadioCheck(this);" Style="width: 10px;
                                                            left: 20px;" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vchInquiry_no" HeaderText="Enquiry no">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtInquiryDate" HeaderText="Enquiry Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchName" HeaderText="Candidate Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchFatherName" HeaderText="Father Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchFatherMobile" HeaderText="Father Mobile">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table runat="server" id="Table1">
                                            <tr id="Tr1" runat="server">
                                                <td id="Td2"  runat="server">
                                                    <asp:Button ID="Button2" runat="server" CssClass="efficacious_send" Text="Go" OnClick="Button2_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

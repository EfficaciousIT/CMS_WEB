<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="LoginDetails.aspx.cs" Inherits="LoginDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     var prm = Sys.WebForms.PageRequestManager.getInstance();
     //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
     prm.add_beginRequest(BeginRequestHandler);
     // Raised after an asynchronous postback is finished and control has been returned to the browser.
     prm.add_endRequest(EndRequestHandler);
     function BeginRequestHandler(sender, args) {
         //Shows the modal popup - the update progress
         var popup = $find('<%= modalPopup.ClientID %>');
         if (popup != null) {
             popup.show();
         }
     }

     function EndRequestHandler(sender, args) {
         //Hide the modal popup - the update progress
         var popup = $find('<%= modalPopup.ClientID %>');
         if (popup != null) {
             popup.hide();
         }
     }
    </script>
    <style>
    .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
     <style type="text/css">
        .style1
        {
            width: 100%;
            font-family: Verdana;
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
                border-radius: 0px;
                padding: 6px 0px;
                font-size: 13px;
                text-align: left;
                margin-top: 10px;
                margin-right: 106px;
            }

        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }

        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }

        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }

        .search
        {
            border: 1px solid #078DB9 !important;
            padding: 3px;
        }

        .efficacious_Submit
        {
            border: none;
            width: 130% !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
        }

        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }

        .td, th
        {
            padding: 0;
            padding-right: 300px;
        }
        .style1 input[type=text] {
            display: block;
            border: 1px solid #3498db;
            width: 70%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-header">
        <h1>
            Login Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Report</a></li>
            <li class="active">Login Details</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px" Visible="false">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>Top Scores</HeaderTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"
                                    Visible="False">
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <table class="style1">
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" style="padding-right: 30px;">
                                            <tr>                                                
                                                <td valign="middle" align="center" style="width:12%">
                                                        <asp:Label ID="lblRole" runat="server" Text="Role" CssClass="textsize" style="padding-left: 20px;"></asp:Label>
                                                    </td>
                                                     <td style="width:27%">
                                                        <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" Style="padding-right: 30px;"
                                                            CssClass="textsize" onselectedindexchanged="ddlRole_SelectedIndexChanged"  >
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td valign="middle" align="center" style="width:12%">
                                                        <asp:Label ID="lblStd" runat="server" Text="Standard" CssClass="textsize" style="padding-left: 20px;" Visible="false"></asp:Label>
                                                    </td>
                                                     <td style="width:27%">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" 
                                                             Style="padding-right: 30px;" Visible="false"
                                                            CssClass="textsize" onselectedindexchanged="ddlSTD_SelectedIndexChanged"  >
                                                        </asp:DropDownList>
                                                    </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:GridView ID="grd" runat="server" CssClass="table  tabular-table " EmptyDataText="No Login Details Yet"
                                                        Width="100%">
                                                    </asp:GridView>
                                        
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

 </asp:Content>


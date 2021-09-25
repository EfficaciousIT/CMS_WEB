<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmChanegePassword.aspx.cs" Inherits="frmChanegePassword" Title="Change Password" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
    </head>
    <div class="clearfix">
    </div>
<div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Setting <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li class="active1"> <a href="frmChanegePassword.aspx"> Change Password </a></li>
                  <li><a href="frmRoleWisePromotion.aspx"> Promotion</a></li>             
        </ul>
    </div>
<section class="content">
    <center>
        <table>
            <tr>
                <td align="left">
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                        CssClass="MyTabStyle">
                        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                            <HeaderTemplate>
                                Change Password
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="updv1" runat="server">
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table style="font-weight: bolder; width: 45%; padding-top: 10px; margin-top: 50px;" align="center">
                                                    <tr visible="false" runat="server">
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="False">User Name</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="selectf" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="Please Enter User Name"
                                                                ControlToValidate="TextBox1" Display="None" ValidationGroup="g1" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                                                runat="server" TargetControlID="RFV1" Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegEV1" runat="server" ControlToValidate="TextBox1"
                                                                ErrorMessage="Only alphabets are allowed" ValidationGroup="g1" ForeColor="Red"
                                                                ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True"
                                                                TargetControlID="RegEV1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" nowrap="nowrap" style="padding-bottom: 15px">
                                                            <asp:Label ID="lblvchno" runat="server" Font-Bold="False">Old Password</asp:Label>
                                                        </td>
                                                        <td style="padding-bottom: 15px">
                                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="selectf" ValidationGroup="b" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RegEV2" runat="server" ErrorMessage="Please Enter Old Password"
                                                                ControlToValidate="TextBox2" ValidationGroup="g1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RegEV2">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" nowrap="nowrap" style="padding-bottom: 15px">
                                                            <asp:Label ID="lblvchmake" runat="server" Font-Bold="False">New Password</asp:Label>
                                                        </td>
                                                        <td style="padding-bottom: 15px">
                                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="selectf" ValidationGroup="b" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="ReqFV3" runat="server" ErrorMessage="Please Enter New Password"
                                                                ControlToValidate="TextBox3" Display="None" ValidationGroup="g1" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="ReqFV3"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                     &nbsp;
                                                    </tr>
                                                    <tr>
                                                   
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="lblvchdrivername" runat="server" Text="Confirm Password" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td style="padding-bottom: 15px">
                                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="selectf" ValidationGroup="b" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="ReqFdV4" runat="server" ErrorMessage="Please Enter Confirm Password"
                                                                ControlToValidate="TextBox4" ValidationGroup="g1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="ReqFdV4"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="TextBox3"
                                                                ControlToValidate="TextBox4" ValidationGroup="g1" ErrorMessage="Your new password and confirm password do not match!"
                                                                Display="None" Font-Bold="False" />
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="comparePasswords"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        
                                                        <td>
                                                            <asp:Image ID="imgCaptcha" runat="server" />
                                                         
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtImg" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Label ID="lblCaptchaResult" runat="server" />
                                                       
                                                        </td>
                                                    </tr>
                                                    

                                                    <tr>
                                                        <td align="center" colspan="3" nowrap="nowrap" style="padding-left: 62px;">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width:100%; padding-left:105px;">

                                                                        
                                                                        <asp:Button ID="btnsubmit" runat="server" CssClass="efficacious_send" OnClick="change_pass" OnClientClick="return TopicValidation()" 
                                                                            Text="Submit" ValidationGroup="g1" />
                                                                    </td>
                                                                   
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </center>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
        </table>
    </center>
</section>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .efficacious input.efficacious_send
        {
            padding: 3px 10px !important;
            font-size: 13px !important;
        }
        .efficacious_send {
            width: 27% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function TopicValidation() {
            var TextBox3 = document.getElementById("<%=TextBox3.ClientID %>").value;
            var txt4 = document.getElementById("<%=TextBox4.ClientID %>").value;
            if (TextBox3.length <= 3) {
                alert('New password should be more then 3 charecter');
                return false;
            }

            if (txt4.length <= 3) {
                alert('Confirm password should be more then 3 charecter');
                return false;
            }

            return true;
        }
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="FrmAdmChanPass.aspx.cs" Inherits="FrmAdmChanPass" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
           <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="930px">
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            
                            Change Password</HeaderTemplate>
                        <ContentTemplate>
                            <center>
       <%-- <table width="50%">
        
            <tr>
                <td style="padding: 10 0 10px 0" colspan="2">
                    <asp:Label ID="lab1" runat="server" Text="Changed Password Page"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding: 10 0 10px 0">
                    <asp:Label ID="Label1" runat="server" Text="Enter Old Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" placeholder="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Enter New Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox>
                </td>
            </tr>
              <tr style="padding: 10 0 10px 0">
                <td style="padding: 10 0 10px 0">
                    <asp:Label ID="Label3" runat="server" Text="Re-Type New Password"></asp:Label>
                </td>
                <td style="padding: 10 0 10px 0">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="submit" runat="server" Text="Log in" OnClick="submit_Click" />
                </td>
            </tr>
        </table>--%>
        <table>
        <tr><td>
      <%--  <asp:ChangePassword ID="ch1" runat="server" BackColor="#F7F7DE" 
                BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" 
                DisplayUserName="True" Font-Names="Verdana" Font-Size="10pt" Height="223px" 
                onchangedpassword="ch1_ChangedPassword" Width="473px" 
                ConfirmNewPasswordLabelText="Confirm New Password" 
                NewPasswordLabelText="New Password" NewPasswordRegularExpressionErrorMessage="" 
                ondatabinding="Page_Load" PasswordLabelText="Password" 
                >
            <ChangePasswordButtonStyle Font-Size="XX-Small" />
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:ChangePassword>--%>


           <%-- <asp:ChangePassword ID="ChangePassword1" runat="server" 
        ContinueDestinationPageUrl="~/Users/UserProfile.aspx" style="margin-right: 2px" 
        Width="450px" EnableTheming="True">
        <ChangePasswordTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Change Your Password</td>
                            </tr>
                           
                            <tr>
                                <td align="left">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                        AssociatedControlID="CurrentPassword">Password</asp:Label>
                                </td>
                                <td style="width: 166px">
                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                        ControlToValidate="CurrentPassword" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="NewPasswordLabel" runat="server" 
                                        AssociatedControlID="NewPassword">New Password</asp:Label>
                                </td>
                                <td style="width: 166px">
                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                        ControlToValidate="NewPassword" ErrorMessage="New Password is required." 
                                        ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmNewPassword">Confirm New Password</asp:Label>
                                </td>
                                <td style="width: 166px">
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmNewPassword" 
                                        ErrorMessage="Confirm New Password is required." 
                                        ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                        ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                        Display="Dynamic" 
                                        ErrorMessage="The Confirm New Password must match the New Password entry." 
                                        ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                        CommandName="ChangePassword" Text="Change Password" 
                                        ValidationGroup="ChangePassword1" />
                                </td>
                                <td style="width: 166px">
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
    </asp:ChangePassword>--%>
    
    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F7DE" 
                BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="Verdana" Font-Size="10pt" 
                onchangedpassword="ChangePassword1_ChangedPassword" 
            
                ChangePasswordFailureText="Password incorrect or New Password invalid. New Password length minimum: {2}. Non-alphanumeric characters required: {0}." 
                ConfirmNewPasswordLabelText="Confirm New Password" EnableTheming="True" 
                Height="235px" NewPasswordLabelText="New Password" PasswordLabelText="Password" 
                UserNameLabelText="User Name" Visible="False" Width="482px">
    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF"/>
  
</asp:ChangePassword>
 
        </td></tr>
        
        </table>

    </center>
                            </ContentTemplate>
                        </asp:TabPanel>
               </asp:TabContainer>
        </center>
</asp:Content>

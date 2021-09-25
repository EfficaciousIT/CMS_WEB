<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmInquiryReception.aspx.cs" Inherits="frmInquiryReception" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Enquiry <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li class="active1"> <a> Enquiry</a></li>                  
        </ul>
    </div>
<section class="content">
  <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                     <tr>
                                    <td align="left" valign="top">
                                        <div class="tabular">
                                            <table width="100%">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                       
                                                    </td>
                                                    <td align="left" style="padding-right: 0px" valign="middle">

                                                    </td>
                                                    <td align="right" valign="middle">
                                                        <asp:Label ID="lblDIV" runat="server" Text="Status" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" width="10%" valign="middle">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                                                            CssClass="textsize" onselectedindexchanged="ddlStatus_SelectedIndexChanged"
                                                           >
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td>
                                                  
                                                    </td>
                                                    <td align="center" valign="middle">
                                                       
                                                    </td>
                                                    <td align="left" valign="bottom" CssClass="efficacious_send">
                                                    
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                        <tr>
                       
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" CssClass="efficacious" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>

                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" 
                                                                DataKeyNames="intInquiryReception_Id" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing" >
                                                                <Columns>
                                                                   <asp:BoundField DataField="vchName" HeaderText="Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchEmail" HeaderText="Email" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchMobile" HeaderText="Mobile" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchDescription" HeaderText="Description" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intStatus_Id" HeaderText="Status" ReadOnly="True"/> 
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" style="  width: 22% !important; outline:0;" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" style="  width: 22% !important; outline:0;" CommandName="Delete" CausesValidation="false"
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
                                            <table width="50%"  style="text-align: right; margin:0 auto;">
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        &nbsp;
                                                    </td>
                                                    <td align="justify">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                
                                                 <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label5" runat="server" Text="Name"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtName" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="50" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="txtName"
                                                            Display="None" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                                            runat="server" Enabled="True" TargetControlID="R1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label3" runat="server" Text="E-Mail"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtMail" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="50" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="txtMail"
                                                            Display="None" ErrorMessage="Please Enter E-Mail"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                            runat="server" Enabled="True" TargetControlID="R2">
                                                        </asp:ValidatorCalloutExtender>
                                                         <asp:RegularExpressionValidator ID="EmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="txtMail" Display="None" ValidationGroup="a" ErrorMessage="Invalid Email Format" Font-Bold="False"></asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender
                                                        ID="VCE1" runat="server" Enabled="True" TargetControlID="EmailValid">
                                                    </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                        <asp:TextBox ID="txtMobile" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="10" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R4" runat="server" ControlToValidate="txtMobile"
                                                            Display="None" ErrorMessage="Please Enter Mobile"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="R4_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="R4">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                  <asp:TextBox ID="txtAddress" runat="server" AutoComplete="Off" CssClass="input-blue" 
                                                            MaxLength="250" Width="201px" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RQFD1" runat="server" ControlToValidate="txtAddress"
                                                            Display="None" ErrorMessage="Please Enter Address"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                            runat="server" Enabled="True" TargetControlID="RQFD1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label8" runat="server" Text="Description"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtDescription" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="250" Width="201px"></asp:TextBox>                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpStatus" runat="server" AutoPostBack="True">                                                             
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                    </td>
                                                    <td align="left">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClientClick="return ConfirmInsertUpdate();"
                                                            Text="Submit" onclick="btnSubmit_Click" />
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                                            Text="Clear" Visible="False" />
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
</section>
</asp:Content>


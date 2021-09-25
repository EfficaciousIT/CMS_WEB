<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmDriverDetails.aspx.cs" Inherits="frmDriverDetails"
    Title="E-SMARTs" Culture="es-MX" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 80px;
        }
        .style2
        {
            width: 230px;
        }
    </style>
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Driver Entry
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Transporter</a></li>
            <li class="active">Driver Entry</li>
        </ol>
    </div>
    <div style="padding: 05px 0 0 0">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
            CssClass="MyTabStyle">
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Driver Details
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="efficacious">
                        <center>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" EmptyDataText="No Records Found" DataKeyNames="intDriver_id"
                                            runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table " Width="100%" OnRowDeleting="GridView1_RowDeleting"
                                            OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchTransporter_name" HeaderText="Transporter Name" 
                                                    ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="intMobile_no" HeaderText="Mobile" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchLicence_no" HeaderText="Licence No" 
                                                    ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtLicenceIssue_Date" HeaderText="Issue Date" 
                                                    ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtLicenceExpire_Date" HeaderText="Expire Date" 
                                                    ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="intDriver_id" runat="server" Text='  <%# Eval("intDriver_id")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CommandName="Edit" ID="lnkBtn" runat="server">
                                                            <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CommandName="Delete" ID="lnkBtn1" runat="server">
                                                            <asp:Image ID="Img1" runat="server" ImageUrl="~/images/delete.png" /></asp:LinkButton></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    New Entry
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="efficacious">
                        <center>
                            <table style="width: 379px; margin: 10px 0;" align="center">
                                <tr height="35">
                                    <td align="left" width="230">
                                        <asp:Label ID="lblvchno" runat="server">Driver First Name<font id="eid" color="#CC0000">*</font> </asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtDriverFName" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" ForeColor="Black" Width="200px" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req15" runat="server" ControlToValidate="txtDriverFName"
                                            ErrorMessage="Enter Driver First Name" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="Req15"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegEV1" runat="server" ControlToValidate="txtDriverFName"
                                            ValidationGroup="a" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                            ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RegEV1">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lblvchmake" runat="server">Driver Middle Name</asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtDriverMName" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lblvchdrivername" runat="server">Driver Last Name  <font id="Font1" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtDriverLName" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req17" runat="server" ControlToValidate="txtDriverLName"
                                            ErrorMessage="Enter Driver Last Name" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="Req17"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegEV2" ValidationGroup="a" runat="server" ControlToValidate="txtDriverLName"
                                            ErrorMessage="Only alphabets are allowed" ForeColor="Red" ValidationExpression="[a-zA-Z]+"
                                            Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RegEV2">
                                            </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno" runat="server" Text="Transporter Name"></asp:Label>
                                    </td>
                                    <td align="left" class="style2" nowrap="nowrap">
                                        <asp:DropDownList ID="DrpContractorname" runat="server" Font-Names="Verdana" Font-Size="Small"
                                            Width="200px" ForeColor="Black" MaxLength="50" ValidationGroup="b" CssClass="textsize">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno0" runat="server" Text="Telephone No"></asp:Label>
                                    </td>
                                    <td align="left" style="float: left;">
                                        <asp:TextBox ID="txtTelNo" runat="server" Font-Names="Verdana" MaxLength="10" Font-Size="Small"
                                            Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtTelNo"
                                            FilterType="Custom, Numbers" ValidChars="-" 
                                            Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno1" runat="server">Mobile No<font id="Font4" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtMobileNo" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" CssClass="input-blue"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req19" runat="server" ControlToValidate="txtMobileNo"
                                            ErrorMessage="Enter Mobile no" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="Req19"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegEV4" runat="server" ControlToValidate="txtMobileNo"
                                            Display="None" ErrorMessage="Enter Valid Mobile no" ValidationGroup="a" Font-Bold="False"
                                            ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True"
                                            TargetControlID="RegEV4">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno2" runat="server">Licence No<font id="Font9" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" style="float: left;">
                                        <asp:TextBox ID="txtLicenceNo" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req20" runat="server" ControlToValidate="txtLicenceNo"
                                            ErrorMessage="Enter Licence no" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="Req20"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno3" runat="server">Date of Issue<font id="Font3" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtIssueDate" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtIssueDate"
                                            runat="server" Enabled="True">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="Req21" runat="server" ControlToValidate="txtIssueDate"
                                            ErrorMessage="Enter Issue Date" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="Req21"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left" nowrap="nowrap">
                                        <asp:Label ID="lbldrivermobno4" runat="server">Date of Expire<font id="Font5" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtExpireDate" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtExpireDate"
                                            runat="server" Enabled="True">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="Req22" runat="server" ControlToValidate="txtExpireDate"
                                            ErrorMessage="Enter Expire Date" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="Req22"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:CompareValidator ID="ComV1" runat="server" ValidationGroup="a" Operator="GreaterThanEqual"
                                            Type="Date" Display="None" ControlToValidate="txtExpireDate" ControlToCompare="txtIssueDate"
                                            ErrorMessage="Expire Date Greater then Issue date"></asp:CompareValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="ComV1"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno5" runat="server">Job Status<font id="Font8" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" class="style2" style="float: left;">
                                        <asp:DropDownList ID="DrpJobStatus" runat="server" Font-Names="Verdana" Font-Size="Small"
                                            Width="200px" ForeColor="Black" MaxLength="50" ValidationGroup="b" CssClass="textsize">
                                            <asp:ListItem Value="Select" Selected="True">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Parment">Parment</asp:ListItem>
                                            <asp:ListItem Value="Temporary">Temporary</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Req25" runat="server" InitialValue="Select" ControlToValidate="DrpJobStatus"
                                            ErrorMessage="Enter Job Status" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="Req25"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno6" runat="server">From Date<font id="Font6" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtContFromDate" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" TargetControlID="txtContFromDate"
                                            runat="server" Enabled="True">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="Req23" runat="server" ControlToValidate="txtContFromDate"
                                            ErrorMessage="Enter From Date" ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="Req23"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr height="35">
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno7" runat="server">To Date<font id="Font7" color="#CC0000">*</font></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" style="float: left;">
                                        <asp:TextBox ID="txtComtToDate" runat="server" Font-Names="Verdana" MaxLength="20"
                                            Font-Size="Small" Width="200px" ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" TargetControlID="txtComtToDate"
                                            runat="server" Enabled="True">
                                        </asp:CalendarExtender>
                                        <asp:CompareValidator ID="CoVa1" runat="server" Operator="GreaterThanEqual" ValidationGroup="a"
                                            Display="None" Type="Date" ControlToValidate="txtComtToDate" ControlToCompare="txtContFromDate"
                                            ErrorMessage="Expire Date Greater then Issue date"></asp:CompareValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="CoVa1"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RequiredFieldValidator ID="Req24" ValidationGroup="a" runat="server" ControlToValidate="txtComtToDate"
                                            ErrorMessage="Enter To Date" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="Req24"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td align="left" colspan="2">
                                        <table style="width: 100%">
                                            <tr id="visi1" runat="server">
                                                <td width="40%" runat="server">
                                                </td>
                                                <td runat="server" width="30%">
                                                    <asp:Button CssClass="efficacious_send" Width="70%" ID="Button1" runat="server" Text="Submit"
                                                        OnClick="Button1_Click" />
                                                </td>
                                                <td runat="server" width="30%">
                                                    <asp:Button ID="Button2" CssClass="efficacious_send" runat="server" Text="Clear"
                                                        OnClick="Button2_Click" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr id="visi2" runat="server">
                                                <td runat="server" width="40%">
                                                </td>
                                                <td class="style1" runat="server" width="30%">
                                                    <asp:Button ID="Button3" runat="server" CssClass="efficacious_send" Text="Update"
                                                        OnClick="Button3_Click" />
                                                </td>
                                                <td runat="server" width="30%">
                                                    <asp:Button ID="Button4" runat="server" Text="Clear" CssClass="efficacious_send"
                                                        OnClick="Button4_Click" Visible="False" />
                                                </td>
                                            </tr>
                                            <tr id="Tr1" runat="server">
                                                <td id="Td1" runat="server">
                                                </td>
                                                <td id="Td2" class="style1" runat="server">
                                                    &nbsp;</td>
                                                <td id="Td3" runat="server">
                                                    <asp:TextBox ID="hidden1" runat="server" CssClass="textsize" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
</asp:Content>

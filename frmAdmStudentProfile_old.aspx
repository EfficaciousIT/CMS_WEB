<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmStudentProfile.aspx.cs" Inherits="frmAdmStudentProfile" Title="Student Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>

/* default layout */
.ajax__tab_default .ajax__tab_header {
	white-space: normal !important
}
.ajax__tab_default .ajax__tab_outer {
	display: -moz-inline-box;
	display: inline-block
}
.ajax__tab_default .ajax__tab_inner {
	display: -moz-inline-box;
	display: inline-block
}
.ajax__tab_default .ajax__tab_tab {
	overflow: hidden;
	text-align: center;
	display: -moz-inline-box;
	display: inline-block
}
/* xp theme */
.ajax__tab_xp .ajax__tab_header {
	font-family: Verdana;
	font-size: 11px;
	background:#fff;
}
.textcss{ font-size:13px !important;}
.ajax__tab_xp .ajax__tab_outer {
	  padding-right: 4px;
  background: #fff;
  height: 21px;
  font-size: 12px;
  padding: 4px 0;
  border: 1px solid #D5D5D5; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_inner {
	padding-left: 3px;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_tab {
	height: 13px;
	padding: 4px;
	margin: 0px;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_hover .ajax__tab_outer {
	cursor: pointer;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_hover .ajax__tab_inner {
	cursor: pointer;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_hover .ajax__tab_tab {
	cursor: pointer;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_outer {
  background: #fff;
  border-right: 1px solid green;
  border-left: 1px solid green;
  border-top: 1px solid green;
  padding: 5px 0; border-radius:5px 5px 0 0; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_inner {
	background:#fff;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_tab {
	background:#fff; color:Green; font-size:12px; font-weight:bold;
}
.ajax__tab_xp .ajax__tab_disabled {
	color: #A0A0A0;
}
.ajax__tab_xp .ajax__tab_body {
	font-family: Verdana;
	font-size: 10pt;
	border: 1px solid #999999;
	
	padding: 8px;
	background-color: #ffffff;
}
/* scrolling */
.ajax__scroll_horiz {
	overflow-x: scroll;
}
.ajax__scroll_vert {
	overflow-y: scroll;
}
.ajax__scroll_both {
	overflow: scroll
}
.ajax__scroll_auto {
	overflow: auto
}
/* plain theme */
.ajax__tab_plain .ajax__tab_outer {
	text-align: center;
	vertical-align: middle;
	border: 2px solid #999999;
}
.ajax__tab_plain .ajax__tab_inner {
	text-align: center;
	vertical-align: middle;
}
.ajax__tab_plain .ajax__tab_body {
	text-align: center;
	vertical-align: middle;
}
.ajax__tab_plain .ajax__tab_header {
	text-align: center;
	vertical-align: middle;
}
.ajax__tab_plain .ajax__tab_active .ajax__tab_outer {
	background: #FFF;
}
.efficacious_send {
  border: none;
  width: 15% !important;
  background: #3498db;
  border: 1px solid #00000;
  font-size: 12px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
  color: #fff;
  margin: 10px auto;
  padding: 3px;
  cursor: pointer;
  height: 30px;
  float: right; position:relative; left:-88px;
  text-align: center;
}
.textcss{ font-size:13px !important}
.btn{
  border: none;
  width: 110px !important;
  background: #3498db;
  border: 1px solid #00000;
  font-size: 12px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
  color: #fff;
  margin: 10px 2px;
  padding: 3px;
  cursor: pointer;
  height: 30px;
  float: left; 
  text-align: center;
}
.efffield{
  display: block;
  border: 1px solid #3498db;
  width: 100%;
  padding: 5px 5px 5px 10px;
  font-family: Verdana;
  outline: none;
  font-size: 13px;
  text-align: left;
  outline: none; border-radius:5px; margin-bottom:5px; -webkit-border-radius:5px; -moz-border-radius:5px;
}

</style>
    <div style="padding:5px 0 0 0">
      <asp:UpdatePanel ID="updv1" runat="server">
        <ContentTemplate>
    <table>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                    Width="1015px">
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Academic Details</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                            <table>
                                <tr>
                                        <td align="left">
                    <fieldset style="width: 725px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Academic Details</legend>
                            <center>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label26" runat="server" CssClass="textcss" Font-Bold="False" Text="Standard" style="font-size:13px;"></asp:Label>
                                    <font size="1px" color="red">*</font></td>
                                <td align="left" width="240" nowrap="nowrap">
                                   
                                            <asp:DropDownList ID="DropDownList2" Width="155px" style="padding:5px; border:1px solid #3498db; border-radius:5px; -webkit-border-radius:5px; -moz-border-radius:5px;" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="textcss">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0" ErrorMessage="Please select Standerd"
                                                CssClass="textcss" ControlToValidate="DropDownList2" ValidationGroup="g1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10"
                                                runat="server" TargetControlID="RequiredFieldValidator15" Enabled="True">
                                            </asp:ValidatorCalloutExtender>

                                           
                                        
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label27" runat="server" CssClass="textcss" Font-Bold="False" Text="Division Id" style="font-size:13px;"></asp:Label>
                                    <font size="1px" color="red">*</font></td>
                                <td align="left" width="240" nowrap="nowrap">
                                  
                                            <asp:DropDownList ID="DropDownList3" runat="server"  AutoPostBack="True" Width="155px" style="padding:5px; border:1px solid #3498db; border-radius:5px; -webkit-border-radius:5px; -moz-border-radius:5px;"
                                                OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CssClass="textcss">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="Please select Division"
                                                CssClass="textcss" ControlToValidate="DropDownList3" ValidationGroup="g1" InitialValue="0" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11"
                                                runat="server" TargetControlID="RegularExpressionValidator19" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="240" nowrap="nowrap">
                                    <asp:Label ID="Label28" runat="server" CssClass="textcss" Font-Bold="False" Text="Roll No" style="font-size:13px;"></asp:Label>
                                    <font size="1px" color="red">*</font></td>
                                <td align="left"  width="240" nowrap="nowrap">
                                    
                                        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="checkroll"   width="143px" style="padding:5px; border:1px solid #3498db; border-radius:5px; -webkit-border-radius:5px; -moz-border-radius:5px;" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                    ValidationGroup="b" CssClass="textcss"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Req10" runat="server" ErrorMessage="Please Enter Roll No"
                                                CssClass="textcss" ControlToValidate="TextBox1" ValidationGroup="g1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12"
                                                runat="server" TargetControlID="Req10" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator id="RegExpr1"
                   ControlToValidate="TextBox1"
                   ValidationExpression="\d+"
                   Display="None"
                   ErrorMessage="Please enter numbers only"
                   ValidationGroup="g1" runat="server" CssClass="textcss" Font-Bold="False"/>
                                     <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender31"
                                                runat="server" TargetControlID="RegExpr1" Enabled="True">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:Label ID="Label4" runat="server" width="140px" CssClass="textcss" Font-Bold="False" 
                                                ForeColor="#FF3300"></asp:Label>
                                    
                                     
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button runat="server" CssClass="efficacious_send" Text="Next"
                                        ID="ButN7" OnClick="checknextval7" ValidationGroup="g1"></asp:Button>
                                </td>
                            </tr>
                        </table>
                        </center>
                    </fieldset>
                </td></tr></table>
                </center>
                            
                            </ContentTemplate>
                        </asp:TabPanel>
             
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Personal Details</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table>
                                <tr>
                                        <td align="left">
                                          
                                <fieldset style="width: 725px;">
                                    <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                                        Personal Details</legend>
                                      <center>
                                    <table style="font-weight: bolder; width: 80%; margin: 10px auto;" align="center">
                                        <tr>
                                            <td rowspan="6">
                                                <asp:Image ID="imgViewFile" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                            </td>
                                            <td align="left" width="180" nowrap="nowrap">
                                                <asp:Label ID="lblvchno" runat="server" CssClass="textcss" Font-Bold="False">First Name</asp:Label>
                                                <font size="1px" color="red">*</font>
                                            </td>
                                            <td align="left" width="180"  nowrap="nowrap">
                                                <asp:TextBox ID="txt1" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                    ValidationGroup="b" CssClass="efffield"></asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ValidationGroup="p1" ErrorMessage="Please Enter First Name"
                                                        CssClass="textcss" ControlToValidate="txt1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender
                                                            ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" TargetControlID="RequiredFieldValidator1"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="RegEV1" ValidationGroup="p1" runat="server"
                                                    ControlToValidate="txt1" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+" CssClass="textcss" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RegEV1">
                                                    </asp:ValidatorCalloutExtender>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblvchmake" runat="server" CssClass="textcss" Font-Bold="False">Middle Name</asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt2" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                    ValidationGroup="b" CssClass="efffield"></asp:TextBox>
                                               
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ValidationGroup="p1" runat="server"
                                                    ControlToValidate="txt2" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+" CssClass="efffield" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator12">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" CssClass="textcss"
                                                    Font-Bold="False"></asp:Label>
                                                <font size="1px" color="red">*</font></td>
                                            <td align="left" class="style29" nowrap="nowrap">
                                                <asp:TextBox ID="txt3" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="textcss"
                                                    ErrorMessage="Please Enter Last Name" ValidationGroup="p1" ControlToValidate="txt3" Display="None"
                                                    Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                        runat="server" TargetControlID="RequiredFieldValidator3" Enabled="True">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt3"
                                                    ErrorMessage="Only alphabets are allowed" ValidationGroup="p1" ForeColor="Red" ValidationExpression="[a-zA-Z]+"
                                                    CssClass="textcss" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender23" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lbldrivermobno" runat="server" CssClass="textcss" Font-Bold="False"
                                                    Text="Father Name"></asp:Label>
                                               <font size="1px" color="red">*</font></td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt4" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt4"
                                                    CssClass="textcss" Display="None" ValidationGroup="p1" ErrorMessage="Please Enter Father Name" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                    ControlToValidate="txt4" CssClass="textcss" ValidationGroup="p1" ErrorMessage="Only alphabets are allowed"
                                                    ForeColor="Red" ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender22" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator13">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblmother" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Name"></asp:Label>
                                                <font size="1px" color="red">*</font></td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:TextBox ID="txt5" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt5"
                                                    CssClass="textcss" Display="None" ValidationGroup="p1" ErrorMessage="Please Enter Mother Name" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RequiredFieldValidator1_ValidatorCalloutExtender0" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator5">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                    ControlToValidate="txt5" ErrorMessage="Only alphabets are allowed" ValidationGroup="p1" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+" CssClass="textcss" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender21" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator14">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Gender" runat="server" CssClass="textcss" Font-Bold="False" Text="Email ID"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt6" runat="server" CssClass="efffield"  Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regexEmailValid" CssClass="efffield"  runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="txt6" Display="None"  ErrorMessage="Invalid Email Format" Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style27">
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblbob" runat="server" CssClass="textcss" Font-Bold="False" Text="Date of Birth"></asp:Label>
                                                <font size="1px" color="red">*</font></td>
                                            <td align="left" nowrap="nowrap">
                                            
                                                <asp:TextBox ID="txt7" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ReadOnly="True"></asp:TextBox>
                                                    <asp:CalendarExtender
                                                        ID="CalendarExtender1" runat="server" TargetControlID="txt7" Enabled="True">
                                                    </asp:CalendarExtender>
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt7"
                                                    CssClass="textcss" Display="None" ErrorMessage="Please Enter Dob" ValidationGroup="p1" Font-Bold="False"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator12">
                                                    </asp:ValidatorCalloutExtender>
                                                &nbsp;&nbsp;
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                    ControlToCompare="date1" ControlToValidate="txt7"
                                                    CssClass="textcss"  Display="None" Type="Date" ErrorMessage="age must be greater then 2 year"
                                                    Font-Bold="False" Operator="LessThan" ValidationGroup="p1" 
                                                    ></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender60"
                                                        runat="server" Enabled="True" TargetControlID="CompareValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                                                       </td>
                                        </tr>
                                        <tr>
                                            <td >
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblpalceofbirth" runat="server" CssClass="textcss" Font-Bold="False"
                                                    Text="Place of Birth"></asp:Label>
                                                <font size="1px" color="red">*</font></td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:TextBox ID="txt8" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b" OnTextChanged="txt8_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt8"
                                                    CssClass="textcss" Display="None" ValidationGroup="p1" ErrorMessage="Please Enter Place Of Birth"
                                                    Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender2"
                                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server"
                                                    ControlToValidate="txt8" CssClass="textcss" ValidationGroup="p1" ErrorMessage="Only alphabets are allowed"
                                                    ForeColor="Red" ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender65" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator43">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td >
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblpalceofbirth0" style=" position: relative; top: -8px;" runat="server" CssClass="textcss" 
                                                    Font-Bold="False" Text="Cast"></asp:Label>
                                                <font color="red" style=" position: relative; top: -8px;" size="1px">*</font></td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt9" runat="server" CssClass="efffield" Font-Names="Verdana" 
                                                    ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                    ControlToValidate="txt9" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Please Enter Cast" Font-Bold="False" ValidationGroup="p1"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender3" 
                                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                                                    ControlToValidate="txt9" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red" 
                                                    ValidationExpression="[a-zA-Z]+" ValidationGroup="p1"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" 
                                                    Enabled="True" TargetControlID="RegularExpressionValidator9">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblpalceofbirth1" style=" position: relative; top: -8px;" runat="server" CssClass="textcss" 
                                                    Font-Bold="False" Text="Sub Cast"></asp:Label>
                                              
                                            </td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:TextBox ID="txt10" runat="server" CssClass="efffield" Font-Names="Verdana" 
                                                    ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                                    runat="server" ControlToValidate="txt10" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red" 
                                                    ValidationExpression="[a-zA-Z]+" ></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" 
                                                    Enabled="True" TargetControlID="RegularExpressionValidator10">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td >
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                              
                                                <asp:Label ID="Label52" runat="server" style=" position: relative; top: -8px;" CssClass="textcss" 
                                                    Font-Bold="False" Text="Gender"></asp:Label>
                                                <font color="red" style=" position: relative; top: -8px;" size="1px">*</font></td>
                                            <td align="left"  nowrap="nowrap">
                                                
                                                        <asp:DropDownList ID="txt11" runat="server" CssClass="efffield" style="width:107% !important;"
                                                            Font-Names="Verdana" ForeColor="Black" 
                                                            OnSelectedIndexChanged="DroplistAtten_SelectedIndexChanged" ValidationGroup="p1" 
                                                            Width="155px">
                                                            <asp:ListItem Selected="True" Value="Select">---Select---</asp:ListItem>
                                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txt11" CssClass="textcss" Display="None" 
                                                            ErrorMessage="Please Select Gender " Font-Bold="False" InitialValue="Select" 
                                                            ValidationGroup="p1"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                                            Enabled="True" TargetControlID="RequiredFieldValidator2">
                                                        </asp:ValidatorCalloutExtender>
                                                    
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td >
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblpalceofbirth5" runat="server" CssClass="textcss" 
                                                    Font-Bold="False" style=" position: relative; top: -8px;" Text="Home Telephone 1"></asp:Label>
                                                <font color="red"style=" position: relative; top: -8px;" size="1px">*</font></td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:TextBox ID="txt12" runat="server" CssClass="efffield" Font-Names="Verdana" 
                                                    ForeColor="Black" MaxLength="10" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                    ControlToValidate="txt12" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Please Enter Telephone no " Font-Bold="False" 
                                                     ValidationGroup="p1"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" 
                                                    Enabled="True" TargetControlID="RequiredFieldValidator9">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator29" 
                                                    runat="server" ControlToValidate="txt12" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Enter valid Phone number" Font-Bold="False" 
                                                    ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" 
                                                    ValidationGroup="p1"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" 
                                                    Enabled="True" TargetControlID="RegularExpressionValidator29">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td >
                                            </td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:Label ID="lblpalceofbirth2" style=" position: relative; top: -8px;" runat="server" CssClass="textcss" 
                                                    Font-Bold="False" Text="Father Mobile No"></asp:Label>
                                                <font color="red" style=" position: relative; top: -8px;" size="1px">*</font></td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:TextBox ID="txt13" runat="server" CssClass="efffield" Font-Names="Verdana" 
                                                    ForeColor="Black" MaxLength="10" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                    ControlToValidate="txt13" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Please Enter Father Mobile No" Font-Bold="False" 
                                                    ValidationGroup="p1"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender5" 
                                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" 
                                                    runat="server" CssClass="textcss" ControlToValidate="txt13" Display="None" 
                                                    ErrorMessage="Enter Valid Mobile no" Font-Bold="False" 
                                                    ValidationExpression="[0-9]{10}" ValidationGroup="p1"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" 
                                                    Enabled="True" TargetControlID="RegularExpressionValidator23">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td >
                                            </td>
                                            <td align="left" nowrap="nowrap" >
                                                <asp:Label ID="lblpalceofbirth3" style=" position: relative; top: -8px;" runat="server" CssClass="textcss" 
                                                    Font-Bold="False" Text="Mother Mobile No"></asp:Label>
                                                &nbsp;&nbsp;</td>
                                            <td align="left"  nowrap="nowrap">
                                                <asp:TextBox ID="txt14" runat="server" CssClass="efffield" Font-Names="Verdana" 
                                                    ForeColor="Black" MaxLength="10" ></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                                    runat="server" CssClass="textcss" ControlToValidate="txt14" Display="None" 
                                                    ErrorMessage="Enter Valid Mobile no" Font-Bold="False" 
                                                    ValidationExpression="[0-9]{10}" ></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" 
                                                    Enabled="True" TargetControlID="RegularExpressionValidator11">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr valign="bottom">
                                            <td class="style26">
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="lblpalceofbirth4" runat="server" style="position:relative; top:-43px" CssClass="textcss" 
                                                    Font-Bold="False" Text="Present Address"></asp:Label>
                                                <font color="red" style="position:relative; top:-43px" size="1px">*</font>
                                            </td>
                                            <td align="left" class="style30" nowrap="nowrap">
                                                <asp:TextBox ID="txt15" runat="server" CssClass="efffield" Font-Names="Verdana" 
                                                    ForeColor="Black" Height="50px" MaxLength="20" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                    ControlToValidate="txt15" CssClass="textcss" Display="None" 
                                                    ErrorMessage="Please Enter Address" Font-Bold="False" ValidationGroup="p1"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                                    Enabled="True" TargetControlID="RequiredFieldValidator10">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style32">
                                            </td>
                                            <td class="style33" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            
                                            <td ID="img" runat="server" align="left" colspan="2">
                                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" 
                                                    UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                    
                                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="efffield" style="width:50%;  position: relative;
  right: -12px; float:right;" />
                                                        &nbsp;<br />
                                                        <br />
                                                        <asp:Button ID="Button1" runat="server" CssClass="btn" style=" float:right; position: relative;
  left: 124px;"
                                                            OnClick="Button1_Click" OnClientClick="if (!validatePage()) {return true;}" 
                                                            Text="Upload File" />
                                                   
                                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="Button1" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                
                                                        <asp:TextBox ID="date1" runat="server" hidden="true" ></asp:TextBox>
                                                        <br />
                                                     
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                        
                                               
                                                 
                                            </td>
                                            <td></td>
                                            <td align="right" colspan="2">
                                             <asp:Button ID="ButP2" runat="server" CssClass="btn" 
                                                    OnClick="checkPrivious2" OnClientClick="if (!validatePage()) {return true;}" 
                                                    Text="Back" />
                                                <asp:Button ID="ButN2" runat="server" CssClass="btn" 
                                                    OnClick="checknextval2" Text="Next" ValidationGroup="p1" />
                                            </td>
                                        </tr>
                                      
                                    </table>
                                 </center>
                                          </fieldset>
                                               
                                            </td>
                                    </tr>
                                    </table>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Address Details</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                 <table>
                                <tr>
                                        <td align="left">
                                <fieldset style="width: 725px;">
                                    <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                                        Address Details</legend>
                                    <center>
                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                                        <tr>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:Label ID="Label1" runat="server" CssClass="textcss" Font-Bold="False">Present Address</asp:Label>
                                                <font size="1px" color="red">*</font>
                                            </td>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:TextBox ID="txt34" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                    Width="134px" Height="40px" CssClass="efffield"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ValidationGroup="a1" runat="server" CssClass="textcss"
                                                    ErrorMessage="Please Enter Present Address" ControlToValidate="txt34" Display="None"
                                                    Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6"
                                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator27">
                                                    </asp:ValidatorCalloutExtender>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label3" runat="server" CssClass="textcss" Font-Bold="False">Permanent Address</asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt35" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    Height="47px" MaxLength="20"  Width="134px"></asp:TextBox>
                                                &nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server"
                                                    ControlToValidate="txt35" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+"  CssClass="textcss" Font-Bold="False" Display="None"></asp:RegularExpressionValidator>&nbsp;&nbsp;
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender50" runat="server" Enabled="True"
                                                    TargetControlID="RegularExpressionValidator37">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                         
                                                <asp:Button runat="server" CssClass="btn" OnClientClick="if (!validatePage()) {return true;}" Text="Back"
                                                    ID="ButP3" OnClick="checkPrivious3"></asp:Button>
                                                
                                            </td>
                                            <td align="right">

                                                <asp:Button runat="server" CssClass="btn" ValidationGroup="a1" Text="Next"
                                                    ID="ButN3" OnClick="checknevl3"></asp:Button>
                                         
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                        </fieldset>
                                            </td>
                                    </tr>
                                     </table>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    
                    <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                        <HeaderTemplate>
                            Contact Details</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table>
                                <tr>
                                        <td align="left">
                                <fieldset style="width: 725px;">
                                    <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                                        Contact Details</legend>
                                    <center>
                                    <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                                        <tr>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:Label ID="Label2" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False">Home Telephone 1</asp:Label>
                                           <font size="1px" style=" position: relative; top: -8px;" color="red">*</font>
                                            </td>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:TextBox ID="txt36" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="c1"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="c1" runat="server" ControlToValidate="txt36"
                                                    CssClass="textcss" Display="None" ErrorMessage="Please Enter Telephone No" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender51" runat="server"  Enabled="True" TargetControlID="RequiredFieldValidator6">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server"
                                                    ControlToValidate="txt36" CssClass="textcss" Display="None" ValidationGroup="c1" ErrorMessage="Enter valid TelPhone number"
                                                    Font-Bold="False" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender52" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator38">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label5" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False">Home Telephone 2</asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt37" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                                
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator39" runat="server"
                                                    ControlToValidate="txt37" CssClass="textcss" ValidationGroup="c1" Display="None" ErrorMessage="Enter valid TelPhone number"
                                                    Font-Bold="False" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender57" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator39">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label6" runat="server" Text="Emergency Contact Person 1"  style=" position: relative; top: -8px;" CssClass="textcss"
                                                    Font-Bold="False"></asp:Label>
                                                    <font size="1px" style=" position: relative; top: -8px;" color="red">*</font>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt38" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt38"
                                                    CssClass="textcss" ValidationGroup="c1" ErrorMessage="Only alphabets are allowed" Font-Bold="False"
                                                    Display="None" ForeColor="Red" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender16" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" CssClass="textcss"
                                                    ErrorMessage="Please Enter Emergency contact persone Name" ValidationGroup="c1" ControlToValidate="txt38"
                                                    Display="None" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="RequiredFieldValidator1_ValidatorCalloutExtender20" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator29">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label7" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Emergency Contact Number 1"></asp:Label>
                                            <font size="1px" style=" position: relative; top: -8px;" color="red">*</font>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt39" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txt39"
                                                    CssClass="textcss" Display="None" ValidationGroup="c1" ErrorMessage="Please Enter Contact Number"
                                                    Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender59"
                                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator39">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                    ControlToValidate="txt39" ErrorMessage="Enter Valid Mobile no" ValidationExpression="[0-9]{10}"
                                                    Display="None" CssClass="textcss" ValidationGroup="c1" Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator27">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label8" runat="server" style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Emergency Contact Person 2"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt40" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt38"
                                                    CssClass="textcss" ValidationGroup="c1" ErrorMessage="Only alphabets are allowed" Font-Bold="False"
                                                    Display="None" ForeColor="Red" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender17" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label9" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Emergency Contact Number 2"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt41" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server"
                                                    ControlToValidate="txt41" Display="None" ValidationGroup="c1" ErrorMessage="Enter Valid Mobile no"
                                                    ValidationExpression="[0-9]{10}" CssClass="textcss" Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender14" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator28">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label10" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Neighbour Name"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt42" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt42"
                                                    CssClass="textcss" ErrorMessage="Only alphabets are allowed" Font-Bold="False"
                                                    Display="None" ForeColor="Red" ValidationGroup="c1" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender35" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator6">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label11" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Neighbour Number"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt43" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server"
                                                    ControlToValidate="txt43" ErrorMessage="Enter Valid Neighbour Mobile  no" ValidationExpression="[0-9]{10}"
                                                    Display="None" CssClass="textcss" ValidationGroup="c1" Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender58" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator40">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                              
                                                        <asp:Button ID="ButP4" runat="server" CssClass="btn" 
                                                            OnClick="checkPrivious4" OnClientClick="if (!validatePage()) {return true;}" 
                                                            Text="Back" Width="46px" />
                                                
                                            </td>
                                            <td align="right">
                                               
                                                        <asp:Button ID="ButN4" runat="server" CssClass="btn" OnClick="checknextval4" Text="Next" 
                                                            ValidationGroup="c1" />
                                                   
                                            </td>
                                        </tr>
                                      
                                    </table>
                               </center>
                                         </fieldset>
                                            </td>
                                    </tr>
                                    </table>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                   
                       <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel6">
                        <HeaderTemplate>
                            Other</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table><tr><td align="left">
                                <fieldset style="width: 725px;" >
                                    <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                                        Others Details</legend>
                                    <center>
                                    <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                                        <tr>
                                            <td align="left" nowrap="nowrap" class="auto-style1">
                                                <asp:Label ID="Label16" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False">Cast</asp:Label>
                                            </td>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:TextBox ID="txt46" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                    CssClass="efffield" OnTextChanged="txt46_TextChanged"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt46"
                                                    CssClass="textcss" ErrorMessage="Only alphabets are allowed" Font-Bold="False"
                                                    ForeColor="Red" ValidationExpression="[a-zA-Z]+" Display="None" ValidationGroup="Goa1"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender36" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator7">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap" class="auto-style1">
                                                <asp:Label ID="Label18" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False">Sub Cast</asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt47" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                                    CssClass="efffield"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                    ControlToValidate="txt47" CssClass="textcss" ErrorMessage="Only alphabets are allowed"
                                                    Font-Bold="False" ForeColor="Red" ValidationExpression="[a-zA-Z]+" ValidationGroup="Goa1"  Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender41" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator21">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap" class="auto-style1">
                                                <asp:Label ID="Label19" runat="server" Text="Passport No" CssClass="textcss" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt48" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                                     CssClass="efffield"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator251" runat="server"
                                                    ControlToValidate="txt48" CssClass="textcss"  ErrorMessage="Only alphabets are allowed"
                                                    Font-Bold="False" ForeColor="Red" ValidationGroup="Goa1" ValidationExpression="[[A-Z][0-9][0-9] [0-9][0-9][0-9][0-9][0-9]]"
                                                    Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender42"
                                                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator251">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap" class="auto-style1">
                                                <asp:Label ID="Label20" runat="server" CssClass="textcss"  style=" position: relative; top: -8px;" Font-Bold="False" Text="Date of Issue"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt49" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ReadOnly="True" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt49"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                &nbsp;&nbsp;
                                                
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap" class="auto-style1">
                                                <asp:Label ID="Label21" runat="server" CssClass="textcss"  style=" position: relative; top: -8px;" Font-Bold="False" Text="Date of Expire"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap">
                                                <asp:TextBox ID="txt50" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ReadOnly="True" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt50"
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                                &nbsp;&nbsp;
                                                <asp:CompareValidator ID="CoeVal2" runat="server" 
                                                    ControlToCompare="txt49" ControlToValidate="txt50"
                                                    CssClass="textcss"  Display="None" Type="Date" ErrorMessage="Date Of Issue greater then Date of Expiry"
                                                    Font-Bold="False" Operator="GreaterThan" ValidationGroup="Goa1" 
                                                    ></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender34"
                                                        runat="server" Enabled="True" TargetControlID="CoeVal2">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style2" nowrap="nowrap">
                                                <asp:Label ID="Label22" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Mother Tounge"></asp:Label>
                                                <font size="1px" style=" position: relative; top: -8px;" color="red">*</font>
                                            </td>
                                            <td align="left" class="style20" nowrap="nowrap">
                                                <asp:TextBox ID="txt51" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txt51"
                                                    CssClass="textcss" ValidationGroup="Goa1" ErrorMessage="Please Enter Mother Tounge" Display="None"  Font-Bold="False"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender
                                                        ID="RequiredF25" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator34">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txt51"
                                                    CssClass="textcss" ErrorMessage="Only alphabets are allowed" ValidationGroup="Goa1" Display="None" Font-Bold="False"
                                                    ForeColor="Red" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender37" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator8">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style2" nowrap="nowrap">
                                                <asp:Label ID="Label13" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Pan Card No"></asp:Label>
                                                <font size="1px" style=" position: relative; top: -8px;" color="red">*</font>
                                            </td>
                                            <td align="left" class="style20" nowrap="nowrap">
                                                <asp:TextBox ID="txt54" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt54"
                                                    CssClass="textcss" ValidationGroup="Goa1" ErrorMessage="Please Enter Mother Tounge" Display="None"  Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender27" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator13">
                                                    </asp:ValidatorCalloutExtender>
                                             <asp:RegularExpressionValidator ID="Reor1" runat="server" ValidationGroup="Goa1" ControlToValidate="txt54"  
                     ForeColor="Red" ErrorMessage="InValid PAN Card" Display="None" ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}" Font-Bold="False"></asp:RegularExpressionValidator> 
                                                  <asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender28" runat="server" Enabled="True"
                                                        TargetControlID="Reor1">
                                                    </asp:ValidatorCalloutExtender>
                                                 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style2" nowrap="nowrap">
                                                <asp:Label ID="Label17" runat="server"  style=" position: relative; top: -8px;" CssClass="textcss" Font-Bold="False" Text="Aadhar Card"></asp:Label>
                                                <font size="1px" style=" position: relative; top: -8px;" color="red">*</font>
                                            </td>
                                            <td align="left" class="style20" nowrap="nowrap">
                                                <asp:TextBox ID="txt55" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt55"
                                                    CssClass="textcss" ValidationGroup="Goa1" ErrorMessage="Please Enter Mother Tounge" Display="None"  Font-Bold="False"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender29" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator34">
                                                    </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt55"
                                                    CssClass="textcss" ValidationGroup="Goa1" ErrorMessage="Only alphabets are allowed" Display="None" Font-Bold="False"
                                                    ForeColor="Red" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender30" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator8">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                       
                                     
                                           <tr>
                                            <td align="left" class="auto-style1">
                                     
                                                <asp:Button ID="ButP8" CssClass="btn" runat="server" OnClick="checkPrivious8" OnClientClick="if (!validatePage()) {return true;}"
                                                    Text="Back" />
                                               
                                                  
                                            </td>
                                            <td align="right">
                                           
                                                <asp:Button ID="ButN8" CssClass="btn" runat="server" 
                                                    OnClick="checknextval8" ValidationGroup="Goa1" Text="Next"></asp:Button>
                                                    
                                            </td>
                                        </tr>
                                    </table>
                              </center>
                                         </fieldset>
                                    </td></tr></table>
                        </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                   
                    <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
            <HeaderTemplate>
                Alerts Details

            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <table><tr><td align="left">
                    <fieldset style="width: 725px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                              Alerts Details</legend>
                        <center>
                        <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left"  nowrap="nowrap" height="17px" width="230">
                                    <asp:Label ID="Label103" runat="server" CssClass="textcss" Font-Bold="False">Bus Alert Number1</asp:Label>
                                    <font size="1px" color="red">*</font>
                                </td>
                                <td align="left" nowrap="nowrap">
                                     <asp:TextBox ID="txt52" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequireFiVlt13" runat="server" ControlToValidate="txt52"
                                                    CssClass="textcss" ErrorMessage="Please Enter Bus Alert Number1" ValidationGroup="b" Display="None"  Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                                        TargetControlID="RequireFiVlt13">
                                                    </asp:ValidatorCalloutExtender>

                                                <asp:RegularExpressionValidator ID="ReguExdator1" 
                                                    runat="server" CssClass="textcss" ControlToValidate="txt52" Display="None" 
                                                    ErrorMessage="Enter Valid Mobile no" Font-Bold="False" 
                                                    ValidationExpression="[0-9]{10}" ValidationGroup="b"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="server" 
                                                    Enabled="True" TargetControlID="ReguExdator1">
                                                </asp:ValidatorCalloutExtender>
                                               
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px" class="style27">
                                    <asp:Label ID="Label105" runat="server" CssClass="textcss" Font-Bold="False">Bus Alert Number2</asp:Label>
                                <font size="1px" color="red">*</font>
                                </td>
                                <td align="left">
                                    
                                    <asp:TextBox ID="txt53" runat="server" CssClass="efffield" Font-Names="Verdana" ForeColor="Black"
                                                    MaxLength="20" ></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="ReqidFdVlr14" runat="server" ControlToValidate="txt53"
                                                    CssClass="textcss" ErrorMessage="Please Enter Bus Alert Number2" Display="None" ValidationGroup="b"  Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender26" runat="server" Enabled="True"
                                                        TargetControlID="ReqidFdVlr14">
                                                    </asp:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RexpVator1" 
                                                    runat="server" CssClass="textcss" ControlToValidate="txt53" Display="None" 
                                                    ErrorMessage="Enter Valid Mobile no" Font-Bold="False" 
                                                    ValidationExpression="[0-9]{10}" ValidationGroup="b"></asp:RegularExpressionValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" runat="server" 
                                                    Enabled="True" TargetControlID="RexpVator1">
                                                </asp:ValidatorCalloutExtender>
                                               
                                </td>
                            </tr>
                                   <tr>
                                            <td align="left">
                                            
                                                <asp:Button ID="ButP5" CssClass="btn" runat="server" OnClick="checkPrivious5" OnClientClick="if (!validatePage()) {return true;}"
                                                    Text="Back" />
                                                 
                                            </td>
                                            <td align="right">
                                            
                                                <asp:Button ID="ButN5" CssClass="btn" runat="server" ValidationGroup="b" 
                                                    OnClick="checknextval5" Text="Next"></asp:Button>
                                                  
                                            </td>
                                        </tr>
                          
                        </table>
                            </center>
                    </fieldset>
                </td></tr></table>
                        </center>
                </ContentTemplate>
                        </asp:TabPanel>
         
 
                   
                   <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                        <HeaderTemplate>
                            Health status</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table>
                                <tr>
                                        <td align="left">
                                           
                                <fieldset style="width: 725px;">
                                    <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                                        Health Details</legend>
                                     <center>
                                    <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                                        <tr>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:Label ID="Label12" runat="server" CssClass="textcss" Font-Bold="False">Blood Group</asp:Label>
                                                <font size="1px" color="red">*</font>
                                            </td>
                                            <td align="left" width="230" nowrap="nowrap">
                                                <asp:TextBox ID="txt44" runat="server" Font-Names="Verdana" MaxLength="10" ForeColor="Black"
                                                     CssClass="efffield"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator31" runat="server" CssClass="textcss" ErrorMessage="Please Enter Blood Group"
                                                        ControlToValidate="txt44" Display="None" ValidationGroup="h1"  Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                            ID="RequiredFieldValidator1_ValidatorCalloutExtender22" runat="server" Enabled="True"
                                                            TargetControlID="RequiredFieldValidator31">
                                                        </asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server"
                                                    ControlToValidate="txt44" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+" ValidationGroup="h1" CssClass="textcss" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender63" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator41">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap"  width="230">
                                                <asp:Label ID="Label14" runat="server" CssClass="textcss" Font-Bold="False">Any Health Disability</asp:Label>
                                                <font size="1px" color="red">*</font>
                                            </td>
                                            <td align="left" nowrap="nowrap"  width="230">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="efffield" Width="160px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" CssClass="textcss"
                                                    ErrorMessage="Please Enter Health Disability" ValidationGroup="h1" InitialValue="0" ControlToValidate="DropDownList1"
                                                    Display="None" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="Req1_Ver23" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator32">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" nowrap="nowrap">
                                                <asp:Label ID="Label15" runat="server" Text="Description" CssClass="textcss" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txt45" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                    ValidationGroup="b" CssClass="efffield"></asp:TextBox>&nbsp;&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server"
                                                    ControlToValidate="txt45" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z]+" CssClass="textcss" Font-Bold="False" ValidationGroup="h1" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender64" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator42">
                                                    </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-top:20px">
                                       
                                                <asp:Button ID="ButP6" CssClass="btn" runat="server" OnClick="checkPrivious6" OnClientClick="if (!validatePage()) {return true;}"
                                                    Text="Back" />
                                                    
                                            </td>
                                            <td align="left" style="padding-top:20px">
                                                <asp:Button ID="ButN6" CssClass="btn" runat="server" ValidationGroup="h1"
                                                    OnClick="submit" Text="Submit"></asp:Button>
                                                 <asp:Button ID="Update" CssClass="textcss" runat="server" 
                                                    OnClick="Update1" Text="Update"></asp:Button>
                                                <asp:Label ID="idv1" runat="server" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                  
                                        </table>
                                           </center>
                                </fieldset>
                          
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
      </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style6
        {
            font-family: Verdana;
            font-size: 10px;
            text-align: left;
            height: 22px;
        }
        .style20
        {
            height: 22px;
        }
        .style21
        {
            width: 124px;
            height: 22px;
        }
        .style22
        {
            height: 26px;
        }
        .style23
        {
            width: 124px;
            height: 26px;
        }
        .style26
        {
            width: 75px;
        }
        .style27
        {
            width: 75px;
            height: 22px;
        }
        .style28
        {
            height: 46px;
        }
        .style29
        {
            width: 124px;
        }
        .style30
        {
            width: 124px;
            margin-right: 0px;
            font-family: Verdana;
            font-size: 10px;
        }
        .style31
        {
            width: 124px;
            margin-right: 0px;
            font-family: Verdana;
            font-size: 10px;
            height: 22px;
        }
        .style32
        {
            width: 75px;
            height: 16px;
        }
        .style33
        {
            height: 16px;
        }
        .style34
        {
            width: 75px;
            height: 24px;
        }
        .style35
        {
            height: 24px;
        }
        .style36
        {
            width: 124px;
            margin-right: 0px;
            font-family: Verdana;
            font-size: 10px;
            height: 24px;
        }
        .style37
        {
            width: 75px;
            height: 23px;
        }
        .style38
        {
            height: 23px;
        }
        .style39
        {
            width: 124px;
            margin-right: 0px;
            font-family: Verdana;
            font-size: 10px;
            height: 23px;
        }
        .auto-style1 {
            width: 230px;
        }
        .auto-style2 {
            height: 22px;
            width: 230px;
        }
    </style>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" Culture="en-Gb"
    CodeFile="frmLiStudentProfile.aspx.cs" Inherits="frmLiStudentProfile" Title="Student Profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
    <title></title>
     <link href="styles/styles.css" rel="stylesheet" type="text/css" />
     <link href="sty/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 24px;
        }
        .style2
        {
            height: 22px;
        }
        .style3
        {
            height: 39px;
        }
        .style7
        {
            width: 96px;
        }
        .style8
        {
            width: 230px;
        }
        .auto-style4 {
            height: 17px;
        }
        .auto-style5 {
            width: 156px;
        }
        .auto-style6 {
            height: 17px;
            width: 156px;
        }
        
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
.ajax__tab_xp .ajax__tab_outer {
	  padding-right: 4px;
  background: #fff  !important;
  height: 21px;
  font-size: 12px;
  padding: 4px 0;
  border: 1px solid #D5D5D5; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_inner {
	padding-left: 3px;
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_tab {
	height: 13px;
	padding: 4px;
	margin: 0px;
	background:#fff !important;
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
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_outer {
  background: #fff;
  border-right: 1px solid green;
  border-left: 1px solid green;
  border-top: 1px solid green;
  padding: 5px 0; border-radius:5px 5px 0 0; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_inner {
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_tab {
	background:#fff !important; color:Green; font-size:12px; font-weight:bold;
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
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
 
    <div style="padding:05px 0 0 0">
    <asp:UpdatePanel ID="up2" runat="server">
        <ContentTemplate>
                
<table>
    <tr><td><asp:Label ID="Label109" runat="server" ></asp:Label></td></tr>
    <tr><td align="left">
     <table width="100%">
     <tr><td class="style22" align="center">
     <br/>
         <asp:Label ID="Labnorecord" runat="server" 
             CssClass="textcss" Font-Bold="False" ForeColor="#CC0000" Font-Size="Small"></asp:Label></td></tr>
     <tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="6"
        Width="930px">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Personal Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px; padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; padding:0 0 0 0">
                            Student Personal Details</legend>
                        <table style="font-weight: bolder; width: 90%; margin: 10px 0;" align="center">
                            <tr>
                            <td rowspan="6" class="auto-style5">
                                <asp:Image id="fileImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image"/>&nbsp;&nbsp;
                               </td>
                                <td align="left"  nowrap="nowrap" width="250px">
                                    <asp:Label ID="lblvchno" runat="server" CssClass="textcss" Font-Bold="False">First Name</asp:Label>
                                </td>
                                <td align="left" width="250px" >
                                    <asp:Label ID="lblvn" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px">
                                    <asp:Label ID="lblvchmake" runat="server" CssClass="textcss" Font-Bold="False">Middle Name</asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label17" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" >
                                    <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" CssClass="textcss"
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                   <asp:Label ID="Label23" runat="server" CssClass="textcss" 
                                            Font-Bold="False" ></asp:Label>
                              </td>
                                <tr>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lbldrivermobno" runat="server" CssClass="textcss" 
                                            Font-Bold="False" Text="Father Name"></asp:Label>
                                        <td align="left" class="style26">
                                            
                                            <asp:Label ID="Label24" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" >
                                        <asp:Label ID="lblmother" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Mother Name"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label25" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                  <tr>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="Label56" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Standard"></asp:Label>
                                    </td>
                                    <td align="left"  nowrap="nowrap">
                                        
                                        <asp:Label ID="Label75" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                  <tr>
                                  <td class="auto-style6"></td>
                                    <td align="left" nowrap="nowrap" class="auto-style4">
                                        <asp:Label ID="Label77" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Division"></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap" class="auto-style4">
                                        
                                        <asp:Label ID="Label79" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                  <tr>
                                  <td class="auto-style5"></td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="Label83" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Roll No"></asp:Label>
                                    </td>
                                    <td align="left"  nowrap="nowrap">
                                        
                                        <asp:Label ID="Label85" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                  <tr>
                                  <td class="auto-style5"></td>
                                    <td align="left"nowrap="nowrap" height="17px">
                                        <asp:Label ID="Label87" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Class Teacher"></asp:Label>
                                    </td>
                                    <td align="left"  nowrap="nowrap">
                                        
                                        <asp:Label ID="Label89" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td class="auto-style5"></td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="Gender" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Email Id"></asp:Label>
                                    </td>
                                    <td align="left"  nowrap="nowrap">
                                        
                                        <asp:Label ID="Label26" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5" >
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lblbob" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Date Of Birth"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label27" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5" >
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lblpalceofbirth" runat="server" CssClass="textcss" 
                                            Font-Bold="False" Text="Place Of Birth"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label28" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style5" >
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lblpalceofbirth0" runat="server" CssClass="textcss" 
                                            Font-Bold="False" Text="Cast"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label29" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style5">
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lblpalceofbirth1" runat="server" CssClass="textcss" 
                                            Font-Bold="False" Text="Sub Cast"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <asp:Label ID="Label30" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style5" >
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px" >
                                        <asp:Label ID="Label52" runat="server" Font-Bold="False" Text="Gender" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label53" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style5">
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lblpalceofbirth5" runat="server" CssClass="textcss" 
                                            Font-Bold="False" Text="Home Telephone 1"></asp:Label>
                                        &nbsp;&nbsp;</td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label31" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style5" >
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px" >
                                        <asp:Label ID="lblpalceofbirth2" class="textcss" runat="server" Font-Bold="False" 
                                            Text="Father Mobile No"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label32" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td nowrap="nowrap" class="auto-style5" >
                                    </td>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="lblpalceofbirth3" class="textcss" runat="server" Font-Bold="False" 
                                            Text="Mother Mobile No"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label33" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style5">
                                        <td align="left" nowrap="nowrap" >
                                            <asp:Label ID="lblpalceofbirth4" runat="server" CssClass="textcss" 
                                                Font-Bold="False" Text="Present Address"></asp:Label>
                                        </td>
                                        <td align="left"  nowrap="nowrap">
                                            
                                            <asp:Label ID="Label34" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                            <br />
                                        </td>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel6">
            <HeaderTemplate>
                Parents Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px; padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; padding:0 0 0 0">
                            Parents Details</legend>
                        <table style="font-weight: bolder; width: 90%; margin: 10px 0;" align="center">
                            
                            <tr>
                                <td colspan="3" align="center" nowrap="nowrap" height="17px">
                                    <asp:Label ID="Label54" runat="server" CssClass="textheadcss" 
                                        Font-Bold="True">Father Details</asp:Label></td>
                            </tr>
                            
                            <tr><td colspan="3" nowrap="nowrap" height="17px"></td></tr|>
                              <tr>
                                  <td rowspan="6">
                                      &nbsp;&nbsp;
                                      <asp:Image id="fileImg2" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                  <td nowrap="nowrap" width="250px" >
                                      <asp:Label ID="Label57" runat="server" CssClass="textcss" Font-Bold="False">Name</asp:Label>
                                  </td>
                                  <td width="250px">
                                      <asp:Label ID="Label58" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                  </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap">
                                    <asp:Label ID="Label59" runat="server" CssClass="textcss" Font-Bold="False">Mobile No</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label60" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label61" runat="server" CssClass="textcss" Font-Bold="False">Email Id</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label62" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label63" runat="server" CssClass="textcss" Font-Bold="False">Father Company Name</asp:Label>
                                </td>
                                <td class="style18">
                                    <asp:Label ID="Label64" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label65" runat="server" CssClass="textcss" Font-Bold="False">Father Designation</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label66" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label67" runat="server" CssClass="textcss" Font-Bold="False">Telephone No (Office)</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label68" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="3" nowrap="nowrap" >
                                </td>
                                </tr|>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="Label55" runat="server" CssClass="textheadcss" Font-Bold="True">Mother Details</asp:Label>
                                </td>
                            </tr>

                                <tr>
                                <td colspan="3">
                                </td>
                                </tr>
                            
                            <tr>
                                <td rowspan="6" class="style8">
                                    &nbsp;&nbsp;
                                    <asp:Image id="fileImg3" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label69" runat="server" CssClass="textcss" Font-Bold="False">Name</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label70" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label93" runat="server" CssClass="textcss" Font-Bold="False">Mobile No</asp:Label>
                                </td>
                                <td class="style18">
                                    <asp:Label ID="Label72" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label73" runat="server" CssClass="textcss" Font-Bold="False">Email Id</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label74" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label97" runat="server" CssClass="textcss" Font-Bold="False">Mother Company Name</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label76" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label98" runat="server" CssClass="textcss" Font-Bold="False">Mother Designation</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label78" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" height="17px" class="style29">
                                    <asp:Label ID="Label99" runat="server" CssClass="textcss" Font-Bold="False">Telephone No (Office)</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label80" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="17px">
                                </td>
                            </tr>
                           
                            </tr>
                            <tr>
                                <td align="center" colspan="3" nowrap="nowrap" height="17px">
                                    <asp:Label ID="Label71" runat="server" CssClass="textheadcss" Font-Bold="True">Guardian Details</asp:Label>
                                </td>
                            </tr>
              
                            <tr>
                                <td colspan="3" >
                                </td>
                                </tr|>
                            </tr>
                            
                                    <tr>
                                        <td rowspan="6" >
                                            &nbsp;&nbsp;
                                           <asp:Image id="fileImg4" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                                
                                                </td>
                                        <td nowrap="nowrap" height="17px" class="style29">
                                            <asp:Label ID="Label81" runat="server" CssClass="textcss" Font-Bold="False">Name</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label82" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" height="17px" class="style29">
                                            <asp:Label ID="Label94" runat="server" CssClass="textcss" Font-Bold="False">Mobile No</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label84" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" height="17px" class="style29">
                                            <asp:Label ID="Label96" runat="server" CssClass="textcss" Font-Bold="False">Email Id</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label86" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" height="17px" class="style29">
                                            <asp:Label ID="Label100" runat="server" CssClass="textcss" Font-Bold="False">Guardian Company Name</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label88" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" height="17px" class="style29">
                                            <asp:Label ID="Label101" runat="server" CssClass="textcss" Font-Bold="False">Guardian Designation</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label90" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" height="17px" class="style29">
                                            <asp:Label ID="Label102" runat="server" CssClass="textcss" Font-Bold="False">Telephone No (Office)</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label92" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Address Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px;padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;padding:0 0 0 0">
                            Student Address Details</legend>
                        <table style="font-weight: bolder; width: 90%; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" nowrap="nowrap" width="250px">
                                    <asp:Label ID="Label1" runat="server" CssClass="textcss" Font-Bold="False">Present Address</asp:Label>
                                </td>
                                <td align="left" nowrap="nowrap" width="250px">
                                    
                                        <asp:Label ID="Label35" runat="server" 
                                        CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px" class="style27">
                                    <asp:Label ID="Label3" runat="server" CssClass="textcss" Font-Bold="False">Permanent Address</asp:Label>
                                </td>
                                <td align="left" nowrap="nowrap" height="17px">
                                    <asp:Label ID="Label36" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
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
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Contact Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px;padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;padding:0 0 0 0">
                            Contact Details</legend>
                        <table style="font-weight: bolder; width: 90%; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" nowrap="nowrap" width="250">
                                    <asp:Label ID="Label2" runat="server" CssClass="textcss" Font-Bold="False">Home Telephone 1</asp:Label>
                                </td>
                                <td align="left" width="250">
                                        <asp:Label ID="Label4" runat="server" 
                                        CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" width="250">
                                    <asp:Label ID="Label5" runat="server" CssClass="textcss" Font-Bold="False">Home Telephone 2</asp:Label>
                                </td>
                                <td align="left" width="250">
                                     <asp:Label ID="Label37" runat="server" CssClass="textcss" 
                                        Font-Bold="False"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td align="left"nowrap="nowrap" width="250">
                                    <asp:Label ID="Label6" runat="server" Text="Emergency Contact Person 1" 
                                        CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="250">
                                   <asp:Label ID="Label38" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="Label7" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Emergency Contact Number 1"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="Label39" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="Label8" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Emergency Contact Person 2"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="Label40" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="Label9" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Emergency Contact Number 2"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="Label41" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="Label10" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Neighbour Name"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="Label42" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="Label11" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Neighbour Number"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="Label43" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="LabelDr1" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Doctor Name"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="LabelDrName" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="LabelDr2" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Doctor Number"></asp:Label>
                                    </td>
                                    <td align="left" width="250">
                                        
                                        <asp:Label ID="LabelDrNu" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left"  width="250">
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Health Status</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px;padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;padding:0 0 0 0">
                            Health Details</legend>
                        <table style="font-weight: bolder; width: 90%; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" nowrap="nowrap" width="250">
                                    <asp:Label ID="Label12" runat="server" CssClass="textcss" Font-Bold="False">Blood Group</asp:Label>
                                </td>
                                <td align="left" nowrap="nowrap" width="250">
                                        <asp:Label ID="Label13" runat="server" CssClass="textcss" 
                                        Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px" class="style27">
                                    <asp:Label ID="Label14" runat="server" CssClass="textcss" Font-Bold="False">Any Health Disability</asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label44" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px" class="style27">
                                    <asp:Label ID="Label15" runat="server" Text="Description" CssClass="textcss" 
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label45" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Other</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px;padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Others Details</legend>
                        <table style="font-weight: bolder; width: 90%; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left"  nowrap="nowrap" width="250px">
                                    <asp:Label ID="Label16" runat="server" CssClass="textcss" Font-Bold="False">Cast</asp:Label>
                                </td>
                                <td align="left" nowrap="nowrap"  width="250px">
                                    
                                    <asp:Label ID="Label46" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap"  width="250px">
                                    <asp:Label ID="Label18" runat="server" CssClass="textcss" Font-Bold="False">Sub Cast</asp:Label>
                                </td>
                                <td align="left"  width="250px">
                                    
                                    <asp:Label ID="Label47" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px">
                                    <asp:Label ID="Label19" runat="server" Text="Passport No" CssClass="textcss" 
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label48" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left" nowrap="nowrap" height="17px" class="style27">
                                        <asp:Label ID="Label20" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Date of Issue"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label49" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" height="17px">
                                        <asp:Label ID="Label21" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Date of Expire"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label50" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap="nowrap" height="17px" class="style27">
                                        <asp:Label ID="Label22" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Mother Tounge"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label51" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left" nowrap="nowrap" height="17px" class="style27">
                                        <asp:Label ID="Label91" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Aadhar Card No"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label95" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left" nowrap="nowrap" height="17px" class="style27">
                                        <asp:Label ID="Label107" runat="server" CssClass="textcss" Font-Bold="False" 
                                            Text="Pan Card"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label108" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                            </tr>
                          
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
           <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Alerts Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 500px;padding:0 0 0 5px">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                              Alerts Details</legend>
                        <table style="font-weight: bolder;width: 90%; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left"  nowrap="nowrap" width="250px">
                                    <asp:Label ID="Label103" runat="server" CssClass="textcss" Font-Bold="False">Bus Alert Number1</asp:Label>
                                </td>
                                <td align="left" nowrap="nowrap" hwidth="250px">
                                    
                                    <asp:Label ID="Label104" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" height="17px" class="style27">
                                    <asp:Label ID="Label105" runat="server" CssClass="textcss" Font-Bold="False">Bus Alert Number2</asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label106" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                          
                          
                        </table>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </td></tr></table>
        </td>
        </tr>
    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        </form>
    </body>
    </html>


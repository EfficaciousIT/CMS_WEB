<%@ Page Title="FrmCard" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmCard.aspx.cs" Inherits="frmCard" Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
.efficacious input, form.winner-inside textarea{ width:94% !important}
 .mGrid th {
         text-align: center !important;
            }
</style>
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
  border-right: 1px solid #3498db;
  border-left: 1px solid #3498db;
  border-top: 1px solid #3498db;
  padding: 5px 0; border-radius:5px 5px 0 0; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_inner {
	background:#fff;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_tab {
	background:#fff; color:3498db; font-size:12px; font-weight:bold;
}
.ajax__tab_xp .ajax__tab_disabled {
	color: #A0A0A0;
}
.ajax__tab_xp .ajax__tab_body {
	font-family: Verdana;
	font-size: 10pt;
	border: 1px solid #999999; padding:0 !important;
	
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
    <table runat="server" width="100%"> 
    <tr>
    <td align="left">
    
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="1015px" class="MyTabStyle" >
    
        <asp:TabPanel ID="TabPanelIdcard" runat="server" HeaderText="TabPanelIdcard" visibility="false">
            <HeaderTemplate>
                Identity Card</HeaderTemplate>
            <ContentTemplate>
                
              <div class="efficacious">             
                    <table  runat="server" style="height:100px;width:550px;border:solid" align="center">                        
                        <tr class="noBorder" runat="server" >
                            <td align="left" rowspan="2" runat="server"  >
                                <img src="images/school-pic.png" style="width: 85px; height: 70px;" />
                            </td>
                            </tr>
                        <tr runat="server">
                            <td colspan="2" nowrap="nowrap" runat="server" align="center">
                                <span style="width: 147px" >Okavango School</span>
                                </td>
                            </tr>
                        <tr runat="server">
                            <td runat="server"></td>
                            <td colspan="2" runat="server" nowrap="nowrap" align="left">
                                <span style="font-variant: normal; font-size: xx-small">(G-Square
                                    Business Park,1402,14th Floor,Plot No.25,26,Sec-30,<br />Opp Sanpada Station,Navi Mumbai-400703,Maharashtra)
                                </span>
                            </td>
                        </tr>
                        <tr runat="server" >
                            <td rowspan="6" align="center" runat="server"  valign=top>
                                <asp:Image id="fileImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                <br>
                                <span style="font-size: 9px" ><asp:Label ID="Label11" runat="server"  ></asp:Label></span>
                            </td>
                        </tr>
                        <tr runat="server" id="studname" class="noBorder">
                            <td id="Td1" runat="server" nowrap="nowrap">
                                <asp:Label ID="lblvchno0" runat="server">Student Name</asp:Label>
                            </td>
                            <td id="Td2" runat="server">
                                <asp:TextBox ID="txtvchmake1" runat="server" Font-Names="Verdana" ForeColor="Black"
                                    MaxLength="20" ValidationGroup="b" OnTextChanged="txtvchmake1_TextChanged" BorderStyle="None"
                                     ></asp:TextBox>
                            </td>
                        </tr>
                        
                       
                        <tr id="classid" runat="server" class="noBorder">
                            <td id="Td3" runat="server" nowrap="nowrap">
                                <asp:Label ID="lblvchno2" runat="server">Std/Div</asp:Label>
                            </td>
                            <td id="Td4" runat="server">
                                <asp:TextBox ID="TextBox8" runat="server" Font-Names="Verdana" ForeColor="Black"
                                    MaxLength="20" ValidationGroup="b"   OnTextChanged="txtvchmake1_TextChanged"
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr class="noBorder" runat="server">
                            <td id="Td5" runat="server"  nowrap="nowrap">
                                <asp:Label ID="lblvchno3" runat="server">Contact No.</asp:Label>
                            </td>
                            <td id="Td6" runat="server" >
                                <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana"  
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" OnTextChanged="txtvchmake1_TextChanged"
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server"><td colspan="2" runat="server"></td></tr>
                        <tr class="noBorder" runat="server">
                            <td align="right" colspan="2" runat="server">
                                <asp:Label ID="Label25" runat="server"   Font-Size="10px">Signature Here</asp:Label>
                             
                                <asp:Label ID="Label26" runat="server" BorderStyle="None"   Font-Size="10px">Principal</asp:Label>
                            </td>
                        </tr>
                        <tr class="noBorder" runat="server">
                            <td align="center" colspan="2" nowrap="nowrap" runat="server">
                                <span style="font-size: 9px"></span>
                            </td>
                        </tr>
                    </table>
                  
               </div>
                   </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanelcarddisplay" runat="server" HeaderText="TabPanelcarddisplay">
            <HeaderTemplate>
                Card Details Display</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                
                    <tr>
                        <td style="padding: 10px 0 20px 0;" align="center">
                            <asp:GridView ID="GridView2" runat="server" designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Cardid"
                                EmptyDataText="Record not Found." Width="100%" Font-Bold="False" HorizontalAlign="Center">
                                <Columns>   
                                    <asp:BoundField DataField="cardid" HeaderText="Card ID" />
                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                    <asp:BoundField DataField="DateofIssue" HeaderText="Issue" />
                                    <asp:BoundField DataField="DateofActivation" HeaderText="Activation" />
                                    <asp:BoundField DataField="DateofExpire" HeaderText="Expire" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        
        
        <asp:TabPanel ID="TabPaneltempcardt" runat="server" HeaderText="TabPaneltempcardt">
            <HeaderTemplate>
                Temporary Issued</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
            <table width="100%">
            
            <tr runat="server"><td runat="server">
                <table style="font-weight: bolder; width: 100%; margin: 10px 0;">
                    
                        <tr runat="server">
                            <td align="center" style="padding: 10px 0 20px 0;" runat="server">
                                <asp:GridView ID="GridViewTempDis" runat="server" __designer:wfdid="w36" 
                                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                    CssClass="mGrid" DataKeyNames="cardid" EmptyDataText="Record not Found." 
                                    HorizontalAlign="Center" Width="100%" EnableModelValidation="True">
                                    <Columns>
                                        
                                        
                                        <asp:BoundField DataField="Tempcardno" HeaderText="Card No" />
                                       
                                        <asp:BoundField DataField="DateofIssue" HeaderText="Issue" />
                                        <asp:BoundField DataField="DateofActivation" HeaderText="Activation" />
                                        <asp:BoundField DataField="DateofExpire" HeaderText="Expire" />
                                        <asp:BoundField DataField="TemporaryStatus" HeaderText="Status" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" />
                                     
                                        <asp:BoundField DataField="FeePaidStatus" HeaderText="Fee Paid" />
                                        <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount" />
                                  
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                </table>
                </td>
                </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
      
    </asp:TabContainer>
    </td></tr></table>
</div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
   
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTrainingDetail.aspx.cs" Inherits="frmTrainingDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="sty/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 16px;
        }
        .auto-style2 {
            height: 17px;
        }
         .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 1px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGrid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            color: #717171;
            text-align: center;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            background: rgb(3, 116, 3) url(images/grd_head.png) repeat-x top;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
        }
        .mGrid .alt
        {
            background: #FAFAFA;
        }
        .mGrid .pgr
        {
            background: #424242;
        }
        .mGrid .pgr table
        {
            margin: 5px 0;
        }
        .mGrid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGrid .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGrid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
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
	font-family: verdana, tahoma, helvetica;
	font-size: 11px;
	background:#fff;
}
.ajax__tab_xp .ajax__tab_outer {
	  padding-right: 4px;
  background: #fff !important;
  height: 21px;
  font-size: 12px;
  padding: 4px 0;
  border: 1px solid #D5D5D5; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_inner {
	padding-left: 3px;
	 background: #fff !important;
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
  background: #fff !important;
  border-right: 1px solid green;
  border-left: 1px solid green;
  border-top: 1px solid green;
  padding: 5px 0; border-radius:5px 5px 0 0; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_inner {
	background:#fff!important;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_tab {
	background:#fff !important; color:Green; font-size:12px; font-weight:bold;
}
.ajax__tab_xp .ajax__tab_disabled {
	color: #A0A0A0;
}
.ajax__tab_xp .ajax__tab_body {
	font-family: verdana, tahoma, helvetica;
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
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div style="padding: 5px 0 0 0">
            <center>
            <table width ="80%">
                <tr>
                    <td align="center" colspan="4">
                         <asp:Label ID="Label2" runat="server" Text="Training Detail" CssClass="textcss" 
                             Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">&nbsp;

                    </td>
                 </tr>
                <tr>
                    <td align="justify">

                        <asp:Label ID="Label1" runat="server" Text="Title" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify">

                        <asp:Label ID="lblTitle" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                    <td align="justify">

                        <asp:Label ID="Label3" runat="server" Text="Name" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify">

                        <asp:Label ID="lblName" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td align="justify" >

                        <asp:Label ID="Label4" runat="server" Text="Description" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" colspan="3" >

                        <asp:Label ID="lblDesc" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td align="justify" class="auto-style2" >

                        <asp:Label ID="Label5" runat="server" Text="From Date" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" class="auto-style2" >

                        <asp:Label ID="lblFrmDate" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                    <td align="justify" class="auto-style2" >

                        <asp:Label ID="Label7" runat="server" Text="To Date" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" class="auto-style2" >

                        <asp:Label ID="lblToDate" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td align="justify" >

                        <asp:Label ID="Label9" runat="server" Text="Start Time" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" >

                        <asp:Label ID="lblFrmTime" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                    <td align="justify" >

                        <asp:Label ID="Label11" runat="server" Text="End Time" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" >

                        <asp:Label ID="lblToTime" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td align="justify" class="auto-style1" >

                        <asp:Label ID="Label12" runat="server" Text="Total Trainees " CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" class="auto-style1" >

                        <asp:Label ID="lblTotTrainees" runat="server" CssClass="textcss"></asp:Label>

                    </td>
                    <td align="justify" class="auto-style1" >

                        <asp:Label ID="Label13" runat="server" Text="Document" CssClass="textcss" Font-Bold="True"></asp:Label>

                    </td>
                    <td align="justify" class="auto-style1" >

                        <asp:LinkButton ID="lnkDoc" runat="server" CssClass="textcss" 
                            Font-Underline="True" onclick="lnkDoc_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="justify" class="auto-style1" >

                        </td>
                    <td align="justify" class="auto-style1" >

                        </td>
                    <td align="justify" class="auto-style1" >

                        </td>
                    <td align="justify" class="auto-style1" >

                        </td>
                </tr>
                <tr>
                    <td align="justify"  colspan="4">
                        <asp:TabContainer ID="TabContainer1" runat="server" Width="100%" 
                            ActiveTabIndex="3">
                            <asp:TabPanel ID="TabPanel1" HeaderText="TabPanel1" runat="server">
                            <HeaderTemplate>
                                    Student
                                
                            
</HeaderTemplate>
                            
<ContentTemplate>
<center><asp:GridView ID="grvStud" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" PageSize="15" Width="90%" AllowPaging="True" OnPageIndexChanging="grvStud_PageIndexChanging" OnRowDeleting="grvStud_RowDeleting">
    <Columns>
        <asp:TemplateField HeaderText="Delete" Visible="False">
            <ItemTemplate>
                <asp:ImageButton ID="ImgDelete" runat="server"  ImageUrl="~/images/delete.png"  />

            </ItemTemplate>

        </asp:TemplateField><asp:BoundField DataField="intRollNo" HeaderText="Roll No" />
<asp:BoundField DataField="StudName" HeaderText="Student Name" />
<asp:BoundField DataField="STD" HeaderText="STD" />
<asp:BoundField DataField="DIV" HeaderText="DIV" />
</Columns>
</asp:GridView>

                                    </center>
                                
                        
</ContentTemplate>
                            
</asp:TabPanel>
                            <asp:TabPanel ID="TabPanel2" HeaderText="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    Staff
                                
                            
</HeaderTemplate>
                                
<ContentTemplate>
<center><asp:GridView ID="grvTeacher" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" PageSize="15" Width="80%" AllowPaging="True" OnPageIndexChanging="grvTeacher_PageIndexChanging"><Columns>
    <asp:TemplateField HeaderText="Delete" Visible="False"><ItemTemplate><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/delete.png" /></ItemTemplate></asp:TemplateField><asp:BoundField DataField="Department" HeaderText="Department" />
<asp:BoundField DataField="Teacher" HeaderText="Name" />
</Columns>
</asp:GridView>

                                    </center>
                                
                        
</ContentTemplate>
                                
</asp:TabPanel>
                            <asp:TabPanel ID="TabPanel3" HeaderText="TabPanel1" runat="server">
                             <HeaderTemplate>
                                    Parent
                                
                            
</HeaderTemplate>
                            
<ContentTemplate>
<center><asp:GridView ID="grvParent" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" PageSize="15" Width="100%" AllowPaging="True" OnPageIndexChanging="grvParent_PageIndexChanging">
    <Columns>
        <asp:TemplateField HeaderText="Delete" Visible="False">
    <ItemTemplate>
    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/delete.png" />

    </ItemTemplate>

                                                                                                                                                         </asp:TemplateField><asp:BoundField DataField="intRollNo" HeaderText="Roll No" />
<asp:BoundField DataField="StudName" HeaderText="Student Name" />
<asp:BoundField DataField="Parent" HeaderText="Parent Name" /><asp:BoundField DataField="STD" HeaderText="STD" /><asp:BoundField DataField="DIV" HeaderText="DIV" /></Columns>
</asp:GridView>

                                    </center>
                                
                        
</ContentTemplate>
                        
</asp:TabPanel>

                              <asp:TabPanel ID="TabPanel4" HeaderText="TabPanel1" runat="server">
                             <HeaderTemplate>
                                    All
                                
                            
</HeaderTemplate>
                            
<ContentTemplate>
<center><asp:GridView ID="grvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" PageSize="15" Width="100%" AllowPaging="True" OnPageIndexChanging="grvAll_PageIndexChanging">
    <Columns>
    <asp:TemplateField HeaderText="Delete" Visible="False">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/delete.png" />

        </ItemTemplate>

    </asp:TemplateField>
    <asp:BoundField DataField="Type" HeaderText="Type" />
<asp:BoundField DataField="Teacher" HeaderText="Staff Name" />
<asp:BoundField DataField="StudName" HeaderText="Student Name" />
    <asp:BoundField DataField="Parent" HeaderText="Parent Name" />
    <asp:BoundField DataField="Department" HeaderText="Department" />
    <asp:BoundField DataField="STD" HeaderText="STD" />
    <asp:BoundField DataField="DIV" HeaderText="DIV" />

</Columns>
</asp:GridView>

                                    </center>
                                
                        
</ContentTemplate>
                        
</asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
            </center>
        </div>
    </form>
</body>
</html>

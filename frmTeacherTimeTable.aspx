<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmTeacherTimeTable.aspx.cs" Inherits="frmTeacherTimeTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
    
    .mGrid th{ text-align:center !important;}
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
	display: inline-block;
	margin-top:-5px;
	
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
  border-right: 1px solid green;
  border-left: 1px solid green;
  border-top: 1px solid green;
  padding: 5px 0; border-radius:5px 5px 0 0; margin-right:2px;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_inner {
	background:#fff !important;
}
.ajax__tab_xp .ajax__tab_active .ajax__tab_tab {
	background:#fff !important; color:#3498db; font-size:12px; font-weight:bold;
}
.ajax__tab_xp .ajax__tab_disabled {
	color: #A0A0A0;
}
.ajax__tab_xp .ajax__tab_body {
	font-family: Verdana;
	font-size: 10pt;
	border: 1px solid #999999;
	
	padding: 0 !important;
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
    <style type="text/css">
        .style1
        {
            width: 60%;
            margin: 0 auto;
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
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
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
        }
        .efficacious_send
        {
            width: 60% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="content-header pd-0">
       
        <ul class="top_nav1 sp">
        <li><a >Study <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li class="active1"><a href="frmTeacherTimeTable.aspx">Time Table</a></li>
            <li><a href="frmExaminationSchedule.aspx">Examination</a></li>
            <li><a href="frmSyllabusMst.aspx">Syllabus</a></li>
            <li><a href="frmMarksEntry.aspx">Marks Entry</a></li>            
            <li><a href="Result.aspx">Result</a></li>  
                               
        </ul>
    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" ID="tc1" Width="100%" Visible="false">
                            <asp:TabPanel runat="server" ID="tb1">
                                <HeaderTemplate>
                                    Detail
                                </HeaderTemplate>
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                        <table width="100%">
                            <tr id="selection" runat="server">
                                <td colspan="4" align="center">
                                    <div id="efficacious" class="efficacious" style="background: #fff; height: 1px;">
                                        <table width="80%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblTeacher" runat="server" Text="Teacher Name"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="True" Width="200px"
                                                        OnSelectedIndexChanged="ddlTeacher_SelectedIndexChanged">
                                                        <asp:ListItem>---Select---</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" valign="top">
                                    <asp:GridView ID="grvTimetable" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                        EmptyDataText="Record not Found." Width="100%" OnRowDataBound="grvTimetable_RowDataBound"
                                        Height="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSrno" Font-Bold="true" runat="server" Text='<%#Eval("SrNo")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Period Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPeriod" runat="server" Text='<%#Eval("Time")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonday" runat="server" Text='<%#Eval("Monday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tuesday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTuesday" runat="server" Text='<%#Eval("Tuesday")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Wednesday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWednesday" runat="server" Text='<%#Eval("Wednesday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thursday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblThursday" runat="server" Text='<%#Eval("Thursday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Friday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFriday" runat="server" Text='<%#Eval("Friday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Saturday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSaturday" runat="server" Text='<%#Eval("Saturday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BitRecess" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecess" runat="server" Text='<%#Eval("btrecess")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle HorizontalAlign="Left"></RowStyle>
                                        <AlternatingRowStyle CssClass="alt" />
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</section>
</asp:Content>

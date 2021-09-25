<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="CCEdit.aspx.cs" Inherits="CCEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<style>
		.txt_cls{border:1px solid #3498db; width:50%; margin:5px; padding:5px;}
		.frm_heading h1{text-align:center; margin:40px 00;}
        td {
			width: 40%
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel runat="server" ID="Up">
                        <ContentTemplate>

<div class="tabular">
                                           <%-- <table width="100%">
                                                <tr>
                                                    <td align="center" valign="middle" style="width:auto">
                                                        <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 0px; width:auto" valign="middle">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged" >
                                                            <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            
                                                            <%--<asp:ListItem Value="1" Text="I"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="II"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="III"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="IV"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="V"></asp:ListItem>--%>
                                                        <%--</asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle" style="width:auto">
                                                        <asp:Label ID="lblDIV" runat="server" Text="Section" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle" style="width:auto">
                                                        <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize" AutoPostBack="True" onselectedindexchanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
<%--                                                    <td align="center" valign="middle" style="width:auto">
                                                        <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="textsize"></asp:Label>
                                                    </td>--%>
<%--                                                    <td align="left" valign="middle" style="width:auto">
                                                         <asp:DropDownList ID="ddlGender" runat="server"  
                                                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    <asp:ListItem  Value="2">Female</asp:ListItem>
                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                </asp:DropDownList>
                                                    </td>--%>
                                                     <%--<td style="width:auto">
                                                    <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="center" valign="middle" style="width:auto">
                                                        <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="bottom" CssClass="efficacious_send" style="width:auto">
                                                     <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                                           <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                        <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="textsize" 
                                                            OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    </td>
                                                     <td align="center" valign="middle" style="width:auto">
                                                    <asp:Label ID="Label27" runat="server" Text="Exam" CssClass="textsize" Visible="false"></asp:Label>

                                                    </td>

                                                     <td align="left" valign="bottom" CssClass="efficacious_send" style="width:auto">
                                                     <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" CssClass="textsize" Visible="false" ></asp:DropDownList>
                                                    
                                                    </td>
                                                    <td style="padding-left: 12px; width:auto">
                                                    <asp:Button ID="show" runat="server" CssClass="btn btn-sm btn-primary" Text="Show" onclick="show_Click" Visible="false" />
                                                    </td>
                                                    
                                                   
                                                </tr>
                                            </table>--%>
                                        </div>
    <div class="content-header">
	<div class="frm_heading"><h1>Character Certificate</h1></div>
	<div class="main_content">
	<center>
    <div class="frm_content" style="width:100%">
	<table style="width:90%">
		<tbody>
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server" Text="This is to certify that Master / Miss"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtnameofpupil" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server" Text="Son / Daughter of  Mr"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtfathername" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Text="Son / Daughter of Mrs"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtmothername" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label4" runat="server" Text="is/was a student of this school. He/She is/was well behaved diligent and an energetic student.He/ She is/was reading in class"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtclass" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label5" runat="server" Text="sec"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtSec" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label6" runat="server" Text="srteam" Visible="false"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="ddlstream" runat="server" style="width:50%;margin:5px" Visible="false">
						<asp:ListItem>Arts</asp:ListItem>
						<asp:ListItem>Commerce</asp:ListItem>
						<asp:ListItem>Science</asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label7" runat="server" Text="Roll No."></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtRollno" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label8" runat="server" Text="Year"></asp:Label>
				</td>
				<td>
					<%--<asp:TextBox ID="txtyear" runat="server" TextMode="Date" class="txt_cls"></asp:TextBox>--%>
                    <asp:TextBox ID="txtyear" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label9" runat="server" Text="Secondary / Sr. Secondary."></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label10" runat="server" Text="He / She has appeared for class"></asp:Label>
				</td>
				<td>
					<%--<asp:TextBox ID="txtappclass" runat="server" class="txt_cls"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlappclass" runat="server" AutoPostBack="True" class="txt_cls"
                                                            >
                                                            <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            
                                                            <%--<asp:ListItem Value="1" Text="I"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="II"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="III"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="IV"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="V"></asp:ListItem>--%>
                                                        </asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label11" runat="server" Text="stream" Visible="false"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="ddlappstream" runat="server" style="width:50%;margin:5px" Visible="false">
						<asp:ListItem>Arts</asp:ListItem>
						<asp:ListItem>Commerce</asp:ListItem>
						<asp:ListItem>Science</asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label12" runat="server" Text="Examination AISSE, AISSCE Roll No"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtAISSCERollno" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label13" runat="server" Text="from our School promoted / not promoted the Secondary / Sr. Secondary examination from our school in the year"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtappyear" runat="server" class="txt_cls"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label14" runat="server" Text="under Central Board of Secondary Education. New Delhi.	"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label15" runat="server" Text="According to our School Register his / her date of birth is "></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtDOB" runat="server"  class="txt_cls"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB" Format="dd/MMMM/yyyy"
                                                                                Enabled="True"></asp:CalendarExtender>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label16" runat="server" Text="His / Her character within the campus is was"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtcharacter" runat="server" class="txt_cls" Visible="false"></asp:TextBox>
                    <asp:Label ID="Label17" runat="server" Text="AVERAGE/GOOD/VERY GOOD"></asp:Label>
				</td>
			</tr>
			<tr>
				<td><h4 class="pull-left">Prepared By</h4></td>
			</tr>
				<tr>
					<td>
					<asp:Label ID="Label18" runat="server" Text="Date"></asp:Label>
			<asp:TextBox ID="txtpreparedby" TextMode="Date" runat="server"></asp:TextBox>
				</td>
				<td>
					<h4 class="pull-left">Principal’s Signature</h4>
				</td>
					</tr>
			</tbody>
	</table>
        
    <div>
    <table>
    <tr>
    <td>
    <asp:Button ID="btnview" runat="server" CssClass="btn btn-sm btn-primary" Text="Preview" onclick="view_Click" style="margin:5px;" />
    </td>
    <td>
    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" onclick="Submit_Click" style="margin:5px;" Visible="false"  />
    </td>
    <td>
    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-primary" Text="Update" onclick="Update_Click" style="margin:5px;" Visible="false"  />
    </td>
    </tr>
    </table>
    
    </div>

        </div>
		</center>
        </div>
        </div>
	


    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HostelBed.aspx.cs" Inherits="HostelBed" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style>
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function confirmMsg() {
            if (Page_ClientValidate() == false) {
                return false;
            }
            else {
                var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
                if (btn == 'Submit') {
                    var msg = confirm('Do You Really Want To Save Entered Records ?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    var msg = confirm('Do You Really Want To Update Entered Records ?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }
    </script>
  
    <style type="text/css">
        .efficacious span
        {
            margin: 5px 0 5px 0 !important;
            padding: 0 !important;
        }
        .style1
        {
            height: 22px;
        }
        .style4
        {
            width: 107px;
        }
        .style6
        {
            height: 22px;
            width: 207px;
        }
        .style7
        {
            width: 207px;
        }
        .style8
        {
            width: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Hostel Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="HostelBuilding.aspx">Hostel Building</a></li>
             <li><a href="HostelWing.aspx">Hostel Wing</a></li>
            <li><a href="HostelFloor.aspx">Hostel Floor</a></li>
            <li><a href="HostelRoom.aspx">Hostel Room</a></li>
            <li class="active1"><a href="HostelBed.aspx">Hostel Bed</a></li>
            <li><a href="HostelFeeHead.aspx">Hostel Fee</a></li>
            <li><a href="HostelStudentMaster.aspx">Hostel Student Entry</a></li>
            <li><a href="HostelInquiry.aspx">Hostel Enquiry</a></li>
        </ul>
    </div>

<section class="content">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer CssClass="MyTabStyle" ID="TBC" Width="100%" runat="server" 
                            ActiveTabIndex="1">
                            <asp:TabPanel ID="TB1" runat="server">
                                <HeaderTemplate>
                                    Details</HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <center>
                                        <asp:GridView ID="grvDetail" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                            Width="100%" DataKeyNames="HostelBed_Id" AllowPaging="True" 
                                            onpageindexchanging="grvDetail_PageIndexChanging" 
                                            onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing" >
                                            <Columns>
                                                <asp:BoundField DataField="HostelBuilding_id" HeaderText="Building Name" ReadOnly="True" />
                                                <asp:BoundField DataField="HostelWing_id" HeaderText="Wing" ReadOnly="True" />
                                                <asp:BoundField DataField="HostelFloor_id" HeaderText="Floor Name" ReadOnly="True" />
                                                <asp:BoundField DataField="HostelRoom_id" HeaderText="Room Name" ReadOnly="True" />
                                                <asp:BoundField DataField="vchBed" HeaderText="Bed No." ReadOnly="True" />      
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="HostelBed_Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("HostelBed_Id") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Delete" >
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                            OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');"
                                                            ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                                                                      
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TB2" runat="server">
                                <HeaderTemplate>
                                    New Entry</HeaderTemplate>
                                <ContentTemplate>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <center>
                                        <div class="efficacious">
                                            <table width="55%">
                                             <tr>
                                                    <td align="left"  width="50%">
                                                        <asp:Label ID="Label7" runat="server" Text="Building Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="drpBuilding" Style="width: 106%; position: relative; right: 130px"
                                                            runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpBuilding_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                      
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left"  width="50%">
                                                        <asp:Label ID="Label8" runat="server" Text="Wing"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="drpWing" Style="width: 106%; position: relative; right: 130px"
                                                            runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpWing_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                      
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  width="50%">
                                                        <asp:Label ID="Label1" runat="server" Text="Floor "></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:DropDownList ID="ddlFloor" Style="width: 106%; position: relative; right: 130px"
                                                            runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlFloor_SelectedIndexChanged" >
                                                        </asp:DropDownList>
                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style6" >
                                                        <asp:Label ID="Label2" runat="server" Text="Room"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" class="style1">
                                                       <asp:DropDownList ID="drpRoom" Style="width: 106%; position: relative; right: 130px"
                                                            runat="server" AutoPostBack="True" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                                        <asp:Label ID="Label3" runat="server" Text="Bed"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtBed" Style="position: relative; right: 130px" CssClass="input-blue"
                                                            runat="server" AutoComplete="Off" MaxLength="3"></asp:TextBox><asp:FilteredTextBoxExtender
                                                                runat="server" ID="Filtertxt" FilterType="Numbers" TargetControlID="txtBed"
                                                                Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                               
                                               
                                                <tr valign="top">
                                                    <td class="style7" align="right">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" valign="top" width="30%">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            OnClientClick="return confirmMsg();" Text="Submit" onclick="btnSubmit_Click" 
                                                             />
                                                    </td>
                                                    <td align="left" width="50%">
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                                            CssClass="efficacious_send" Visible="False"
                                                            Text="Clear"  />
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>


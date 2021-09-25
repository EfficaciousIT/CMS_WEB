<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HostelRoom.aspx.cs" Inherits="HostelRoom" %>

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
            <li class="active1"><a href="HostelRoom.aspx">Hostel Room</a></li>
            <li><a href="HostelBed.aspx">Hostel Bed</a></li>
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
                                            Width="100%" DataKeyNames="HostelRoom_id" AllowPaging="True" OnPageIndexChanging="grvDetail_PageIndexChanging"
                                            OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                            <Columns>
                                                                                                <asp:BoundField DataField="HostelBuilding_id" HeaderText="Building Name" ReadOnly="True" />
                                                <asp:BoundField DataField="HostelWing_id" HeaderText="Wing" ReadOnly="True" />

                                                <asp:BoundField DataField="HostelFloor_name" HeaderText="Floor Name" ReadOnly="True" />
                                                <asp:BoundField DataField="vchRoom_name" HeaderText="Room Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intTotalChairs" HeaderText="Total Chairs" ReadOnly="True" />
                                                <asp:BoundField DataField="intTotalLights" HeaderText="Total Lights" ReadOnly="True" />
                                                <asp:BoundField DataField="intTotalFan" HeaderText="Total Fan" ReadOnly="True" />
                                                <asp:BoundField DataField="intTotalBed" HeaderText="Total Bed" ReadOnly="True" Visible="false" />   
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="HostelRoom_id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("HostelRoom_id") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Delete">
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
                                                    <td align="left" class="style6" valign="top">
                                                        <asp:Label ID="Label2" runat="server" Text="Room"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" class="style1">
                                                        <asp:TextBox ID="txtRoom" Style="position: relative; right: 130px" runat="server"
                                                            AutoComplete="Off" MaxLength="50"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server" TargetControlID="txtRoom"
                                                            FilterType="Numbers, UppercaseLetters, LowercaseLetters" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                                        <asp:Label ID="Label3" runat="server" Text="Total Chairs"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtChair" Style="position: relative; right: 130px" CssClass="input-blue"
                                                            runat="server" AutoComplete="Off" MaxLength="3"></asp:TextBox><asp:FilteredTextBoxExtender
                                                                runat="server" ID="Filtertxt" FilterType="Numbers" TargetControlID="txtChair"
                                                                Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style7" >
                                                        <asp:Label ID="Label4" runat="server" Text="Total Lights"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtLight" Style="position: relative; right: 130px" runat="server"
                                                            AutoComplete="Off" MaxLength="2" CssClass="input-blue"></asp:TextBox><asp:FilteredTextBoxExtender
                                                                runat="server" ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtLight"
                                                                Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style7" >
                                                        <asp:Label ID="Label5" runat="server" Text="Total Fans"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtFan" Style="position: relative; right: 130px" runat="server"
                                                            AutoComplete="Off" MaxLength="2" CssClass="input-blue"></asp:TextBox><asp:FilteredTextBoxExtender
                                                                runat="server" ID="FilteredTextBoxExtender2" FilterType="Numbers" TargetControlID="txtFan"
                                                                Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td align="left" class="style7">
                                                        <asp:Label ID="Label6" runat="server" Text="Total Bed" Visible="false"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                    <asp:DropDownList runat="server" AutoPostBack="True" ID="drpBed" Style="width: 106%; position: relative; right: 130px" Visible="false">
                                                    </asp:DropDownList>

                                                    </td>
                                                </tr>
                                               
                                                <tr valign="top">
                                                    <td class="style7" align="right">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" valign="top" width="30%">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            OnClientClick="return confirmMsg();" Text="Submit" 
                                                            onclick="btnSubmit_Click" />
                                                    </td>
                                                    <td align="left" width="50%">
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                                            CssClass="efficacious_send" Visible="False"
                                                            Text="Clear" onclick="btnClear_Click"  />
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


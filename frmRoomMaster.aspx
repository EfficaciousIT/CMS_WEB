<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmRoomMaster.aspx.cs" Inherits="frmRoomMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        .style7
        {
            width: 207px;
        }
        .style10
        {
            height: 48px;
        }
        .style11
        {
            width: 28%;
        }
        .style12
        {
            width: 49px;
        }
        .style13
        {
            height: 48px;
            width: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Asset Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li> <a href="frmBuildingMaster.aspx"> Building Master </a></li>
                  <li><a href="frmWingMaster.aspx"> Wing Master</a></li>
                  <li><a>Floor Master</a></li>   
                  <li class="active1"><a href="frmRoomMaster.aspx"> Room Master</a></li>
                  <li><a href="frmEquipItemMaster.aspx">Item Master</a></li>
                  <li><a href="frmItemTypeMaster.aspx"> Item Details Master</a></li>
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
                                    <left>
                                        <asp:GridView ID="grvDetail" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                            Width="100%" DataKeyNames="intRoom_id" AllowPaging="false" OnPageIndexChanging="grvDetail_PageIndexChanging"
                                            OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                            <Columns>
                                             <asp:TemplateField HeaderText="intRoom_id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("intRoom_id") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="intBuilding_id" HeaderText="Building Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intWing_id" HeaderText="Wing Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intFloor_id" HeaderText="Floor Name" ReadOnly="True" />
                                                <asp:BoundField DataField="vchRoom_name" HeaderText="Room Name" ReadOnly="True" />
                                                <asp:BoundField DataField="vchDescription" HeaderText="Description" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                               
                                               <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                            OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');"
                                                            ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </left>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TB2" runat="server">
                                <HeaderTemplate>
                                    New Entry</HeaderTemplate>
                                <ContentTemplate>
                                   
                                    <br />
                                    <left>
                                        <div class="efficacious">
                                            <table width="50%">
                                            <tr>
                                                    <td class="style11">

                                                    </td>
                                                    <td align="left" class="style11">
                                                        <asp:Label ID="Label7" runat="server" Text="Building Name"></asp:Label>



                                                    </td>

                                                    <td align="left" colspan="2" width="50%">
                                                        <asp:DropDownList ID="drpBuilding" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpBuilding_SelectedIndexChanged"></asp:DropDownList>



                                                    </td>
                                                    
                                                </tr>
                                                 <tr>
                                                 <td class="style11">

                                                    </td>
                                                    <td align="left" class="style11">
                                                        <asp:Label ID="Label3" runat="server" Text="Wing Name"></asp:Label>



                                                    </td>
                                                    <td align="left" colspan="2" width="10%">
                                                        <asp:DropDownList ID="drpWing" 
                                                            runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpWing_SelectedIndexChanged"></asp:DropDownList>



                                                    </td>
                                                </tr>
                                                <tr>
                                                <td class="style12">

                                                    </td>
                                                    <td align="left" class="style11">
                                                        <asp:Label ID="Label1" runat="server" Text="Floor"></asp:Label>



                                                    </td>
                                                    <td align="left" colspan="2" width="50%">
                                                        <asp:DropDownList ID="ddlFloor" runat="server" AutoPostBack="True"></asp:DropDownList>




                                                        <asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="Please Select Floor"
                                                            Display="None" ControlToValidate="ddlFloor" InitialValue="0"></asp:RequiredFieldValidator>




                                                               <asp:ValidatorCalloutExtender
                                                                ID="VC" runat="server" TargetControlID="R1" Enabled="True"></asp:ValidatorCalloutExtender>







                                                    </td>
                                                </tr>
                                                <tr>
                                                <td class="style12">

                                                    </td>
                                                    <td align="left" class="style11">
                                                        <asp:Label ID="Label2" runat="server" Text="Room"></asp:Label>




                                                    </td>
                                                    <td align="left" colspan="2" width="50%" class="style10">
                                                        <asp:TextBox ID="txtRoom" runat="server" MaxLength="50" Height="33px" 
                                                            Width="283px"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="R2"
                                                                runat="server" ErrorMessage="Please Enter Room Name" Display="None" ControlToValidate="txtRoom"></asp:RequiredFieldValidator>

                                                                    <asp:ValidatorCalloutExtender
                                                                    ID="VC2" runat="server" TargetControlID="R2" Enabled="True"></asp:ValidatorCalloutExtender>

                                                       
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                <td class="style12">

                                                    </td>
                                                    <td align="left" class="style11">
                                                        <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>




                                                    </td>
                                                    <td align="left" colspan="2" width="50%" class="style10">
                                                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="500" Height="33px" 
                                                            Width="283px" TextMode="MultiLine"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                <td width="10%">
                                                </td>
                                                    <td class="style12" align="right">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" class="style11">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                            OnClientClick="return confirmMsg();" Text="Submit" Width="255px" />







                                                    </td>
                                                    <td align="left" width="50%">
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                                            CssClass="efficacious_send" Visible="False"
                                                            Text="Clear" OnClick="btnClear_Click" />







                                                    </td>
                                                    <td align="left">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </left>
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

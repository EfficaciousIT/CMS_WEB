<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSchoolInventory.aspx.cs" Inherits="frmSchoolInventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     var prm = Sys.WebForms.PageRequestManager.getInstance();
     //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
     prm.add_beginRequest(BeginRequestHandler);
     // Raised after an asynchronous postback is finished and control has been returned to the browser.
     prm.add_endRequest(EndRequestHandler);
     function BeginRequestHandler(sender, args) {
         //Shows the modal popup - the update progress
         var popup = $find('<%= modalPopup.ClientID %>');
         if (popup != null) {
             popup.show();
         }
     }

     function EndRequestHandler(sender, args) {
         //Hide the modal popup - the update progress
         var popup = $find('<%= modalPopup.ClientID %>');
         if (popup != null) {
             popup.hide();
         }
     }
</script>  
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[id*=chkCtrlAll]").live("click", function () {
        var chkCtrlAll = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkCtrlAll.is(":checked")) {
                $(this).attr("checked", "checked");
                $("td", $(this).closest("tr")).addClass("selected");
            } else {
                $(this).removeAttr("checked");
                $("td", $(this).closest("tr")).removeClass("selected");
            }
        });
    });
    $("[id*=chkRow]").live("click", function () {
        var grid = $(this).closest("table");
        var chkCtrlAll = $("[id*=chkCtrlAll]", grid);
        if (!$(this).is(":checked")) {
            $("td", $(this).closest("tr")).removeClass("selected");
            chkCtrlAll.removeAttr("checked");
        } else {
            $("td", $(this).closest("tr")).addClass("selected");
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkCtrlAll.attr("checked", "checked");
            }
        }
    });
</script> 
 
<style type="text/css">
    .modalPopup
    {
    background-color: #696969;
    filter: alpha(opacity=40);
    opacity: 0.7;
    xindex:-1;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Inventory Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="#">Store Master</a></li>
             <li><a href="frmSchoolEquipmentMaster.aspx">Equipment Master</a></li>
            <li><a href="frmUnitMaster.aspx">Unit Master</a></li>
            <li class="active1"><a href="frmSchoolInventory.aspx">Inventory Master</a></li>
        </ul>
    </div>
<section class="content">   
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="tabcon" ActiveTabIndex="0"
                    Width="99%">
                    <asp:TabPanel ID="List" HeaderText="List" runat="server">
                        <ContentTemplate>
                            <center>
                                <div class="efficacious">
                                    <table width="90%" style="margin-top: 15px;">
                                        <tr>
                                            <td align="center">
                                                <table runat="server" id="filtertable" width="100%">
                                                    <tr id="Tr1" runat="server">
                                                        <td id="Td1" runat="server">
                                                            <asp:Label ID="lblInventoryName" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Inventory Name"></asp:Label>
                                                        </td>
                                                        <td id="Td2"  align="left" runat="server">
                                                            <asp:DropDownList ID="ddlInventory" runat="server" Style="position: relative; top: 5px; text-align: right;" >
                                                                                </asp:DropDownList>
                                                        </td>
                                                        <td id="Td3" align="center" runat="server">
                                                            <asp:Label ID="lblQty" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Quantity"></asp:Label>
                                                        </td>
                                                        <td id="Td4" align="left" runat="server">
                                                            <asp:TextBox ID="txtQty" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>                                                       
                                                    </tr>
                                                      <tr id="Tr2" runat="server">
                                                        <td id="Td7" runat="server">
                                                            <asp:Label ID="lblUnit" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Unit Type"></asp:Label>
                                                        </td>
                                                        <td id="Td8"  align="left" runat="server">
                                                            <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                        </td>
                                                        <td id="Td9" align="center" runat="server">
                                                            <asp:Label ID="lblPrice" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="Price"></asp:Label>
                                                        </td>
                                                        <td id="Td10" align="left" runat="server" >
                                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>

                                                       </tr>
                                                       <tr runat="server">                                                        <td id="Td11" align="center" runat="server">
                                                           
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send"  
                                                                Text="Submit" onclick="btnSubmit_Click" />
                                                            
                                                        </td>

                                                       </tr>

                                                   
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                <asp:GridView ID="gvList" runat="server" AllowSorting="True"
                                                                            AutoGenerateColumns="False" 
                                                        CssClass="table  tabular-table " DataKeyNames="intInventory_Id"
                                                                            EmptyDataText="Record not Found."  Width="100%" 
                                                        onrowdeleting="gvList_RowDeleting" onrowediting="gvList_RowEditing" >
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>
                                                                                <asp:BoundField ReadOnly="True" DataField="dtDate" HeaderText="Date" />                                                                                 
                                                                                <asp:BoundField ReadOnly="True" DataField="intEquipment_id" HeaderText="Name" />  
                                                                                <asp:BoundField ReadOnly="True" DataField="vchQty" HeaderText="Qty" />   
                                                                                <asp:BoundField ReadOnly="True" DataField="intUnit_Id" HeaderText="Type" />    
                                                                                <asp:BoundField ReadOnly="True" DataField="vchPrice" HeaderText="Price" />   
                                                                                <asp:TemplateField HeaderText="Edit">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                            ImageUrl="~/images/edit.png" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                               <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                            OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>                                                                          
                                                                            </Columns>
                                                                            <PagerStyle CssClass="pgr" />
                                                                            <RowStyle HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                          <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                                <ProgressTemplate>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                                                PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                                                Enabled="True">
                                                            </asp:ModalPopupExtender>
                                                </div>
                                            </td>
                                         
                                        </tr>
                                    </table>
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Details" Visible="false">
                       
                    </asp:TabPanel>                   
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>

</section>
</asp:Content>


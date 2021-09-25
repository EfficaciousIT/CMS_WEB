<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmGroupMst.aspx.cs" Inherits="frmGroupMst" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style type="text/css">
       
          .mGrid th {
 
  text-align: center !important;
 
}
        </style>
    <script type="text/javascript" language="javascript">

        function Delete() {
            var del = confirm('Do You Really Want To Delete Selected Record?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }


        function ConfirmMsg() {
            var txt = document.getElementById('<%=txtGroupName.ClientID %>').value;
            if (txt.trim() == '') {
                alert('Please Enter Group Name');
                document.getElementById('<%=txtGroupName.ClientID %>').value = '';
                document.getElementById('<%=txtGroupName.ClientID %>').focus();
                return false;
            }
            else {

                var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
                if (btn == 'Submit') {
                    var msg = confirm('Do You Want To Add This Group Name?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    var msg = confirm('Do You Want To Update This Group Name?');
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
        
        .efficacious input.efficacious_send{background: #3498db !important; border:none; }
        
        .style1
       {
           width: 164px;
       }
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table>
            <tr>
                <td align="left">
                    <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1" 
                        Width="1015px">
                        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                            <HeaderTemplate>
                                Details</HeaderTemplate>
                            <ContentTemplate>
                                <table width="1015">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="grvGroup" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                Width="100%" OnRowDataBound="grvGroup_RowDataBound" OnRowCommand="grvGroup_RowCommand"
                                                DataKeyNames="intGroup_id" OnRowEditing="grvGroup_RowEditing" 
                                                onpageindexchanging="grvGroup_PageIndexChanging" 
                                                onrowdeleting="grvGroup_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" OnClientClick="return Delete();" ImageUrl="~/images/delete.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Edit Group Name" CommandName="Edit"
                                                                ImageUrl="~/images/edit.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="GroupId" Visible="False" DataField="intGroup_id" ReadOnly="True" />
                                                    <asp:BoundField HeaderText="Group Name" DataField="vchGroup_name" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Member Count">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkCount" CommandName="LinkCall" runat="server" CommandArgument='<% #Bind("intGroup_id") %>'
                                                                Text='<% #Eval("intGroup_count") %>' Font-Underline="true">0</asp:LinkButton></ItemTemplate>
                                                        <HeaderStyle Width="200px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                            <HeaderTemplate>
                                New Group</HeaderTemplate>
                            <ContentTemplate>
                                <center>
                                <div class="efficacious">
                                    <table width="50%">
                                        <tr>
                                            <td align="left" class="style1">
                                                <asp:Label ID="lblGroupName" runat="server" Text="Enter Group Name" CssClass="textcss"></asp:Label>
                                            </td>
                                            <td align="left" width="150px" >
                                                <asp:TextBox ID="txtGroupName" runat="server" CssClass="textsize" 
                                                    AutoComplete="Off" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                      
                                            <td align="center">
                                                
                                            </td>
                                            <td align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ConfirmMsg();"
                                                    OnClick="btnSubmit_Click" style="margin-right:10px;:" CssClass="efficacious_send" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                    onclick="btnCancel_Click" CssClass="efficacious_send" />
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
        
    </div>
</asp:Content>

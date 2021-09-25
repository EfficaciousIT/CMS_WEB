<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSubModuleMaster.aspx.cs" Inherits="frmSubModuleMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">

    function confirmMsg() {
        var txt = document.getElementById("<%=txtSubModule.ClientID %>").value;
        if (txt.trim() == '') {
            alert('Please Enter Sub-Module Name');
            return false
        }
        else {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {
                var msg = confirm('Do You Really Want To Save Entered Record ?');
                if (msg) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var msg = confirm('Do You Really Want To Update Entered Record ?');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Sub-Module
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
             <li><a ><i ></i>School Master</a></li>
            <li class="active">Sub-Module Master</li>
        </ol>
    </div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" Width="100%" 
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    List
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="50%" AllowPaging="True" 
                                                        DataKeyNames="intSubModule_Id" onrowdeleting="grvDetail_RowDeleting" 
                                                        onpageindexchanging="grvDetail_PageIndexChanging" 
                                                        onrowediting="grvDetail_RowEditing" >
                                                        <Columns>
                                                        <asp:BoundField DataField="intModule_Id" HeaderText="Module" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchSubModule" HeaderText="Sub-Module" ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" ImageUrl="~/images/edit.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department Name" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Text='<%#Eval("intSubModule_Id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Delete" >
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="true"
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record ?');"
                                                                        ImageUrl="~/images/delete.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TB2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious">
                                            <table width="50%">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                 
                                                 <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label4" runat="server" Text="Module"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:DropDownList ID="ddlModule" runat="server" ></asp:DropDownList>
                                                    </td>
                                                </tr>                               
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbllectype" runat="server" Text="Sub-Module Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtSubModule" runat="server" CssClass="input-blue" MaxLength="50" ToolTip="Enter Sub-Module Name Here "></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server" TargetControlID="txtSubModule"
                                                            FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" 
                                                            ValidChars=" " Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                            Text="Submit" onclick="btnSubmit_Click"  />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" 
                                                            Text="Cancel" Visible="False"  />
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

</asp:Content>


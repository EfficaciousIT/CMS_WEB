<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmDeviceAssign.aspx.cs" Inherits="frmDeviceAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function validation() {
            var ddlDeviceType = document.getElementById('<%=ddlDeviceType.ClientID %>');
            if (ddlDeviceType == '0') {
                alert('Please Select Device Type');
                
                return false;
            }
            
            var atLeast = 1;
            var count = 0;
            var chkLst = document.getElementById('<%=chkLst.ClientID %>');
            var chk = chkLst.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].checked) {
                    count++;
                }
            }
            if (atLeast > count) {
                alert('Please Select Atleast One Record');
                return false;
            }

            var ddlSchool = document.getElementById('<%=ddlSchool.ClientID %>').value;
            if (ddlSchool == '0') {
                alert('Please Select School');
               
                return false;
            }

            var msg = confirm('Do You Really Want To Assign Selected Records?');
            if (msg) {
                return true;
            }
            else {
            return false;
            }

            return true;
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 143px;
        }
        
        .checkbox
        {
        	width:50px;
        	border:0px ;
        	
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                    <br />
                        <asp:TabContainer ID="tbc1" CssClass="MyTabStyle" runat="server" Width="100%" 
                            ActiveTabIndex="3">
                            <asp:TabPanel runat="server" ID="tb1">
                                <HeaderTemplate>
                                    Assigned RF Devices
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="90%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left" class="style1">
                                                            <asp:Label ID="lblSchool" runat="server" Text="Select School" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSchoolRf" runat="server" CssClass="textsize" 
                                                                onselectedindexchanged="ddlSchoolRf_SelectedIndexChanged" 
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:GridView ID="grvRF" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                    CssClass="mGrid" EmptyDataText="Record not Found." 
                                                    PageSize="5" DataKeyNames="intRFid" Width="100%" 
                                                    onrowdeleting="grvRF_RowDeleting" 
                                                    onpageindexchanging="grvRF_PageIndexChanging" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" CausesValidation="false"
                                                                    OnClientClick="return ConfirmDelete();" ImageUrl="~/images/delete.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" CausesValidation="false"
                                                                    ImageUrl="~/images/edit.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="vchRF_No" HeaderText="RF Number" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="intPort" HeaderText="Port" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="vchIP" HeaderText="IP" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel1">
                                <HeaderTemplate>
                                    Assigned Tracking Devices
                                </HeaderTemplate>
                                <ContentTemplate>
                                 <table width="90%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left" class="style1">
                                                            <asp:Label ID="Label1" runat="server" Text="Select School" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSchoolTrack" runat="server" CssClass="textsize" 
                                                                AutoPostBack="True" 
                                                                onselectedindexchanged="ddlSchoolTrack_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:GridView ID="grvTrack" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False"
                                                    CssClass="mGrid" EmptyDataText="Record not Found." 
                                                    PageSize="5" DataKeyNames="intDeviceId" Width="100%" 
                                                    OnRowDeleting="grvTrack_RowDeleting" 
                                                    onpageindexchanging="grvTrack_PageIndexChanging" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" CausesValidation="false"
                                                                    OnClientClick="return ConfirmDelete();" ImageUrl="~/images/delete.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" CausesValidation="false"
                                                                    ImageUrl="~/images/edit.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="vchDeviceNum" HeaderText="Device Name" 
                                                            ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="vchPort" HeaderText="Port" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="vchIp" HeaderText="IP" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel2">
                                <HeaderTemplate>
                                    Assigned ID
                                </HeaderTemplate>
                                <ContentTemplate>
                                 <table width="90%">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left" class="style1">
                                                            <asp:Label ID="Label2" runat="server" Text="Select School" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSchoolCard" runat="server" CssClass="textsize" 
                                                                AutoPostBack="True" onselectedindexchanged="ddlSchoolCard_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <br />
                                                <asp:GridView ID="grvCard" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False"
                                                    CssClass="mGrid" EmptyDataText="Record not Found."
                                                    PageSize="5" DataKeyNames="intCard_id" Width="50%" 
                                                    OnRowDeleting="grvCard_RowDeleting" onpageindexchanging="grvCard_PageIndexChanging"
                                                    >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" CausesValidation="false"
                                                                    OnClientClick="return ConfirmDelete();" ImageUrl="~/images/delete.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" CausesValidation="false"
                                                                    ImageUrl="~/images/edit.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="vchCardNo" HeaderText="ID Card" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel3">
                                <HeaderTemplate>
                                    Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious">
                                        <table width="48%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblDevice" runat="server" Text="Select Device Type" CssClass="textsize"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlDeviceType" runat="server" CssClass="textsize" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlDeviceType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="lblNoDevice" runat="server" Text="Select Number Of Device"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" 
                                                        OnCheckedChanged="chkAll_CheckedChanged" Text="All" CssClass="checkbox" 
                                                        />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" width="50%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="padding-right:13px" colspan="2">
                                                    <div style="overflow: scroll; width: 200px; height: 200px">
                                                        <asp:CheckBoxList ID="chkLst" runat="server" CssClass="textsize" AutoPostBack="True"
                                                            OnSelectedIndexChanged="chkLst_SelectedIndexChanged">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="left" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="textsize" Text="Select School"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlSchool" runat="server" CssClass="textsize">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="margin-left: 80px">
                                                    <asp:Button ID="btnSubmit" OnClientClick="return validation();" runat="server" OnClick="btnSubmit_Click"
                                                        Text="Assign" CssClass="efficacious_send" />
                                                </td>
                                                <td align="left" style="margin-left: 80px">
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                                        CssClass="efficacious_send" OnClick="btnCancel_Click" Text="Cancel" />
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

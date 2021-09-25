<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmSendGroupMsg.aspx.cs" Inherits="frmSendGroupMsg" Title="Message Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1
        {
        }
        .auto-style2
        {
        }
        .auto-style3
        {
            height: 20px;
        }
        .style1
        {
            height: 24px;
        }
        
            height: 25px;
        }
          
         .mGrid th{ text-align:center !important}
         .efficacious textarea{ width:97% !important}

    </style>

    <script type="text/javascript" language="javascript">
        function Scroll() {
            var txtChat = document.getElementById('<%=txtChat.ClientID %>');
            txtChat.scrollTop = txtChat.scrollHeight;
            return true;
        }


        window.onload = function() {

            var lblType = document.getElementById("<%=ddlType.ClientID %>").nodeValue;            
            var DropdownList = document.getElementById('<%=ddlType.ClientID %>');
            var SelectedIndex = DropdownList.selectedIndex;
            var SelectedValue = DropdownList.value;
            var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;


            setInterval(function callUserDetail() {
                $.ajax({

                    type: "POST",
                    url: "frmSendGroupMsg.aspx/OpenChat1",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function(response) {
                        alert('Inside Function')
                        alert(response.d);
                    }
                });


            }, 1000);


        }


        function StartChat() {

            var Msg = document.getElementById("<%=txtMsg.ClientID %>").value;
            if (Msg.trim() == '') {
                return false;
            }
            setInterval(function callChat() {
                $.ajax({

                    type: "POST",
                    url: "frmSendGroupMsg.aspx/OpenChat1",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function(response) {
                        alert(response.d);
                    }
                });

            }, 5000);
        }
        function OnSuccess(response) {
            if (response.d == 'false') {
                window.location = "../index/Default.aspx";
            }
            else {
                $('#<%= txtChat.ClientID%>').html(response.d.toString())
            }
        }


        

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:Timer runat="server" ID="UpdateTimer" Interval="10000" OnTick="UpdateTimer_Tick" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="1015px">
                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                    <HeaderTemplate>
                                        Send Message
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table width="60%">
                                                    <tr>
                                                        <td align="justify" class="style1">
                                                        </td>
                                                        <td class="style1" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify" class="auto-style2">
                                                            <asp:Label ID="Label1" runat="server" CssClass="textcss" Text="Select Type"></asp:Label>
                                                        </td>
                                                        <td class="auto-style2" colspan="2" align="left">
                                                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trSTD" runat="server" visible="False">
                                                        <td align="left" class="auto-style11" runat="server">
                                                            <asp:Label ID="lblStd" runat="server" CssClass="textcss" Text="STD"></asp:Label>
                                                        </td>
                                                        <td align="justify" class="auto-style5" colspan="2" runat="server">
                                                            <asp:DropDownList ID="ddlStd" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                OnSelectedIndexChanged="ddlStd_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trDiv" runat="server" visible="False">
                                                        <td align="left" class="auto-style3" runat="server">
                                                            <asp:Label ID="lblDiv" runat="server" CssClass="textcss" Text="DIV"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style3" colspan="2" runat="server">
                                                            <asp:DropDownList ID="ddlDiv" runat="server" CssClass="textsize" OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style3">
                                                            <asp:Label ID="lblDept" runat="server" CssClass="textcss" Text="Department"></asp:Label>
                                                        </td>
                                                        <td class="auto-style3" align="justify" colspan="2">
                                                            <asp:DropDownList ID="ddlDept" runat="server" CssClass="textsize" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style3">
                                                            <asp:Label ID="lblName" runat="server" CssClass="textcss" Text="Student"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style5" colspan="2">
                                                            <asp:DropDownList ID="ddlName" runat="server" CssClass="textsize" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style3" valign="top">
                                                            <asp:Label ID="lblChat" runat="server" CssClass="textcss" Text="Chat History"></asp:Label>
                                                            <br />
                                                        </td>
                                                        <td align="left" class="auto-style5" colspan="2">
                                                            <asp:TextBox ID="txtChat" runat="server" CssClass="textsize" Height="163px" TextMode="MultiLine"
                                                                Enabled="False" ReadOnly="True" MaxLength="50000"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblStudent3" runat="server" CssClass="textcss" Text="Enter Message"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style1" colspan="2">
                                                            <asp:TextBox ID="txtMsg" runat="server" CssClass="textsize" Height="58px" 
                                                                TextMode="MultiLine" MaxLength="50000"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style9">
                                                            <asp:Label ID="lblStudent7" runat="server" CssClass="textcss" Text="Attach Document"
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style9" colspan="2">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="textcss" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            &nbsp;<asp:HiddenField ID="PrivateChatActive" runat="server" />
                                                        </td>
                                                        <td align="center" class="auto-style1">
                                                            <asp:Button ID="btnSend" runat="server" CssClass="efficacious_send" OnClick="Button5_Click"
                                                                OnClientClick="return StartChat();" Text="Send Message" Width="50%" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </center>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" ID="tb">
                                    <HeaderTemplate>
                                        Group Message
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvChatDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="mGrid" OnRowCommand="grvChatDetail_RowCommand" Width="100%" AllowPaging="True"
                                                                OnPageIndexChanging="grvChatDetail_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="intGrpMem_Id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMemid" runat="server" Text='<% #Bind("intGrpMem_Id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Chat">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgChat" runat="server" CommandArgument='<% #Bind("intGroup_id") %>'
                                                                                CommandName="ImgCall" Height="26px" ImageUrl="~/images/group chat details.png"
                                                                                Width="28px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchGroup_name" HeaderText="Group Name" />
                                                                    <asp:BoundField DataField="intNotification" HeaderText="Notification" />
                                                                    <%--     <asp:TemplateField HeaderText="OwnMemId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOwnMemId" Text='<% #Bind("OwnMemId")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" ID="TabPanel2" Visible="false">
                                    <HeaderTemplate>
                                        Private Message
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <center>
                                                                <asp:GridView ID="grvPrivateMsg" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    CssClass="mGrid" OnRowCommand="grvPrivateMsg_RowCommand" Width="70%" AllowPaging="True"
                                                                    OnPageIndexChanging="grvPrivateMsg_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="intGrpMem_Id" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMemid" runat="server" Text='<% #Bind("intGrpMem_Id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Chat">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgChat" runat="server" CommandArgument='<% #Bind("intGroup_id") %>'
                                                                                    CommandName="ImgCall" Height="26px" ImageUrl="~/images/chat details.png" Width="37px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                        <asp:BoundField DataField="Department" HeaderText="Department" />
                                                                        <asp:BoundField DataField="STD" HeaderText="STD" />
                                                                        <asp:BoundField DataField="DIV" HeaderText="DIV" />
                                                                        <asp:BoundField DataField="intNotification" HeaderText="Notification" />
                                                                        <asp:TemplateField HeaderText="OwnMemId" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOwnMemId" Text='<%#Eval("OwnMemId") %>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </center>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

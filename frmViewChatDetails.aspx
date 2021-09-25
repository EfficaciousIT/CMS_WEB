<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmViewChatDetails.aspx.cs"
    Inherits="frmViewChatDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="sty/styles.css" rel="stylesheet" type="text/css" />
    <style>
        .ResizeDisable
        {
        }
   .efficacious_send {
  width: 130px;
  background: #3498db;
  border: none;
  font-size: 16px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
  color: #fff;
  margin: 10px auto;
  padding: 3px;
  cursor: pointer;
  height: 30px;
  float: left;
  text-align: center; margin-left:180px;
}
    </style>
</head>
<body>
    <script type="text/javascript" language="javascript">


        window.onload = function () {
            var textarea = document.getElementById('<%=txtChat.ClientID %>');
            textarea.scrollTop = textarea.scrollHeight;


        }

        function Scroll() {
            var textarea = document.getElementById('<%=txtChat.ClientID %>');
            textarea.scrollTop = textarea.scrollHeight;
        }

        function setFouc(con) {
            var text = document.getElementById('<%= txtMsg.ClientID%>');

            if (text != null && text.value.length > 0) {

                if (text.createTextRange) {

                    var FieldRange = text.createTextRange();
                    FieldRange.moveStart('character', text.value.length);
                    FieldRange.collapse();
                    FieldRange.select();
                }
            }
        }

    

    </script>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 5px 0 0 0; width: 850px">
                <center>
                    <table style="width: 650px">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table width="80%">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblStudent5" runat="server" CssClass="textcss" Text="View Members"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="ImgBtnView" runat="server" Height="21px" ImageUrl="~/images/group.jpg"
                                                        OnClick="ImageButton1_Click" Width="28px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblStudent8" runat="server" CssClass="textcss" Text="Chat History"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <div id="q" style="overflow:auto; height:200px; width:270px;   text-align: left; border: 1px solid #3498db;" >
                                                    <asp:TextBox ID="txtChat" runat="server" CssClass="textsize" Rows="15" TextMode="MultiLine" Height="200px"
                                                        Width="264px" Enabled="true" ReadOnly="True" Style="overflow: auto;"></asp:TextBox>
                                                     </div>
                                                    <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
                                                    </asp:Timer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblStudent6" runat="server" CssClass="textcss" 
                                                        Text="Attach Document" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:AsyncFileUpload ID="AttachFile" runat="server" CssClass="textsize" 
                                                     FailedValidation="False"
                                                                        OnUploadedComplete="FileUploadApp_UploadedComplete" OnClientUploadError="uploadError"
                                                                        OnClientUploadComplete="uploadComplete" 
                                                        UploaderStyle="Modern" CompleteBackColor="White"
                                                                        ThrobberID="imgLoader" Visible="False"/>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            </td>
                                                <td align="left" valign="top">
                                                    <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" 
                                                        Visible="False" />
                                                    <asp:Label ID="lblMesg" runat="server" CssClass="textsize" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblStudent4" runat="server" CssClass="textcss" Text="Enter Message"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMsg" style="border: 1px solid #3498db;" runat="server" CssClass="textsize" Height="58px" TextMode="MultiLine"
                                                        Width="264px" onfocus="setFouc(this)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="Center">
                                                    <asp:Button ID="btnMsg" runat="server" Text="Send Message" CssClass="efficacious_send" OnClick="btnMsg_Click"
                                                        OnClientClick="Scroll();"  />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

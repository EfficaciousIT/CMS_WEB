<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PushpinsClickEvent.aspx.cs" Inherits="Samples_PushpinClickEvent" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Google Map with draggable pushpins</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <h3><a href="Default.aspx">Back</a></h3>
    <h3>Pushpin click event example.</h3>
    Click any pushpin and see changed position value at bottom of page. See <b>OnPushpinCliked()</b> event in source code.
    <br />
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Last Pushpin Clicked : <asp:Label ID="lblLastPushpin" runat="server" Text="" ForeColor="Red" Font-Bold=true></asp:Label><br />
            Position : <asp:Label ID="lblPushpin1" runat="server" Text="" ForeColor="Blue" Font-Bold=true></asp:Label><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
        <h3><a href="Default.aspx">Return to Samples Index</a></h3>

</body>
</html>

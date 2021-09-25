<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="feecollection.aspx.cs" Inherits="feecollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script language="javascript" type="text/javascript">
    function resizeIframe(obj) {
        obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px';
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <iframe id="frame1" style="border:none;height:376px; width:100%" src="frmFeeCol.aspx" scrolling="auto" runat="server" ></iframe>
            </td>
        </tr>
    </table>
</asp:Content>

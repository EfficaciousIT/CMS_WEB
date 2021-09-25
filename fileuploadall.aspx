<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="fileuploadall.aspx.cs" Inherits="fileuploadall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function UploadFile(fileUpload) {
        if (fileUpload.value != '') {
            document.getElementById("<%=btnUpload.ClientID %>").click();
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<head>
<body>
<table>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label ID="lblMessage" runat="server" Text="File uploaded successfully." ForeColor="Green"
    Visible="false" />
<asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />

</table>
</body>
</head>
</asp:Content>


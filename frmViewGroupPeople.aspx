<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmViewGroupPeople.aspx.cs" Inherits="frmViewGroupPeople" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="sty/styles.css" rel="stylesheet" type="text/css" />
    <style>
    
    th{ text-align:center; background:rgb(3, 116, 3); color:#fff;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div style="padding: 5px 0 0 0; width:850px" >
            <center>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
    <table style="width:650px">
        <tr >
            <td>
                <asp:GridView ID="grvViewDetail" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" CssClass="mGrid" PageSize="20" Width="100%" 
                    AllowPaging="True" onpageindexchanging="grvViewDetail_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Type" HeaderText="Type" />
                        <asp:BoundField DataField="Department" HeaderText="Department" />
                        <asp:BoundField DataField="StaffName" HeaderText="Staff Name" />
                        <asp:BoundField DataField="STD" HeaderText="STD" />
                        <asp:BoundField DataField="DIV" HeaderText="DIV" />
                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                        <asp:BoundField DataField="ParentName" HeaderText="Parent Name" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </ContentTemplate>
     </asp:UpdatePanel>
                  </center>
        </div>

    </form>
</body>
</html>

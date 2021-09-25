<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Absentsummary.aspx.cs" Inherits="Absentsummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style12.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <tr>
                            <td>
                                <div class="excel">
                                    <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" ImageUrl="~/images/xlsImg.gif"
                                        runat="server" OnClick="ImgXls_Click" />
                                </div>
                            </td>
                        </tr>
        <center>
            <asp:GridView ID="grdDet" runat="server" CssClass="table  tabular-table " EmptyDataText="No Details Available"
                Width="50%">
            </asp:GridView>
        </center>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmRawDataDet.aspx.cs" Inherits="frmRawDataDet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 1px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGrid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            text-align: left;
            color: #717171;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            text-align: left;
            background: rgb(3, 116, 3);
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .mGrid tr
        {
            height: 21px;
        }
        .mGrid .alt
        {
            background: #fff;
        }
        .mGrid .pgr
        {
            background: #424242;
        }
        .mGrid .pgr table
        {
            margin: 5px 0;
        }
        .mGrid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGrid .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGrid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" CssClass="mGrid" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>

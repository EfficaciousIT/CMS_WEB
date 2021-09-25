<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTeachPreDetail.aspx.cs" Inherits="frmTeachPreDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

        <title>E-SMS</title>

    <link href="css/style.css" rel="stylesheet" type="text/css"/>
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>

    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="sty/styles.css" rel="stylesheet" type="text/css" />

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <script src="sty/script.js"></script>
        <style type="text/css">
            .style1
            {
                height: 16px;
            }
            </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
  <table style="font-weight: bolder; width: 500px; margin: 10px 0;" align="center">
                                                        <tr>
                                                            <td align="center" colspan="3" class="style1">
                                                                <asp:Label ID="Label4" runat="server" Font-Bold="False" CssClass="textheadcss">Attendance Report</asp:Label>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>

                                                        <tr><td colspan="3"></td></tr>
                                                        <tr><td align="left"><asp:Label ID="lblvchno" runat="server" Font-Bold="False" >Roll No</asp:Label>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="False">s1002</asp:Label></td>
                                                        
                                                        
                                                        <td align="left" Width="100px" nowrap="nowrap"><asp:Label ID="Label3" runat="server" Font-Bold="False">Name</asp:Label>&nbsp;&nbsp;
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="False">Manu Sharma</asp:Label>
                                                        </td>
                                                        <td Width="100px">&nbsp;</td>
                                        </tr>
                                        <tr><td colspan="3">
                                            <br />
                                            </td></tr>
                                        <tr><td colspan="3"></td></tr>
                                                        <tr id="allid" runat="server" >
                                                            <td id="Td1" runat="server" colspan="5">
                                                                <asp:GridView ID="GridViewPADe" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                                                    Width="820px">
                                                                    <Columns>
                                    <%--<asp:BoundField DataField="dtRollNo" HeaderText="Roll No" ReadOnly="True" >
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dtName" HeaderText="Name" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InTime" HeaderText="In Time" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OutTime" HeaderText="OutTime" 
                                        ReadOnly="True">                                 
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                                 </td>
                                                        </tr>
                                                      
                                                    </table>
<%--</asp:Content>--%>
</center>
    </div>
    </form>
</body>
</html>


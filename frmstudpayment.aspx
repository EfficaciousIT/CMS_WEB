<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmstudpayment.aspx.cs" Inherits="frmpayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Table tr td{ width:25%;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="Table">
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblstudentId" runat="server" Text="Student ID" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtstudentID" runat="server" placeholder="Enter Student Number" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
              <td>
            </td>
             <td>
                <asp:Label ID="lblsttudnm" runat="server" Text="Student Name" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtStudnm" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
              <td>
            </td>
        </tr>
           <tr>
               <td>
            </td>
             <td>
                <asp:Label ID="lblstand" runat="server" Text="Standard" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtStad" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
                 <td>
            </td>
        </tr>
           <tr>
                <td>
            </td>
             <td>
                <asp:Label ID="lblDiv" runat="server" Text="Division" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDiv" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
                 <td>
            </td>
        </tr>
           <tr>
               <td>
            </td>
             <td>
                <asp:Label ID="lblParentnm" runat="server" Text="Parent Name" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtParennm" runat="server" placeholder="Enter Parent Name"></asp:TextBox>
            </td>
                 <td>
            </td>
        </tr>
        <tr>
              <td>
            </td>
             <td>
                <asp:Label ID="lblemailid" runat="server" Text="Email ID" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtemailID" runat="server" placeholder="Enter Email Address"></asp:TextBox>
            </td>
              <td>
            </td>
        </tr>
         <tr>
               <td>
            </td>
             <td>
                <asp:Label ID="lblBanknm" runat="server" Text="Name of the bank" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbanknm" runat="server" placeholder="Enter Bank Name"></asp:TextBox>
            </td>
               <td>
            </td>
        </tr>
         <tr>
               <td>
            </td>
             <td>
                <asp:Label ID="lblpayamt" runat="server" Text="Payment Amount" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpayamt" runat="server" placeholder="Enter Payment Amount" ReadOnly="true"></asp:TextBox>
            </td>
               <td>
            </td>
        </tr>
              <tr>
                    <td>
            </td>
             <td>
                <asp:Label ID="lblpayrefno" runat="server" Text="Payment Refernce No." ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpayrefno" runat="server" placeholder="Enter Payment Reference Number"></asp:TextBox>
            </td>
                    <td>
            </td>
        </tr>
              <tr>
                    <td>
            </td>
             <td>
                <asp:Label ID="lblremark" runat="server" Text="Remak" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRemark" runat="server" placeholder="Enter Remark"></asp:TextBox>
            </td>
                    <td>
            </td>
        </tr>
         <tr>
                    <td>
            </td>
             <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
                    <td>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
            <b>Please Note :</b>
                </td>
            <td>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
            <asp:Label ID="label" runat="server" Text="1.Our Bankn Details:"></asp:Label>
                </td>
            <td> <asp:Label ID="label1" runat="server" Text="HDFC Bank Ltd., Barrackpore Branch"></asp:Label>
            </td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td>
            <asp:Label ID="label2" runat="server" Text=" Account No."></asp:Label>
                </td>
            <td> <asp:Label ID="label3" runat="server" Text="07121450000080"></asp:Label>
            </td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td>
            <asp:Label ID="label4" runat="server" Text=" RTGS/NEFT IFSC :"></asp:Label>
                </td>
            <td> <asp:Label ID="label5" runat="server" Text="HDFC0000712"></asp:Label>
            </td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
            <asp:Label ID="label6" runat="server" Text="2. Please send a copy of the Payment ref no. on centralmodel2020@gmail.com "></asp:Label>
                </td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
            <asp:Label ID="label8" runat="server" Text="3. For any clearification please connect with Mr. Sujoy @. 9046569705"></asp:Label>
                </td>
            <td></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmReAdmissionForm.aspx.cs" Inherits="frmReAdmissionForm" %>

<!doctype html>

<html lang="en">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="css/StudentFeemain.css">
   
     <script type="text/javascript">
         function allowOnlyNumber(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }
    </script>

</head>

<body>

    <div class="container-contact100">

        <div class="wrap-contact100">

            <img class="central_model-logo" src="images/central_model-logo-sm1.png" />
            <hr>
            <h4 class="contact100-form-adderess">23 Riverside Road, Kolkata 700120</h4>
           
            <form class="contact100-form" id="form1" runat="server">

                <h5 class="contact100-form-adderess"><asp:Label ID="lblAdm" runat="server" Text="Re-Admission Form" Font-Bold="true"></asp:Label></h5>
                <hr>
                <div class="wrap-input100">
					<span class="label-input100"> <asp:Label ID="lbsystemId" runat="server" Text="System ID"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtsystemID" runat="server" placeholder="Enter System ID" ReadOnly="true"></asp:TextBox>
					<span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
					<span class="label-input100"> <asp:Label ID="lblstudentId" runat="server" Text="Student ID"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtstudentID" runat="server" placeholder="Enter Student Number" ReadOnly="true"></asp:TextBox>
					<span class="focus-input100"></span>
                </div>
                
                <div class="wrap-input100">
					<span class="label-input100"> <asp:Label ID="lblsttudnm" runat="server" Text="Student Name"></asp:Label> </span>
                    <asp:TextBox class="input100"  ID="txtStudnm" runat="server" ReadOnly="true"></asp:TextBox>
					<span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
					<span class="label-input100"> <asp:Label ID="lblstand" runat="server" Text="Standard"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtStad" runat="server" ReadOnly="true"></asp:TextBox>
					<span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
					<span class="label-input100">  <asp:Label ID="lblDiv" runat="server" Text="Division"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtDiv" runat="server" ReadOnly="true"></asp:TextBox>
					<span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
                    <span class="label-input100"> <asp:Label ID="lblParentnm" runat="server" Text="Parent Name"></asp:Label> </span>
                    <asp:TextBox class="input100"  ID="txtParennm" runat="server" placeholder="Enter Parent Name" ReadOnly="true"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
                    <span class="label-input100"> <asp:Label ID="Label9" runat="server" Text="Address"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="TextBox2" runat="server" placeholder="" ReadOnly="true"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>

                <div class="wrap-input100">
                    <span class="label-input100"> <asp:Label ID="lblemailid" runat="server" Text="Email ID"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtemailID" runat="server" placeholder="Enter Email Address"></asp:TextBox>
                    <span class="focus-input100"></span>
                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemailID" ValidationGroup="b" Display="None" ErrorMessage="Please Enter Email ID" Font-Bold="False" InitialValue=""></asp:RequiredFieldValidator>
                    
                </div>

                <div class="wrap-input100">
                    <span class="label-input100"> <asp:Label ID="lblBanknm" runat="server" Text="Name of the bank"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtbanknm" runat="server" placeholder="Enter Bank Name"></asp:TextBox>
                    <span class="focus-input100"></span>
                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbanknm" ValidationGroup="b" Display="None" ErrorMessage="Please Enter Bank Name" Font-Bold="False" InitialValue=""></asp:RequiredFieldValidator>
                   
                </div>

                <div class="wrap-input100">
                    <span class="label-input100">  <asp:Label ID="Label7" runat="server" Text="Amount to be Paid"></asp:Label> </span>
                    <asp:TextBox class="input100" ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                    <span class="focus-input100"></span>
                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpayamt" ValidationGroup="b" Display="None" ErrorMessage="Please Enter Payment Amount" Font-Bold="False" InitialValue=""></asp:RequiredFieldValidator>
                </div>


                <div class="wrap-input100">
                    <span class="label-input100">   <asp:Label ID="lblpayamt" runat="server" Text="Amount Paid"></asp:Label> </span>
                    <asp:TextBox class="input100"  ID="txtpayamt" runat="server" placeholder="Enter Paid Amount" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                    <span class="focus-input100"></span>
                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator3" runat="server"                               ControlToValidate="txtpayamt" ValidationGroup="b" Display="None"  ErrorMessage="Please Enter Payment Amount" Font-Bold="False" InitialValue=""></asp:RequiredFieldValidator>
                </div>


                <div class="wrap-input100">
                    <span class="label-input100">  <asp:Label ID="lblpayrefno" runat="server" Text="Payment Reference No."></asp:Label> </span>
                    <asp:TextBox class="input100" ID="txtpayrefno" runat="server" placeholder="Enter Payment Reference Number">
                    </asp:TextBox>
                    <span class="focus-input100"></span>
                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpayrefno" ValidationGroup="b" Display="None" ErrorMessage="Please Enter Payment Reference Number" Font-Bold="False" InitialValue=""></asp:RequiredFieldValidator>
                </div>

                <div class="wrap-input100">
					<span class="label-input100"> <asp:Label ID="lblremark" runat="server" Text="Remark"></asp:Label></span>
                    <asp:TextBox class="input100" ID="txtRemark" runat="server" placeholder="Enter Remark..."></asp:TextBox>
					<span class="focus-input100"></span>
                </div>
                
                <div class="wrap-input100">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="b" onclick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />
                </div>

                <div class="note">
                    <h4>Please Note :</h4>
                    <ol>
                        <li>
                            <asp:Label ID="label" runat="server" Text="Our Bank Details:"></asp:Label>
                            <hr>
                            <asp:Label ID="label1" runat="server" Text="HDFC Bank Ltd., Barrackpore Branch"></asp:Label>
                            <hr>
                            <asp:Label ID="label2" runat="server" Text=" Account No."></asp:Label>
                            <asp:Label ID="label3" runat="server" Text="07121450000080"></asp:Label>
                            <hr>
                            <asp:Label ID="label4" runat="server" Text=" RTGS/NEFT IFSC :"></asp:Label>
                            <asp:Label ID="label5" runat="server" Text="HDFC0000712"></asp:Label>
                            <hr>
                        </li>
    
                        <li><asp:Label ID="label6" runat="server" Text="">Please send a copy of the Payment ref no. on <strong><a href="mailto:centralmodel2020@gmail.com">centralmodel2020@gmail.com</a> </strong></asp:Label></li>
    
                        <li>
                            <asp:Label ID="label8" runat="server" Text="">For any clarification please connect with Mr. Sujoy @. <strong><a href="tel:+919046569705">9046569705</a> </strong></asp:Label>
                        </li>
                    </ol>

                </div>

                




            </form>




        </div>

    </div>



</body>

</html>
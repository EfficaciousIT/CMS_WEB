<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contactUs.aspx.cs" Inherits="login_contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!-- InstanceBegin template="/Templates/master.dwt" codeOutsideHTMLIsLocked="false" -->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <!-- InstanceBeginEditable name="doctitle" -->
    <title>e-Smarts - School bus tracking system</title>
    <meta name="description" content="Advanced Tools for school management and functioning">
    <meta name="keywords" content="fees management software for schools, Web based library management system, school bus monitoring system, rfid based student attendance system">
    <!-- InstanceEndEditable -->
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css">
    <link href="css/animate.min.css" rel="stylesheet">
    <script language="javascript" type="text/javascript">
        function TopicValidation() {
            var drpUserType = document.getElementById("<%=drpUserType.ClientID %>").value;
            var txtUserName = document.getElementById("<%=txtUserName.ClientID %>").value;
            var txtPassword = document.getElementById("<%=txtPassword.ClientID %>").value;
            if (drpUserType == '---Select---') {
                alert('Please Select User Type');
                return false;
            }
            if (txtUserName == '') {
                alert('Please Enter Username');
                return false;
            }
            else if (txtPassword.trim() == '') {
                alert('Please Enter Password');
                return false;
            }
            return true;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function ContactValidation() {
            var txtSchoolname = document.getElementById("<%=txtSchoolname.ClientID %>").value;
            var txtcontactPerson = document.getElementById("<%=txtcontactPerson.ClientID %>").value;
            var txtPhone = document.getElementById("<%=txtPhone.ClientID %>").value;
            if (txtSchoolname == '') {
                alert('Please Enter School Name');
                return false;
            }
            if (txtcontactPerson == '') {
                alert('Please Enter Contact Person Name');
                return false;
            }
            else if (txtPhone.trim() == '') {
                alert('Please Enter Phone Number');
                return false;
            }
            return true;
        }
    </script>
       <script type="text/javascript">
           function disableRightClick() {
               alert("Sorry, right click is not allowed !!");
               return false;
           } 
</script> 
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body oncontextmenu=" return disableRightClick();">
    <form runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <header>
  <div class="container headerbg" >
    <div class="logo"> <img src="img/logo.png"> </div>
  </div>
</header>
    <!-- InstanceBeginEditable name="head" -->
    <nav class="navbar navbar-default ">
  <div class="container"> 
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
      <a class="navbar-brand menu-responsive" href="#">Menu</a> </div>
    
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li> <a href="index.aspx">home </a> </li>
        <li> <a href="AboutUs.aspx" >About </a> </li>
        <li> <a href="features.aspx" >Features</a> </li>
        <li> <a href="howitswork.aspx">how it works</a> </li>
        <li> <a href="contactUs.aspx" class="active">Contact</a> </li>
        <li> <a href="#" data-toggle="modal" data-target="#login">Login</a> </li>
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>
    <div class="map">
        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d942.7347012173374!2d73.0084684045817!3d19.0664280006685!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sin!4v1439456280439"
            width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen>
        </iframe>
    </div>
    <div class="container contactbox">
        <div class="clearfix">
        </div>
        <div class="col-md-4">
            <div class="contact_form">
                <h3 class="primary">
                    Contact form</h3>
                <div class="alert alertbox alert-danger fade in" style="display: none">
                    <a href="#" class="closes" data-dismiss="alert">&times;</a> Enter your Your Name
                </div>
                <fieldset>
                    <asp:TextBox ID="txtSchoolname" CssClass="input-blue" placeholder="School Name" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtcontactPerson" CssClass="input-blue" placeholder="Contact Person" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtPhone" CssClass="input-blue" placeholder="Phone" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" CssClass="input-blue" placeholder="Email" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtAddress" CssClass="input-blue" placeholder="Address" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtState" CssClass="input-blue" placeholder="State" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtCity" CssClass="input-blue" placeholder="City" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtRemark" CssClass="input-blue" placeholder="Remark" runat="server"></asp:TextBox>
                    <%--<input type="text" class="input-blue" name="name" value="" placeholder="Name">
                    <input type="text" class="input-blue" name="email" value="" placeholder="email">
                    <input type="text" class="input-blue" name="phone" value="" placeholder="Phone">
                    <textarea name="message" class="input-blue" placeholder="Message"></textarea>--%>
                    <div class="link">                        
                        <asp:Button ID="btnSumitEnquiry" OnClick="btnSumitEnquiry_Click1" OnClientClick="return ContactValidation();" CausesValidation="false"
                        CssClass="input-blue-button" runat="server" Text="Submit" />
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="col-md-8">
            <h3 class="primary">
                Address</h3>
            <div class="col-md-6 nopadding">
                <h5 class="primary">
                    <strong>Head Office</strong></h5>
                <div class="col-md-2 nopadding fa-icon text-center">
                    <i class="fa fa-map-marker"></i>
                </div>
                <div class="col-md-8 nopadding">
                    <div class="address">
                        <h5>
                            1402, G Square Business Park, Plot 25 & 26, Sector 30, Opp. Sanpada Station, Vashi,
                            Navi Mumbai Pin – 400703</h5>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <div class="col-md-2 nopadding fa-icon text-center">
                    <i class="fa fa-phone"></i>
                </div>
                <div class="col-md-8 nopadding">
                    <div class="address">
                        <h5>
                            phone: +91-22-49707524</h5>
                        E-mail: <a href="mailto:info@efficacious.co.in">info@efficacious.co.in</a>
                    </div>
                </div>
            </div>
            <div class="col-md-6 nopadding">
                <h5 class="primary">
                    <strong>Branch Office</strong></h5>
                <div class="col-md-2 nopadding fa-icon text-center">
                    <i class="fa fa-map-marker"></i>
                </div>
                <div class="col-md-8 nopadding">
                    <div class="address">
                        <h5>
                           Ek Tower 8th Floor, Room No.801, Plot No.IID, 30,
Street Number 692, Action Area IID, Newtown Kolkata,
Near Akhankha More Bus Stop, West Bengal 700161</h5>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <div class="col-md-2 nopadding fa-icon text-center">
                    <i class="fa fa-phone"></i>
                </div>
                <div class="col-md-8 nopadding">
                    <div class="address">
                        <h5>
                            phone: +91-22-49707524</h5>
                        E-mail: <a href="mailto:info@efficacious.co.in">info@efficacious.co.in</a></div>
                </div>
            </div>
        </div>
    </div>
    <!-- InstanceEndEditable -->
    <div class="modal fade" id="login" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <img src="img/logo.png">
                </div>
                <div class="modal-body">
                    <%--<div class="alert alertbox alert-danger fade in" style="display: none">
                        <a href="#" class="closes" data-dismiss="alert">&times;</a> Enter your User Name
                    </div>--%>
                    <%--<select name="ctl00$drpUserType" id="ctl00_drpUserType" class="input-blue">
                        <option value="---Select---">---Select---</option>
                        <option value="Student">Student</option>
                        <option value="Parent">Parent</option>
                        <option value="Teacher">Teacher</option>
                        <option value="Staff">Staff</option>
                        <option value="Administrator">Administrator</option>
                    </select>--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                     <asp:DropDownList ID="drpSchool" CssClass="input-blue" runat="server"  AutoPostBack="True" onselectedindexchanged="drpSchool_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                   
                    </asp:DropDownList>
                    <asp:DropDownList ID="drpUserType" CssClass="input-blue" runat="server">
                    </asp:DropDownList>
                    <%--<input type="text" class="input-blue" placeholder="User Name" />--%>
                    <asp:TextBox ID="txtUserName" CssClass="input-blue" placeholder="User Name" runat="server"></asp:TextBox>
                    <%--<input type="text" class="input-blue" placeholder="Password" />--%>
                    <asp:TextBox ID="txtPassword" CssClass="input-blue" TextMode="Password" placeholder="Password"
                        runat="server"></asp:TextBox>
                    <%--<button type="button" class="input-blue-button">
                        Login</button>--%>
                    <asp:Button ID="btnSubmit" CausesValidation="false" OnClick="btnSubmit_Click1" OnClientClick="return TopicValidation();"
                        CssClass="input-blue-button" runat="server" Text="Log in" />
                         </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
  <div class="container">
    <div class="row">
      
       <div class="col-md-4">
        <ul class="footerlink">
        <li> <a href="index.aspx" class="active">Home </a> </li>
         <li> <a href="AboutUs.aspx">About </a> </li>
        <li> <a href="features.aspx">Features</a> </li>
        <li> <a href="howitswork.aspx">How it Works</a> </li>
        <li>  <a href="contactUs.aspx">Contact</a> </li>
        <li> <a href="#">Login</a> </li>
      </ul>
      
      
      </div>
      <div class="col-md-4">
        <div class="col-md-2 fa-icon"><i class="fa fa-map-marker"></i></div>
        <div class="col-md-10">
          <div class="box_aside"> <span id="adress">E-smarts<br>
            1402, G Square Business Park,<br>
            Plot 25 & 26, Sector 30,<br>
            Opp. Sanpada Station,<br>
            Vashi, Navi Mumbai Pin – 400703</span> </div>
        </div>
        <div class="clearfix"></div>
        <div class="box_aside" style="margin-top:30px;">
          <div class="col-md-2 fa-icon"><i class="fa fa-phone"></i></div>
          <div class="col-md-10"><span id="phone">Tellephone :  +91-22-49707524 </span><br>
            <span id="email"> E-mail: <a href="mailto:info@efficacious.co.in">info@efficacious.co.in</a></span> </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="box_aside" id="social_block"> E-SMARTS &nbsp; © <span id="copyright-year">2015</span> | <a class="footer_link" href="index.aspx">Privacy Policy</a> 
          <!-- {%FOOTER_LINK} -->
          <div class="social">
            <div class="soc_network"><a class="fa fa-facebook" href="https://www.facebook.com/efficacioustech/?fref=ts"></a> </div>
            <div class="soc_network"><a class="fa fa-rss" href="#"></a> </div>
             <div class="soc_network"><a class="fa fa-twitter" href="https://twitter.com/EfficaciousInd"></a> </div>
            <div class="soc_network"><a class="fa fa-google-plus" href="https://plus.google.com/104956629708822726442"></a> </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</footer>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/custom.js"></script>
    <script src="js/TweenMax.min.js"></script>
    <script src="js/ScrollToPlugin.min.js"></script>
    <script src="js/wow.min.js"></script>
    </form>
</body>
<!-- InstanceEnd -->
</html>

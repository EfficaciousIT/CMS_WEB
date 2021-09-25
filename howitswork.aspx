<%@ Page Language="C#" AutoEventWireup="true" CodeFile="howitswork.aspx.cs" Inherits="login_howitswork" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!-- InstanceBegin template="/Templates/master.dwt" codeOutsideHTMLIsLocked="false" -->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <!-- InstanceBeginEditable name="doctitle" -->
    <title>e-Smarts - Fees management software for schools</title>
    <meta name="description" content="student tracking system, Web based library management system, student attendance system, school bus tracking system, fee management software">
    <meta name="keywords" content="students attendance management system, school bus monitoring system, School library management system, school fees collection software">
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
    <div class="logo"> <img src="img/logoBig.png"> </div>
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
        <li> <a href="howitswork.aspx" class="active">how it works</a> </li>
        <li> <a href="contactUs.aspx">Contact</a> </li>
        <li> <a href="#" data-toggle="modal" data-target="#login">Login</a> </li>
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>
    <div class="container howit-works">
        <h2>
            how it works</h2>
        <p class="tag-p" style="display: none">
            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
            Ipsum has been the industry's standard dummy text ever since the 1500s, when an
            unknown printer took a galley of type and scrambled it to make a type specimen book.
        </p>
        <hr>
        <div class="col-md-12 nopadding">
            <div class=" col-md-2" style="vertical-align: middle">
                <img src="img/Howitswork.jpg"></div>
            <div class="col-md-10" style="display: none">
                <h3>
                    Lorem Ipsum is simply dummy text of the printing and typese</h3>
                <p>
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                    Ipsum has been the industry's standard dummy text ever since the 1500s, when an
                    unknown printer took a galley of type and scrambled it to make a type specimen book.
                </p>
                <ul class="howit-works-ulli">
                    <li>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</li>
                    <li>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</li>
                    <li>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</li>
                </ul>
            </div>
        </div>
        <div class="clearfix">
        </div>
        <hr>
        <div class="col-md-12 nopadding" style="display: none">
            <div class=" col-md-2">
                <img src="img/how-it-works/Information.png"></div>
            <div class="col-md-10">
                <h3>
                    Lorem Ipsum is simply dummy text of the printing and typese</h3>
                <p>
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                    Ipsum has been the industry's standard dummy text ever since the 1500s, when an
                    unknown printer took a galley of type and scrambled it to make a type specimen book.
                </p>
                <ul class="howit-works-ulli">
                    <li>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</li>
                    <li>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</li>
                    <li>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</li>
                </ul>
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
                    <img src="img/logoBig.png">
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
                        <%--<asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>Student</asp:ListItem>
                        <asp:ListItem>Parent</asp:ListItem>
                        <asp:ListItem>Teacher</asp:ListItem>
                        <asp:ListItem>Staff</asp:ListItem>
                        <asp:ListItem>Administrator</asp:ListItem>--%>
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
        <li> <a href="index.aspx" class="active">home </a> </li>
         <li> <a href="AboutUs.aspx">About </a> </li>
        <li> <a href="features.aspx">Features</a> </li>
        <li> <a href="howitswork.aspx">how it works</a> </li>
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

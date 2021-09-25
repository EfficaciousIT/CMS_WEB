<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="login_index" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">
<!-- InstanceBegin template="/Templates/master.dwt" codeOutsideHTMLIsLocked="false" -->
<head>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <!-- InstanceBeginEditable name="doctitle" -->
    <title>E-Smarts - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management</title>
    <meta name="description" content="
e-Smarts is a powerful platform to manage school operations such as fees management, syllabus management, exam scheduling, time table management, school attendance, notifications, school bus tracking, bus attendance, library management, notice board, leave management
">
    <meta name="keywords" content="student attendance management system, school bus tracking, School library management system, fees management system, school result software, leave management system, online leave management system">
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
     <%--<script type="text/javascript">
         function disableRightClick() {
             alert("Sorry, right click is not allowed !!");
             return false;
         } 
</script>--%> 
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
        <li> <a href="index.aspx" class="active">home </a> </li>
        <li> <a href="AboutUs.aspx">About </a> </li>
        <li> <a href="features.aspx">Features</a> </li>
        <li> <a href="howitswork.aspx">how it works</a> </li>
        <li> <a href="contactUs.aspx">Contact</a> </li>
        <li> <a href="#" data-toggle="modal" data-target="#login">Login</a> </li>
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>

<ul class="brochure">
  <li>
    <a class="fa fa-file-pdf-o fa-2x" href="pdf/Health-Card.pdf" target="_blank">    
      <span>Health Record Card</span>
    </a> 
  </li>
</ul>

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
        </ol>
        <div class="carousel-inner">
            <div class="item active">
                <img src="img/slider/bg1.jpg">
                <div class="container">
                    <div class="carousel-caption">
                        <h1>
                            Ease for schools,<br>
                            peace for parents</h1>
                        <p>
                            <a class="btn enquire btn-lg btn-primary" href="#" role="button" data-toggle="modal"
                                data-target="#enquire">enquire now</a></p>
                    </div>
                </div>
            </div>
            <div class="item">
                <img src="img/slider/bg3.jpg">
                <div class="container">
                    <div class="carousel-caption">
                        <h1>
                            Ease for schools,<br>
                            peace for parents</h1>
                        <p>
                            <a class="btn enquire btn-lg btn-primary" href="#" role="button" data-toggle="modal"
                                data-target="#enquire">enquire now</a></p>
                    </div>
                </div>
            </div>
        </div>
        <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left">
        </span></a><a class="right carousel-control" href="#myCarousel" data-slide="next"><span
            class="glyphicon glyphicon-chevron-right"></span></a>
    </div>
    <div class="container">
        <ul class="details-div">
            <li class="wow fadeInDown " data-wow-duration="1000ms" data-wow-delay="300ms">
                <div class="bgbox">
                    <div class="imgbox">
                        <img src="img/icon/school.png"></div>
                    <h4>
                        school</h4>
                </div>
                <p>
                    E-Smarts offers variety of dashboards to school management to monitor and manage
                    daily school operations with ease. It covers almost all aspects of school management
                    such as automation of fee payment, admission and other processes, security (through
                    the latest RFID system), scheduling of all school events like examinations, events,
                </p>
                <a href="schoolfeesmanagement.aspx">Read More...</a> </li>
            <li class="wow fadeInDown " data-wow-duration="1000ms" data-wow-delay="300ms">
                <div class="bgbox">
                    <div class="imgbox">
                        <img src="img/icon/teachers.png"></div>
                    <h4>
                        teachers</h4>
                </div>
                <p>
                    E-Smarts is the latest <strong>RFID school management system</strong> and holds
                    tremendous benefits for teachers, students, school administrators and parents in
                    many modern ways.
                    <br>
                    The software provides for the best-in-class teacher assistance framework and helps
                    the teacher to save both time and efforts so that he/she can channelize his/her
                    energy in
                </p>
                <a href="Teacher.aspx">Read More...</a> </li>
            <li class="wow fadeInDown " data-wow-duration="1000ms" data-wow-delay="300ms">
                <div class="bgbox">
                    <div class="imgbox">
                        <img src="img/icon/parents.png"></div>
                    <h4>
                        parents</h4>
                </div>
                <p>
                    E-Smarts is a new<strong> RFID School Management System</strong> and employs the
                    latest radio frequency technology for tracking student movements. It also has a
                    host of other features that benefit school administrators, students, parents and
                    teachers alike.
                    <br>
                    Our modern and state-of-the-art E-Smarts school-management system holds tremendous
                    advantages</p>
                <a href="Parent.aspx">Read More...</a> </li>
            <li class="wow fadeInDown " data-wow-duration="1000ms" data-wow-delay="300ms">
                <div class="bgbox">
                    <div class="imgbox">
                        <img src="img/icon/students.png"></div>
                    <h4>
                        students</h4>
                </div>
                <p>
                    Our E-Smarts dynamic school management system holds tremendous advantages for school
                    students. Through the system they can improve their attendance levels, easily view
                    their performance related data in academic and other school activities and improve
                    in a timely manner. They can also share and download teacher-issued notes online
                </p>
                <a href="Student.aspx">Read More...</a> </li>
        </ul>
    </div>
    <section class="about-us">
  <div class="container">
    <div class="col-md-4 about-logo"><img src="img/logo.png"></div>
    <div class="col-md-8">
      <h3 class="sinlge-skill ">About e-smarts</h3>
      <p>E-Smarts is the latest technological breakthrough in the field of automated school management and student tracking through radio frequency. E-Smarts, school management system, uses RFID technology (or radio frequency identification) for tracking the movements of students on the school campus (in predefined areas) and during home-school transits. The technologically superior system ensures their well being and safety and also offers a myriad range of benefits to school management, teachers, parents and students to perform better in their respective areas of activities.   </p>
      <a  href="AboutUs.aspx"> Read More...</a>
    </div>
  </div>
</section>
    <section class="Features">
  <div class="container">
    <h3>Features</h3>
    <p>E-SMARTs offers more than a dozen features that can be <br>
      managed from web interface or our mobile app. </p>
    <ul class="Features-ul-li Features-1">
      <li>
        <div class="inner-box"> <img src="img/features/Attendance-Module.png">
          <h4>Attendance Module</h4>
        </div>
      </li>
      <li>
        <div class="inner-box"> <img src="img/features/Transport-Module.png">
          <h4>Transport Module</h4>
        </div>
      </li>
      <li>
        <div class="inner-box"> <img src="img/features/Security-Module.png">
          <h4>Security Module</h4>
        </div>
      </li>	
    </ul>
    <ul class="Features-ul-li Features-2">
      <li>
        <div class="inner-box"> <img src="img/features/dashboard.png">
          <h4>Dash Boards </h4>
        </div>
      </li>
      <li>
        <div class="inner-box"> <img src="img/features/Profile-Management.png">
          <h4>Profile Management</h4>
        </div>
      </li>
      
    </ul>
  </div>
</section>
    <div class="modal fade" id="enquire" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <img src="img/logoBig.png">
                </div>
                <div class="modal-body">
                    <div class="alert alertbox alert-danger fade in">
                        <a href="#" class="closes" data-dismiss="alert">&times;</a> Enter your Your Name
                    </div>
                    <fieldset>
                        <input type="text" class="input-blue" name="name" value="" placeholder="Name">
                        <%--<asp:TextBox ID="txtUserName" CssClass="input-blue" placeholder="Name" runat="server"></asp:TextBox>--%>
                        <input type="text" class="input-blue" name="email" value="" placeholder="email">
                        <input type="text" class="input-blue" name="phone" value="" placeholder="Phone">
                        <textarea name="message" class="input-blue" placeholder="Message"></textarea>
                        <div class="link">
                            <a href="#" data-type="submit" class="input-blue-button">Submit</a>
                        </div>
                    </fieldset>
                    <%--<form id="contact-form" method="POST" action="">
                    
                    </form>--%>
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
                    <img src="img/logoBig.png">
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                      <asp:DropDownList ID="drpSchool" CssClass="input-blue" runat="server"  AutoPostBack="True" onselectedindexchanged="drpSchool_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                   
                    </asp:DropDownList>
                     <asp:DropDownList ID="drpYear" CssClass="input-blue" runat="server"  AutoPostBack="True" onselectedindexchanged="drpYear_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                   
                    </asp:DropDownList>  
                    <asp:DropDownList ID="drpUserType" CssClass="input-blue" runat="server">
                      <%--  <asp:ListItem>---Select---</asp:ListItem>        --%>            
                    </asp:DropDownList>
                    <%--<input type="text" class="input-blue" placeholder="User Name" />--%>
                    <asp:TextBox ID="txtUserName" CssClass="input-blue" placeholder="User Name" runat="server"></asp:TextBox>
                    <%--<input type="text" class="input-blue" placeholder="Password" />--%>
                    <asp:TextBox ID="txtPassword" CssClass="input-blue" TextMode="Password" placeholder="Password"
                        runat="server"></asp:TextBox>
                    <%--<button type="button" class="input-blue-button">
                        Login</button>--%>
                    <asp:Button ID="btnSubmit" CausesValidation="false" OnClick="btnSubmit_Click1" OnClientClick="return TopicValidation();" CssClass="input-blue-button"
                        runat="server" Text="Log in" />
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
          <div class="col-md-10"><span id="phone">Telephone :  +91-22-49707524 </span><br>
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

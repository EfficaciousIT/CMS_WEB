<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" %>

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
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="Form1" runat="server">
        <header>
            <div class="container headerbg">
                <div class="logo">
                    <img src="img/logo.png">
                </div>
            </div>
        </header>




        <!-- InstanceBeginEditable name="head" -->
        <nav class="navbar navbar-default ">
            <div class="container">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <a class="navbar-brand menu-responsive" href="#">Menu</a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li><a href="index.aspx">home </a></li>
                        <li><a href="AboutUs.aspx">About </a></li>
                        <li><a href="features.aspx">Features</a> </li>
                        <li><a href="howitswork.aspx">how it works</a> </li>
                        <li><a href="contactUs.aspx">Contact</a> </li>
                        <li><a href="#" data-toggle="modal" data-target="#login">Login</a> </li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div class="container" id="about-us">
            <div class="row">



                <div class="col-md-12">
                    <h2>students</h2>
                    <p>
                        Our E-Smarts dynamic school management system holds tremendous advantages for school students. Through the system they can improve their attendance levels, easily view their performance related data in academic and other school activities and improve in a timely manner. They can also share and download teacher-issued notes online and form groups for working on shared assignments. The RFID based school-management system also improves their security while they are on school-campus or when they are in transit from their home to school and vice-versa.
                    </p>


                    <h4 class="aboute-h4">Modern and effective student attendance management system and module</h4>
                    <p>Our best-in-class and truly modern <strong>RFID-based student attendance system</strong> helps the students to register their attendance easily through biometric input and smart cards. Students can also check their attendance online, improve on the discrepancies and apply for the rectification. The futuristic attendance module also helps the students to know the top-most attendance-wise five best performers of the class. They can apply for leave through the system itself and the leave application automatically escalates and reaches the next hierarchy/authority level for approval. </p>


                    <h4 class="aboute-h4">Easy information dissipation through Information Module</h4>
                    <p>Through our system, a student can view his/her daily class schedule as defined by the school administrator. The system also displays all information relating to events, holidays and exams in a vivid manner so that the students can plan their activities well ahead. The syllabus of the students is there on the online information bulletin and can be accessed and downloaded by the students any time they wish. </p>

                    <h4 class="aboute-h4">Examination module for better preparation</h4>
                    <p>The examination module helps the students to know all aspects of the exam like dates and timings of different subject exams, sitting arrangement, etc. Through the module, students can also see and download their current and previous mark sheets. </p>

                    <h4 class="aboute-h4">Integration Module for remarks</h4>
                    <p>The students can use the integration module for knowing the subject-wise remarks that have been assigned to them by teachers.</p>

                    <h4 class="aboute-h4">Performance Analysis of academic and co-curricular activities</h4>
                    <p>Students can know about their performance remarks and marks that they have acquired in cultural, sports and other co-curricular events.</p>


                    <h4 class="aboute-h4">Content management for easy notes sharing</h4>
                    <p style="margin-bottom: 50px;">The students can easily view and download the contents of lesson notes that have been provided to them by the subject teachers. Students who have similar assignments can form online groups and share the notes and subject/topic content amongst them online itself.</p>

                </div>





            </div>
        </div>

        <!-- InstanceEndEditable -->




        <div class="modal fade" id="login" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <img src="img/logo.png">
                    </div>
                    <div class="modal-body">
                        <div class="alert alertbox alert-danger fade in" style="display:none;"">
                            <a href="#" class="closes" data-dismiss="alert">&times;</a>
                            Enter your User Name 
                        </div>
                        <asp:DropDownList ID="drpUserType" CssClass="input-blue" runat="server">
                            <asp:ListItem>---Select---</asp:ListItem>
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Parent</asp:ListItem>
                            <asp:ListItem>Teacher</asp:ListItem>
                            <asp:ListItem>Staff</asp:ListItem>
                            <asp:ListItem>Administrator</asp:ListItem>
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
                    </div>
                </div>
            </div>
        </div>

        <footer class="footer">
            <div class="container">
                <div class="row">

                    <div class="col-md-4">
                        <ul class="footerlink">
                            <li><a href="index.aspx" class="active">home </a></li>
                            <li><a href="AboutUs.aspx">About </a></li>
                            <li><a href="features.aspx">Features</a> </li>
                            <li><a href="howitswork.aspx">how it works</a> </li>
                            <li><a href="contactUs.aspx">Contact</a> </li>
                            <li><a href="#" data-toggle="modal" data-target="#login">Login</a></li>
                        </ul>


                    </div>
                    <div class="col-md-4">
                        <div class="col-md-2 fa-icon"><i class="fa fa-map-marker"></i></div>
                        <div class="col-md-10">
                            <div class="box_aside">
                                <span id="adress">E-smarts<br>
                                    1402, G Square Business Park,<br>
                                    Plot 25 & 26, Sector 30,<br>
                                    Opp. Sanpada Station,<br>
                                    Vashi, Navi Mumbai Pin – 400703</span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="box_aside" style="margin-top: 30px;">
                            <div class="col-md-2 fa-icon"><i class="fa fa-phone"></i></div>
                            <div class="col-md-10">
                                <span id="phone">Tellephone :  +91-22-49707524 </span>
                                <br>
                                <span id="email">E-mail: <a href="mailto:info@efficacious.co.in">info@efficacious.co.in</a></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="box_aside" id="social_block">
                            E-SMARTS &nbsp; © <span id="copyright-year">2015</span> | <a class="footer_link" href="index-5.html">Privacy Policy</a>
                            <!-- {%FOOTER_LINK} -->
                            <div class="social">
                                <div class="soc_network"><a class="fa fa-facebook" href="#"></a></div>
                                <div class="soc_network"><a class="fa fa-rss" href="#"></a></div>
                                <div class="soc_network"><a class="fa fa-twitter" href="#"></a></div>
                                <div class="soc_network"><a class="fa fa-google-plus" href="#"></a></div>
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

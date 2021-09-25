<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="Teacher" %>

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
                    <img src="img/logoBig.png">
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
                    <h2>Teachers</h2>
                    <p>E-Smarts is the latest <strong>RFID school management system</strong> and holds tremendous benefits for teachers, students, school administrators and parents in many modern ways. </p>
                    <p>
                        The software provides for the best-in-class teacher assistance framework and helps the teacher to save both time and efforts so that he/she can channelize his/her energy in more important tasks. 
                    </p>

                    <h4 class="aboute-h4">Attendance Gathering And Monitoring</h4>
                    <ul class="about-ulli">
                        <li>Best-in-class attendance registering through use of Bio-Metric inputs and Smart Cards</li>
                        <li>Any time assessment of student attendance through online modes and fast rectification of discrepancies</li>
                        <li>The RFID-based school tracking system uses radio frequencies to ensure that all student movements are tracked in real-time to their specific locations, and no abnormal absence gets unnoticed</li>

                    </ul>

                    <h4 class="aboute-h4">Swift Flow of Information</h4>

                    <ul class="about-ulli">
                        <li>Teachers can view their administrator-defined classes easily.</li>
                        <li>Online notice board for viewing holidays, examination schedules, and easy syllabus downloads for lessons planning and references</li>


                    </ul>


                    <h4 class="aboute-h4">Instant Messaging Module</h4>

                    <ul class="about-ulli">
                        <li>Instant message generation and delivery for all school activities related to teachers like notification of unplanned holidays etc.</li>
                        <li>Instant messaging and alerts from RFID-based school tracking system in case any student is absent without information</li>
                    </ul>



                    <h4 class="aboute-h4">Integration Module</h4>

                    <ul class="about-ulli">
                        <li>Fast delivery of marks allotted by teachers to students in their exams subject-wise</li>
                        <li>Easy scheduling and quick distribution of notification of all activities related to students and teachers such as cultural events, picnics, Parent-teacher Meetings, etc.</li>
                    </ul>


                    <h4 class="aboute-h4">Performance Monitoring And Analysis</h4>

                    <ul class="about-ulli">
                        <li>Best modules and software tools for measuring and analyzing the performance of a child in sports activities, stage shows, internal competitions, etc. and easy and fast displaying of results</li>
                    </ul>

                    <h4 class="aboute-h4">Effective Content Management and Easy To Access Content</h4>

                    <ul class="about-ulli">
                        <li>Easy uploading of teaching notes on the web and their fast publishing so that any student can view download and use the notes for study purposes</li>
                    </ul>


                    <h4 class="aboute-h4">Dash Boards and MIS reports for instant reporting</h4>

                    <ul class="about-ulli">
                        <li>Highly interactive dashboards for faster viewing and analysis of information and generation of MIS reports at the click of mouse </li>
                    </ul>


                    <h4 class="aboute-h4">Full Automation</h4>

                    <ul class="about-ulli" style="margin-bottom: 50px;">
                        <li>The most advanced software has all the functions fully automated so that all the tedious jobs such as preparation of mark sheets can be done easily and quickly.<br>
                            Contact us now to know more about the Teacher-related benefits that are offered by our truly modern, automated and secure E-Smarts school management system.</li>
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
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <img src="img/logoBig.png">
                    </div>
                    <div class="modal-body">
                        <div class="alert alertbox alert-danger fade in" style="display:none;">
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
                            <li><a href="index.html" class="active">home </a></li>
                            <li><a href="about.html">About </a></li>
                            <li><a href="features.html">Features</a> </li>
                            <li><a href="how-it-works.html">how it works</a> </li>
                            <li><a href="contact.html">Contact</a> </li>
                            <li><a href="#">Login</a> </li>
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

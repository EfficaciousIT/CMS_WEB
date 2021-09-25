<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Parent.aspx.cs" Inherits="Parent" %>

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
                    <h2>parents</h2>
                    <p>E-Smarts is a new RFID School Management System and employs the latest radio frequency technology for tracking student movements. It also has a host of other features that benefit school administrators, students, parents and teachers alike. </p>

                    <p>Our modern and state-of-the-art E-Smarts school-management system holds tremendous advantages for parents and provides them unique monitoring benefits of their ward’s performance along with providing for better security for mishap prevention. </p>

                    <h4 class="aboute-h4">Modern Attendance Module For Monitoring Ward’s Attendance Patterns</h4>
                    <p>Our unique system helps parents to view the attendance of their wards at any time they wish. Apart from knowing the attendance rates, parents can have an analytic comparison of attendance of all students in the class and know the five best students based on attendance-wise performance. </p>

                    <h4 class="aboute-h4">Information Module For Planning </h4>
                    <p>The latest information metrics and module system provides in-depth, accurate and timely updates to parents about upcoming school events such as Parent-Teacher meeting, cultural events, holidays, and vacations. Also, they can download the syllabus anytime for their wards.</p>

                    <h4 class="aboute-h4">Integration system for fast messaging and analysis</h4>
                    <p>This part of the system provides for seamless flow of information among the system users. Parents can know and view the marks of specific subjects that are assigned by the teachers of respective subjects to the ward. The system generates automated messages for informing parents about special events and days like fee day, picnic day, etc.</p>

                    <h4 class="aboute-h4">Performance display </h4>
                    <p>The system provides the performance related data that a student achieves in any co-curricular activity such as sports, stage shows, competitions, etc. The analyzed data helps the parents in judging the performance of their child and for improving it. </p>

                    <h4 class="aboute-h4">RFID based school tracking</h4>
                    <p>Our modern and technologically advanced system tracks the student movement through the latest RFID or Radio Frequency Identification technology. Hence, parents and school administrators are able to prevent mishaps and know more the student activities and movements.</p>

                    <h4 class="aboute-h4">Key benefits of our latest RFID-based school management system for parents:</h4>
                    <ul class="about-ulli" style="margin-bottom: 50px;">
                        <li>Timely alerts of the student’s/wards arrival and departure from the school</li>
                        <li>Regular and timely updates of all events and happenings in the school (which are relevant to the parents)</li>
                        <li>A special login provided to each parent for knowing and judging their ward’s performance in examinations and co-curricular activities</li>
                        <li>Easy communication with teachers of all subjects</li>
                        <li>A fully customized and user-friendly app (for all mobile platforms including Windows, Blackberry, iOS and Android) for parents so that they can track the movements of the ward’s school bus easily and on-the-go</li>
                        <li>Online availability of exam schedules and holidays in-advance so that parents can easily plan vacations </li>

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
                            <li><a href="index.aspx" class="active">home </a></li>
                            <li><a href="AboutUs.aspx">About </a></li>
                            <li><a href="features.aspx">Features</a> </li>
                            <li><a href="howitswork.aspx">how it works</a> </li>
                            <li><a href="contactUs.aspx">Contact</a> </li>
                            <li><a href="#" data-toggle="modal" data-target="#login">Login</a> </li>
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

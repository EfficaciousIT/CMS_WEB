<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schoolfeesmanagement.aspx.cs" Inherits="schoolfeesmanagement" %>

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
                    <h2>SCHOOL</h2>
                    <p style="margin-bottom: 50px">E-Smarts offers variety of dashboards to school management to monitor and manage daily school operations with ease. It covers almost all aspects of school management such as automation of fee payment, admission and other processes, security (through the latest RFID system), scheduling of all school events like examinations, events, holidays, and  management of transport. </p>
                    <h4 class="aboute-h4">E-Smarts with RFID based school tracking</h4>
                    <p>Efficacious India Limited presents to you the most modern and technologically advanced RFID school management system - E-Smarts. The innovative software and modules collection has been designed after extensive research for schools and educational institutes and helps the school administrators, teachers, students and parents in various ways. </p>
                    <h4 class="aboute-h4">E-Smarts for Schools</h4>
                    <p>The software has a wide array of web-based and offline features and tools that facilitate instructors, teachers and management/administrative staff to manage different aspects of school management such as perfect student tracking, security and monitoring; event planning, attendance regulation and more. In addition, it assists the school administrators in a host of other ways so that the administration can make better and faster decisions.</p>
                    <h4 class="aboute-h4">RFID based school tracking</h4>
                    <p>RFID or Radio Frequency Identification System uses radio frequencies for tracking children and students in pre-defined school areas. Through the advanced system, a parent or school administrator can know where the child or student is in real-time. It helps to prevent mishaps.</p>
                    <h4 class="aboute-h4">Futuristic Security</h4>
                    <p>Our inbuilt security system issues alerts to the school administration in certain situations (trigger points) and prevents mishaps by making the concerned person aware of the child’s/student's absence. The system is designed to trace the log-ins and log-outs of children during their transit from schools to their homes in school buses as well. </p>
                    <h4 class="aboute-h4">Fixed asset management and tracking</h4>
                    <p>Through our fixed asset management module, the school administration can easily manage all the fixed assets that are placed in classes, staff rooms and school offices. </p>
                    <h4 class="aboute-h4">Inventory management module</h4>
                    <p>Through our inventory module, you can track all the material and inventory transactions of the whole school. This provides for faster categorization of equipments and products that can also be easily traced in times of need. The module reduces the work pressure of your inventory handling staff to marginal levels. Real time changes related to addition and removal can be made as well. </p>
                    <h4 class="aboute-h4">Monitoring</h4>
                    <p>The attendance and information module of our software helps you to know all the details relating to students and their attendance performance. Our transport module can be used for defining transporters, for defining routes for the passengers and for other purposes. All the information can be tracked in real time.</p>
                    <h4 class="aboute-h4">Some other key benefits of our RFID-based school management system E-Smarts include:</h4>
                    <ul class="about-ulli">
                        <li>Advanced Tools for school management and functioning</li>
                        <li>Paperless and virtual management for saving time and costs</li>
                        <li>Automation of various school processes leading to complete transparency</li>
                        <li>Introduces better efficiency in staff leading to better results and reputation</li>
                        <li>Seamless communication among school staff and parents about every aspect relating to the students</li>
                        <li>Better management of examination schedules </li>
                        <li>Better event planning </li>
                        <li>A separate Library module for managing and maintaining the library</li>
                    </ul>
                    <p style="margin: 20px 0px 50px;">Call us now to know more about the exceptional administration-assisting features our latest School Management System offers to you.</p>
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


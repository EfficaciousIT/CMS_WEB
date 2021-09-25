<%@ Page Language="C#" AutoEventWireup="true" CodeFile="features.aspx.cs" Inherits="login_features" %>

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
        <li> <a href="features.aspx" class="active">Features</a> </li>
        <li> <a href="howitswork.aspx">how it works</a> </li>
        <li> <a href="contactUs.aspx">Contact</a> </li>
        <li> <a href="#" data-toggle="modal" data-target="#login">Login</a> </li>
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>
    <div class="container">
        <ul class="features-page">
            <li>
                <div class="bluebox">
                    <img src="img/features/Attendance-Module.png"></div>
                <div class="leftbox-features">
                    <h4>
                        Attendance Module</h4>
                    <p>
                        Our paperless RFID student attendance system improves on the conventional paper-pen
                        method of attendance. The fully automated E-Smarts requires no manual work for registering
                        attendance, is very fast, can detect late entries and saves lots of time. Teachers
                        can focus more on teaching and other academic and co-curricular activities.
                    </p>
                    <p>
                        The technologically advanced system has a number of key features.
                    </p>
                    <ul class="about-ulli">
                        <li>Latest RFID-based student tracking system for tracking student’s movement in pre-defined
                            school areas and during their home-school transits on school buses </li>
                        <li>GPS/GPRS systems attached to the RFID systems for pinpointing the exact location
                            of a student</li>
                        <li>Unique and technologically advanced attendance module tags (that each student carries
                            around as a kind of identification) for automatic registering of student attendance.</li>
                        <li>Recording of arrivals and departures (on time, late or early) of students for time-summary,
                            analysis and review</li>
                    </ul>
                </div>
            </li>
            <li>
                <div class="bluebox">
                    <img src="img/features/Transport-Module.png"></div>
                <div class="leftbox-features">
                    <h4>
                        Transport Module</h4>
                    <p>
                        The E-Smarts system for school management is equipped with the latest school bus
                        management system for taking care of all the transport-related aspects of school
                        children. It improves over the traditional manual registering and imperfect forecasting
                        patterns. It provides real-time information related to school bus movement.
                    </p>
                    <p>
                        The technologically advanced school bus tracking system has loads of other advantages
                        as well.</p>
                    <ul class="about-ulli">
                        <li>Fast, easy and fully automated process for collecting all the information related
                            to bus transporters, and routes.</li>
                        <li>Precise defining of student transit routes, drivers, trips and stops for an efficient
                            and timely student transit</li>
                        <li>Mobile application for smartphones so that parents can track the school bus movement
                            in real-time </li>
                        <li>RFID (Radio Frequency Identification) assisted with GPS/GPRS modules for pinpointing
                            the exact location of a school bus and each student (through the student-specific
                            RFID card). </li>
            </li>
        </ul>
    </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Security-Module.png"></div>
        <div class="leftbox-features">
            <h4>
                Security Module</h4>
            <p>
                E-Smarts is technologically advanced software that has comprehensive security tools
                and arrangements for ensuring the well being of the child on the school campus and
                during transits. The system has many futuristic technological features that improve
                the security aspects of a school manifold and are not breachable easily.</p>
            <p>
                The<strong> RFID-based security system </strong>ensures that each student is precisely
                identified during attendance, during his/her school-home transits, while the student
                is out of the class and during other times as well. The security of the system is
                further strengthened by GPS/GPRS systems that are combined with <strong>advanced RFID
                    system</strong> so that the location of a child is traced to exact and specific
                location.</p>
            <p>
                The system generates automatic alerts for the administration at some trigger points.
                These trigger points are the points at which a child’s security is threatened and
                are related to a student’s movements in school campus and while being in transit
                from his home to school and vice versa.</p>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/dashboard.png"></div>
        <div class="leftbox-features">
            <h4>
                Dash Boards & MIS Reports</h4>
            <p>
                E-Smarts offers information integration and management benefits to all the stakeholders
                of the school including school administration, parents, teachers and students. The
                system generates many different kinds of reports and displays all information on
                a highly interactive, user-friendly and easy-to-navigate dashboard.</p>
            <ul class="about-ulli">
                <li>The system generates a range of Student MIS reports including reports relating to
                    house configuration, reassignment and rearrangement of house configuration, sanctioning
                    of long leaves, etc. </li>
                <li>Easy uploading of all the required documents for admission process and set up of
                    the second language </li>
                <li>Full automation of all school processes such as fee transactions, report card</li>
                <li>Generations of many different kinds of reports including fee report, attendance
                    report, performance report, inventory report, library report and more</li>
                <li>Reports for all the stakeholders for analyzing and measuring each and every aspect
                    of school management and student performance</li>
                <li>Easy generation (at the click of mouse)</li>
    </li>
    </ul> </div> </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Profile-Management.png"></div>
        <div class="leftbox-features">
            <h4>
                Profile Management</h4>
            <p>
                The profile management module of E-Smarts school management software has been designed
                in a modern, futuristic, easy-to-navigate and user-friendly manner so that all concerned
                parties including teachers, school administrators, and parents can get any information
                they need in detail, specifically and accurately.</p>
            <h4>
                Key features of profile management module</h4>
            <ul class="about-ulli">
                <li>Profile creation for all school stakeholders including school administrators, teachers,
                    students and parents</li>
                <li>Daily updates of all data and information relating to registration, admissions,
                    faculty and all other school processes for school administrators</li>
                <li>Students can view their results, grades, teacher remarks, performance related data
                    in academics and co-curricular activities and more </li>
                <li>Parents get real time updates of grades, attendance, feedbacks and teacher remarks</li>
                <li>Simple user interface, intuitive features and additional features like forum, complaint
                    forum, etc </li>
                <li>Key information relating to students’ movements that may be vital in times of emergency</li>
            </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Examination-Module.png"></div>
        <div class="leftbox-features">
            <h4>
                Examination Module</h4>
            <p>
                The E-Smarts module of <strong>school exam management system</strong> fully automates
                the examination process. It provides for easy planning and scheduling of exams and
                also integrates the examination process with the result, report card and grade distribution
                process thereby making the processes more effective, flawless and fast.</p>
            <ul class="about-ulli">
                <li>Management of all aspects of examination like sitting arrangements, time, date,
                    etc</li>
                <li>Profile based access to the examination module by students, teachers and administrators</li>
                <li>Display of results in marks or grades</li>
                <li>Full support for all kinds of examinations including practical examinations</li>
                <li><strong>School results in management system</strong> for online uploading and display
                    of results so that a student can view them anytime through different devices</li>
            </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Inventory-Module.png"></div>
        <div class="leftbox-features">
            <h4>
                Inventory Module</h4>
            <p>
                E-Smarts is the most innovative and modern RFID based school management system.
                The RFID based inventory tracking system of the software tracks down all material
                and inventory transactions and also fully automates inventory control and scheduling
                processes.
            </p>
            <h4>
                Key features and Benefits of E-Smarts Inventory Module</h4>
            <ul class="about-ulli">
                <li>Radio wave identification of all unique items that have specific microchips and
                    tags</li>
                <li>RFID for inventory control system does not require line-of-sight and the reading
                    can be done remotely as well</li>
                <li>Detailed record of all material and inventory transaction</li>
                <li>Easy to generate MIS reports for detailed review and analysis</li>
                <li>Easy workflow and lesser burden on the staff and employees </li>
                <li>Customization of the module for making it just-right for the school-specific inventory
                </li>
            </ul>
            <p>
                E-Smarts Inventory Module brings perfection at all levels without any scope of errors.
            </p>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Fixed-Asset.png"></div>
        <div class="leftbox-features">
            <h4>
                Fixed Asset Module</h4>
            <p>
                This module provides all the asset related reports to college administration and
                others for whom it may be relevant. It provides details related to all assets that
                may be on the school campus with their current valuation and purchase price. E-Smarts
                is the most efficient software system today for locating and finding fixed assets
                of school and is equipped with the latest <strong>RFID fixed asset inventory software</strong>.
                The RFID software makes use of radio frequency via RFID tags to know the exact location
                of an asset. </h4>
                <h4>
                    Key benefits of E-Smarts Fixed Asset Module</h4>
                <ul class="about-ulli">
                    <li>Provides full maintenance history details of assets for their timely upkeep, channel
                        usage etc.</li>
                    <li>In-detail description of warranties and guarantees of all assets</li>
                    <li>Latest <strong>RFID Asset Tracking system</strong> for knowing the precise location
                        of any asset</li>
                </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Syllabus-Module.png"></div>
        <div class="leftbox-features">
            <h4>
                Syllabus Module</h4>
            <p>
                E-Smarts inbuilt syllabus module is a necessary and significant syllabus viewing
                and a downloading feature that benefits the students, teachers and parents, alike.</h4>
                <h4>
                    Key features of E-Smarts Syllabus Module</h4>
                <ul class="about-ulli">
                    <li>The module displays and describes in detail courses and their syllabus that can
                        be downloaded anytime by students, parents or teachers.</li>
                    <li>The module covers all the reports that relate to previous year results. The results
                        can also be viewed rank-wise.</li>
                    <li>The module provides information on many different aspects of the institution including
                        its profile, history, facilities offered (with images), contact details.</li>
                    <li>The software system has an inbuilt Admin part that can be used to add more information
                        and manipulate the existing information. Hence, school administrators can easily
                        change fee, course structure, syllabus, etc. in a precise manner and also add new
                        courses and subjects to the existing syllabus.</li>
                </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Library.png"></div>
        <div class="leftbox-features">
            <h4>
                Library Module</h4>
            <p>
                The unique and efficient <strong>RFID based Library management system</strong> is
                a truly modern module of E-Smarts for improving the efficiency of a librarian and
                making his/her work process seamless, automated and less tiring. The system does
                not require manual typing at any stage and provides library-member information and
                book information directly. </h4>
                <h4>
                    Benefits</h4>
                <ul class="about-ulli">
                    <li>A number of books can be accessed at the same time</li>
                    <li>Easy search of a particular book and pin-point location finding</li>
                    <li>Automated stock verification/accounting of the books and other library materials
                    </li>
                    <li>Inbuilt <strong>RFID library security systems</strong> and 24*7 monitoring of book
                        movements across library gates assisted by alarms</li>
                    <li>RFID handheld reader for searching the books in a fast manner</li>
                    <li>Faster processes for issue, reissue and return of books</li>
                    <li>A flawless system that minimizes errors</li>
                </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Reception.png"></div>
        <div class="leftbox-features">
            <h4>
                Reception/ Enquiry Module</h4>
            <p>
                Our Best-In-Class RFID-based school management system has an integrated Reception
                and Enquiry Management module that fully automates all the processes of reception
                handling. Reception is the first place a visitor visits while visiting the school
                and our impressive school management system makes the enquiry and reception process
                seamless, fast and effective.</h4>
                <h4>
                    Key Benefits of E-Smarts Reception And Enquiry Module</h4>
                <ul class="about-ulli">
                    <li>A single view to fee payments, collections, availability of hostel rooms, etc
                    </li>
                    <li>Scalability and adaptability feature for making the software more robust</li>
                    <li>Provides for inspection, authentication and verification</li>
                    <li>Effective search facility for searching any information and data</li>
                    <li>Comprehensive and timely performance reports</li>
                    <li>Streamlines all information and enquiry tasks and integrates them in a seamless
                        manner</li>
                    <li>Secure access through alternative devices like laptops, PDAs, tablets, etc</li>
                    <li>Centralized back-up and data restore options</li>
                </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Messaging.png"></div>
        <div class="leftbox-features">
            <h4>
                Messaging Module</h4>
            <p>
                The fast and efficient Messaging Module of E-Smarts school management software is
                designed to create a flawless and fast communication network amongst the concerned
                parties including teachers, parents, students and administrators. It automates all
                messaging processes and makes it easy to create and distribute messages specifically
                and in bulk as well.</p>
            <h4>
                A few benefits include:</h4>
            <ul class="about-ulli">
                <li>Instant creation and delivery of messages to teachers and parents about different
                    school events including fee payments and fee day, examinations, holidays, etc</li>
                <li>Real-time notification of the log-ins and log-outs of the student from the school
                    and during their transit between school and home via the school bus</li>
                <li>Easy creation of emergency notifications (for admin purposes) and instant delivery
                    for preventing or controlling mishaps</li>
            </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Mobile-App.png"></div>
        <div class="leftbox-features">
            <h4>
                Mobile App For Smart Phone</h4>
            <p>
                E-Smarts consists of a RFID based student tracking system that is combined with
                the GPS/GPRS system for precisely knowing a student’s location. The system also
                has a supportive feature in the form of a mobile app for smartphones that run on
                Android, Windows, iOS, Symbian, Blackberry and other smartphone platforms. It offers
                peace of mind for the parents as they know that the security of their child is not
                compromised in any way</p>
            <h4>
                Key Benefits
            </h4>
            <ul class="about-ulli">
                <li>The App helps the parents to track the location of the school bus in real time
                </li>
                <li>Live update of travel status of the students who travel by the school bus or any
                    other school transport facility</li>
                <li>Over-speed alerts</li>
                <li>Better planning and optimization of the school transit routes thereby saving costs
                    and time of both parents and school administrators </li>
                <li>Detailed log of student travel data which helps in better analysis and exploration
                    of facts that are crucial to preventing mishaps</li>
                <li>Easy generated MIS reports that can monitor and even enhance the efficiency of transport
                    operations </li>
            </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Information.png"></div>
        <div class="leftbox-features">
            <h4>
                Information Module</h4>
            <p>
                The comprehensive information module of our state-of-the-art school management software
                E-Smarts provides for faster access to all information and data which relates to
                school activities, in lesser time and with ease. All the concerned people including
                teachers, students, parents and administrators can save lots of time and energy
                by using the software for information processing, gathering and dissipation.</p>
            <h4>
                Key Benefits of E-Smarts Information Module</h4>
            <ul class="about-ulli">
                <li>School administrator can define all school activities on the software dashboard
                    and they can view them easily and plan in advance</li>
                <li>Administrators can create identification cards (IDs) and upload all student data
                    including name, address, blood group, contact number, class, section etc. The information
                    proves crucial in times of emergency</li>
                <li>Students can easily apply for fresh/new ID cards (in case they lose them) online
                    itself</li>
                <li>Detailed display of syllabus according to subjects</li>
            </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Performance.png"></div>
        <div class="leftbox-features">
            <h4>
                Performance Analysis</h4>
            <p>
                E-Smarts provides a very interactive and easily navigable dashboard/platform that
                is extremely helpful in analyzing a student’s performance. The use of extensive
                parameters, graphs and data ensures that all aspects of the student’s performance
                in academics and co-curricular activities are fairly and adequately described.
            </p>
            <h4>
                Benefits</h4>
            <ul class="about-ulli">
                <li>Detailed description of performance results with a date for all activities held
                    in school including stage shows, internal competitions, sports, debates, etc.</li>
                <li>Better child counseling on the basis of analysis of performance of the child in
                    present and past contests</li>
                <li>Provides for planned improvement of a child’s performance so that he/she can excel
                    in the areas of his/her interest </li>
            </ul>
        </div>
    </li>
    <li>
        <div class="bluebox">
            <img src="img/features/Mess-Management.png"></div>
        <div class="leftbox-features">
            <h4>
                Hostel & Mess Management</h4>
            <p>
                E-Smarts has inbuilt Hostel and Mess Management module that can customize and manage
                all the issues that relate to the hostel. It automates almost all processes related
                to hostel management including enquiries, payments, reservations, cleaning lists,
                booking lists and more.</p>
            <h4>
                Key Benefits of E-Smarts Hostel And Mess Management Software</h4>
            <ul class="about-ulli">
                <li>Management of reservations</li>
                <li>Generation of different kinds of list including non-payer lists</li>
                <li>Longer service life and high durability</li>
                <li>Excellent performance and compact design</li>
                <li>Has inbuilt automated functionality improving features like hostel master, room
                    master, course master, room transfer, etc. that makes it easy for the warden to
                    manage the hostel and mess activities</li>
                <li>Generates MIS reports at the click of mouse for detailed information dissipation
                    and provides for better efficiency and performance improvement</li>
            </ul>
        </div>
    </li>
    </ul> </div>
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
                       <%-- <asp:ListItem>---Select---</asp:ListItem>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta charset="utf-8">
    <title>E – SMARTs</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="css/normal.css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" href="css/animation.css">

    <script src="js/jquery-1.8.3.js" language="javascript"></script>

    <script src="js/jquery.carouFredSel-6.2.0-packed.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/ssp1.min.js"></script>

    <link type="text/css" rel="stylesheet" href="css/featherlight.min.css">

    <script type="text/javascript" src="js/normal.js"></script>

    <script type="text/javascript" src="js/carousels.js"></script>

    <script type="text/javascript" src="js/slider-modernizr.js"></script>

   <%-- <script src="js/classie.js"></script>

    <script src="js/portfolio-effects.js"></script>

    <script src="js/toucheffects.js"></script>

    <script src="js/modernizr.js"></script>

    <script src="js/animation.js"></script>

    <script src="js/featherlight.min.js"></script>--%>

    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.4.7/webfont.js"></script>

    <script>
        if (/mobile/i.test(navigator.userAgent)) document.documentElement.className += ' w-mobile';
    </script>

    <!-- FlexSlider -->
    <link href="css/banner.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="js/jquery.flexslider-min.js"></script>

    <script type="text/javascript" charset="utf-8">
        var $ = jQuery.noConflict();
        $(window).load(function() {
            $('.flexslider').flexslider({
                animation: "fade"
            });

            $(function() {
                $('.show_menu').click(function() {
                    $('.menu').fadeIn();
                    $('.show_menu').fadeOut();
                    $('.hide_menu').fadeIn();
                });
                $('.hide_menu').click(function() {
                    $('.menu').fadeOut();
                    $('.show_menu').fadeIn();
                    $('.hide_menu').fadeOut();
                });
            });
        });
    </script>

    <style type="text/css">
        .lightbox
        {
            display: none;
        }
        .fl-page .btn-download
        {
            float: right;
        }
        .fl-page .btn-default
        {
            vertical-align: bottom;
        }
        .btn-group a
        {
            color: #f05023;
            margin: 8px auto 20px auto;
            display: inline-block;
        }
        .trustee_desc .btn-group a:nth-child(1)
        {
            display: none;
        }
        /* override default feather style... */.fixwidth
        {
            background: rgba(256,256,256, 0.8);
        }
        .fixwidth .featherlight-content
        {
            max-width: 720px;
            padding: 25px;
            color: #fff;
            background: #fff;
        }
        .fixwidth .featherlight-content p
        {
            font-size: 16px;
            line-height: 34px;
            color: #000;
        }
        .fixwidth .featherlight-close
        {
            color: #fff;
            background: #333;
        }
    </style>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico">
    <!--[if lt IE 9]><script src="https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7/html5shiv.min.js"></script><![endif]-->
    <!----Pop-up----->
    <!--- pop end ----->
</head>
<body>
    <form runat="server">
    <div class="fix-header" id="home">
        <div class="w-container">
            <div class="w-nav" data-collapse="medium" data-animation="default" data-duration="400">
            </div>
        </div>
    </div>
    <div class="fixed-header">
        <div class="w-container container">
            <div class="w-row">
                <!--///////////////////////////////////////////////////////
       // Logo section 
       //////////////////////////////////////////////////////////-->
                <div class="w-col w-col-3 logo">
                    <a href="#">
                        <img class="logo" src="images/logo-esmarts.png" alt="Esmarts"></a>
                </div>
                <!--///////////////////////////////////////////////////////
       // End Logo section 
       //////////////////////////////////////////////////////////-->
                <div class="w-col w-col-9">
                    <!--///////////////////////////////////////////////////////
       // Menu section 
       //////////////////////////////////////////////////////////-->
                    <div class="w-nav navbar" data-collapse="medium" data-animation="default" data-duration="400"
                        data-contain="1">
                        <div class="w-container nav">
                            <nav class="w-nav-menu nav-menu" role="navigation">

                <a class="w-nav-link menu-li" href="#home">HOME</a>
                <a class="w-nav-link menu-li" href="#about">ABOUT</a>
                <a class="w-nav-link menu-li" href="#service">PRODUCT</a>
                <a class="w-nav-link menu-li"href="#demo">DEMO</a>
                <a class="w-nav-link menu-li" href="#contact">CONTACT</a>
                <a onClick="document.getElementById('login').style.display='';return false;"   class="w-nav-link menu-li"href="#login">LOGIN</a>
                <!--<a class="w-nav-link menu-li" href="#contact">LOGIN</a>-->
                <!-- <a class="w-nav-link menu-li" href="#home">HOME</a>
                <a class="w-nav-link menu-li" href="#about">ABOUT</a>
                <a class="w-nav-link menu-li" href="#service">PRODUCT</a>
                <a class="w-nav-link menu-li" href="#portfolio">CONTACT</a>
                <a class="w-nav-link menu-li"href="#team">LOGIN</a> -->
              </nav>
                            <div class="w-nav-button">
                                <div class="w-icon-nav-menu">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--///////////////////////////////////////////////////////
       // End Menu section 
       //////////////////////////////////////////////////////////-->
                </div>
            </div>
        </div>
    </div>
    <!--///////////////////////////////////////////////////////
       //  Slider section 
       //////////////////////////////////////////////////////////-->
    <div class="slidersection">
        <div class="sp-slideshow">
            <div class="banner">
                <div class="slider_container">
                    <div class="flexslider">
                        <ul class="slides">
                            <li><a href="#">
                                <img src="images/slider/slide1.png" alt="" title="" /></a>
                                <div class="flex-caption">
                                    <div class="caption_title_line">
                                        <h2>
                                            A Complete Integrated Solution for Education Innovated to Address the Need of the
                                            Hour</h2>
                                    </div>
                                </div>
                            </li>
                            <li><a href="#">
                                <img src="images/slider/slide2.png" alt="" title="" /></a>
                                <div class="flex-caption">
                                    <div class="caption_title_line">
                                        <h2>
                                            An Innovative Technological Tool Created, Designed & Developed SMARTly for Educational
                                            Sector</h2>
                                    </div>
                                </div>
                            </li>
                            <li><a href="#">
                                <img src="images/slider/slide3.png" alt="" title="" /></a>
                                <div class="flex-caption">
                                    <div class="caption_title_line">
                                        <h2>
                                            Completely Secured & Automated Capturing Attendance of Students, Teachers & Staff</h2>
                                    </div>
                                </div>
                            </li>
                            <li><a href="#">
                                <img src="images/slider/slide5.png" alt="" title="" /></a>
                                <div class="flex-caption">
                                    <div class="caption_title_line">
                                        <h2>
                                            Real Time School Bus Tracking & Instant Notifications</h2>
                                    </div>
                                </div>
                            </li>
                            <li><a href="#">
                                <img src="images/slider/slide4.png" alt="" title="" /></a>
                                <div class="flex-caption">
                                    <div class="caption_title_line">
                                        <h2>
                                            Can easily accessible from any corner of the Globe via internet</h2>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- sp-slideshow -->
    </div>
    <!--///////////////////////////////////////////////////////
       // End slider section 
       //////////////////////////////////////////////////////////-->
    <!--///////////////////////////////////////////////////////
       // About section 
       //////////////////////////////////////////////////////////-->
    <div class="about-parlex" id="about">
        <section class="parlex7-back">
      <div class="w-container">
        <div id="about-animation">
        <div class="wrap">
          <div class="about">
            <h1 class="about-heading">ABOUT</h1>
           
            <div class="sepreater"></div>
          </div>
          <p class="about-des">Efficacious India Limited has been incorporated in the year 2012. The company is committed to innovative products and solutions that can improve management efficacy and tracking for school going children by efficient use of technology and service aspect.</p>
            <p class="about-des"> The company is backed by team of highly professionals from IT Security and Education Sector who understand the requirement of the sector and have invariably researched products that can cater to the needs of the education sector.</p>
            
              <h1 class="about-heading">OUR TEAM</h1>
         <div class="w-row team-member">
            
          <div style="width: 100%;color: #000;height: auto;padding: 2%;float: left; margin-bottom:15px; background: #fff;font-size: 16px;
text-align: justify;"><p style="color: #000;
line-height: 23px;
font-size: 16px;"><img width="150" height="150" style="border:1px solid #ededed; margin-right:15px;" align="left" src="images/team/kamal-Agrawal.png"><strong>Kamal Agrawal</strong> is the CMD of Efficacious Group. He has over 15 years of post-qualification experience in the field of Accounts, Finance, Costing and Budgeting. A veteran in Finance field, he has done his CA, CS, CWA and Diploma in IFRS from ACCA London. He has been associated and worked closely with various IT companies during his tenure and in the process developed an acumen to do some innovative research/experiment in this field. In order to provide a platform to transform his vision into tangible reality has created Efficacious.</p></div>

  <div style="width: 100%;color: #000;height: auto;padding: 2%;float: left; margin-bottom:15px; background: #fff;font-size: 16px;
text-align: justify;"><p style="color: #000;
line-height: 23px;
font-size: 16px;"><img width="150" height="150" style="border:1px solid #ededed; margin-right:15px;" align="left" src="images/team/Mukund-Gupta.png"><strong>Mukund Gupta</strong> is the Advisor of Efficacious India Limited. An alumnus of Mumbai University from where he received his Master's Degree in Information Management and went on to get a Diploma in Software Engineering & Embedded Systems. Mr. Gupta has been a source of inspiration and motivation to all those whom he comes across and considering his stupendous contributions and amazing achievements, he was propelled to the position of Executive Director of Micro Technologies (India) Ltd prior to joining EIL. Mr. Gupta is responsible for the overall Technological development of the Company for innovative products.</p></div>


 <div style="width: 100%;color: #000;height: auto;padding: 2%;float: left; margin-bottom:15px; background: #fff;font-size: 16px;
text-align: justify;"><p style="color: #000;
line-height: 23px;
font-size: 16px;"><img width="150" height="150" style="border:1px solid #ededed; margin-right:15px;" align="left" src="images/team/Mr-Rakesh_Rao.png"><strong>Rakesh Rao</strong> heads the business development across UAE & Africa region. He has over 6 years of experience in sales and marketing, event management, partner acquisition etc. To his credit he has acquired partners/clients across India, Middle East and Africa. His domain expertise include GPS related IT solutions for transportation and construction ERP. Mr. Rakesh Rao holds bachelor’s degree in engineering, post graduate in marketing and certificate in digital marketing.</p></div>

 <div style="width: 100%;color: #000;height: auto;padding: 2%;float: left; margin-bottom:15px; background: #fff;font-size: 16px;
text-align: justify;"><p style="color: #000;
line-height: 23px;
font-size: 16px;"><img width="150" height="150" style="border:1px solid #ededed; margin-right:15px;" align="left" src="images/team/Ajay-Prajati.png"><strong>Ajay Prajapati</strong> heads the development & implementation team at Efficacious. Mr. Ajay has more than 6 years of domain experience in IT and software development. He is adept at building and managing a motivated team by setting and maintaining high standards for individual and team performance. He is also known for nurturing effective teams and cross-functional relationships. He is endowed with excellent creative instincts, deep understanding of technology and strong project management and analytical skills. Mr. Ajay is responsible for new developments in software technology. He is handling various development activities like planning, scheduling, coding and implementing the project. His vast experience includes developing and executing strategies for new products, skill enhancement and employability that extends from increasing the profitability of existing products to developing a variety of new products for the Company.</p></div>          
          
         
         <div style="width:90%; height:auto; padding:2%; float:left;"></div>
         
         <div style="width:90%; height:auto; padding:2%; float:left;"></div>
          
          
            
            
            
        </div>
      </div>
      </div>
    </section>
    </div>
    <!--///////////////////////////////////////////////////////
       // End about section 
       //////////////////////////////////////////////////////////-->
    <!--///////////////////////////////////////////////////////
       // Service section 
       //////////////////////////////////////////////////////////-->
    <section class="service-parlex" id="service">
    <section class="parlex-back">
      <div class="w-container">
        <div class="wrap">
          <div class="service-combo">
            <div class="services">
              <h1 class="service-heading">PRODUCT</h1>
              <h3 class="services-heading">E – SMARTs</h3>
              <div class="sepreater service"></div>
            </div>
            <div class="services-text">With ever expanding Education Sector & the increase in crimes against school going children in school premises and in school buses which has been on the rise now a days, so for a better & secured management has always been felt from years for the Child's Safety. </div>
            
             <div class="services-text">E-SMARTs is a signature product of Efficacious India Limited (EIL), embarking on this issue aiming completely to revolutionize the concept of Educational sector with Simple, Safe & Secured Management to provide robust Child Security.  The company is committed to create distinctive products and solutions that can make a substantial difference and make an impact in the existing Educational Sector by providing Smart Security and Tracking Solutions for Children.</div>
             
             
              <div class="services-text">We are the pioneers to build Security and Tracking features in Educational sector with E-Smarts, a Simple, Safe & Secured Management Software tool. We have a strong team of professionals with immense expertise of more than two decades in IT Security & Education field and we understand the need of the hour of the Educational sector. We envisioned the education sector for the future and exchanged different approaches towards the education management and security solutions to make it a reality.</div>
              
               <div class="services-text">E-SMARTs has been designed in such a way that it can be used in Schools, Colleges, Coaching Institutes & Universities operating from Single or Multiple premises/location covering wider geographies. Based on actual site condition our Business Development Team can assess the exact requirement and provide the most competitive proposal both in terms of cost and effectiveness.</div>
            <div class="w-row">
              <div class="w-col w-col-13 services-column">
                <div class="service-icon">
                  <img src="images/services/Motion-Video.png">
                </div>
                <h4 class="service-head">Fabulous Design & Easy to use DASHBOARD</h4>
              </div>
              <div class="w-col w-col-13">
                <div class="service-icon">
                   <img src="images/services/Web-Design-Development.png">
                </div>
                <h4 class="service-head">Secured & Automated Attendance Capturing </h4>
              </div>
              <div class="w-col w-col-13">
                                <div class="service-icon">
                  <img src="images/services/Print-Packaging.png">
                </div>
                <h4 class="service-head">SMS Notifications on Arrival & Departure of Child at school</h4>
              </div>
              <div class="w-col w-col-13">
                <div class="service-icon">
                 <img src="images/services/Branding-Identity.png">
                </div>
                <h4 class="service-head">Track the whereabouts of Child's bus, from any corner of the Globe via Internet.</h4>
              </div>
              
              <div class="w-col w-col-13">
                <div class="service-icon">
                  <img src="images/services/05.png">
                </div>
                <h4 class="service-head">Individual Logins which Enables Smooth & Seamless Interaction</h4>
              </div>
              
              <div class="w-col w-col-13">
                <div class="service-icon">
                  <img src="images/services/UX-UI.png">
                </div>
                <h4 class="service-head">	Environment Friendly & Paperless System to send Instant notification by SMS </h4>
              </div>
              
              
              
            </div>
          </div>
        </div>
      </div>
    </section>
  </section>
    <!--///////////////////////////////////////////////////////
       // End Service section 
       //////////////////////////////////////////////////////////-->
    <!--///////////////////////////////////////////////////////
       // Demo section 
       //////////////////////////////////////////////////////////-->
    <div class="team-parlex" id="demo">
        <div class="parlex5-back">
            <div class="w-container">
                <div class="wrap">
                    <div class="w-row exp-des">
                        <div class="w-col w-col-6 exp-col1">
                            <div class="col1-div">
                                <div class="experinc-box">
                                    <h3 class="experinc-box-h3">
                                        DEMO</h3>
                                    <p class="contact-para">
                                    </p>
                                    <div class="w-form">
                                    </div>
                                    <label for="Usertype" style="color: #fff; margin-bottom: 10px;">
                                        User Type</label>
                                    <select name="user-type" class="w-select">
                                        <option value="Select" selected>Select</option>
                                        <option value="Student">Students</option>
                                        <option value="Parents">Parents</option>
                                        <option value="Teachers">Teachers</option>
                                        <option value="Staff">Staff</option>
                                        <option value="Administrator">Administrator</option>
                                    </select>
                                    <label for="name" style="color: #fff; margin-bottom: 10px;">
                                        Username:</label>
                                    <input class="w-input" type="text" placeholder="Enter Username" name="cf_name">
                                    <label for="email" style="color: #fff; margin-bottom: 10px;">
                                        Password</label>
                                    <input class="w-input" placeholder="Enter  Password" type="password" name="cf_email">
                                    <br>
                                    <input class="w-button" type="submit" value="Submit">
                                    <div class="w-form-done">
                                        <p>
                                            Thank you! Your submission has been received!</p>
                                    </div>
                                    <div class="w-form-fail">
                                        <p>
                                            Oops! Something went wrong while submitting the form :(</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="w-col w-col-6 exp-col2">
                            <img style="padding-top: 100px;" src="images/Login/demo.png"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--///////////////////////////////////////////////////////
       // End Demo section 
       //////////////////////////////////////////////////////////-->
    <!--///////////////////////////////////////////////////////
       // Contact section 
       //////////////////////////////////////////////////////////-->
    <div class="contact-parlex" id="contact">
        <div class="parlex8-back">
            <div class="w-container">
                <div class="wrap">
                    <div class="w-row exp-des">
                        <div class="w-col w-col-6 exp-col1">
                            <div class="col1-div">
                                <div class="experinc-box">
                                    <h3 class="experinc-box-h3">
                                        CONTACT</h3>
                                    <p class="contact-para" style="color: #000;">
                                        <font style="font-size: 16px; font-weight: bold;">INDIA</font></p>
                                    <div style="margin-bottom: 30px;">

                                        <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>

                                        <div style="overflow: hidden; height: 300px; width: 350px;">
                                            <div id="gmap_canvas" style="height: 300px; width: 350px;">
                                            </div>
                                            <style>
                                                #gmap_canvas img
                                                {
                                                    max-width: none !important;
                                                    background: none !important;
                                                }
                                            </style>
                                            <a class="google-map-code" href="http://www.trivoo.net" id="get-map-data">www.trivoo.net</a></div>

                                        <script type="text/javascript">                                            function init_map() { var myOptions = { zoom: 14, center: new google.maps.LatLng(19.077693, 73.00709899999993), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById("gmap_canvas"), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(19.077693, 73.00709899999993) }); infowindow = new google.maps.InfoWindow({ content: "<b>1402, G Square Business Park, Plot 25 &amp; 26, Sector 30,Opp. Sanpada Station, Vashi, Navi Mumbai </b><br/>Plot 25 &amp; 26, Sector 30<br/>400703 Navi Mumbai" }); google.maps.event.addListener(marker, "click", function() { infowindow.open(map, marker); }); infowindow.open(map, marker); } google.maps.event.addDomListener(window, 'load', init_map);</script>

                                    </div>
                                    <p class="contact-para" style="color: #000;">
                                        Landline: +9122 -27816136/37
                                    </p>
                                    <p class="contact-para" style="color: #000;">
                                        Website: <a style="color: brown; text-decoration: none;" href="http://www.efficacious.co.in"
                                            title="Efficacious" target="_blank">www.efficacious.co.in</a>
                                    </p>
                                    <p class="contact-para" style="color: #000;">
                                        Email: <a style="color: brown; text-decoration: none;" href="mailto:sales@efficacious.co.in">
                                            sales@efficacious.co.in</a> | <a style="color: brown; text-decoration: none;" href="mailto:enquiry@efficacious.co.in">
                                                enquiry@efficacious.co.in</a> | <a style="color: brown; text-decoration: none;" href="mailto:info@efficacious.co.in">
                                                    info@efficacious.co.in</a>
                                    </p>
                                    <div style="border-bottom: 4px double rgba(255, 255, 255, 0.53); margin: 20px 0;">
                                    </div>
                                    <p class="contact-para" style="color: #000;">
                                        <font style="font-size: 16px; font-weight: bold;">DUBAI</font>
                                    </p>
                                    <div style="width: 350px; height: 300px; float: left; margin-left: -7px; margin-bottom: 30px;">
                                        <iframe width="360" scrolling="no" height="300" src="dubaimap.html"></iframe>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <p class="contact-para" style="color: #000;">
                                        Landline: +971-43124867/68
                                    </p>
                                    <p class="contact-para" style="color: #000;">
                                        Website: <a style="color: brown; text-decoration: none;" href="http://www.efficacioustech.com"
                                            title="Efficacioustech" target="_blank">www.efficacioustech.com </a>
                                    </p>
                                    <p class="contact-para" style="color: #000;">
                                        Email: <a style="color: brown; text-decoration: none;" href="mailto:sales@efficacioustech.co.in">
                                            sales@efficacioustech.co.in</a> | <a style="color: brown; text-decoration: none;"
                                                href="mailto:enquiry@efficacioustech.co.in">enquiry@efficacioustech.co.in</a>
                                        | <a style="color: brown; text-decoration: none;" href="mailto:info@efficacioustech.co.in">
                                            info@efficacioustech.co.in</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="w-col w-col-6 exp-col2">
                            <h3 class="experinc-box-h3">
                                Enquiry Form</h3>
                            <div class="col2-div">
                                <div class="w-form">
                                    <label for="school-name">
                                        School Name:</label>
                                    <asp:TextBox ID="txtSchoolname" CssClass="w-input" runat="server" placeholder="School name"></asp:TextBox>
                                    <%--<input class="w-input" type="text" placeholder="School name" name="cf_name">--%>
                                    <label for="contact person">
                                        Contact Name:</label>
                                    <asp:TextBox ID="txtcontactPerson" CssClass="w-input" runat="server" placeholder="Contact person"></asp:TextBox>
                                    <%--<input class="w-input" type="text" placeholder="Contact name" name="cf_name">--%>
                                    <label for="address">
                                        Address:</label>
                                    <asp:TextBox ID="txtAddress" CssClass="w-input message" runat="server" placeholder="Enter Address"></asp:TextBox>
                                    <%--<textarea class="w-input message" placeholder="Enter Address" name="cf_message"></textarea>--%>
                                    <%--<input class="w-input" type="text" placeholder="Enter City" name="cf_name">--%>
                                    <label for="state">
                                        State:</label>
                                    <asp:TextBox ID="txtState" CssClass="w-input" runat="server" placeholder="Enter State"></asp:TextBox>
                                    <label for="city">
                                        City:</label>
                                    <asp:TextBox ID="txtCity" CssClass="w-input" runat="server" placeholder="Enter City"></asp:TextBox>
                                    <label for="country">
                                        Country:</label>
<asp:TextBox ID="txtCountry" CssClass="w-input" runat="server" placeholder="Enter Country"></asp:TextBox>
                                    <label for="telephone">
                                        Telephone:</label>
                                    <asp:TextBox ID="txtPhone" CssClass="w-input" runat="server" placeholder="Enter Phone"></asp:TextBox>
                                    <label for="email">
                                        Email Address:</label>
                                    <asp:TextBox ID="txtEmail" CssClass="w-input" runat="server" placeholder="Enter Email"></asp:TextBox>
 				   <label for="Remark">
                                        Remark :</label>
                                    <asp:TextBox ID="txtRemark" CssClass="w-input" runat="server" placeholder="Enter Remark"></asp:TextBox>
                                                                       
					<br>
                                    
				     <asp:Button ID="ButSub1" TabIndex="1" OnClientClick="return checkSubValidation();"
                                            OnClick="btnSubSubmit_Click" CssClass="w-button" runat="server" Text="Submit" ForeColor="#419C06"
                                            Font-Bold="true"></asp:Button>
                                    <div class="w-form-done">
                                        <p>
                                            Thank you! Your submission has been received!</p>
                                    </div>
                                    <div class="w-form-fail">
                                        <p>
                                            Oops! Something went wrong while submitting the form :(</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--///////////////////////////////////////////////////////
       // End Contact section 
       //////////////////////////////////////////////////////////-->
    <!--///////////////////////////////////////////////////////
       // Demo section 
       //////////////////////////////////////////////////////////-->
    <div class="team-parlex" style="display: none;" id="login">
        <div class="parlex5-back">
            <div class="w-container">
                <div class="wrap">
                    <div class="w-row exp-des">
                        <div class="w-col w-col-6 exp-col1">
                            <div class="col1-div">
                                <div class="experinc-box">
                                    <h3 class="experinc-box-h3">
                                        Login</h3>
                                    <p class="contact-para">
                                    </p>
                                    <div class="w-form">
                                        <label for="Usertype" style="color: #fff; margin-bottom: 10px;">
                                            User Type</label>
                                        <asp:DropDownList ID="drpUserType" CssClass="w-select" runat="server">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>Student</asp:ListItem>
                                            <asp:ListItem>Parent</asp:ListItem>
                                            <asp:ListItem>Teacher</asp:ListItem>
                                            <asp:ListItem>Staff</asp:ListItem>
                                            <asp:ListItem>Administrator</asp:ListItem>
                                        </asp:DropDownList>
                                        <label for="name" style="color: #fff; margin-bottom: 10px;">
                                            Username:</label>
                                        <asp:TextBox ID="txtUserName" runat="server" class="w-input" placeholder="User name"></asp:TextBox>
                                        <%-- <input class="w-input" type="text" placeholder="Enter Username" name="cf_name">--%>
                                        <label for="email" style="color: #fff; margin-bottom: 10px;">
                                            Password</label>
                                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="w-input"
                                            placeholder="Password"></asp:TextBox>
                                        <%--<input class="w-input" placeholder="Enter  Password" type="password" name="cf_email"
                                            required>--%>
                                        <br>
                                        <asp:Button ID="btnSubmit" TabIndex="1" OnClientClick="return checkValidation();"
                                            OnClick="btnSubmit_Click" CssClass="w-button" runat="server" Text="Log in" ForeColor="#419C06"
                                            Font-Bold="true"></asp:Button>
                                        <%--<input class="w-button" type="submit" value="Submit">--%>
                                        <div class="w-form-done">
                                            <p>
                                                Thank you! Your submission has been received!</p>
                                        </div>
                                        <div class="w-form-fail">
                                            <p>
                                                Oops! Something went wrong while submitting the form :(</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="w-col w-col-6 exp-col2">
                            <img style="padding-top: 100px; padding-left: 53px;" src="images/Login/login.png"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--///////////////////////////////////////////////////////
       // End Demo section 
       //////////////////////////////////////////////////////////-->
    <!--///////////////////////////////////////////////////////
       // Footer section 
       //////////////////////////////////////////////////////////-->
    <div class="footer-parlex">
        <div class="parlex9-back">
            <div class="w-container">
                <div class="wrap">
                    <img class="footer-logo" src="esmarts-logo.png" alt="Elegance">
                    <!--<div class="footer-social">
            <div class="fotter-social-wrap">
              <a href="https://www.facebook.com/"><img class="fotter-social" src="images/social/Facebook.png" alt="52dd249c929b601f5400054c_Facebook.png"></a>
              <a href="https://www.twitter.com/"><img class="fotter-social" src="images/social/Twitter.png" alt="52dd24f2929b601f54000551_Twitter.png"></a>
              <a href="https://plus.google.com/"><img class="fotter-social" src="images/social/Google-plus.png" alt="52dd26a55b54031d540005af_Google-plus.png"></a>
              <a href="https://www.blogger.com/"><img class="fotter-social" src="images/social/Blogger.png" alt="52de52e7b6d2171f78000414_Blogger.png"></a>
              <a href="https://www.digg.com/"><img class="fotter-social" src="images/social/Digg.png" alt="52de53174702a71e780003c3_Digg.png"></a>
              <a href="https://www.pinterest.com/"><img class="fotter-social" src="images/social/Pinterest.png" alt="52de533c5d3566c1430003e9_Pinterest.png"></a>
              <a href="https://www.flicker.com/"><img class="fotter-social" src="images/social/Flickr.png" alt="52de535f1b42bfc24300049e_Flickr.png"></a>
              <a href="https://www.vimeo.com/"><img class="fotter-social" src="images/social/Vimeo.png" alt="52de537cb6d2171f7800041c_Vimeo.png"></a>
              <a href="https://www.myspace.com/"><img class="fotter-social" src="images/social/Myspace.png" alt="52de53954702a71e780003c5_Myspace.png"></a>
              <a href="https://www.stumbleupon.com/"><img class="fotter-social" src="images/social/Stumbleupn.png" alt="52de53c0b6d2171f7800041e_Stumbleupn.png"></a>
              <a href="https://www.tumblr.com/"><img class="fotter-social" src="images/social/Tumblr.png" alt="52de54021b42bfc2430004a3_Tumblr.png"></a>
              <a href="https://www.youtube.com/"><img class="fotter-social" src="images/social/Youtube.png" alt="52de54495d3566c14300040a_Youtube.png"></a>
            </div>
          </div>-->
                    <div>
                        <p class="copyright-area" style="color: #424242; font-size: 12px;">
                            ©2014 . All Rights Reserved by Efficacious India Limited
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <!--///////////////////////////////////////////////////////
       // End Footer section 
       //////////////////////////////////////////////////////////-->
    </form>
</body>
</html>

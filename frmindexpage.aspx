<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="frmindexpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Efficacious</title>
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="css/menu.css" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script>
        $(document).ready(function() {
            $('#login-trigger').click(function() {
                $(this).next('#login-content').slideToggle();
                $(this).toggleClass('active');

                if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
                else $(this).find('span').html('&#x25BC;')
            })
        });
    </script>

</head>
<body style="background: #f5f5f5;">
    <div class="minibar">
        <div class="minibar_container">
            <div class="top-social">
                <div class="contact">
                    <img src="img/social-icon/facebook.jpg" title="efficacious facebook" />
                    <img src="img/social-icon/linkedin.jpg" title="efficacious linkedin" />
                    <img src="img/social-icon/googleplus.jpg" title="efficacious googleplus" />
                    <img src="img/social-icon/twitter.jpg" title="efficacious twitter" />
                </div>
                <div class="top-link">
                    <ul class="eff">
                        <li id="login"><a id="login-trigger" href="#">Log in </a>
                            <div id="login-content">
                                <form runat="server">
                                <fieldset id="inputs" style="border: none;">
                                    <%--<select name="drpUserType" id="drpUserType" class="w-select">
                                        <option value="---Select---">---Select---</option>
                                        <option value="Student">Student</option>
                                        <option value="Parent">Parent</option>
                                        <option value="Teacher">Teacher</option>
                                        <option value="Staff">Staff</option>
                                        <option value="Administrator">Administrator</option>
                                    </select>--%>
                                    <asp:DropDownList ID="drpUserType" CssClass="w-select" runat="server">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Parent</asp:ListItem>
                                        <asp:ListItem>Teacher</asp:ListItem>
                                        <asp:ListItem>Staff</asp:ListItem>
                                        <asp:ListItem>Administrator</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtUserName" runat="server" class="w-input" placeholder="User name"></asp:TextBox>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="w-input"
                                        placeholder="Password"></asp:TextBox>
                                </fieldset>
                                <fieldset id="actions">
                                    <%--<input type="submit" id="submit" value="Log in">--%>
                                    <asp:Button ID="btnSubmit" TabIndex="1" OnClientClick="return checkValidation();"
                                        OnClick="btnSubmit_Click" CssClass="w-button" runat="server" Text="Log in" Font-Bold="true">
                                    </asp:Button>
                                    <!--<label><input type="checkbox" checked="checked"> Keep me signed in</label>-->
                                </fieldset>
                                </form>
                            </div>
                        </li>
                    </ul>
                    <strong></strong>
                </div>
            </div>
            <!--top-social -->
        </div>
        <!--minibar_container -->
    </div>
    <!--minibar -->
    <div class="clearfix">
    </div>
    <div class="wrapper">
        <div class="pagewrapper">
            <div class="logo">
                <div class="esmart">
                    <img src="img/logo/logo.png" width="194" height="57" alt="emart" /><br />
                    <font style="font-size: 10px; font-family: Georgia, 'Times New Roman', Times, serif;">
                        Student Management and Remote Tracking System</font>
                </div>
                <div class="email">
                    <div class="call-number">
                        <img align="left" style="padding-right: 10px;" src="img/social-icon/call.png" />:
                        +91-22-49707524</div>
                    <div class="clearfix">
                    </div>
                    <div class="email-info">
                        <img align="left" style="padding-right: 10px;" src="img/social-icon/email.png" />:
                        info@efficacious.co.in</div>
                </div>
                <div class="efficacious-logo">
                    <img src="img/logo/efficacious-log.png" width="200" height="70" alt="efficacious" /></div>
            </div>
            <div class="clearfix">
            </div>
            <div class="top-nav">
                <nav id="nav" role="navigation">
	<a href="#nav" title="Show navigation">Show navigation</a>
	<a href="#" title="Hide navigation">Hide navigation</a>
	<ul class="clearfix">
		<li class="active"><a href="index.aspx">Home</a></li>
		<li>
			<a href="about.html" aria-haspopup="true">About</a>
			<!--<ul>
				<li><a href="?design">Design</a></li>
				<li><a href="?html">HTML</a></li>
				<li><a href="?css">CSS</a></li>
				<li><a href="?javascript">JavaScript</a></li>
			</ul>-->
		</li>
		<li>
			<a href="product.html" aria-haspopup="true">Product</a>
			<!--<ul>
				<li><a href="?webdesign">Web Design</a></li>
				<li><a href="?typography">Typography</a></li>
				<li><a href="?frontend">Front-End</a></li>
			</ul>-->
		</li>
        <li>
			<a href="http://www.e-smarts.net/demo/" target="_blank" aria-haspopup="true">Demo</a>
			<!--<ul>
				<li><a href="?webdesign">Web Design</a></li>
				<li><a href="?typography">Typography</a></li>
				<li><a href="?frontend">Front-End</a></li>
			</ul>-->
		</li>
        <li>
			<a href="contact.html" aria-haspopup="true">Contact</a>
			<!--<ul>
				<li><a href="?webdesign">Web Design</a></li>
				<li><a href="?typography">Typography</a></li>
				<li><a href="?frontend">Front-End</a></li>
			</ul>-->
		</li>
        <li>
			<a href="pdf/E-smarts-Brochure.pdf" target="_blank" aria-haspopup="true">Brochure</a>
			<!--<ul>
				<li><a href="?webdesign">Web Design</a></li>
				<li><a href="?typography">Typography</a></li>
				<li><a href="?frontend">Front-End</a></li>
			</ul>-->
		</li>
        <!-- <li>
			<a href="?work" aria-haspopup="true"><span>Brochure</span></a>
			<ul>
				<li><a href="?webdesign">Web Design</a></li>
				<li><a href="?typography">Typography</a></li>
				<li><a href="?frontend">Front-End</a></li>
			</ul>
		</li>-->
		<!--<li><a href="?about">About</a></li>-->
	</ul>
</nav>
            </div>
            <div class="clearfix">
            </div>
            <div class="banner">
                <div id="ei-slider" class="ei-slider">
                   <ul class="ei-slider-large">
                    <li>
                        <img src="img/large/banner-01.png" alt="image06" />
                       <div class="ei-title">
                            <h2>
                                
                                Completely Integrated Solution for Educational Institutes to Address Need of the Hour “Child Security”.
                            </h2>
                        </div>
                    </li>
                   <%-- <li>
                        <img src="img/large/2.jpg" alt="image06" />
                        <div class="ei-title">
                            <h2>
                                An Innovative Technological Tool Created, Designed & Developed SMARTLY For Educational
                                Sector</h2>
                        </div>
                    </li>--%>
                    <li>
                        <img src="img/large/3.jpg" alt="image06" />
                        <div class="ei-title">
                            <h2>
                                Secured Attendance Capturing System.
                                
                                </h2>
                        </div>
                    </li>
                    <li>
                        <img src="img/large/4.jpg" alt="image06" />
                        <div class="ei-title">
                            <h2>
                             Easily Accessible from any Corner of the Globe via Internet.
                             </h2>
                        </div>
                    </li>
                    <li>
                        <img src="img/large/5.jpg" alt="image06" />
                        <div class="ei-title">
                            <h2>
                                   Real - Time School Bus Tracking & Generating Instant Notifications.
                                   
                                   </h2>
                        </div>
                    </li>
                    
                </ul>
                <!-- ei-slider-large -->
                <ul class="ei-slider-thumbs" >
                    <li class="ei-slider-element" style="display:none !important;" >Current</li>
                    <li style="display:none !important;"><a href="#">Slide 1</a></li>
                    <li style="display:none !important;"><a href="#">Slide 2</a></li>
                    <li style="display:none !important;"><a href="#">Slide 3</a></li>
                    <li style="display:none !important;"><a href="#">Slide 4</a></li>
                   
                </ul>
                    <!-- ei-slider-thumbs -->
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="efficacious_content">
                <p>
                    With the changing life style, rapid urbanization, evolvement of nuclear family concept
                    wherein both the Parents are working & with the increase in crime rate against
                    school going children need for a better and secured monitoring system for Child
                    Safety both inside the school premises and during their journey in school buses
                    is the need of the hour.</p>
                <p>
                    E-SMARTs is a signature product of Efficacious India Limited (EIL), embarking on
                    this issue aiming completely to revolutionize the concept of School Management with
                    Simple, Safe & Secured solution to provide robust Child Security. The company is
                    committed to create distinctive products and solutions that can make a substantial
                    difference and make an impact in the existing Educational Sector functioning by
                    providing Smart Security and Tracking Solutions for Children.</p>
                <p>
                    We are the pioneers to build & include Security and Tracking features in Educational
                    sector with E-Smarts, a Simple, Safe & Secured Management Software tool. We have
                    a strong team of professionals with immense expertise of more than two decades in
                    IT Security & Education field and we understand the need of the hour of the Educational
                    sector. We envisioned the education sector for the future and exchanged different
                    approaches towards the education management and security solutions to make it a
                    reality.</p>
            </div>
        </div>
        <!--pagewrapper -->
    </div>
    <!--wrapper-end -->
    <div class="clearfix">
    </div>
    <div class="footer">
        <div class="footer_container">
            <div class="copyright">
                ©2015 . All Rights Reserved by Efficacious India Limited</div>
            <div class="privacypolicy">
                Disclaimer | Privacy Policy | Terms & Conditions</div>
        </div>
    </div>

    <script src="jquery/jquery.min.js"></script>

    <script src="jquery/doubletaptogo.js"></script>

    <script>
        $(function() {
            $('#nav li:has(ul)').doubleTapToGo();
        });
    </script>

    <script src="jquery/main.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>

    <script type="text/javascript" src="js/jquery.eislideshow.js"></script>

    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>

    <script type="text/javascript">
        $(function() {
            $('#ei-slider').eislideshow({
                animation: 'center',
                autoplay: true,
                slideshow_interval: 3000,
                titlesFactor: 0
            });
        });
    </script>

</body>
</html>

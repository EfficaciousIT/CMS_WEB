<%@ Page Language="C#" MasterPageFile="~/loginMaster.master" AutoEventWireup="true"
    CodeFile="Product.aspx.cs" Inherits="Product" Title="E-SMARTs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix">
    </div>
    <div class="pagewrapper">
        <div class="top-nav">
            <nav id="nav" role="navigation">
	<a href="#nav" title="Show navigation">Show navigation</a>
	<a href="#" title="Hide navigation">Hide navigation</a>
	<ul >
		<li ><a href="Home.aspx">Home</a></li>
		 <li>
			<a href="About.aspx" aria-haspopup="true">About</a>
			<!--<ul>
				<li><a href="?design">Design</a></li>
				<li><a href="?html">HTML</a></li>
				<li><a href="?css">CSS</a></li>
				<li><a href="?javascript">JavaScript</a></li>
			</ul>-->
		</li>
		<li class="active">
			<a href="Product.aspx" aria-haspopup="true">Product</a>
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
     <li >
			<a href="contact.aspx" aria-haspopup="true">Contact</a>
			<!--<ul>
				<li><a href="?webdesign">Web Design</a></li>
				<li><a href="?typography">Typography</a></li>
				<li><a href="?frontend">Front-End</a></li>
			</ul>-->
		</li>
        <li>
			<a href="pdf/E-smarts-Brochure.pdf" download target="_blank" aria-haspopup="true">Brochure</a>
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
            <h1>
                E – SMARTs</h1>
            <p>
                With ever expanding Education Sector & the increase in crimes against school going
                children in school premises and in school buses which has been on the rise now a
                days, so for a better & secured management has always been felt from years for the
                Child's Safety.</p>
            <p>
                E-SMARTs is a signature product of Efficacious India Limited (EIL), embarking on
                this issue aiming completely to revolutionize the concept of Educational sector
                with Simple, Safe & Secured Management to provide robust Child Security. The company
                is committed to create distinctive products and solutions that can make a substantial
                difference and make an impact in the existing Educational Sector by providing Smart
                Security and Tracking Solutions for Children.</p>
            <p>
                We are the pioneers to build Security and Tracking features in Educational sector
                with E-Smarts, a Simple, Safe & Secured Management Software tool. We have a strong
                team of professionals with immense expertise of more than two decades in IT Security
                & Education field and we understand the need of the hour of the Educational sector.
                We envisioned the education sector for the future and exchanged different approaches
                towards the education management and security solutions to make it a reality.</p>
            <p>
                E-SMARTs has been designed in such a way that it can be used in Schools, Colleges,
                Coaching Institutes & Universities operating from Single or Multiple premises/location
                covering wider geographies. Based on actual site condition our Business Development
                Team can assess the exact requirement and provide the most competitive proposal
                both in terms of cost and effectiveness.</p>
            <div class="clearfix">
            </div>
            <div class="products-description">
                <img src="img/products/01.png" /><br />
                Fabulous Design &<br />
                Easy to use DASHBOARD</div>
            <div class="products-description-middle">
                <img src="img/products/02.png" /><br />
                Secured & Automated<br />
                Attendance Capturing</div>
            <div class="products-description">
                <img src="img/products/03.png" /><br />
                SMS Notifications on Arrival<br />
                & Departure of Child at school</div>
            <div class="clearfix">
            </div>
            <div class="products-description">
                <img src="img/products/04.png" /><br />
                Track the whereabouts of Child's bus,
                <br />
                from any corner of the Globe via Internet.</div>
            <div class="products-description-middle">
                <img src="img/products/05.png" /><br />
                Individual Logins which Enables<br />
                Smooth & Seamless Interaction</div>
            <div class="products-description">
                <img src="img/products/06.png" /><br />
                Environment Friendly & Paperless System<br />
                to send Instant notification by SMS</div>
        </div>
    </div>
    <div class="clearfix">
    </div>
</asp:Content>

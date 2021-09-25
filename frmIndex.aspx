<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmIndex.aspx.cs" Inherits="frmIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="google-site-verification" content="4D7p6rl0d1HxjKvus6VxPRdji2wBmHEPhv9BSp_AMA4" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Student Management and Remote Tracking System</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"> </script>

    <script type="text/javascript" src="js/script.js"></script>

    <style type="text/css">
        @charset@charset@charset@charset@charset"utf-8";/* CSS Document */
        *
        {
            margin: 0;
            padding: 0;
        }
        header, section, article, nav, aside, footer, video, audio, datalist, details
        {
            display: block;
        }
        img
        {
            display: block;
        }
        p
        {
            font-size: 14px;
            line-height: 18px;
            text-align: left; ;}
        h1, h2, h3, h4, h5
        {
            font-size: 18px;
            color: blue;
        }
        .wrapper
        {
            width: 100%;
            height: auto;
        }
        .pagewrapper
        {
            width: 1024px;
            height: auto;
            margin: 0 auto;
        }
        .top-home
        {
            width: 1024px;
            height: 200px;
            float: left;
            margin-bottom: 30px;
            border-bottom: 1px solid #429d07;
        }
        .top-left
        {
            width: 250px;
            height: auto;
            float: left;
        }
        .top-middle
        {
            width: 1024px;
            height: auto;
            float: left;
        }
        .top-right
        {
            width: 768px;
            height: auto;
            float: right;
        }
        .top-enquiry
        {
            width: 276px;
            padding-top: 15px;
            height: 40px;
            float: left;
            font-size: 14px;
            font-weight: bold;
            color: #429d07;
        }
        .top-contact
        {
            width: 180px;
            height: 40px;
            float: left;
            padding-left: 46px;
            padding-top: 19px;
            font-size: 14px;
            font-weight: bold;
            color: #429d07;
            background: url(images/contact.png) no-repeat 10px 14px;
        }
        .top-social
        {
            width: 230px;
            padding: 0 13px;
            height: 40px;
            float: left;
            padding-top: 15px;
        }
        .middle-home
        {
            width: 1024px;
            height: 290px;
            float: left;
        }
        .middle-left
        {
            width: 1024px;
            height: auto;
            float: left;
        }
        .middle-right
        {
            width: 1024px;
            height: auto;
            float: left;
        }
        .bottom-home
        {
            width: 1024px;
            height: 300px;
            float: left;
            margin-top: 20px;
        }
        .bottom-left
        {
            width: 1024px;
            height: auto;
            float: left;
        }
        .bottom-middle
        {
            width: 1024px;
            height: auto;
            float: left;
            text-align: left;
        }
        .bottom-right
        {
            width: 1024px;
            height: auto;
            float: left;
        }
        .clearfix
        {
            clear: both;
            margin: 0;
        }
        .enquiry
        {
            width: 150px;
            height: 25px;
            padding-left: 10px;
            margin-left: 10px;
            border: 1px solid #000;
        }
        .middle-left
        {
            width: 648px;
            height: 280px;
            float: left;
            padding-left: 12px;
            background: url(images/flash-banner.png) no-repeat;
        }
        .middle-right
        {
            width: 310px;
            height: auto;
            float: left;
            padding-left: 15px;
        }
        .linkdin
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .facebook
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .googleplus
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .twitter
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .youtube
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .rss
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .pintrest
        {
            width: 30px;
            height: 30px;
            float: left;
        }
        .home-nav
        {
            width: 484px;
            padding: 44px 0 0 281px;
            float: left;
            height: auto;
            border-top: 1px solid #429d07;
        }
        .product-btn
        {
            width: 71px;
            height: 71px;
            float: left;
            padding: 5px 10px;
        }
        .abt-btn
        {
            width: 71px;
            height: 71px;
            float: left;
            padding: 5px 10px;
        }
        .contact-btn
        {
            width: 71px;
            height: 71px;
            float: left;
            padding: 5px 10px;
        }
        .login-btn
        {
            width: 71px;
            height: 71px;
            float: left;
            padding: 5px 0px 5px 10px;
        }
        .home-btn
        {
            width: 71px;
            height: 71px;
            float: left;
            padding: 5px 10px;
        }
        #backgroundPopup
        {
            z-index: 1;
            position: fixed;
            display: none;
            height: 100%;
            width: 100%;
            background: #000000;
            top: 0px;
            left: 0px;
        }
        #toPopup
        {
            font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 10px solid #ccc;
            border-radius: 3px 3px 3px 3px;
            color: #333333;
            display: none;
            font-size: 14px;
            left: 50%;
            margin-left: -244px;
            position: fixed;
            top: 20%;
            width: 443px;
            z-index: 2;
        }
        #addressLocation
        {
        	font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 10px solid #ccc;
            border-radius: 3px 3px 3px 3px;
            color: #333333;
            display: none;            
            left: 50%;
            margin-left: -300px;
            position: fixed;
            top: 20%;
            width: 610px;
            z-index: 2;
        }
        #DivAboutUS
        {
        	font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 10px solid #ccc;
            border-radius: 3px 3px 3px 3px;
            color: #333333;
            display: none;            
            left: 50%;
            margin-left: -480px;
            margin-top:-100px;
            position: fixed;
            top: 20%;
            width: 930px;
            z-index: 2;
        }
	#DivProduct
        {
        	font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 10px solid #ccc;
            border-radius: 3px 3px 3px 3px;
            color: #333333;
            display: none;            
            left: 50%;
            margin-left: -480px;
            margin-top:-100px;
            position: fixed;
            top: 20%;
            width: 930px;
            z-index: 2;
        }
        div.loader
        {
            background: url("../img/loading.gif") no-repeat scroll 0 0 transparent;
            height: 32px;
            width: 32px;
            display: none;
            z-index: 9999;
            top: 40%;
            left: 50%;
            position: absolute;
            margin-left: -10px;
        }
        div.close
        {
            background: url("img/closebox.png") no-repeat scroll 0 0 transparent;
            cursor: pointer;
            height: 30px;
            position: absolute;
            right: -27px;
            top: -24px;
            width: 30px;
        }
        span.ecs_tooltip
        {
            background: none repeat scroll 0 0 #000000;
            border-radius: 2px 2px 2px 2px;
            color: #FFFFFF;
            display: none;
            font-size: 11px;
            height: 16px;
            opacity: 0.7;
            padding: 4px 3px 2px 5px;
            position: absolute;
            right: -62px;
            text-align: center;
            top: -51px;
            width: 93px;
        }
        span.arrow
        {
            border-left: 5px solid transparent;
            border-right: 5px solid transparent;
            border-top: 7px solid #000000;
            display: block;
            height: 1px;
            left: 40px;
            position: relative;
            top: 3px;
            width: 1px;
        }
        div#popup_content
        {
            margin: 4px 7px; /* remove this comment if you want scroll bar
            
    overflow-y:scroll;
    height:200px
    */
        }
        div#addresspopup_content
        {
            margin: 4px 7px; /* remove this comment if you want scroll bar
            
    overflow-y:scroll;
    height:200px DivAboutUS
    */
        }
 	div#DivProduct_content
        {
            margin: 4px 7px;
             overflow-y:scroll;
            height:600px 
            
             /* remove this comment if you want scroll bar            
            overflow-y:scroll;
            height:200px 
            */
        }
        div#DivAboutUS_content
        {
	     margin: 4px 7px;
             overflow-y:scroll;
             height:600px 
        }
        .bottom-left
        {
            width: 250px;
            height: 300px;
            float: left;
        }
        .bottom-middle
        {
            width: 488px;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            font-size: 14px;
            text-align: center;
            height: 300px;
            float: left;
            margin: 0 17px;
            border-right: 1px solid #429d07;
            border-left: 1px solid #429d07;
        }
        .bottom-right
        {
            width: 250px;
            height: 300px;
            float: left;
        }
        .recenta
        {
            width: 250px;
            height: 30px;
            float: left;
            background: #419C06;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            font-size: 14px;
            text-align: center;
            padding-top: 10px;
            margin-bottom: 10px;
        }
        .rcontent
        {
            width: 250px;
            height: 138px;
            float: left;
            font-family: Verdana, Geneva, sans-serif;
            font-size: 12px;
            text-align: left;
            padding-top: 10px;
        }
        .testimonials
        {
            width: 250px;
            height: 30px;
            float: left;
            background: #419C06;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            font-size: 14px;
            color: #FFF text-align: center;
            padding-top: 10px;
            margin-bottom: 10px;
        }
        .cmdmessege
        {
            width: 250px;
            height: 30px;
            float: left;
            background: #419C06;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            color: #FFF;
            font-size: 14px;
            text-align: center;
            padding-top: 10px;
            margin-bottom: 10px;
        }
        .aboutEfficacious
        {
            width: 488px;
            height: 30px;
            float: left;
            background: #419C06;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            color: #FFF;
            font-size: 14px;
            text-align: center;
            padding-top: 10px;
            margin-bottom: 10px;
        }
        .aboutEfficaciousContent
        {
            width: 488px;
            height: 200px;
            float: left;
            font-family: Verdana, Geneva, sans-serif;
            font-size: 12px;
            font-weight:normal;
            text-align: left;
            padding-top: 10px;
        }
 .cmdEnquiry
        {
            width: 610px;
            height: 30px;
            float: left;
            background: #419C06;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            color: #FFF;
            font-size: 14px;
            text-align: center;
            padding-top: 10px;
            margin-bottom: 10px;
        }
       
        .mdmessege
        {
            width: 250px;
            height: 30px;
            float: left;
            background: #419C06;
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            font-size: 14px;
            text-align: center;
            padding-top: 10px;
            margin-bottom: 10px;
        }
        .name
        {
            width: 250px;
            height: 30px;
            float: left;
            border: 1px solid #242424;
            padding-left: 10px;
            font-size: 14px;
            font-family: Verdana, Geneva, sans-serif;
            color: #000;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
        .password
        {
            width: 250px;
            height: 30px;
            float: left;
            border: 1px solid #242424;
            padding-left: 10px;
            font-size: 14px;
            font-family: Verdana, Geneva, sans-serif;
            color: #000;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
        .button
        {
            width: 250px;
            height: 30px;
            float: left;
            border: 1px solid #419C06;
            padding-left: 10px;
            font-size: 14px;
            font-family: Verdana, Geneva, sans-serif;
            color: #999999;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
        .userType
        {
            width: 250px;
            height: 30px;
            float: left;
            border: 1px solid #242424;
            font-size: 14px;
            font-family: Verdana, Geneva, sans-serif;
            color: #000;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
    </style>

    <script type="text/javascript">
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
    </script>

    <script>
        function checkValidation() {
            var txtUserName = document.getElementById('txtUserName').value;
            var txtPassword = document.getElementById('txtPassword').value;
            var drpUserType = document.getElementById('drpUserType').value;
            if (drpUserType == '---Select---') {
                alert('Select User Type');
                return false;
            }
            if (txtUserName == '') {
                alert('Enter username');
                return false;
            }
            if (txtPassword == '') {
                alert('Enter password');
                return false;
            }
        }
    </script>

</head>
<body onload="MM_preloadImages('images/linkdin-h.png','images/facebook-h.png','images/google-plus-h.png','images/twitter-h.png','images/youtube-h.png','images/rss-h.png','images/pintrest-h.png','images/Layer6.png','images/Layer7.png','images/Layer10.png','images/Layer12.png','images/Layer14.png')">
    <form runat="server">
    <div class="wrapper">
        <div class="pagewrapper">
            <div class="top-home">
                <div class="top-left">
                    <img src="images/Logo.png" width="230px" height="170px" />
                </div>
                <div class="top-right">
                    <div class="top-enquiry">
                        Enquiry<input type="text" class="enquiry" placeholder="Enquiry" /></div>
                    <div class="top-contact">
                        - 022 - 27816136/37</div>
                    <div class="top-social">
                        <div class="linkdin">
                            <a href="https://www.linkedin.com/company/efficacious?" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('linkdin','','images/linkdin-h.png',1)">
                                <img src="images/linkdin-m.png" width="28" height="26" id="linkdin" /></a></div>
                        <div class="facebook">
                            <a href="https://www.facebook.com/efficacioustech" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image3','','images/facebook-h.png',1)">
                                <img src="images/facebook-m.png" width="28" height="26" id="Image3" /></a></div>
                        <div class="googleplus">
                            <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image4','','images/google-plus-h.png',1)">
                                <img src="images/google-plus-m.png" width="28" height="26" id="Image4" /></a></div>
                        <div class="twitter">
                            <a href="https://twitter.com/efficacioustec" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image5','','images/twitter-h.png',1)">
                                <img src="images/twitter-m.png" width="28" height="26" id="Image5" /></a></div>
                        <div class="youtube">
                            <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image6','','images/youtube-h.png',1)">
                                <img src="images/youtube-m.png" width="28" height="26" id="Image6" /></a></div>
                        <div class="rss">
                            <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image7','','images/rss-h.png',1)">
                                <img src="images/rss-m.png" width="28" height="26" id="Image7" /></a></div>
                        <div class="pintrest">
                            <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image8','','images/pintrest-h.png',1)">
                                <img src="images/pintrest-m.png" width="28" height="26" id="Image8" /></a></div>
                    </div>
                    <div class="clearfix">
                    </div>
                    <div class="home-nav">
                        <div class="home-btn">
                            <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image9','','images/Layer6.png',1)">
                                <img src="images/Layer5.png" width="71" height="71" id="Image9" /></a></div>
                        <div class="abt-btn">
                            <a href="#" class="DivAboutUS" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/Layer7.png',1)">
                                <img src="images/Layer8.png" width="71" height="72" id="Image10" /></a></div>
                        <div class="product-btn">
                            <a href="#" class="DivProduct"  onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image11','','images/Layer10.png',1)">
                                <img src="images/Layer9.png" width="71" height="71" id="Image11" /></a></div>
                        <div class="contact-btn">
                            <a href="#" class="addressLocation" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image12','','images/Layer12.png',1)">
                                <img src="images/Layer11.png" width="72" height="71" id="Image12" /></a></div>
                        <div class="login-btn">
                            <a href="#" class="topopup" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image13','','images/Layer14.png',1)">
                                <img src="images/Layer13.png" width="71" height="71" id="Image13" /></a></div>
                        <div id="toPopup">
                            <div class="close">
                            </div>
                            <span class="ecs_tooltip">Press Esc to close <span class="arrow"></span></span>
                            <div id="popup_content">
                                <!--your content start-->
                                <div style="width: 300px; float: left; height: 80px; padding-left: 90px;">
                                    <label style="display: block; font-family: Verdana, Geneva, sans-serif; font-size: 14px;
                                        width: 100%; height: 30px; float: left;" for="name">
                                        User Type :</label>
                                    <asp:DropDownList ID="drpUserType" CssClass="userType" runat="server">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Parent</asp:ListItem>
                                        <asp:ListItem>Teacher</asp:ListItem>
                                        <asp:ListItem>Staff</asp:ListItem>
                                        <asp:ListItem>Administrator</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="width: 300px; float: left; height: 80px; padding-left: 90px;">
                                    <label style="display: block; font-family: Verdana, Geneva, sans-serif; font-size: 14px;
                                        width: 100%; height: 30px; float: left;" for="name">
                                        Name:</label>
                                    <%--<input type="text" id="name" value="" placeholder="Enter your user name" />--%>
                                    <asp:TextBox ID="txtUserName" CssClass="name" runat="server" placeholder="Enter your user name"></asp:TextBox>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div style="width: 300px; float: left; height: 80px; padding-left: 90px;">
                                    <label style="display: block; font-family: Verdana, Geneva, sans-serif; font-size: 14px;
                                        width: 100%; height: 30px; float: left;" for="name">
                                        Password:</label>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="password" runat="server"
                                        placeholder="Enter your password"></asp:TextBox>
                                    <%--<input type="password" id="password" value="" placeholder="Enter your password" />--%>
                                </div>
                                <div style="width: 300px; float: left; height: 80px; padding-left: 90px;">
                                    <asp:Button ID="btnSubmit" OnClientClick="return checkValidation();" OnClick="btnSubmit_Click"
                                        CssClass="button" runat="server" Text="Log in" ForeColor="#419C06" Font-Bold="true">
                                    </asp:Button>
                                </div>
                                <p align="center">
                                    <a href="#" style="padding-left: 90px;" class="topopup">Forget Password</a>
                                </p>
                            </div>
                            <!--your content end-->
                        </div>
                        <div id="addressLocation">
                            <div class="close">
                            </div>
                            <span class="ecs_tooltip">Press Esc to close <span class="arrow"></span></span>
                            <div id="addresspopup_content">
                                <img src="images/Address.png" width="600px" height="350px" id="Image13" />
                            </div>
			<div ><a href="FrmEquiry_Form.aspx" class="cmdEnquiry" >Enquiry</a></div>
                            <!--your content end-->
                        </div>
 			<div id="DivProduct">
                           <div class="close">
                            </div>
                            <span class="ecs_tooltip">Press Esc to close <span class="arrow"></span></span>
                            <div id="DivProduct_content" >
                                
                                <img src="images/About E-Smarts1.png"  width="900px"  id="Img2" />
                            </div>
                         
                        </div>
                        <div id="DivAboutUS">
                            <div class="close">
                            </div>
                            <span class="ecs_tooltip">Press Esc to close <span class="arrow"></span></span>
                            <div id="DivAboutUS_content">
                                <%--<img src="images/About E-Smarts.png"width="900px" height="580px" id="Img1" />--%>
                               <%-- <iframe frameborder="1" src="www.google.com" width="900" height="580">
                                </iframe>--%>
				 <img src="images/About us.png"  width="900px"  id="Img1" /> 
                            </div>
                            <!--your content end-->
                        </div>
                        <!--toPopup end-->
                    </div>
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="middle-home">
                <div class="middle-left">
                </div>
                <div class="middle-right">
                    <img src="images/smarts-logo-home.png" style="margin: 20px 0;" width="300" height="109"
                        alt="smarts" />
                    <p style="font-family: Verdana, Geneva, sans-serif; font-size: 14px; line-height: 22px;
                        font-weight: bold; text-align: center;">
                        An Innovative Technological Tool Created, Designed & Developed SMARTly for Educational
                        Sector.</p>
                </div>
            </div>
            <div class="bottom-home">
                <div class="bottom-left">
                    <div class="cmdmessege">
                        Recent Activity</div>
                    <div class="clearfix">
                    </div>
                    <div class="rcontent">
                        content</div>
                    <div class="cmdmessege">
                        Testimonials</div>
                    <div class="clearfix">
                    </div>
                    <div class="rcontent">
                        content</div>
                </div>
                <div class="bottom-middle">
                    <div class="aboutEfficacious">
                        About Efficacious</div>
                    <div class="aboutEfficaciousContent">
                        <span>&nbsp;&nbsp;&nbsp;&nbsp; Efficacious is the synonym to efficient aims to 
                        provide innovative &amp; efficient solution to the complex needs of Customer&#39;s to 
                        make their life Safe, Secure &amp; Easy. Efficacious Technologies LLC is the company 
                        incorporated with the basic aim of bringing the best of the enterprise 
                        software’s with specialized solution in the given vertical available in the 
                        Indian market to Middle East and Africa. The company offers a dual advantage of 
                        providing the best of the enterprise solution to the market and at the same time 
                        provide the required support services locally.<br />
                        <br />
&nbsp;&nbsp;&nbsp; Now the group is focusing basically in creating a complete ERP solution for 
                        schools/education institutes which shall completely revolutionize the operations 
                        with the much needed CHILD SECURITY as the prime focus. </span></div>
                </div>
                <div class="bottom-right">
                    <div class="cmdmessege">
                        CMD Messege</div>
                    <div class="clearfix">
                    </div>
                    <div class="rcontent">
                        <span>“The basic impetus behind creating this solution is not only to provide seamless
                            state of art platform for complete end to end management of educational institutes,
                            but to also utilize the latest technology for the much needed CHILD SECURITY which
                            is need of the hour for our society.” </span>
                    </div>
                    <div class="cmdmessege">
                        ED Messege</div>
                    <div class="clearfix">
                    </div>
                    <div class="rcontent">
                        <span>&quot;E- SMARTs is a revolutionary management concept with Security features embedded
                            with latest technological management. We have ensured all possible measures for
                            phase-wise launch of product that all concerned in Education Sector i.e. School/College
                            Administrators, Teachers, Parents, Children/students etc who benefit from this technology
                            can look forward for fullest satisfaction.&quot;</span></div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

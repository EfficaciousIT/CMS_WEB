<%@ Page Title="E-Smarts - Student attendance management system, Fees management, School bus tracking, Exam schedule, time table management" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmNewStudentProfile.aspx.cs" Inherits="frmNewStudentProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
        
        .profile-left
        {
            width: 184px;
            height: 342px;
            padding: 10px;
            float: left;
            background: #fff;
        }
        
        .right-details
        {
            width: 370px;
            height: auto;
            padding: 10px;
            float: left;
            text-align: left;
            font-size: 12px;
            background: #f5f5f5;
            border: 1px solid #d5d5d5;
        }
        
        .profile-pic
        {
            width: 162px;
            height: auto; /* float: left; */
            background: #f5f5f5;
            margin: 0 auto;
        }
        .profile-pic img
        {
            width: 100%;
        }
        
        img
        {
            padding-right: 05px;
        }
        
        .personal-details
        {
            width: 193px;
            padding: 10px 0;
            float: left;
            color: #FFF;
        }
        .name
        {
            width: 190px;
            hight: auto;
            font-family: verdana;
            font-size: 12px;
            float: left;
            padding: 5px 0;
            border-bottom: 1px solid #000;
        }
        
        .left-details
        {
            width: 145px;
            height: auto;
            padding: 10px 10px;
            float: left;
            font-size: 12px;
            text-align: left;
            background: #fff;
            border: 1px solid #d5d5d5;
        }
        
        .parent-pic img
        {
            width: 100%;
        }
        .parent-pic
        {
            width: 100px;
            height: 100px;
            float: left;
            background: #f5f5f5;
        }
        
        img
        {
            padding-right: 05px;
        }
        
        
        .pleft-details
        {
            width: 148px;
            height: auto;
            padding: 10px 10px;
            float: left;
            font-size: 12px;
            text-align: left;
            background: #fff;
            border: 1px solid #d5d5d5;
        }
        .pright-details
        {
            width: 367px;
            height: auto;
            padding: 10px 5px;
            float: left;
            text-align: left;
            font-size: 12px;
            background: #f5f5f5;
            border: 1px solid #d5d5d5;
        }
        
        .parent-left
        {
            width: 140px;
            height: auto;
            padding: 10px;
            float: left;
        }
        
        p
        {
            margin: 0;
            line-height: 16px;
            font-size: 11px;
        }
        
        .contact-right-details
        {
            width: 300px;
            height: auto;
            padding: 10px 20px;
            float: left;
            text-align: left;
            font-size: 12px;
            background: #f5f5f5;
            border: 1px solid #d5d5d5;
        }
        
        .personal-right-deatils
        {
            width: 400px;
            float: left;
            height: auto;
            padding: 10px;
        }
        .contact-left-details
        {
            width: 180px;
            height: auto;
            padding: 10px 12px;
            float: left;
            font-size: 12px;
            text-align: left;
            background: #fff;
            border: 1px solid #d5d5d5;
        }
        
        .heading
        {
            width: 500px;
            text-align: center;
            padding-left: 10px;
            font-family: verdana;
            font-size: 14px;
            font-weight: bold;
        }
        h1
        {
            width: 500px;
            text-align: center;
            padding-left: 10px;
            font-family: verdana;
            font-size: 14px;
            font-weight: bold;
        }
        .profile-right
        {
            width: 550px;
            height: auto;
            padding: 10px;
            float: left;
        }
        .clearfix
        {
            clear: both;
            margin: 0 auto;
        }
        ajax__tab_body
        {
            border: none;
        }
        .textcss
        {
            color:Black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td class="style22" align="center">
                <br />
                <asp:Label ID="Labnorecord" runat="server" CssClass="textcss" Font-Bold="False" ForeColor="#CC0000"
                    Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" CssClass="MyTabStyle"
                    Width="1015px">
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Style="border: 1px solid #000;">
                        <HeaderTemplate>
                            Personal Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <div class="profile-left">
                                    <div class="profile-pic">
                                        <asp:Image ID="fileImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                            runat="server" Style="line-height: normal; margin-right: 27px;" border="2" ToolTip="Image" />
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="personal-details">
                                        <div class="name">
                                            <p>
                                                <img align="left" src="img/user.png" width="20" height="20"><asp:Label Style="display: block; color:Black"
                                                    ID="lblvn" runat="server" Font-Bold="False" Width="100%"></asp:Label>
                                            </p>
                                        </div>
                                        <div class="name">
                                            <p>
                                                <img align="left" src="img/email.png" width="20" height="20"><asp:Label ID="Label26"
                                                    runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                            </p>
                                        </div>
                                        <div class="name" style="border-bottom: none;">
                                            <p>
                                                <img align="left" src="img/gender.png" width="20" height="20"><asp:Label ID="Label53"
                                                    runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                            </p>
                                        </div>
                                        <div class="name" style="display: none">
                                            <p>
                                                <img align="left" src="img/telephone.png" width="20" height="20">8796885193</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="profile-right">
                                    <div class="left-details">
                                        Standard / Division</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label75" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                        /
                                        <asp:Label ID="Label79" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Roll No</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label85" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <%--<div class="left-details">
                                        Class Teacher</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label89" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>--%>
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Date of Birth</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label27" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                  
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Cast</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label29" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Sub Cast</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label30" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>                                   
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Father Mobile No.</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label31" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Mother Mobile No.</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label33" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Present Address</div>
                                    <div class="right-details">
                                        <asp:Label ID="Label34" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                </div>
                                 <div class="clearfix">
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel6" Style="border: 1px solid #000;">
                        <HeaderTemplate>
                            Parents Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <div class="heading">
                                    Father Details</div>
                                <div class="clearfix">
                                </div>
                                <div class="parent-left">
                                    <div class="parent-pic">
                                        <asp:Image runat="server" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                            ToolTip="Image" ID="fileImg2" Style="line-height: normal;" border="2"></asp:Image>
                                    </div>
                                </div>
                                <div class="profile-right">
                                    <div class="pleft-details">
                                        Name</div>
                                    <div class="pright-details">
                                        <asp:Label ID="Label58" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="pleft-details">
                                        Mobile No.</div>
                                    <div class="pright-details">
                                        <asp:Label ID="Label60" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="pleft-details">
                                        Email ID</div>
                                    <div class="pright-details">
                                        <asp:Label ID="Label62" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="heading">
                                    Mother Details</div>
                                <div class="clearfix">
                                </div>
                                <div class="parent-left">
                                    <div class="parent-pic">
                                        <asp:Image runat="server" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                            ToolTip="Image" ID="fileImg3"></asp:Image>
                                    </div>
                                </div>
                                <div class="profile-right">
                                    <div class="pleft-details">
                                        Name</div>
                                    <div class="pright-details">
                                        <asp:Label ID="Label70" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="pleft-details">
                                        Mobile No.</div>
                                    <div class="pright-details">
                                        <asp:Label ID="Label72" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    
                                </div>
                                <div class="clearfix">
                                </div>
                                
                                
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Address Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <div class="profile-right" style="margin:0 auto; float:inherit;">
                                    <div class="left-details">
                                        Present Address
                                    </div>
                                    <div class="right-details">
                                        <asp:Label ID="Label35" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="left-details">
                                        Permanent Address
                                    </div>
                                    <div class="right-details">
                                        <asp:Label ID="Label36" runat="server" CssClass="textcss" Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                </div>
                                 <div class="clearfix">
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Contact Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <div class="profile-right" style="margin:0 auto; float:inherit;">                                    
                                    <div class="contact-left-details">
                                        School Contact Number</div>
                                    <div class="contact-right-details">
                                        022-25412142/43
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="contact-left-details">
                                        School Fax Number</div>
                                    <div class="contact-right-details">
                                        1234567890</div>
                                </div>
                                
                                 <div class="clearfix">
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>                    
                </asp:TabContainer>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
        </tr>
    </table>
</asp:Content>

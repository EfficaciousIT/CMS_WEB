<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmParentsDetails.aspx.cs" Inherits="frmParentsDetails" Title="Parents Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        body
        {
            font-family: verdana;
        }
        .parent-left
        {
            width: 100px;
            height: auto;
            padding: 10px;
            float: left;
            margin-left: 100px;
        }
        .profile-right
        {
            width: 550px;
            height: auto;
            padding: 10px;
            float: left;
        }
        .parent-pic
        {
            width: 100px;
            height: 100px;
            float: left;
            background: #f5f5f5;
        }
        .clearfix
        {
            clear: both;
            margin: 0 auto;
        }
        img
        {
            padding-right: 05px;
        }
        p
        {
            margin: 0;
            line-height: 16px;
            font-size: 11px;
        }
        .personal-details
        {
            width: 200px;
            padding: 10px 0;
            float: left;
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
        .personal-right-deatils
        {
            width: 400px;
            float: left;
            height: auto;
            padding: 10px;
        }
        .pleft-details
        {
            width: 150px;
            height: auto;
            padding: 5px 10px;
            float: left;
            font-size: 13px !important;
            text-align: left;
            background: #fff;
            border: 1px solid #d5d5d5;
        }
        .pright-details
        {
            width: 366px;
            height: auto;
            padding: 5px 5px;
            float: left;
            text-align: left;
            font-size: 13px;
            background: #f5f5f5;
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
        .textcss
        {
            font-size: 13px !important;
        }
        .textsize
        {
            font-size: 13px !important;
        }
    </style>
    <div style="padding: 05px,0,0,0">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
            CssClass="MyTabStyle">
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Father Details
                </HeaderTemplate>
                <ContentTemplate>
                    <center>
                        <div class="heading">
                            Father Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <p>
                                &nbsp;</p>
                            <div class="clearfix">
                            </div>
                            <div class="parent-pic">
                                <asp:Image ID="imgfath1" runat="server" AlternateText="Image" border="2" ImageUrl="images/Sample%20Photo1.jpg"
                                    Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                    ToolTip="Image" /></div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="lblvchno" runat="server" CssClass="textcss" Font-Bold="False">Father Name</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label23" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label><asp:Label
                                    ID="Label24" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label><asp:Label
                                        ID="Label25" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="lblpalceofbirth1" runat="server" CssClass="textcss" Font-Bold="False"
                                    Text="Father Mobile No"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label32" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="lblpalceofbirth4" runat="server" CssClass="textcss" Font-Bold="False"
                                    Text="Father DOB"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label35" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label20" runat="server" CssClass="textcss" Font-Bold="False" Text="Father Email Id"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label39" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label37" runat="server" CssClass="textcss" Font-Bold="False">Father Address</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label61" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label62" runat="server" CssClass="textcss" Font-Bold="False">Father Passport No</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label63" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="heading">
                            Office Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="Label2" runat="server" CssClass="textcss" Font-Bold="False">Father Company Name</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label45" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label5" runat="server" CssClass="textcss" Font-Bold="False">Father Designation</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label46" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label6" runat="server" CssClass="textcss" Font-Bold="False" Text="Father Company Address"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label47" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label7" runat="server" CssClass="textcss" Font-Bold="False" Text="Telephone No (Office)"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label48" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label8" runat="server" CssClass="textcss" Font-Bold="False" Text="Income Details"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label49" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="heading">
                            Others Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="Label64" runat="server" CssClass="textcss" Font-Bold="False" Text="Father Vehicle Name"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label65" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label66" runat="server" CssClass="textcss" Font-Bold="False" Text="Father Vehicle No"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label67" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label68" runat="server" CssClass="textcss" Font-Bold="False" Text="Father PAN No"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label69" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label70" runat="server" CssClass="textcss" Font-Bold="False" Text="Father Blood Group"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label71" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label90" runat="server" CssClass="textcss" Font-Bold="False" Text="Father Highest Qualification"></asp:Label></div>
                            <div class="pright-details" style="padding: 13px 5px;">
                                <asp:Label ID="Label91" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                        </div>
                         <div class="clearfix">
                        </div>
                    </center>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                    Mother Details
                </HeaderTemplate>
                <ContentTemplate>
                    <center>
                        <div class="heading">
                            Father Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <p>
                                &nbsp;</p>
                            <div class="clearfix">
                            </div>
                            <div class="parent-pic">
                                <asp:Image ID="imgMoth1" runat="server" AlternateText="Image" border="2" ImageUrl="images/Sample%20Photo1.jpg"
                                    Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                    ToolTip="Image" /></div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details" style="padding: 6px 10px;">
                                <asp:Label ID="lbldrivermobno" runat="server" Visible="false" CssClass="textcss"
                                    Font-Bold="False" Text="Mother First Name"></asp:Label>
                                <asp:Label ID="lblmother" runat="server" Visible="false" CssClass="textcss" Font-Bold="False"
                                    Text="Mother Middle Name"></asp:Label>
                                <asp:Label ID="Gender" runat="server" Visible="false" CssClass="textcss" Font-Bold="False"
                                    Text="Mother last Name"></asp:Label>Mother Name</div>
                            <div class="pright-details" style="padding: 6px 5px;">
                                <asp:Label ID="Label26" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label><asp:Label
                                    ID="Label27" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                                <asp:Label ID="Label28" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="lblpalceofbirth2" runat="server" CssClass="textcss" Font-Bold="False"
                                    Text="Mother Mobile No"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label33" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="lblpalceofbirth5" runat="server" CssClass="textcss" Font-Bold="False"
                                    Text="Mother DOB"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label36" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label21" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Email Id"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label40" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label1" runat="server" CssClass="textcss" Font-Bold="False">Mother Address</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label42" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label3" runat="server" CssClass="textcss" Font-Bold="False">Mother Passport No</asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label43" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="heading">
                            Office Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="Label9" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Company Name"></asp:Label></div>
                            <div class="pright-details" style="padding: 13px 5px;">
                                <asp:Label ID="Label50" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label10" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Designation"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label51" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details" style="padding: 13px 10px 14px 10px;">
                                <asp:Label ID="Label11" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Company Address"></asp:Label></div>
                            <div class="pright-details" style="padding: 22px 5px 21px 5px;">
                                <asp:Label ID="Label52" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label13" runat="server" CssClass="textcss" Font-Bold="False" Text="Telephone No (Office)"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label53" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label14" runat="server" CssClass="textcss" Font-Bold="False" Text="Income Details"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label54" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="heading">
                            Others Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="Label72" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Vehicle Name"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label73" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label74" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Vehicle No"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label75" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label76" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother PAN No"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label77" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label78" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Blood Group"></asp:Label></div>
                            <div class="pright-details">
                                <asp:Label ID="Label79" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details" style="">
                                <asp:Label ID="Label92" runat="server" CssClass="textcss" Font-Bold="False" Text="Mother Highest Qualification"></asp:Label></div>
                            <div class="pright-details" style="padding: 13px 5px;">
                                <asp:Label ID="Label93" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label></div>
                        </div>
                          <div class="clearfix">
                        </div>
                    </center>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Guardian Details
                </HeaderTemplate>
                <ContentTemplate>
                    <center>
                        <div class="heading">
                            Guardian Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                            <p>
                                &nbsp;</p>
                            <div class="clearfix">
                            </div>
                            <div class="parent-pic">
                                <asp:Image ID="imgGuar1" runat="server" AlternateText="Image" border="2" ImageUrl="images/Sample%20Photo1.jpg"
                                    Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                    ToolTip="Image" />
                            </div>
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="lblbob" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian First name"></asp:Label>
                                <asp:Label ID="lblpalceofbirth" Visible="false" runat="server" CssClass="textcss"
                                    Font-Bold="False" Text="Guardian Middle Name"></asp:Label>
                                <asp:Label ID="lblpalceofbirth0" Visible="false" runat="server" CssClass="textcss"
                                    Font-Bold="False" Text="Guardian last Name"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label29" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                                <asp:Label ID="Label30" runat="server" Visible="false" CssClass="textsize" Font-Bold="False"
                                    Text="Label"></asp:Label>
                                <asp:Label ID="Label31" runat="server" Visible="false" CssClass="textsize" Font-Bold="False"
                                    Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label4" runat="server" CssClass="textcss" Font-Bold="False" Text="Gaurdian Mobile No"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label38" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label34" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian DOB"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label60" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label12" runat="server" CssClass="textcss" Font-Bold="False">Guardian Address</asp:Label>
                            </div>
                            <div class="pright-details" style="padding: 13px 5px;">
                                <asp:Label ID="Label44" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label22" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian Email Id"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label41" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="heading">
                            Office Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="Label15" runat="server" CssClass="textcss" Font-Bold="False">Guardian Company Name</asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label55" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label16" runat="server" CssClass="textcss" Font-Bold="False">Guardian Designation</asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label56" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label17" runat="server" CssClass="textcss" Font-Bold="False" Text="Company Address"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label57" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label88" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian Passport No"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label89" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label18" runat="server" CssClass="textcss" Font-Bold="False" Text="Telephone No (Office)"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label58" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label19" runat="server" CssClass="textcss" Font-Bold="False" Text="Income Details"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label59" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="heading">
                            Others Details</div>
                        <div class="clearfix">
                        </div>
                        <div class="parent-left">
                        </div>
                        <div class="profile-right">
                            <div class="pleft-details">
                                <asp:Label ID="Label80" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian Vehicle Name"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label81" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label82" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian Vehicle No"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label83" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label84" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian PAN No"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label85" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label86" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian Blood Group"></asp:Label>
                            </div>
                            <div class="pright-details">
                                <asp:Label ID="Label87" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="pleft-details">
                                <asp:Label ID="Label94" runat="server" CssClass="textcss" Font-Bold="False" Text="Guardian Highest Qualification"></asp:Label>
                            </div>
                            <div class="pright-details" style="padding:13px 5px;">
                                <asp:Label ID="Label95" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        </tr> </table>

                          <div class="clearfix">
                        </div>
                    </center>
                    </fieldset>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style4
        {
            height: 17px;
        }
        .style5
        {
            width: 98px;
            height: 17px;
        }
        .style6
        {
            width: 91px;
        }
    </style>
</asp:Content>

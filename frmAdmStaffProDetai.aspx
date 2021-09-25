<%@ Page Title="Staff Profile Details" Language="C#"  AutoEventWireup="true" CodeFile="frmAdmStaffProDetai.aspx.cs" Inherits="frmAdmStaffProDetai" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css"/>
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>

    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="sty/styles.css" rel="stylesheet" type="text/css" />

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <script src="sty/script.js"></script>

  <style type="text/css">
        .style1
        {
            height: 24px;
        }
        .style2
        {
            height: 22px;
        }
        .style3
        {
            height: 39px;
        }
        .style7
        {
            width: 96px;
        }
        .style8
        {
            width: 230px;
        }
        .auto-style1 {
            width: 241px;
        }
        .auto-style2 {
            width: 455px;
        }
        .auto-style3 {
            width: 494px;
        }
                 .MyTabStyle .ajax__tab_header
        {
            font-family: "Helvetica Neue" , Arial, Sans-Serif;
            font-size: 14px;
            font-weight: bold;
            display: block;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            height: 25px;
            border: solid 1px #d7d7d7;
            background: #fdfdfd;
            padding-top: 5px;
            font-size: 12px;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_inner
        {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            height: 25px;
            border: solid 1px #d7d7d7;
            background: #fdfdfd;
            padding-top: 5px;
            cursor: pointer;
            font-size: 12px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_inner
        {
            color: #222;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_outer
        {
            border-bottom-color: #ffffff;
            background-color: #FFF;
            height: 29px;
            border-radius: 5px 5px 0 0;
            border: 1px solid green;
            border-bottom: none;
            padding-top: 5px;
            font-size: 14px;
            font-family: Verdana;
            cursor: pointer;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: green;
            border-color: #333;
        }
        .MyTabStyle .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #d7d7d7;
        }
         .efficacious label
        {
            display: block;
            height: auto;
            padding: 10px 0px;
            font-size: 18px;
            border: 1px solid #242424;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 120px;
            color: #000;
        }


        #efficacious
        {
            background: #e5e5e5;
            border-radius: 7px;
            height: 30px;
            padding: 2px;
            width: 90%;
            margin-bottom: 5px;
        }
        .efficacious span
        {
            display: block;
            height: auto;
            padding: 10px 0px;
            font-size: 12px;
            margin: 2% 5%;
            padding: 2%;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 120px;
            color: #000;
        }
        .efficacious input, form.winner-inside textarea
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            font-family: 'verdana';
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .efficacious input.winner-inside
        {
            width: 100%;
            background: #ffff;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin-top: 10px;
        }
        .efficacious select
        {
            width: 100%;
            border: 1px solid #3498db;
            padding: 2px 5px;
            height: 26px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            font-size: 13px;
            margin-bottom: 10px;
        }
        .efficacious textarea
        {
            width: 100%;
            border: 1px solid #3498db;
            padding: 5px 5px;
            height: 32px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            font-size: 13px;
            margin-bottom: 10px;
        }
        .efficacious input.efficacious_send {
          
            background: #3498db;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            height: 35px;
            float: left; text-align:center;
}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <center>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>


    <table>
        <tr id="id1h" runat="server" >
            <td>
               <center>
               <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                
                Personal Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr>
                        <td align="center" colspan="2" class="style2">
                        
                            <asp:Label ID="Label7" runat="server" Text="Personal Details" 
                                CssClass="textheadcss" Font-Bold="False"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblvchno" runat="server"  Font-Bold="False"  >First Name</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"  ></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label24" runat="server"   Font-Bold="False" 
                                Text="Sharad"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblvchmake" runat="server" Font-Bold="False"  >Middle Name</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"  ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label25" runat="server"   Font-Bold="False" 
                                Text="Suhas"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" 
                                Font-Bold="False"  ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                  Height="18px" Width="108px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label26" runat="server"   Font-Bold="False" 
                                Text="Mali"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label12" runat="server" Text="Department id" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox8" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"   ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label27" runat="server"   Font-Bold="False" 
                                Text="Gardening"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label13" runat="server" Text="Gender" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox9" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"   ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label28" runat="server"   Font-Bold="False" 
                                Text="Male"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label14" runat="server" Text="Date of Birth" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox10" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label29" runat="server"   Font-Bold="False" 
                                Text="18-06-1987"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbldrivermobno" runat="server" Text="Email" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label30" runat="server"   Font-Bold="False" 
                                Text="Sharad@gmail.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label15" runat="server" Text="Highest Qualifiacation" 
                                Font-Bold="False"  ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox11" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label31" runat="server"   Font-Bold="False" 
                                Text="12 th"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label16" runat="server" Text="Home Telphone number 1" 
                                Font-Bold="False"  ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label32" runat="server"   Font-Bold="False" 
                                Text="022-66784578"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label17" runat="server" Text="Home Telphone number 2" 
                                Font-Bold="False"  ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox13" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"   ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label33" runat="server"   Font-Bold="False" 
                                Text="--"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label18" runat="server" Text="Mobile number" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label34" runat="server"   Font-Bold="False" 
                                Text="9989758945"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style1">
                            <asp:Label ID="Label19" runat="server" Text="facebook url" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="TextBox15" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                ontextchanged="TextBox15_TextChanged"  ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label35" runat="server"   Font-Bold="False" 
                                Text="Sharad@facebook.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label20" runat="server" Text="Twitter Url" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label36" runat="server"   Font-Bold="False" 
                                Text="Sharad@twitter.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style1">
                            <asp:Label ID="Label21" runat="server" Text="Other Url" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="TextBox17" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label37" runat="server"   Font-Bold="False" 
                                Text="--"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="btnsubmit" runat="server" ForeColor="#999999" Height="28px"
                                ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="btnclr" runat="server" Height="28px" ImageUrl="~/images/cancel.png"
                                Width="64px" />
                        </td>
                    </tr>
                </table>
                     </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                
                Address Details
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr>
                        <td align="center" colspan="2">
                        
                            <asp:Label ID="Label8" runat="server" Text="Address Details" 
                                CssClass="textheadcss" Font-Bold="False"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Font-Bold="False"  >Present Address</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px" 
                                Height="55px" CssClass="textboxcs"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label38" runat="server"   Font-Bold="False" 
                                Text="lila chawl,vasai"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="2"></td></tr>
                    <tr><td colspan="2">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Same As Above" 
                              Font-Bold="False" Checked="True" oncheckedchanged="CheckBox1_CheckedChanged" />
                        
                        </td></tr>
                        <tr><td colspan="2"></td></tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="Permanet Address" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px" 
                                Height="48px" CssClass="textboxcs"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="Label39" runat="server"   Font-Bold="False" 
                                Text="Same As Above"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="ImageButton1" runat="server" ForeColor="#999999" Height="28px"
                                ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" ImageUrl="~/images/cancel.png"
                                Width="64px" />
                        </td>
                    </tr>
                </table>
                    </div>

            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
            
                Others Deatils</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr>
                        <td align="center" colspan="2">
                        
                            <asp:Label ID="Label1" runat="server" Text="Other Deatils" Font-Bold="False" 
                                CssClass="textheadcss"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                  
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Highest Qualifiacation" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="75px" 
                                CssClass="dropdowncs">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;<asp:Label ID="Label40" runat="server"   Font-Bold="False" 
                                Text="12 th"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Year of Passing" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="75px" 
                                CssClass="dropdowncs">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;<asp:Label ID="Label41" runat="server"   Font-Bold="False" 
                                Text="2009"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Work Experience" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList4" runat="server" Width="75px" 
                                CssClass="dropdowncs">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;<asp:Label ID="Label42" runat="server"   Font-Bold="False" 
                                Text=" 2 Years"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="Availability" Font-Bold="False" 
                                 ></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList5" runat="server" Width="75px" 
                                CssClass="dropdowncs">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;<asp:Label ID="Label43" runat="server"   Font-Bold="False" 
                                Text="12 hrs"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="ImageButton3" runat="server" ForeColor="#999999" 
                                 CssClass="efficacious_send" ValidationGroup="b"/>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton4" runat="server" Height="28px" ImageUrl="~/images/cancel.png"
                                Width="64px" />
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </center>
            </td>
        </tr>
    </table>
        </div>
        </center>
    </form>
</body>
</html>

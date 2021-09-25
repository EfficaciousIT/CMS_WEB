<%@ Page Language="C#"  AutoEventWireup="true"
    CodeFile="frmAdmStuProDetai1.aspx.cs" Inherits="frmAdmStuProDetai1" Culture="es-MX"   Title="Student Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="styles/styles.css" rel="stylesheet" type="text/css" />
     <link href="sty/styles.css" rel="stylesheet" type="text/css" />
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
            font-family: 'allerregular';
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
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
    <div style="padding:05px,0,0,0">
     <table width="100%">
     <tr><td  align="left">

         <asp:Label ID="Labnorecord" runat="server" 
               Font-Bold="False" ForeColor="#CC0000" Font-Size="Small"></asp:Label></td></tr>
     <tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
        Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Personal Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
               <center>
                    <fieldset style="width: 500px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold">
                            Student Personal Details</legend>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                            <td rowspan="6" class="auto-style4" >
                                <asp:Image id="fileImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                               </td>
                                <td align="left" width="230">
                                    <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">First name</asp:Label>
                                </td>
                                <td align="left" >
                                    
                                    <asp:Label ID="lblvn" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Middle name</asp:Label>
                                </td>
                                <td align="left" class="style21">
                                    
                                    <asp:Label ID="Label17" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblvchdrivername" runat="server" Text="Last name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">

                                   <asp:Label ID="Label23" runat="server"   
                                            Font-Bold="False" ></asp:Label>
                              </td>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lbldrivermobno" runat="server"   
                                            Font-Bold="False" Text="Father name"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label24" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblmother" runat="server"   Font-Bold="False" 
                                            Text="Mother name"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label25" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Gender" runat="server"   Font-Bold="False" 
                                            Text="Email ID"></asp:Label>
                                    </td>
                                    <td align="left" nowrap="nowrap">
                                        
                                        <asp:Label ID="Label26" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" >
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblbob" runat="server"   Font-Bold="False" 
                                            Text="Date of birth"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label27" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4" >
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth" runat="server"   
                                            Font-Bold="False" Text="Place of birth"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label28" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style4">
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth0" runat="server"   
                                            Font-Bold="False" Text="Cast"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label29" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style4">
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth1" runat="server"   
                                            Font-Bold="False" Text="Sub cast"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <asp:Label ID="Label30" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">
                                    </td>
                                    <td align="left" >
                                        <asp:Label ID="Label52" runat="server" Font-Bold="False" Text="Gender"  ></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label53" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style4" >
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth5" runat="server"   
                                            Font-Bold="False" Text="Home Telphone 1"></asp:Label>
                                        </td>
                                    <td align="left" class="style4">
                                        
                                        <asp:Label ID="Label31" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style4" >
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth2" runat="server"   Font-Bold="False" 
                                            Text="Father mobile no"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        
                                        <asp:Label ID="Label32" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style4">
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth3" runat="server"   Font-Bold="False" 
                                            Text="Mother mobile no"></asp:Label>
                                    </td>
                                    <td align="left" class="style4">
                                        
                                        <asp:Label ID="Label33" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="bottom">
                                    <td class="auto-style4" >
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblpalceofbirth4" runat="server"   
                                            Font-Bold="False" Text="Present Address"></asp:Label>
                                    </td>
                                    <td align="left" class="style4" nowrap="nowrap">
                                        
                                        <asp:Label ID="Label34" runat="server"   Font-Bold="False"></asp:Label>
                                    <br />
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
             </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel6">
            <HeaderTemplate>
                Parents Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <fieldset style="width: 500px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Parents Details</legend>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="Label54" runat="server" CssClass="textheadcss" 
                                        Font-Bold="False">Father Details</asp:Label></td>
                            </tr>
                            <tr><td colspan="3"></td></tr>

                              <tr>
                                  <td rowspan="6" >
                                      
                                      <img src="images/Student_Father.jpg" 
                                          style="line-height: normal; height: 100px; width: 80px;" border="2"" /></td>
                                  <td align="left">
                                      <asp:Label ID="Label57" runat="server"   Font-Bold="False">Name</asp:Label>
                                  </td>
                                  <td>
                                      <asp:Label ID="Label58" runat="server"   Font-Bold="False"></asp:Label>
                                  </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label59" runat="server"   Font-Bold="False">Mobile No</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label60" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label61" runat="server"   Font-Bold="False">Email id</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label62" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style18" align="left">
                                    <asp:Label ID="Label63" runat="server"   Font-Bold="False">Father Company Name</asp:Label>
                                </td>
                                <td class="style18">
                                    <asp:Label ID="Label64" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label65" runat="server"   Font-Bold="False">Father Designation</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label66" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label67" runat="server"   Font-Bold="False">Telphone No (Office)</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label68" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                                </tr|>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="Label55" runat="server" CssClass="textheadcss" Font-Bold="False">Mother Details</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                                </tr|>
                            </tr>
                            <tr>
                                <td rowspan="6">
                                    &nbsp;&nbsp;
                                    <img src="images/Student_Mother.jpg" 
                                        style="line-height: normal; height: 100px; width: 80px;" border="2"" /></td>
                                <td align="left">
                                    <asp:Label ID="Label69" runat="server"   Font-Bold="False">Name</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label70" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label93" runat="server"   Font-Bold="False">Mobile No</asp:Label>
                                </td>
                                <td class="style18">
                                    <asp:Label ID="Label72" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label73" runat="server"   Font-Bold="False">Email id</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label74" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label97" runat="server"   Font-Bold="False">Mother Company Name</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label76" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label98" runat="server"   Font-Bold="False">Mother Designation</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label78" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label99" runat="server"   Font-Bold="False">Telphone No (Office)</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label80" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                                </tr|>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="Label71" runat="server" CssClass="textheadcss" Font-Bold="False">Guardian Details</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                                </tr|>
                            </tr>
                            
                                    <tr>
                                        <td rowspan="6">
                                            &nbsp;&nbsp;
                                            <img src="images/Student_Guardian.jpg" 
                                                style="line-height: normal;height: 100px; width: 80px;" border="2"" /></td>
                                        <td align="left">
                                            <asp:Label ID="Label81" runat="server"   Font-Bold="False">Name</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label82" runat="server"   Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label94" runat="server"   Font-Bold="False">Mobile No</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label84" runat="server"   Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label96" runat="server"   Font-Bold="False">Email id</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label86" runat="server"   Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label100" runat="server"   Font-Bold="False">Guardian Company Name</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label88" runat="server"   Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label101" runat="server"   Font-Bold="False">Guardian Designation</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label90" runat="server"   Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label102" runat="server"   Font-Bold="False">Telphone No (Office)</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label92" runat="server"   Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Address Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                                    <center>
                    <fieldset style="width: 500px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Student Address Details</legend>
                        <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" width="230" class="style5">
                                    <asp:Label ID="Label1" runat="server"   Font-Bold="False">Present Address</asp:Label>
                                </td>
                                <td align="left" width="230" class="style5" nowrap="nowrap">
                                    &nbsp;&nbsp;
                                        <asp:Label ID="Label35" runat="server" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server"   Font-Bold="False">Permanent Address</asp:Label>
                                </td>
                                <td align="left" nowrap="nowrap">
                                    &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label36" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;&nbsp;
                                </td>
                                <td>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </center>
                    </div>

            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Contact Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <fieldset style="width: 556px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Contact Details</legend>
                        <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Label2" runat="server"   Font-Bold="False">Home Telphone 1</asp:Label>
                                </td>
                                <td align="left" width="230">
                                        <asp:Label ID="Label4" runat="server" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server"   Font-Bold="False">Home Telphone 2</asp:Label>
                                </td>
                                <td align="left">
                                     <asp:Label ID="Label37" runat="server"   
                                        Font-Bold="False"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Emergency contact persone 1" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label38" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label7" runat="server"   Font-Bold="False" 
                                            Text="Emergency contact number 1"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label39" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label8" runat="server"   Font-Bold="False" 
                                            Text="Emergency contact persone 2"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label40" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label9" runat="server"   Font-Bold="False" 
                                            Text="Emergency contact number 2"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label41" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label10" runat="server"   Font-Bold="False" 
                                            Text="Neighbour Name"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label42" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label11" runat="server"   Font-Bold="False" 
                                            Text="Neighbour number"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:Label ID="Label43" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Health status</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <fieldset style="width: 556px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold">
                            Health Details</legend>
                        <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Label12" runat="server"   Font-Bold="False">Blood group</asp:Label>
                                </td>
                                <td align="left" width="230">
                                        <asp:Label ID="Label13" runat="server"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label14" runat="server"   Font-Bold="False">Any health disability</asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label44" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label15" runat="server" Text="Description"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="Label45" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Other</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <fieldset style="width: 556px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold ">
                            Others Details</legend>
                        <table style="font-weight: bolder; width: 423px; margin: 10px 0;" align="center">
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Label16" runat="server"   Font-Bold="False">Cast</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label46" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label18" runat="server"   Font-Bold="False">Sub Cast</asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label47" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label19" runat="server" Text="Passport no"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label48" runat="server"   Font-Bold="False"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label20" runat="server"   Font-Bold="False" 
                                            Text="Date of issue"></asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label49" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label21" runat="server"   Font-Bold="False" 
                                            Text="Date of expire"></asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label50" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style20">
                                        <asp:Label ID="Label22" runat="server"   Font-Bold="False" 
                                            Text="Mother tounge"></asp:Label>
                                    </td>
                                    <td align="left" class="style20">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label51" runat="server"   Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                            </tr>
                          
                        </table>
                    </fieldset>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </td></tr></table>
      </div>
    </form>
</body>
</html>
<%--</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style3
        {
            width: 200px;
        }
        .style4
        {
            width: 200px;
            margin-right: 0px;
            font-family: Verdana, Arial, Sans-Serif;
            font-size: 10px;
        }
        .style5
        {
            height: 76px;
        }
        .style6
        {
            font-family: Verdana, MS Reference Sans Serif, Arial;
            font-size: 10px;
            text-align: left;
            height: 22px;
        }
        .style7
        {
            width: 200px;
            margin-right: 0px;
            font-family: Verdana, Arial, Sans-Serif;
            font-size: 10px;
            height: 22px;
        }
        .style8
        {
            width: 122px;
        }
        .style18
        {
            height: 19px;
        }
        .style20
        {
            height: 22px;
        }
        .style21
        {
            width: 200px;
            height: 22px;
        }
        .style22
        {
            height: 14px;
        }
        </style>
</asp:Content>
--%>
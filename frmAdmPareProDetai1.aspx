<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="frmAdmPareProDetai1.aspx.cs" Inherits="frmAdmPareProDetai1" Title="Parents Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">--%>
<%--<br />--%>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="styles/styles.css" rel="stylesheet" type="text/css" />
     <link href="sty/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
                 .MyTabStyle .ajax__tab_header
        {
            font-family: Verdana;
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
            font-family: Verdana;
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
            width: auto;
            color: #000;word-wrap: break-word;
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
        .style1
        {
            width: 261px;
        }
        .style2
        {
            width: 262px;
        }
        .style4
        {
            width: 943px;
        }
        .style5
        {
            width: 1293px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
    <div style="padding:05px 0 0 0">
 <br />
 <asp:Label ID="Label96" runat="server" style="padding-top:10px" Text="No Record Found" 
                                          Font-Bold="true" ForeColor="Red"></asp:Label>
                                  
                                        </div>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2"
        Width="900" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Father Details
            
</HeaderTemplate>
            

<ContentTemplate>
    <div class="efficacious">
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Father Details</legend>
                        <table style="font-weight: bolder; width: 480px; margin: 10px 0;" align="center">
                            <tr>
                            <td rowspan="3"  valign="top">
                            <br />
                                 <asp:Image ID="imgfath1" runat="server" AlternateText="Image" border="2" 
                                                ImageUrl="images/Sample%20Photo1.jpg" 
                                                Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;" 
                                                ToolTip="Image" />
                                <td align="left" width="230">
                                
                                        <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Personal 
                                                Details</legend>
                                            <table align="center">
                                                <tr>
                                                    <td nowrap="nowrap" width="250">
                                                        <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">Father First Name</asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        <asp:Label ID="Label23" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Father Middle Name</asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label24" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="lblvchdrivername" runat="server"   
                                                            Font-Bold="False" Text="Father Last Name"></asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label25" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="bottom">
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="lblpalceofbirth1" runat="server"   
                                                            Font-Bold="False" Text="Father Mobile No"></asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label32" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="bottom">
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="lblpalceofbirth4" runat="server"   
                                                            Font-Bold="False" Text="Father DOB"></asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label35" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label20" runat="server"   Font-Bold="False" 
                                                            Text="Father Email Id"></asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label39" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                  
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label37" runat="server"   Font-Bold="False">Father Address</asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label61" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label62" runat="server"   Font-Bold="False">Father Passport No</asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label63" runat="server"   Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                   
                            </td>
                            </tr>
                          
                             <tr>
                            <td>
                            <table>
                            <tr>
                            <td>
                          <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Office 
                                                Details</legend>
                                            <table align="center">
                                                
                            <tr>
                                <td align="left" nowrap="true" width="250" >
                                    <asp:Label ID="Label2" runat="server"   Font-Bold="False">Father Company Name</asp:Label>
                                </td>
                                <td align="left" nowrap="true" width="230" >
                                        <asp:Label 
                                        ID="Label45" runat="server"   Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                           
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server"   Font-Bold="False">Father Designation</asp:Label>
                                </td>
                                <td align="left">
                                         <asp:Label ID="Label46" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                           
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label6" runat="server" Text="Father Company Address"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label47" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                           
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="Telephone No (Office)" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label48" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                         
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label8" runat="server" Text="Income Details"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label49" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </fieldset>
                            </td>
                            </tr>
                            <tr>
                            <td>
                             <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Others 
                                                </legend>
                                            <table align="center">
                                                <tr>
                            
                            
                                <td align="left" nowrap="true" width="250">
                                    <asp:Label ID="Label64" runat="server" Text="Father Vehicle Name"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230" >
                                    <asp:Label ID="Label65" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                     
                                <td align="left" nowrap="true" >
                                    <asp:Label ID="Label66" runat="server" Text="Father Vehicle No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true" >
                                    <asp:Label ID="Label67" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label68" runat="server" Text="Father PAN No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label69" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                        
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label70" runat="server" Text="Father Blood Group"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label71" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                        
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label90" runat="server" Text="Father Highest Qualification"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label91" runat="server" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </fieldset>
                    </td>
                    </tr>
               
            
                </table>
                </td>
                </tr>
                </table>
                </fieldset>
                </center>
            </div>
</ContentTemplate>
        

</asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Mother Details
            
</HeaderTemplate>
            

<ContentTemplate>
    <div class="efficacious">
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold;">
                            Mother Details</legend>
                      <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                         
                            <td rowspan="3" valign="top">
                               <br />
                                 <asp:Image ID="imgMoth1" runat="server" AlternateText="Image" border="2" 
                                                    ImageUrl="images/Sample%20Photo1.jpg" 
                                                    Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;" 
                                                    ToolTip="Image" />
                                                    </td>
                                <td align="left">
                                <table>
                                <tr>
                                <td>
                                 <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Personal 
                                                Details</legend>
                                            <table align="center">
                                                <tr><td nowrap="nowrap" width="250">
                                    <asp:Label ID="lbldrivermobno" runat="server" Text="Mother First Name" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                                    
                                <td align="left" width="230">


                                    <asp:Label ID="Label26" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lblmother" runat="server" Text="Mother Middle Name" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="nowrap">


                                    <asp:Label ID="Label27" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="Gender" runat="server" Text="Mother Last Name" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="nowrap">


                                    <asp:Label ID="Label28" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lblpalceofbirth2" runat="server" Text="Mother Mobile No" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="nowrap">


                                    <asp:Label ID="Label33" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                                <tr valign="bottom">
                                <td align="left" nowrap="nowrap">
                                    <asp:Label ID="lblpalceofbirth5" runat="server" Text="Mother DOB" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="nowrap">


                                    <asp:Label ID="Label36" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label21" runat="server" Text="Mother Email Id" 
                                          Font-Bold="False"></asp:Label>

</td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label40" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label1" runat="server"   Font-Bold="False">Mother Address</asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label42" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                       
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label3" runat="server"   Font-Bold="False">Mother Passport No</asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label43" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            </table>
                            </fieldset>
                            </td>
                            </tr>
                            <tr>
                            <td>
                             <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Office 
                                                Details</legend>
                                            <table align="center">
                                               
                            <tr>
                           
                                <td align="left" nowrap="true" WIDTH="250" >
                                    <asp:Label ID="Label9" runat="server" Text="Mother Company Name" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true" width="230">


                                    <asp:Label ID="Label50" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label10" runat="server" Text="Mother Designation" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label51" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true" >
                                    <asp:Label ID="Label11" runat="server" Text="Mother Company Address" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true" >


                                    <asp:Label ID="Label52" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>

                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label13" runat="server" Text="Telphone No (Office)" 
                                          Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label53" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label14" runat="server" Text="Income Details"   
                                        Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label54" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>


                                </td>
                            </tr>
                            </table>
                            </fieldset>
                            </td>
                            </tr>
                            <tr>
                            <td>
                             <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Others
                                                </legend>
                                            <table align="center">
                                          
                             <tr>
                           
                                <td align="left" nowrap="true" width="250">
                                    <asp:Label ID="Label72" runat="server" Text="Mother Vehicle Name"   
                                        Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true" width="230">


                                    <asp:Label ID="Label73" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
               
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label74" runat="server" Text="Mother Vehicle No"   
                                        Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label75" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                 
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label76" runat="server" Text="Mother PAN No"   
                                        Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label77" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                          
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label78" runat="server" Text="Mother Blood Group"   
                                        Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left" nowrap="true">


                                    <asp:Label ID="Label79" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                              <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label92" runat="server" Text="Mother Highest Qualification"   
                                        Font-Bold="False"></asp:Label>


                                </td>
                                <td align="left">


                                    <asp:Label ID="Label93" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>


                                </td>
                            </tr>
                            <tr><td colspan="2"></td></tr>
                           
                        </table>
                    </fieldset>
                    </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    </table>
                    </fieldset>
                </center>
           </div>
            
</ContentTemplate>
        
        
</asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Guardian Details
            
</HeaderTemplate>
            

<ContentTemplate>
    <div class="efficacious">
        <center>
              <table><tr><td  align="left">
                    <fieldset style="width: 705px;">
                        <legend style="color: #000000; font: 13px verdana; text-align:center; font-weight: bold">
                            Guardian Details</legend>
                        <table style="font-weight: bolder; width: 480px; margin: 10px 0;" align="center">
                             <tr>
                             <td rowspan="3" valign="top" >
                             <br />
                            <asp:Image ID="imgGuar1" runat="server" AlternateText="Image" border="2" 
                                        ImageUrl="images/Sample%20Photo1.jpg" 
                                        Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;" 
                                        ToolTip="Image" />
                                </td>
                                 <td align="left">
                                     <fieldset style="width: 580px;">
                                         <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Personal 
                                             Details</legend>
                                         <table align="center">
                                             <tr>
                                                 <td nowrap="true" width="250">
                                                     <asp:Label ID="lblbob" runat="server"   Font-Bold="False" 
                                                         Text="Guardian First Name"></asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true" width="230">
                                                     <asp:Label ID="Label29" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr runat="server" visible="false" >
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="lblpalceofbirth" runat="server"   
                                                         Font-Bold="False" Text="Guardian Middle Name"></asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label30" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr valign="bottom" runat="server" visible="false">
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="lblpalceofbirth0" runat="server"   
                                                         Font-Bold="False" Text="Guardian Last Name"></asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label31" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr valign="bottom" >
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label4" runat="server"   Font-Bold="False" 
                                                         Text="Guardian Mobile No"></asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label38" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr valign="bottom">
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label34" runat="server"   Font-Bold="False" 
                                                         Text="Guardian DOB"></asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label60" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label12" runat="server"   Font-Bold="False">Guardian Address</asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label44" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label22" runat="server"   Font-Bold="False" 
                                                         Text="Guardian Email Id"></asp:Label>
                                                 </td>
                                                 <td align="left" nowrap="true">
                                                     <asp:Label ID="Label41" runat="server"   Font-Bold="False" 
                                                         Text="Label"></asp:Label>
                                                 </td>
                                             </tr>
                                         </table>
                                     </fieldset>
                                 </td>
                                 
                            </tr>
                            <tr>
                            <td>

                            <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Personal 
                                                Details</legend>
                                            <table align="center">
                           
                            
                            <tr>
                            
                                <td align="left" nowrap="true" width="250">
                                    <asp:Label ID="Label15" runat="server"   Font-Bold="False">Guardian Company Name</asp:Label>
                                </td>
                                <td align="left" nowrap="true" width="230">
                                    <asp:Label ID="Label55" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label16" runat="server"   Font-Bold="False">Guardian Designation</asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label56" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label17" runat="server" Text="Company Address" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label57" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label88" runat="server" Text="Guardian Passport No" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:Label ID="Label89" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label18" runat="server" Text="Telephone No (Office)" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label58" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label19" runat="server" Text="Income Details"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                        <asp:Label ID="Label59" runat="server"   
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </fieldset>
                            </td>
                            </tr>
                            <tr>
                            
                                <td align="left">
                                <fieldset style="width: 580px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold;">Personal 
                                                Details</legend>
                                            <table align="center">
                                            <tr>
                                            <td nowrap="true" width="250">
                                    <asp:Label ID="Label80" runat="server" Text="Guardian Vehicle Name"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true" width="230">
                                    <asp:Label ID="Label81" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label82" runat="server" Text="Guardian Vehicle No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label83" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label84" runat="server" Text="Guardian PAN No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label85" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label86" runat="server" Text="Guardian Blood Group"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true" >
                                    <asp:Label ID="Label87" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                            
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label94" runat="server" Text="Guardian Highest Qualification"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" nowrap="true">
                                    <asp:Label ID="Label95" runat="server"   Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td colspan="2"></td>
                            </tr>
                        </table>
                    </fieldset>
                    </td>
                    </tr>
                    </table>
                    </fieldset>
             </td></tr></table> 
            </center>
        </div>        
</ContentTemplate>
        

</asp:TabPanel>
    </asp:TabContainer>
   
    </form>
</body>
</html>
<%--</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
    </style>
</asp:Content>--%>


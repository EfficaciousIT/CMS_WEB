<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" CodeFile="frmParentsProfile.aspx.cs" Inherits="frmParentsProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="928px">

        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Father Details
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Father Details</legend>
                        <div class="efficacious">
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                                <td rowspan="3" class="style8" valign="top">
                                
                                  <asp:Image id="imgfath1" runat="server" AlternateText="Image" ImageUrl=""
                                                    Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />           

                                                    

                                </td>
                                <td>
                                <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Personal Details</legend>
                            <table>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">Father first name</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Text="Label" CssClass="textsize"
                                        Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Father middle name</asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label24" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblvchdrivername" runat="server" Text="Father last name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label25" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth1" runat="server" Text="Father mobile no"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label32" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth4" runat="server" Text="Father DOB"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label35" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label20" runat="server" Text="Father Email id"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label39" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                                <td align="left" width="230">
                                    <asp:Label ID="Label37" runat="server"   Font-Bold="False">Father Address</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label61" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                               
                                <td align="left">
                                    <asp:Label ID="Label62" runat="server"   Font-Bold="False">Father Passport no</asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label63" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            </table>
                                    
                            </fieldset>
                            </td>
                            <td></td>
                                </tr>
                            
                            <tr>
                                <td>
                                <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Office Details</legend>
                            <table>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Label2" runat="server"   Font-Bold="False">Father company name</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label45"
                                            runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server"   Font-Bold="False">Father Designation</asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label46" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              
                                <td align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Father Company address"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label47" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                               
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="Telphone No (Office)"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label48" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              
                                <td align="left">
                                    <asp:Label ID="Label8" runat="server" Text="Income Details"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label49" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                       
                            </tr>
                            </table>
                           
                            </fieldset>
                            </td>
                           <td></td>
                            </tr>
                            <tr>
                            <td>
                            <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Others</legend>
                            <table>
                            <tr>
                              
                                <td align="left" width="230">
                                    <asp:Label ID="Label64" runat="server" Text="Father vehicle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label65" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              
                                <td align="left" width="230">
                                    <asp:Label ID="Label66" runat="server" Text="Father Vehicle No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label67" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                                <td align="left" width="230">
                                    <asp:Label ID="Label68" runat="server" Text="Father PAN No"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label69" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              
                                <td align="left">
                                    <asp:Label ID="Label70" runat="server" Text="Father Blood Group"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label71" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              
                                <td align="left">
                                    <asp:Label ID="Label90" runat="server" Text="Father Highest Qualification"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label91" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                
                            </tr>
                        </table>
                    </fieldset>
                    <td></td>
                    </tr>
             
                </table>
                             </div>
                            </center>
               
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Mother Details
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Mother Details</legend>
                        <div class="efficacious">
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                                <td rowspan="3" valign="top" >
                                       <asp:Image id="imgMoth1" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                </td>
                                <td >
                                <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Personal Details</legend>
                            <table>
                            <tr>
                            <td width="230" width="230">
                                    <asp:Label ID="lbldrivermobno" runat="server" Text="Mother first name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label26" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="lblmother" runat="server" Text="Mother middle name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label27" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Gender" runat="server" Text="Mother last name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label28" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="lblpalceofbirth2" runat="server" Text="Mother mobile no"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label33" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="lblpalceofbirth5" runat="server" Text="Mother DOB"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left"width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label36" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Label21" runat="server" Text="Mother Email id"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label40" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                               
                                <td align="left" width="230">
                                    <asp:Label ID="Label1" runat="server"   Font-Bold="False">Mother Address</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label42" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td align="left" width="230">
                                    <asp:Label ID="Label3" runat="server"   Font-Bold="False">Mother Passport no</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label43" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </fieldset>
                            </td>
                            <td></td>
                            </tr>
                            <tr>
                                
                               <td >
                                <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Office Details</legend>
                            <table>
                            <tr>
                                <td align="left" width="230">
                                    <asp:Label ID="Label9" runat="server" Text="Mother company name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label50" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                       
                                <td align="left" width="230">
                                    <asp:Label ID="Label10" runat="server" Text="Mother Designation"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label51" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                               
                                <td align="left" width="230">
                                    <asp:Label ID="Label11" runat="server" Text="Mother Company address"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label52" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                             
                                <td align="left" width="230">
                                    <asp:Label ID="Label13" runat="server" Text="Telphone No (Office)"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label53" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              
                                <td align="left" width="230">
                                    <asp:Label ID="Label14" runat="server" Text="Income Details"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label54" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </fieldset>
                            </td>
                            <td></td>
                            </tr>
                            <tr>
                               <td>
                               <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Others</legend>
                            <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label72" runat="server" Text="Mother vehicle Name"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label ID="Label73" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                         
                                <td align="left" width="230">
                                    <asp:Label ID="Label74" runat="server" Text="Mother Vehicle No"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label75" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                          
                                <td align="left" width="230">
                                    <asp:Label ID="Label76" runat="server" Text="Mother PAN No"   Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label77" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                               
                                <td align="left" width="230">
                                    <asp:Label ID="Label78" runat="server" Text="Mother Blood Group"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label79" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            
                                <td align="left" width="230">
                                    <asp:Label ID="Label92" runat="server" Text="Mother Highest Qualification"  
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" width="230">
                                    &nbsp;&nbsp;<asp:Label ID="Label93" runat="server" CssClass="textsize" Font-Bold="False"
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </fieldset>

                            </td>
                            <td></td></tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>
                            </div>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Guardian Details
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Guardian Details</legend>
                        <div class></div>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                                <td rowspan="4" class="style6" valign="top">
                                      <asp:Image id="imgGuar1" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />&nbsp;&nbsp;
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <fieldset style="width: 600px;">
                                            <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                                                Personal Details</legend>
                                            <table>
                                                <tr>
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        <asp:Label ID="lblbob" runat="server"   Font-Bold="False" 
                                                            Text="Guardian first name"></asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label29" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        <asp:Label ID="lblpalceofbirth" runat="server"   
                                                            Font-Bold="False" Text="Guardian middle name"></asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label30" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="bottom">
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        <asp:Label ID="lblpalceofbirth0" runat="server"   
                                                            Font-Bold="False" Text="Guardian last name"></asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label31" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="bottom" width="230">
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:Label ID="Label4" runat="server"   Font-Bold="False" 
                                                            Text="Gaurdian mobile no"></asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label38" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="bottom">
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        <asp:Label ID="Label34" runat="server"   Font-Bold="False" 
                                                            Text="Guardian DOB"></asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label60" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        <asp:Label ID="Label12" runat="server"   Font-Bold="False">Guardian Address</asp:Label>
                                                    </td>
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label44" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                  
                                                    <td align="left" nowrap="nowrap" width="230">
                                                        <asp:Label ID="Label22" runat="server"   Font-Bold="False" 
                                                            Text="Guardian Email id"></asp:Label>
                                                    </td>
                                                    <td align="left" width="230">
                                                        &nbsp;&nbsp;<asp:Label ID="Label41" runat="server" CssClass="textsize" Font-Bold="False" 
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                    <td></td>
                                    </tr>
                            <tr>
                            <td>
                                <fieldset style="width: 600px;">
                                    <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                                        Office Details</legend>
                                    <table>
                                        <tr>
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label15" runat="server"   Font-Bold="False">Guardian company name</asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label55" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td align="left" class="style5" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label16" runat="server"   Font-Bold="False">Guardian Designation</asp:Label>
                                            </td>
                                            <td align="left" class="style4" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label56" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                        
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label17" runat="server"   Font-Bold="False" 
                                                    Text="Company address"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label57" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label88" runat="server"   Font-Bold="False" 
                                                    Text="Guardian Passport no"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label89" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label18" runat="server"   Font-Bold="False" 
                                                    Text="Telphone No (Office)"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label58" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label19" runat="server"   Font-Bold="False" 
                                                    Text="Income Details"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label59" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        </table>
                                        </fieldset>
                                        </td>
                                        <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                             <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Others</legend>
                        <table >
                            <tr>
        <td align="left" nowrap="nowrap" width="230">
        <asp:Label ID="Label80" runat="server"   Font-Bold="False" 
                                                    Text="Guardian vehicle Name"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label81" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label82" runat="server"   Font-Bold="False" 
                                                    Text="Guardian Vehicle No"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label83" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label84" runat="server"   Font-Bold="False" 
                                                    Text="Guardian PAN No"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label85" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label86" runat="server"   Font-Bold="False" 
                                                    Text="Guardian Blood Group"></asp:Label>
                                            </td>
                                            <td align="left" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label87" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td align="left" nowrap="nowrap" width="230">
                                                <asp:Label ID="Label94" runat="server"   Font-Bold="False" 
                                                    Text="Guardian Highest Qualification"></asp:Label>
                                            </td>
                                            <td align="left" nowrap="nowrap" width="230">
                                                &nbsp;&nbsp;<asp:Label ID="Label95" runat="server" CssClass="textsize" Font-Bold="False" 
                                                    Text="Label"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                            <td></td>
                </center>
                    </div>
                </tr>
                </table>
                </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
  
    </asp:TabContainer>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmPareProDetai.aspx.cs" Inherits="frmAdmPareProDetai" Title="Parents Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle"
        Width="99%">
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
                            <td rowspan="6" class="style8">
                                <img src="images/Student_Father.jpg"  
                                    style="line-height: normal; height: 100px; width: 80px;" border="2" /></td>
                                <td align="left" width="230">
                                    <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">Father first name</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    <asp:TextBox ID="txtvchno" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                        &nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Text="Label" 
                                        CssClass="textsize" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Father middle name</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
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
                                    <asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana" MaxLength="20"
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
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
                                    <asp:TextBox ID="txtvchmake7" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
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
                                    <asp:TextBox ID="txtvchmake10" runat="server" Font-Names="Verdana"
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label35" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                        
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label20" runat="server" Text="Father Email id" 
                                          Font-Bold="False"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake14" runat="server" Font-Names="Verdana" 
                                         ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label39" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left" width="230">
                                    <asp:Label ID="Label37" runat="server"   Font-Bold="False">Father Address</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    <asp:TextBox ID="txtvchmake17" runat="server" Font-Names="Verdana" MaxLength="20"
                                     ForeColor="Black" ValidationGroup="b"  CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label61" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label62" runat="server"   Font-Bold="False">Father Passport no</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake18" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b"  
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label63" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                          
                             <tr>
                             <td></td>
                                <td align="left" width="230">
                                    <asp:Label ID="Label2" runat="server"   Font-Bold="False">Father company name</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;<asp:Label 
                                        ID="Label45" runat="server" CssClass="textsize" Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server"   Font-Bold="False">Father Designation</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                         &nbsp;&nbsp;<asp:Label ID="Label46" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left" width="160p">
                                    <asp:Label ID="Label6" runat="server" Text="Father Company address"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox5" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label47" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="Telphone No (Office)" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox6" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label48" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label8" runat="server" Text="Income Details"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox7" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label49" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label64" runat="server" Text="Father vehicle Name"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label65" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label66" runat="server" Text="Father Vehicle No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label67" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label68" runat="server" Text="Father PAN No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox11" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label69" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label70" runat="server" Text="Father Blood Group"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox21" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label71" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label90" runat="server" Text="Father Highest Qualification"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox31" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label91" runat="server" CssClass="textsize" Font-Bold="False" 
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
                            </div>
                    </fieldset>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Mohter Details
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                    <fieldset style="width: 600px;">
                        <legend style="color: #000000; font: 13px verdana; font-weight: bold; margin-left: 190px;">
                            Mohter Details</legend>
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                            <tr>
                            <td rowspan="6" class="style8">
                                <img src="images/Student_Mother.jpg" 
                                    style="line-height: normal; height: 100px; width: 80px;" border="2" /></td>
                                <td align="left">
                                    <asp:Label ID="lbldrivermobno" runat="server" Text="Mother first name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake1" runat="server" Font-Names="Verdana" MaxLength="20"
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label26" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblmother" runat="server" Text="Mother middle name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake2" runat="server" Font-Names="Verdana" MaxLength="20"
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label27" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Gender" runat="server" Text="Mother last name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake3" runat="server" Font-Names="Verdana" MaxLength="20"
                                         ForeColor="Black" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label28" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth2" runat="server" Text="Mother mobile no" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake8" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label33" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                                <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth5" runat="server" Text="Mother DOB" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake11" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label36" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label21" runat="server" Text="Mother Email id" 
                                          Font-Bold="False"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake15" runat="server" Font-Names="Verdana" 
                                         ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label40" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                            <td></td>
                                <td align="left" width="230">
                                    <asp:Label ID="Label1" runat="server"   Font-Bold="False">Mother Address</asp:Label>
                                </td>
                                <td align="left" width="230">
                                    <asp:TextBox ID="txtvchmake19" runat="server" Font-Names="Verdana" MaxLength="20"
                                     ForeColor="Black" ValidationGroup="b"  CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label42" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server"   Font-Bold="False">Mother Passport no</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake20" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b"  
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label43" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label9" runat="server" Text="Mother company name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox8" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label50" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label10" runat="server" Text="Mother Designation" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox9" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label51" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left" class="style1">
                                    <asp:Label ID="Label11" runat="server" Text="Mother Company address" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" class="style1">
                                    <asp:TextBox ID="TextBox10" runat="server" Font-Names="Verdana" MaxLength="20" 
                                         ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label52" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label13" runat="server" Text="Telphone No (Office)" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" 
                                         MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label53" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label14" runat="server" Text="Income Details"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox13" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label54" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label72" runat="server" Text="Mother vehicle Name"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox22" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label73" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label74" runat="server" Text="Mother Vehicle No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox23" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label75" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label76" runat="server" Text="Mother PAN No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox24" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label77" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label78" runat="server" Text="Mother Blood Group"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox25" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label79" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label92" runat="server" Text="Mother Highest Qualification"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox32" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label93" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr><td colspan="3"></td></tr>
                           
                        </table>
                    </fieldset>
                </center>
                    </div>
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
                        <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                             <tr>
                             <td rowspan="6" class="style8">
                                <img src="images/Student_Guardian.jpg" 
                                    style="line-height: normal; height: 100px; width: 80px;" border="2" /></td>
                                <td align="left">
                                    <asp:Label ID="lblbob" runat="server" Text="Guardian first name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake4" runat="server" Font-Names="Verdana" MaxLength="20"
                                         ForeColor="Black" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label29" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth" runat="server" Text="Guardian middle name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake5" runat="server" Font-Names="Verdana" MaxLength="20"
                                         ForeColor="Black" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label30" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="lblpalceofbirth0" runat="server" Text="Guardian last name" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake6" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label31" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Text="Gaurdian mobile no" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox19" runat="server" Font-Names="Verdana"
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label38" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                             <tr valign="bottom">
                                <td align="left">
                                    <asp:Label ID="Label34" runat="server" Text="Guardian DOB" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox20" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label60" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td align="left">
                                    <asp:Label ID="Label12" runat="server"   Font-Bold="False">Guardian Address</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake21" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black"  MaxLength="20" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label44" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                     <asp:Label ID="Label22" runat="server" Text="Guardian Email id" 
                                          Font-Bold="False"></asp:Label></td>
                                <td align="left">
                                    <asp:TextBox ID="txtvchmake16" runat="server" Font-Names="Verdana" 
                                         ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                        CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label41" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                           
                            
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label15" runat="server"   Font-Bold="False">Guardian company name</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label55" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label16" runat="server"   Font-Bold="False">Guardian Designation</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox15" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label56" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label17" runat="server" Text="Company address" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label57" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label88" runat="server" Text="Guardian Passport no" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox30" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label89" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label18" runat="server" Text="Telphone No (Office)" 
                                          Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox17" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label58" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label19" runat="server" Text="Income Details"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox18" runat="server" Font-Names="Verdana" 
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                        &nbsp;&nbsp;<asp:Label ID="Label59" runat="server" CssClass="textsize" 
                                        Font-Bold="False" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label80" runat="server" Text="Guardian vehicle Name"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox26" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label81" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label82" runat="server" Text="Guardian Vehicle No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox27" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label83" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label84" runat="server" Text="Guardian PAN No"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox28" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label85" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label86" runat="server" Text="Guardian Blood Group"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox29" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label87" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                            <td></td>
                                <td align="left">
                                    <asp:Label ID="Label94" runat="server" Text="Guardian Highest Qualification"   
                                        Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox33" runat="server" Font-Names="Verdana" MaxLength="20" 
                                        ForeColor="Black" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:Label ID="Label95" runat="server" CssClass="textsize" Font-Bold="False" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr><td colspan="3"></td></tr>
                        </table>
                    </fieldset>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
    </style>
</asp:Content>


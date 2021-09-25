<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="FrmAdmTeaProDetai.aspx.cs" Inherits="FrmAdmTeaProDetai" Title="Teacher Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Personal Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr>
                    <td rowspan="6" class="style4">
                        <img src="images/Sample%20Photo.jpg"  style="line-height: normal; height: 109px;" />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">First Name</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label46" runat="server"   Font-Bold="False">Mr.Sharad</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    
                        <td align="left" class="style2">
                            <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Middle Name</asp:Label>
                        </td>
                        <td class="style2" align="left">
                            <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label47" runat="server"   Font-Bold="False">Ramesh</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    
                        <td align="left">
                            <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label48" runat="server"   Font-Bold="False">Wora</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    
                        <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="Preferd Subjects" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox6" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label49" runat="server"   Font-Bold="False">English</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    
                        <td align="left">
                            <asp:Label ID="Label12" runat="server" Text="Department id"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox8" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"  
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label50" runat="server"   Font-Bold="False">Language</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    
                        <td align="left">
                            <asp:Label ID="Label13" runat="server" Text="Gender"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox9" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label51" runat="server"   Font-Bold="False">Male</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left" class="style1">
                            <asp:Label ID="Label14" runat="server" Text="Date of Birth"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td class="style1" align="left">
                            <asp:TextBox ID="TextBox10" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label52" runat="server"   Font-Bold="False">15-jun-1980</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="lbldrivermobno" runat="server" Text="Email"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label53" runat="server"   Font-Bold="False">Sharad@ymail.com</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label15" runat="server" Text="Highest Qualifiacation" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox11" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label54" runat="server"   Font-Bold="False">Mbbs</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label16" runat="server" Text="Home Telphone number 1" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label55" runat="server"   Font-Bold="False">7304578952</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label17" runat="server" Text="Home Telphone number 2" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox13" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label56" runat="server"   Font-Bold="False">022-65784598</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label18" runat="server" Text="Mobile number"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label57" runat="server"   Font-Bold="False">9875896124</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label19" runat="server" Text="facebook url"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox15" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label58" runat="server"   Font-Bold="False">Shad562@facebook.com</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label20" runat="server" Text="Twitter Url"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label59" runat="server"   Font-Bold="False">Sharadwora@twitter.com</asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="style4"></td>
                        <td align="left">
                            <asp:Label ID="Label21" runat="server" Text="Other Url"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox17" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                CssClass="textsize"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label60" runat="server"   Font-Bold="False">None</asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="style4">
                            
                            <asp:ImageButton ID="btnsubmit" runat="server" ForeColor="#999999" Height="28px"
                                ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" />
                        </td>
                        <td>
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
                        <td align="center" colspan="3">
                            <asp:Label ID="Label8" runat="server" Text="Address Details" 
                                CssClass="textheadcss"></asp:Label>
                            <br />
                          
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server"   Font-Bold="False">Present Address</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="182px" 
                                Height="45px"></asp:TextBox>
                                </td>
                                <td align="left">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label61" runat="server"   Font-Bold="False">R401,SK Vila,Dadar</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3" nowrap="nowrap">
                            <asp:Label ID="Label4" runat="server" Text="Permanet Address" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td class="style3" nowrap="nowrap">
                            <asp:TextBox ID="TextBox5" runat="server" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="180px" 
                                Height="48px"></asp:TextBox>
                                </td>
                                <td align="left">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label62" runat="server"   Font-Bold="False">American Center,24,Kasturba Gandhi Marg,<br />New Delhi - 110001</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <br />
                            <asp:ImageButton ID="ImageButton1" runat="server" ForeColor="#999999" Height="28px"
                                ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" />
                        
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
                Qualification Deatils</HeaderTemplate>
            <ContentTemplate>
                  <div class="efficacious">
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="Qualification Deatils" 
                                CssClass="textheadcss"></asp:Label>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Highest Qualifiacation:" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="75px">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label63" runat="server"   Font-Bold="False">MBBS</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Year of Passing:" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="75px">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label64" runat="server"   Font-Bold="False">2009-2010</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Percentage/Grade:" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList4" runat="server" Width="75px">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label65" runat="server"   Font-Bold="False">85%</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="University:"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList5" runat="server" Width="75px">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label66" runat="server"   Font-Bold="False">Delhi University </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <br />
                            <br />
                            <asp:ImageButton ID="ImageButton3" runat="server" ForeColor="#999999" Height="28px"
                                ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" />
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
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    
</asp:Content>


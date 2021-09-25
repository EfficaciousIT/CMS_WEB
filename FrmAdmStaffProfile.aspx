<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="FrmAdmStaffProfile.aspx.cs" Inherits="FrmAdmStaffProfile" Title="Staff Profile" Culture="es-MX" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding:05px 0 0 0">
    <asp:UpdatePanel ID="up2" runat="server">
        <ContentTemplate>
                
<table>
    <tr><td><asp:Label ID="Labnorecord" runat="server" ></asp:Label></td></tr>
    <tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2"
        Width="928px" CssClass="MyTabStyle">
      
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
               
                Personal Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <div class="efficacious">
                         <table style="font-weight: bolder; width: 70%" align="center">
               
                    <tr>
                    <td rowspan="16" valign="top">
                        <br />
                            <asp:Image id="TeacherImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                    runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                    border="2" ToolTip="Image" />
                        </td>
                        <td align="left" >
                            <asp:Label ID="lblvchno" runat="server"   Font-Bold="False">First Name</asp:Label>
                            
                        </td>
                        <td align="left" nowrap="nowrap">
                             <asp:Label ID="Label1" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="TextBox1" ValidationGroup="a1"   Display="None" 
                                ErrorMessage="Please Enter First Name" Font-Bold="False"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                            </asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="Reg30" 
                                runat="server" ValidationGroup="a1" ControlToValidate="TextBox1"   Display="None" 
                                ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red" 
                                ValidationExpression="^[a-zA-Z]$+"></asp:RegularExpressionValidator>
                            &nbsp;&nbsp;
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" 
                                Enabled="True" TargetControlID="Reg30">
                            </asp:ValidatorCalloutExtender>
                       
                            </td>
                    </tr>
                    <tr>
                    
                        <td align="left" >
                            <asp:Label ID="lblvchmake" runat="server"   Font-Bold="False">Middle Name</asp:Label>
                     
                        </td>
                        <td align="left" >
                                  <asp:Label ID="Label2" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                          
                            </td>
                    </tr>
                    <tr>
                    
                        <td align="left" style="padding-top:10px">
                            <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left"  nowrap="nowrap" >
                             <asp:Label ID="Label5" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"   ></asp:TextBox>&nbsp;&nbsp;
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="TextBox3" ValidationGroup="a1"   Display="None" 
                                ErrorMessage="Please Enter last Name" Font-Bold="False"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" 
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                            </asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="Regg2" 
                                runat="server" ControlToValidate="TextBox3" ValidationGroup="a1"   Display="None" 
                                ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red" 
                                ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator>
                            &nbsp;&nbsp;
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" 
                                Enabled="True" TargetControlID="Regg2">
                            </asp:ValidatorCalloutExtender>
                         
                            </td>
                    </tr>
                    <tr>
                    
                        <td align="left" style="padding-top:10px;white-space:nowrap">
                            <asp:Label ID="Label9" runat="server" Text="Preferd Subjects" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left" >
                                                         <asp:Label ID="Label6" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b"  ></asp:TextBox>

                            </td>
                    </tr>
                    <tr>
                    
                        <td align="left" >
                            <asp:Label ID="Label12" runat="server" Text="Department Name"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                              <asp:Label ID="Label10" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:DropDownList ID="TextBox5" runat="server" DataTextField="vchDepartment_name" DataValueField='intDepartment'   Width="160px" OnSelectedIndexChanged="TextBox5_SelectedIndexChanged">
                             </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Select Department" ValidationGroup="a1" ControlToValidate="TextBox5" 
                                InitialValue="Select" Display="None"   Font-Bold="False"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                             runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                            </asp:ValidatorCalloutExtender>
                            
                           
                            </td>
                    </tr>
                    <tr>
                    
                        <td align="left">
                            <asp:Label ID="Label13" runat="server" Text="Gender"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                        
                                    <asp:Label ID="Label11" runat="server"   Font-Bold="False"></asp:Label>

                                <asp:DropDownList ID="TextBox6"   Width="160px" runat="server" >
                                <asp:ListItem Value="Select" Selected="True">---Select---</asp:ListItem>
                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                </asp:DropDownList>
                           
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Select Gender" ControlToValidate="TextBox6" 
                                    InitialValue="Select" Display="None" ValidationGroup="a1"   Font-Bold="False"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                 runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"></asp:ValidatorCalloutExtender>
                     
                           
                             </td>
                    </tr>
                    <tr>
                   
                        <td align="left" >
                            <asp:Label ID="Label14" runat="server" Text="Date of Birth"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left" nowrap="nowrap">
                             <asp:Label ID="Label22" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox7" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                  ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;
                                 <asp:CalendarExtender
                                                        ID="CalendarExtender3" runat="server" TargetControlID="TextBox7" Enabled="True"></asp:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7"
                                                      ValidationGroup="a1" Display="None" ErrorMessage="Please Enter Dob Name" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                                    </asp:ValidatorCalloutExtender>
                                                &nbsp;&nbsp;
                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox7"
                                                      Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)"
                                                    Font-Bold="False" Operator="LessThan"  SetFocusOnError="True" Type="Date" ValidationGroup="a1"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13"
                                                        runat="server" Enabled="True" TargetControlID="CompareValidator3">
                                                    </asp:ValidatorCalloutExtender>
                            

                            </td>
                    </tr>
                    <tr>
             
                        <td align="left">
                            <asp:Label ID="lbldrivermobno" runat="server" Text="Email"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left"  nowrap="nowrap">
                              <asp:Label ID="Label23" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox8" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                               ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="TextBox8" Display="None" ValidationGroup="p1" ErrorMessage="Invalid Email Format" Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                    </asp:ValidatorCalloutExtender>
                           
                            </td>
                    </tr>
                    <tr>
                   
                        <td align="left" >
                            <asp:Label ID="Label15" runat="server" Text="Highest Qualifiacation" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                               <asp:Label ID="Label24" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox9" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                          
                            </td>
                    </tr>
                    <tr>
                
                        <td align="left" >
                            <asp:Label ID="Label16" runat="server" Text="Home Telphone number 1" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                                <asp:Label ID="Label25" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox10" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>&nbsp;&nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" 
                                runat="server" ValidationGroup="a1" ControlToValidate="TextBox10"   Display="None" 
                                ErrorMessage="Enter valid Phone number" Font-Bold="False" 
                                ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" 
                                Enabled="True" TargetControlID="RegularExpressionValidator29">
                            </asp:ValidatorCalloutExtender>
                         
                            </td>
                    </tr>
                    <tr>
                   
                        <td align="left" >
                            <asp:Label ID="Label17" runat="server" Text="Home Telphone number 2" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left" >
                              <asp:Label ID="Label26" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox11" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>&nbsp;&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" ValidationGroup="a1" ControlToValidate="TextBox10"   Display="None" 
                                ErrorMessage="Enter valid Phone number" Font-Bold="False" 
                                ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                Enabled="True" TargetControlID="RegularExpressionValidator29">
                            </asp:ValidatorCalloutExtender>
                           
                            </td>
                    </tr>
                    <tr>
                    
                        <td align="left" >
                            <asp:Label ID="Label18" runat="server" Text="Mobile number"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left"  nowrap="nowrap">
                              <asp:Label ID="Label27" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                         
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox12" ValidationGroup="a1"   Display="None" 
                                ErrorMessage="Please Enter Father Mobile No" Font-Bold="False"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" 
                                Enabled="True" TargetControlID="RequiredFieldValidator4">
                            </asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="Regg33" runat="server" 
                                ControlToValidate="TextBox12" ValidationGroup="a1" Display="None" ErrorMessage="Enter Valid Mobile no" 
                                Font-Bold="False" ValidationExpression="[0-9]{10}"  ></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" 
                                Enabled="True" TargetControlID="Regg33">
                            </asp:ValidatorCalloutExtender>
                           
                            </td>
                    </tr>
                    <tr>
                  
                        <td align="left" >
                            <asp:Label ID="Label19" runat="server" Text="facebook url"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left" >
                              <asp:Label ID="Label28" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox13" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                           
                            <asp:RegularExpressionValidator ID="RegE22" runat="server" 
                                ControlToValidate="TextBox13" ValidationGroup="a1" Display="None" ErrorMessage="Enter Valid facebook id" 
                                Font-Bold="False" ValidationExpression="^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$"  ></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                Enabled="True" TargetControlID="Regg33">
                            </asp:ValidatorCalloutExtender>
                             </td>
                    </tr>
                    <tr>
                 
                        <td align="left" >
                            <asp:Label ID="Label20" runat="server" Text="Twitter Url"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left">
                                 <asp:Label ID="Label29" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                        
                            </td>
                    </tr>
                    <tr>
                
                        <td align="left" >
                            <asp:Label ID="Label21" runat="server" Text="Other Url"   
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td align="left" >
                                 <asp:Label ID="Label30" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox15" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                        
                            </td>
                    </tr>
                    <tr><td align="left"><asp:Label ID="Label34" runat="server" Text="Time To Contact"   
                                Font-Bold="False"></asp:Label></td><td  align="left" ><asp:Label ID="Label33" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox18" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox></td></tr>
                    <tr id="bro1" runat="server">
                        <td runat="server"></td>
                        <td ID="img" runat="server" align="left" colspan="2" >
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" 
                                                    UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload1" runat="server"   />
                                                        
                                                        <asp:Button    ID="Button1" runat="server"   
                                                            OnClick="Button1_Click" CssClass="efficacious_send" OnClientClick="if (!validatePage()) {return true;}" 
                                                            Text="Upload File" />
                                                        &nbsp;<br />
                                                        <br />
                                                    </ContentTemplate>
                                                    <Triggers>
<asp:PostBackTrigger ControlID="Button1" />
</Triggers>
                                                </asp:UpdatePanel>
                                            </td></tr>
                                            <tr>
                                            <td ></td>
                                            <td>&nbsp;</td>
                                            <td align="right" width="30px">
                                                <asp:Button    runat="server" CssClass="efficacious_send"   Text="next"
                                                    ID="ButN1" OnClick="checknextval1" ValidationGroup="a1" ></asp:Button   >
                                            </td></tr>
                   
                </table>
                        </div>
                    </center>

            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Address Details
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <div class="efficacious">
                <table  align="center" width="60%">
                    
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server"   Font-Bold="False">Present Address</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label31" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" ></asp:TextBox>
                                </td>
                                <td align="left">
                                
<asp:RegularExpressionValidator ID="Regulor2" 
                                runat="server" ValidationGroup="a1" ControlToValidate="TextBox16"   Display="None" 
                                ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red" 
                                ValidationExpression= "^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$"></asp:RegularExpressionValidator>
                            &nbsp;&nbsp;
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" 
                                Enabled="True" TargetControlID="Regulor2">
                            </asp:ValidatorCalloutExtender>
                       
                            </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap="nowrap">
                            <asp:Label ID="Label4" runat="server" Text="Permanet Address" 
                                  Font-Bold="False"></asp:Label>
                        </td>
                        <td >
                                <asp:Label ID="Label32" runat="server"   Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="TextBox17" runat="server" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="Black" MaxLength="20"   ValidationGroup="b" ></asp:TextBox>
                                </td>
                                <td align="left">
                
                            </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            
                            </td>
                    </tr>
                     <tr>
                              <td colspan="3">
                                  <table width="100%"><tr>
                                            <td align="left">
                                                <asp:Button    runat="server" CssClass="efficacious_send"  OnClientClick="if (!validatePage()) {return true;}" Text="Back"
                                                    ID="ButP2" OnClick="checkPrivious2"></asp:Button   >
                                            </td>
                                            <td width="70%"></td>
                                            <td align="right">
                                                <asp:Button    runat="server" CssClass="efficacious_send"   OnClientClick="if (!validatePage()) {return true;}"  Text="next"
                                                    ID="ButN2" OnClick="checknextval2"></asp:Button   >
                                            </td>
                                      </tr></table>
                                  </td>
                                        </tr>
                </table>
                        </div>
                </center>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server">
            <HeaderTemplate>Education Details</HeaderTemplate>
                <ContentTemplate>
                    <div class="efficacious">
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"  runat="server" TargetControlID="txtDegree1" FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                    </asp:FilteredTextBoxExtender>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtInstitution1" FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                    </asp:FilteredTextBoxExtender>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPassingYear1"
                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtPercent1"
                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%." Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtMajorSubject1"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDegree2"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtInstitution2"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPassingYear2"
                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPercent1"
                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%." Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtMajorSubject2"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtDegree3"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtInstitution3"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtPassingYear3"
                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtPercent3"
                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%." Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtMajorSubject3"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txtDegree4"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txtInstitution4"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" TargetControlID="txtPassingYear4"
                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" TargetControlID="txtPercent4"
                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%." Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" TargetControlID="txtMajorSubject4"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txtDegree5"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" TargetControlID="txtInstitution5"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" TargetControlID="txtPassingYear5"
                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtPercent5"
                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%." Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" TargetControlID="txtMajorSubject5"
                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
            </asp:FilteredTextBoxExtender>
            <asp:CalendarExtender ID="cal1" runat="server" TargetControlID="txtPassingYear1"
                Format="yyyy" Enabled="True">
            </asp:CalendarExtender>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPassingYear2"
                Format="dd/MM/yyyy" Enabled="True">
            </asp:CalendarExtender>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPassingYear3"
                Format="dd/MM/yyyy" Enabled="True">
            </asp:CalendarExtender>
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtPassingYear4"
                Format="dd/MM/yyyy" Enabled="True">
            </asp:CalendarExtender>
            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtPassingYear5"
                Format="dd/MM/yyyy" Enabled="True">
            </asp:CalendarExtender>
                  <div class="efficacious">
                    <table cellpadding="6" cellspacing="6">
                        
                <tr>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <td align="center">
                        Degree / Diploma / Other
                    </td>
                    <td align="center">
                        Institution
                    </td>
                    <td align="center">
                        University</td>
                    <td align="center" >
                        Year of Passing
                    </td>                    
                    <td align="center">
                        % Score / Grade</td>
                    <td align="center">
                        Major Subjects
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr id="tr1" runat="server">
                    <td align="center"  nowrap="nowrap" valign="middle" runat="server">  
                                          
                       <asp:Button    ID="Button4" runat="server" CssClass="efficacious_send" Text="+" OnClientClick="if (!validatePage()) {return true;}" OnClick="Button4_Click"  />  

                              </td>
                   
                    <td valign="top" align="center" runat="server" >
                       
                         <asp:TextBox ID="txtDegree1" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" MaxLength="50"></asp:TextBox>
                      <br /><asp:Label ID="txtDegreev1" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtInstitution1" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server"></asp:TextBox>
                                     <br /><asp:Label ID="txtInstitutionv1" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtUniversity1" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                     <br /><asp:Label ID="txtUniversityv1" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                                                <asp:TextBox runat="server" MaxLength="5"  ID="txtPassingYear1" oncopy="return false" oncut="return false" AutoComplete="Off" onpaste="return false"></asp:TextBox>

                       <br /><asp:Label ID="txtPassingYearv1" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtPercent1" oncopy="return false" oncut="return false" AutoComplete="Off"
                                        onpaste="return false"   runat="server" MaxLength="5"></asp:TextBox>
                            <br /><asp:Label ID="txtPercentv1" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server" aling="center">
                        <asp:TextBox ID="txtMajorSubject1" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                         <br /><asp:Label ID="txtMajorSubjectv1" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server">
                       
                    </td>
                </tr>
                <tr id="tr2" runat="server" visible="False">
                    <td align="center" nowrap="nowrap" valign="middle"  runat="server">
                       <asp:Button    ID="Button5" runat="server" Text="+" OnClick="Button5_Click" CssClass="efficacious_send" OnClientClick="if (!validatePage()) {return true;}" />  
                       
                    </td>
                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                        <asp:TextBox ID="txtDegree2" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server"></asp:TextBox>
                    <br /><asp:Label ID="txtDegreev2" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtInstitution2" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                          <br /><asp:Label ID="txtInstitutionv2" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    
<td valign="top" align="center" runat="server" >
                        <asp:TextBox ID="txtUniversity2" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
     <br /><asp:Label ID="txtUniversityv2" runat="server"   Font-Bold="False"></asp:Label>
</td>
                    <td valign="top" align="center"  runat="server">
                        <asp:TextBox ID="txtPassingYear2" runat="server" 
                            MaxLength="10" ></asp:TextBox>
                          <br /><asp:Label ID="txtPassingYearv2" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtPercent2" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server"  MaxLength="5"></asp:TextBox>
                     <br /><asp:Label ID="txtPercentv2" runat="server"   Font-Bold="False"></asp:Label>
                         </td>
                    <td valign="top" runat="server" align="center">
                        <asp:TextBox ID="txtMajorSubject2" runat="server" ></asp:TextBox>
                          <br /><asp:Label ID="txtMajorSubjectv2" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server">
                       
                    </td>
                </tr>
                <tr id="tr3" runat="server" visible="False">
                    <td align="center" nowrap="nowrap" valign="middle"  runat="server">
                        <asp:Button    ID="Button6" runat="server" CssClass="efficacious_send" Text="+" OnClick="Button6_Click" OnClientClick="if (!validatePage()) {return true;}" style="height: 26px" />  
                       
                    </td>
                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                        <asp:TextBox ID="txtDegree3" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                         <br /><asp:Label ID="txtDegreev3" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtInstitution3" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                      <br /><asp:Label ID="txtInstitutionv3" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    
<td valign="top" align="center" runat="server" >
                        <asp:TextBox ID="txtUniversity3" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
         <br /><asp:Label ID="txtUniversityv3" runat="server"   Font-Bold="False"></asp:Label>
</td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtPassingYear3"   runat="server"
                            MaxLength="10"></asp:TextBox>
                          <br /><asp:Label ID="txtPassingYearv3" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtPercent3" runat="server" oncopy="return false" oncut="return false" 
                                        onpaste="return false" MaxLength="10"></asp:TextBox>
                        <br /><asp:Label ID="txtPercentv3" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server" align="center">
                        <asp:TextBox ID="txtMajorSubject3" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                    <br /><asp:Label ID="txtMajorSubjectv3" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server">
                       
                    </td>
                </tr>
                <tr id="tr4" runat="server" visible="False">
                    <td align="center" nowrap="nowrap" valign="middle"  runat="server">
                        <asp:Button    ID="Button7" runat="server" CssClass="efficacious_send" Text="+" OnClick="Button7_Click" OnClientClick="if (!validatePage()) {return true;}" />  
                        &nbsp;</td>
                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                        <asp:TextBox ID="txtDegree4" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server"></asp:TextBox>
                    <br /><asp:Label ID="txtDegreev4" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtInstitution4" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                          <br /><asp:Label ID="txtInstitutionv4" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server" >
                        <asp:TextBox ID="txtUniversity4" oncopy="return false" oncut="return false" 
                                        onpaste="return false" CssClass="formlbl" runat="server" ></asp:TextBox>
                            <br /><asp:Label ID="txtUniversityv4" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" class="style4" runat="server">
                        <asp:TextBox ID="txtPassingYear4"   runat="server" 
                            MaxLength="10"></asp:TextBox>
                        <br /><asp:Label ID="txtPassingYearv4" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtPercent4"   oncopy="return false" oncut="return false" 
                                        onpaste="return false" runat="server"  MaxLength="10"></asp:TextBox>
 <br /><asp:Label ID="txtPercentv4" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server" align="center">
                        <asp:TextBox ID="txtMajorSubject4" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                        <br /><asp:Label ID="txtMajorSubjectv4" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server">
                      
                    </td>
                </tr>
                <tr id="tr5" runat="server" visible="False">
                    <td align="center" nowrap="nowrap" valign="middle" runat="server">                        
                        &nbsp;</td>
                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                        <asp:TextBox ID="txtDegree5" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                        <br /><asp:Label ID="txtDegreev5" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtInstitution5" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                          <br /><asp:Label ID="txtInstitutionv5" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    
<td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtUniversity5" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
    <br /><asp:Label ID="txtUniversityv5" runat="server"   Font-Bold="False"></asp:Label>
</td>
                    <td valign="top" align="center"  runat="server">
                        <asp:TextBox ID="txtPassingYear5"   runat="server" 
                            MaxLength="10" ></asp:TextBox>
                        <br /><asp:Label ID="txtPassingYearv5" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" align="center" runat="server">
                        <asp:TextBox ID="txtPercent5" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server"  MaxLength="10"></asp:TextBox>
                     <br /><asp:Label ID="txtPercentv5" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server" align="center">
                        <asp:TextBox ID="txtMajorSubject5" oncopy="return false" oncut="return false" 
                                        onpaste="return false"   runat="server" ></asp:TextBox>
                         <br /><asp:Label ID="txtMajorSubjectv5" runat="server"   Font-Bold="False"></asp:Label>
                    </td>
                    <td valign="top" runat="server">
                       
                        
                    </td>
                </tr>
               
               
                <tr>
                    <td align="center" colspan="6" >
                        <table><tr><td>
                        <asp:Button    runat="server"   OnClientClick="if (!validatePage()) {return true;}" Text="Back"
                                                    ID="Button3" CssClass="efficacious_send" OnClick="checkPrivious3"></asp:Button   >
                        </td>
                            <td width="70%"></td><td>
                            <asp:Button    ID="Button2"   runat="server" CssClass="efficacious_send" OnClientClick="if (!validatePage()) {return true;}"
                                                    OnClick="submit" Text="Submit"></asp:Button   >
                       </td>
                            </tr>
                            <tr>
                           
<td>                    <asp:Label ID="lab1" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td><asp:Label ID="lab2" runat="server" Visible="false"></asp:Label>

                       </td>
                                 <td><asp:Button    ID="Button8"   runat="server" CssClass="efficacious_send" OnClick="Updateval" Text="Update"></asp:Button   ></td>
                            </tr></table>

                            </td>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
            </table>
                      </div>
                        </center>
                      </div>
                </ContentTemplate>

        </asp:TabPanel>
    </asp:TabContainer>
</td></tr></table>
            
                     </ContentTemplate></asp:UpdatePanel>
</div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
       
    </style>
</asp:Content>


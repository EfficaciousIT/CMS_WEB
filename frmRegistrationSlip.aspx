<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmRegistrationSlip.aspx.cs" Inherits="frmRegistrationSlip" Title="E-Smarts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 60%;
            font-family: Verdana;
        }
        .style2
        {
            height: 27px;
        }
        .formlbl
        {
            font: Normal 11px Verdana, Arial, Helvetica, sans-serif;
            padding: 4px 0 0 0;
            text-transform: capitalize;
        }
        .style3
        {
            width: 70%;
            float: left;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            width: 13px !important;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            float: left;
            margin-right: 10px;
        }
        .style4
        {
            height: 29px;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 60%;
            font-family: Verdana;
        }
        .style2
        {
            height: 27px;
        }
        .style3
        {
            width: 100%;
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
            width: 100%;
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
            font-size: 12px;
            margin: 0 !important;
            padding: 0 !important;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 100% !important;
            color: #000;
        }
        .gender span
        {
            display: block;
            height: auto;
            font-size: 12px;
            margin: 0 !important;
            padding: 0 !important;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 120px;
            color: #000;
        }
        .efficacious input[type="image"]
        {
            border: 0px;
            padding: 0px;
        }
        .efficacious select
        {
            width: 40% !important;
            border: 1px solid #d5d5d5 !important;
            padding: 0;
            height: 29px !important;
            border-radius: 0 !important;
            -webkit-border-radius: 0 !important;
            font-size: 13px;
            margin: 5px;
        }
        .efficacious textarea
        {
            width: 40% !important;
            border: 1px solid #d5d5d5 !important;
            padding: 5px 5px;
            height: 32px;
            border-radius: 0px !important;
            -webkit-border-radius: 0px !important;
            -moz-border-radius: 0px !important;
            font-size: 13px;
            margin: 5px 0 0 5px !important;
        }
        .efficacious input.efficacious_send
        {
            width: 90%;
            background: #e2222f;
            border: 1px solid #00000;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center;
        }
        .efficacious_send
        {
            width: 30%;
            background: #3498db;
            font-size: 16px;
            border: none;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            color: #fff;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center;
        }
        .efficacious input
        {
            width: 40% !important;
            border: 1px solid #d5d5d5 !important;
            font-size: 16px;
            background: #f8f8f8;
            color: #242424;
            float: left;
            text-align: left;
            padding: 5px;
            margin: 5px;
            border-radius: 0 !important;
            -webkit-border-radius: 0 !important;
        }
        .efficacious input[type=checkbox]:checked + label:after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=100);
            opacity: 1;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            width: 17px !important;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
        }
        .efficacious label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            white-space: nowrap;
        }
        .efficacious input[type=checkbox] + label
        {
            display: block;
            width: 1.1em;
            height: 0.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
        }
        .efficacious input[type=checkbox]:checked + label::before
        {
            content: "\2714";
            color: #fff;
            height: 1em;
            line-height: 1.1em;
            width: 1.1em;
            font-weight: 900;
            margin-right: 6px;
            margin-left: -20px;
        }
        .efficacious input[type=radio] + label
        {
            display: block;
            width: 8em;
            height: -1em;
            background: #3498db !important;
            border-radius: 5px !important;
            border: none !important;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            text-indent: 0px !important;
            text-align: center;
        }
        .wrapper1
        {
            width: 939px;
            height: auto;
            margin: 0 auto;
        }
        .pagewrapper1
        {
            width: 939px;
            margin: 0 auto;
            height: auto;
        }
        .inquiry-name
        {
            width: 180px;
            float: left;
            margin: 5px;
            padding: 7px;
        }
        .inquiry-field
        {
            width: 730px;
            float: left;
        }
        .gender
        {
            width: 244px;
            float: left;
        }
        .gender-name
        {
            width: 66px;
            float: left;
            border: 1px solid #d5d5d5;
            padding: 6px 5px;
            margin: 5px;
        }
        .father
        {
            width: 266px;
            float: left;
        }
        .father-name
        {
            width: 153px;
            float: left;
            border: 1px solid #d5d5d5;
            padding: 6px 5px;
            margin: 5px;
        }
        .clearfix
        {
            clear: both;
            margin: 0;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var print = document.getElementById("btnSubmit");
            alert(print);
            //Set the print button visibility to 'hidden'            
            print.style.visibility = 'hidden';
            //Print the page content
            window.resizeTo('100%', '100%');
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]           
            print.style.visibility = 'visible';

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">
        function print() {

            
            
            var txtInquiryNo = document.getElementById("<%=txtInquiryNo.ClientID %>").value;



            var txtRegistrationNo = document.getElementById("<%=txtRegistrationNo.ClientID %>").value;



            var txtCondidatename = document.getElementById("<%=txtCondidatename.ClientID %>").value;



            var drpStandard = document.getElementById("<%=drpStandard.ClientID %>").value;



            var txtAmount = document.getElementById("<%=txtAmount.ClientID %>").value;



            var date = new Date();


            dateString = (date.getDate()) + "/" + (date.getMonth() + 1) + "/" + date.getFullYear().toString();




            var printWin = window.open("about:blank", "Voucher", "menubar=no;status=no;toolbar=no;");
            printWin.document.write("<html><head><title>Registration Form Receipt</title></head><body><table width=70 border=0 cellspacing=0 cellpadding=0 align=center style=border:1px dashed #424242;><tr><td align=center style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>&nbsp;</td></tr><tr><td align=center style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Swami Vivekanand School</td> </tr> <tr><td align=center style=font-family:Verdana, Geneva, sans-serif; font-size:14px; color:#000; >Vashi, Navi Mumbai</td></tr><tr><td align=center>&nbsp;</td></tr><tr><td align=center><table width=700 border=0 cellspacing=0 cellpadding=0><tr><td width=475>&nbsp;</td><td width=77 align=center style=font-family:Verdana, Geneva, sans-serif; font-size:14px; color:#000;>Date</td><td width=20 align=center>:</td><td width=128 style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000; padding-left:5px;>" + dateString + "</td></tr><tr><td>&nbsp;</td>        <td align=center style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>&nbsp;</td><td align=center>&nbsp;</td><td style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>&nbsp;</td></tr></table></td></tr><tr><td align=center><table width=700 border=0 align=center cellpadding=0 cellspacing=0><tr>        <td width=16>&nbsp;</td>        <td width=166 height=25 align=left style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Registration No.</td>        <td width=11 height=25 align=center>:</td>        <td width=492 style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000; margin-bottom:5px; border-bottom:1px dashed #242424; padding-left:10px;>" + txtRegistrationNo + "</td>        <td width=15 >&nbsp;</td>      </tr>      <tr>        <td>&nbsp;</td>        <td height=25 align=left style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Inquiry No.</td>        <td height=25 align=center>:</td>        <td style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000; margin-bottom:5px; border-bottom:1px dashed #242424; padding-left:10px;>" + txtInquiryNo + "</td>        <td>&nbsp;</td>      </tr>      <tr>        <td>&nbsp;</td>        <td height=25 align=left style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Student Name</td>        <td height=25 align=center>:</td>        <td style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000; margin-bottom:5px; border-bottom:1px dashed #242424; padding-left:10px;>" + txtCondidatename + "</td>        <td>&nbsp;</td>      </tr>      <tr>        <td>&nbsp;</td>        <td height=25 align=left style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Standard</td>        <td height=25 align=center>:</td>        <td style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000; margin-bottom:5px; border-bottom:1px dashed #242424; padding-left:10px;>" + drpStandard + "th</td>        <td>&nbsp;</td>      </tr>      <tr>        <td>&nbsp;</td>        <td height=25 align=left style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Amount</td>        <td height=25 align=center>:</td>        <td style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000; margin-bottom:5px; border-bottom:1px dashed #242424; padding-left:10px;>Rs " + txtAmount + "/-</td>        <td>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr>    <td align=center>&nbsp;</td>  </tr>  <tr>    <td align=center>&nbsp;</td>  </tr>  <tr>    <td align=center><table width=700 border=0 cellspacing=0 cellpadding=0>      <tr>        <td width=446>&nbsp;</td>        <td width=254 align=center style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>Signature</td>      </tr>      <tr>        <td>&nbsp;</td>        <td align=center style=font-family:Verdana, Geneva, sans-serif; font-size:16px; color:#000;>&nbsp;</td>      </tr>    </table></td>  </tr></table></body></html>");
            printWin.document.close();
            printWin.window.print();
            printWin.close();
        }
        String.prototype.insertAt = function(index, string) {
            return this.substr(0, index) + string + this.substr(index);
        }
    
    </script>
    
    <script type="text/javascript" language="javascript">
        function validation() {
        
            var txtInquiryNo = document.getElementById("<%=txtInquiryNo.ClientID %>").value;

            var txtRegistrationNo = document.getElementById("<%=txtRegistrationNo.ClientID %>").value;

            var txtCondidatename = document.getElementById("<%=txtCondidatename.ClientID %>").value;

            var txtfatherName = document.getElementById("<%=txtfatherName.ClientID %>").value;

            var txtFatherMobile = document.getElementById("<%=txtFatherMobile.ClientID %>").value;

            var txtAmount = document.getElementById("<%=txtAmount.ClientID %>").value;

            var drpStandard = document.getElementById("<%=drpStandard.ClientID %>").value;            
            
            if (txtInquiryNo == '') {

                alert('Please provide Enquiry number');
                return false;
            }

            if (txtRegistrationNo == '') {

                alert('Please provide Registration number');
                return false;
            }

            if (drpStandard == '0') {

                alert('Please select standard');
                return false;
            }

            if (txtCondidatename == '') {

                alert('Please provide candidate name');
                return false;
            }



            if (txtfatherName == '') {

                alert('Please provide father name');
                return false;
            }
            
            if (txtFatherMobile == '') {

                alert('Please provide father mobile number');
                return false;
            }

            if (txtAmount == '') {

                alert('Please enter amount');
                return false;
            }

            return true;

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <div class="content-header">
        <h1>
            Registration Acceptance Form
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">Registration Form</li>
            <li class="active">Registration Acceptance Form</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="wrapper1">
                <div class="pagewrapper1">
                    <div class="efficacious">
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo" runat="server" Text="Inquiry No" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:RadioButton Font-Size="11px" ID="rdbYes" GroupName="Inquiry" Text="Yes" runat="server"
                                OnCheckedChanged="rdbYes_CheckedChanged" AutoPostBack="True" />
                            <asp:RadioButton Font-Size="11px" ID="rdbNo" AutoPostBack="true" GroupName="Inquiry"
                                Text="No" runat="server" OnCheckedChanged="rdbNo_CheckedChanged" />
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                        </div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtInquiryNo" runat="server" OnTextChanged="txtInquiryNo_TextChanged" CssClass="input-blue"
                                AutoPostBack="True"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtInquiryNo"
                                Mask="L/LL/9999/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="None" InputDirection="RightToLeft"
                                AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" CultureCurrencySymbolPlaceholder=""
                                CultureDateFormat="" />
                            <%--<asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                    AcceptAMPM="false" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True" Mask="L/LL/9999/9999" MaskType="Time" TargetControlID="txtInquiryNo">
                                </asp:MaskedEditExtender>--%>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo18" runat="server" Font-Size="12px" >Registration Form No <font size="1px" color="red">*</font></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="input-blue" OnTextChanged="txtInquiryNo_TextChanged"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtInquiryNo0_MaskedEditExtender" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="LL/LL/9999/9999"
                                MaskType="None" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtRegistrationNo" />
                        </div>
                        <div class="clearfix">
                        </div>
                  
                               <div class="inquiry-name">
                            <asp:Label ID="Label7" runat="server" Font-Size="12px" Text="Academic Year"></asp:Label></div>
                        <div class="inquiry-field">
                           <asp:DropDownList ID="ddlAcademicYear" runat="server" >
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>  
                            </asp:DropDownList>
                        </div>
                        <div class="clearfix">
                        </div>

                        <div class="inquiry-name">
                            <asp:Label ID="Label1" runat="server" Font-Size="12px" Text="Standard"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:DropDownList ID="drpStandard" runat="server">
                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo0" runat="server" Text="First Name" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtCondidatename" CssClass="formlbl" runat="server" MaxLength="50" ></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtCondidatename"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                         <div class="inquiry-name">
                            <asp:Label ID="Label2" runat="server" Text="Middle Name" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtMiddleName" CssClass="formlbl" runat="server" MaxLength="50" ></asp:TextBox>
                          </div>
                         <div class="inquiry-name">
                            <asp:Label ID="Label3" runat="server" Text="Last Name" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtLastName" CssClass="formlbl" runat="server" MaxLength="50" ></asp:TextBox>
                           </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo15" runat="server" Text="Date Of Birth" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtDOB" CssClass="formlbl" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtDOB"
                                runat="server">
                            </asp:CalendarExtender>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo17" runat="server" Text="Gender" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:DropDownList ID="drpGender" runat="server">
                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo1" runat="server" Text="Telphone No" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtTelNo" CssClass="formlbl" runat="server" MaxLength="12" Width="250px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtTelNo"
                                FilterType="Numbers" runat="server">
                            </asp:FilteredTextBoxExtender>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo2" runat="server" Text="Father name" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtfatherName" CssClass="formlbl" runat="server" MaxLength="50"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtfatherName"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo3" runat="server" Text="Father Mobile" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtFatherMobile" CssClass="formlbl" runat="server" MaxLength="250"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtFatherMobile"
                                FilterType="Numbers" runat="server">
                            </asp:FilteredTextBoxExtender>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo4" runat="server" Text="Father Email" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtFatherEmail" CssClass="formlbl" runat="server"></asp:TextBox></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo5" runat="server" Text="Father Occupation" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtFatherOccupation" CssClass="formlbl" runat="server" Width="250px"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtFatherOccupation"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo6" runat="server" Text="Mother name" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtMotherName" CssClass="formlbl" runat="server" MaxLength="50"
                                Width="250px"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtMotherName"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo7" runat="server" Text="Mother Mobile" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtMotherMobile" CssClass="formlbl" runat="server" MaxLength="12"
                                Width="250px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtMotherMobile"
                                FilterType="Numbers" runat="server">
                            </asp:FilteredTextBoxExtender>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo8" runat="server" Text="Mother Email" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtMotherEmail" CssClass="formlbl" runat="server" MaxLength="50"
                                Width="250px"></asp:TextBox></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo9" runat="server" Text="Mother Occupation" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtMotherOccupation" CssClass="formlbl" runat="server" MaxLength="250"
                                Width="250px"></asp:TextBox>
                            <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtMotherOccupation"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo10" runat="server" Text="Address" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtAddress" CssClass="formlbl" runat="server" Height="50px" TextMode="MultiLine"
                                 MaxLength="500"></asp:TextBox></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo11" runat="server" CssClass="formlbl" Text="Pincode" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtPincode" runat="server" MaxLength="7"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtPincode"
                                FilterType="Numbers" runat="server">
                            </asp:FilteredTextBoxExtender>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo12" runat="server" Text="State" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtState" CssClass="formlbl" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtState"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo13" runat="server" Text="City" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtCity" CssClass="formlbl" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtCity"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%></div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo19" runat="server" Font-Size="12px">Amount <font size="1px" color="red">*</font></asp:Label></div>
                        <div class="inquiry-field">
                            <asp:TextBox ID="txtAmount" runat="server" MaxLength="7"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" runat="server"
                                FilterType="Numbers" TargetControlID="txtAmount">
                            </asp:FilteredTextBoxExtender>
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="inquiry-name">
                            <asp:Label ID="lblInquiryNo14" runat="server" Text="Source Of Inquiry" Font-Size="12px"></asp:Label></div>
                        <div class="inquiry-field">
                            <div class="gender">
                                <asp:RadioButton ID="rdbNewspaper" GroupName="source" Text="Newspaper Ads" runat="server"
                                    Font-Size="11px" />
                            </div>
                            <div class="gender">
                                <asp:RadioButton ID="rdbHoarding" GroupName="source" Text="Hoarding" runat="server"
                                    Font-Size="11px" />
                            </div>
                            <div class="gender">
                                <asp:RadioButton ID="rdbStaff" Text="Staff Ref" GroupName="source" runat="server"
                                    Font-Size="11px" />
                            </div>
                            <div class="gender">
                                <asp:RadioButton ID="rdbStudent" Text="Student Ref" GroupName="source" runat="server"
                                    Font-Size="11px" />
                            </div>
                            <div class="gender">
                                <asp:RadioButton ID="rdbleaflet" Text="Leaflet" runat="server" GroupName="source"
                                    Font-Size="11px" />
                            </div>
                            <div class="gender">
                                <asp:RadioButton ID="rdbOther" Text="Other" runat="server" GroupName="source" Font-Size="11px" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <center>
                    <table class="style1">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table class="style3">
                                    <tr>
                                        <td id="Submit" align="left">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" Text="Submit" OnClientClick="return validation();"
                                                OnClick="btnSubmit_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td colspan="2">
                                <div id="divID" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblname" runat="server" Text="Ajay Prajapati"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>--%>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

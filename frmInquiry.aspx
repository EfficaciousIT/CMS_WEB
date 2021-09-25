<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInquiry.aspx.cs" Inherits="frmInquiry"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inquiry Form</title>
    <style type="text/css">
        .style1
        {
            width: 40%;
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
            width: 100%;
        }
        .input-blue
        {
            width: 69%;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 5px;
        }
        .select
        {
            display: block;
            border: 1px solid #3498db;
            width: 30%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .efficacious_send
        {
            width: 60% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
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
        function zoomIn() {
            var Page = document.getElementById('Body');
            var zoom = parseInt(70) + '%'
            alert(zoom);
            Page.style.zoom = zoom;
            return false;
        }
        function zoomOut() {
            var Page = document.getElementById('Body');
            var zoom = parseInt(100) + '%'
            alert(zoom);
            Page.style.zoom = zoom;
            return false;
        }
    </script>

</head>
<body runat="server" id="Body" style="zoom: 100%">
    <form id="form1" runat="server">
    <script type="text/javascript" language="javascript">
        function validation() {

            var txtInquiryNo = document.getElementById("<%=txtInquiryNo.ClientID %>").value;



            var txtCondidatename = document.getElementById("<%=txtCondidatename.ClientID %>").value;

            var txtDOB = document.getElementById("<%=txtDOB.ClientID %>").value;            

            var txtfatherName = document.getElementById("<%=txtfatherName.ClientID %>").value;

            var txtFatherMobile = document.getElementById("<%=txtFatherMobile.ClientID %>").value;



            var drpStandard = document.getElementById("<%=drpStandard.ClientID %>").value;

            if (txtInquiryNo == '') {

                alert('Please provide Enquiry number');
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

            if (txtDOB == '') {

                alert('Please provide date of birth');
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



            return true;

        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlPerson" runat="server">
                <div>
                    <center>
                        <table class="style1">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 80px">
                                    <asp:Label ID="lblInquiry" runat="server" Text="Inquiry Form"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" align="left">
                                    <asp:Label ID="lblInquiryNo" runat="server" Text="Inquiry No" Font-Size="12px"></asp:Label>
                                    &nbsp;<asp:Label ID="Label1" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>
                                </td>
                                <td class="style2" align="left">
                                    <asp:TextBox ID="txtInquiryNo" runat="server" CssClass="input-blue"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style2">
                                    <asp:Label ID="lblInquiryNo18" runat="server" Font-Size="12px" Text="Standard"></asp:Label>
                                    &nbsp;<asp:Label ID="Label2" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left" class="style2">
                                    <asp:DropDownList ID="drpStandard" runat="server" CssClass="select">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo0" runat="server" Text="Candidate full name" Font-Size="12px"></asp:Label>
                                    &nbsp;<asp:Label ID="Label3" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCondidatename" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="250px"></asp:TextBox>
                                    <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtCondidatename"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo15" runat="server" Text="Date Of Birth" Font-Size="12px"></asp:Label>
                                    &nbsp;<asp:Label ID="Label4" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDOB" CssClass="input-blue" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtDOB"
                                        runat="server">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo17" runat="server" Text="Gender" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpGender" runat="server" CssClass="select">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo1" runat="server" Text="Telphone No" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTelNo" CssClass="input-blue" runat="server" MaxLength="12" Width="250px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtTelNo"
                                        FilterType="Numbers" runat="server">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo2" runat="server" Text="Father name" Font-Size="12px"></asp:Label>
                                    &nbsp;<asp:Label ID="Label5" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfatherName" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="250px"></asp:TextBox>
                                    <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtfatherName"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo3" runat="server" Text="Father Mobile" Font-Size="12px"></asp:Label>
                                    &nbsp;<asp:Label ID="Label6" ForeColor="Red" runat="server" Text="*" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFatherMobile" CssClass="input-blue" runat="server" MaxLength="250"
                                        Width="250px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtFatherMobile"
                                        FilterType="Numbers" runat="server">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo4" runat="server" Text="Father Email" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFatherEmail" CssClass="input-blue" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo5" runat="server" Text="Father Occupation" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFatherOccupation" CssClass="input-blue" runat="server" Width="250px"></asp:TextBox>
                                    <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtFatherOccupation"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo6" runat="server" Text="Mother name" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherName" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="250px"></asp:TextBox>
                                    <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtMotherName"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo7" runat="server" Text="Mother Mobile" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherMobile" CssClass="input-blue" runat="server" MaxLength="12"
                                        Width="250px"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtMotherMobile"
                                        FilterType="Numbers" runat="server">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo8" runat="server" Text="Mother Email" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherEmail" CssClass="input-blue" runat="server" MaxLength="50"
                                        Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo9" runat="server" Text="Mother Occupation" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMotherOccupation" CssClass="input-blue" runat="server" MaxLength="250"
                                        Width="250px"></asp:TextBox>
                                    <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtMotherOccupation"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo10" runat="server" Text="Address" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAddress" CssClass="input-blue" runat="server" Height="50px" TextMode="MultiLine"
                                        MaxLength="500"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo11" runat="server"  Text="Pincode" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPincode" runat="server" MaxLength="7" CssClass="input-blue"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtPincode"
                                        FilterType="Numbers" runat="server">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo12" runat="server" Text="State" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtState" CssClass="input-blue" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
                                    <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtState"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo13" runat="server" Text="City" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCity" CssClass="input-blue" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
                                    <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtCity"
                            FilterType="Custom" ValidChars=" ,LowercaseLetters,UppercaseLetters" runat="server">
                        </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo14" runat="server" Text="Source Of Inquiry" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rdbNewspaper" GroupName="source" Text="Newspaper Ads" runat="server"
                                                    Font-Size="11px" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbHoarding" GroupName="source" Text="Hoarding" runat="server"
                                                    Font-Size="11px" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbFM" Text="FM" GroupName="source" runat="server" Font-Size="11px" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rdbStaff" Text="Staff Ref" GroupName="source" runat="server"
                                                    Font-Size="11px" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbStudent" Text="Student Ref" GroupName="source" runat="server"
                                                    Font-Size="11px" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbleaflet" Text="Leaflet" runat="server" GroupName="source"
                                                    Font-Size="11px" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbOther" Text="Other" runat="server" GroupName="source" Font-Size="11px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblInquiryNo16" runat="server" Text="Remark" Font-Size="12px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRemark" CssClass="input-blue" runat="server" Height="50px" TextMode="MultiLine"
                                        MaxLength="500"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <table class="style3">
                                        <tr>
                                            <td id="Submit" align="left">
                                                <asp:Button ID="btnSubmit" runat="server" OnClientClick="return validation();" CssClass="efficacious_send" Text="Submit" OnClick="btnSubmit_Click1" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

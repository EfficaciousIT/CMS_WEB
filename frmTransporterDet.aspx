<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-gb" CodeFile="frmTransporterDet.aspx.cs" Inherits="frmTransporterDet"
    Title="Transporter Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            height: 32px;
            width: 74px;
        }
        .style4
        {
            height: 35px;
        }
        .style5
        {
            width: 120px;
        }
        .style6
        {
            height: 35px;
            width: 120px;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        .textsize {
            font-family: Verdana;
            font-size: 12px;
            margin-left: -12px;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function checkdate(input) {
            var validformat = /^\d{1,2}(\-|\/|\.)\d{1,2}\1\d{4}$/ //Basic check for format validity
            var returnval = true;
            if (input.value == '' || !validformat.test(input.value)) {
                alert("Invalid Date Format. Please correct and submit again.")
                var returnval = false;
            }
            return returnval
        }
        function CheckDates(strdate, enddate) {

            var sd = strdate.slice(3, [5]);
            var ed = enddate.slice(3, [5]);
            var sm = strdate.slice(0, [2]);
            var em = enddate.slice(0, [2]);
            var sy = strdate.slice(6, [11]);
            var ey = enddate.slice(6, [11]);
            var start = new Date();
            start.setFullYear(sy);
            start.setMonth(sm);
            start.setDate(sd);
            var end = new Date();
            end.setFullYear(ey);
            end.setMonth(em);
            end.setDate(ed);
            var oneDay = 1000 * 60 * 60 * 24;
            var difMilli = Math.ceil(end.getTime() - start.getTime());
            var diff = Math.round(difMilli / oneDay);
            if (diff < 0) {

                alert("Invalid Date");

                return false;

            }
            else {
                return true;
            }

        }
        function confirm() {


            var fromdate, todate, dt1, dt2, mon1, mon2, yr1, yr2, date1, date2;
            //            var chkFrom = document.getElementById('<%= txtContractFrmDt.ClientID %>').value;
            //            
            //            var chkTo = document.getElementById('<%= txtContractToDate.ClientID %>').value;
            //            alert('Inside');

           
            var txtTel_1 = document.getElementById('<%=txtTel_1.ClientID %>').value;
            //alert(txtTel_1.length);
            if (txtTel_1 != '' && txtTel_1.length < 7) {
                alert('Please provide valid Telephone 1 No');
                return false;
            }


            var txtTel_2 = document.getElementById('<%=txtTel_2.ClientID %>').value;

            if (txtTel_2 != '' && txtTel_2.length < 7) {
                alert('Please provide valid Telephone 2 No');
                return false;
            }

            var txtTranspoterName = document.getElementById('<%=txtTranspoterName.ClientID %>').value;

            if (txtTranspoterName.length < 1) {
                alert('Please provide Transporter');
                return false;
            }
            var txtContactPerson = document.getElementById('<%=txtContactPerson.ClientID %>').value;

            if (txtContactPerson.length < 1) {
                alert('Please provide Contact Person');
                return false;
            }
            var txtMob = document.getElementById('<%=txtMob.ClientID %>').value;
            if (txtMob.length < 10) {
                alert('Please provide valid mobile no');
                return false;
            }


            var obj = document.getElementById('<%= txtEmail.ClientID %>');
            var regex = /^[a-zA-Z0-9._-]+@([a-zA-Z0-9.-]+\.)+[a-zA-Z0-9.-]{2,4}$/;
            if (obj != '' && regex.test(obj.value)) {
                //You can also assign stylesheet by
                //obj.className='....';

                return true;
            }
            else {
                //Changing Background Color, so that user can understand that its invalid
                //You can also assign stylesheet by
                //obj.className='....';
                //CheckDates(chkFrom, chkTo);
                alert('Please provide valid email id')

                return false;
            }



            var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;

            var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
            if (btn == 'Submit') {
                var save = confirm('Do You Really Want Save Record?');
                if (save) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                var save = confirm('Do You Really Want Update Record?');
                if (save) {

                    return true;
                }
                else {
                    return false;
                }
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Transporter
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Transporter</a></li>
            <li class="active">Transporter</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                            Width="1015px" Height="375px">
                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    Transporter Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvTransport" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="100%" OnRowEditing="grvTransport_RowEditing" OnRowDeleting="grvTransport_RowDeleting"
                                                        AllowPaging="True" OnPageIndexChanging="grvTransport_PageIndexChanging">
                                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                        <Columns>
                                                         <asp:BoundField DataField="vchTransporter_name" HeaderText="Transporter Name" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchContact_Person" HeaderText="Contact Person" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="numTelNo1" HeaderText="Telephone" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="numMobileNo" HeaderText="Mobile" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtContractStartDate" HeaderText="Start Date" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtContractEndDate" HeaderText="End Date" ReadOnly="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTransId" runat="server" Text='<%#Eval("intTransporter_id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" CausesValidation="false"
                                                                        ImageUrl="~/images/edit.png" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" CausesValidation="false"
                                                                        ImageUrl="~/images/delete.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="efficacious">
                                            <table width="60%">
                                                <tr>
                                                    <td align="left" class="style6" style="padding-right: 100px">
                                                        <asp:Label ID="lblTransportName" runat="server" CssClass="textsize">Transporter <font size="1px" color="red">*</font></asp:Label>
                                                        
                                                    </td>
                                                    <td align="left" width="230" colspan="3">
                                                        <asp:TextBox ID="txtTranspoterName" runat="server" MaxLength="20" ForeColor="Black"
                                                            ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtTranspoterName"
                                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1TransName" runat="server" ErrorMessage="Please Enter Transpoter Name"
                                                            ControlToValidate="txtTranspoterName" Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1TransName"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style6">
                                                        <asp:Label ID="lblContactPerson" runat="server" CssClass="textsize">Contact Person <font size="1px" color="red">*</font></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtContactPerson" runat="server" MaxLength="20" ForeColor="Black"
                                                            ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtContactPerson"
                                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2ContactPerson" runat="server" ErrorMessage="Please Enter Contact Person Name"
                                                            ControlToValidate="txtContactPerson" Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2ContactPerson"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style6">
                                                        <asp:Label ID="lblTel_1" runat="server" Text="Telephone 1" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtTel_1" runat="server" MaxLength="10" ForeColor="Black" ValidationGroup="b"
                                                            CssClass="input-blue"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTel_1"
                                                            FilterType="Custom, Numbers" ValidChars="-" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style6">
                                                        <asp:Label ID="lblTel_2" runat="server" Text="Telephone 2" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtTel_2" runat="server" MaxLength="10" ForeColor="Black" ValidationGroup="b"
                                                            CssClass="input-blue"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtTel_2"
                                                            FilterType="Custom, Numbers" ValidChars="-" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style6">
                                                        <asp:Label ID="lblMob" runat="server" CssClass="textsize">Mobile No <font size="1px" color="red">*</font></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtMob" runat="server" MaxLength="10" ForeColor="Black" ValidationGroup="b"
                                                            CssClass="input-blue"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Mobile Number"
                                                            ControlToValidate="txtMob" Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMob"
                                                            FilterType="Numbers" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEmail" runat="server" Text="Email ID" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" ForeColor="Black" ValidationGroup="b"
                                                            CssClass="input-blue"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ControlToValidate="txtEmail" Display="None" ValidationGroup="p1" ErrorMessage="Invalid Email Format"
                                                                Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                                </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblContractFrmDt" runat="server"  CssClass="textsize">Contract Date <font size="1px" color="red">*</font></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtContractFrmDt" runat="server" MaxLength="20" Style="width: 95%;"
                                                            ForeColor="Black" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
                                                             <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtContractFrmDt"
                                                            Format="dd/MM/yyyy" Enabled="True">
                                                        </asp:CalendarExtender>

                                                              <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtContractFrmDt"
                                                               WatermarkText="From Date" Enabled="True">
                                                               </asp:TextBoxWatermarkExtender>
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter From Date"
                                                               Display="None" ControlToValidate="txtContractFrmDt" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                              ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>


                                                       
                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter From Date"
                                                            ControlToValidate="txtContractFrmDt" Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="From Date"
                                                            TargetControlID="txtContractFrmDt" runat="server" Enabled="True">
                                                        </asp:TextBoxWatermarkExtender>--%>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtContractToDate" runat="server" CssClass="input-blue" Style="width: 94% !important;
                                                            float: left; margin-left: 6%;" ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtContractToDate"
                                                            Format="dd/MM/yyyy" Enabled="True">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter To Date"
                                                            ControlToValidate="txtContractToDate" Display="None" CssClass="textsize"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator6"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" WatermarkText="To Date"
                                                            TargetControlID="txtContractToDate" runat="server" Enabled="True">
                                                        </asp:TextBoxWatermarkExtender>
                                                        <asp:CompareValidator ID="ComV1" runat="server" ValidationGroup="a" Operator="GreaterThan"
                                                            Type="Date" Display="None" ControlToValidate="txtContractToDate" ControlToCompare="txtContractFrmDt"
                                                            ErrorMessage="Invalid Date. To date should be greater then from date"></asp:CompareValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="ComV1"
                                                            Enabled="True">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr valign="bottom">
                                                    <td align="center" class="style6">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="Button2_Click"
                                                                        OnClientClick="return  confirm();" Text="Submit" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="Button1" runat="server" CssClass="efficacious_send" CausesValidation="false"
                                                                        OnClick="Button1_Click" Text="Cancel" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style6">
                                                        &#160;&nbsp;
                                                    </td>
                                                    <td colspan="3">
                                                        &#160;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

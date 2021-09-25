<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-GB" CodeFile="frmFeesAssignMst.aspx.cs" Inherits="frmFeesAssignMst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious textarea
        {
            width: 97% !important;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .efficacious input[type=checkbox] + label {
            display: block;
            /* width: auto !important; */
            /* height: auto !important; */
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            /* background: white !important; */
            vertical-align: middle;
            line-height: 1em;
            /* font-size: 14px; */
            /* color: #000; */
            padding: 1px 0px;
            text-align: center;
            width: 30px;
            /* height: 50px; */
            margin-top: 3px;
        }
    </style>
    <script language="javascript" type="text/javascript">
//        function confirm() {
//            if (Page_ClientValidate() == false) {
//                return false;
//            }
//            else {

//                var atLeast = 1;
//                var count = 0;
//                var chkLst = document.getElementById('<%=chkSTD.ClientID %>');
//                var chk = chkLst.getElementsByTagName("input");
//                for (var i = 0; i < chk.length; i++) {
//                    if (chk[i].checked) {
//                        count++;
//                    }
//                }
//                if (atLeast > count) {
//                    alert('Please Select Atleast One Standard');
//                    return false;
//                }
//                //ConfMsg();

//            }
//        }

        function ConfMsg() {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {

                if (confirm('Do You Really Want To Save Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (confirm('Do You Really Want To Update Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
     <script type="text/javascript">
         var prm = Sys.WebForms.PageRequestManager.getInstance();
         //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
         prm.add_beginRequest(BeginRequestHandler);
         // Raised after an asynchronous postback is finished and control has been returned to the browser.
         prm.add_endRequest(EndRequestHandler);
         function BeginRequestHandler(sender, args) {
             //Shows the modal popup - the update progress
             var popup = $find('<%= modalPopup.ClientID %>');
             if (popup != null) {
                 popup.show();
             }
         }

         function EndRequestHandler(sender, args) {
             //Hide the modal popup - the update progress
             var popup = $find('<%= modalPopup.ClientID %>');
             if (popup != null) {
                 popup.hide();
             }
         }
    </script>
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Fee Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmDurationMaster.aspx">Duration Master</a></li>
             <li><a href="frmYearlyMaster.aspx">Yearly Master</a></li>
            <li><a href="frmHalfYearlyMaster.aspx">Half Yearly Master</a></li>
            <li><a href="frmQuartarlyMaster.aspx">Quarterly Master</a></li>
            <li><a href="frmFeeHead.aspx">Fee Head </a></li>
            <li class="active1"><a href="frmFeesAssignMst.aspx">Fee Chart</a></li>
        </ul>
    </div>
<section class="content">
    <div style="padding: 10px 0 0 0">
       
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                    PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="70%">
                                                                    <tr>
                                                                    <td align="center">
                                                                            <asp:Label ID="Label7" runat="server" Text="Academic Year" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpAcademiYear" runat="server"  AutoPostBack="True" 
                                                                                onselectedindexchanged="drpAcademiYear_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label6" runat="server" Text="Standard" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlSTD" runat="server"  OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table" Width="70%" OnRowDataBound="grvDetail_RowDataBound" AllowPaging="True"
                                                                DataKeyNames="intFeeDetId" OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                                                <Columns>
                                                                <asp:TemplateField HeaderText="FeeDetId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFeeDetId") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" ReadOnly="True" />
                                                                    <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                                                                    <asp:BoundField DataField="feetype" HeaderText="Type" ReadOnly="True" />                                                                   
                                                                    <asp:BoundField DataField="FrmDt" HeaderText="Effective From Date" ReadOnly="True"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="ToDt" HeaderText="Effective To Date" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField DataField="vchFeeDesc" HeaderText="Description" ReadOnly="True" Visible="False" />
                                                                   
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="False"
                                                                                ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>
                                                       Total Annual Fee : <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                                    </td>
                                                    </tr>
                                                </table>
                                                </div></center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <div class="efficacious" style="background-color:White;">
                                                    <table width="50%" style="margin-left:2%;">
                                                    <tr>
                                                     <td class="style4" align="left">
                                                                            <asp:Label ID="Label8" runat="server" Text="Academic Year" ></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlAcademiYear" runat="server"  >
                                                                            </asp:DropDownList>
                                                                        </td>
                                                    </tr>
                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label1" runat="server"  Text="Particulars "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlParticular" runat="server"  OnSelectedIndexChanged="ddlParticular_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="ddlParticular"
                                                                     Display="None" ErrorMessage="Please Select Valid Particular"
                                                                    InitialValue="0"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="V2"
                                                                        runat="server" Enabled="True" TargetControlID="R1">
                                                                    </asp:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label11" runat="server"  Text="Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtDurationType" runat="server" Width="100%" 
                                                                    CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                                    
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td  class="style5" align="left">
                                                                <asp:Label ID="Label2" runat="server"  Text="Standard"></asp:Label>
                                                            </td>
                                                            <td class="auto-style6" align="left" valign="top">
                                                                 <asp:DropDownList ID="chkSTD" runat="server"                                                                    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label3" runat="server"  Text="Amount"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAmt" runat="server" Width="100%" CssClass="input-blue" MaxLength="7"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="R2" runat="server" ControlToValidate="txtAmt" Display="None" ErrorMessage="Please Enter Amount"
                                                                   ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="V3"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:FilteredTextBoxExtender ID="FT" runat="server" FilterType="Custom, Numbers"
                                                                    ValidChars="." TargetControlID="txtAmt" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr visible="False" runat="server">
                                                            <td class="style5" align="left" runat="server">
                                                                <asp:Label ID="Label4" runat="server"  Text="Effective Date"></asp:Label>
                                                            </td>
                                                            <td width="100%" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left"  width="50%">
                                                                            <asp:TextBox ID="txtFrmDt" runat="server" Style="width: 91%;" ></asp:TextBox><asp:CalendarExtender
                                                                                ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt" Format="dd/MM/yyyy"
                                                                                Enabled="True">
                                                                            </asp:CalendarExtender>
                                                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFrmDt"
                                                                                WatermarkText="From Date" Enabled="True">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                            <asp:RequiredFieldValidator ID="R4" runat="server" ControlToValidate="txtFrmDt" Display="None"
                                                                                ErrorMessage="Please Enter From Date" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="V4" TargetControlID="R4" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                        <td>
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td align="left"  width="70%">
                                                                            <asp:TextBox ID="txtToDt" runat="server" Width="94%" CssClass="input-blue"></asp:TextBox><asp:TextBoxWatermarkExtender
                                                                                ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtToDt" WatermarkText="To Date"
                                                                                Enabled="True">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDt"
                                                                                Format="dd/MM/yyyy" Enabled="True">
                                                                            </asp:CalendarExtender>
                                                                            <asp:CompareValidator ID="CV1" runat="server" Display="None" ControlToValidate="txtToDt"
                                                                                ControlToCompare="txtFrmDt" Type="Date" Operator="GreaterThanEqual" ErrorMessage="From Date Should Be Less Than Or Equal To ToDate"
                                                                                ></asp:CompareValidator><asp:ValidatorCalloutExtender ID="V1"
                                                                                    TargetControlID="CV1" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                            <asp:RequiredFieldValidator ID="R5" runat="server" ControlToValidate="txtToDt" Display="None"
                                                                                ErrorMessage="Please Enter To Date" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="V5" TargetControlID="R5" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr visible="False" runat="server">
                                                            <td class="style6"  align="left" runat="server">
                                                                <asp:Label ID="Label5" runat="server"  Text="Description"></asp:Label>
                                                            </td>
                                                            <td align="left" runat="server">
                                                                <asp:TextBox ID="txtDesc" runat="server" CssClass="input-blue" width="100%" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" OnClick="btnSubmit_Click"
                                                                                Text="Submit" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                            
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
       
    </div>
</section>
</asp:Content>

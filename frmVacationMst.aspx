<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmVacationMst.aspx.cs" Inherits="frmVacationMst"
    Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style3
        {
            height: 24px;
        }
        .auto-style4
        {
            width: 108px;
            height: 24px;
        }
        .auto-style5
        {
            height: 16px;
        }
        .style1
        {
            width: 615px;
        }
        .mGrid
        {
            margin: 0 auto;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious input, form.winner-inside textarea
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 6px 0px 6px 3px !important;
            font-family: Verdana;
            -webkit-border-radius: 0px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            outline: none;
            font-size: 13px;
            text-align: left;
            outline: none;
            margin-top: 10px;
        }
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: gray;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Verdana;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
    <script type="text/javascript">
        function messageConfirm(msg) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(msg)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }

            document.forms[0].reset();
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmDelete() {
            var del = confirm('Do You Really Want To Delete Selected Record?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }


        function ConfirmInsertUpdate() {
            if (Page_ClientValidate()) {
                var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
                if (btn == 'Submit') {
                    var del = confirm('Do You Really Want To Save Entered Record?');
                    if (del) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    var del = confirm('Do You Really Want To Update Entered Record?');
                    if (del) {
                        return true;
                    }
                    else {
                        return false;
                    }

                }
            }
        }

        function CallWindow(DocName) {


            window.open("frmViewDoc.aspx?Path=Documents/Vacation&DocName=" + DocName, "", "height=600,width=800,status=yes,location=no,toolbar=no,menubar=no,scrollbars=yes", "");
            return false;
        }
    </script>
    <script type="text/javascript">
        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
        }

        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
    </head>
    <div class="clearfix">
    </div>
 <div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Calendar <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li> <a href="frmHolidayMst.aspx"> Holiday </a></li>
                  <li class="active1"><a href="frmVacationMst.aspx"> Vacation</a></li>                 
        </ul>
    </div>
<section class="content">
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 5px 0 0 0">
                    <center>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                                Visible="true" ActiveTabIndex="2">
                                                <asp:TabPanel ID="Calendar" runat="server">
                                                    <HeaderTemplate>
                                                        Calendar</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <asp:Calendar ID="CalVacation" runat="server" Font-Names="Tahoma" Height="250px"
                                                                Width="500px" Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full"
                                                                SelectMonthText="»" SelectWeekText="›" CssClass="fc-body myCalendar1" OnDayRender="Calendar1_DayRender" style="width:100% !important;"
                                                                CellPadding="4" OnVisibleMonthChanged="CalVacation_VisibleMonthChanged">
                                                                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                                                <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                                                <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2D3338" />
                                                                <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
                                                                <TodayDayStyle CssClass="myCalendarToday" />
                                                                <SelectorStyle CssClass="myCalendarSelector" />
                                                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                                <TitleStyle CssClass="myCalendarTitle" />
                                                            </asp:Calendar>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                    <HeaderTemplate>
                                                        Detail</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged"
                                                                            Text="All" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="grvDetail" runat="server" AllowPaging="True" AllowSorting="True"
                                                                            AutoGenerateColumns="False" CssClass="table  tabular-table " DataKeyNames="intVacation_id"
                                                                            OnPageIndexChanging="grvDetail_PageIndexChanging" OnRowDataBound="grvDetail_RowDataBound"
                                                                            OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing" PageSize="15"
                                                                            Width="100%" EmptyDataText="No Records Found For Selected Month. Please Check All CheckBox To View All Vacations"
                                                                            OnRowCommand="grvDetail_RowCommand1">
                                                                            <Columns>
                                                                             <asp:TemplateField HeaderText="FilePath" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPath" runat="server" Text='  <%# Eval("vchDocPath")  %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Document">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgView" runat="server" CausesValidation="false" CommandArgument='<%#Bind("vchDocPath") %>'
                                                                                            ImageUrl="~/images/action_success.png" CommandName="Detail" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="intVacation_Type_Id" HeaderText="Vacation Type" ReadOnly="True" />
                                                                                 <asp:BoundField DataField="intRole_Id" HeaderText="Role Type" ReadOnly="True" />
                                                                                <asp:BoundField DataField="vchVacation_name" HeaderText="Name" ReadOnly="True" />
                                                                                <asp:BoundField DataField="dtFromDate" HeaderText="From Date" ReadOnly="True" />
                                                                                <asp:BoundField DataField="dtToDate" HeaderText="To Date" ReadOnly="True" />
                                                                                <asp:BoundField DataField="intNoOfDay" HeaderText="No Of Days" ReadOnly="True" />
                                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblid" runat="server" Text='  <%# Eval("intVacation_id")  %>'></asp:Label></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                             
                                                                                <asp:TemplateField HeaderText="Edit">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                                            ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                  <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                                                            ImageUrl="~/images/delete.png" OnClientClick="return ConfirmDelete();" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        New Entry</HeaderTemplate>
                                                    <ContentTemplate>
                                                       
                                                            <div class="efficacious">
                                                                <table width="50%" style="margin:2% 0 2% 2%;">
                                                                    <tr>
                                                                        <td align="justify" style="width: 20%">
                                                                            <asp:Label ID="Label1" runat="server" Text="Vacation Type" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" colspan="2">
                                                                            <asp:DropDownList ID="ddlVacationType" runat="server" CssClass="textsize">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="Select"
                                                                                ControlToValidate="ddlVacationType" ErrorMessage="Please Select Vacation Type"
                                                                                Display="None" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator3" runat="server"
                                                                                    Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td align="justify" style="width: 20%">
                                                                            <asp:Label ID="Label5" runat="server" Text="Role Type" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" colspan="2">
                                                                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="textsize">                                                                                
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select"
                                                                                ControlToValidate="ddlRole" ErrorMessage="Please Select Role"
                                                                                Display="None" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="ValidatorCalloutExtender5" TargetControlID="RequiredFieldValidator4" runat="server"
                                                                                    Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify">
                                                                            <asp:Label ID="Label2" runat="server" Text="Name" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" colspan="2">
                                                                            <asp:TextBox ID="txtName" runat="server" CssClass="textsize" MaxLength="75"></asp:TextBox><asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Name"
                                                                                Display="None" ControlToValidate="txtName" Font-Names="Verdana" Font-Size="Smaller"
                                                                                CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                                                    runat="server" TargetControlID="RequiredFieldValidator1" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style3">
                                                                            <asp:Label ID="Label3" runat="server" Text="Date" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" width="100%" colspan="2">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtFrmDt" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                                            OnTextChanged="txtFrmDt_TextChanged" MaxLength="10"></asp:TextBox><asp:CalendarExtender
                                                                                                ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt" Format="dd/MM/yyyy"
                                                                                                Enabled="True">
                                                                                            </asp:CalendarExtender>
                                                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFrmDt"
                                                                                            WatermarkText="From Date" Enabled="True">
                                                                                        </asp:TextBoxWatermarkExtender>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter From Date"
                                                                                            Display="None" ControlToValidate="txtFrmDt" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                                ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                                                Enabled="True">
                                                                                            </asp:ValidatorCalloutExtender>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtToDt" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                                            OnTextChanged="txtToDt_TextChanged" MaxLength="10"></asp:TextBox><asp:CalendarExtender
                                                                                                ID="CalendarExtender2" runat="server" TargetControlID="txtToDt" Format="dd/MM/yyyy"
                                                                                                Enabled="True">
                                                                                            </asp:CalendarExtender>
                                                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtToDt"
                                                                                            WatermarkText="To Date" Enabled="True">
                                                                                        </asp:TextBoxWatermarkExtender>
                                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="FromDate Should Be Less Than Or Equal To ToDate"
                                                                                            ControlToCompare="txtFrmDt" Display="None" ControlToValidate="txtToDt" Operator="GreaterThanEqual"
                                                                                            Type="Date" CssClass="textsize"></asp:CompareValidator><asp:ValidatorCalloutExtender
                                                                                                ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator1"
                                                                                                Enabled="True">
                                                                                            </asp:ValidatorCalloutExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify">
                                                                            <asp:Label ID="Label4" runat="server" Text="No Of Days" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" colspan="2">
                                                                            <asp:TextBox ID="txtNoOfdays" runat="server" CssClass="textsize" Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="left">
                                                                            <asp:Label ID="lblDesc" runat="server" CssClass="textcss" Text="Description "></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top" colspan="2" class="style1">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td  width="58%">
                                                                                        <asp:FileUpload ID="FileUp" runat="server" />
                                                                                    </td>
                                                                                    <td width="40%">
                                                                                        <asp:Button ID="btnUpload" CssClass="efficacious_send" Style="Width: 99% !important; margin: auto auto auto 2% !important;"
                                                                                             OnClientClick="GetFileSize();" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMesg" runat="server" Width="100%"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="txtDesc" runat="server" AutoComplete="Off" CssClass="textsize" Height="50px"
                                                                                            MaxLength="200" TextMode="MultiLine" style="width:100%;"></asp:TextBox>
                                                                                        <asp:TextBoxWatermarkExtender ID="txtDesc_TextBoxWatermarkExtender" runat="server"
                                                                                            Enabled="True" TargetControlID="txtDesc" WatermarkText="Enter Description Here">
                                                                                        </asp:TextBoxWatermarkExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <br />
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="top">
                                                                        <td>
                                                                        </td>
                                                                        <td align="left" width="40%">
                                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                                                OnClientClick="return ConfirmInsertUpdate();" CssClass="efficacious_send" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="left" width="60%">
                                                                            <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="efficacious_send"
                                                                                OnClick="btnClear_Click" Text="Clear" style="float:right;" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="auto-style5" colspan="3">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Visible="False" Wrap="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                            </asp:TabContainer>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <%-- <asp:AsyncPostBackTrigger ControlID="TabContainer1$TabPanel1$btnUpload" EventName="Click" />--%>
                                <asp:PostBackTrigger ControlID="TabContainer1$TabPanel1$btnUpload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </center>
                </div>
            </td>
            <td align="right" width="100%" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" Style="position: relative;
                                top: 10px; left: -94px;" ImageUrl="~/images/xlsImg.gif" runat="server" OnClick="ImgXls_Click" />
                        </td>
                        <td align="right" width="100%" valign="top">
                            <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" Style="position: relative;
                                top: 11px; left: -165px;" ImageUrl="~/images/pdfImg.gif" runat="server" OnClick="ImgPdf_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            <div class="word">
                                <asp:ImageButton ID="ImgDoc" CausesValidation="false" ToolTip="Export in DOC" CssClass="export"
                                    Style="position: relative; top: -24px; left: 25px;" ImageUrl="~/images/docImg.gif"
                                    runat="server" OnClick="ImgDoc_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</section>
</asp:Content>

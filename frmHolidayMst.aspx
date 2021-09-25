<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Title="Holiday Master" CodeFile="frmHolidayMst.aspx.cs" Inherits="frmHolidayMst"
    EnableEventValidation="false" Culture="en-gb" %>

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
        .style1 input, form.winner-inside textarea, select {
    display: block;
    border: 1px solid #3498db;
    width: 96% !important;
    margin-left:2% !important;
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
            width: 96%;
            margin-left:2%;
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
    <script type="text/javascript" language="javascript">
        function NoOfDays() {
            //var frmDt = document.getElementById('<=%txtFrmDt.ClientID%>');
            //alert(frmDt);
            //var ToDt = Date.parse(document.getElementById('txtToDt').value);
            //var datediff = ((ToDt - frmDt)/1000*60*60*24).toFixed(0);
            //document.getElementById('txtNoOfdays').value = datediff.value;

            var txtdate1 = document.getElementById('txtFrmDt').value;
            var txtdate2 = document.getElementById('txtToDt').value;
            var date1 = new Date(txtdate1.split('-')[0], txtdate1.split('-')[1] - 1, txtdate1.split('-')[2]);
            var date2 = new Date(txtdate2.split('-')[0], txtdate2.split('-')[1] - 1, txtdate2.split('-')[2]);
            var timediffsec = date2.getTime() - date1.getTime();
            var timediffday = parseInt(timediffsec / (24 * 3600 * 1000));
            document.getElementById('txtNoOfdays').value = timediffday;
        }
    </script>
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
            //            if (Page_ClientValidate()) {
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
            //            }
        }
    </script>
    <script type="text/javascript">
        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
        }

        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
        }
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function GetFileSize() {
            var uploadedFile = document.getElementById("<%=FileUp.ClientID %>");
            var fileSize = uploadedFile.files[0].size;

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
            <li class="active1"> <a href="frmHolidayMst.aspx"> Holiday </a></li>
                  <li><a href="frmVacationMst.aspx"> Vacation</a></li>                 
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
                                                ActiveTabIndex="2">
                                                <asp:TabPanel ID="Calendar" runat="server">
                                                    <HeaderTemplate>
                                                        Calendar</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <asp:Calendar ID="CalHoliday" runat="server" Font-Names="Tahoma" Height="250px" Width="250px"
                                                                Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full" SelectMonthText="»"
                                                                SelectWeekText="›" CssClass="fc-body myCalendar1" OnDayRender="Calendar1_DayRender" style="width:100% !important;"
                                                                CellPadding="4" OnVisibleMonthChanged="CalHoliday_VisibleMonthChanged">
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
                                                            <div id="div1" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged"
                                                                                Text="All" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                CssClass="table  tabular-table" DataKeyNames="intHoliday_id" OnPageIndexChanging="grvDetail_PageIndexChanging"
                                                                                OnRowCommand="grvDetail_RowCommand" OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing"
                                                                                PageSize="20" Width="100%" EmptyDataText="No Records Found For Selected Month. Please Check All CheckBox To View All Holidays">
                                                                                <Columns>
                                                                                <asp:BoundField DataField="intHoliday_Type_Id" HeaderText="Holiday Type" ReadOnly="True">
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="vchHoliday_name" HeaderText="Name" ReadOnly="True">
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="dtFromDate" HeaderText="From Date" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="dtToDate" HeaderText="To Date" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="intNoOfDay" HeaderText="No Of Days" ReadOnly="True" />
                                                                                    <asp:TemplateField HeaderText="Document">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImgView" CommandName="View" OnClientClick="SetTarget();" CausesValidation="false"
                                                                                                runat="server" CommandArgument='<%#Bind("vchDocPath") %>' ImageUrl="~/images/action_success.png" /></ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="intHoliday_id" HeaderText="Id" Visible="False" />
                                                                                  
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
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        New Entry</HeaderTemplate>
                                                    <ContentTemplate>
                                                        
                                                            <div id="divEntry" class="efficacious" runat="server">
                                                                <table width="55%" style="text-align: center; margin:2% 0 2% 2%;">
                                                                    <tr>
                                                                        <td align="center" width="20%">
                                                                            <asp:Label ID="Label1" runat="server" Text="Holiday Type" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" >
                                                                            <asp:DropDownList ID="ddlHolidayType" Style="" runat="server" CssClass="textsize">
                                                                               <%-- <asp:ListItem Text="Select"></asp:ListItem>
                                                                                <asp:ListItem Text="Public"></asp:ListItem>
                                                                                <asp:ListItem Text="Private"></asp:ListItem>
                                                                                <asp:ListItem Text="Bank"></asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Holiday Type"
                                                                                InitialValue="Select" Display="None" CssClass="textsize" ControlToValidate="ddlHolidayType"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator3"
                                                                                    Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" width="100%">
                                                                            <asp:Label ID="Label2" runat="server" Text="Name" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" class="">
                                                                            <asp:TextBox ID="txtName" runat="server" CssClass="textsize" MaxLength="75" AutoComplete="Off"></asp:TextBox><asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Name"
                                                                                Display="None" ControlToValidate="txtName" Font-Names="Verdana" Font-Size="Smaller"
                                                                                CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                                                    runat="server" TargetControlID="RequiredFieldValidator1" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" width="100%" class="auto-style3">
                                                                            <asp:Label ID="Label3" runat="server" Text="Date" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" class="auto-style4 " >
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtFrmDt" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                                            AutoComplete="Off" OnTextChanged="txtFrmDt_TextChanged" MaxLength="10" Style="width: 120%; margin-left:6%;"></asp:TextBox><asp:CalendarExtender
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
                                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Date Should Be Greater Than or Equal Today's Date"
                                                                                            Display="None" ControlToCompare="txtFrmDt" ControlToValidate="TextBox1" Operator="GreaterThan"
                                                                                            CssClass="textsize"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                                                                runat="server" TargetControlID="CompareValidator2" Enabled="True">
                                                                                            </asp:ValidatorCalloutExtender>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtToDt" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                                            OnTextChanged="txtToDt_TextChanged" MaxLength="10" Style="width: 108%; margin-left:30%;" ></asp:TextBox><asp:CalendarExtender
                                                                                                ID="CalendarExtender2" runat="server" TargetControlID="txtToDt" Format="dd/MM/yyyy"
                                                                                                Enabled="True">
                                                                                            </asp:CalendarExtender>
                                                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtToDt"
                                                                                            WatermarkText="To Date" Enabled="True">
                                                                                        </asp:TextBoxWatermarkExtender>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDt"
                                                                                            ErrorMessage="Please Enter To Date" CssClass="textsize" Display="None"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                                ID="ValidatorCalloutExtender6" TargetControlID="RequiredFieldValidator4" runat="server"
                                                                                                Enabled="True">
                                                                                            </asp:ValidatorCalloutExtender>
                                                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator1"
                                                                                            Enabled="True">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ErrorMessage="From Date Should Be Less Than Or Equal To To Date"
                                                                                            ControlToCompare="txtFrmDt" ControlToValidate="txtToDt" Font-Size="Smaller" Type="Date"
                                                                                            Operator="GreaterThanEqual" CssClass="textsize"></asp:CompareValidator>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" width="100%" >
                                                                            <asp:Label ID="Label4" runat="server" Text="No Of Days" CssClass="textcss"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" class="auto-style6 ">
                                                                            <asp:TextBox ID="txtNoOfdays" runat="server" AutoComplete="Off" CssClass="textsize"
                                                                                Enabled="False" AutoPostBack="True"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" width="100%" class="style1" valign="top">
                                                                            <asp:Label ID="lblDesc" runat="server" CssClass="textcss" Text="Description "></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top"  class="style1">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td >
                                                                                        <asp:FileUpload ID="FileUp" runat="server" style="width:50% !important;"/>
                                                                                    </td>
                                                                                     <td width="40%">
                                                                                        <asp:Button ID="btnUpload" CssClass="efficacious_send" style="width:184px !important;margin-left:-184px !important;" OnClientClick="GetFileSize();"
                                                                                            runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMesg" runat="server" Width="100%"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtDesc" runat="server" AutoComplete="Off" CssClass="textsize" Height="80px"
                                                                                            Width="440px" MaxLength="200" TextMode="MultiLine"></asp:TextBox><asp:TextBoxWatermarkExtender
                                                                                                ID="txtDesc_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtDesc"
                                                                                                WatermarkText="Enter Description Here">
                                                                                            </asp:TextBoxWatermarkExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" Visible="False" />
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td align="left" width="50%" dir="rtl" valign="top">
                                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                                                OnClientClick="return ConfirmInsertUpdate();" CssClass="efficacious_send" style="width:50% !important;" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="left" width="50%" dir="rtl" valign="top">
                                                                            <asp:Button ID="btnClear0" runat="server" CausesValidation="False" CssClass="efficacious_send" style="width:184px !important;margin-left:-184px !important;"
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="auto-style5" colspan="3">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
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
                        </td>
                        <td align="right" width="100%" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            <div class="word" stye="width:100px;">
                                <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" CausesValidation="false"
                                    ImageUrl="~/images/xlsImg.gif" runat="server" OnClick="ImgXls_Click" />
                                <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" Style="position: relative;
                                    top: -22px; left: -27px;" CausesValidation="false" ImageUrl="~/images/pdfImg.gif"
                                    runat="server" OnClick="ImgPdf_Click" />
                                <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" Style="position: relative;
                                    top: -43px; left: 25px;" CausesValidation="false" ImageUrl="~/images/docImg.gif"
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

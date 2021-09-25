<%@ Page Title="Training Master" Language="C#" MasterPageFile="~/MasterPage2.master"
    AutoEventWireup="true" CodeFile="frmTraningMst.aspx.cs" Inherits="frmTraningMst"
    Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .InputWidth
        {
            width: 650px;
        }
        
        
        .TextWidth
        {
        }
        
        
        .efficacious input[type="file"] {
  display: block;
  border: 1px solid #3498db;
  width: 100%;
  padding:0;
  font-family: Verdana;
  -webkit-border-radius: 7px;
  -moz-border-radius: 7px;
  border-radius: 7px;
  outline: none;
  font-size: 13px;
  text-align: left;
  outline:none; background:none !important;}

        .style1
        {
            width: 259px;
        }
        .mGrid th{ text-align:center !important; padding-left:5px !important; font-size:13px; width:13.5%;}
        .mGrid td{ padding-left:5px !important;}
    </style>
    <script language="javascript" type="text/javascript">
        var newwindow;
        function popUp(url) {
            newwindow = window.open(url, 'name', 'height=400,width=200');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <script type="text/javascript">
        function checkBoxList1OnCheck(listControlRef) {
            var inputItemArray = listControlRef.getElementsByTagName('chkNameList');

            for (var i = 0; i < inputItemArray.length; i++) {
                var inputItem = inputItemArray[i];

                if (inputItem.checked) {
                    inputItem.parentElement.style.backgroundColor = 'Red';
                }
                else {
                    inputItem.parentElement.style.backgroundColor = 'White';
                }
            }
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
    </script>
    <script type="text/javascript">
        function Confirm() {

            var btnNm = document.getElementById('<%= btnSubmit.ClientID %>').value;

            if (btnNm == 'Submit') {
                var msg = confirm('Do You Want To Save Record ?');
                if (msg) {
                    return true
                }
                else {
                    return false;
                }
            }
            else if (btnNm == 'Update') {
                var msg = confirm('Do You Want To Update Record ?');
                if (msg) {
                    return true
                }
                else {
                    return false;
                }
            }

        }

        function DeleteConfirm() {
            var msg = confirm('Do You Really Want To Delete This Record ?');
            if (msg) {
                return true;
            }
            else {
                return false;
            }
        }

        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
        }

        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <center>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    Visible="true" ActiveTabIndex="2">
                                   
                                    <asp:TabPanel ID="TabPanel2" HeaderText="TabPanel1" runat="server" Visible="true">
                                        <HeaderTemplate>
                                            Calendar </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Calendar ID="CalTraining" runat="server" Font-Names="Tahoma" Height="250px"
                                                                Width="500px" OnSelectionChanged="Calendar1_SelectionChanged" Font-Size="14px"
                                                                NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full" 
                                                                SelectMonthText="»" SelectWeekText="›" CssClass="fc-body CalAttendance" OnDayRender="Calendar1_DayRender"
                                                                CellPadding="4" OnVisibleMonthChanged="CalTraining_VisibleMonthChanged">
                                                                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                                                <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                                                <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2D3338" />
                                                                <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
                                                                <TodayDayStyle CssClass="myCalendarToday" />
                                                                <SelectorStyle CssClass="myCalendarSelector" />
                                                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                                <TitleStyle CssClass="myCalendarTitle" />
                                                            </asp:Calendar>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:TabPanel>

                                     <asp:TabPanel ID="TabPanel3" HeaderText="TabPanel1" runat="server" Visible="true">
                                        <HeaderTemplate>
                                            Tabular</HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="table  tabular-table" PageSize="15" Width="100%" OnRowEditing="grvDetail_RowEditing"
                                                DataKeyNames="intTraining_id" OnRowDeleting="grvDetail_RowDeleting" OnRowCommand="grvDetail_RowCommand"
                                                AllowPaging="True" OnPageIndexChanging="grvDetail_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("intTraining_id") %>'></asp:Label></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" OnClientClick="return DeleteConfirm();"
                                                                ImageUrl="~/images/delete.png" CausesValidation="false" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" ImageUrl="~/images/edit.png"
                                                                CausesValidation="false" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Detail">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDetail" runat="server" CommandName="ImgCall" CommandArgument='<% #Bind("intTraining_id") %>'
                                                                Font-Underline="true" CausesValidation="False" ImageUrl="~/images/traning details.png"
                                                                Height="37px" Width="50px"></asp:ImageButton></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="varTitle" HeaderText="Training Title" ReadOnly="True" />
                                                    <asp:BoundField DataField="varName" HeaderText="Training Name" ReadOnly="True" />
                                                    <asp:BoundField DataField="FrmDt" HeaderText="From Date" ReadOnly="True" />
                                                    <asp:BoundField DataField="ToDt" HeaderText="To Date" ReadOnly="True" />
                                                    <asp:BoundField DataField="STime" HeaderText="Start Time" ReadOnly="True" />
                                                    <asp:BoundField DataField="ETime" HeaderText="End Time" ReadOnly="True" />
                                                    <asp:BoundField DataField="varDesc" HeaderText="Desc" ReadOnly="True" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel1" HeaderText="TabPanel1" runat="server">
                                        <HeaderTemplate>
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UPNewEntry" runat="server">
                                                <ContentTemplate>
                                                    <center>
                                                        <div class="efficacious">
                                                            <table width="50%">
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="Label1" runat="server" Text="Title" CssClass="textcss"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="textsize" AutoComplete="Off"></asp:TextBox><asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Title"
                                                                            ControlToValidate="txtTitle" Display="None" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                                Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td align="left" rowspan="10" valign="top" width="100%">
                                                                        <asp:GridView ID="grvAdd" runat="server" AllowPaging="True" style="position:relative; left:100px;" AllowSorting="True" AutoGenerateColumns="False"
                                                                            CssClass="mGrid" OnPageIndexChanging="grvAdd_PageIndexChanging" OnRowDeleting="grvAdd_RowDeleting"
                                                                            PageSize="7" Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="false" CommandName="Delete"
                                                                                            ImageUrl="~/images/delete.png" Width="60%" /></ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                                                                <asp:BoundField DataField="StudId" HeaderText="StudId" ReadOnly="True" />
                                                                                <asp:BoundField DataField="Type" HeaderText="Type" ReadOnly="True" />
                                                                                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                                <asp:BoundField DataField="STD" HeaderText="STD" ReadOnly="True" />
                                                                                <asp:BoundField DataField="DIV" HeaderText="DIV" ReadOnly="True" />
                                                                                <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="True" />
                                                                                <asp:BoundField DataField="TypeId" HeaderText="TypeId" />
                                                                                <asp:BoundField DataField="DeptId" HeaderText="DeptId" />
                                                                                <asp:BoundField DataField="ParentId" HeaderText="ParentId" />
                                                                                <asp:BoundField DataField="Staffid" HeaderText="Staffid" ReadOnly="True" />
                                                                                <asp:BoundField DataField="STD_ID" HeaderText="STD_ID" />
                                                                                <asp:BoundField DataField="DIV_ID" HeaderText="DIV_ID" ReadOnly="True" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="Label9" runat="server" CssClass="textcss" Text="Name"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2" class="auto-style2">
                                                                        <asp:TextBox ID="txtTrainingName" runat="server" CssClass="textsize" AutoComplete="Off"></asp:TextBox><asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Name"
                                                                            ControlToValidate="txtTrainingName" Display="None" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                                Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="Label2" runat="server" Text="Description" CssClass="textcss"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2" class="auto-style1">
                                                                        <asp:TextBox ID="txtDesc" runat="server" CssClass="textsize" AutoComplete="Off"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="Label5" runat="server" Text="Date" CssClass="textcss"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <asp:TextBox ID="txtFrmDt" runat="server" CssClass="textsize" AutoComplete="Off" style="width:90%;"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFrmDt">
                                                                                    </asp:CalendarExtender>
                                                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                                                        TargetControlID="txtFrmDt" WatermarkText="From Date">
                                                                                    </asp:TextBoxWatermarkExtender>
                                                                                    <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True"
                                                                                        Format="dd/MM/yyyy" TargetControlID="txtToDate">
                                                                                    </asp:CalendarExtender>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter From Date"
                                                                                        Display="None" ControlToValidate="txtFrmDt" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                                                                            Enabled="True">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    &#160;
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:TextBox ID="txtToDate" runat="server" AutoComplete="Off" CssClass="textsize"></asp:TextBox>
                                                                                   
                                                                                    <asp:RequiredFieldValidator
                                                                                        ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtToDate" CssClass="textsize"
                                                                                        Display="None" ErrorMessage="Please Enter To Date"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                                            TargetControlID="RequiredFieldValidator12">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFrmDt"
                                                                                        ControlToValidate="txtToDate" CssClass="textsize" Display="None" ErrorMessage="FromDate Should Be Less Than Or Equal To ToDate"
                                                                                        Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator><asp:ValidatorCalloutExtender
                                                                                            ID="CompareValidator2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                                                            TargetControlID="CompareValidator2">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="Label7" runat="server" Text="Time" CssClass="textcss"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td valign="top" >
                                                                                    <asp:TextBox ID="txtStime" runat="server"  CssClass="textsize" AutoComplete="Off" style="width:90%;"></asp:TextBox><asp:MaskedEditExtender
                                                                                        ID="MaskedEditExtender1" runat="server" AcceptAMPM="True" AutoComplete="true"
                                                                                        AutoCompleteValue="00:00" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                        CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtStime">
                                                                                    </asp:MaskedEditExtender>
                                                                                    <asp:MaskedEditValidator ID="MskFrmTime" Display="None" ControlToValidate="txtStime"
                                                                                        ControlExtender="MaskedEditExtender1" EmptyValueMessage="Please Enter Valid Time"
                                                                                        SetFocusOnError="true" InvalidValueMessage="Please enter a valid time." ErrorMessage="Please Enter Valid Time"
                                                                                        runat="server" CssClass="textsize"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                                                            runat="server" ID="Valid" TargetControlID="MskFrmTime">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkText="Start Time"
                                                                                        TargetControlID="txtStime" Enabled="True">
                                                                                    </asp:TextBoxWatermarkExtender>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    &#160;
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:TextBox ID="txtEtime" runat="server" AutoComplete="Off" CssClass="textsize"></asp:TextBox><asp:MaskedEditExtender
                                                                                        ID="txtEtime_MaskedEditExtender" runat="server" AcceptAMPM="True" AutoComplete="true"
                                                                                        AutoCompleteValue="00:00" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                        CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtEtime">
                                                                                    </asp:MaskedEditExtender>
                                                                                    <asp:MaskedEditValidator ID="MaskedEditValidator1" Display="None" ControlToValidate="txtEtime"
                                                                                        ControlExtender="txtEtime_MaskedEditExtender" InvalidValueMessage="Please enter a valid time."
                                                                                        EmptyValueMessage="Please Enter Valid Time" SetFocusOnError="true" ErrorMessage="Please Enter Valid Time"
                                                                                        runat="server" CssClass="textsize"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                                                            runat="server" ID="ValidatorCalloutExtender4" TargetControlID="MaskedEditValidator1">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                    <asp:TextBoxWatermarkExtender ID="txtEtime_TextBoxWatermarkExtender" runat="server"
                                                                                        Enabled="True" TargetControlID="txtEtime" WatermarkText="End Time">
                                                                                    </asp:TextBoxWatermarkExtender>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEtime"
                                                                                        CssClass="textsize" Display="None" ErrorMessage="Please Enter End Time"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="RequiredFieldValidator13_ValidatorCalloutExtender" runat="server" TargetControlID="RequiredFieldValidator13">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Start Time"
                                                                                        Display="None" ControlToValidate="txtStime" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                            ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RequiredFieldValidator10">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="Label3" runat="server" Text="Audience Type" CssClass="textcss"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        <asp:DropDownList ID="ddlType" runat="server" style="width:105%;" CssClass="textsize" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                                                                            AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="Select" runat="server"
                                                                            ErrorMessage="Please Select Type" ControlToValidate="ddlType" Display="None"
                                                                            CssClass="textcss"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6"
                                                                                runat="server" TargetControlID="RequiredFieldValidator5" Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="lblSTD" runat="server" CssClass="textcss" Text="STD" Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style7" colspan="2">
                                                                        <asp:DropDownList ID="ddlSTD" runat="server" CssClass="textsize" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged"
                                                                            Visible="False" AutoPostBack="True">
                                                                            <asp:ListItem Text="Select"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlSTD"
                                                                            runat="server" InitialValue="0" ErrorMessage="Please Select Standard" Display="None"
                                                                            CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7"
                                                                                runat="server" TargetControlID="RequiredFieldValidator6" Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="lblDiv" runat="server" CssClass="textcss" Text="DIV" Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2" class="auto-style2">
                                                                        <asp:DropDownList ID="ddlDiv" runat="server" CssClass="textsize" OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged"
                                                                            Visible="False" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="0" runat="server"
                                                                            CssClass="textsize" ErrorMessage="Please Select Division" ControlToValidate="ddlDiv"
                                                                            Display="None"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8"
                                                                                TargetControlID="RequiredFieldValidator7" runat="server" Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="lblDept" runat="server" Text="Department" CssClass="textcss" Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2" class="auto-style7">
                                                                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="textsize" Visible="False"
                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select Department"
                                                                            ControlToValidate="ddlDept" Display="None" InitialValue="0" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                ID="ValidatorCalloutExtender9" TargetControlID="RequiredFieldValidator8" runat="server"
                                                                                Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1" valign="top">
                                                                        <asp:Label ID="lblName" runat="server" CssClass="textcss" Visible="False">Student Name</asp:Label><br />
                                                                        <br />
                                                                    </td>
                                                                    <td align="left" colspan="2" class="auto-style7">
                                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                            OnCheckedChanged="chkAll_CheckedChanged" Text="All" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style1">
                                                                        &#160;&#160;
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        <div runat="server" id="divChecklist" style="overflow: scroll; height: 200px;">
                                                                            <asp:CheckBoxList ID="chkNameList" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="chkNameList_SelectedIndexChanged" Width="229px">
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </td>
                                                                    <td align="left" class="auto-style7">
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1">
                                                                        <asp:Label ID="lblPName" runat="server" CssClass="textcss" Visible="False">Parent Name</asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        <asp:TextBox ID="txtPName" runat="server" CssClass="textsize" ReadOnly="True" Visible="False"
                                                                            AutoComplete="Off"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1">
                                                                    </td>
                                                                    <td align="left">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="50%">
                                                                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" CssClass="efficacious_send" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnRemove" runat="server" CommandName="Delete" CssClass="efficacious_send"
                                                                                        OnClick="btnRemove_Click" Text="Remove" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1">
                                                                        &#160;&#160;
                                                                    </td>
                                                                    <td align="left" class="auto-style8" colspan="2">
                                                                        &#160;&#160;
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style1">
                                                                        <asp:Label ID="lblUpload" runat="server" CssClass="textcss" Text="Upload App"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="padding-right: 200px; font-family: Verdana;  width: 79px;">
                                                                        <asp:AsyncFileUpload ID="FileUploadApp" runat="server" CssClass="textsize" FailedValidation="False"
                                                                            Width="80%" OnUploadedComplete="FileUploadApp_UploadedComplete" OnClientUploadError="uploadError"
                                                                            OnClientUploadComplete="uploadComplete" UploaderStyle="Modern" CompleteBackColor="White"
                                                                            ThrobberID="imgLoader" PersistFile="True" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style1">
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" /><asp:Label
                                                                            ID="lblMesg" runat="server" CssClass="textsize"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1">
                                                                        &#160;&#160;
                                                                    </td>
                                                                    <td align="left" colspan="2">
                                                                        &#160;&#160;
                                                                    </td>
                                                                    <td align="left">
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="style1">
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="50%">
                                                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                                                        CausesValidation="false" OnClientClick="return Confirm();" CssClass="efficacious_send" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="efficacious_send"
                                                                                        OnClick="btnCancel_Click" Text="Cancel" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="auto-style1" colspan="3">
                                                                        <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                            OnSelectedIndexChanged="ddlName_SelectedIndexChanged" Visible="False" Width="145px">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlName"
                                                                            CssClass="textsize" Display="None" ErrorMessage="Please Select Name" InitialValue="0"
                                                                            Visible="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10"
                                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9">
                                                                            </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td align="center" class="auto-style1">
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </center>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlSTD" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlDiv" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlName" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>

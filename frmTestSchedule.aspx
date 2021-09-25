<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmTestSchedule.aspx.cs" Inherits="frmTestSchedule" Title="E-SMART's" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 70%;
        }
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            font-weight:normal;
        }
        .style1 input[type=text]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            width: 100% !important;
        }
        .style1 input[type=checkbox]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
            width: 15px !important;
            float: left !important;
        }
        .efficacious_send
        {
            width: 100%;
            background: #9fd727;
            font-size: 16px;
            border: none !important;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            color: #fff;
            padding: 3px;
            cursor: pointer;
            height: 35px;
            float: left;
            text-align: center !important;
        }
        .efficacious_send{width:100px !important}
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .style1 select
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 1px;
            -moz-border-radius: 1px;
            border-radius: 1px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .chk
        {
            display: block;
            border: 1px solid #3498db;
            width: 10px;
            padding: 5px;
            float: left;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            display: block;
            width: 16px;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            outline: 0;
            float: left;
        }
        .efficacious input[type=checklist], input[type=radio]
        {
            display: block;
            width: 16px;
            height: 1.3em;
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            background: black;
            vertical-align: middle;
            line-height: 1em;
            font-size: 14px;
            outline: 0;
            float: left;
        }
        .style1 input[type="radio"] {
    width: 5%;
    margin-top: 0px;
}
    </style>
    <style>
        input[type="image"]
        {
            width: 70% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            Test Schedule
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">Test Schedule</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                                Width="1015px">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Test Schedule</HeaderTemplate>
                                    <ContentTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="position: relative; top: -5px;">
                                                    <asp:Label ID="Label6" runat="server" Text="Academic Year"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpAcademiYear" runat="server"  >
                                                        <asp:ListItem>---select---</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                                <td>
                                                </td>
                                                </tr>
                                            <tr>
                                                <td style="position: relative; top: -5px;">
                                                    <asp:Label ID="lblUserType" runat="server" Text="Standard"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                                        <asp:ListItem>---select---</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: center; position: relative; top: -5px;">
                                                    <asp:Label ID="lblStandard" runat="server" Text="Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDate" runat="server" Width="83px"></asp:TextBox><asp:CalendarExtender
                                                        ID="txtfromdate0_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="txtDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="position: relative; top: -5px;">
                                                    <asp:Label ID="Label14" runat="server" Text="From Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFromTime" runat="server" Width="83px"></asp:TextBox><asp:MaskedEditExtender
                                                        ID="txtMaskedFrmTime" runat="server" AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" AcceptAMPM="True" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtFromTime">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                                <td style="text-align: center; position: relative; top: -5px;">
                                                    <asp:Label ID="Label17" runat="server" Text="To Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtToTime" runat="server" Width="83px"></asp:TextBox><asp:MaskedEditExtender
                                                        ID="MaskedEditExtender1" runat="server" AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" AcceptAMPM="True" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtToTime">
                                                    </asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="position: relative; top: -5px;">
                                                    Interview By
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpInterviewBy" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>---select---</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: center; position: relative; top: -5px;">
                                                    Location
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLocation" runat="server" Width="83px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="position: relative; top: -8px;">
                                                    Candidate Interview
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdbYes" GroupName="grpChild" runat="server" Text="Yes" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdbNo" GroupName="grpChild" runat="server" Text="No" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="position: relative; top: -8px;">
                                                    Candidate Exam
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="chkChildExamYes" GroupName="grpChildExam" runat="server" Text="Yes" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="chkChildExamNo" GroupName="grpChildExam" runat="server" Text="No" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="position: relative; top: -8px;">
                                                    Parent Interview
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdbYes0" GroupName="grpParent" runat="server" Text="Yes" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdbNo0" GroupName="grpParent" runat="server" Text="No" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="3" valign="top">
                                                    <asp:CheckBoxList ID="chkListStudent" runat="server">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="efficacious_send"
                                                        Text="Submit" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Send Intimation</HeaderTemplate>
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="padding-left:70px">
                                                    <table width="80%">
                                                        <tr>
                                                      
                                                            <td style="position: relative; top: -5px;">
                                                                <asp:Label ID="Label7" runat="server" Text="Academic Year"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged"  >
                                                                    <asp:ListItem>---select---</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                          
                                                            <td align="center">
                                                                <asp:Label ID="Label1" runat="server" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:DropDownList ID="drpStandardDet" runat="server" OnSelectedIndexChanged="drpStandardDet_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:DropDownList ID="drpDate" AutoPostBack="True" runat="server" OnSelectedIndexChanged="drpDate_SelectedIndexChanged">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 3px; width: 50px;">
                                                    <asp:GridView ID="grdTestSchedule" EmptyDataText="No Records Found" runat="server"
                                                        AutoGenerateColumns="False" DataKeyNames="intTest_id" CssClass="table  tabular-table" Width="840px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("intTest_id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="father" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfather" runat="server" Text='<%#Eval("vchfathermobile") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="RFNO" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRF" runat="server" Text='<%#Eval("vchRF_no") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCtrl" runat="server" OnCheckedChanged="ChckedChanged" AutoPostBack="true"
                                                                        Style="width: 10px; left: 20px;" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="candiateName" HeaderText="Candidate Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="From Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFromTime" runat="server" Text='<%#Eval("dtfromTime") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="dtToTime" HeaderText="To Time">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="location" HeaderText="Location">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table runat="server" id="Table1">
                                                        <tr runat="server">
                                                            <td runat="server" style="padding-bottom: 0px; padding-left: 100px">
                                                                <asp:Button ID="Button2" runat="server" CssClass="efficacious_send" Text="Send" OnClick="Button2_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table runat="server" id="tblEdit" visible="False">
                                                        <tr runat="server">
                                                            <td style="text-align: center; position: relative; top: -5px;" runat="server">
                                                                <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                                                            </td>
                                                            <td runat="server">
                                                                <asp:TextBox ID="TextBox1" runat="server" Width="83px"></asp:TextBox><asp:CalendarExtender
                                                                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox1">
                                                                </asp:CalendarExtender>
                                                            </td>
                                                            <td style="position: relative; top: -5px;" runat="server">
                                                                <asp:Label ID="Label3" runat="server" Text="From Time"></asp:Label>
                                                            </td>
                                                            <td runat="server">
                                                                <asp:TextBox ID="txtFromTimeEdit" runat="server" Width="83px"></asp:TextBox><asp:MaskedEditExtender
                                                                    ID="MaskedEditExtender2" runat="server" AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" AcceptAMPM="True" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtFromTimeEdit">
                                                                </asp:MaskedEditExtender>
                                                            </td>
                                                            <td style="position: relative; top: -5px;" runat="server">
                                                                <asp:Label ID="Label5" runat="server" Text="To Time"></asp:Label>
                                                            </td>
                                                            <td runat="server">
                                                                <asp:TextBox ID="txtTotimeEdit" runat="server" Width="83px"></asp:TextBox><asp:MaskedEditExtender
                                                                    ID="MaskedEditExtender3" runat="server" AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" AcceptAMPM="True" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTotimeEdit">
                                                                </asp:MaskedEditExtender>
                                                            </td>
                                                            <td style="padding-bottom: 0px; padding-left: 40px" runat="server">
                                                                <asp:Button ID="Button1" runat="server" CssClass="efficacious_send" Text="Submit"
                                                                    OnClick="Button1_Click" />
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
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

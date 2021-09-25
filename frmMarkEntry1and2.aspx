<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmMarkEntry1and2.aspx.cs" Inherits="frmMarkEntry1and2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript">

        // JQUERY ".Class" SELECTOR.
        $(document).ready(function () {

            $("#txtSub1").keypress(function (event) { return isNumber(event) });

            $('#txtSub1').keyup(function () {
            });
        });

        // THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
        function isNumber(evt) {


            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode != 45 && (charCode != 46 ||
                $(this).val().indexOf('.') != -1) && (charCode < 48 || charCode > 57)) {
                return false;
            }
            var currVal = String.fromCharCode(evt.keyCode);
            alert(currVal);
            return true;
        }    
    </script>
   <%-- <script type="text/javascript">
        function forNumeric1(evt) {
            var charCode = evt.keyCode;
            var target = event.target || event.srcElement;
            var id = target.id
            var value = document.getElementById(id).value;

            var MaxMark = document.getElementById('<%=SubMaxMarks.ClientID %>').value;
            value = value + String.fromCharCode(evt.keyCode);

            if (charCode >= 48 && charCode <= 57) {
                if (Number(value) > Number(MaxMark)) {
                    alert('Marks Should Less Than ' + MaxMark);
                    value = 0;
                    return false;
                }
                return true;
            }


            return false;
        }

    </script>--%>
    <style type="text/css">
        .groupOfTexbox
        {
        }
        .efficacious select{ width:61% !important;}
        .mGrid th{text-align="center !important"} 
        .efficacious span{ font-size:13px !important;}
        .input-blue {
            width: 75%  !important;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 30px;
        }
    </style>
    <style type="text/css">
        .watermarked
        {
            background-color: #F7F6F3;
            border: solid 1px #808080;
            padding: 3px;
            color: Gray;
        }
        
        .unwatermarked
        {
            border: solid 1px #808080;
            padding: 3px;
            color: Black;
        }
  .efficacious_send{      /* background: #3498db !important; */
       width:50% !important;                         
        border: none !important;
        font-size: 16px;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 2px;
        color: #fff;
        margin: 7px 5px 7px 0;
        padding: 3px;
        cursor: pointer;
        height: 28px !important;
        float: left;
        text-align: center !important;       }
        
.left{  float:left;     float: left;    width: 100%;    background-color: white;    padding: 13px 0px; }      
.markslist-table{   width:100%;     table-layout: fixed }
.markslist-table tr th{ text-align: center; vertical-align: inherit;    width: 140px;}
.markslist-table tr th:nth-child(1){   }
  
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="content"> 
        <div class="row">
            <%--<section class="col-md-12 col-xs-12">
                <div class="box box-orange">--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" ActiveTabIndex="0" CssClass="MyTabStyle" ID="MainTab"
                    Width="100%">
                     <asp:TabPanel runat="server" ID="tb2" HeaderText="All Entries">
                        <ContentTemplate>
                            <div class="form-horizontal" style="margin-top:15px;">
                                <div class="col-md-12">
                                    <div class="row">
                                    <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="lblSTD1" runat="server" Text="Standard" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                         <asp:DropDownList ID="ddlSTD1" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlSTD1_SelectedIndexChanged" CssClass="form-control">
                                                            <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            
                                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                          </div>      
                                    </div>
                                    </div>  <!-- col-3-->
                                    <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="lblDIV1" runat="server" Text="Section" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                          <asp:DropDownList ID="ddlDIV1" runat="server" AutoPostBack="True" CssClass="form-control"
                                                                OnSelectedIndexChanged="ddlDiv1_SelectedIndexChanged">
                                                             <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            

                                                            </asp:DropDownList>

                                                         <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                        </div>
                                    </div>
                                    </div>  <!-- col-3-->
                                    <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="Label2" runat="server" Text="Gender" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                          <asp:DropDownList ID="ddlGender" runat="server"  CssClass="form-control "
                                                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    <asp:ListItem  Value="2">Female</asp:ListItem>
                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                </asp:DropDownList>

                                                <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                        </div>
                                    </div>
                                    </div>  <!-- col-3-->
                                    
                                     <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="Label4" runat="server" Text="Examination" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                          <asp:DropDownList ID="ddlExam1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam1_SelectedIndexChanged"  CssClass="form-control ">
                                                            </asp:DropDownList>
                                        </div>
                                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                    </div>
                                    </div>  <!-- col-3-->
                                    <%--<div class="col-md-4">
                                    <div class="form-group">
                                       <asp:Label ID="Label3" runat="server" Text="Declare Date-Time" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-6 p-rl5">
                                       <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True"  CssClass="form-control" style="margin-top:10px;"></asp:TextBox>
                                           <asp:CalendarExtender ID="calDate" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate" 
                                                                Enabled="True">
                                                            </asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Date For Result Declaration"
                                                                Display="None" ControlToValidate="txtDate" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RequiredFieldValidator10"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                        </div>
                                         <div class="col-md-6 p-rl5">
                                             <asp:HiddenField ID="SubMaxMarks" runat="server" Value="0" />
                                         <asp:TextBox ID="txtTime" runat="server" CssClass="form-control"  style="margin-top:10px;"></asp:TextBox>
                                             <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="True"  
                                                                AutoCompleteValue="00:00" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTime">
                                                            </asp:MaskedEditExtender>
                                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" Display="None" ControlToValidate="txtTime" 
                                                                ControlExtender="MaskedEditExtender1" InvalidValueMessage="Please enter a valid time."
                                                                EmptyValueMessage="Please Enter Valid Time" SetFocusOnError="True" ErrorMessage="Please Enter Valid Time"
                                                                runat="server" CssClass="textsize"></asp:MaskedEditValidator>
                                                            <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender4" TargetControlID="MaskedEditValidator1"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Time For Result Declaration"
                                                                Display="None" ControlToValidate="txtTime" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                    </div>--%>  


                                    </div>  <!-- ROW-->
                                </div>
                            </div>
                               
                                  
                                                <table width="100%">
                                                    <tr>
                                                        <td id="trStudent" runat="server" visible="False">
                                                            <asp:Label ID="lblStudentName" runat="server" Text="Student Name" Visible="False"></asp:Label>
                                                        </td>
                                                        <td width="73%" colspan="3">
                                                            <asp:DropDownList ID="ddlStud" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"
                                                                Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>                                               
                                                </table>
<asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1250px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Subject</HeaderTemplate>

                                         <ContentTemplate>   
                                    <div id="div4" runat="server" style="overflow: scroll; height: 600px;">
                                        <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView9_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>English Activity</HeaderTemplate>

                                         <ContentTemplate>   
                                    <div id="div2" runat="server" style="overflow: scroll; height: 600px;">
                                        <asp:GridView ID="grvMarks" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="grvMarks_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>English Reader</HeaderTemplate>

                                         <ContentTemplate>
                                         <div id="div1" runat="server" style="overflow: scroll; height: 600px;">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView1_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                          </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Number Work</HeaderTemplate>

                                         <ContentTemplate>
                                         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="grvMarks_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Second Language Hindi</HeaderTemplate>

                                         <ContentTemplate>
                                         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="grvMarks_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel12" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Second Language Bengali</HeaderTemplate>

                                         <ContentTemplate>
                                         <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView7_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>EVS</HeaderTemplate>
                                <ContentTemplate>
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView4_RowDataBound" Width="70%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" Width="50px" />
                                                    <ItemStyle HorizontalAlign="left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </ContentTemplate>
                                         
                                         </asp:TabPanel>

                                         <asp:TabPanel ID="TabPanel11" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Computer</HeaderTemplate>
                                <ContentTemplate>
                                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView10_RowDataBound" Width="70%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" Width="50px" />
                                                    <ItemStyle HorizontalAlign="left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </ContentTemplate>
                                         
                                         </asp:TabPanel>

                                         <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Skill Mark</HeaderTemplate>

                                         <ContentTemplate>
                                         <div id="div3" runat="server" style="overflow: scroll; height: 600px;">
                                        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView8_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                          </ContentTemplate>
                                    </asp:TabPanel>

                                         <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Work Habit</HeaderTemplate>

                                         <ContentTemplate>
                                         <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView5_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Personal & Social Traits</HeaderTemplate>

                                         <ContentTemplate>
                                         <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView6_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                    </asp:TabPanel>

                                    <asp:TabPanel ID="TabPanel13" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>Area and Remark Entry</HeaderTemplate>
                                <ContentTemplate>
                                <asp:GridView ID="GridView13" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table markslist-table"
                                            EnableViewState="False" OnRowDataBound="GridView13_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                       <asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub13">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub13" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub14">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub14" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub15">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub15" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sub16">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub16" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </ContentTemplate>
                                         
                                         </asp:TabPanel>

                                    </asp:TabContainer>

                                    

                                    <div class="left">
                                    <div class="col-md-4"">
                                             <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-success col-md-5" style="margin-right:5px;" Text="Submit"
                                                    Visible="False" OnClick="btnSubmit1_Click"/>

                                                <asp:Button ID="btnClear1" CssClass="btn btn-primary col-md-5" runat="server" Text="Clear"
                                                    Visible="False" OnClick="btnClear1_Click"/>                                         
                                     </div>
                                     </div>
                                      
                               
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" ID="TabPanel1" HeaderText="View Details" Visible="false">
                        <ContentTemplate>
                            <div class="efficacious">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                             <iframe id="frame1" style="border:none;height:576px; width:100%" src="ResultStudent.aspx" scrolling="auto" runat="server" ></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" ID="tb3" HeaderText="View Details" Visible="false">
                        <ContentTemplate>
                            <div class="efficacious">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <table width="50%">
                                                <tr>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="lblSTD2" runat="server" Text="STD"></asp:Label></div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlSTD2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="lblDIV2" runat="server" Text="DIV"></asp:Label></div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlDIV2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDIV2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="lblStud" runat="server" Text="Student Name"></asp:Label></div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlStudent2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="Label8" runat="server" Style="padding-right: 0 !important; margin-right: 0 !important;"
                                                                    Text="Examination"></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlExam2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 20px">
                                                        <asp:Label ID="lblGetName" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td colspan="2" align="right">
                                                        <asp:LinkButton ID="btnView" runat="server" OnClick="btnView_Click" Visible="False">View</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div id="divMarksHeader" runat="server">
                                                        </div>
                                                        <div id="divMarks" runat="server" style="overflow: none; height: 300px">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                   
                    <asp:TabPanel runat="server" Visible="false" ID="tbl1" HeaderText="Entry">
                        <ContentTemplate>
                            <center>
                                <br />
                                <div class="efficacious">
                                    <table width="50%">
                                        <tr>
                                            <td align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="padding-left: 2px">
                                                            <asp:Label ID="lblStd" runat="server" Text="STD"></asp:Label>
                                                        </td>
                                                        <td style="padding-left: 16px">
                                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding-left: 25px">
                                                            <asp:Label ID="lblDIV" runat="server" Text="DIV"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDiv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblStudent" runat="server" Text="Student Name"></asp:Label>
                                                        </td>
                                                        <td width="73%">
                                                            <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblExam" runat="server" Text="Examination"></asp:Label>
                                                        </td>
                                                        <td width="73%">
                                                            <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td width="73%">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divTable" class="efficacious" runat="server">
                                    </div>
                                    <div class="col-md-6">
                                             <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send col-md-6" Text="Submit"
                                                    Visible="False" />

                                                <asp:Button ID="btnClear" CssClass="efficacious_send col-md-6" runat="server" Text="Clear"
                                                    Visible="False" />                                         
                                     </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
   

   <%-- </div>
            </section>--%>
            
        </div>
    </section>
</asp:Content>


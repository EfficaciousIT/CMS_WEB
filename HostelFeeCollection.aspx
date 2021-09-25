<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HostelFeeCollection.aspx.cs" Inherits="HostelFeeCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script language="javascript">
     function checkvalidation() {
         var txtpaidAmount = document.getElementById("<%#txtpaidAmount.ClientID %>").value;
         if (txtpaidAmount == '') {
             alert('Paid amount should not be blank.');
             return false;
         }
     }
    </script>
    <style type="text/css">
        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .selectName
        {
            width: 200px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .search
        {
            border: 1px solid green !important;
            padding: 3px;
        }
        .efficacious_Submit
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 130% !important;
            background: #3498db;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
            top: -6px;
        }
         .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .lalfont
        {
            font-family: Verdana;
            font-size: 12px;
        }
        .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 1px #525252;
            border-collapse: collapse;
            font: 12px Verdana, Helvetica, sans-serif;
        }
        *
        {
            margin: 0;
            padding: 0;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            text-align: center;
            background: #3498db;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
            height: 29px;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        a
        {
            text-decoration: none;
        }
        a
        {
            text-decoration: none;
        }
        .style1
        {
            margin: 0 auto;
            padding: 0;
        }
        .style2
        {
            width: 100%;
        }
    </style>
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
     <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>

    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        $(function () {
            $("[id$=txtSearch]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/CS.aspx/GetCustomers") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                $("[id$=txtAdmission]").val(item.split('-')[3]);
                                $("[id$=txtStandard]").val(item.split('-')[2]);
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }

                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Hostel <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li class="active1"><a href="HostelFeeCollection.aspx"> Fee Collection</a></li>
             <li><a href="HostelRoomAllotment.aspx"> Room Allotment</a></li>
             <li><a href="HostelReports.aspx">Hostel Fee</a></li>
                             
        </ul>
    </div>
<section class="content">
<div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 <table class="style1">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label6" CssClass="lalfont" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" CssClass="selectf" Font-Names="Verdana"
                            ForeColor="Black"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label7" CssClass="lalfont" runat="server" Text="Standard"></asp:Label>
                    </td>
                    <td>
                     <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="drpStandard_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                                                            
                    </asp:DropDownList>
                       <%-- <asp:TextBox ID="txtAdmission" runat="server" AutoPostBack="True" CssClass="selectf"
                            Font-Names="Verdana" ForeColor="Black" ></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label8" CssClass="lalfont" runat="server" Text="Division"></asp:Label>
                    </td>
                    <td>
                     <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="drpDivision_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                                                            
                    </asp:DropDownList>
                       <%-- <asp:TextBox ID="txtStandard" runat="server" AutoPostBack="True" CssClass="selectf"
                            Font-Names="Verdana" ForeColor="Black"></asp:TextBox>--%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label9" CssClass="lalfont" runat="server" Text="Student Name"></asp:Label>
                    </td>
                    <td>
                     <asp:DropDownList ID="drpStudent" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="drpStudent_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                                                            
                    </asp:DropDownList>
                        <%--<asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" CssClass="selectName"
                            Font-Names="Verdana" ForeColor="Black"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;&nbsp;
                    </td>
                    <td align="left">
                        <asp:Label ID="Label10" CssClass="lalfont" runat="server" Text="Pay Type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpType" runat="server" AutoPostBack="True" 
                            CssClass="selectf" onselectedindexchanged="drpType_SelectedIndexChanged"
                            >
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Annual" Value="1"></asp:ListItem>
                       <%--     <asp:ListItem Text="Installment" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Multi Installment" Value="3"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr id="MultiInstallment" runat="server" visible="true">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="drpFromMonth" runat="server" AutoPostBack="True" visible="false"
                            CssClass="selectf" >
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblTo" CssClass="lalfont" Visible="false" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpToMonth" runat="server" AutoPostBack="True" Visible="false"
                            CssClass="selectf" >
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Annual" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr id="Tr1" runat="server" visible="true">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left" colspan="5">
                        <table width="100%">
                            <tr>
                                <td style="width: 50%">
                                    <asp:GridView ID="grvDetail" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                        DataKeyNames="HostelFeeId" Width="100%" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="FeeDetId" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("HostelFeeId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="feetype" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfeetype" runat="server" Text='<%#Eval("feetype") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="vchFee" HeaderText="Particulars" ReadOnly="True" />
                                            <asp:BoundField DataField="FeeAmt" HeaderText="Amount" ReadOnly="True" Visible="false" />
                                            <asp:TemplateField HeaderText="Amount" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("FeeAmt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <%--   <asp:TemplateField>
                                                    <ItemTemplate>
                                                         <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true" style="margin-left:10px;"
                                                          OnCheckedChanged = "CheckBox1_CheckedChanged">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                             <asp:CommandField HeaderText="Delete" InsertText="Delete" 
                                                ShowSelectButton="True" Visible="False" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="width: 50%" valign="top">
                                    <table style="padding-top:1px" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" CssClass="lalfont" Text="Late Payment" Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLateAmount" runat="server" AutoPostBack="True" CssClass="selectf" Visible="false"
                                                    Font-Names="Verdana" ForeColor="Black" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" CssClass="lalfont" Text="concession" Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtconcession" runat="server" AutoPostBack="True" CssClass="selectf" Visible="false"
                                                    Font-Names="Verdana" ForeColor="Black" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" CssClass="lalfont" Text="Total Dues "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDues" runat="server" AutoPostBack="True" 
                                                    CssClass="selectf" Font-Names="Verdana" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" CssClass="lalfont" Text="Paid Amount"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpaidAmount" runat="server" AutoPostBack="True" CssClass="selectf" Font-Names="Verdana" ForeColor="Black"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                           &nbsp;
                    </td>
                    <td>
                       &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Label ID="Label13" runat="server" CssClass="lalfont" Text="Pay Mode"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpPayMode" runat="server" AutoPostBack="True" 
                            CssClass="selectf" onselectedindexchanged="drpPayMode_SelectedIndexChanged"
                            >
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Cheque" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left" colspan="5">
                        <table class="style2" visible="false" id="chequeTbl" runat="server">
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" CssClass="lalfont" Text="Cheque No"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChequeNo" runat="server" AutoPostBack="True" CssClass="selectf"
                                        Font-Names="Verdana" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" CssClass="lalfont" Text="Cheque Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChequeDate" runat="server" AutoPostBack="True" CssClass="selectf"
                                        Font-Names="Verdana" ForeColor="Black"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtChequeDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" CssClass="lalfont" Text="Bank"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBankName" runat="server" AutoPostBack="True" CssClass="selectf"
                                        Font-Names="Verdana" ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="Button1" runat="server" CssClass="efficacious_Submit" OnClientClick="return checkvalidation();"
                            Text="Sumbit" onclick="Button1_Click" /> 
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfCustomerId" runat="server" />
                  </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</section>
</asp:Content>


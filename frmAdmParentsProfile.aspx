<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmAdmParentsProfile.aspx.cs" Inherits="frmAdmParentsProfile" Title="Parents Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style type="text/css">
.modalPopup
{
background-color: #696969;
filter: alpha(opacity=40);
opacity: 0.7;
xindex:-1;
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
    <style>
        /* default layout */
        .ajax__tab_default .ajax__tab_header
        {
            white-space: normal !important;
        }
        .ajax__tab_default .ajax__tab_outer
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_inner
        {
            display: -moz-inline-box;
            display: inline-block;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
        }
        /* xp theme */
        .ajax__tab_xp .ajax__tab_header
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 11px;
            background: #fff;
            height: 26px;
        }
        .textcss
        {
            font-size: 13px !important;
        }
        .ajax__tab_xp .ajax__tab_outer
        {
            padding-right: 4px;
            background: #fff;
            height: 25px;
            font-size: 12px;
            padding: 4px 0;
            border: 1px solid #D5D5D5;
            margin-right: 2px;
        }
        .ajax__tab_xp .ajax__tab_inner
        {
            padding-left: 3px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_tab
        {
            height: 20px;
            padding-bottom: 15px;
            padding: 4px;
            margin: 0px;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_outer
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_inner
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_hover .ajax__tab_tab
        {
            cursor: pointer;
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_outer
        {
            background: #fff;
            border-right: 1px solid #3498db;
            border-left: 1px solid #3498db;
            border-top: 1px solid #3498db;
            padding: 5px 0;
            border-radius: 1px 1px 0 0;
            margin-right: 2px;
            height: 26px;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_inner
        {
            background: #fff;
        }
        .ajax__tab_xp .ajax__tab_active .ajax__tab_tab
        {
            background: #fff;
            color: #3498db;
            font-size: 12px;
            font-weight: bold;
            padding-bottom: 15px;
        }
        .ajax__tab_xp .ajax__tab_disabled
        {
            color: #A0A0A0;
        }
        .ajax__tab_xp .ajax__tab_body
        {
            font-family: verdana, tahoma, helvetica;
            font-size: 10pt;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
        /* scrolling */
        .ajax__scroll_horiz
        {
            overflow-x: scroll;
        }
        .ajax__scroll_vert
        {
            overflow-y: scroll;
        }
        .ajax__scroll_both
        {
            overflow: scroll;
        }
        .ajax__scroll_auto
        {
            overflow: auto;
        }
        /* plain theme */
        .ajax__tab_plain .ajax__tab_outer
        {
            text-align: center;
            vertical-align: middle;
            border: 2px solid #999999;
        }
        .ajax__tab_plain .ajax__tab_inner
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_body
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_header
        {
            text-align: center;
            vertical-align: middle;
        }
        .ajax__tab_plain .ajax__tab_active .ajax__tab_outer
        {
            background: #FFF;
        }
        .efficacious_send
        {
            border: none;
            width: 15% !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: -88px;
            text-align: center;
        }
        .textcss
        {
            font-size: 13px !important;
        }
        .btn
        {
            border: none;
            width: 110px !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px 2px;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: left;
            text-align: center;
        }
         .btn1
        {
            border: none;
            width: 190px !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px 2px;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: left;
            text-align: center;
        }
        .element.style
        {
            width: 155px;
            padding: 5px;
            border: 1px solid #3498db;
            border-radius: 2px;
            -webkit-border-radius: 1px;
            -moz-border-radius: 5px;
        }
        .efffield
        {
            display: block;
            border: 1px solid #3498db;
            width: 96%;
            padding: 5px 5px 5px 10px;
            font-family: Verdana;
            outline: none;
            font-size: 13px;
            text-align: left;
            outline: none;
            border-radius: 5px;
            margin-bottom: 5px;
            -webkit-border-radius: 2px;
            -moz-border-radius: 5px;
        }
    </style>
    <asp:UpdatePanel ID="updt5" runat="server">
        <ContentTemplate>
        <div class="content-header">
        <h1>
            Parent
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
             <li><a ><i ></i>School Master</a></li>
            <li class="active">Parent Master</li>
        </ol>
    </div>
            <br />
            <asp:Label ID="ivLab1" runat="server"></asp:Label>
            <br />
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="99%"
                CssClass="MyTabStyle">
                 <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
        <HeaderTemplate>
                            Details
                            </HeaderTemplate>
             

                            <ContentTemplate>
                                            
                                                <table width="95%" style="margin-left:2%;">
                                                 <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbls1" runat="server" Font-Bold="False" Text="Standard : "></asp:Label>                                                    
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlStandrd" runat="server" 
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="ddlStandrd_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>

                                                     <td align="center">
                                                        <asp:Label ID="lbls2" runat="server" Font-Bold="False" Text="Division : "></asp:Label>                                                    
                                                    </td>
                                                    <td align="left" width="20%">
                                                        <asp:DropDownList ID="ddlDiv" runat="server" 
                                                            AutoPostBack="True" onselectedindexchanged="ddlDiv_SelectedIndexChanged" ></asp:DropDownList>
                                                    </td>

                                                     <td align="center">
                                                        <asp:Label ID="lbls3" runat="server" Font-Bold="False" Text="Roll No. : "></asp:Label>                                                    
                                                    </td>
                                                    <td align="left" width="20%">
                                                        <asp:DropDownList ID="ddlRoll" runat="server" 
                                                            AutoPostBack="True" onselectedindexchanged="ddlRoll_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                  </tr>
                                                  </table>
                                                  <table width="95%" style="margin-left:2%;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " Width="100%" 
                                                                DataKeyNames="intParent_id" onrowediting="grvDetails_RowEditing"  >
                                                                <Columns>
                                                                <asp:BoundField DataField="RollNo" HeaderText="Roll No" ReadOnly="True" />
                                                                        <asp:BoundField DataField="Stu_Name" HeaderText="Student Name" ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchfatherName" HeaderText="Father Name" ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchMotherName" HeaderText="Mother Name" ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchFatherMobile" HeaderText="Mobile" ReadOnly="True" />    
                                                                        <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True" />    
                                                                        <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />                                                                        
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                </Columns>
                                                                </asp:GridView>


                                                        </td>
                                                    </tr>
                                                </table>
                                           
                                        
</ContentTemplate> 
</asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
                        Parent Details
                    
</HeaderTemplate>
<ContentTemplate>
                        <div>
                          
                                <table>
                                    <tr>
                                        <td align="left">
                                            <fieldset style="width: 725px;">
                                              
                                                <table style="font-weight: bolder; width: 496px; margin: 0 auto;" align="center">
                                                  
                                                <tr>
                                                <td></td>
                                                        <td align="left" class="style22" nowrap="nowrap">
                                                            <asp:Label ID="Label26" runat="server" Font-Bold="False">Standard<font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" class="style23" nowrap="nowrap">
                                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="efffield"
                                                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="Req8" runat="server" InitialValue="0" ErrorMessage="Please select Standerd"
                                                                ControlToValidate="DropDownList1" ValidationGroup="a1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" TargetControlID="Req8"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td></td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label27" runat="server" Font-Bold="False">Division Id<font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap" class="style30">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="efffield"
                                                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="Req9" runat="server" ErrorMessage="Please select Division"
                                                                ControlToValidate="DropDownList2" ValidationGroup="a1" InitialValue="0" Display="None"
                                                                Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender16"
                                                                    runat="server" TargetControlID="Req9" Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td></td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:Label ID="Label28" runat="server" Font-Bold="False">Roll No<font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap" class="style30">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" CssClass="efffield"
                                                                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="Req10" runat="server" ErrorMessage="Please select Roll No"
                                                                        ControlToValidate="DropDownList3" ValidationGroup="a1" InitialValue="0" Display="None"
                                                                        Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender17"
                                                                            runat="server" TargetControlID="Req10" Enabled="True">
                                                                        </asp:ValidatorCalloutExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="6" class="style8">
                                                            <asp:Image ID="FatherImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                                runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;
                                                                margin-top: -140px" border="2" ToolTip="Image" />&nbsp;&nbsp;
                                                        </td>
                                                        <td align="left" width="230" now abbrrap="nowrap">
                                                            <asp:Label ID="lblvchno" runat="server" Font-Bold="False">Father Name <font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" width="230" nowrap="nowrap">
                                                            <asp:TextBox ID="txtp1" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                CssClass="efffield" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequFieator1" runat="server" ValidationGroup="b1"
                                                                ErrorMessage="Please Enter First Name" ControlToValidate="txtp1" Display="None"
                                                                Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender18"
                                                                    runat="server" TargetControlID="RequFieator1" Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegEV1" ValidationGroup="b1" runat="server" ControlToValidate="txtp1"
                                                                ErrorMessage="Only alphabets are allowed" ForeColor="Red" ValidationExpression="[a-zA-Z]+"
                                                                Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RegEV1">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    
                                                        <td align="left" width="230" now abbrrap="nowrap"style="display:none;" >
                                                            <asp:Label ID="lblvchmake" runat="server" Font-Bold="False">Father Middle Name</asp:Label>
                                                        </td>
                                                        <td align="left" width="230" now abbrrap="nowrap" style="display:none;">
                                                            <asp:TextBox ID="txtp2" runat="server" Font-Names="Verdana" CssClass="efffield" MaxLength="20"
                                                                ForeColor="Black" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtp2"
                                                                FilterType="UppercaseLetters, LowercaseLetters" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="display:none;">
                                                            <asp:Label ID="lblvchdrivername" runat="server" Font-Bold="False">Father Last Name<font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" style="display:none;">
                                                            <asp:TextBox ID="txtp3" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                CssClass="efffield" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="ReqFdV2" runat="server" ValidationGroup="b1" ErrorMessage="Please Enter Last Name"
                                                                ControlToValidate="txtp3" Display="None" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender19" runat="server" TargetControlID="ReqFdV2" Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegExpValr3" ValidationGroup="b1" runat="server"
                                                                ControlToValidate="txtp3" ErrorMessage="Only alphabets are allowed" ForeColor="Red"
                                                                ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender21" runat="server" Enabled="True" TargetControlID="RegExpValr3">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblpalceofbirth1" runat="server" Font-Bold="False">Father Mobile No<font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:TextBox ID="txtp4" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="10"
                                                                CssClass="efffield" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtp4"
                                                                Display="None" ValidationGroup="b1" ErrorMessage="Please Enter Father Mobile No"
                                                                Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14"
                                                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                                </asp:ValidatorCalloutExtender>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtp4"
                                                                FilterType="Numbers" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                              
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblpalceofbirth4" runat="server" Font-Bold="False">Father DOB</asp:Label>
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:TextBox ID="txtp5" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                                                CssClass="efffield" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtp5"
                                                                Enabled="True" Format="dd/MM/yyyy">
                                                            </asp:CalendarExtender>
                                                            &nbsp;&nbsp;
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtp5"
                                                                Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)" Font-Bold="False"
                                                                Operator="GreaterThan" ValidationGroup="b1" SetFocusOnError="True" Type="Date"
                                                                ValueToCompare="1/1/1100"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender60"
                                                                    runat="server" Enabled="True" TargetControlID="CompareValidator1">
                                                                </asp:ValidatorCalloutExtender>
                                                                
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label20" runat="server" Font-Bold="False">Father Email Id</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtp6" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="50"
                                                                CssClass="efffield" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ControlToValidate="txtp6" Display="None" ValidationGroup="b1" ErrorMessage="Invalid Email Format"
                                                                Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                                </asp:ValidatorCalloutExtender>                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="MotherImg" runat="server" AlternateText="Image" border="2" 
                                                                ImageUrl="images/Sample%20Photo1.jpg" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;
                                                                margin-top: -155px" ToolTip="Image" />
                                                        </td>
                                                           <td align="left" width="230" nowrap="nowrap">
                                                            <asp:Label ID="lbldrivermobno" runat="server" Font-Bold="False">Mother Name</asp:Label>








                                                        </td>
                                                        <td align="left" width="230" nowrap="nowrap">
                                                            <asp:TextBox ID="txtp19" runat="server" Font-Names="Verdana" MaxLength="20" ForeColor="Black"
                                                                CssClass="input-blue"></asp:TextBox>








                                                            &nbsp;&nbsp; &nbsp;&nbsp;








                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtp19"
                                                                FilterType="UppercaseLetters, LowercaseLetters" Enabled="True"></asp:FilteredTextBoxExtender>








                                                        </td>
                                                        
                                                    </tr>
                                                 
                                                  
                                                    <tr valign="bottom">
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <asp:Label ID="lblpalceofbirth2" runat="server" Style="position: relative; top: -9px;"
                                                                Font-Bold="False">Mother Mobile No</asp:Label>








                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtp22" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="10"
                                                                CssClass="input-blue"></asp:TextBox>
                                                                 <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtp22"
                                                                FilterType="Numbers" Enabled="True"></asp:FilteredTextBoxExtender>






                                                           
                                                        </td>
                                                    </tr>
                                                    <tr valign="bottom">
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <asp:Label ID="lblpalceofbirth5" runat="server" Style="position: relative; top: -9px;"
                                                                Font-Bold="False">Mother DOB</asp:Label>








                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                            <asp:TextBox ID="txtp23" runat="server" Font-Names="Verdana" ForeColor="Black" MaxLength="20"
                                                                CssClass="input-blue"></asp:TextBox>








                                                            &nbsp;&nbsp;
                                                            <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtp23"
                                                                Enabled="True"></asp:CalendarExtender>


                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtp23"
                                                                Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)" Font-Bold="False"
                                                                Operator="GreaterThan" SetFocusOnError="True" Type="Date" ValidationGroup="C1"
                                                                ValueToCompare="1/1/1100"></asp:CompareValidator>








                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                                                TargetControlID="CompareValidator2"></asp:ValidatorCalloutExtender>








                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
<td align="left" width="230">
                                                            <asp:Label ID="Label37" runat="server" Font-Bold="False">Address<font size="1px" color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="left" width="230" nowrap="nowrap">
                                                            <asp:TextBox ID="txtp7" runat="server" Font-Names="Verdana" MaxLength="250" 
                                                                Height="50px" ForeColor="Black"
                                                                CssClass="efffield" ValidationGroup="b1" TextMode="MultiLine"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequFietor10" runat="server" ControlToValidate="txtp7"
                                                                Display="None" ErrorMessage="Please Enter Address" Font-Bold="False" ValidationGroup="b1"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender23" runat="server" Enabled="True" TargetControlID="RequFietor10">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
</tr>
                                                   <tr>
                                                   <td>&nbsp;</td>
                                                        
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                        <td id="img" runat="server" align="left">
                                                            
                                                                    <asp:FileUpload ID="FileUpload1" CssClass="efffield" runat="server" /> </td>
                                                                   <td>
                                                                    <asp:Button ID="Button1" runat="server" Style="position: relative;" CssClass="btn1"
                                                                        OnClick="Button1_Click" OnClientClick="if (!validatePage()) {return true;}" Text="Upload Father Image" />
                                                                         </td>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="Button1" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                      
                                                    </tr>
                                                  
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                          <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                                                        <td id="Td1" runat="server" align="center">
                                                          
                                                                    <asp:FileUpload ID="FileUpload2" runat="server" class="efffield"  />
                                                                        </td>
                                                                <td>
                                                                    <asp:Button ID="Button2" runat="server" CssClass="btn1" Style="position: relative;
                                                                      " OnClick="Button2_Click" OnClientClick="if (!validatePage()) {return true;}"
                                                                        Text="Upload Mother Image" />
                                                                   </td>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                        <asp:PostBackTrigger ControlID="Button2" />
                                                                        </Triggers>
                                                                        </asp:UpdatePanel>

                                                    </tr>
                                                 
                                                    
                                                      <tr>
                                                      <td>&nbsp;</td>
                                                        
                                                        
                                                         
                                                               
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
                                                                  
                                                                
                                                                    
                                                                    <td>

                                                                       
                                                           <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                        <asp:Button ID="ButN3" runat="server" CssClass="btn" OnClick="submit" 
                                                                            OnClientClick="if (!validatePage()) {return true;}" Style="margin-right: 10px; position: relative;
                                                                            left: 10px; top: 0px;" Text="Submit" ValidationGroup="d1" />
                                                                             </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button5" runat="server" CssClass="btn" OnClick="Updatev" 
                                                                            OnClientClick="if (!validatePage()) {return true;}" Style="float: right" 
                                                                            Text="Update" ValidationGroup="d1" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:Label ID="idvp1" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                
                                                     
                                                    <caption>
                                                        &nbsp;</caption>
                                                    </tr>
                                                </table>
                          
                        </div>
                    
</ContentTemplate>
                









</asp:TabPanel>
   
      
           
      
           
      
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1
        {
            width: 388px;
        }
        .auto-style2
        {
            height: 22px;
            width: 388px;
        }
        .auto-style3
        {
            height: 26px;
        }
    </style>
</asp:Content>

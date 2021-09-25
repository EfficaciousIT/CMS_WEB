<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSportEquipmentAssignment.aspx.cs" Inherits="frmSportEquipmentAssignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
     function checkDate(sender, args) {
         if (sender._selectedDate < new Date()) {
             alert("You Cannot Select a Past Date Earlier Than Today!");
             sender._selectedDate = new Date();
             // set the date back to the current date
             sender._textbox.set_Value(sender._selectedDate.format(sender._format))
         }
     }

     function CheckStartDate(sender, args) {
         var txtDate1 = document.getElementById('<%= txtAssignDate.ClientID %>').value;
         var tostartDate = new Date(txtDate1);
         var enddateDate = new Date(sender._selectedDate);

         if (txtDate1.length > 0) {
             if (enddateDate < tostartDate) {
                 sender._selectedDate = tostartDate;
                 sender._textbox.set_Value(sender._selectedDate.format(sender._format));
                 alert("End Date must greater than or Equal start date");
             }
         }
     }
     function CheckTargetDate(sender, args) {
         var txtDate1 = document.getElementById('<%= txtReturnDate.ClientID %>').value;
         var tostartDate = new Date(txtDate1);
         var enddateDate = new Date(sender._selectedDate);

         if (txtDate1.length > 0) {
             if (enddateDate < tostartDate) {
                 sender._selectedDate = tostartDate;
                 sender._textbox.set_Value(sender._selectedDate.format(sender._format));
                 alert("Target Date must greater than or Equal start date");
             }
         }
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style>
        .efficacious_send
        {
            width: 100% !important;
            background: #3498db;
            border: none;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            margin-right: 10px;
            float: none;
            text-align: center;
        }
        .textcss
        {
            font-size: 13px !important;
        }
        .textsize
        {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
    </style>
<div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Sports <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li class="active1"><a>Sports Management</a></li>                     
        </ul>
    </div>
<section class="content">
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                <tr>
                                                 <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" style="width:96%;border-collapse:collapse; margin:2% auto 0" 
                                                                DataKeyNames="intEquipment_Assign_id" 
                                                                onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing"
                                                                >
                                                                <Columns>
                                                                   <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intEquipment_id" HeaderText="Equipments" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intStudent_id" HeaderText="Students" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intSport_card_id" HeaderText="Sport Card Number" ReadOnly="True" />
                                                                     <asp:BoundField DataField="dtAssign_date" HeaderText="Assigned Date" ReadOnly="True" />                                                                     
                                                                     <asp:BoundField DataField="dtReturn_date" HeaderText="Due Date" ReadOnly="True" />                                                                    
                                                                     <asp:BoundField DataField="vchStatus" HeaderText="Status" ReadOnly="True" />
                                                                     <asp:BoundField DataField="dtUpdatedDate" HeaderText="Return Date" ReadOnly="True" />
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
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
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                           
                                                <table width="40%" style="text-align: right; margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            Sport Card Number</td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlSportCardNo" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            Standard</td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlStandard_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            Division</td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlDivision" runat="server" 
                                                                onselectedindexchanged="ddlDivision_SelectedIndexChanged" 
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server" Text="Student Name"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlStudentName" runat="server" >
                                                            </asp:DropDownList>
                                                                </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Equipment Name</td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlEquipName" runat="server" >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Due Date</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtAssignDate" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="4" Enabled="False" ></asp:TextBox>
                                                            <asp:CalendarExtender ID="txtAssignDate_CalendarExtender" runat="server" 
                                                               Format="dd/MM/yyyy" Enabled="True" TargetControlID="txtAssignDate">
                                                            </asp:CalendarExtender>
                                                            <asp:FilteredTextBoxExtender ID="txtAssignDate_FilteredTextBoxExtender" 
                                                                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                                                TargetControlID="txtAssignDate" ValidChars="/\ -">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                ControlToValidate="txtAssignDate" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Return Date</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtReturnDate" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="4" AutoPostBack="True" ></asp:TextBox>
                                                            <asp:CalendarExtender ID="txtReturnDate_CalendarExtender" runat="server"  OnClientDateSelectionChanged="checkDate"
                                                              Format="dd/MM/yyyy"  Enabled="True" TargetControlID="txtReturnDate">
                                                            </asp:CalendarExtender>
                                                            <asp:FilteredTextBoxExtender ID="txtReturnDate_FilteredTextBoxExtender" 
                                                                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                                                                TargetControlID="txtReturnDate" ValidChars="/\ -">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                ControlToValidate="txtReturnDate" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Status</td>
                                                        <td align="left">
                                                          <asp:DropDownList ID="txtStatus" runat="server" >
                                                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                                 <asp:ListItem >Assigned</asp:ListItem>
                                                                <asp:ListItem >Returned</asp:ListItem>
                                                            </asp:DropDownList>
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                ControlToValidate="txtStatus" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                
                                                                    <td align="center" >
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="center" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" 
                                                                            onclick="btnClear_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
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
        </center>
    </div>
</section>
</asp:Content>


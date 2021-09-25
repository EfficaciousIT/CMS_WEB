<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmBookAssignToTeacher.aspx.cs" Inherits="frmBookAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("You Cannot Select a Past Date Earlier Than Today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }

        function checkDateIsGreater(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You Cannot Select a Future Date Earlier Than Today!");
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .efficacious_send {
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

        .textcss {
            font-size: 13px !important;
        }

        .textsize {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }

        .style2 {
            height: 19px;
        }

        .reddot {
          height: 20px;
          width: 20px;
          background-color: red !important;
          border-radius: 50%;
          display: inline-block;
          margin-left: 10px;
        }
        .greendot {
          height: 20px;
          width: 20px;
          background-color: green !important;
          border-radius: 50%;
          display: inline-block;
          margin-left: 10px;
        }
        .orangedot {
          height: 20px;
          width: 20px;
          background-color: orange !important;
          border-radius: 50%;
          display: inline-block;
          margin-left: 10px;
        }
        .graydot {
          height: 20px;
          width: 20px;
          background-color: gray !important;
          border-radius: 50%;
          display: inline-block;
          margin-left: 10px;
        }
        .whitedot {
          height: 20px;
          width: 20px;
          background-color: white !important;
          border-radius: 50%;
          display: inline-block;
          margin-left: 10px;
        }
        .browndot {
          height: 20px;
          width: 20px;
          background-color: brown !important;
          border-radius: 50%;
          display: inline-block;
          margin-left: 10px;
        }
    </style>
    <div class="content-header pd-0">
        <ul class="top_nav1">
            <li><a>Library <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li class="active1"><a>Book Assign To Teacher</a></li>
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
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="98%" style="margin:0 0 0 1%;">
                                                <tr>
                                                        <td align="justify" width="3%">
                                                            <asp:Label ID="Label1" runat="server" Text="Deparment"></asp:Label></td>
                                                        <td align="justify" width="10%">    
                                                <asp:DropDownList ID="ddlSDeparment" runat="server" AutoPostBack="True" width="98%" onselectedindexchanged="ddlSDeparment_SelectedIndexChanged" >
                                                               
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td align="justify" width="3%">
                                                            <asp:Label ID="Label4" runat="server" Text="Designation"></asp:Label></td>
                                                        <td align="justify" width="10%">    
                                                <asp:DropDownList ID="ddlSDesignation" runat="server" AutoPostBack="True" width="98%" onselectedindexchanged="ddlSDesignation_SelectedIndexChanged" >
                                                               
                                                            </asp:DropDownList>
                                                        </td>
                                                   
                                                   
                                                        <td align="justify" width="3%">
                                                            <asp:Label ID="Label2" runat="server" Text="Teacher"></asp:Label></td>
                                                             <td align="justify" width="10%">
                                                <asp:DropDownList ID="ddlSTeacher" runat="server" AutoPostBack="True" width="98%" onselectedindexchanged="ddlSTeacher_SelectedIndexChanged">
                                                               
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" width="8%"><strong>Or</strong></td>
                                                  
                                                        
                                                        <td align="left" width="10%">                                                           
                                                             <asp:Label ID="Label3" runat="server" Text="Accession No"></asp:Label></td>
                                                              <td align="left" width="8%"> 
                                                         <asp:TextBox ID="txtSearchAccession" runat="server"  width="100%"
                                                                CssClass="input-blue" AutoPostBack="True" 
                                                                ontextchanged="txtSearchAccession_TextChanged" ></asp:TextBox>
                                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchAccession"
MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="10" ServiceMethod="GetSearchAccession" DelimiterCharacters="" 
                                                                Enabled="True" ServicePath=""></asp:AutoCompleteExtender>
                                                   
                                                        </td>
                                                       <td width="30%"></td> 
                                                    </tr>
                                                    </table>

                                                    <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                              <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="99%" 
                                                                DataKeyNames="intTeacherBook_assign_id" onrowdeleting="grvDetail_RowDeleting1" 
                                                                onrowediting="grvDetail_RowEditing1" OnRowDataBound="myGV_RowDataBound">
                                                                <Columns>
                                                                     <asp:BoundField DataField="vchDepartment_name" HeaderText="DepartMent" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchDesignation" HeaderText="Designation" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intTeacher_id" HeaderText="Teacher Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intBookDetails_id" HeaderText="Accession No" ReadOnly="True" />
                                                                     <asp:BoundField DataField="dtAssigned_Date" HeaderText="Assigned Date" ReadOnly="True" />
                                                                    <asp:BoundField DataField="dtExpectedReturnedDate" HeaderText="Expected Returned Date" ReadOnly="True" />
                                                                     <asp:BoundField DataField="dtReturn_date" HeaderText="Actual Returned Date" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchStatus" HeaderText="Status" ReadOnly="True" />
                                                                  
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemTemplate>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     
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
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                         
                                                <table width="36%" style="text-align: right; margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            Department
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify" class="style2">
                                                            </td>
                                                        <td align="justify" class="style2">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  InitialValue="0" 
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlDepartment"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            Designation 
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlDesignationId" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDesignationId_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                        <td align="justify">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0"  
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlDesignationId"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            Teacher
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlTeacherId" runat="server">
                                                                <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                        <td align="justify">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" InitialValue="0"  
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlTeacherId"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="justify">
                                                            Category
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                        <td align="justify">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0"  
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="justify">
                                                            Subject
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlSubject_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                        <td align="justify">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  InitialValue="0" 
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlSubject"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="justify">
                                                            Book
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlBookId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlBookId_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;</td>
                                                        <td align="justify">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  InitialValue="0" 
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlBookId"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="justify">
                                                            Accession No</td>
                                                        <td align="justify">
                                                         <asp:TextBox ID="txtAccession" runat="server"  
                                                                CssClass="input-blue" Enabled="False" ></asp:TextBox>
                                                   
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  InitialValue="" 
                                                                ErrorMessage="Please provide input" ControlToValidate="txtAccession"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="justify">
                                                            Assigned Date
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                         <asp:TextBox ID="txtAssignDate" runat="server" AutoPostBack="True"  
                                                                CssClass="input-blue" ></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtAssignDate"  OnClientDateSelectionChanged="checkDateIsGreater">
                                                    </asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                                ErrorMessage="Please provide input" ControlToValidate="txtAssignDate"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left">
                                                            Expected Return Date
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtExpectedReturnedDate" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="10"></asp:TextBox>
                                                                <asp:CalendarExtender ID="txtExpectedReturnedDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate"
                                                                Enabled="True" TargetControlID="txtExpectedReturnedDate">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue=""  
                                                                ErrorMessage="Please provide input" ControlToValidate="txtExpectedReturnedDate"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left">
                                                            Status
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="left">
                                                         <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                                             <asp:ListItem Value="0">---select---
                                                                </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify" class="style2">
                                                            </td>
                                                        <td align="justify" class="style2">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  InitialValue="0" 
                                                                ErrorMessage="Please provide input" ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="left">
                                                            Actual Return Date</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtReturnDate" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="10"></asp:TextBox>
                                                                <asp:CalendarExtender ID="txtReturnDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDateIsGreater"
                                                                Enabled="True" TargetControlID="txtReturnDate">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Remarks</td>
                                                        <td align="justify">
                                                          <asp:TextBox ID="txtRemarks" runat="server"  
                                                                CssClass="input-blue" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                             OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px"
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


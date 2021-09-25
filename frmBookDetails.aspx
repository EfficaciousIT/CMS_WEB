<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmBookDetails.aspx.cs" Inherits="BookDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        function showModal(a) {
            $(a).show();
        }
        function hideModal(a) {
            $(a).hide();
        }

        function ddlStatus_Changed() {
            var value = $('#<%=ddlStatusId.ClientID %>').val();           
            if (value == "3" || value == "4" || value == "5" || value == "6" || value == "7")
            {
                $('#Error span i').html('');
                $('#Error span i').html(' You can not set this status from this menu!');
                $('#Error').fadeIn();
                setTimeout(function(){ $('#Error').fadeOut(); }, 5000);
                $('#<%=ddlStatusId.ClientID %>').val("2");
            }
            if (value == "1")
                $('#<%=ddlRemark.ClientID %>').attr("disabled", false);
            else {
                $('#<%=ddlRemark.ClientID %>').attr("disabled", true);
                $('#<%=ddlRemark.ClientID %>').val("0");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Book Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
            <li><a ><i ></i>Library Master</a></li>
            <li class="active">Book Details</li>
        </ol>
    </div>
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

    /* The Modal (background) */
    .modal {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0px;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }

    /* Modal Content */
    .modal-content {
        background-color: #fefefe;
        margin: auto;
        padding: 0px;
        border: 1px solid #888;
        width: 30%;
    }

    /* The Close Button */
    .close {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

        .close:hover,
        .close:focus {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
</style>
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="80%">
                                                <tr>
                                                        <td align="left" width="5%">
                                                            Standard</td>
                                                        <td align="left" width="17%">
                                                            <asp:DropDownList ID="ddlDetStandard" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDetStandard_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" width="5%">
                                                            Subject</td>
                                                        <td align="left" width="17%">
                                                            <asp:DropDownList ID="ddlDetSubject" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDetSubject_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>

                                                     <td align="center" width="5%"><strong>Or</strong></td>

                                                        <td align="left" width="5%">                                                           
                                                             <asp:Label ID="Label3" runat="server" Text="Accession No"></asp:Label></td>
                                                        <td align="left" width="13%"> 
                                                         <asp:TextBox ID="txtSearchAccession" runat="server"  width="100%"
                                                                CssClass="input-blue" AutoPostBack="True" 
                                                                ontextchanged="txtSearchAccession_TextChanged" >
                                                         </asp:TextBox>
                                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchAccession"
                                                                    MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="10" ServiceMethod="GetSearchAccession" 
                                                                    DelimiterCharacters="" Enabled="True" ServicePath=""></asp:AutoCompleteExtender>
                                                   
                                                        </td>

                                                    <td align="center" width="5%"><strong>Or</strong></td>

                                                    <td align="left"  width="5%">
                                                            Status
                                                        </td>
                                                        <td align="left"  width="13%">
                                                            <asp:DropDownList ID="ddlSStatus" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlDetSStatusId_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                        <td  align="right" width="10%" style="padding: 9px;">
                                                            <asp:Button ID="Button1" runat="server" CssClass="efficacious_send" 
                                                                    Text="Export to Excel" onclick="ExportToExcel_Click"  />
                                                        </td> 
                                                    </tr>
                                                 <table width="100%">
                                                <tr>
                                                 <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="99%"   AllowPaging="True"  OnPageIndexChanging="grvDetail_OnPageIndexChanging"
                                                                DataKeyNames="intBookDetails_id" onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing" 
                                                                OnRowDataBound="myGV_RowDataBound"
                                                                >
                                                                <Columns>
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchAccessionNo" HeaderText="Accessio No." ReadOnly="True" />
                                                                <asp:BoundField DataField="intCategory_id" HeaderText="Category" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookEdition_id" HeaderText="Edition" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBook_publication_id" HeaderText="Publication" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBook_Author_id" HeaderText="Author" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookLanguage_id" HeaderText="Subject" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchBookDetails_bookName" HeaderText="Book Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchBookDetails_Status" HeaderText="Status" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchBookDetails_Remark" HeaderText="Remark" ReadOnly="True" />
                                                                <asp:BoundField DataField="intBookQuantity" HeaderText="Qty" ReadOnly="True" 
                                                                        Visible="False" />
                                                                <asp:BoundField DataField="intBookPrice" HeaderText="Price" ReadOnly="True"  
                                                                        Visible="False"/>                                                                     
                                                                     
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
                                            
                                                <table width="36%" style="text-align: right; margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Standard
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStandard" runat="server" >
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
<%--                                                     <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                ControlToValidate="ddlStandard" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">
                                                            Book Category
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlBookCategory" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                             <%--       <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                ControlToValidate="ddlBookCategory" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">
                                                            Book Edition

                                                        </td>
                                                         <td align="left">
                                                            <asp:DropDownList ID="ddlBookEdition" runat="server" AutoPostBack ="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                           <span id="btnshowEditionModal" onclick="showModal($('#bookEditionModal'))" style="cursor: pointer;">
                                                               <i class="fa fa-plus"></i>

                                                           </span>        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Publication</td>
                                                         <td align="left">
                                                            <asp:DropDownList ID="ddlBookPublication" runat="server" >
                                                            </asp:DropDownList>
                                                                    
                                                        </td>
                                                        <td>
                                                            <span id="btnshowPublicationModal" onclick="showModal($('#bookPublicationModal'))" style="cursor: pointer;">
                                                               <i class="fa fa-plus"></i>

                                                           </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Book Author</td>
                                                         <td align="left">
                                                            <asp:DropDownList ID="ddlBookAuthor" runat="server" >
                                                            </asp:DropDownList>
                                                                 
                                                        </td>
                                                        <td>
                                                            <span id="btnshowAuthorModal" onclick="showModal($('#bookAuthorModal'))" style="cursor: pointer;">
                                                               <i class="fa fa-plus"></i>

                                                           </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Subject
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlSubject" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                             <%--       <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="ddlSubject" ErrorMessage="Please provide input"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="justify">
                                                            Book Name 
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" MaxLength="50" AutoComplete="Off"></asp:TextBox>
                                                             <%-- <asp:FilteredTextBoxExtender ID="Fbte1" runat="server" TargetControlID="txtName"
                                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " Enabled="True">
                                                            </asp:FilteredTextBoxExtender>--%>
                                                                </td>
                                                        <td></td>
                                                    </tr>
                                <%--                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td align="left">
                                                            Book Quantity</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBookQuantity" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="4"></asp:TextBox>
                                                                 <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBookQuantity"
                                                                FilterType="Custom, Numbers" ValidChars=" " Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            
                                                        </td>
                                                        <td></td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">
                                                            Book Price</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBookPrice" runat="server" AutoComplete="Off" 
                                                                CssClass="input-blue" MaxLength="8"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtBookPrice"
                                                                FilterType="Custom, Numbers" ValidChars=".$" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label1" runat="server" Text="Accession No."></asp:Label>
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtAccessionNo" runat="server" CssClass="input-blue" MaxLength="50" AutoComplete="Off"></asp:TextBox>
                                                             <%-- <asp:FilteredTextBoxExtender ID="Fbte1" runat="server" TargetControlID="txtName"
                                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " Enabled="True">
                                                            </asp:FilteredTextBoxExtender>--%>
                                                                </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                            
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Rack No.</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtRackNo" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Row No.</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtRowNo" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Status
                                                            <font size="1px" color="red">*</font>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStatusId" runat="server" onchange="ddlStatus_Changed();">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Remark
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlRemark" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left" ">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" 
                                                                            onclick="btnClear_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                        <td></td>
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

    <!-- The Modal -->
    <div id="bookEditionModal" class="modal">

      <!-- Modal content -->
        <div class="modal-content">
          <div class="modal-header">
            <span class="close" onclick="hideModal($('#bookEditionModal'))">&times;</span>
            <h3><b>Add Book Edition</b></h3>
          </div>
          <div class="modal-body">
            <table>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Book Edition :</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <%--<input type="text" id="txtEdition" class="input-blue" />--%>
                    <asp:TextBox ID="txtEdition" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            </table>
          </div>
          <div class="modal-footer" style="text-align: center;">
	        <%--<input type="button" value ="Save" runat="server" style="width: 25% !important;background: #3498db;font-size: 16px;border-radius: 2px;" onclick="addBookEdition()"/>--%>
              <asp:Button ID="Button2" runat="server" Text="Save" style="width: 25% !important;background: #3498db;font-size: 16px;border-radius: 2px;" CssClass="efficacious_send"
                                                                             onclick="addBookEdition" />
          </div>
        </div>
    </div>

    <!-- The Modal -->
    <div id="bookPublicationModal" class="modal">
      <!-- Modal content -->
        <div class="modal-content">
          <div class="modal-header">
            <span class="close" onclick="hideModal($('#bookPublicationModal'))">&times;</span>
            <h3><b>Add Book Publication</b></h3>
          </div>
          <div class="modal-body">
            <table>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Publication Name:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <%--<input type="text" id="txtPublicationName" class="input-blue" />--%>
                    <asp:TextBox ID="txtPublicationName" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Address:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <%--<input type="text" id="txtPublicationAddress" class="input-blue" />--%>
                    <asp:TextBox ID="txtPublicationAddress" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Email:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <%--<input type="text" id="txtPublicationEmail" class="input-blue" />--%>
                    <asp:TextBox ID="txtPublicationEmail" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Mobile No.:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <%--<input type="text" id="txtPublicationMobileNo" class="input-blue" />--%>
                    <asp:TextBox ID="txtPublicationMobileNo" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            </table>
          </div>
          <div class="modal-footer" style="text-align: center;">
	        <%--<input type="button" value ="Save" style="width: 25% !important;background: #3498db;font-size: 16px;border-radius: 2px;" onclick="addBookPublication()"/>--%>
            <asp:Button ID="Button3" runat="server" Text="Save" style="width: 25% !important;background: #3498db;font-size: 16px;border-radius: 2px;" CssClass="efficacious_send"
                                                                             onclick="addBookPublication" />
          </div>
        </div>
    </div>


    <!-- The Modal -->
    <div id="bookAuthorModal" class="modal">
      <!-- Modal content -->
        <div class="modal-content">
          <div class="modal-header">
            <span class="close" onclick="hideModal($('#bookAuthorModal'))">&times;</span>
            <h3><b>Add Book Author</b></h3>
          </div>
          <div class="modal-body">
            <table>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Author Name:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <asp:TextBox ID="txtAuthorName" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Address:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <asp:TextBox ID="txtAuthorAddress" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Email:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <asp:TextBox ID="txtAuthorEmail" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 150px;"><h4>Mobile No.:</h4> </td>
                <td style="text-align: center;width: 150px;">
                    <asp:TextBox ID="txtAuthorMobileNo" runat="server" AutoComplete="Off" CssClass="input-blue" ></asp:TextBox>
                </td>
            </tr>
            </table>
          </div>
          <div class="modal-footer" style="text-align: center;">
	        <asp:Button ID="Button4" runat="server" Text="Save" style="width: 25% !important;background: #3498db;font-size: 16px;border-radius: 2px;" CssClass="efficacious_send"
                            onclick="addBookAuthor" />
          </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HostelFeeHead.aspx.cs" Inherits="HostelFeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript">
      function checkvalidation() {
          var txtParticular = document.getElementById("<%=txtParticular.ClientID %>").value;
          if (txtParticular == '') {
              alert('Head should not be blank');
              return false;
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

      }
    </script>
    <style type="text/css">
        .style1
        {
            width: 80%;
            font-family: Verdana;
        }
        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .search
        {
            border: 1px solid #3498db !important;
            padding: 3px;
        }
        .efficacious_Submit
        {
            border: none;
            background: #3498db;
            border: 1px solid #3498db;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: none;
            left: 10px;
            text-align: center;
        }
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            width: auto;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            vertical-align: middle;
            margin: 0px;
            padding: 0px;
            font-size: 13px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Hostel Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="HostelBuilding.aspx">Hostel Building</a></li>
             <li><a href="HostelWing.aspx">Hostel Wing</a></li>
            <li><a href="HostelFloor.aspx">Hostel Floor</a></li>
            <li><a href="HostelRoom.aspx">Hostel Room</a></li>
            <li><a href="HostelBed.aspx">Hostel Bed</a></li>
            <li class="active1"><a href="HostelFeeHead.aspx">Hostel Fee</a></li>
            <li><a href="HostelStudentMaster.aspx">Hostel Student Entry</a></li>
            <li><a href="HostelInquiry.aspx">Hostel Enquiry</a></li>
        </ul>
    </div>

<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1"
                                Width="850px">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Head Details</HeaderTemplate>
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
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="grdFeeMaster" runat="server"  AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                        DataKeyNames="HostelFeeId" EmptyDataText="No Records Found" Width="100%" 
                                                        onrowdeleting="grdFeeMaster_RowDeleting" 
                                                        onrowediting="grdFeeMaster_RowEditing" >
                                                        <Columns>
                                                            <asp:BoundField DataField="feeType" HeaderText="Fee Type"  ReadOnly ="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchFee" HeaderText="Fee" ReadOnly ="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FeeAmt" HeaderText="Fee Amount"  ReadOnly ="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                        ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                                        ImageUrl="~/images/delete.png" OnClientClick="return confirm('Are you sure you want to delete ?');" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                        </Columns>
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image></ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                                        PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                                        Enabled="True">
                                                    </asp:ModalPopupExtender>
                                                </td>
                                                <td>
                                                </td>
                                                <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnUpdate" runat="server" CssClass="efficacious_Submit" Text="Update"
                                                                    Visible="False"  />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSMS" runat="server" CssClass="efficacious_Submit" Text="SMS" Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Head Entry" Visible="true">
                                    <HeaderTemplate>
                                        Head Entry</HeaderTemplate>
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
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
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
                                                    <asp:Label ID="Label5" runat="server" Text="Type"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpType" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Annual" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Installment" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
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
                                                    <asp:Label ID="Label6" runat="server" Text="Fee Head"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtParticular" runat="server" AutoPostBack="True" CssClass="input-blue"
                                                        Font-Names="Verdana" ForeColor="Black"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender runat="server" ID="Filtertxt" 
                                                        FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " TargetControlID="txtParticular"
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
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
                                                    <asp:Label ID="Label1" runat="server" Text="Fee Amount"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFeeAmt" runat="server" AutoPostBack="True" CssClass="input-blue"
                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="5"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" 
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtFeeAmt"
                                                        Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td align="right">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
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
                                                <td align="left">
                                                    <asp:Button ID="Button1" runat="server" CssClass="efficacious_Submit" 
                                                        OnClientClick="return checkvalidation();" Text="Submit" 
                                                        onclick="Button1_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>


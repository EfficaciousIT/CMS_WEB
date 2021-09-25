<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmstudfeecollection.aspx.cs" Inherits="frmstudfeecollection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     function HideLoader() {
         setTimeout(function () { $('#ctl00_ContentPlaceHolder1_MainTab_tb2_UpdateProgress').hide(); }, 10000);

     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="updat4" runat="server">

        <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                    PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
<div class="content-header pd-0">
       
       <%-- <ul class="top_nav1">
        <li><a >Profile <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li><a href="FrmAdminProfile.aspx">Personal Detail</a></li>
            <li><a href="FrmAdmsTeacherProfile.aspx">Teacher Detail</a></li>
            <li><a href="FrmAdmsStaffProfile.aspx">Staff Detail</a></li>
            <li class="active1"><a href="frmAdmListStudentDetails.aspx">Student Detail</a></li>            
        </ul>--%>
    </div>
<section class="content">

            <div style="padding-top: 5px 0 0 0">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
                                CssClass="MyTabStyle">
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Re-Admission Report
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                            <div class="efficacious">
                                                <table style="font-weight: bolder; width: 60%; margin: 10px 0;" align="center">
                                                    <tr id="teachhide" runat="server">
                                                        <td id="Td127" runat="server" align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label86" runat="server" Font-Bold="False">Standard</asp:Label>
                                                        </td>
                                                        <td id="Td1" runat="server" style="padding-top: 10px">
                                                            <asp:DropDownList ID="DropDownL1" runat="server" Width="140px" OnSelectedIndexChanged="DropDownL1_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownL1"
                                                                Display="None" ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator3">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="teachhide1" runat="server">
                                                        <td id="Td2" align="left" runat="server" style="padding-top: 10px">
                                                            <asp:Label ID="Label17" runat="server" Font-Bold="False">Division</asp:Label>
                                                        </td>
                                                        <td id="Td3" runat="server" style="padding-top: 10px">
                                                            <asp:DropDownList ID="DropDownL2" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                MaxLength="50" Width="140px" OnSelectedIndexChanged="DropDownL2_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownL2"
                                                                Display="None" ErrorMessage="Select Division " Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="False">Select Student</asp:Label>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:DropDownList ID="Droptypeuser" AutoPostBack="True" runat="server" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="50" Width="140px" OnSelectedIndexChanged="Droptypeuser_SelectedIndexChanged"
                                                                ValidationGroup="b">
                                                                <asp:ListItem>---Select---</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Droptypeuser"
                                                                Display="None" ErrorMessage="Select Student " Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                         <td width="30%">
                                                            <asp:Button ID="btnReport" runat="server" CssClass="efficacious_send" 
                                                                    Text="Report" onclick="btnReport_Click" Visible="False"  />
                                                        </td> 
                                                        <td>
                                                            <asp:Button ID="btnExcel" runat="server" Text="Export" width="100%"
                                                            CssClass="btn btn-success col-md-5" style="margin-right:1px;" OnClientClick="HideLoader();" 
                                                             OnClick="btnExcel_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                            <asp:Label ID="lbltext" runat="server"></asp:Label>
                                            </div>
                                            <div class="efficacious">
                                                <table width="100%">
                                                    <tr align="center" id="listparengrid" runat="server">
                                                        <td id="Td4" class="style10" runat="server">
                                                            Student Fee Collection Report
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                    <td>
                                                    <asp:Label ID="lblCount" runat="server" Font-Bold="True"></asp:Label>
                                                   </td>
                                                    </tr>
                                                    <tr id="listparengrid1" runat="server">
                                                        <td id="Td5" style="padding: 10px 0 20px 0;" align="center" runat="server">
                                                         <div id="" style="width: 1000px; height: 600px; overflow: scroll">
                                                            <asp:GridView ID="GridViewliststud" runat="server" designer:wfdid="w36"
                                                                AllowSorting="True" OnRowEditing="GridViewliststud_RowEditing" OnDataBound="GridViewliststud_DataBound"
                                                                OnRowDataBound="GridViewliststud_RowDataBound" OnRowDeleting="GridViewliststud_RowDeleting"
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table" OnPageIndexChanging="GridViewliststud_OnPageIndexChanging"
                                                                 EmptyDataText="Record not Found."  DataKeyNames="int_ID"
                                                                Width="100%" Visible="False" ShowFooter="True">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                    
                                                                    <asp:BoundField DataField="int_ID" HeaderText="int_ID" ReadOnly="True" 
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="intStudentID_Number" HeaderText="StudentID Number" 
                                                                        ReadOnly="True" />
                                                                    <asp:BoundField DataField="Student_name" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True"/>
                                                                    <asp:BoundField DataField="vchDivisionName" HeaderText="Division"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="EmailID" HeaderText="Email ID"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchBank_name" HeaderText="Bank Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="FeeAmount" HeaderText="Amount To be Paid " ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidAmt" HeaderText="Paid Amount" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaymentRefNo" HeaderText="Payment Reference Number" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remark" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="dtInsertDate" HeaderText="Date" ReadOnly="True"  />
                                                                  
                                                                  <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <FooterStyle Font-Bold="True" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                            </div>
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" >
                                                                <Columns>
                                                                <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="Admission Fee" HeaderText="Paid Admission Fee (Rs.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Annual Fee" HeaderText="Paid Annual Charges (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Photo and Insurance" HeaderText="Paid Photo and Insurance (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Total fee" HeaderText="Total fee (Rs.)"  ReadOnly="True" />
                                                                    
                                                                    <asp:BoundField DataField="outstabding" HeaderText="Due Fee (Rs.)" ReadOnly="True" />
                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </center>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


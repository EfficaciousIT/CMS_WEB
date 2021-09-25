<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmMemberMst.aspx.cs" Inherits="frmMemberMst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript">
        function ConfirmMsg() {
            var del = confirm('Do you want to delete this record?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <style type="text/css">
     
         .mGrid th { text-align:center !important;}
       
         .textcss{ font-size:13px !important; color:#000;}
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <table>
             <tr>
                 <td align="left">

               
            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="1" 
        Width="1015">
               
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
                        Details
                    </HeaderTemplate>
                    <ContentTemplate>
                        <center>
                         <table width="100%">
                         <tr>
                         <td align="right">
                             <asp:Label ID="lblSelectGroupNm" runat="server" Text="Select Group Name" style="padding-right:20px;" CssClass="textcss"></asp:Label>
                         </td>
                         <td align="left">
                             <asp:DropDownList ID="ddlGrp" runat="server" CssClass="textsize" Width="150px" style=" padding: 5px 5px; font-size:13px; border-radius: 5px; border: 1px solid green;"
                                 AutoPostBack="True" onselectedindexchanged="ddlGrp_SelectedIndexChanged">
                                   <asp:ListItem Text="Select"></asp:ListItem>
                             <asp:ListItem Text="STD 5"></asp:ListItem>
                             <asp:ListItem Text="STD 9"></asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         </tr>
                          <tr>
                         <td>
                            
                         </td>
                         <td>
                             
                         </td>
                         </tr>

                         <tr>
                         <td colspan="2">
                            <asp:GridView ID="grvDetails" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="Record not Found."
                                Width="100%" DataKeyNames="intGrpMem_id" 
                                 onrowdeleting="grvDetails_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return  ConfirmMsg();"
                                                ImageUrl="~/images/delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Type" DataField="Type" />
                                    <asp:BoundField HeaderText="Department" DataField="Department" />
                                    <asp:BoundField DataField="StaffName" HeaderText="Staff Name" />
                                    <asp:BoundField HeaderText="STD" DataField="STD" />
                                    <asp:BoundField HeaderText="DIV" DataField="DIV" />
                                    <asp:BoundField HeaderText="Roll No" DataField="RollNo" />
                                    <asp:BoundField HeaderText="Student Name" DataField="StudentName" />
                                    <asp:BoundField HeaderText="Parent Name" DataField="ParentName" />
                                    <asp:BoundField DataField="intGrpMem_id" HeaderText="intGrpMem_id" 
                                        Visible="False" />
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
                        New Member
                    </HeaderTemplate>
                    <ContentTemplate>
                        <center>
                        <div class="efficacious">
                            <table width="50%">
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lblSelectGrp" runat="server"  STYLE="WIDTH:140PX !IMPORTANT; color:#000" Text="Select Group Name" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlGroupNm" runat="server" CssClass="textsize">
                                        
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" ControlToValidate="ddlGroupNm" runat="server" Display="None" ErrorMessage="Please Select Group Name" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                            TargetControlID="RequiredFieldValidator1" Enabled="True"></asp:ValidatorCalloutExtender>


                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lblType" runat="server" Text="Select Type" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                                            AutoPostBack="True" CssClass="textsize">
                                             
                                        </asp:DropDownList>

                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" ControlToValidate="ddlType" runat="server" Display="None" ErrorMessage="Please Select Type" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                            TargetControlID="RequiredFieldValidator2" Enabled="True"></asp:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lblSTD" runat="server" Text="STD" Visible="False" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlStd" runat="server" Visible="False" 
                                            CssClass="textsize" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlStd_SelectedIndexChanged">
                                        </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" ControlToValidate="ddlStd" runat="server" Display="None" ErrorMessage="Please Select Standard" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                            TargetControlID="RequiredFieldValidator3" Enabled="True"></asp:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lblDIv" runat="server" Text="DIV" Visible="False" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlDiv" runat="server" Visible="False" 
                                            CssClass="textsize" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged">
                                        
                                        </asp:DropDownList>

                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ControlToValidate="ddlDiv" runat="server" Display="None" ErrorMessage="Please Select Division" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                            TargetControlID="RequiredFieldValidator4" Enabled="True"></asp:ValidatorCalloutExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lbldept" runat="server" Text="Department" Visible="False" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlDept" runat="server" Visible="False" 
                                            CssClass="textsize" AutoPostBack="True" 
                                            onselectedindexchanged="ddlDept_SelectedIndexChanged">
                                        
                                        </asp:DropDownList>

                                        
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" ControlToValidate="ddlDept" runat="server" Display="None" ErrorMessage="Please Select Department" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                                            TargetControlID="RequiredFieldValidator5" Enabled="True"></asp:ValidatorCalloutExtender>


                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lblName" runat="server" Visible="False" CssClass="textcss"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlName" runat="server" Visible="False" 
                                            OnSelectedIndexChanged="ddlName_SelectedIndexChanged" AutoPostBack="True" 
                                            CssClass="textsize">
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" ControlToValidate="ddlName" runat="server" Display="None" ErrorMessage="Please Select Name" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" 
                                            TargetControlID="RequiredFieldValidator6" Enabled="True"></asp:ValidatorCalloutExtender>


                                    </td>
                                </tr>
                                <tr>
                                    <td align="justify">
                                        <asp:Label ID="lblParentNm" runat="server" Visible="False" CssClass="textcss">Parent Name</asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="55%">
                                        <asp:DropDownList ID="ddlParentNm" runat="server" AutoPostBack="True" 
                                            CssClass="textsize" Visible="False">
                                        </asp:DropDownList>

                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="0" ControlToValidate="ddlParentNm" runat="server" Display="None" ErrorMessage="Please Select Parent Name" CssClass="textsize"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" 
                                            TargetControlID="RequiredFieldValidator7" Enabled="True"></asp:ValidatorCalloutExtender>


                                    </td>
                                </tr>
                                <tr>
                                <td>
                                </td>
                                    <td align="left">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="False" 
                                            CssClass="efficacious_send" onclick="btnSubmit_Click" />
                                        &nbsp; 
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Button ID="btnCancel" runat="server" CssClass="efficacious_send" 
                                            OnClick="btnSubmit_Click" Text="Cancel" Visible="False" />
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
        </ContentTemplate>
  <%--      <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlName" EventName="SelectedIndexChanged" />
        </Triggers>--%>
    </asp:UpdatePanel>
    </div>
</asp:Content>

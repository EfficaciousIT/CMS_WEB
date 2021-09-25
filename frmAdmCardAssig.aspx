<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmCardAssig.aspx.cs" Inherits="frmAdmCardAssig" Title="Card Assignment"
    Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="Update1" runat="server"><ContentTemplate>
    <div style="padding-top:5px 0 0 0">
    <table>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="928px" CssClass="MyTabStyle">
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            
                            Student Card Assignment</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <div class="efficacious">
                                        <table width="50%">
                                           
                                            <tr>
                                                <td align="left" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label2" runat="server"  >Type of User</asp:Label>
                                                </td>
                                                
                                                <td align="left" runat="server" style="padding-top:10px">
                                                    
                                                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Width="160px"
                                                        OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"  >
                                                    </asp:DropDownList>
                                                    </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList4"
                                                          Display="None" ErrorMessage="Select Type Of User" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="Tr6" runat="server"  >
                                                <td id="Td7" align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label15" runat="server"   Font-Bold="False">Card No</asp:Label>
                                                </td>
                                                
                                                <td id="Td8" runat="server" align="left" style="padding-top:10px" >
                                                    <asp:DropDownList ID="DropDownListcard" runat="server" AutoPostBack="True" Width="160px"
                                                        OnSelectedIndexChanged="DropDownListcard_SelectedIndexChanged"  >
                                                    </asp:DropDownList>
                                                    </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownListcard"
                                                          Display="None" ErrorMessage="Select Card No" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator5">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R1" runat="server" >
                                                <td align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label6" runat="server"  >Standard Id</asp:Label>
                                                </td>
                                               
                                                <td align="left" runat="server" style="padding-top:10px"><asp:DropDownList ID="DropDownList1"  runat="server" AutoPostBack="True" Width="160px"
                                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  >
                                                    </asp:DropDownList>
                                                   </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList1"
                                                          Display="None" ErrorMessage="Select Standard" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="R2" runat="server">
                                                <td align="left"  runat="server"  style="padding-top:10px">
                                                    <asp:Label ID="Label11" runat="server"  >Division Id</asp:Label>
                                                </td>
                                                
                                                <td align="left" runat="server" style="padding-top:10px">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Width="160px"
                                                        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"  >
                                                    </asp:DropDownList>
                                                   </td><td style="padding-top:10px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList2"
                                                          Display="None" ErrorMessage="Select Division" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator3">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R3" runat="server">
                                                <td align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label18" runat="server"  >Student Roll No</asp:Label>
                                                </td>
                                               
                                                <td align="left" runat="server" style="padding-top:10px">
                                                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="160px"
                                                        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"  >
                                                    </asp:DropDownList>
                                                    </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList3"
                                                          Display="None" ErrorMessage="Select Student Roll No" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R4" runat="server">
                                                <td id="Td9" align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label3" runat="server"  >Department</asp:Label>
                                                </td>
                                                
                                                <td id="Td11" align="left" runat="server" style="padding-top:10px">
                                                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" Width="160px"
                                                         OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"  >
                                                    </asp:DropDownList>
                                                    </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList3"
                                                          Display="None" ErrorMessage="Select Department" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="R5" runat="server" style="padding-top:10px">
                                                <td id="Td12" align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label5" runat="server"  >Staff Id</asp:Label>
                                                </td>
                                              
                                                <td id="Td14" align="left" runat="server" style="padding-top:10px">
                                                    <asp:DropDownList ID="DropDownList6" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged"
                                                         >
                                                    </asp:DropDownList>
                                                    </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownList6"
                                                          Display="None" ErrorMessage="Select Staff Id" Font-Bold="False"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                           
                                            <tr id="Temp2" runat="server">
                                                <td id="Td1" align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label12" runat="server"   Font-Bold="False">Date of Issue</asp:Label>
                                                </td>
                                              
                                                <td id="Td2" runat="server" align="left" style="padding-top:10px; margin:0 auto; float:left;">
                                                
                                                    <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="144px" ></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="TextBox5"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                    </td><td nowrap="nowrap">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Select Date Of Issue"
                                                          ControlToValidate="TextBox5" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator7">
                                                    </asp:ValidatorCalloutExtender>
                                                    &nbsp;
                                                    <asp:CompareValidator ID="CompareEndTodayValidator" Operator="GreaterThanEqual" Type="Date"
                                                        ControlToValidate="TextBox5" ControlToCompare="HiddenTodayDate" ErrorMessage="'Date Of Issue' must be After today's date"
                                                        runat="server" Display="None"   />
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                                        TargetControlID="CompareEndTodayValidator">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr id="Temp3" runat="server">
                                                <td id="Td3" align="left"  runat="server" nowrap="nowrap" style="padding-top:10px ">
                                                    <asp:Label ID="Label13" runat="server"   Font-Bold="False">Date of Expire</asp:Label>
                                                </td>
                                             
                                                <td id="Td4" runat="server" align="left" style="padding-top:10px;margin:0 auto; float:left;">
                                                
                                                    <asp:TextBox ID="TextBox7" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        ForeColor="Black"  MaxLength="20" ValidationGroup="b" Width="144px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="TextBox7"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                    </td><td nowrap="nowrap">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  
                                                        ErrorMessage="Select Date Of Expired" ControlToValidate="TextBox7" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator8">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="CompareValidator1" Operator="GreaterThanEqual" Type="Date"
                                                        ControlToValidate="TextBox7" ControlToCompare="TextBox5" ErrorMessage="'Date Of Expire' must be Greater Then Issue date"
                                                        runat="server" Display="None"   />
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                                        TargetControlID="CompareValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="Temp4" runat="server">
                                                <td id="Td5" align="left"  runat="server" nowrap="nowrap" style="padding-top:10px">
                                                    <asp:Label ID="Label14" runat="server"   Font-Bold="False">Date of Activation</asp:Label>
                                                </td>
                                                
                                                <td id="Td6" runat="server" align="left" style="padding-top:10px; margin:0 auto; float:left;">
                                                
                                                    <asp:TextBox ID="TextBox12" runat="server" AutoPostBack="True" CssClass="textsize"
                                                        ForeColor="Black"  MaxLength="20" ValidationGroup="b" Width="144px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="TextBox12"
                                                        Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                    </td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  
                                                        ErrorMessage="Select Date Of Activation" ControlToValidate="TextBox12" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator9">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="CompareValidator2" Operator="GreaterThanEqual" Type="Date"
                                                        ControlToValidate="TextBox12" ControlToCompare="TextBox5" ErrorMessage="'Date Of Expire' must be Greater Then Issue date"
                                                        runat="server" Display="None"   />
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True"
                                                        TargetControlID="CompareValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="CompareValidator3" Operator="LessThan" Type="Date"
                                                        ControlToValidate="TextBox12" ControlToCompare="TextBox7" ErrorMessage="'Date Of Activation' must be Less Then Expiry date"
                                                        runat="server" Display="None"   />
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" Enabled="True"
                                                        TargetControlID="CompareValidator3">
                                                    </asp:ValidatorCalloutExtender>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <table><tr><td>
                                                    <asp:TextBox ID="HiddenTodayDate" Visible="false" runat="server" />
                                                    <asp:Button    ID="Button1" runat="server" CssClass="efficacious_send" style="  margin-left: 29px;" Text="Submit" OnClick="Button1_Click"   />
                                                </td></tr></table>
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
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #TextArea1
        {
            width: 125px;
            margin-left: 10px;
        }
    </style>
    <script type="text/javascript">
        function CheckDate(ctrl) {
            var dt = new Date();
            var cdt = Date.parse(ctrl.value);
            if (cdt > dt) {
                alert('Date greater than Today');
            }
        }
    </script>
</asp:Content>

<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmListParentsLog.aspx.cs" Inherits="frmAdmListParentsLog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updat4" runat="server"><ContentTemplate>
    <div style="padding-top:5px 0 0 0">
            <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="928px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
               Parents Login's Details
</HeaderTemplate>           
<ContentTemplate>
<center>
    <div class="efficacious">
    <table style="font-weight: bolder; width: 60%; margin: 10px 0;" align="center">
    
        <tr id="teachhide" runat="server"> 
                                <td id="Td127" runat="server" align="left" style="padding-top:10px">
                              
                                <asp:Label ID="Label86" runat="server"   Font-Bold="False">Standard</asp:Label>
                                </td>
                                <td runat="server" style="padding-top:10px">
                               
                                    <asp:DropDownList ID="DropDownL1" runat="server" Width="140px"  OnSelectedIndexChanged="DropDownL1_SelectedIndexChanged"   AutoPostBack="True">
                                    </asp:DropDownList> 
                                   
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="DropDownL1"   Display="None" 
                                        ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>  
                                    
                                                                    
                                  
                                </td>
                                </tr>
                                <tr id="teachhide1" runat="server" >
                                <td align="left" runat="server" style="padding-top:10px">
                               
                                <asp:Label ID="Label17" runat="server"   Font-Bold="False">Division</asp:Label>
                                   </td><td runat="server" style="padding-top:10px">
                                   
                                    <asp:DropDownList ID="DropDownL2" runat="server" Font-Names="Verdana"
                                        ForeColor="Black"  MaxLength="50" Width="140px" OnSelectedIndexChanged="DropDownL2_SelectedIndexChanged"
                                           AutoPostBack="True" >
                                        
                                    </asp:DropDownList>
                                 
                                    
                                  
                                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="DropDownL2"   Display="None" 
                                        ErrorMessage="Select Division " Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
             
               
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender>
                                   
                                   

                                </td>
                                </tr>
                                <tr >
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label1" runat="server"   Font-Bold="False">Select Student</asp:Label>
                </td><td style="padding-top:10px">
              
                <asp:DropDownList ID="Droptypeuser" AutoPostBack="True" runat="server" Font-Names="Verdana" 
                    ForeColor="Black" MaxLength="50" Width="140px" OnSelectedIndexChanged="Droptypeuser_SelectedIndexChanged"
                    ValidationGroup="b"  
                     >
                    
                </asp:DropDownList>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Droptypeuser"   Display="None" 
                    ErrorMessage="Select Student " Font-Bold="False"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                    Enabled="True" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
         
            </td>

        </tr>
        
    </table>
    
    <table width="100%">
        <tr align="center" id="listparengrid" runat="server">
            <td class="style10" runat="server">
               Student Login's Details
            </td>
        </tr>
        <tr id="listparengrid1" runat="server">
            <td align="right" runat="server">
                            <asp:GridView ID="GridViewliststudvl" DataKeyNames="dtLoginDate" runat="server" EmptyDataText="Record not Found."
                                AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="True"
                                OnPageIndexChanging="GridViewliststud_PageIndexChanging" OnRowCancelingEdit="GridViewliststud_RowCancelingEdit"
                                CssClass="mGrid" OnRowDeleting="GridViewliststud_RowDeleting" OnRowEditing="GridViewliststud_RowEditing" EnableModelValidation="True" OnSelectedIndexChanged="GridViewliststudvl_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <Columns>
                                 
                                    <asp:BoundField DataField="dtLoginDate" HeaderText="Date"  />
                                    <asp:BoundField DataField="dtLoginTime" HeaderText="LogInTime"  />
                                    <asp:BoundField DataField="dtLogoutTime" HeaderText="LogOutTime"  />
                                    <asp:BoundField DataField="vchIPaddress" HeaderText="IpAddress"  />
                                </Columns>
                                <PagerStyle CssClass="pgr"></PagerStyle>
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
        </ContentTemplate></asp:UpdatePanel>                          
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style7
        {
            width: 162px;
            height: 26px;
        }
        .style8
        {
            width: 162px;
            height: 22px;
        }
        .style9
        {
            height: 22px;
        }
        .style10
        {
            height: 16px;
        }
    </style>
</asp:Content>

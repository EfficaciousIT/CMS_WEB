<%@ Page Title="List Parents Details" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAdmListParentsDetails.aspx.cs" Inherits="frmAdmListParentsDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding:5px 0 0 0">
         <asp:UpdatePanel ID="upd1" runat="server"><ContentTemplate>
             <table><tr><td align="left">
              <asp:TabContainer ID="TabContainer1" runat="server"  ActiveTabIndex="0"
        Width="1015px"  CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                Parents Details</HeaderTemplate>
            <ContentTemplate>
                <center>
                    <div class="efficacious">
     <table width="50%" >
       <tr><td><br /></td></tr>
        <tr id="drophide1" runat="server"> 
                                <td id="Td127" runat="server" align="left" style="padding-top:10px">
                                <asp:Label ID="Label86" runat="server"   Font-Bold="False">Standard</asp:Label>
                                    </td><td runat="server">
                                    
                                    <asp:DropDownList ID="DropDownL1" runat="server" Font-Names="Verdana"
                                        ForeColor="Black"  MaxLength="50" OnSelectedIndexChanged="DropDownL1_SelectedIndexChanged"
                                        ValidationGroup="b" Width="140px"   AutoPostBack="True">
                                      
                                    </asp:DropDownList>
                                       
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="DropDownL1"   Display="None" 
                                        ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                    
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>
                                </td>
            </tr>
         <tr id="drophide2" runat="server">
                                
                                <td id="Td129" runat="server" align="left" style="padding-top:10px"> 
                                <asp:Label ID="Label21" runat="server"   Font-Bold="False">Division</asp:Label>
                                    </td><td runat="server" style="padding-top:10px">
                                   
                                    <asp:DropDownList ID="DropDownL2" runat="server" Font-Names="Verdana"
                                        ForeColor="Black" Width="140px"  MaxLength="50" OnSelectedIndexChanged="DropDownL2_SelectedIndexChanged"
                                        ValidationGroup="b"   AutoPostBack="True" >
                                     
                                    </asp:DropDownList>
                              
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="DropDownL2"   Display="None" 
                                        ErrorMessage="Select Division" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender>


                                </td>
             </tr>
         <tr>
              <td id="studid" runat="server" align="left" style="padding-top:10px">
                <asp:Label ID="Label22" runat="server"  >Select Student </asp:Label>
                 </td><td style="padding-top:10px">
                
                  <asp:DropDownList ID="Droptypeuser" runat="server" Font-Names="Verdana" 
                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="Droptypeuser_SelectedIndexChanged"
                    ValidationGroup="b" Width="140px" AutoPostBack="True"   
                      DataTextField="TEXT" DataValueField="ID">
                      <asp:ListItem>---Select---</asp:ListItem>
                    </asp:DropDownList>
                     
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="Droptypeuser"   Display="None" 
                                        ErrorMessage="Select Student Id" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                      <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                        Enabled="True" TargetControlID="RequiredFieldValidator2">
                 </asp:ValidatorCalloutExtender>
            </td>

        </tr>
        <tr><td style="padding-top:10px"></td></tr>
    </table>
   </div>
</center>
                                        
    <table width=100%>
        <tr align="center" id="listparengrid" runat="server">
            <td style="padding-top:20px" runat="server">
                <asp:Label ID="labv1" runat="server" Text="List Of Parents Profile Details"></asp:Label>
                
            </td>
        </tr>
        <tr id="listparengrid1" runat="server">
            <td  align="center" runat="server">
                <asp:GridView ID="GridViewlistpare" runat="server" designer:wfdid="w36" AllowPaging="True" OnPageIndexChanging="GridViewlistpare_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False"  OnRowEditing="GridViewlistpare_RowEditing" 
                    OnDataBound="GridViewlistpare_DataBound" 
                    OnRowDataBound="GridViewlistpare_RowDataBound" OnRowDeleting="GridViewlistpare_RowDeleting" CssClass="mGrid" DataKeyNames="intParent_id"
                    EmptyDataText="Record not Found." Width="100%" onselectedindexchanged="GridViewlistpare_SelectedIndexChanged" EnableModelValidation="True">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                     
                                                    <asp:ImageButton ID="ImgDelete" runat="server" Style="width:20px !important;" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                        OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                        CausesValidation="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgEdit" runat="server" Style="width:18px !important;" ImageUrl="~/images/edit.png" CommandName="Edit"
                                                        CausesValidation="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                         <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                ImageUrl="images/icon_edit.png" Text="Delete" AlternateText="Details" ToolTip="Click"
                                               Style="width:20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                        <asp:BoundField DataField="intStudent_id" HeaderText="Student Id" />
                        <asp:BoundField DataField="intstanderd_id" HeaderText="Standard Id" />
                        <asp:BoundField DataField="intDivision_id" HeaderText="Division Id" />
                        <asp:BoundField DataField="intRollNo" HeaderText="Roll No" />
                        <asp:BoundField DataField="name" HeaderText="Student Name" />
                        <asp:BoundField DataField="fathername" HeaderText="Father Name" />
                        <asp:BoundField DataField="mothername" HeaderText="Mother Name" />
                        <asp:BoundField DataField="intFatherMobile" HeaderText="Father Mobile No" />
                        <asp:BoundField DataField="MotherMobile" HeaderText="Mother Mobile No" />
                        <asp:BoundField DataField="FatherCompanyName" HeaderText="Father Company Name" />
                        <asp:BoundField DataField="MotherCompanyName" HeaderText="Mother Company Name" />
                    </Columns>
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </td>
        </tr>
    </table>
   </ContentTemplate>
            </asp:TabPanel>
                  </asp:TabContainer>
                </td></tr></table>
                   </ContentTemplate>

         </asp:UpdatePanel>
           </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 2px;
        }
        .style5
        {
            width: 162px;
        }
         .mGrid th {
         text-align: center !important;
            }

        </style>
</asp:Content>

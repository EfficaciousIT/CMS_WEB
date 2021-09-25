<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" CodeFile="frmAdmEnquiry_Received.aspx.cs" Inherits="frmAdmEnquiry_Received" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:5px 0 0 0">
<table>
    
    <tr><td align="left">
<asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="930px"
         style="margin-bottom: 0px" CssClass="MyTabStyle">
 <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Enquiry List
            </HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table width="100%">
 <tr><td align="center">
                        <div class="efficacious" id="efficacious"> <table align="right">
                    <tr><td width="200px"></td><td align="right">
                       
                            <asp:Label ID="Label6" runat="server"   Font-Bold="False">Select Month</asp:Label>
                        </td>
                        <td>
                       
                            <asp:DropDownList ID="DropDown5" AutoPostBack="True" runat="server" 
                                onselectedindexchanged="DropDown5_SelectedIndexChanged">
                                <asp:ListItem Selected="True">--select--</asp:ListItem>
                                <asp:ListItem Value="01">Jan</asp:ListItem>
                                <asp:ListItem Value="02">Feb</asp:ListItem>
                                <asp:ListItem Value="03" >Mar</asp:ListItem>
                                <asp:ListItem Value="04">Apr</asp:ListItem>
                                <asp:ListItem Value="05">May</asp:ListItem>
                                <asp:ListItem Value="06">June</asp:ListItem>
                                <asp:ListItem Value="07">July</asp:ListItem>
                                <asp:ListItem Value="08">Aug</asp:ListItem>
                                <asp:ListItem Value="09">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                         
                        </td></tr>
                        </table></div></td></tr>

                    <tr>
                        <td>
                            <asp:GridView ID="GridViewEnquiry" EmptyDataText="No Records Found" 
                                runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="100%">
                                <AlternatingRowStyle CssClass="alt"  ></AlternatingRowStyle>
                                <Columns>
                                
                                <asp:BoundField DataField="intEnquiry_id" HeaderText="ID" 
                                        ReadOnly="True" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchSchool_Name" HeaderText="School Name" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchContact_Name" HeaderText="Contact Name" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vchCity" HeaderText="City" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="vchState" HeaderText="State" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="vchCountry" HeaderText="Country" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="vchTelephone" HeaderText="Telephone No" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="vchEmail" HeaderText="Email Id" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dtInsertDate" HeaderText="Enquiry Date" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                    
                                </Columns>
                                <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="True"/> 
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        </asp:TabContainer>
</td></tr></table>

</div>
</asp:Content>


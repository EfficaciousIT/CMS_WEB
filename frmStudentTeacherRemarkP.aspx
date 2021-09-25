<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmStudentTeacherRemarkP.aspx.cs" Inherits="frmStudentTeacherRemarkP" Title="Teacher Remark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding:5px,0,0,0">
        <asp:UpdatePanel ID="udv1" runat="server"><ContentTemplate>
    <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="1015px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
             View Remark
            
</HeaderTemplate>
            

<ContentTemplate>
    <div class="efficacious">
    <table width="100%" >
     
        <tr><td align="center">
                        <div class="efficacious" id="efficacious"> <table align="right">
                    <tr>
                    <td width="200"></td>
                    <td align="center" width="200">
                       
                            <asp:Label ID="Label6" runat="server"   Font-Bold="False">Select Month</asp:Label>
                        </td>
                        <td width="200">
                       
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
                         
                        </td>
                        <td width="300"></td>
                        
                        </tr>
                        </table></div></td></tr>
                    <tr><td colspan="2"></td></tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="GridView2" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="100%" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView2_PageIndexChanging" 
                                 DataKeyNames="name" EnableModelValidation="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="alt" ></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="Name" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="starttime" HeaderText="Start Time" 
                                        ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="endtime" HeaderText="End Time" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Route_name" HeaderText="Route Name" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Trip_name" HeaderText="Trip Name" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BusStop_name" HeaderText="Bus Stop Name" ReadOnly="True">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="True"/> 
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                    
                    <td>
                    
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PageSize="10"
                    EmptyDataText="No Records Found" Width="100%" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                  
                         <asp:BoundField DataField="StudentID" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Teacher name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vchSubjectname" HeaderText="Subject">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TeacherRemark" HeaderText="Remark">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Insertdate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" />                            
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                    
                    </td>
                    </tr>
                </table></td></tr>
          <tr>
            <td >
                <br />
              
            </td>
        </tr>
    
       
    </table>
        </div>
    </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </td></tr></table>
    </ContentTemplate></asp:UpdatePanel>
            </div>
</asp:Content>

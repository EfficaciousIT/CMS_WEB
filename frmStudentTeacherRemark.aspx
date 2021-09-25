<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmStudentTeacherRemark.aspx.cs" Inherits="frmStudentTeacherRemark" Title="Teacher Remark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 93%;
        }
        .style2
        {
            width: 463px;
        }
        .mGrid th {
padding: 1% !important;
color: #fff;
text-align: center !important;
background: rgb(3, 116, 3);
border-left: solid 1px #525252;
font-size: 0.9em;
font: 14px verdana !important;
height: auto !important; width:20%;
}
.efficacious span{ width:13px !important; margin-bottom:0 !important;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding:5px,0,0,0">
    <table><tr><td align="left">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="1015px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
             View Remark
            
</HeaderTemplate>
            

<ContentTemplate>
    <div class="efficacious">
    <table width="1015px" >
        <tr id="divDis" runat="server" visible="False"> <td ALIGN="CENTER" runat="server">
            <div class="efficacious" id="efficacious">
            <table width="600">
                       <tr>
                       <td align="left" width="100px">
                   <asp:Label ID="lab1" runat="server" style="width:100% !important; margin:0; padding:0; position:relative; top:-5px; right:10px; text-align:right;" Text="Standard" ></asp:Label>
                       </td>
                       <td align="right"  width="100px">
               <asp:DropDownList ID="Drop11" runat="server" style="width:100%" AutoPostBack="True" OnSelectedIndexChanged="Drop11_SelectedIndexChanged" ></asp:DropDownList>    
               </td>
                   <td align="left"  width="100px">
                       <asp:Label ID="Label1" runat="server" style="width:100% !important; margin:0; padding:0; position:relative; top:-5px; right:10px; text-align:right;" Text="Division" ></asp:Label>
                       </td>
                       <td align="right"  width="100px">
               <asp:DropDownList ID="Drop12" runat="server" style="width:100%" AutoPostBack="True" OnSelectedIndexChanged="Drop12_SelectedIndexChanged" ></asp:DropDownList>  
</td></tr>
</table>
    </div>
                   </td></tr>
                    <tr><td colspan="2"></td></tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="GridView2" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                CssClass="mGrid" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" 
                                 DataKeyNames="name" 
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
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
            <td >
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    EmptyDataText="No Records Found" Width="100%" AllowPaging="True" 
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                  
                        <asp:BoundField DataField="Insertdate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" />                            
                        </asp:BoundField>
                  
                         <asp:BoundField DataField="StudentID" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Teacher Name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vchSubjectname" HeaderText="Subject">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TeacherRemark" HeaderText="Remark">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

</table>
            
                </table></td></tr>
          
    
       
    </table>
        </div>
    </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </td></tr></table>
    </div>
</asp:Content>

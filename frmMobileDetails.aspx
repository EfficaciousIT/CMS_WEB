<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmMobileDetails.aspx.cs" Inherits="frmMobileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Mobile Details <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
             <li class="active1"><a>Mobile Detials</a></li>        
        </ul>
    </div>

    <div class="container">
        <div class="card" >
            <div class="card-block" style="width:97%;height:auto;background-color:#ffffff">
    <section class="content">

        <div class="row">
            <section class="col-md-12 col-xs-12">
                <div class="border box-orange">
                    <div class="box-header">
                        <h3 class="text-center">Mobile Details</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-horizontal">
                            <div class="col-md-10">
                                <div class="form-group">
                                    <div class="col-md-2" style="padding:0 0 0 6px;margin-top:10px;">
                                        <asp:Label ID="Label1" runat="server" Text="User Type" CssClass="control-label"></asp:Label>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:DropDownList ID="DropDownList1" style="width:60%;" runat="server" class="from-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>Student</asp:ListItem>
                                            <asp:ListItem>Teacher</asp:ListItem>
                                            <asp:ListItem>Staff</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>

                                <div class="form-group"  runat="server" id="Numbers">
                                    <div class="col-md-2" style="padding:0 0 0 6px;margin-top:2px;">
                                        <asp:Label ID="Label2" runat="server" Text="Mobile Number" CssClass="control-label"></asp:Label>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="control-label" style="text-align:left;"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="col-md-2 col-md-offset-1" style="padding:0;">
                                    <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Search" OnClick="Button1_Click"></asp:Button>
                                </div>




                                <div class="efficacious">
                                    <table width="100%">
                                        <tr align="center"  runat="server">
                                            <td class="style10" runat="server">
                                                List of Mobile Details
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td style="padding:10px 0 20px 0;" align="center" runat="server">
                                                 <asp:GridView ID="GridView1" runat="server" designer:wfdid="w36" AutoGenerateColumns="False" CssClass="table tabular-table"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging" DataBound="intStudent_id" EmptyDataText="Record Not Found" Width="100%">
                                                     <Columns>
                                                                 <asp:BoundField DataField="intStudent_id" HeaderText="Student Id" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" Visible="true" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchDivisionName" HeaderText="Division" Visible="true" ReadOnly="True" />
                                                                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" ReadOnly="True" />
                                                     </Columns>
                                                 </asp:GridView>


                                                <asp:GridView ID="GridView2" runat="server" designer:wfdid="w36" AutoGenerateColumns="False" CssClass="table tabular-table"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging" DataBound="intTeacher_id" EmptyDataText="Record Not Found" Width="100%">
                                                     <Columns>
                                                                 <asp:BoundField DataField="intTeacher_id" HeaderText="Teacher Id" ReadOnly="True" />
                                                                    <%--<asp:BoundField DataField="intstanderd_id" HeaderText="Standard" Visible="true" ReadOnly="True" />--%>
                                                                   <%-- <asp:BoundField DataField="intDivision_id" HeaderText="Division" Visible="true" ReadOnly="True" />--%>
                                                                    <asp:BoundField DataField="vchFirst_name" HeaderText="Teacher Name" ReadOnly="True" />
                                                     </Columns>
                                                 </asp:GridView>

                                                <asp:GridView ID="GridView3" runat="server" designer:wfdid="w36" AutoGenerateColumns="False" CssClass="table tabular-table"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging" DataBound="intStaff_id" EmptyDataText="Record Not Found" Width="100%">
                                                     <Columns>
                                                                 <asp:BoundField DataField="intStaff_id" HeaderText="Staff Id" ReadOnly="True" />
                                                                    <%--<asp:BoundField DataField="intstanderd_id" HeaderText="Standard" Visible="true" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intDivision_id" HeaderText="Division" Visible="true" ReadOnly="True" />--%>
                                                                    <asp:BoundField DataField="vchFirst_name" HeaderText="Staff Name" ReadOnly="True" />
                                                     </Columns>
                                                 </asp:GridView>

                                                <asp:GridView ID="GridView4" runat="server" designer:wfdid="w36" AutoGenerateColumns="False" CssClass="table tabular-table"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging" DataBound="intAdmin_id" EmptyDataText="Record Not Found" Width="100%">
                                                     <Columns>
                                                                 <asp:BoundField DataField="intAdmin_id" HeaderText="Admin Id" ReadOnly="True" />
                                                                    <%--<asp:BoundField DataField="intstanderd_id" HeaderText="Standard" Visible="true" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intDivision_id" HeaderText="Division" Visible="true" ReadOnly="True" />--%>
                                                                    <asp:BoundField DataField="vchFirst_name" HeaderText="Admin" ReadOnly="True" />
                                                     </Columns>
                                                 </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                 </div>
                                </div>
                        </div>
                         
                    </div>
                </div>
            </section>
        </div>
    </section>
            </div>
            </div>
        </div>
</asp:Content>


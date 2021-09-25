<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-gb" EnableEventValidation="true" CodeFile="frmBusTracking.aspx.cs"
    Inherits="frmBusTracking" Title="Live Tracking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=BusRequestDetail.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
    </script>
    <style type="text/css">
        .style3
        {
            width: 50%;
        }
        .mGrid th {
 
  text-align: center !important;
 
}
.btn{background: #3498db; border-radius:5px; height:auto; padding:10px 20px; border:none; color:#fff; outline:none; width:}
.select{ width:130px; height:auto; padding:5px; border-radius:5px; -webkit-border-radius:5px; font-size:13px !important; -moz-border-radius:5px; border: 1px solid #3498db; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
     <head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            Bus Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li class="active">Bus Service</li>
        </ol>
    </div>
    <table>
        <tr>
            <td align="left">
                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                    Width="1015px">
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Current Month
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table>
                                <tr>
                                    <td align="center">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:GridView ID="grdCurrentMonth" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                            CssClass="table  tabular-table" DataKeyNames="intDevice_id,dtAttendance,intTrip_id,dtInTime,dtouttime"
                                            Width="1000px" OnRowDataBound="grdCurrentMonth_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
<Columns>
<asp:TemplateField HeaderText="Bing Map">
    <ItemTemplate>
     <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" ImageUrl="images/bMap.png" />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="vchBusNumber" HeaderText="Bus No.">
<HeaderStyle HorizontalAlign="Center" />
</asp:BoundField>
<asp:BoundField DataField="dtAttendance_date" HeaderText="Date">
<HeaderStyle HorizontalAlign="Center" />
</asp:BoundField>
<asp:BoundField DataField="dtInTime" HeaderText="Bus In">
<HeaderStyle HorizontalAlign="Center" />
</asp:BoundField>
<asp:BoundField DataField="dtouttime" HeaderText="Bus Out">
<HeaderStyle HorizontalAlign="Center" />
</asp:BoundField>
</Columns>
</asp:GridView>

                                        
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            View History
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="right" style="padding: 0;">
                                        <table width="50%" style="margin: 0 auto;">
                                            <tr>
                                                <td align="right">
                                                    <table width="50%" style="margin: 0 auto;">
                                                        <tr>
                                                            <br />
                                                            <td align="left" style="padding: 0;">
                                                                <asp:DropDownList ID="droMonth" AutoPostBack="True" CssClass="select" runat="server"
                                                                    Font-Names="Verdana" Font-Size="8.5pt" OnSelectedIndexChanged="droMonth_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                                                    <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                                    <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                                    <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                                    <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                                    <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                                                    <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                                    <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:GridView ID="grdHistory" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                            CssClass="table  tabular-table" Width="1010px" OnRowDataBound="drdTrack_RowDataBound"
                                            EnableModelValidation="True">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Bing Map" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" Visible="false" runat="server" CausesValidation="False"
                                                            ImageUrl="images/bMap.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vchBusNumber" HeaderText="Bus No.">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtAttendance_date" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtInTime" HeaderText="Bus In">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtouttime" HeaderText="Bus Out">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel5">
                        <HeaderTemplate>
                            Absent Details
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="right" style="padding: 0px">
                                        <table width="36%" style="margin: 0 auto;">
                                            <tr>
                                                <td align="right">
                                                    <table width="50%" style="margin: 0 auto;">
                                                        <tr>
                                                            <td align="left" style="padding: 0px;">
                                                                <br />
                                                                <asp:DropDownList ID="DropDownList3" AutoPostBack="true" CssClass="select" runat="server"
                                                                    Font-Names="Verdana" Font-Size="8.5pt" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                                                    <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                                    <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                                    <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                                    <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                                    <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                                                    <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                                    <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:GridView ID="grdAbsentDetails" EmptyDataText="No Records Found" runat="server"
                                            AutoGenerateColumns="False" CssClass="table  tabular-table" Width="1000px">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="dtAttendance_date" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchDay" HeaderText="Day">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel3" Visible="false">
                        <HeaderTemplate>
                            Bus Service
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table>
                                <tr>
                                    <td align="right">
                                        <table width="50%" style="margin: 0 auto;">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Bus Service" Visible="false"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <table class="style3" style="margin: 0 auto;">
                                                        <br />
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton3" runat="server" Visible="false" Font-Underline="True">Next</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton4" runat="server" Visible="false" Font-Underline="True">Previous</asp:LinkButton>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select" Font-Names="Verdana"
                                                                    Font-Size="8pt">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>Jan</asp:ListItem>
                                                                    <asp:ListItem>Feb</asp:ListItem>
                                                                    <asp:ListItem>Mar</asp:ListItem>
                                                                    <asp:ListItem>Apr</asp:ListItem>
                                                                    <asp:ListItem>May</asp:ListItem>
                                                                    <asp:ListItem>June</asp:ListItem>
                                                                    <asp:ListItem>July</asp:ListItem>
                                                                    <asp:ListItem>Aug</asp:ListItem>
                                                                    <asp:ListItem>Sep</asp:ListItem>
                                                                    <asp:ListItem>Oct</asp:ListItem>
                                                                    <asp:ListItem>Nov</asp:ListItem>
                                                                    <asp:ListItem>Dec</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:GridView ID="GridView3" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                            CssClass="mGrid" Width="1010px">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="route" HeaderText="Route Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="effectivefrom" HeaderText="Effective From">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="effectiveto" HeaderText="Effective To">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fee" HeaderText="Fee Paid">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="paiddate" HeaderText="Paid Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel Visible="false" runat="server" HeaderText="TabPanel1" ID="TabPanel4">
                        <HeaderTemplate>
                            Travel Details
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table>
                                <tr>
                                    <td align="right">
                                        <table width="50%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Bus Service"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="LinkButton5" runat="server" Font-Underline="True">Next</asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="LinkButton6" runat="server" Font-Underline="True">Previous</asp:LinkButton>
                                                </td>
                                                <td align="right">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="select" Font-Names="Verdana"
                                                        Font-Size="8pt">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Jan</asp:ListItem>
                                                        <asp:ListItem>Feb</asp:ListItem>
                                                        <asp:ListItem>Mar</asp:ListItem>
                                                        <asp:ListItem>Apr</asp:ListItem>
                                                        <asp:ListItem>May</asp:ListItem>
                                                        <asp:ListItem>June</asp:ListItem>
                                                        <asp:ListItem>July</asp:ListItem>
                                                        <asp:ListItem>Aug</asp:ListItem>
                                                        <asp:ListItem>Sep</asp:ListItem>
                                                        <asp:ListItem>Oct</asp:ListItem>
                                                        <asp:ListItem>Nov</asp:ListItem>
                                                        <asp:ListItem>Dec</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdTravelDetails" EmptyDataText="No Records Found" runat="server"
                                            AutoGenerateColumns="False" CssClass="mGrid" Width="800px">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="dtAttendance_date" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchDay" HeaderText="Day">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtInTime" HeaderText="Bus In">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dtouttime" HeaderText="Bus Out">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel Visible="false" runat="server" HeaderText="TabPanel1" ID="TabPanel6">
                        <HeaderTemplate>
                            Payment Details
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table>
                                <tr>
                                    <td align="right">
                                        <table width="50%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="Bus Service" Visible="false"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="LinkButton9" runat="server" Visible="false" Font-Underline="True">Next</asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="LinkButton10" runat="server" Visible="false" Font-Underline="True">Previous</asp:LinkButton>
                                                </td>
                                                <td align="right">
                                                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="select" Font-Names="Verdana"
                                                        Font-Size="8pt">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Jan</asp:ListItem>
                                                        <asp:ListItem>Feb</asp:ListItem>
                                                        <asp:ListItem>Mar</asp:ListItem>
                                                        <asp:ListItem>Apr</asp:ListItem>
                                                        <asp:ListItem>May</asp:ListItem>
                                                        <asp:ListItem>June</asp:ListItem>
                                                        <asp:ListItem>July</asp:ListItem>
                                                        <asp:ListItem>Aug</asp:ListItem>
                                                        <asp:ListItem>Sep</asp:ListItem>
                                                        <asp:ListItem>Oct</asp:ListItem>
                                                        <asp:ListItem>Nov</asp:ListItem>
                                                        <asp:ListItem>Dec</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView6" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                            CssClass="mGrid" Width="800px">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="date" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="mode" HeaderText="Mode">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="amount" HeaderText="Amount">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="receivedate" HeaderText="Receive date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Chequeno" HeaderText="Cheque no.">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="chequedate" HeaderText="Cheque date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="clearancedate" HeaderText="Cheque clearance date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel runat="server" Visible="false" HeaderText="TabPanel1" ID="TabPanel7">
                        <HeaderTemplate>
                            Notification
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table>
                                <tr>
                                    <td align="right">
                                        <table width="50%" style="margin: 0 auto;">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Bus Service"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="LinkButton11" runat="server" Font-Underline="True">Next</asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="LinkButton12" runat="server" Font-Underline="True">Previous</asp:LinkButton>
                                                </td>
                                                <td align="right">
                                                    <asp:DropDownList ID="DropDownList6" runat="server" CssClass="select" Font-Names="Verdana"
                                                        Font-Size="8pt">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Jan</asp:ListItem>
                                                        <asp:ListItem>Feb</asp:ListItem>
                                                        <asp:ListItem>Mar</asp:ListItem>
                                                        <asp:ListItem>Apr</asp:ListItem>
                                                        <asp:ListItem>May</asp:ListItem>
                                                        <asp:ListItem>June</asp:ListItem>
                                                        <asp:ListItem>July</asp:ListItem>
                                                        <asp:ListItem>Aug</asp:ListItem>
                                                        <asp:ListItem>Sep</asp:ListItem>
                                                        <asp:ListItem>Oct</asp:ListItem>
                                                        <asp:ListItem>Nov</asp:ListItem>
                                                        <asp:ListItem>Dec</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView7" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="False"
                                            CssClass="mGrid" Width="1015px">
                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="route" HeaderText="Route name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="effectivefrom" HeaderText="Effective from">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="effectiveto" HeaderText="Effective to">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fee" HeaderText="Fee paid">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="paiddate" HeaderText="Paid date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Bus Service Request
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                <tr>
                                    <td style="padding: 10px 0 20px 0;" align="center">
                                        <asp:GridView ID="BusRequestDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="mGrid" Width="100%" DataKeyNames="intBusFees_Id" Font-Bold="False"
                                            OnSelectedIndexChanged="BusRequestDetail_SelectedIndexChanged" HorizontalAlign="Center"
                                            EnableModelValidation="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="intBusFees_Id" runat="server" Text='<%# Eval("intBusFees_Id")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="id11" onclick="RadioCheck(this);" AutoPostBack="true" DataTextField="intBusFees_Id"
                                                            DataValueField="intBusFees_Id" runat="server" />
                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("intBusFees_Id")  %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="intArea_Id" HeaderText="Area Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intBus_Amount" HeaderText="Amount" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="Submit" Text="Submit" CssClass="btn" runat="server" OnClick="Submit_Click" />
                                        <asp:TextBox ID="td1" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Application Status
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                <tr>
                                    <td style="padding: 10px 0 20px 0;" align="center">
                                        <asp:GridView ID="GridVApp" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="mGrid" Width="100%" DataKeyNames="intService_id" Font-Bold="False"
                                            OnRowDeleting="GridVApp_RowDeleting" OnSelectedIndexChanged="GridVApp_SelectedIndexChanged"
                                            HorizontalAlign="Center">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="intService_id" runat="server" Text='<%# Eval("intService_id")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="Delete"
                                                            OnClientClick="return messageConfirm('Do you want to Delete this Record ?');" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intbus_amount" HeaderText="Amount" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                                <asp:BoundField DataField="dtAppli_Date" HeaderText="Application Date" ReadOnly="True" />
                                                <asp:BoundField DataField="vchApprovaStatus" HeaderText="Approval Status" ReadOnly="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="Button1" Text="Submit" CssClass="btn" runat="server" OnClick="Submit_Click" />
                                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel3" Visible="false">
                        <HeaderTemplate>
                            Report
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                                <tr>
                                    <td style="padding: 10px 0 20px 0;" align="center">
                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="mGrid" Width="100%" DataKeyNames="intService_id" Font-Bold="False"
                                            OnRowDeleting="GridVApp_RowDeleting" OnSelectedIndexChanged="GridVApp_SelectedIndexChanged"
                                            HorizontalAlign="Center" EnableModelValidation="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="intService_id" runat="server" Text='<%# Eval("intService_id")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" ReadOnly="True" />
                                                <asp:BoundField DataField="intbus_amount" HeaderText="Amount" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveFrom" HeaderText="Effective From" ReadOnly="True" />
                                                <asp:BoundField DataField="dtEffectiveTo" HeaderText="Effective To" ReadOnly="True" />
                                                <asp:BoundField DataField="dtAppli_Date" HeaderText="Application Date" ReadOnly="True" />
                                                <asp:BoundField DataField="vchApprovaStatus" HeaderText="Approval Status" ReadOnly="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="Button2" Text="Submit" CssClass="btn" runat="server" OnClick="Submit_Click" />
                                        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                    <asp:TabPanel ID="TabPanel11" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            RawData
                        
</HeaderTemplate>
                        
<ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div style="padding: 5px 0 0 0">
                                            <center>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TabContainer ID="TabContainer2" CssClass="MyTabStyle" runat="server" Width="928px"
                                                                        ActiveTabIndex="0">
                                                                        <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                                            <HeaderTemplate>
                                                                                Detail</HeaderTemplate>
                                                                            <ContentTemplate>
                                                                                <br />
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <center>
                                                                                                <table width="50%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lbladmStandard" runat="server" Text="Month"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">
                                                                                                                <asp:ListItem>---Select--</asp:ListItem>
                                                                                                                <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Fab" Value="02"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                                                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                                                                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td id="Td2" align="center" visible="False" runat="server">
                                                                                                            Date
                                                                                                        </td>
                                                                                                        <td id="Td3" visible="False" runat="server">
                                                                                                            <asp:DropDownList ID="drpDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDate_SelectedIndexChanged">
                                                                                                                <asp:ListItem>---Select--</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            Device
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="drpDevice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDevice_SelectedIndexChanged">
                                                                                                                <asp:ListItem>---Select--</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </center>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                CssClass="mGrid" Width="50%" EmptyDataText="No Examination schedule" DataKeyNames="vchDeviceNumber,StartDate"
                                                                                                OnRowDataBound="GridView3_RowDataBound">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="intExamSchedule_id" HeaderText="Id" Visible="False" />
                                                                                                    <%-- <asp:BoundField DataField="StartDate" HeaderText="Date" ReadOnly="True">
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:BoundField>--%>
                                                                                                    <asp:TemplateField HeaderText="Date">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkOut" CommandName='Edit' runat="server" Text='<%# Eval("StartDate") %>'
                                                                                                                Width="25%"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="Expected" HeaderText="Expected" ReadOnly="True">
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:BoundField>
                                                                                                    <asp:TemplateField HeaderText="Actual">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkIn" CommandName='Edit' runat="server" Text='<%# Eval("Actual") %>'
                                                                                                                Width="25%"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="Difference" HeaderText="Difference" ReadOnly="True">
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:BoundField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                            <asp:GridView ID="grdRawdata" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                CssClass="mGrid" Width="50%" EmptyDataText="No Examination schedule" DataKeyNames="Devicenumber,dtRecieveDatetime,Hour"
                                                                                                OnRowDataBound="grdRawdata_RowDataBound">
                                                                                                <Columns>
                                                                                                    <asp:BoundField DataField="intExamSchedule_id" HeaderText="Id" Visible="False" />
                                                                                                    <asp:BoundField DataField="dtRecieveDatetime" HeaderText="Date" ReadOnly="True">
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:BoundField>
                                                                                                    <asp:BoundField DataField="Hour" HeaderText="Hour" ReadOnly="True">
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:BoundField>
                                                                                                    <asp:TemplateField HeaderText="Count">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkIn" CommandName='Edit' runat="server" Text='<%# Eval("Ct") %>'
                                                                                                                Width="25%"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </asp:TabPanel>
                                                                    </asp:TabContainer>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </center>
                                        </div>
                                    </td>
                                    <td align="right" width="100%" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="right" width="100%" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" width="100%" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        
</ContentTemplate>
                    
</asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>

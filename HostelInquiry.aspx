<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HostelInquiry.aspx.cs" Inherits="HostelInquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
        .style1
        {
            width: 40%;
            padding-left: 2%;
        }
        .style2
        {
            width: 40%;
            padding-left: 2%;
        }
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .mGrid th {
         text-align: center !important;
            }
          
        .style1 input[type=text]
        {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 7px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-bottom: 10px;
        }
         .btn{ width:100px !important; padding:8px 5px; float:left; background:#3498db; -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px; text-align:center !important; outline:0; border:none; color:#fff;}
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Hostel Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="HostelBuilding.aspx">Hostel Building</a></li>
             <li><a href="HostelWing.aspx">Hostel Wing</a></li>
            <li><a href="HostelFloor.aspx">Hostel Floor</a></li>
            <li><a href="HostelRoom.aspx">Hostel Room</a></li>
            <li><a href="HostelBed.aspx">Hostel Bed</a></li>
            <li><a href="HostelFeeHead.aspx">Hostel Fee</a></li>
            <li><a href="HostelStudentMaster.aspx">Hostel Student Entry</a></li>
            <li class="active1"><a href="HostelInquiry.aspx">Hostel Enquiry</a></li>
        </ul>
    </div>

<section class="content">
  <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" CssClass="efficacious" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" 
                                                                DataKeyNames="HostelinquiryId" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing"  >
                                                                <Columns>
                                                                   <asp:BoundField DataField="vchHostelType" HeaderText="Hostel Type" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchRoomType" HeaderText="Room Type" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStudentName" HeaderText="Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchFinYear" HeaderText="Fin. Year" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStandard" HeaderText="Standard" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchDivision" HeaderText="Division" ReadOnly="True"/> 
                                                                    <asp:BoundField DataField="vchMobile" HeaderText="Mobile" ReadOnly="True" />                                                                                                                                    
                                                                    <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True"/>
                                                                    <asp:BoundField DataField="vchMessage" HeaderText="Message" ReadOnly="True" />
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" style="  width: 22% !important; outline:0;" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete" >
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" style="  width: 22% !important; outline:0;" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     
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
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table width="50%"  style="text-align: right; margin:0 auto;">
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        &nbsp;
                                                    </td>
                                                    <td align="justify">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label9" runat="server" Text="Type of Hostel"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                  <asp:DropDownList ID="drpHostelType" runat="server" AutoPostBack="True">
                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                             <asp:ListItem Value="1">Boys</asp:ListItem>
                                                             <asp:ListItem Value="2">Girls</asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label10" runat="server" Text="Type of Room Required"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                  <asp:DropDownList ID="drpRoomType" runat="server" AutoPostBack="True">
                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                             <asp:ListItem>Single</asp:ListItem>
                                                             <asp:ListItem>Double</asp:ListItem>
                                                              <asp:ListItem>Tripple</asp:ListItem>
                                                             <asp:ListItem>Fourple</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label5" runat="server" Text="Name of Applicant"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtName" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="15" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="txtName"
                                                            Display="None" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                                            runat="server" Enabled="True" TargetControlID="R1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label6" runat="server" Text="Financial Year"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                  <asp:DropDownList ID="drpFinYear" runat="server" AutoPostBack="True">                                                           
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label3" runat="server" Text="Standard"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtStandard" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="15" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="txtStandard"
                                                            Display="None" ErrorMessage="Please Enter Standard"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                            runat="server" Enabled="True" TargetControlID="R2">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label4" runat="server" Text="Division"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtDivision" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="15" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R3" runat="server" ControlToValidate="txtDivision"
                                                            Display="None" ErrorMessage="Please Enter Mobile"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                            runat="server" Enabled="True" TargetControlID="R3">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                        <asp:TextBox ID="txtMobile" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="50" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R4" runat="server" ControlToValidate="txtMobile"
                                                            Display="None" ErrorMessage="Please Enter Mobile"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="R4_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="R4">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="Label1" runat="server" Text="Gender"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpGender" runat="server" AutoPostBack="True">
                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                             <asp:ListItem>Male</asp:ListItem>
                                                             <asp:ListItem>Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                               
                                               <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtAddress" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="250" Width="201px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="R5" runat="server" ControlToValidate="txtAddress"
                                                            Display="None" ErrorMessage="Please Enter Address"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5"
                                                            runat="server" Enabled="True" TargetControlID="R5">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="justify" class="style1">
                                                        <asp:Label ID="Label8" runat="server" Text="Message"></asp:Label>
                                                    </td>
                                                    <td align="justify">
                                                    <asp:TextBox ID="txtMessage" runat="server" AutoComplete="Off" CssClass="input-blue" MaxLength="250" Width="201px"></asp:TextBox>                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                    </td>
                                                    <td align="left">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClientClick="return ConfirmInsertUpdate();"
                                                            Text="Submit" onclick="btnSubmit_Click" />
                                                        <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                                            Text="Clear" Visible="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="auto-style5" colspan="2">
                                                        &nbsp;
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
</section>
</asp:Content>


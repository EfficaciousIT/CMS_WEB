<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmUploadMark.aspx.cs" Inherits="frmUploadMark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Mark Uploading
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">Mark Uploading</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                <tr>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="ddlCAT" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="ddlCAT_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" Text="Status" ></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="ddlQualified" runat="server" AutoPostBack="True"
                                                onselectedindexchanged="ddlQualified_SelectedIndexChanged">
                                                <asp:ListItem >---Select---</asp:ListItem>
                                             <asp:ListItem Value="1">Qualified</asp:ListItem>
                                            <asp:ListItem Value="0">Pending</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="70%" 
                                                                DataKeyNames="intTest_id" onrowediting="grvDetail_RowEditing"  >
                                                                <Columns>
                                                                    <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                     <asp:BoundField DataField="candiateName" HeaderText="Student Name" ReadOnly="True" />
                                                                      <asp:BoundField DataField="marks1" HeaderText="Obtained Mark" ReadOnly="True" />
                                                                     <asp:BoundField DataField="TotalMarks" HeaderText="Out Of Mark" ReadOnly="True" />
                                                                     <asp:BoundField DataField="intPercentage" HeaderText="Percentage" ReadOnly="True" />
                                                                     <asp:BoundField DataField="castType" HeaderText="Category" ReadOnly="True" 
                                                                        Visible="False"/>
                                                                       <asp:TemplateField HeaderText="Select Qualified">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="true"
                                                                        OnClientClick="return confirm('Do You Really Want To Qualify Selected Candidate ?');"
                                                                                ImageUrl="~/images/edit.png" />
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
            <center>
                <br />
                <div>
                    <table width="60%">
                        <tr>
                            <td align="left">
                                <table width="50%">
                                    <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="lblSTD1" runat="server" Text="Standard"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="drpStandard_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="Label2" runat="server" Text="Student"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpStudent" runat="server"  >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Total Marks"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:TextBox ID="txtTotalMarks" runat="server" CssClass="input-blue"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Total Marks"
                                                Display="None" ControlToValidate="txtTotalMarks" CssClass="textsize">
                                            </asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Obtained Marks"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:TextBox ID="txtMarks1" runat="server" CssClass="input-blue"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Obtained Marks"
                                                Display="None" ControlToValidate="txtMarks1" CssClass="textsize">
                                            </asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                   
                                      <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpCategory" runat="server">
                                            <%--<asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>Open</asp:ListItem>
                                            <asp:ListItem>SC</asp:ListItem>
                                            <asp:ListItem>ST</asp:ListItem>
                                            <asp:ListItem>OBC</asp:ListItem>
                                            <asp:ListItem>Management Quota</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;
                            </td>
                        </tr>
                    </table>                   
                    <table width="28%">
                        <tr>
                            
                            <td width="50%" align="right">
                                <asp:Button ID="btnSubmit1" runat="server" CssClass="efficacious_send" Text="Submit"
                                    onclick="btnSubmit1_Click"  />
                            </td>
                            <td width="50%" align="right">
                                <asp:Button ID="btnClear1" CssClass="efficacious_send" runat="server" Text="Clear"
                                    Visible="False"  />
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


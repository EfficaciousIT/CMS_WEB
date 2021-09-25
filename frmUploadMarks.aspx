<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmUploadMarks.aspx.cs" Inherits="frmUploadMarks" Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <center>
                <br />
                <div>
                    <table width="60%">
                        <tr>
                            <td align="left">
                                <table width="50%">
                                    <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="lblSTD1" runat="server" Text="STD"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Total Marks"></asp:Label>
                                        </td>
                                        <td style="float: left; width: 40%; margin: 0 auto;">
                                            <asp:TextBox ID="txtTotalMarks" runat="server" CssClass="input-blue"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Total Marks"
                                                Display="None" ControlToValidate="txtTotalMarks" CssClass="textsize">
                                            </asp:RequiredFieldValidator>
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
                    <div id="div2" runat="server" style="overflow: scroll; height: 280px;">
                        <asp:GridView ID="grvMarks" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table "
                            EnableViewState="true" DataKeyNames="intTest_id" OnRowDataBound="grvMarks_RowDataBound"
                            Width="80%">
                            <Columns>
                                <asp:TemplateField HeaderText="Candiate Name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="intTest_id" Text='<%#Eval("intTest_id") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candiate Name" Visible="true" >
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="intTest_id" Text='<%#Eval("candiateName") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Justify" Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px" VerticalAlign="Bottom"/>
                                </asp:TemplateField>
                                <asp:BoundField Visible="false" DataField="candiateName" HeaderText="Candiate Name" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="120px"/>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Marks 1">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMarks1" EnableViewState="false" CssClass="input-blue" onkeypress="return forNumeric(event)"
                                            runat="server" Width="60%"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks 2">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMarks2" runat="server" onkeypress="return forNumeric(event)"
                                            CssClass="input-blue" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks 3">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMarks3" runat="server" onkeypress="return forNumeric(event)"
                                            CssClass="input-blue" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks 4">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMarks4" runat="server" onkeypress="return forNumeric(event)"
                                            CssClass="input-blue" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks 5">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMarks5" runat="server" onkeypress="return forNumeric(event)"
                                            CssClass="input-blue" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpCategory" runat="server">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>Open</asp:ListItem>
                                            <asp:ListItem>SC</asp:ListItem>
                                            <asp:ListItem>ST</asp:ListItem>
                                            <asp:ListItem>OBC</asp:ListItem>
                                            <asp:ListItem>Management Quota</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table width="28%">
                        <tr>
                            <td width="50%" align="right">
                                <asp:Button ID="btnSubmit1" runat="server" CssClass="efficacious_send" Text="Submit"
                                    Visible="False" OnClick="btnSubmit1_Click" />
                            </td>
                            <td width="50%" align="right">
                                <asp:Button ID="btnClear1" CssClass="efficacious_send" runat="server" Text="Clear"
                                    Visible="False" OnClick="btnClear1_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

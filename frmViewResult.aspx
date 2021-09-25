<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmViewResult.aspx.cs" Inherits="frmViewResult" Title="E-SMARTs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header">
        <h1>
            View Result
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Admission</a></li>
            <li class="active">View Result</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <div class="efficacious">
                    <table width="60%">
                        <tr>
                            <td align="left">
                                <table width="60%" style="margin: 0 auto; float: left; padding-left: 50px;">
                                    <tr>
                                        <td style="padding-left: 2px">
                                            <asp:Label ID="lblSTD1" runat="server" Style="text-align: right;" Text="STD"></asp:Label>
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="float: left; width: 40%; margin: 0 auto;">
                                            &nbsp;
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
                    <div id="div2" runat="server" style="min-height: 280px;">
                        <asp:GridView ID="grvCandiateCount" runat="server" Style="margin-bottom: 20px;" CssClass="table  tabular-table "
                            EnableViewState="true" Width="50%">
                        </asp:GridView>
                        <asp:GridView ID="grvMarks" runat="server" Style="margin-bottom: 20px;" AutoGenerateColumns="False"
                            CssClass="table  tabular-table " EnableViewState="true" Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Sub1" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                            runat="server" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub2" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub3">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub3" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub4">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub5">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub6">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub7">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="grdCandidate" AutoGenerateColumns="false" runat="server" Style="margin-bottom: 20px;"
                            CssClass="table  tabular-table " EnableViewState="true" Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("intTest_id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFatherMobile" runat="server" Text='<%#Eval("vchfathermobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="candiateName" HeaderText="Candiate Name">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Marks" HeaderText="Marks">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="castType" HeaderText="Category">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table width="28%">
                        <tr>
                            <td width="50%" align="right">
                                <asp:Button ID="btnSubmit1" runat="server" CssClass="efficacious_send" Text="Search"
                                    Visible="true" OnClick="btnSubmit1_Click" />
                            </td>
                            <td width="50%" align="right">
                                <asp:Button ID="btnSub" CssClass="efficacious_send" runat="server" Text="Submit"
                                    Visible="true" OnClick="btnSub_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

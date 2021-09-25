<%@ Page Title="FrmTraning" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="FrmTraning.aspx.cs" Inherits="FrmTraning" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="565px"
        Width="840px">
        <asp:TabPanel runat="server" HeaderStyle-Font-Size="5px" HeaderText="Traningentry"
            ID="Traningentry" Style="display: none;" Font-Size="10px">
            <HeaderTemplate>
                Traning Details Entry</HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="font-weight: bolder; margin: 10px 0;" align="center" width="100%">
                            <tr>
                                <td nowrap="nowrap" class="style24">
                                    <asp:Label ID="Label1" runat="server" CssClass="textcss" Font-Bold="False">Academic Year:</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ValidationGroup="b" Font-Names="Verdana" Font-Size="10px"
                                        ForeColor="Black" Height="19px" Width="86px" ID="DropDownList1" MaxLength="50"
                                        OnSelectedIndexChanged="DropDownTran1_SelectedIndexChanged" Style="margin-left: 0px">
                                        <asp:ListItem>2014-2015</asp:ListItem>
                                        <asp:ListItem>2013-2014</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="8" class="textheadcss">
                                    Traning Details Entry<br />
                                    <br />
                                </td>
                                <caption>
                                    <br />
                                </caption>
                            </tr>
                        </table>
                        <table id="details" style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                            <tr id="Tran1" runat="server" visible="False">
                                <td id="Tran10" align="right" runat="server" height="20px" colspan="1">
                                    <asp:Label ID="lblvchno" runat="server" CssClass="textcss" Height="20px" Font-Bold="False">Type Of Traning</asp:Label>
                                </td>
                                <td id="Tran11" runat="server" class="style25" height="20px" colspan="3">
                                    <asp:TextBox ID="txtvchmake0" runat="server" Font-Names="Verdana" ForeColor="Black"
                                        MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="Tran2" runat="server" visible="False">
                                <td id="Tran20" align="right" runat="server" height="20px">
                                    <asp:Label ID="lblvchmake" runat="server" CssClass="textcss" Font-Bold="False">From Date</asp:Label>
                                </td>
                                <td id="Tran21" runat="server">
                                    <asp:TextBox ID="txtvchmake" runat="server" Font-Names="Verdana" ForeColor="Black"
                                        MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton11" runat="server" Height="19px" src="images/Calender1.jpg"
                                        Width="26px" />
                                </td>
                                <td id="Tran22" runat="server">
                                    <asp:Label ID="lblvchmake0" runat="server" CssClass="textcss" Font-Bold="False">To Date</asp:Label>
                                </td>
                                <td id="Tran23" runat="server">
                                    <asp:TextBox ID="txtvchmake2" runat="server" CssClass="textsize" Font-Names="Verdana"
                                        ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton15" runat="server" Height="19px" src="images/Calender1.jpg"
                                        Width="26px" />
                                </td>
                            </tr>
                            <tr id="Tran3" runat="server" visible="False">
                                <td id="Tran31" align="right" runat="server" class="style27" colspan="1">
                                    <asp:Label ID="lblvchmake1" runat="server" CssClass="textcss" Font-Bold="False">Timing </asp:Label>
                                </td>
                                <td id="Tran32" runat="server" class="style27" colspan="3">
                                    <asp:TextBox ID="TextBoxDA" runat="server" Font-Names="Verdana" ForeColor="Black"
                                        MaxLength="20" ValidationGroup="b" CssClass="textsize"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="Tran4" runat="server" visible="False">
                                <td id="Tran41" align="right" runat="server" height="20px">
                                    <asp:Label ID="Label9" runat="server" CssClass="textcss" Font-Bold="False">Traning For</asp:Label>
                                </td>
                                <td id="Tran42" runat="server" height="20px" colspan="3">
                                 <asp:DropDownList ID="DropDownt" runat="server" Font-Names="Verdana" Font-Size="10px"
                                ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownt_SelectedIndexChanged"
                                ValidationGroup="b" Height="18px" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="Select">-Select-</asp:ListItem>
                                <asp:ListItem Value="student">Student</asp:ListItem>
                                <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                <asp:ListItem Value="Staff">Staff</asp:ListItem>
                            </asp:DropDownList>
                                       
                                </td>
                            </tr>
                        </table>
                        <table style="font-weight: bolder; width: 70%; margin: 10px 0;" align="center">
                            <tr id="Tran5" runat="server" visible="False">
                                <td id="Tran51" runat="server" >
                                    <asp:Label ID="Label86" runat="server" CssClass="textcss" Font-Bold="False">Standard</asp:Label>
                                </td>
                                <td id="Tran52" runat="server" >
                                    <asp:DropDownList ID="DropDownList37" runat="server" Font-Names="Verdana" ForeColor="Black"
                                        MaxLength="50" OnSelectedIndexChanged="DropDownTran4_SelectedIndexChanged" ValidationGroup="b"
                                        Width="71px" CssClass="textcss">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>1 st</asp:ListItem>
                                        <asp:ListItem>2 nd</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td id="Tran53" runat="server">
                                    <asp:Label ID="Label87" runat="server" CssClass="textcss" Font-Bold="False">Division</asp:Label>
                                </td>
                                <td id="Tran54" runat="server">
                                    <asp:DropDownList ID="DropDownList38" runat="server" Font-Names="Verdana" ForeColor="Black"
                                        MaxLength="50" OnSelectedIndexChanged="DropDownTran5_SelectedIndexChanged" ValidationGroup="b"
                                        CssClass="textcss">
                                    </asp:DropDownList>
                                </td>
                            
                            </tr>
                            <tr id="Tran6" runat="server" visible="False">
                                <td id="Tran61" nowrap="nowrap" runat="server" >
                                    <asp:Label ID="Label407" runat="server" CssClass="textcss" Font-Bold="False" 
                                        Width="50px">Department</asp:Label>
                                </td>
                                <td id="Tran62" runat="server"  >
                                    <asp:DropDownList ID="DropDownList278" runat="server" Font-Names="Verdana" ForeColor="Black"
                                        MaxLength="50" OnSelectedIndexChanged="DropDownTran6_SelectedIndexChanged" ValidationGroup="b"
                                        CssClass="textcss">
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td></td>
                              
                            </tr>
                            <tr id="Card14" runat="server" visible="False">
                                <td id="Td150" colspan="4" align="center" runat="server">
                                    <asp:ImageButton ID="btnsubmit" runat="server" ForeColor="#999999" ImageUrl="~/images/submit.png"
                                        ValidationGroup="b" OnClick="btnsubmit_Click" CssClass="textcss" Width="61px" />
                                    <asp:ImageButton ID="btnclr" runat="server" ImageUrl="~/images/cancel.png" CssClass="textcss"
                                        AlternateText="Cancel" Width="24px" />&#160;&#160;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style24
        {
            width: 101px;
        }
        .style25
        {
            height: 24px;
        }
        .style27
        {
            height: 3px;
        }
        .style30
        {
            height: 22px;
        }
    </style>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmViewVacationsDisplay.aspx.cs" Inherits="frmViewVacationsDisplay"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:TabContainer ID="TabHolientry" runat="server" ActiveTabIndex="1" Height="565px"
        Width="946px">
        <asp:TabPanel runat="server" HeaderText="TabPanelcardentry" ID="TabPanelholientry">
            <HeaderTemplate>
                Vacation Entry
            </HeaderTemplate>
            <ContentTemplate>
                <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                    <table id="Table1" visible="false" style="font-weight: bolder; width: 496px; margin: 10px 0;"
                        align="center">
                        <tr>
                            <td colspan="2" align="center">
                                Enter Vacation
                            </td>
                        </tr>
                        <tr id="TempNo" runat="server">
                            <td id="Td4" align="left" runat="server">
                                <asp:Label ID="Label8" runat="server">Vacation Name</asp:Label>
                            </td>
                            <td id="Td5" runat="server">
                                <asp:TextBox runat="server" MaxLength="20" ValidationGroup="b" Font-Names="Verdana"
                                    Font-Size="Small" ForeColor="Black" Width="200px" ID="TextBox1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Temp2" runat="server">
                            <td id="Tdf1" align="left" runat="server">
                                <asp:Label ID="Label3" runat="server">From Date:</asp:Label>
                            </td>
                            <td id="Tdf2" runat="server">
                                <asp:TextBox ID="TextBox5" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" src="images/Calender1.jpg"
                                    Width="26px" />
                            </td>
                        </tr>
                        <tr id="Temp3" runat="server">
                            <td id="Td3" align="left" runat="server">
                                <asp:Label ID="Label4" runat="server">To Date:</asp:Label>
                            </td>
                            <td id="Td1" runat="server">
                                <asp:TextBox ID="TextBox7" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="19px" src="images/Calender1.jpg"
                                    Width="26px" />
                            </td>
                        </tr>
                        <tr id="Temp4" runat="server">
                            <td id="Td2" align="left" runat="server">
                                <asp:Label ID="Label5" runat="server">Total no days</asp:Label>
                            </td>
                            <td id="Td6" runat="server">
                                <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButtonr" runat="server" Height="19px" src="images/Calender1.jpg"
                                    Width="26px" />
                            </td>
                        </tr>
                        <tr id="Tr4" runat="server">
                            <td id="Td18" align="left" runat="server">
                                <asp:Label ID="Label7" runat="server">Type of Vacation:</asp:Label>
                            </td>
                            <td id="Td19" runat="server">
                                <asp:TextBox ID="TextBox6" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                Vacation Applicable For
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td id="Td11" align="left" runat="server">
                                <asp:Label ID="Label1" runat="server">Standard Id</asp:Label>
                            </td>
                            <td id="Td12" runat="server">
                                <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Tr2" runat="server">
                            <td id="Td13" align="left" runat="server">
                                <asp:Label ID="Label2" runat="server">Division Id</asp:Label>
                            </td>
                            <td id="Td14" runat="server">
                                <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server">
                            <td id="Td15" align="left" runat="server" style="height: 51px">
                                <asp:Label ID="Label6" runat="server">Department Id:</asp:Label>
                            </td>
                            <td id="Td16" runat="server" style="height: 51px">
                                <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Temp7" runat="server">
                            <td id="Td9" align="left" runat="server">
                                <asp:Label ID="Label10" runat="server">Student Id</asp:Label>
                            </td>
                            <td id="Td10" runat="server">
                                <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" Width="200px" Height="59px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Temp15" runat="server">
                            <td id="Td17" colspan="2" align="center" runat="server">
                                <asp:ImageButton ID="ImageButton8" runat="server" ForeColor="#999999" Height="28px"
                                    ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" />
                                <asp:ImageButton ID="ImageButton9" runat="server" Height="28px" ImageUrl="~/images/cancel.png"
                                    Width="64px" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabHoliDetai" runat="server" HeaderText="TabPanelIdcard">
            <HeaderTemplate>
                Vacation Details
            </HeaderTemplate>
            <ContentTemplate>
                <center>
                    <table style="font-weight: bolder; width: 496px; margin: 10px 0;" align="center">
                        <tr align="center">
                            <td>
                                View Vacations
                            </td>
                        </tr>
                        <tr id="vacatval0" runat="server" visible="False">
                            <td id="Td7" align="left" style="width: 306px" runat="server">
                                <asp:Label ID="Label11" runat="server">Type of User:</asp:Label>
                                <asp:DropDownList ID="DropDownList12" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="Dropvacatiadmin_SelectedIndexChanged"
                                    ValidationGroup="b" Height="18px" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="Select">-Select-</asp:ListItem>
                                    <asp:ListItem Value="student">Student</asp:ListItem>
                                    <asp:ListItem Value="Staff">Staff</asp:ListItem>
                                    <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="vacatval1" runat="server" visible="False">
                            <td id="Td8" align="left" style="width: 306px; height: 46px;" runat="server">
                                <asp:Label ID="Label19" runat="server">Type of User:</asp:Label>
                                <asp:DropDownList ID="DropDownList13" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="Drophovacat_SelectedIndexChanged"
                                    ValidationGroup="b" Height="18px" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="Select">-Select-</asp:ListItem>
                                    <asp:ListItem Value="student">Student</asp:ListItem>
                                    <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="GridVacation" runat="server" visible="False">
                            <td style="padding: 10px 0 20px 0;" runat="server">
                                <asp:GridView ID="Gridvacadetails" DataKeyNames="Vacations Name" runat="server" __designer:wfdid="w36"
                                    EmptyDataText="Record not Found." AutoGenerateColumns="False" AllowSorting="True"
                                    Width="856px" AllowPaging="True" OnPageIndexChanging="Gridvacadetails_PageIndexChanging"
                                    OnRowCancelingEdit="Gridvacadetails_RowCancelingEdit" CssClass="mGrid" OnRowDeleting="Gridvacadetails_RowDeleting"
                                    OnRowEditing="Gridvacadetails_RowEditing" 
                                    onrowdatabound="Gridvacadetails_RowDataBound">
                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    ImageUrl="images/delete.png" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                    Text="Delete" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" Visible="true" Font-Underline="true" runat="server">View</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Student Id" HeaderText="Student Id" />
                                        <asp:BoundField DataField="Standard Id" HeaderText="Standard Id" />
                                        <asp:BoundField DataField="Division Id" HeaderText="Division Id" />
                                        <asp:BoundField DataField="Department Id" HeaderText="Department Id" />
                                        <asp:BoundField DataField="Vacations Name" HeaderText="Vacations Name" />
                                        <asp:BoundField DataField="From Date" HeaderText="From Date" />
                                        <asp:BoundField DataField="To Date" HeaderText="To Date" />
                                        <asp:BoundField DataField="Total no days" HeaderText="Total no days" />
                                        <asp:BoundField DataField="Type of Vacations" HeaderText="Type of Vacations" />
                                    </Columns>
                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>

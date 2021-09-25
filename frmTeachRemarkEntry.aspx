<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmTeachRemarkEntry.aspx.cs" Inherits="frmTeachRemarkEntry" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 110px;
        }
        .style2
        {
            height: 34px;
            width: 183px;
        }
        .style4
        {
            width: 221px;
        }
        .style6
        {
            width: 183px;
        }
        .style7
        {
            width: 159px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
<asp:TabContainer ID="TabContainer2" runat="server" Width="830px" 
                                            ActiveTabIndex="0">
                                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                <HeaderTemplate>
                                                    Teacher Remark Entry</HeaderTemplate>
                                                <ContentTemplate>
                                                    <center>
                                                        <asp:Panel ID="panel_Calender" runat="server" Height="440px">
    <table style="font-weight: bolder; width: 100; margin: 10px 0;" align="center" width="100%">
        <%--<tr>
            <td nowrap="nowrap" class="style1">
                <asp:Label ID="Label1" runat="server" CssClass="textcss" Font-Bold="False">Academic Year</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList runat="server" ValidationGroup="b" Font-Names="Verdana" 
                    ForeColor="Black"  ID="DropDownLisaca" MaxLength="50"
                    OnSelectedIndexChanged="DropDownLisaca_SelectedIndexChanged" 
                    CssClass="dropdowncs">
                    <asp:ListItem>2014-2015</asp:ListItem>
                    <asp:ListItem>2013-2014</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
        <%--<tr align="center">
            <td colspan="2" class="textheadcss">
                <asp:Label ID="Label5" runat="server" CssClass="textheadcss" Font-Bold="False">Teacher Remark Entry</asp:Label><br />
                <br />
            </td>
            <caption>
                <br />
            </caption>
        </tr>--%>
    </table>
    <table id="details" style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
    <tr><td colspan="4" class="textheadcss">
                <asp:Label ID="Label5" runat="server" CssClass="textheadcss" Font-Bold="False">Teacher Remark Entry</asp:Label><br />
                <br />
            </td></tr>
        <tr id="Card2" runat="server">
        <td class="style4"></td>
            <td id="Td3" runat="server" align="center" class="style6">
                <asp:Label ID="Label408" runat="server" CssClass="textcss" Font-Bold="False">Standard</asp:Label>
            </td>
            <td id="Td4" runat="server" align="left" class="style7">
                <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Verdana" ForeColor="Black"
                    MaxLength="50" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ValidationGroup="b"
                    Width="71px" CssClass="textcss">
                    <asp:ListItem Value="select" Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem Value="I">I st</asp:ListItem>
                    <asp:ListItem Value="II">II nd</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </td>
            <td></td>
        </tr>
        <tr id="Card3" runat="server">
        <td class="style4"></td>
            <td id="Td5" runat="server" align="center" class="style6">
                <asp:Label ID="Label2" runat="server" CssClass="textcss" Font-Bold="False">Division</asp:Label>
           </td>
           <td id="Td6" runat="server" align="left" class="style7">
                <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Verdana" ForeColor="Black"
                    MaxLength="50" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" ValidationGroup="b"
                    Width="71px" CssClass="textcss">
                    <asp:ListItem Value="select" Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem Value="A">A</asp:ListItem>
                    <asp:ListItem Value="B">B</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </td>
            <td></td>
        </tr>
        <tr id="Card4" runat="server">
        <td class="style4"></td>
            <td id="Td7" runat="server" class="style2" align="center">
                <asp:Label ID="Label3" runat="server" CssClass="textcss" Font-Bold="False">Roll No</asp:Label>
            </td>
            <td id="Td8" runat="server" align="left" class="style7">
                <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="Verdana" ForeColor="Black"
                    MaxLength="50" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" ValidationGroup="b"
                    Width="71px" CssClass="textcss">
                    <asp:ListItem Value="select" Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </td>
            <td></td>
        </tr>
        <tr id="Tr1" runat="server">
        <td class="style4"></td>
            <td id="Td1" align="center" runat="server" class="style6">
                <asp:Label ID="Label4" runat="server" CssClass="textcss" Font-Bold="False">Subject</asp:Label>
          </td>
          <td id="Td2" runat="server" align="left" class="style7">
                <asp:DropDownList ID="DropDownList5" runat="server" Font-Names="Verdana" ForeColor="Black"
                    MaxLength="50" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" ValidationGroup="b"
                    Width="71px" CssClass="textcss">
                    <asp:ListItem Value="select" Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem Value="English">English</asp:ListItem>
                    <asp:ListItem Value="Hindi">Hindi</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </td>
            <td></td>
        </tr>
        <tr id="Card7" runat="server">
        <td class="style4"></td>
            <td id="Td9" align="center" runat="server" height="20px" class="style6">
                <asp:Label ID="Label9" runat="server" CssClass="textcss" Font-Bold="False">Remark</asp:Label>
           </td>
           <td id="Td10" runat="server" align="left" class="style7">
                <textarea id="TextArea1" class="textboxcs" rows="5" cols="1" onclick="return TextArea1_onclick()"></textarea>
            </td>
            <td></td>
        </tr>
        <tr id="Card14" runat="server">
            <td id="Td14" runat="server" align="center" colspan="4"><br />
                <asp:ImageButton ID="btnsubmit" runat="server" ForeColor="#999999" ImageUrl="~/images/submit.png"
                    ValidationGroup="b" OnClick="btnsubmit_Click" CssClass="textcss"  Height="26px" />
            
                <asp:ImageButton ID="btnclr" runat="server" ImageUrl="~/images/cancel.png" CssClass="textcss"
                    AlternateText="Cancel" />&#160;&#160;
            </td>
        </tr>
    </table>
    </asp:Panel>
    </center>
                                                </ContentTemplate>
                                            </asp:TabPanel>
    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                <HeaderTemplate>
                                                    Student Remarks</HeaderTemplate>
                                                <ContentTemplate>

    <table style="font-weight: bolder; width: 840px; margin: 10px 0;" align="center">
                    <tr><td colspan="5" align="center"><asp:Label ID="Labsturemark" runat="server" 
                            CssClass="textheadcss" Font-Bold="False">Student Remark</asp:Label></td></tr>
                    <tr>
                                                                <td align="left" nowrap="nowrap">
                                                                    <asp:Label ID="Label6" runat="server" CssClass="textcss" Font-Bold="False">Select Month</asp:Label>&nbsp;&nbsp;
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdowncs" 
                                                                        Font-Names="Verdana">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem>Jan</asp:ListItem>
                                                                        <asp:ListItem>Feb</asp:ListItem>
                                                                        <asp:ListItem>Mar</asp:ListItem>
                                                                        <asp:ListItem>Apr</asp:ListItem>
                                                                        <asp:ListItem>May</asp:ListItem>
                                                                        <asp:ListItem>June</asp:ListItem>
                                                                        <asp:ListItem>July</asp:ListItem>
                                                                        <asp:ListItem>Aug</asp:ListItem>
                                                                        <asp:ListItem Selected="True">Sep</asp:ListItem>
                                                                        <asp:ListItem>Oct</asp:ListItem>
                                                                        <asp:ListItem>Nov</asp:ListItem>
                                                                        <asp:ListItem>Dec</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td align="left" class="style2" nowrap="nowrap">
                                                                    <asp:Label ID="Label7" runat="server" CssClass="textcss" Font-Bold="False">From Date</asp:Label>&nbsp;&nbsp;
                                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textsize" 
                                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="20" Text="01-09-2014" 
                                                                        ValidationGroup="b"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                                        Format="MM/dd/yyyy" TargetControlID="TextBox1">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td align="left" class="style2" nowrap="nowrap">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="textcss" Font-Bold="False">To Date</asp:Label>&nbsp;&nbsp;
                                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="textsize" 
                                                                        Font-Names="Verdana" ForeColor="Black" MaxLength="20" Text="01-09-2014" 
                                                                        ValidationGroup="b"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                                                        Format="MM/dd/yyyy" TargetControlID="TextBox2">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                            </tr>
        </table>
        <table style="font-weight: bolder; width: 840px; margin: 10px 0;" align="center">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="GridViewremark" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    EmptyDataText="No Records Found" Width="820px" 
                    onselectedindexchanged="GridViewremark_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                ImageUrl="images/delete.png" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                Text="Delete" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                ImageUrl="images/icon_edit.png" Text="Delete" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                    <asp:BoundField DataField="dtRoll" HeaderText="Roll No">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dtName" HeaderText="Name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="teachername" HeaderText="Teacher name">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="subject" HeaderText="Subject">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remark" HeaderText="Remark">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="date" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" />                            
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
    </center>
</asp:Content>

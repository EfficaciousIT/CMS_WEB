<%@ Page Title="Teacher Card" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmTeachCard.aspx.cs" Inherits="frmTeachCard" Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    <table>
    <tr>
    <td align="left">
    
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="3" 
        Width="928px" CssClass="MyTabStyle">
       
        <asp:TabPanel ID="TabPanelIdcard" runat="server" HeaderText="TabPanelIdcard" visibility="false">
            <HeaderTemplate>
                Identity Card</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <center>
                <table>
                <tr align="center" id="tr27" runat="server" >
                        <td id="Td140" class="textheadcss" runat="server">
                           Identity Card <br />
                            <br />
                        </td>
                    </tr>
                </table>
                    <table style="font-weight: bolder; width: 399px; margin: 10px 0;" align="center"
                        border="solid">
                        
                        <tr class="noBorder">
                            <td align="center" >
                                <img src="images/Efficacious-Logo.jpg" style="width: 85px; height: 44px;" />&nbsp;
                            </td>
                            <td colspan="2">
                                <span class="textheadcss">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EFFICACIOUS
                                    INFOTECH</span>
                                <br />
                                <span style="font-variant: normal; font-size: xx-small; text-align: center">(G Quare
                                    Business Park,1402,14th Floor,Plot No.25,26,Sec-30,Opp Sanpada Station,Navi Mumbai-400703,Maharashtra)
                                </span>
                            </td>
                        </tr>
                        <tr><td colspan="3"></td></tr>
                        <tr >
                            <td rowspan="7" align="center" >
                                <img src="images/TeacherPics.jpg" style="line-height: normal; height: 96px; width: 83px;" />
                                <br>
                                <span style="font-size: 9px" ><asp:Label ID="Label11" runat="server"  ></asp:Label></span>
                            </td>
                        </tr>
                       
                        <tr runat="server" id="teachname"  class="noBorder">
                            <td runat="server" nowrap="nowrap">
                                <asp:Label ID="Label27" runat="server"  >Teacher Name</asp:Label>
                            </td>
                            <td runat="server">
                                <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" ForeColor="Black"
                                    MaxLength="20" ValidationGroup="b" OnTextChanged="txtvchmake1_TextChanged" BorderStyle="None"
                                     ></asp:TextBox>
                            </td>
                        </tr>
                        
                       
                        <tr id="departid" runat="server" class="noBorder">
                            <td runat="server" nowrap="nowrap">
                                <asp:Label ID="Label29" runat="server"  >Department</asp:Label>
                            </td>
                            <td runat="server">
                                <asp:TextBox ID="TextBox15" runat="server" Font-Names="Verdana" ForeColor="Black"
                                    MaxLength="20" ValidationGroup="b"   OnTextChanged="txtvchmake1_TextChanged"
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="noBorder">
                            <td runat="server"  nowrap="nowrap">
                                <asp:Label ID="lblvchno3" runat="server"  >Contact No.</asp:Label>
                            </td>
                            <td runat="server" >
                                <asp:TextBox ID="TextBox16" runat="server" Font-Names="Verdana"  
                                    ForeColor="Black" MaxLength="20" ValidationGroup="b" OnTextChanged="txtvchmake1_TextChanged"
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td colspan="2"></td></tr>
                        <tr class="noBorder">
                            <td align="right" colspan="2">
                                <asp:Label ID="Label25" runat="server"   Font-Size="10px">Signature Here</asp:Label>
                                <br />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label26" runat="server" BorderStyle="None"   Font-Size="10px">Principle</asp:Label>
                            </td>
                        </tr>
                        <tr class="noBorder">
                            <td align="center" colspan="2">
                                <span style="font-size: 9px">EXCEEDING ALL EXPECTATIONS</span>
                            </td>
                        </tr>
                    </table>
                </center>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanelcarddisplay" runat="server" HeaderText="TabPanelcarddisplay">
            <HeaderTemplate>
                Card Details Display</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="font-weight: bolder; width: 100%; margin: 10px 0;" align="center">
                    <tr id="carddis" runat="server" visible="False">
                        <td id="Td1021" align="center" style="width: 306px" runat="server">
                     <table style="font-weight: bolder; width: 826px; margin: 10px 0;">
                    
                    <tr align="center" id="tr1" runat="server" >
                        <td id="Td1" class="textheadcss" runat="server">
                             Card Details Display
                        </td>
                    </tr>
                    </table>
                      
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;" align="center">
                            <asp:GridView ID="GridView2" runat="server" designer:wfdid="w36" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="cardid"
                                EmptyDataText="Record not Found." Width="100%" Font-Bold="False" HorizontalAlign="Center">
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
                                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                ImageUrl="images/icon_edit.png" Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="cardid" HeaderText="card id" />
                                    <asp:BoundField DataField="cardno" HeaderText="card no" />
                                    <asp:BoundField DataField="StudentId" HeaderText="Student Id" />
                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                    <asp:BoundField DataField="StandardId" HeaderText="Standard Id" />
                                    <asp:BoundField DataField="DivisionId" HeaderText="Division Id" />
                                    <asp:BoundField DataField="StudentName" HeaderText="Name" />
                                    <asp:BoundField DataField="DateofIssue" HeaderText="Issue" />
                                    <asp:BoundField DataField="DateofActivation" HeaderText="Activation" />
                                    <asp:BoundField DataField="DateofExpire" HeaderText="Expire" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanellostcard" runat="server" HeaderText="TabPanellostcard">
            <HeaderTemplate>
                List Lost Cards Details</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table width="100%" align="center" style="padding-top: 10px;">
                    <tr height="25">
                        <td align="center" runat="server" class="textheadcss" nowrap="nowrap">
                            <b>List Lost Cards Details</b>
                        </td>
                    </tr>
                </table>
                    </div>
                <div class="efficacious">
                <table width="90%" align="center">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="Gridlistlostdetails" DataKeyNames="cardno" runat="server" designer:wfdid="w36"
                                EmptyDataText="Record not Found." AutoGenerateColumns="False" AllowSorting="True"
                                Width="100%" AllowPaging="True" OnPageIndexChanging="Gridlistlostdetails_PageIndexChanging"
                                OnRowCancelingEdit="Gridlistlostdetails_RowCancelingEdit" CssClass="mGrid"
                                OnRowDeleting="Gridlistlostdetails_RowDeleting" 
                                OnRowEditing="Gridlistlostdetails_RowEditing" HorizontalAlign="Center">
                                <Columns>
                                    <asp:BoundField DataField="cardno" HeaderText="Card no" />
                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                    <asp:BoundField DataField="StudentName" HeaderText="Name" />
                                    <asp:BoundField DataField="dateofissue" HeaderText="Issue" />
                                    <asp:BoundField DataField="dateofactivation" HeaderText="Activation" />
                                    <asp:BoundField DataField="dateofexpire" HeaderText="Expire" />
                                    <asp:BoundField DataField="loststatus" HeaderText="Status" />
                                    <asp:BoundField DataField="CardlostDate" HeaderText="Lost Date" />
                                    
                                        
                                </Columns>
                                <PagerStyle CssClass="pgr"></PagerStyle>
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPaneltempcardentry" runat="server" HeaderText="TabPaneltempcardentry">
            <HeaderTemplate>
                TempEntry</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
                <table style="font-weight: bolder; width: 100; margin: 10px 0;" align="center">
                    <tr align="center">
                        <td class="textheadcss" colspan="8">
                            Temperory Card Entry<br />
                            <br />
                        </td>
                    </tr>
                    <tr id="Tr2" runat="server" visible="False">
                        <td id="Td74" style="width: 96px" nowrap="nowrap" runat="server">
                            <asp:Label ID="Label62"   runat="server" Font-Bold="False">From Date</asp:Label>
                        </td>
                        <td id="Td75" runat="server">
                            <asp:TextBox ID="TextBox4" CssClass="textsize" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender8" Format="MM/dd/yyyy" TargetControlID="TextBox4"
                                    runat="server" Enabled="True">
                                </asp:CalendarExtender>
                        </td>
                        <td id="Td76" runat="server"  nowrap="nowrap">
                            <asp:Label ID="Label63" runat="server"   Font-Bold="False">To Date</asp:Label>
                        </td>
                        <td id="Td77" runat="server">
                            <asp:TextBox ID="TextBox30" runat="server" CssClass="textsize"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" 
                                Format="MM/dd/yyyy" TargetControlID="TextBox30">
                            </asp:CalendarExtender>
                        </td>
                        <td id="Td78" runat="server" nowrap="nowrap">
                            <asp:Label ID="Label64" runat="server"   Font-Bold="False">Month</asp:Label>
                        </td>
                        <td id="Td79" runat="server" nowrap="nowrap">
                            <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Verdana" 
                                ForeColor="Black"  MaxLength="50" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                ValidationGroup="b"  CssClass="dropdowncs">
                            </asp:DropDownList>
                        </td>
                        <td id="Td80" runat="server" nowrap="nowrap">
                            <asp:Label ID="Label65" runat="server"   Font-Bold="False">Type Of Card</asp:Label>
                        </td>
                        <td id="Td81" runat="server" >
                            <asp:DropDownList runat="server" ValidationGroup="b" Font-Names="Verdana" 
                                ForeColor="Black" ID="DropDownList6" MaxLength="50"
                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" 
                                CssClass="dropdowncs">
                                <asp:ListItem Selected="True" Value="Select">-Select-</asp:ListItem>
                                <asp:ListItem Value="student">Activated Card</asp:ListItem>
                                <asp:ListItem Value="Staff">Pending Activation</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="Tr13" runat="server" visible="False">
                        <td id="Td82" style="width: 96px" nowrap="nowrap" runat="server" rowspan="4">
                            <asp:Label ID="Label66" runat="server"   Font-Bold="False">Type Of User</asp:Label>
                        </td>
                        <td id="Td83" runat="server" rowspan="4">
                            <asp:DropDownList ID="DropDownList7" runat="server" Font-Names="Verdana"
                                ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="Drophovacat_SelectedIndexChanged"
                                ValidationGroup="b"  AutoPostBack="True" 
                                CssClass="dropdowncs">
                                <asp:ListItem Selected="True" Value="Select">-Select-</asp:ListItem>
                                <asp:ListItem Value="student">Student</asp:ListItem>
                                <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                <asp:ListItem Value="Staff">Staff</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="Tr14" runat="server" visible="False">
                        <td id="Td84" runat="server">
                            <asp:Label ID="Label67" runat="server"   Font-Bold="False">Standard</asp:Label>
                        </td>
                        <td id="Td85" runat="server">
                            <asp:DropDownList ID="DropDownList29" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                ValidationGroup="b" CssClass="dropdowncs">
                            </asp:DropDownList>
                        </td>
                        <td id="Td86" runat="server" >
                            <asp:Label ID="Label68" runat="server"   Font-Bold="False">Division</asp:Label>
                        </td>
                        <td id="Td87" runat="server" >
                            <asp:DropDownList ID="DropDownList30" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                ValidationGroup="b" CssClass="dropdowncs">
                            </asp:DropDownList>
                        </td>
                        <td id="Td88" runat="server"  nowrap="nowrap">
                            <asp:Label ID="Label69" runat="server"   Font-Bold="False">Roll No</asp:Label>
                        </td>
                        <td id="Td89" runat="server" >
                            <asp:TextBox ID="TextBox36" runat="server" CssClass="textsize"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Tr15" runat="server" visible="False">
                        <td id="Td90" runat="server" >
                            <asp:Label ID="Label70" runat="server"   Font-Bold="False">Name</asp:Label>
                        </td>
                        <td id="Td91" runat="server">
                            <asp:TextBox ID="TextBox37" runat="server" CssClass="textsize"></asp:TextBox>
                        </td>
                        <td id="Td92" runat="server" >
                            <asp:Label ID="Label71" runat="server"   Font-Bold="False">Surname</asp:Label>
                        </td>
                        <td id="Td93" runat="server" >
                            <asp:TextBox ID="TextBox38" runat="server" CssClass="textsize"></asp:TextBox>
                        </td>
                        <td id="Td94" runat="server" >
                            <asp:Label ID="Label501" runat="server"   Font-Bold="False">Card Id</asp:Label>
                        </td>
                        <td id="Td431" runat="server">
                            <asp:TextBox ID="TextBox241" runat="server" CssClass="textsize"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Tr81" runat="server" visible="False">
                        <td id="Td551"  nowrap="nowrap" runat="server">
                            <asp:Label ID="Label402" runat="server"   Font-Bold="False">Department</asp:Label>
                        </td>
                        <td id="Td562" runat="server">
                            <asp:DropDownList ID="DropDownList202" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="50" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                ValidationGroup="b"  CssClass="dropdowncs">
                                <asp:ListItem Value="select" Selected="True">Select</asp:ListItem>
                                <asp:ListItem>Teacher</asp:ListItem>
                                <asp:ListItem>Staff</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td id="Td572" runat="server"  nowrap="nowrap">
                            &nbsp;
                        </td>
                        <td id="Td582" runat="server">
                            &nbsp;
                        </td>
                        <td id="Td592" runat="server" >
                            &nbsp;
                        </td>
                        <td id="Td602" runat="server" >
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table id="Table1" visible="false" style="font-weight: bolder; width: 496px; margin: 10px 0;"
                    align="center">
                    <tr id="TempNo" runat="server" visible="False">
                        <td id="Td4" align="left" runat="server">
                            <asp:Label ID="Label8" runat="server"   Font-Bold="False">Temporary Card No</asp:Label>
                        </td>
                        <td id="Td5" runat="server" class="textcss">
                            TSS4001
                        </td>
                    </tr>
                    <tr id="Temp2" runat="server" visible="False">
                        <td align="left" runat="server">
                            <asp:Label ID="Label3" runat="server"   Font-Bold="False">Date of Issue</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox5" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" Format="MM/dd/yyyy" TargetControlID="TextBox5"
                                    runat="server" Enabled="True">
                                </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="Temp3" runat="server" visible="False">
                        <td align="left" runat="server">
                            <asp:Label ID="Label4" runat="server"   Font-Bold="False">Date of Expire</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox7" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender11" Format="MM/dd/yyyy" TargetControlID="TextBox7"
                                    runat="server" Enabled="True">
                                </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="Temp4" runat="server" visible="False">
                        <td align="left" runat="server">
                            <asp:Label ID="Label5" runat="server"   Font-Bold="False">Date of Activation</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender12" Format="MM/dd/yyyy" TargetControlID="TextBox12"
                                    runat="server" Enabled="True">
                                </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="Temp7" runat="server" visible="False">
                        <td align="left" runat="server">
                            <asp:Label ID="Label10" runat="server"   Font-Bold="False">Temporary Status</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox14" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Temp10" runat="server" visible="False">
                        <td align="left" runat="server">
                            <asp:Label ID="Label20" runat="server"   Font-Bold="False">Received By</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox17" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Temp11" runat="server" visible="False">
                        <td align="left" runat="server" class="textcss">
                            <asp:Label ID="Label21" runat="server" Font-Bold="False">Fee Paid Status</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox18" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Temp12" runat="server" visible="False">
                        <td align="left" runat="server">
                            <asp:Label ID="Label22" runat="server"   Font-Bold="False">Fee Amount</asp:Label>
                        </td>
                        <td runat="server">
                            <asp:TextBox ID="TextBox19" runat="server" Font-Names="Verdana" 
                                ForeColor="Black" MaxLength="20" ValidationGroup="b" 
                                 ></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Temp15" runat="server" visible="False">
                        <td colspan="2" align="center" runat="server">
                            <asp:ImageButton ID="ImageButton8" runat="server" ForeColor="#999999" Height="28px"
                                ImageUrl="~/images/submit.png" ValidationGroup="b" Width="64px" OnClick="ImageButton8_Click" />
                            <asp:ImageButton ID="ImageButton9" runat="server" Height="28px" ImageUrl="~/images/cancel.png"
                                Width="64px" />&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                    </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPaneltempcardt" runat="server" HeaderText="TabPaneltempcardt">
            <HeaderTemplate>
                Temperory issued</HeaderTemplate>
            <ContentTemplate>
                <div class="efficacious">
            <table>
            
            <tr runat="server"><td runat="server">
                <table style="font-weight: bolder; width: 826px; margin: 10px 0;">
                    
                    <tr align="center" id="tr25" runat="server" >
                        <td id="Td138" class="textheadcss" runat="server">
                            Temperory Issued Card
                        </td>
                    </tr>
                    </td>
                    </tr>
                        <tr runat="server">
                            <td align="center" style="padding: 10px 0 20px 0;" runat="server" 
                                class="textcss">
                                <asp:GridView ID="GridViewTempDis" runat="server"  
                                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                    CssClass="mGrid" DataKeyNames="Tempcardno" EmptyDataText="Record not Found." 
                                    HorizontalAlign="Center" Width="100%">
                                    <Columns>
                                        
                                        <asp:BoundField DataField="Tempcardno" HeaderText="card no" />
                                    
                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                     
                                        <asp:BoundField DataField="StudentName" HeaderText="Name" />
                                        <asp:BoundField DataField="DateofIssue" HeaderText="Issue" />
                                        <asp:BoundField DataField="DateofActivation" HeaderText="Activation" />
                                        <asp:BoundField DataField="DateofExpire" HeaderText="Expire" />
                                        <asp:BoundField DataField="TemporaryStatus" HeaderText="Status" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" />
                                        <asp:BoundField DataField="FeePaidStatus" HeaderText="Fee Paid" />
                                        <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount" />
                                 
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                </table>
                    </div>
                </td>
                </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanelpendingcard" runat="server" HeaderText="TabPanelpendingcard">
            <HeaderTemplate>
                Pending Card</HeaderTemplate>
            <ContentTemplate>
            <div class="efficacious">
                <table align="center" width="90%">
                 <tr align="center" id="tr3" runat="server" >
                        <td id="Td2" class="textheadcss" runat="server">
                            Pending Temperory Card
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0 20px 0;">
                            <asp:GridView ID="Gridlistpendingtem" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" 
                                DataKeyNames="Tempcardno" designer:wfdid="w36" 
                                EmptyDataText="Record not Found." HorizontalAlign="Center" 
                                OnPageIndexChanging="Gridlistpendingtem_PageIndexChanging" 
                                OnRowCancelingEdit="Gridlistpendingtem_RowCancelingEdit" 
                                OnRowDeleting="Gridlistpendingtem_RowDeleting" 
                                OnRowEditing="Gridlistpendingtem_RowEditing" Width="100%">
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                     <asp:BoundField DataField="Tempcardno" HeaderText="card no" />
                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                        <asp:BoundField DataField="StudentName" HeaderText="Name" />
                                        <asp:BoundField DataField="DateofIssue" HeaderText="Issue" />
                                        <asp:BoundField DataField="DateofActivation" HeaderText="Activation" />
                                        <asp:BoundField DataField="DateofExpire" HeaderText="Expire" />
                                        <asp:BoundField DataField="TemporaryStatus" HeaderText="Status" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" />
                                        <asp:BoundField DataField="FeePaidStatus" HeaderText="Fee Paid" />
                                        <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount" />
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </div>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    </td></tr></table>
</center>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
   
</asp:Content>


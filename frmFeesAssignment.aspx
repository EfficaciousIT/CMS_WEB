<%@ Page Title="" Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmFeesAssignment.aspx.cs" Inherits="frmFeesAssignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="index/scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CalculateTotals() {
            var gv = document.getElementById("<%= grvDetail.ClientID %>");
            var tb = gv.getElementsByTagName("input");
            var lb = gv.getElementsByTagName("span");

            var sub = 0;
            var total = 0;
            var indexQ = 2;
            var indexP = 0;

            for (var i = 0; i < tb.length; i++) {
                if (tb[i].type == "text") {
                    sub = parseFloat(lb[indexP].innerHTML) * parseFloat((tb[i].value) / 100);
                    if (isNaN(sub)) {
                        lb[i + indexQ].innerHTML = "";
                        sub = 0;
                    }
                    else {
                        lb[i + indexQ].innerHTML = parseFloat(lb[indexP].innerHTML) - sub;
                        sub = parseFloat(lb[indexP].innerHTML) - sub;
                    }

                    indexQ++;
                    indexP = indexP + 3;

                    total += parseFloat(sub);
                }
            }
            document.getElementById("<%=LBLTotal.ClientID %>").innerText = total;
        }




        function confirmMsg() {
            if (Page_ClientValidate() == false) {
                return false;
            }
            else {
                var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
                if (btn == 'Submit') {
                    var msg = confirm('Do You Really Want To Assign Current Fee Stucture To Selected Student ?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

        function YearColor() {
            var link = document.getElementById('<%=Year.ClientID %>').value;
            link.style.backgroundColor = '#FFAAAA';
        }
    </script>
    <style type="text/css">
        .style4
        {
            height: 16px;
        }
        .style10
        {
            font-weight: bold;
        }
        .style11
        {
            height: 16px;
            width: 91px;
        }
    </style>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.showhideY').click(function () {
                $("#Year").css("background-color", "red");
                $(".slidedivY").slideToggle();
                $(".slidedivH").slideUp();
                $(".slidedivQ").slideUp();
                $(".slidedivM").slideUp();
            });
        });

        $(function () {
            $('.showhideH').click(function () {
                $(".slidedivH").slideToggle();
                $(".slidedivQ").slideUp();
                $(".slidedivM").slideUp();
                $(".slidedivY").slideUp();
            });
        });

        $(function () {
            $('.showhideQ').click(function () {
                $(".slidedivQ").slideToggle();
                $(".slidedivM").slideUp();
                $(".slidedivY").slideUp();
                $(".slidedivH").slideUp();
            });
        });

        $(function () {
            $('.showhideM').click(function () {
                $(".slidedivM").slideToggle();
                $(".slidedivY").slideUp();
                $(".slidedivH").slideUp();
                $(".slidedivQ").slideUp();
            });
        });

    </script>
    <style type="text/css">
        .slidedivY
        {
            width: 80%;
            padding: 20px;
            background: #FFAA;
            color: #fff;
            margin-top: 10px;
            border-bottom: 5px solid #FFF;
            display: none;
        }
        .slidedivH
        {
            width: 80%;
            padding: 20px;
            background: #FFAA;
            color: #fff;
            margin-top: 10px;
            border-bottom: 5px solid #FFF;
            display: none;
        }
        .slidedivQ
        {
            width: 80%;
            padding: 20px;
            background: #FFAA;
            color: #fff;
            margin-top: 10px;
            border-bottom: 5px solid #FFF;
            display: none;
        }
        
        .slidedivM
        {
            width: 80%;
            padding: 20px;
            background: #FFAA;
            color: #fff;
            margin-top: 10px;
            border-bottom: 5px solid #FFF;
            display: none;
        }
        .style12
        {
            width: 263px;
        }
        .style13
        {
            width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 10px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" Width="100%" ActiveTabIndex="0">
                                    <asp:TabPanel runat="server" ID="TB1">
                                        <HeaderTemplate>
                                            Edit</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                            <div class="efficacious">
                                                <table width="100%">
                                                    <tr>
                                                 <td colspan="2">
                                                 <div class="efficacious" id="efficacious">
                                                 <table width="100%">
                                                 <tr>
                                                 <td align="left">
                                                            <asp:Label ID="Label2" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-right:20px">
                                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label1" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="textsize" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                 </tr>
                                                 </table>
                                                 </div>
                                                 </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="style13">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="mGrid" Width="100%" DataKeyNames="intStudFee_Id">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="intStudFee_Id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intStudFee_Id") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars"  ReadOnly="True" />
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAmount" Text='<%#Eval("numAmount") %>'  runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Discount (%)">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtDiscount" runat="server" AutoComplete="Off" Text='<%#Eval("Discount") %>'
                                                                                CssClass="textsize" MaxLength="5" Width="50px" OnTextChanged="txtDiscount_TextChanged"
                                                                                onkeyup="CalculateTotals();"></asp:TextBox><asp:FilteredTextBoxExtender runat="server"
                                                                                    TargetControlID="txtDiscount" FilterType="Numbers,Custom" FilterMode="ValidChars"
                                                                                    ValidChars=".">
                                                                                </asp:FilteredTextBoxExtender>
                                                                            <asp:RangeValidator ID="RV" runat="server" ControlToValidate="txtDiscount" Display="None"
                                                                                ErrorMessage="Invalid Percentage" MaximumValue="100.00" MinimumValue="0.00" Type="Double"></asp:RangeValidator>
                                                                            <asp:ValidatorCalloutExtender runat="server" TargetControlID="RV" PopupPosition="Right">
                                                                            </asp:ValidatorCalloutExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount with Discount">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTotal"  Text='<%#Eval("AmtWidDiscount") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="LBLTotal" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="intFeeDetId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFeeDetId" Text='<%#Eval("intFeeDetId") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right">
                                                            <table width="60%">
                                                                <tr>
                                                                    <td align="center" class="style11">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" class="style4">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="style11">
                                                                        <asp:Label ID="lbl" runat="server" CssClass="style10">Grand Total</asp:Label>
                                                                    </td>
                                                                    <td align="center" class="style4">
                                                                        <asp:Label ID="LBLTotal" runat="server" CssClass="style10">0</asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" dir="ltr" class="style13">
                                                            &nbsp;</td>
                                                        <td align="right" dir="ltr">
                                                            <asp:Button ID="btnSubmit" runat="server" CausesValidation="False" 
                                                                CssClass="efficacious_send" OnClick="btnSubmit_Click" 
                                                                OnClientClick="return confirmMsg();" Text="Submit" Width="200px" style="margin: 0 auto; float:inherit;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="TB2" runat="server">
                                        <HeaderTemplate>
                                            Fee Details
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <br />
                                            <center>
                                                <table width="70%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblFee" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                                                Font-Size="Medium" Text="Fee Structure" Font-Underline="True"></asp:Label>
                                                                
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                        <br />
                                                            <table width="70%" border="1">
                                                                <tr>
                                                                    <td align="center">
                                                                        <a id="Year" href="#" runat="server" onclick="return Yearcolor();" class="showhideY">Yearly</a>
                                                                    </td>
                                                                    <td align="center">
                                                                        <a id="Half" href="#" runat="server" onclick="return color();" class="showhideH">Half Yearly</a>
                                                                    </td>
                                                                    <td align="center">
                                                                        <a id="Quarter" href="#" runat="server" onclick="return color();" class="showhideQ">Quarterly</a>
                                                                    </td>
                                                                    <td align="center">
                                                                        <a id="Month" href="#" runat="server" onclick="return color();" class="showhideM">Monthly</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <div class="slidedivY">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:GridView ID="grvFee" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                                                                GridLines="Horizontal" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="    " />
                                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" />
                                                                                    <asp:BoundField DataField="AmtWidDiscount" HeaderText="Amount" />
                                                                                </Columns>
                                                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                                                                    Height="30px" />
                                                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                                <%--<SortedAscendingCellStyle BackColor="#F7F7F7" />--%>
                                                                                <%--<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                                                                <RowStyle Height="50px" HorizontalAlign="Justify" />--%>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table width="50%">
                                                                                <tr>
                                                                                    <td align="center" >
                                                                                        <br />
                                                                                        <asp:Label ID="lblGrandTot" runat="server" Text="Grand Total" ForeColor="Black" Font-Bold="True"></asp:Label>
                                                                                    </td>
                                                                                    <td align="right" >
                                                                                        <br />
                                                                                        <asp:Label ID="lblAmt" runat="server" Font-Bold="True" ForeColor="Black" Font-Underline="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                         
                                                            <div class="slidedivH">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:GridView ID="grvHalf" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                                                                GridLines="Horizontal" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="    " />
                                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" />
                                                                                    <asp:BoundField DataField="AmtWidDiscount" HeaderText="Amount" />
                                                                                </Columns>
                                                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                                                                    Height="30px" />
                                                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                                <%--<SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                                                                <RowStyle Height="50px" HorizontalAlign="Justify" />--%>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table width="50%">
                                                                                <tr>
                                                                                    <td align="center" style="padding-left: 50px">
                                                                                        <br />
                                                                                        <asp:Label ID="lblGranH" runat="server" Text="Grand Total" ForeColor="Black" Font-Bold="True"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" style="padding-left: 0px">
                                                                                        <br />
                                                                                        <asp:Label ID="lblTotHalf" runat="server" Font-Bold="True" ForeColor="Black" Font-Underline="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <div class="slidedivQ">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:GridView ID="grvQuarter" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                                                                GridLines="Horizontal" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="    " />
                                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" />
                                                                                    <asp:BoundField DataField="AmtWidDiscount" HeaderText="Amount" />
                                                                                </Columns>
                                                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                                                                    Height="30px" />
                                                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                                <%--<SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                                                                <RowStyle Height="50px" HorizontalAlign="Justify" />--%>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table width="50%">
                                                                                <tr>
                                                                                    <td align="center" >
                                                                                        <asp:Label ID="lblGrandQ" runat="server" Text="Grand Total" ForeColor="Black" Font-Bold="True"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" >
                                                                                      
                                                                                        <asp:Label ID="lblTotQuat" runat="server" Font-Bold="True" ForeColor="Black" Font-Underline="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <div class="slidedivM">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:GridView ID="grvMonth" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                                                                GridLines="Horizontal" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="    " />
                                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" />
                                                                                    <asp:BoundField DataField="AmtWidDiscount" HeaderText="Amount" />
                                                                                </Columns>
                                                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                                                                    Height="30px" />
                                                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                                <%--<SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                                                                <RowStyle Height="50px" HorizontalAlign="Justify" />--%>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table width="48%">
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        
                                                                                        <asp:Label ID="Label3" runat="server" Text="Grand Total" ForeColor="Black" Font-Bold="True"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                       
                                                                                        <asp:Label ID="lblTotMonth" runat="server" Font-Bold="True" ForeColor="Black" Font-Underline="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
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
</asp:Content>

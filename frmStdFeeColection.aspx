<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmStdFeeColection.aspx.cs" Inherits="frmStdFeeColection" Title="Fee Collection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 70%;
            font-family: Verdana;
        }
        .style2
        {
            width: 100%;
        }
        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .selectf
        {
            width: 150px;
            height: auto;
            padding: 4px;
            border: 1px solid #3498db;
        }
        .search
        {
            border: 1px solid green !important;
            padding: 3px;</style>

    <script type="text/javascript" language="javascript">

        function print() {

            var date = new Date();


            dateString = (date.getDate()) + "/" + (date.getMonth() + 1) + "/" + date.getFullYear().toString();

            var lblcandidateName = document.getElementById("<%=HiddenField1.ClientID %>").value;

            var lblFather = document.getElementById("<%=HiddenField2.ClientID %>").value;

            var lblRegistration = document.getElementById("<%=HiddenField3.ClientID %>").value;

            var lblReceipt = document.getElementById("<%=HiddenField4.ClientID %>").value;

            var payment = document.getElementById("<%=HiddenField5.ClientID %>").value;

            var gridData = document.getElementById('<%=grdFee.ClientID %>');

            var varLine = "______________________________________________________________________________________________";
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowUrl, windowName, 'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write("<html><head><meta http-equiv=Content-Type content=text/html; charset=utf-8 /><title>SETH M.R JAIPURIA SCHOOLS</title></head><body><table width=700 border=0 align=center cellpadding=0 cellspacing=0>  <tr> <td align=left><img src=http://e-smarts.net/school-logo.png width=188 height=100 alt=jaipuria /></td>  </tr>  <tr>    <td style=border-bottom:1px solid #242424; align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>" + varLine + "</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=right><table width=700 border=0 cellspacing=0 cellpadding=0>      <tr>        <td width=509></td>        <td width=169 align=center>(Student Copy )</td>        <td width=22>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr style=border-bottom:1px dashed #242424;>   <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;><td align=center><table width=700 border=0 cellspacing=0 cellpadding=0 style=font-size:14px; color:#000; font-family:Verdana, Geneva, sans-serif;>      <tr>        <td width=15 height=25>&nbsp;</td>        <td width=182 height=25>Receipt No</td>        <td width=12 height=25 align=center>:</td><td width=242 height=25>" + lblReceipt + "</td>        <td width=249 height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Date</td>        <td height=25 align=center>:</td>         <td width=242 height=25>" + dateString + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Received From</td>        <td height=25 align=center>:</td>        <td width=242 height=25>" + lblcandidateName + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Father Name</td>        <td height=25 align=center>:</td>          <td width=242 height=25>" + lblFather + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>ID</td>        <td height=25 align=center>:</td>         <td width=242 height=25>" + lblRegistration + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>School Name</td>        <td height=25 align=center>:</td>         <td width=242 height=25><label></label></td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Course Name</td>        <td height=25 align=center>:</td>          <td width=242 height=25><label></label></td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Proscessed by</td>        <td height=25 align=center>:</td>          <td width=242 height=25>DataEntry</td>        <td height=25>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr >    <td align=center><table width=100% border=1 align=center cellpadding=0 cellspacing=0 >      <tr style=border:1px solid #242424><td  height=25 align=center>");
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write("</td> </tr> </table></td>  </tr><tr >    <td align=left>&nbsp;</td>  </tr>  <tr >    <td align=left>Received in " + payment + " only</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=Left>For: Seth M. R. Jaipuria Schools-Banaras</td>  </tr></table>");

            prtWindow.document.write("<BR><BR><BR><BR><BR><BR><BR><BR><table width=700 border=0 align=center cellpadding=0 cellspacing=0>  <tr> <td align=left><img src=http://e-smarts.net/school-logo.png width=188 height=100 alt=jaipuria /></td>  </tr>  <tr>    <td style=border-bottom:1px solid #242424; align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=right><table width=700 border=0 cellspacing=0 cellpadding=0>      <tr>        <td width=509>&nbsp;</td>        <td width=169 align=center>(School Copy )</td>        <td width=22>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr style=border-bottom:1px dashed #242424;>   <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center><table width=700 border=0 cellspacing=0 cellpadding=0 style=font-size:14px; color:#000; font-family:Verdana, Geneva, sans-serif;>      <tr>        <td width=15 height=25>&nbsp;</td>        <td width=182 height=25>Receipt No</td>        <td width=12 height=25 align=center>:</td><td width=242 height=25>" + lblReceipt + "</td>        <td width=249 height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Date</td>        <td height=25 align=center>:</td>         <td width=242 height=25>" + dateString + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Received From</td>        <td height=25 align=center>:</td>        <td width=242 height=25>" + lblcandidateName + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Father Name</td>        <td height=25 align=center>:</td>          <td width=242 height=25>" + lblFather + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>ID</td>        <td height=25 align=center>:</td>         <td width=242 height=25>" + lblRegistration + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>School Name</td>        <td height=25 align=center>:</td>         <td width=242 height=25><label></label></td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Course Name</td>        <td height=25 align=center>:</td>          <td width=242 height=25><label></label></td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Proscessed by</td>        <td height=25 align=center>:</td>          <td width=242 height=25>DataEntry</td>        <td height=25>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr >    <td align=center><table width=100% border=1 align=center cellpadding=0 cellspacing=0 >      <tr style=border:1px solid #242424><td  height=25 align=center>");
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write("</td> </tr> </table></td>  </tr><tr >    <td align=left>&nbsp;</td>  </tr>  <tr >    <td align=left>Received in " + payment + " only</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=Left>For: Seth M. R. Jaipuria Schools-Banaras</td>  </tr></table></body></html>");

            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();

        }
        String.prototype.insertAt = function(index, string) {
            return this.substr(0, index) + string + this.substr(index);
        }
    
    </script>

    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=GridView1.ClientID%>");
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Fee Collection</HeaderTemplate>
                                    <ContentTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Standard"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" CssClass="selectf"
                                                        OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Division"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpDisivion" runat="server" AutoPostBack="True" CssClass="selectf">
                                                        <asp:ListItem Text="--Select--"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td width="30">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNameNo" runat="server" CssClass="inputf"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search.png" OnClick="btnSearch_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td width="30">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td width="30">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                        DataKeyNames="intStudent_id" EmptyDataText="No Records Found" Width="640px">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <Columns>
                                                            <asp:TemplateField Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="intStudent_id" runat="server" Text='<%#Eval("intStudent_id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="chkCtrl" runat="server" AutoPostBack="true" 
                                                                        onclick="RadioCheck(this);" Style="width: 10px; left: 20px;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="intRollNo" HeaderText="Roll No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchStudentFirst_name" HeaderText="Student Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vchFatherName" HeaderText="Father Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Payment Mode"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpPayMode" runat="server" AutoPostBack="True" CssClass="selectf"
                                                        OnSelectedIndexChanged="drpPayMode_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Cheque"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Payment Type"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpPayType" runat="server" AutoPostBack="True" CssClass="selectf"
                                                        OnSelectedIndexChanged="drpPayType_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Text="Monthly"></asp:ListItem>
                                                        <asp:ListItem Text="Quarterly"></asp:ListItem>
                                                        <asp:ListItem Text="Halfyearly"></asp:ListItem>
                                                        <asp:ListItem Text="Yearly"></asp:ListItem>
                                                        <asp:ListItem Text="One Time"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table id="tblCheque" runat="server" class="style2" visible="False">
                                                        <tr id="Tr1" runat="server">
                                                            <td id="Td1" runat="server">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td id="Td2" runat="server">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td id="Td3" runat="server">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td id="Td4" runat="server">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td id="Td5" runat="server">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td id="Td6" runat="server">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr2" runat="server">
                                                            <td id="Td7" runat="server" width="80">
                                                                <asp:Label ID="Label7" runat="server" Text="Cheque No"></asp:Label>
                                                            </td>
                                                            <td id="Td8" runat="server" width="120">
                                                                <asp:TextBox ID="txtChequeNo" runat="server" CssClass="inputfCheck" MaxLength="6"></asp:TextBox>
                                                            </td>
                                                            <td id="Td9" runat="server" width="50">
                                                                <asp:Label ID="Label8" runat="server" Text="Date"></asp:Label>
                                                            </td>
                                                            <td id="Td10" runat="server" width="100">
                                                                <asp:TextBox ID="txtChequeDate" runat="server" CssClass="inputfCheck"></asp:TextBox>
                                                            </td>
                                                            <td id="Td11" runat="server" width="50">
                                                                <asp:Label ID="Label9" runat="server" Text="Bank"></asp:Label>
                                                            </td>
                                                            <td id="Td12" runat="server" width="160">
                                                                <asp:TextBox ID="txtBankname" runat="server" CssClass="inputfCheck"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="grdcandidate" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                        EmptyDataText="No Fee structure Available" Style="margin-bottom: 20px;" Visible="False"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Candidate Name" HeaderText="Candidate Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Father Name" HeaderText="Father Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Father Mobile" HeaderText="Father Mobile">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Fee Structure
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="grdFee" runat="server" CssClass="mGrid" Style="margin-bottom: 20px;"
                                                        Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6">
                                                    <asp:Button ID="btnSub" runat="server" CssClass="efficacious_send" OnClick="btnSub_Click"
                                                        Text="Submit" />
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="HiddenField5" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenField6" runat="server" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="HiddenField4" runat="server" />
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                                <td>
                                                    &#160;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcandidateName" runat="server" Text="Reff No" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFather" runat="server" Text="Label" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRegistration" runat="server" Text="Label" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblReceipt" runat="server" Text="Label" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Visible="false">
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

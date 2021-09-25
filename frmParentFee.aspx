<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmParentFee.aspx.cs" Inherits="frmParentFee" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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

            alert(gridData);

            gridData.visible = false;

            var varLine = "______________________________________________________________________________________________";
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowUrl, windowName, 'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write("<html><head><meta http-equiv=Content-Type content=text/html; charset=utf-8 /><title>SETH M.R JAIPURIA SCHOOLS</title></head><body><table width=700 border=0 align=center cellpadding=0 cellspacing=0>  <tr> <td><img src=http://e-smarts.net/school-logo.png  style= position:absolute; top:10px; height=70 alt=jaipuria />  <table width=100% border=0 cellspacing=0 cellpadding=0 >    <tr>      <td align=center><h2 style=margin:0px;>Sadhu Vswani International School</h2></td>    </tr>    <tr>      <td align=center><h4 style=margin:0px;>( Sadhu Vaswani Mission, Bombay)</h4></td>    </tr>    <tr>      <td align=center>Behind Bhumiraj Complex,</td>    </tr>    <tr>      <td align=center>sanpada, Navi Mumbai</td>    </tr>    <tr>      <td align=center>Tel.: 2781 0750</td>    </tr>  </table></td>  </tr>  <tr>    <td style=border-bottom:1px solid #242424; align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>" + varLine + "</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=right><table width=700 border=0 cellspacing=0 cellpadding=0>      <tr>        <td width=509></td>        <td width=169 align=center>(Student Copy )</td>        <td width=22>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr style=border-bottom:1px dashed #242424;>   <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;><td align=center><table width=700 border=0 cellspacing=0 cellpadding=0 style=font-size:14px; color:#000; font-family:Verdana, Geneva, sans-serif;>      <tr>        <td width=15 height=25>&nbsp;</td>        <td width=182 height=25>Receipt No</td>        <td width=12 height=25 align=center>:</td><td width=242 height=25>" + lblReceipt + "</td>        <td width=249 height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Date</td>        <td height=25 align=center>:</td>         <td width=242 height=25>" + dateString + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Received From</td>        <td height=25 align=center>:</td>        <td width=242 height=25>" + lblcandidateName + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Father Name</td>        <td height=25 align=center>:</td>          <td width=242 height=25>" + lblFather + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>ID</td>        <td height=25 align=center>:</td>         <td width=242 height=25>" + lblRegistration + "</td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>School Name</td>        <td height=25 align=center>:</td>         <td width=242 height=25><label></label></td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Course Name</td>        <td height=25 align=center>:</td>          <td width=242 height=25><label></label></td>        <td height=25>&nbsp;</td>      </tr>      <tr>        <td height=25>&nbsp;</td>        <td height=25>Proscessed by</td>        <td height=25 align=center>:</td>          <td width=242 height=25>DataEntry</td>        <td height=25>&nbsp;</td>      </tr>    </table></td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr >    <td align=center><table width=100% border=1 align=center cellpadding=0 cellspacing=0 >      <tr style=border:1px solid #242424><td  height=25 align=center>");
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write("</td> </tr> </table></td>  </tr><tr >    <td align=left>&nbsp;</td>  </tr>  <tr >    <td align=left>Received in " + payment + " Rupees only</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=center>&nbsp;</td>  </tr>  <tr style=border-bottom:1px dashed #242424;>    <td align=Left>For: Seth M. R. Jaipuria Schools-Banaras</td>  </tr></table>");

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" ID="tc1" CssClass="MyTabStyle" Width="100%" Style="min-height: 450px"
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="tb1">
                                <HeaderTemplate>
                                    Fee Received
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
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
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdReceived" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CssClass="mGrid" OnRowEditing="grdReceived_RowEditing">
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                        <asp:BoundField DataField="Receive Date" HeaderText="Receive Date" ReadOnly="True" />
                                                        <asp:BoundField DataField="Amount Receive" HeaderText="Amount Receive" ReadOnly="True" />
                                                        <asp:BoundField DataField="Fee Type" HeaderText="Fee Type" ReadOnly="True" />
                                                        <asp:TemplateField HeaderText="Pending">
                                                            <ItemTemplate>
                                                                <asp:LinkButton CommandName="Edit" ID="lnkLeave" Text='<%#Eval("Prints") %>' runat="server"></asp:LinkButton></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" Text='<%#Eval("intid") %>' runat="server"></asp:Label></ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdFee" runat="server" CssClass="mGrid" Style="margin-bottom: 20px;"
                                                    Width="100%">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value="Ajay" />
                                                <asp:HiddenField ID="HiddenField2" runat="server" Value="Ajay" />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="HiddenField3" runat="server" Value="Ajay" />
                                                <asp:HiddenField ID="HiddenField4" runat="server" Value="Ajay" />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="HiddenField5" runat="server" Value="Ajay" />
                                                <asp:HiddenField ID="HiddenField6" runat="server" Value="Ajay" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel1" Visible="false">
                                <HeaderTemplate>
                                    Pending Fee
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr2" visible="false" runat="server">
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStandardRegis" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdPending" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TabPanel2" Visible="false">
                                <HeaderTemplate>
                                    Marks
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr id="Tr3" visible="false" runat="server">
                                            <td align="center">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label2" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpStand" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" valign="top">
                                                <asp:GridView ID="grdRegistrationTaken" CssClass="mGrid" runat="server">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel3" runat="server" Visible="false" HeaderText="TabPanel3">
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStudentFeeChart.aspx.cs" Inherits="frmStudentFeeChart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .efficacious textarea
        {
            width: 97% !important;
        }
        .efficacious input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .efficacious input[type=checkbox] + label {
            display: block;
            /* width: auto !important; */
            /* height: auto !important; */
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            /* background: white !important; */
            vertical-align: middle;
            line-height: 1em;
            /* font-size: 14px; */
            /* color: #000; */
            padding: 1px 0px;
            text-align: center;
            width: 30px;
            /* height: 50px; */
            margin-top: 3px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Payment Details
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
           
            <li class="active">Payment Details</li>
        </ol>
    </div>
    <div style="padding: 10px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Fee Chart</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <div class="efficacious" id="efficacious">
                                                                <table width="70%">
                                                                    <tr>
                                                                    <td align="center">
                                                                            <asp:Label ID="Label7" runat="server" Text="Acedemic Year" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpAcademiYear" runat="server"  AutoPostBack="True" 
                                                                              >
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label6" runat="server" Text="Standard" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlSTD" runat="server" 
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label10" runat="server" Text="Category" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpCat" runat="server"  
                                                                                AutoPostBack="True" onselectedindexchanged="drpCat_SelectedIndexChanged" >
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table" Width="70%"  AllowPaging="True"
                                                                DataKeyNames="intFeeDetId" >
                                                                <Columns>
                                                                   
                                                                    <asp:TemplateField HeaderText="FeeDetId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFeeDetId") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchFee" HeaderText="Particulars" ReadOnly="True" />
                                                                    <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                                                                    <asp:BoundField DataField="feetype" HeaderText="Type" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intCat_Id" HeaderText="Category" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField DataField="FrmDt" HeaderText="Effective From Date" ReadOnly="True"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="ToDt" HeaderText="Effective To Date" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField DataField="vchFeeDesc" HeaderText="Description" ReadOnly="True" Visible="False" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>
                                                       Total Fee : <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                                    </td>
                                                    </tr>
                                                </table>
                                                </div></center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1" >
                                        <HeaderTemplate>
                                            Fees Transaction
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                         <table width="100%">
                                            
                                            <tr>
                                        <div class="efficacious" id="Div1">
                                                                <table width="70%">
                                                                <tr>
                                                                   <td align="center"></td>
                                                                    <td align="left" valign="top"></td>
                                                                </tr>
                                                                   
                                                              

                                               <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label11" runat="server"  Text="Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                             <asp:TextBox ID="txtDurationType" runat="server" Width="96%" Visible="False"
                                                                    CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlDurationType" 
                                                                     runat="server" AutoPostBack="True" onselectedindexchanged="ddlDurationType_SelectedIndexChanged"                                                                  
                                                                      >
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                       
                                                            
                                                      
                                                         <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label4" runat="server"  Text="Fee Head"></asp:Label>
                                                            </td>
                                                           <td style="width: 50%">
                                                                <asp:GridView ID="gvHead" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                                    DataKeyNames="intTutionId" Width="100%">
                                                                    <Columns>
                                                                    <asp:BoundField DataField="intTutionId" HeaderText="Id" ReadOnly="True" />
                                                                        <asp:TemplateField HeaderText="Particulars">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFee_Id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                                                                        
                                                                    </Columns>
                                                                </asp:GridView>
                                                                 <asp:DropDownList ID="ddlFeeHead" Visible="False"
                                                                     runat="server"                                                                  
                                                                     AutoPostBack="True" 
                                                                   >
                                                                </asp:DropDownList>
                                                            </td>
                                                          </tr> 
                                                          
                                                         <tr>
                                                            <td align="center">
                                                                <asp:Label ID="lblMonths" runat="server"  Text="Month" Visible="False"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                 <asp:DropDownList ID="ddlMonths" runat="server" Visible="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                          </tr> 
                                                           <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label8" runat="server"  Text="Head Amt" Visible="False"></asp:Label>
                                                            </td>
                                                             <td align="left" valign="top"> <asp:TextBox ID="txtHeadAmt" CssClass="input-blue" runat="server" Visible="False"></asp:TextBox></td>
                                                              
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label5" runat="server"  Text="Paid Amount" ></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtEnterAmt" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            </tr>
                                                          
                                                            <tr><td></td>
                                                              <td width="30%">
                                                                <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" Text="Make Payment" />
                                                            </td>
                                                             <td width="30%" >
                                                             <asp:Button ID="btnReport" runat="server" CssClass="efficacious_send" Text="Report" 
                                                                      />   </td>
                                                        </tr>
                                                 
                                               
                                      
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:GridView ID="grdTrans" runat="server" CssClass="table  tabular-table " EmptyDataText="No Data Found" 
                                                        Width="90%" AutoGenerateColumns="False"  DataKeyNames="intID" >
                                                        <Columns> 
                                                          <asp:BoundField DataField="feeFate" HeaderText="Date" ReadOnly="True" />                                            
                                                          <asp:BoundField DataField="intTutionID" HeaderText="Head" ReadOnly="True" />
                                                          <asp:BoundField DataField="feeType" HeaderText="Pay Type" ReadOnly="True" />
                                                          <asp:BoundField DataField="intMonth_ID" HeaderText="Month" ReadOnly="True" />
                                                          <asp:BoundField DataField="intPaidAmt" HeaderText="Paid Amount" ReadOnly="True" />
                                                          <asp:BoundField DataField="intPayMode" HeaderText="Pay Mode" ReadOnly="True" />
                                                                      
                                                        </Columns>
                                                    </asp:GridView> </td> </tr>
                                                    
                                                   <tr>  <td>
                                                        &nbsp; Total Fee Received : <asp:Label ID="lblFee" runat="server" ></asp:Label>
                                                    </td>
                                                   
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                             </table>
                                                            </div>
                                        </table>
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


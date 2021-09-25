<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTrashHostelInquiry.aspx.cs" Inherits="frmTrashHostelInquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Hostel Enquiry
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
             <li><a ><i ></i>Trash</a></li>
            <li><a ><i ></i>Hostel</a></li>
            <li class="active">Hostel Enquiry</li>
        </ol>
    </div>
 <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="90%" 
                                                                DataKeyNames="HostelinquiryId" onrowediting="grvDetail_RowEditing"     >
                                                                <Columns>
                                                                                                                                    
                                                                    <asp:TemplateField HeaderText="Enable">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="true"
                                                                        OnClientClick="return confirm('Do You Really Want To Enable Selected Record ?');"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                       <asp:BoundField DataField="vchHostelType" HeaderText="Hostel Type" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchRoomType" HeaderText="Room Type" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStudentName" HeaderText="Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchFinYear" HeaderText="Fin. Year" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStandard" HeaderText="Standard" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchDivision" HeaderText="Division" ReadOnly="True"/> 
                                                                    <asp:BoundField DataField="vchMobile" HeaderText="Mobile" ReadOnly="True" />                                                                                                                                    
                                                                    <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True"/>
                                                                    <asp:BoundField DataField="vchMessage" HeaderText="Message" ReadOnly="True" />
                                                                </Columns>
                                                            </asp:GridView>
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


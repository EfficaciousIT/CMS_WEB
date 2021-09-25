<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="CCdetails.aspx.cs" Inherits="CCdetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Detail Character Certificate</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style>
        body {font-family: verdana;}.frm_heading h1 {text-align:center;margin:40px 00;}
        td, th {}
        .txt_cls{border:1px solid #3498db; margin:5px; padding:5px;
        }
       .label_cls{float:left}
        .auto-style1 {height: 22px;}
        #DropDownList1 {border:1px solid #3498db}
        table{text-align:left}
        .auto-style2 {float:left;margin-left:100px}
        .clr{clear:both}
       .sign_panel h4{text-align:center}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="tabular">
                                            <table width="100%">
                                                <tr>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 0px" valign="middle">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="textsize"
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged" >
                                                            <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            
                                                            <%--<asp:ListItem Value="1" Text="I"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="II"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="III"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="IV"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="V"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblDIV" runat="server" Text="Section" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize" AutoPostBack="True" onselectedindexchanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
<%--                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="textsize"></asp:Label>
                                                    </td>--%>
<%--                                                    <td align="left" valign="middle">
                                                         <asp:DropDownList ID="ddlGender" runat="server"  
                                                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    <asp:ListItem  Value="2">Female</asp:ListItem>
                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                </asp:DropDownList>
                                                    </td>--%>
                                                     <td>
                                                    <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                                        <ProgressTemplate>
                                                        <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                                        </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="bottom" CssClass="efficacious_send">
                                                     <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                                           <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                        <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="textsize" 
                                                            OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    </td>
                                                     <td align="center" valign="middle">
                                                    <asp:Label ID="Label27" runat="server" Text="Exam" CssClass="textsize" Visible="false"></asp:Label>

                                                    </td>

                                                     <td align="left" valign="bottom" CssClass="efficacious_send">
                                                     <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" CssClass="textsize" Visible="false" ></asp:DropDownList>
                                                    
                                                    </td>
                                                    <td style="padding-left: 12px;">
                                                    <asp:Button ID="show" runat="server" CssClass="btn btn-sm btn-primary" Text="Show" onclick="show_Click" Visible="false" />
                                                    </td>
                                                    
                                                   
                                                </tr>
                                            </table>

                                                             <div class="clearfix"></div>
                 <div class="clearfix"></div>
                 <div class="col-md-12">
            <asp:GridView ID="grdTrans" runat="server" AutoGenerateColumns="False" 
            CssClass="table  tabular-table " DataKeyNames="intStudent_id" 
            EmptyDataText="No Data Found" OnRowDeleting="grdTrans_RowDeleting" 
            Width="100%" onrowediting="grdTrans_RowEditing" onrowdatabound="gvTrans_RowDataBound" >
            <Columns>
                <%--<asp:BoundField DataField="SRNo" HeaderText="SR No" ReadOnly="True" />--%>
                <asp:BoundField DataField="intStudent_id" HeaderText="Student ID" ReadOnly="True" />
                <asp:BoundField DataField="vchStudent_name" HeaderText="Student Name" ReadOnly="True" />  
                <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" ReadOnly="True" />       
                <asp:BoundField DataField="vchMontherName" HeaderText="Mother Name" ReadOnly="True" />                                                                        
               <%-- <asp:BoundField DataField="dtcertificateissue" HeaderText="Date Issue Certificate" ReadOnly="True" />
                <asp:BoundField DataField="vchreasonlevaning" HeaderText="Reason" ReadOnly="True" /> --%>                                                                                  
                
                <%--<asp:BoundField DataField="dtCheque" HeaderText="Cheque Date" ReadOnly="True" /> --%>    
                <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Edit</asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>                                                                                                                                        
                <asp:TemplateField HeaderText="Print">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                            ImageUrl="~/images/print.png" />
                    </ItemTemplate>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
<asp:Label ID="lblTotal" runat="server" Visible="False"></asp:Label>
            </div>

                                        </div>
</asp:Content>


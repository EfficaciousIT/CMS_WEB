<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="frmColasticActivity.aspx.cs" Inherits="frmColasticActivity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <h1>
            
            Colastic Activity
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
            <li><a ><i ></i>School Master</a></li>
            <li class="active">Activity Master</li>
        </ol>
    </div>

 <style>
        .efficacious_send
        {
            width: 100% !important;
            background: #3498db;
            border: none;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 7px;
            cursor: pointer;
            height: 37px;
            margin-right: 10px;
            float: none;
            text-align: center;
        }
        .textcss
        {
            font-size: 13px !important;
        }
        .textsize
        {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
    </style>
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">

                                                       <asp:GridView ID="grvDetail" runat="server" DataKeyNames="intColasticActivity_id" CssClass="table  tabular-table " 
                                                                AutoGenerateColumns="False" onrowdeleting="grvDetail_RowDeleting1" 
                                                                onrowediting="grvDetail_RowEditing1">
                                                            <Columns>
                                                                <asp:BoundField DataField="intSection_id" HeaderText="Section" ReadOnly="True" />
                                                                 <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True" />
                                                                 <asp:BoundField DataField="vchDescription" HeaderText="Details" ReadOnly="True" />
                                                               
                                                               
                                                               <asp:TemplateField HeaderText="Edit" >
                                                         <ItemTemplate>
                                                              <asp:LinkButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"  >Edit</asp:LinkButton>
                                                              </ItemTemplate>
                                                             
                                                             </asp:TemplateField>  
                                                                   <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');">Delete</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                              </Columns>
                                                           </asp:GridView>
                                                            <%--<asp:GridView ID="grvDetail" CssClass="table  tabular-table " 
                                                                AutoGenerateColumns="False"  runat="server" Width="50%"  
                                                                DataKeyNames="intColasticActivity_id" onrowdeleting="grvDetail_RowDeleting1" 
                                                                onrowediting="grvDetail_RowEditing1"  >
                                                             <Columns>
                                                                 <asp:BoundField DataField="intSection_id" HeaderText="Section" ReadOnly="True" />
                                                                 <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True" />
                                                                 <asp:BoundField DataField="vchDescription" HeaderText="Details" ReadOnly="True" />
                                                              
                                                               <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                       </Columns>
                                                            </asp:GridView>--%>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                           
                                               <table width="36%" style="text-align: right; margin:0 0 0 2%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
              


                                                    <tr>
                                                        <td align="justify"> 
                                                            <asp:Label ID="Label1" runat="server" Text="Section"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlSection" runat="server" CssClass="input-blue" 
                                                                AutoComplete="Off" Width="100%">
                                                            <asp:ListItem Value="0" Text="--Select Section--"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Primary"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Secondary"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                     <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="a" 
                                                                runat="server" SetFocusOnError="True"
                                    ErrorMessage="Please Select  Section" Operator="NotEqual" InitialValue="0" ValueToCompare="0" 
                                                                Type="Integer" Display="Dynamic" ControlToValidate="ddlSection"
                                    ForeColor="Red" ></asp:RequiredFieldValidator>
                                    </td>
                                    </tr>
                            

                                                    </tr>


                                                     <tr>
                                                        <td align="justify"> 
                                                            <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDate" runat="server" CssClass="input-blue" MaxLength="50" 
                                                                AutoComplete="Off" Width="125px"></asp:TextBox>
                                                               <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                    Format="yyyy/MM/dd" TargetControlID="txtDate">
                                                </asp:CalendarExtender>
                                                   <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="a"  runat="server" ControlToValidate="txtDate"
                                                                Display="Dynamic" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                                                        </td>


                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ControlToValidate="txtDate" ErrorMessage="Please Enter proper date format in yyyy/mm/dd"
            ValidationExpression="\d{4}(\/|\-)((10|11|12)|0[1-9]{1})(\/|\-)(([0-2][1-9])|(3[01]{1}))"></asp:RegularExpressionValidator>
                                                        </td>


                                                    </tr>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="justify"> 
                                                            <asp:Label ID="Label2" runat="server" Text="Details"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDet" runat="server" CssClass="input-blue" MaxLength="50" 
                                                                AutoComplete="Off" Width="125px"></asp:TextBox>

                                                             <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="a"  runat="server" ControlToValidate="txtDet"
                                                                Display="Dynamic" ErrorMessage="Please Enter Details"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                        </td>
                                                    </tr>

                                                    
                                                 
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Button ID="btnSubmit" ValidationGroup="a" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
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
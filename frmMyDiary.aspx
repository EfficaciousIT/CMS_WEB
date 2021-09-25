<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmMyDiary.aspx.cs" Inherits="frmMyDiary" Title="Diary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .efficacious input[type="radio"]
        {
            width: 24px;
            float: left;
            margin: 0 auto;
            margin-right: 10px;
            margin-top: 10px;
        }
        .mGrid th {

  text-align: center !important;

}
        .efficacious span
        {
            width: auto !important;
        }
        --[if IE 11]
        > .efficacious input[type=checkbox], input[type=radio]
        {
            background: #f5f5f5 !important;
            border: 0 !important;
        }
        .efficacious input[type=radio]
        {
            width: 18px !important;
            height: 18px !important;
            background: #f5f5f5 !important;
        }
        .efficacious input[type=checkbox]
        {
            width: 14px !important;
            height: 14px !important;
            background: #f5f5f5 !important;
            
        }
         <![
        endif]-- > .efficacious input[type=radio] + label
        {
            background: rgb(248, 158, 54) !important;
            color: #fff !important;
            font-weight: bold;
            width: 115px !important;
            height: auto;
            border-radius: 5px !important;
        }
        .efficacious_send {
            width: 100% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .efficacious input[type=checkbox] + label
        {
            background: inherit !important;
            color: #000 !important;
            padding: 0 !important;
            font-weight: normal;
            font-size: 12px !important;
            width: auto !important;
            height: auto;
            border-radius: 5px !important; line-height:inherit !important;
        }
        .efficacious input
        {
            font-family: Verdana;
        }
        .efficacious select
        {
            font-family: Verdana;
            margin-left:20px;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function validation() {

            var ddlSTD = document.getElementById("<%=ddlSTD.ClientID %>").value;           
            if (ddlSTD == '0') {

                alert('Please select standard');
                return false;
            }

            var ddlDiv = document.getElementById("<%=ddlDiv.ClientID %>").value;
            if (ddlDiv == '0') {

                alert('Please select Division');
                return false;
            }

            var ddlType = document.getElementById("<%=ddlType.ClientID %>").value;
            if (ddlType == '0') {

                alert('Please select type');
                return false;
            }


            var ddlsubject = document.getElementById("<%=ddlsubject.ClientID %>").value;
            if (ddlsubject == '0') {

                alert('Please select subject');
                return false;
            }

            var atLeast = 1;
            var CHK = document.getElementById("<%=chkAllStuList.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var counter = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    counter++;
                }
            }
            if (atLeast > counter) {
                alert("Please select atleast " + atLeast + " student");
                return false;
            }

            var txtDateAssignment = document.getElementById("<%=txtDateAssignment.ClientID %>").value;
            
            if (txtDateAssignment == 'Date') {

                alert('Please provide date');
                return false;
            }

            var txtMessage = document.getElementById("<%=txtMessage.ClientID %>").value;

            if (txtMessage == '') {

                alert('Remark should not be empty');
                return false;
            }
            return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <h1>
            My Diary
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>My Diary</a></li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="padding: 5px 0 0 0; margin: 0 auto; width: 100%;">
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel ID="Entry" runat="server" Visible="true"><HeaderTemplate>Entry</HeaderTemplate><ContentTemplate><center><div class="efficacious" style="margin-top: 10px;"><table width="50%" align="center"><tr><td align="center"><table width="100%"><tr><td style="padding-left: 2px"><asp:Label ID="lblStd" runat="server" Text="STD"></asp:Label></td><td style="padding-left: 16px; margin-left: 10px"><asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged"></asp:DropDownList></td><td style="padding-left: 25px"><asp:Label ID="lblDIV" Style="margin-left: 20px" runat="server" Text="DIV"></asp:Label></td><td><asp:DropDownList ID="ddlDiv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged"></asp:DropDownList></td></tr><tr><td style="padding-left: 2px"><asp:Label ID="lblType" runat="server" Text="Type"></asp:Label></td><td style="padding-left: 16px; margin-left: 10px"><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"><asp:ListItem>---Select---</asp:ListItem><asp:ListItem>Study Remark</asp:ListItem><asp:ListItem>Message</asp:ListItem><asp:ListItem>Homework</asp:ListItem></asp:DropDownList></td><td style="padding-left: 25px"><asp:Label ID="lblStudent0" Style="margin-left: 20px" runat="server" Text="Subject"></asp:Label></td><td><asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="True"><asp:ListItem>---Select---</asp:ListItem></asp:DropDownList></td></tr><tr><td style="padding-left: 2px; margin-left: 10px"><asp:Label ID="lblchater" runat="server" Text="Chapter"></asp:Label></td><td style="padding-left: 16px; margin-left: 10px"><asp:TextBox ID="txtchapter" runat="server" Style="padding-left: 16px; margin-left: 20px"
                                                                            AutoComplete="Off" AutoPostBack="True" CssClass="input-blue" MaxLength="10"></asp:TextBox></td><td style="padding-left: 25px">&nbsp;&nbsp;</td><td>&nbsp;&nbsp;</td></tr></table></td></tr><tr><td align="left"><table width="100%"><tr><div runat="server" id="studydet" visible="False"><table><tr><td style="width: 42%;">&nbsp;&nbsp;</td><td width="73%">&nbsp;&nbsp;</td></tr><tr><td>&nbsp;&nbsp;</td><td width="73%">&nbsp;&nbsp;</td></tr><tr id="Tr1" runat="server" visible="False"><td id="Td2" runat="server"><asp:Label ID="lblStudent" runat="server" Text="Student"></asp:Label></td><td id="Td3" runat="server" width="73%"><asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" ><asp:ListItem>--Select--</asp:ListItem></asp:DropDownList></td></tr><tr><td align="left" valign="top"><div class="efficacious"><asp:Label ID="Label2" runat="server" Text="Student"></asp:Label></div></td><td align="left"><asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                        OnCheckedChanged="chkAll_CheckedChanged" Text="All" /><div style="overflow: scroll;
                                                                                            position: relative; left: -16px; height: 150px; margin-left: -50px"><asp:CheckBoxList ID="ChkDivList" runat="server" AutoPostBack="True"></asp:CheckBoxList></div></td></tr><tr><td><asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label></td><td width="73%"><asp:TextBox ID="txtDate" Style="margin-left: -65px" runat="server" AutoComplete="Off"
                                                                                        AutoPostBack="True" CssClass="input-blue" MaxLength="10"></asp:TextBox><asp:CalendarExtender
                                                                                            ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate"></asp:CalendarExtender><asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                                                                        TargetControlID="txtDate" WatermarkText="Date"></asp:TextBoxWatermarkExtender></td></tr><tr><td><asp:Label ID="lblExam" runat="server" Text="Study"></asp:Label></td><td width="73%"><asp:TextBox ID="txtComments" CssClass="input-blue" runat="server" Height="60px"></asp:TextBox></td></tr></table></div></tr><tr><div runat="server" id="divMessage" visible="False"><table><tr><td align="left" valign="top"><div class="efficacious"><asp:Label ID="Label5" runat="server" Text="Student"></asp:Label></div></td><td align="left"><asp:CheckBox ID="chkAllStu" Style="margin-left: 13px" runat="server" Text="All"
                                                                                        AutoPostBack="True" OnCheckedChanged="chkAll2_CheckedChanged" CssClass="textsize" /><div
                                                                                            style="overflow: scroll; position: relative; left: 13px; height: 150px"><asp:CheckBoxList ID="chkAllStuList" runat="server" AutoPostBack="True"></asp:CheckBoxList></div></td></tr><tr><td><asp:Label ID="Label6" runat="server" Text="Date"></asp:Label></td><td width="73%"><asp:TextBox ID="txtDateAssignment" Style="margin-left: 13px" runat="server" AutoComplete="Off"
                                                                                        AutoPostBack="True" CssClass="input-blue" MaxLength="10"></asp:TextBox><asp:CalendarExtender
                                                                                            ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDateAssignment"></asp:CalendarExtender><asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                                                        TargetControlID="txtDateAssignment" WatermarkText="Date"></asp:TextBoxWatermarkExtender></td></tr><tr><td><asp:Label ID="lblMessage" runat="server" Text="Remark"></asp:Label></td><td width="73%"><asp:TextBox ID="txtMessage" Style="margin-left: 13px" runat="server" CssClass="input-blue"
                                                                                        Height="60px"></asp:TextBox></td></tr><tr style="margin-left: 100px;"><td><table width="40%" style="padding-left: 52px;"><tr><td width="50%" align="right"><asp:Button ID="btnClear" Visible="false" CssClass="efficacious_send" runat="server"
                                                                                                    Text="Clear" /></td><td width="100%" align="right" style="margin-left: 100px;"><asp:Button ID="btnSubmit" runat="server" OnClientClick="return validation();" CssClass="efficacious_send" Text="Submit"
                                                                                                    OnClick="btnSubmit_Click" /></td></tr></table></td></tr></table></div></tr></table></td></tr></table></div></center></ContentTemplate></asp:TabPanel>
                              
                              
                                <asp:TabPanel ID="DiaryNew" runat="server" HeaderText="Events"><HeaderTemplate>My Diary</HeaderTemplate><ContentTemplate><div class="efficacious" style="margin-top: 10px;"><table><tr><div class="efficacious" id="Div1"><table width="100%"><caption><iframe id="frame" frameborder="0" src="frmMyDiaryCal.aspx" width="100%" height="450px"
                                                                    style="overflow: scroll;"></iframe></caption></table></div></tr></table></div></ContentTemplate></asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

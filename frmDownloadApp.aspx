<%@ Page  Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true" Title="Application Detail"
    Culture="en-gb" CodeFile="frmDownloadApp.aspx.cs" Inherits="frmDownloadApp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            height: 25px;
        }
          .mGrid th {
 
  text-align: center !important;
 
}
.efficacious input{ float:left}
   .efficacious input[type="file"] {
  display: block;
  border: 1px solid #3498db;
  width: 100%;
  padding:0;
  font-family: Verdana;
  -webkit-border-radius: 7px;
  -moz-border-radius: 7px;
  border-radius: 7px;
  outline: none;
  font-size: 13px;
  text-align: left;
  background:none !important; float:left;}
        </style>
    <script type="text/javascript" language="javascript">
        function Confirm() {
            var del = confirm('Do You Want To Delete Selected Record ?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }

        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "Application Uploaded Successfully";
        }
        function Check() {
            if (Page_ClientValidate()) {
                var appNm = document.getElementById('<%=FileUploadApp.ClientID %>').value;
                alert(appNm);
                if (appNm == '') {
                    $get("<%=lblMesg.ClientID%>").innerHTML = "Please Upload The Application First";
                    return false;
                }
            }
        }
        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "Application upload failed.";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer CssClass="MyTabStyle" ID="TabContainer1" runat="server" ActiveTabIndex="2" 
                            Width="1015px">
                           
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="grvDownloadDetails" runat="server" AllowSorting="True" Width="100%"
                                                    AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="intApplication_id"
                                                    OnRowEditing="grvDownloadDetails_RowEditing" OnRowDeleting="grvDownloadDetails_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="intApplication_id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppId" runat="server" Text='<% #Bind("intApplication_id") %>'>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgDelete" CausesValidation="false" runat="server" ImageUrl="~/images/delete.png"
                                                                    CommandName="Delete" OnClientClick="return Confirm();" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgEdit" CausesValidation="false" runat="server" ImageUrl="~/images/edit.png"
                                                                    CommandName="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="vchApplication_name" HeaderText="Application Name" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchVersion" HeaderText="Version" ReadOnly="True" />
                                                        <asp:BoundField DataField="vchPlatform" HeaderText="Platform" ReadOnly="True" />
                                                        <asp:BoundField DataField="dtReleaseDate" HeaderText="Release Date" ReadOnly="True" />
                                                        <asp:BoundField DataField="dtUploadDate" HeaderText="Upload Date" ReadOnly="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel3">
                                <HeaderTemplate>
                                    View Downloaded Application
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td valign="top">
                                            <div class="efficacious" id="efficacious" style="margin-top:15px;">
                                                <table width="70%" style="margin:0 auto; ">
                                                    
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="Label1" runat="server" CssClass="textcss" Text="From Date"></asp:Label>
                                                        </td>
                                                        <td valign="top">
                                                            <asp:TextBox ID="txtFrmDt" runat="server" style="width:130px; position:relative; top:-2px" CssClass="textsize" 
                                                                AutoPostBack="True" AutoComplete="Off" ontextchanged="txtFrmDt_TextChanged"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                TargetControlID="txtFrmDt">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <td valign="top">
                                                            <asp:Label ID="Label5" runat="server" CssClass="textcss" Text="To Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtToDt" runat="server" style="width:130px; position:relative; top:-4px" CssClass="textsize" OnTextChanged="txtToDt_TextChanged"
                                                                AutoPostBack="True" AutoComplete="Off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                TargetControlID="txtToDt">
                                                            </asp:CalendarExtender>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="textsize" ControlToCompare="txtFrmDt"
                                                                ControlToValidate="txtToDt" ErrorMessage="From Date Should Be Less Than To Date"
                                                                Operator="GreaterThanEqual" Display="None"></asp:CompareValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="CompareValidator1"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    
                                                  
                                                </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TabContainer ID="TabContainer2" CssClass="MyTabStyle" runat="server" Width="100%" 
                                                    ActiveTabIndex="0">
                                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel4">
                                                        <HeaderTemplate>
                                                            Teacher
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="grvTeacher" runat="server" AllowSorting="True" Width="100%" AutoGenerateColumns="False"
                                                                            CssClass="mGrid">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Dept" HeaderText="Department" />
                                                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                                <asp:BoundField DataField="AppName" HeaderText="Application Name" />
                                                                                <asp:BoundField DataField="Version" HeaderText="Version" />
                                                                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                                <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:TabPanel>
                                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel5">
                                                        <HeaderTemplate>
                                                            Student
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="grvStud" runat="server" AllowSorting="True" Width="100%" AutoGenerateColumns="False"
                                                                            CssClass="mGrid">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                                <asp:BoundField DataField="STD" HeaderText="Standard" />
                                                                                <asp:BoundField DataField="DIV" HeaderText="Division" />
                                                                                <asp:BoundField DataField="AppName" HeaderText="Application Name" />
                                                                                <asp:BoundField DataField="Version" HeaderText="Version" />
                                                                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                                <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:TabPanel>
                                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel6">
                                                        <HeaderTemplate>
                                                            Parent
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="grvParent" runat="server" AllowSorting="True" Width="100%" AutoGenerateColumns="False"
                                                                            CssClass="mGrid">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                                                                <asp:BoundField DataField="StudName" HeaderText="Student Name" />
                                                                                <asp:BoundField DataField="Parent" HeaderText="Parent Name" />
                                                                                <asp:BoundField DataField="STD" HeaderText="Standard" />
                                                                                <asp:BoundField DataField="DIV" HeaderText="Division" />
                                                                                <asp:BoundField DataField="AppName" HeaderText="Application Name" />
                                                                                <asp:BoundField DataField="Version" HeaderText="Version" />
                                                                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                                <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                            </Columns>
                                                                        </asp:GridView>
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
                            </asp:TabPanel>
                             <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                <table width="100%">
                                <tr>
                                <td align="center">
                                 <div class="efficacious">
                                    <table width="60%" >
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="lblAppName" runat="server" Text="Application Name" CssClass="textcss"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtAppNm" runat="server" AutoComplete="Off" 
                                                    CssClass="textsize"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ErrorMessage="Please Enter Application Name"
                                                    ControlToValidate="txtAppNm" Display="None" CssClass="textcss"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="lblVersion" runat="server" Text="Version" CssClass="textcss"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="2">
                                                <asp:TextBox ID="txtVer" runat="server" AutoComplete="Off" CssClass="textsize"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Version Of An Application"
                                                    ControlToValidate="txtVer" Display="None" CssClass="textcss"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="lblPlatform" runat="server" Text="Platform" CssClass="textcss"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="2">
                                                <asp:TextBox ID="txtPlatForm" runat="server" AutoComplete="Off" 
                                                    CssClass="textsize"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Platform Name"
                                                    ControlToValidate="txtPlatForm" Display="None" CssClass="textcss"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="lblRealeseDt" runat="server" Text="Release Date" CssClass="textcss"></asp:Label>
                                            </td>
                                            <td class="style2" colspan="2">
                                                <asp:TextBox ID="txtReleaseDt" runat="server" AutoComplete="Off" 
                                                    CssClass="textsize"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                    TargetControlID="txtReleaseDt">
                                                </asp:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Choose File"
                                                    ControlToValidate="txtReleaseDt" Display="None" CssClass="textcss"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5"
                                                    Enabled="True">
                                                </asp:ValidatorCalloutExtender>

                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="lblUpload" runat="server" CssClass="textcss"  Text="Upload App"></asp:Label>
                                            </td>
                                            <td align="left" class="style2" colspan="2" >
                                                <asp:AsyncFileUpload ID="FileUploadApp" runat="server"  CssClass="textsize" style="float:left; background:none;" FailedValidation="False"
                                                    OnUploadedComplete="FileUploadApp_UploadedComplete" OnClientUploadError="uploadError" 
                                                    OnClientUploadComplete="uploadComplete" UploaderStyle="Modern" CompleteBackColor="White"
                                                    ThrobberID="imgLoader" />
                                           
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                        </td>
                                        
                                          <td align="left" valign="top" colspan="2">
                                                <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" />
                                              <asp:Label ID="lblMesg" runat="server" CssClass="textsize"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                &nbsp;
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Button ID="btnSave" runat="server" CssClass="efficacious_send" 
                                                    OnClick="btnSave_Click" OnClientClick="return Check();"
                                                    Text="Submit" />
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                                    CssClass="efficacious_send" OnClick="btnCancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                    </div>
                                </td>
                                </tr>
                                </table>
                               
                                </ContentTemplate>
                            </asp:TabPanel>

                              <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel7">
                                <HeaderTemplate>
                                    Downloaded App
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%" >
                                        <tr>
                                            <td>
                                               <asp:GridView ID="grvDownloadApp" runat="server" AllowSorting="True" 
                                                    Width="100%" AutoGenerateColumns="False"
                                                                            CssClass="mGrid">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="AppName" HeaderText="Application Name" />
                                                                                <asp:BoundField DataField="Version" HeaderText="Version" />
                                                                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                                <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                            </Columns>
                                                                        </asp:GridView>
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

<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmTeacherRemarkEntry.aspx.cs" Inherits="frmTeacherRemarkEntry" Title="Remark Entry" Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding:5px 0 0 0">
        
                            <asp:UpdatePanel id="c11" runat="server">
                            <ContentTemplate >
    
    <table width="100%"><tr><td align="left">
   
    <asp:TabContainer ID="TabContainer1" runat="server" CssClass="MyTabStyle" ActiveTabIndex="0"
        Width="1015px">
        <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">

            <HeaderTemplate>
                Teacher Remark Entry
            </HeaderTemplate>
               <ContentTemplate>
                   
                                <center>
                                    <br />
                                    <div class="efficacious" >
                                    <table width="70%">
                                        <tr>
                                            <td>
                                        <center>

                                <table width="100%" >
                                          
                                    <tr>
                                        <td align="right">

                                        <div style="width:300px; height:auto; margin:0 auto;">
                                        <div style="width:100px; float:left; text-align:left;">
                                            <asp:Label ID="Label3" runat="server"  >Standard</asp:Label></div>
                                             <div style="width:200px; float:left;">
                                             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                              >
                                   
                                        </asp:DropDownList></div></div>
                                        </td>
                                        
                                    <td align="left" >
                                           
                                     </td><td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="DropDownList1"   Display="None" 
                                            ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                            Enabled="True" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                        &nbsp;&nbsp;
                                       
                                        </td>
                           </tr>
                            <tr id="row2" runat="server">
                                        <td align="left" runat="server">
                                            <asp:Label ID="Label8" runat="server"  >Division</asp:Label>
                                        </td>
                                        
                                    <td align="left" runat="server"  >
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                                             >
                                            </asp:DropDownList>
                                            </td><td runat="server">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="DropDownList2"   Display="None" 
                                            ErrorMessage="Select Division" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                            Enabled="True" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                           </tr>
                            <tr id="row3" runat="server">
                                        <td align="left" runat="server">
                                            <asp:Label ID="Label9" runat="server"  >Roll No</asp:Label>
                                        </td>
                                        
                                    <td align="left" style="padding-top:10px" runat="server" >
                                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                                            
                                            onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                                             >
                                           
                                        </asp:DropDownList>
                                        </td><td runat="server">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="DropDownList3"   Display="None" 
                                            ErrorMessage="Select Student Roll No" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                            Enabled="True" TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                           </tr>
                            <tr id="row4" runat="server">
                                        <td align="left" runat="server">
                                            <asp:Label ID="Label10" runat="server"  >Subject Name</asp:Label>
                                        </td>
                                        
                                    <td align="left" style="padding-top:10px" runat="server" >
                                        <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                                             >
                                           
                                        </asp:DropDownList>
                                        </td><td runat="server">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="DropDownList4"   Display="None" 
                                            ErrorMessage="Select Subject Name" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                            Enabled="True" TargetControlID="RequiredFieldValidator4">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                           </tr>
                           <tr id="row5" runat="server">
                           <td align="left" runat="server"><asp:Label ID="Label1" runat="server"  >Remark</asp:Label></td>
                           
                           <td align="left" runat="server"  >
                               <textarea id="TextArea1" runat="server" style="width:96.6%"></textarea>
                               </td><td runat="server">
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="TextArea1"   Display="None" 
                                            ErrorMessage="Enter Remark" Font-Bold="False"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                                            Enabled="True" TargetControlID="RequiredFieldValidator5">
                                        </asp:ValidatorCalloutExtender>
                               </td>
                           </tr>
                           
                          </table>
                                           
                                    </center>
                         
                            </td>
                            
                        </tr>
                        <tr>
                           <td align="center"  >
                        <table width="100%"><tr>
                        <td width="50%">
                        </td>
                        <td>
                      
                            <asp:Button    ID="Button1" CssClass="efficacious_send" runat="server" 
                                   Text="Submit" onclick="Button1_Click"  style="position:relative; left:-64px;;"   />
                        </td></tr></table>   
                        </td>    
                          </tr>
                       
                            
                    </table>
                                
                                            </div>
                                
                                   
              </ContentTemplate> 
            </asp:TabPanel>
        </asp:TabContainer>
     
        
  </td></tr></table>
              </ContentTemplate>
                          </asp:UpdatePanel>
        </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
      
        #TextArea1
        {
            width: 98px;
            margin-left: 31px;
            height: 33px;
        }

        .style12
        {
            width: 33px;
        }

    </style>
    <script type="text/javascript">
    function CheckDate(ctrl)
        {
            var dt = new Date();
            var cdt = Date.parse(ctrl.value);
            if(cdt > dt)
            {
                alert('Date greater than Today');
            }
        }
        </script>
</asp:Content>

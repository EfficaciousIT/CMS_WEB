<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmMessaging.aspx.cs" Inherits="frmMessaging" Title="Messaging" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-family: Verdana;
        }
      /*  .style1 select {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-right: 30px;
        }*/
                .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }
        .search
        {
            border: 1px solid #078DB9 !important;
            padding: 3px;
        }
        .efficacious_Submit
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 110% !important;
            background: #3498db;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
        }
        .modalPopup
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 10000;
            width: 100%;
            height: 100%;
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            z-index:-1;
           
        }
        .td, th {
            padding: 0;
            padding-right:300px;
        }
.style1 input, form.winner-inside textarea, select{ margin-top:0;}        
    </style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
<div class="content-header pd-0">
       
        <ul class="top_nav1">
        <li><a >Messaging <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
             <li class="active1"><a>Send Message</a></li>
                     
        </ul>
    </div>
     <section class="content">  
    

        <div class="row">
            <section class="col-md-12 col-xs-12">
                <div class="box box-orange">
                <div class="box-header">
                <h3 class="text-center">Send Message</h3>
                </div>
                    <div class="box-body">
                    <div class="form-horizontal">
                        <div class="col-md-10">
                       

                        <div class="form-group">
                            <div class="col-md-1" style="padding: 0 0 0 6px;">
                             <asp:Label ID="Label6" runat="server" Text="SMS Template" CssClass="control-label"></asp:Label>
                           
                            </div>
                            
                        <div class="col-md-4">
                             <asp:DropDownList ID="drpSMSTemp" runat="server"  class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpSMSTemp_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                       </div>
                       
                 
                       <div class="col-md-4">
                            <asp:TextBox ID="txtTemplateid" runat="server" CssClass="form-control"  MaxLength="50"></asp:TextBox>
                       </div>

                         </div>

                        
                            <div class="form-group">
                            <div class="col-md-1" style="padding: 0 0 0 6px;">
                             <asp:Label ID="Label3" runat="server" Text="User Type" CssClass="control-label"></asp:Label>
                           
                            </div>
                        <div class="col-md-4">
                             <asp:DropDownList ID="drpUserType" runat="server"  class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpUserType_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                       </div>

                         </div>

                         <div class="form-group" visible="false" runat="server" id="Numbers">
                            <div class="col-md-1">
                              <asp:Label ID="Label5" runat="server" Text="Numbers" CssClass="control-label"></asp:Label>                         
                            </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNumbers" runat="server" TextMode="MultiLine" CssClass="form-control" Height="68px"></asp:TextBox>
                       </div>
                        <div class="col-md-1">
                        
                        </div>
                         <div class="col-md-3">
                           
                       </div>
                       <div class="col-md-1">
                       
                        </div>
                         <div class="col-md-3">
                            
                       </div>
                         </div>     <!-- form group student -->

                         <div class="form-group" visible="false" runat="server" id="trStudent">
                            <div class="col-md-1">
                              <asp:Label ID="Label1" runat="server" Text="Standard" CssClass="control-label"></asp:Label>                         
                            </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    OnSelectedIndexChanged="drpStandard_SelectedIndexChanged" >
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                       </div>
                        <div class="col-md-1">
                        <asp:Label ID="Label2" runat="server" Text="Section" ></asp:Label>
                        </div>
                         <div class="col-md-3">
                             <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="drpDivision_SelectedIndexChanged">
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                       </div>
                       <div class="col-md-1">
                        <asp:Label ID="Label4" runat="server" Text="Gender" ></asp:Label>
                        </div>
                         <div class="col-md-3">
                             <asp:DropDownList ID="ddlGender" runat="server"  CssClass="form-control"
                                                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    <asp:ListItem  Value="Female">Female</asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                </asp:DropDownList>
                       </div>
                         </div>     <!-- form group student -->
                         <div class="form-group"  visible="false" runat="server" id="trStaff">
                            <div class="col-md-1" style="padding: 0 0 0 0px;">
                              <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="control-label"></asp:Label>
                            </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="drpDepartment" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                       </div>                       
                            </div>      <!-- form-group staff -->
                            <div class="form-group">
                            <div class="col-md-1">
                              <asp:Label ID="Label16" runat="server" Text="Notice"></asp:Label>
                            </div>
                       <div class="col-md-4">
                            <asp:TextBox id="txtNotice" class="message-count form-control" TextMode="MultiLine" runat="server"  Height="200px" 
                                             AutoPostBack="True" placeholder="Message" Rows="160" MaxLength="2"></asp:TextBox>
                            <span id="remaining">160 characters remaining</span> <span id="messages">1 message(s)</span>
                        </p>

  </div>                        
                            </div>      <!-- form-group staff -->
                            <asp:GridView ID="grdMessage" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                            DataKeyNames="ID,Name,Mobile,FCMToken"
                                            EmptyDataText="No Records Found" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Edit" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                     <asp:CheckBox ID="chkCtrl" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile No">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                              
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                        <div class="col-md-2 col-md-offset-1" style="padding:0;">
                                         <asp:Button ID="btnSMS" runat="server" CssClass="efficacious_Submit" Text="Send" 
                                                        OnClick="btnSMS_Click" />
                                        </div>
                         </div>
                         

                    </div>      <!-- form- horizontal-->
                    </div>      <!-- box body-->
                </div>
             </section>
        </div>
 <script>
     var $remaining = $('#remaining'),
    $messages = $remaining.next();

     $('.message-count').keyup(function () {

         var chars = this.value.length,
        messages = Math.ceil(chars / 160),
        remaining = messages * 160 - (chars % (messages * 160) || messages * 160);

         $remaining.text(remaining + ' characters remaining');
         $messages.text(messages + ' message(s)');
     });

</script>                       
    </section>
            
        </ContentTemplate>
    </asp:UpdatePanel>
 
</asp:Content>

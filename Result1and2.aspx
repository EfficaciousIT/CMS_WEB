<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Result1and2.aspx.cs" Inherits="Result1and2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        p,li{ font-family:Arial, Helvetica, sans-serif; }
       .h-30{height:30px;}
        .h-50 {height:50px;        }
        .mt-55 {margin-top:55px;        }
        .h-52 {    height: 52px;}
        .mtb-0 {margin-top:0; margin-bottom:0;        }
        .result-h { display:block;    text-align:center;    }
        .result-h h2{font-size: 22px;    color: #025402;}        .result-h h3{font-size:19px;}        .result-h h4{font-size:19px;}
        .result-h h2, .result-h h3, .result-h h4 { padding:0; margin-top:5px;      margin-bottom: 0;          }
        .student-info { text-align:center;     margin: 10px auto 0;      font-size: 15px;        }
        .grad,.p-message{    display:block; width:100%;  float:left; }
        .grad {     border-bottom: 1px solid black;        }
        .grad h4,.p-message h4 { text-align:center; font-size:16px;        margin: 0 auto 8px;     }
         .grad ul { width:50%; float:left;      padding-left: 20px;   margin-bottom:0;       }
         .grad ul:first-of-type {border-right:1px solid black;            }
         .grad ul li {  list-style-type:none;      text-align:left;      }
           .grad ul li i   {font-style: normal;}
         .grad ul li i.sp{ width:40%;  float: left;}
         .grad ul:first-of-type li span{} 
         .grad ul:only-of-type li span {  padding-left: 20px;            }
          .p-message ol {  padding-left: 20px;            }
         .p-message ol li { list-style-type:decimal;     text-align:left;       }
        .student-info >.form-inline >.form-group {display: inline-block;  margin-bottom:0 !important;  }
        .tab_result tr th, .tab_result1 tr th{                background: #3498db;                color: white;                text-align: center; }   
 .tab_result >tbody >tr >th{width:60% !important;} 
 .tab_result >tbody >tr >th:nth-child(2){width:40% !important;}
 .tab_result >tbody >tr >td{width:60% !important;}
  .tab_result >tbody >tr >td:nth-child(2){width:40% !important;}
  .tab_result.col{    border-top: 0px !important;}
    .tab_result.col >tbody >tr >th:nth-child(1){ border-right:0px !important; border-top:0px !important;}
    .tab_result.col >tbody >tr >th:nth-child(2){color:#3498db; border-top:0px !important; border-left:0px !important;}
        
.tab_result tr td:first-child,.tab_result tr th:first-child,.tab_result1 tr td:first-child,.tab_result1 tr th:first-child{ text-align:left; }                
.tab_result tr td,.tab_result1 tr td{ margin:0; line-height:0;}
.tab_result tr td,.tab_result1 tr td{text-align:center;}
.tab_result,.tab_result tr th,.tab_result tr td{ border:1px solid black !important;    padding: 3px 5px !important; }
.tab_result1 tr th{ border:1px solid black !important;    padding: 3px 5px !important;         }
.tab_result1 tr td { /* border:1px solid #929292 !important; color- light black */  border:1px solid black !important;       padding: 3px 5px !important;       }

.line { display:block; position:relative;        }
.l_child {  position:absolute;   width:100%;    
                     bottom: -3px !important;
                        left: -20px;        /*bottom:0 !important; */
                    /*width: 196%; height:1px; background-color:#929292 !important;     
                    background-image:url("images/ling1.jpg"); background-repeat:repeat-x; display:block; background-size:cover; */}
        .l_child img{    width: 100%;    height: 1px;        }
.line-box {  width:100%;   border:0px !important; float:left;  margin:10px auto 0;    }

.sign { position:relative;        }
.sign img {     position: absolute;
    top: 0;
    left: 0;
    right: 0;
    margin: 0 auto;
    width: 70%;
        }
        @media print and (max-width:768px) {
           .student-info{ font-size: 14px; padding:0;    margin: 120px auto 20px;      }
           .student-info >.form-inline >.form-group { margin-bottom:0 !important;            }
    .adm-sts-border { border:1px solid black;    } 
    .table-bordered td,.table-bordered th { border:1px solid black !important;     }
    .table td, .table th { border:1px solid black !important;    }
    .tab_result.col{    border-top: 0px !important;}
     .tab_result.col >tbody >tr >th:nth-child(2){color:white !important;    opacity: 0; border-left:0px !important;}
    .line { display:block; position:relative;        }
            .form-horizontal .form-group {  margin-right: 0px !important;      margin-left: 0px !important;             }
        .l_child {  position:absolute;  bottom:0 !important; width:100%;
                        bottom: -3px !important;
                        left: -20px;
                    /*width: 196%; height:1px; background-color:#929292 !important; 
                    background-image:url("images/ling1.jpg"); background-repeat:repeat-x; display:block; background-size:cover; */}

        .l_child img{    width: 100% !important;    height: 1px !important;        }

    /* .line-box {width:100%; border-bottom:1px solid #929292 !important; float:left; display:block; margin:0 auto;        }
     .line {  position:relative !important;        }
     .l_child {  position:absolute !important;  bottom:0 !important;  display:none !important;
                 width: 100% !important; height:1px !important; background-color:#929292 !important;        }   */
     .bor{ border:1.5px solid black !important;       margin:15px !important; padding:10px !important;    }
     
     }

        .d-none {display:none;        }
        .mt-30 {    margin-top:30px;        }
    </style>
     <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            document.getElementById('printbutton').style.visibility = 'hidden';
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
            location.reload();

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content"> 
    

        <div class="row">
            <section class="col-md-12 col-xs-12">
                <div class="box box-orange">
    <button class="btn btn-sm btn-primary" value="Print" onclick="javascript:printDiv('PrintRecord')" id="printbutton" style="margin-bottom: 15px;" > Print</button>

    
    <asp:UpdatePanel runat="server" ID="Up">
                        <ContentTemplate>


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
                                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="lblDIV" runat="server" Text="Section" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlDIV" runat="server" CssClass="textsize" AutoPostBack="True" onselectedindexchanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="textsize"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                         <asp:DropDownList ID="ddlGender" runat="server"  
                                                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    <asp:ListItem  Value="2">Female</asp:ListItem>
                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                </asp:DropDownList>
                                                    </td>
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
                                                    <asp:Label ID="Label11" runat="server" Text="Exam" CssClass="textsize"></asp:Label>

                                                    </td>

                                                     <td align="left" valign="bottom" CssClass="efficacious_send">
                                                     <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" CssClass="textsize" ></asp:DropDownList>
                                                    
                                                    </td>
                                                    <td style="padding-left: 12px;">
                                                    <asp:Button ID="show" runat="server" CssClass="btn btn-sm btn-primary" Text="Show" onclick="show_Click" />
                                                    </td>
                                                    
                                                   
                                                </tr>
                                            </table>
                                        </div>

      <div id="PrintRecord" align="center" style="background-color:White;">
        <div class="col-md-12 col-xs-12 prl-5 d-none">
                <div class="col-md-3 col-md-offset-1 col-xs-3">
                    <img src="img/jbl.png" class="img-responsive" />
                </div>
                <div class="col-md-4 col-xs-6">
                    <div class="result-h">
                        <h2>HALF YEARLY PROGRESS REPORT</h2>
                        <h3>SESSION : <asp:Label ID="lblsession" runat="server"></asp:Label></h3>
                        <h4>LOWER PRIMARY DEPARTMENT</h4>
                    </div>
                </div>
                 <div class="col-md-3 col-xs-3">
                     <img src="img/jbl1.png" class="img-responsive" alt=""/>
                </div>

        </div>
          <div class="bor">
        <div class="col-md-12 col-sm-12 prl-5">
            <div class="student-info">
                <div class="form-inline">
                     <div class="form-group prl-10" style="margin-right:5%;">
                        <label for="Name">Name:</label>
                           <asp:Label ID="Label1" runat="server" ></asp:Label>                        
                      </div>
                        <div class="form-group prl-10" style="margin-right:3%;">
                        <label for="Class">Class :</label>
                           <asp:Label ID="Label2" runat="server"></asp:Label>                        
                      </div>
                    <div class="form-group prl-10" style="margin-right:3%;">
                        <label for="Sec">Sec :</label>
                           <asp:Label ID="Label3" runat="server"></asp:Label>                        
                      </div>
                    <div class="form-group prl-10">
                        <label for="roll no">Roll No :</label>
                           <asp:Label ID="Label4" runat="server"></asp:Label>                        
                      </div>
                </div>
               <%-- <div class="form-inline">
                     <div class="form-group prl-10"  style="margin-right:2%;">
                        <label for="Name">House :</label>
                           <asp:Label ID="Label5" runat="server" Text="GREEN"></asp:Label>                        
                      </div>
                        <div class="form-group prl-10" style="margin-right:2%;">
                        <label for="Class">Attendance :</label>
                           <asp:Label ID="Label6" runat="server" ></asp:Label>                        
                      </div>
                    <div class="form-group prl-10">
                        <label for="Sec">Out of :</label>
                           <asp:Label ID="Label7" runat="server"></asp:Label>                        
                      </div>                    
                </div>

            </div>--%>
        </div>
        <div class="clearfix"></div>
        <div class="row">
        <asp:Panel ID="pnlresult" runat="server" Visible="false">
             <div class="line-box">
        <div class="col-md-6  col-md-offset-1 col-xs-6 pr-5 pl-14 line">
            
        <%--EnglishActivity--%>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result1 table table-hover mb-0 d-none" PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                      
                                                     EmptyDataText="No Records Found" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                     
                                                         <asp:BoundField DataField="VchName" HeaderText="English Activity" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                         <asp:BoundField DataField="GRADE" HeaderText="Annual Examination" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField  HeaderText="Grade" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result1 table  table-hover mb-0 d-none" PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                      
                                                     EmptyDataText="No Records Found" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="English Reader" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField  HeaderText="Grade" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>
                                                 <asp:GridView ID="GridView5" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result1 table  table-hover mb-0 d-none" PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                      
                                                     EmptyDataText="No Records Found" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="Number Work" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField  HeaderText="Grade" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>
                                                 <asp:GridView ID="GridView6" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result1 table  table-hover mb-0 d-none" PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                      
                                                     EmptyDataText="No Records Found" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="Second Language Bengali" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField  HeaderText="Grade" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>
                                                 <asp:GridView ID="GridView7" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result1 table  table-hover mb-0 d-none" PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                      
                                                     EmptyDataText="No Records Found" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="EVS" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField  HeaderText="Grade" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                        
                                                     </Columns>
                                                 </asp:GridView>
                                                 <asp:GridView ID="GridView8" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result1 table  table-hover mb-0 d-none" PageSize="20" style="width: 98%;border-collapse:collapse;margin: 1% auto;"
                                                      
                                                     EmptyDataText="No Records Found" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="vchskillName"  ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField  HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="Grade" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                        
                                                     </Columns>
                                                 </asp:GridView>

<!--    first term      -->
<asp:Panel ID="pnlfirst" runat="server" Visible="false">
<table class="tab_result1 table table-hover mb-0">
                  <thead>
                      <tr>
                          <th>Subject</th>
                          <th>First Term</th>                          
                          <th>Grade</th>
                          
                      </tr>
                  </thead>
                  <tbody>
                      <tr>
                          <td colspan="3" style="font-weight: bold;">English Activity</td>
                      </tr>
                      <tr>
                          <td>Sentence construction</td>
                          <td text-align: left; ><asp:Label ID="lblenglishactivity1" runat="server"></asp:Label></td>                         
                          <td rowspan="5" style="vertical-align: middle;"><asp:Label ID="lblenglishactivitygrade" runat="server"></asp:Label>       </td>
                          
                      </tr>
                      <tr>
                          <td>Ability to purchase</td>
                          <td><asp:Label ID="lblenglishactivity2" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Response to concept</td>
                          <td><asp:Label ID="lblenglishactivity3" runat="server"></asp:Label></td>
                         
                      </tr>
                      <tr>
                          <td>Creative writing</td>
                          <td><asp:Label ID="lblenglishactivity4" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Car express adeqiately</td>
                          <td><asp:Label ID="lblenglishactivity5" runat="server"></asp:Label></td>
                          
                      </tr>
                       <tr>
                          <td colspan="3" style="font-weight: bold;">English Reader</td>
                      </tr>
                      <tr>
                          <td>Spelling and dictation</td>
                          <td><asp:Label ID="lblenglishreader1" runat="server"></asp:Label></td>                          
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="lblenglishreadergrade" runat="server" ></asp:Label>  </td>
                          
                      </tr>
                      <tr>
                          <td>Can comprehend text</td>
                          <td><asp:Label ID="lblenglishreader2" runat="server"></asp:Label></td>
                         
                      </tr>
                      <tr>
                          <td>Reading</td>
                          <td><asp:Label ID="lblenglishreader3" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Response to questions</td>
                          <td><asp:Label ID="lblenglishreader4" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td colspan="3" style="font-weight: bold;">Number Work</td>
                      </tr>
                       <tr>
                          <td>Number sense</td>
                          <td><asp:Label ID="lblnumberwork1" runat="server"></asp:Label></td>                          
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="lblnumberworkgrade" runat="server"></asp:Label>  </td>
                           
                      </tr>
                      <tr>
                          <td>Work accuracy</td>
                          <td><asp:Label ID="lblnumberwork2" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Concept Understanding</td>
                          <td><asp:Label ID="lblnumberwork3" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Work with tables</td>
                          <td><asp:Label ID="lblnumberwork4" runat="server"></asp:Label></td>
                          
                      </tr>
                       <tr>
                          <td colspan="3" style="font-weight: bold;"><asp:Label ID="sechindilbl1" runat="server" Text="Second Language Bengali"></asp:Label></td>
                      </tr>
                       <tr>
                          <td>Proficiency in letters and matras</td>
                          <td><asp:Label ID="lblsecondlang1" runat="server"></asp:Label></td>                          
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="lblsecondlanggrade" runat="server"></asp:Label>  </td>                           
                      </tr>
                      <tr>
                          <td>Spelling and dictation</td>
                          <td><asp:Label ID="lblsecondlang2" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Sentence contruction</td>
                          <td><asp:Label ID="lblsecondlang3" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Reading</td>
                          <td><asp:Label ID="lblsecondlang4" runat="server"></asp:Label></td>
                          
                      </tr>
                       <tr>
                          <td colspan="3" style="font-weight: bold;">EVS</td>
                      </tr>
                       <tr>
                          <td>Observance and curiosity</td>
                          <td><asp:Label ID="lblevs1" runat="server"></asp:Label></td>                          
                          <td rowspan="3" style="vertical-align: middle;"><asp:Label ID="lblevsgrade" runat="server"></asp:Label>  </td>                           
                      </tr>
                      <tr>
                          <td>Concept and curiosity</td>
                          <td><asp:Label ID="lblevs2" runat="server"></asp:Label></td>
                          
                      </tr>
                      <tr>
                          <td>Drawing and activity</td>
                          <td><asp:Label ID="lblevs3" runat="server"></asp:Label></td>
                          
                      </tr>

                                             <tr>
                          <td colspan="3" style="font-weight: bold;">Computer</td>
                      </tr>

<%--                       <tr>
                          <td>Computer</td>
                          <td><asp:Label ID="lblcomputer1" runat="server"></asp:Label></td>                          
                          <td rowspan="3" style="vertical-align: middle;"><asp:Label ID="lblcomputergrd" runat="server"></asp:Label>  </td>                           
                      </tr>--%>
                      <tr>
                          <td>Can relate hardware to this functions</td>
                          <td><asp:Label ID="lblcomputer2" runat="server"></asp:Label></td>
                          <td rowspan="2" style="vertical-align: middle;"><asp:Label ID="lblcomputergrd" runat="server"></asp:Label>  </td> 
                          
                      </tr>
                            <tr>
                          <td>Is able to follow the operations</td>
                          <td><asp:Label ID="lblcomputer3" runat="server"></asp:Label></td>
                          
                      </tr>


<%--                       <tr>
                          <td colspan="2" style="font-weight: bold;">Art & Craft</td>
                           <td><asp:Label ID="lblartcrft" runat="server"></asp:Label></td>
                           
                      </tr>
                       <tr>
                          <td colspan="2" style="font-weight: bold;">P.T.</td>
                           <td><asp:Label ID="lblpt" runat="server"></asp:Label></td>
                          
                      </tr>--%>
                  </tbody>

            </table>
            </asp:Panel>

   <!-- final term -->
   <asp:Panel ID="pnlfinal" runat="server" Visible="false">
              <table class="tab_result1 table table-hover mb-0">
                  <thead>
                      <tr>
                          <th>Subject</th>
                          <th>First Term</th>                          
                          <th>Grade</th>
                          <th>Second Term</th>
                          <th>Grade</th>
                      </tr>
                  </thead>
                  <tbody>
                      <tr>
                          <td colspan="6" style="font-weight: bold;">English Activity</td>
                      </tr>
                      <tr>
                          <td>Sentence construction</td>
                          <td><asp:Label ID="lblenglishactivity11" runat="server"></asp:Label></td>                         
                          <td rowspan="5" style="vertical-align: middle;"><asp:Label ID="Label12" runat="server"></asp:Label>       </td>
                           <td><asp:Label ID="lblengactgrade11" runat="server"></asp:Label></td>
                          <td rowspan="5" style="vertical-align: middle;"><asp:Label ID="Label17" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>Ability to purchase</td>
                          <td><asp:Label ID="lblenglishactivity22" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblengactgrade22" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Response to concept</td>
                          <td><asp:Label ID="lblenglishactivity33" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblengactgrade33" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Creative writing</td>
                          <td><asp:Label ID="lblenglishactivity44" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblengactgrade44" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Car express adeqiately</td>
                          <td><asp:Label ID="lblenglishactivity55" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblengactgrade55" runat="server"></asp:Label></td>                          
                      </tr>
                       <tr>
                          <td colspan="6" style="font-weight: bold;">English Reader</td>
                      </tr>
                      <tr>
                          <td>Spelling and dictation</td>
                          <td><asp:Label ID="lblenglishreader11" runat="server"></asp:Label></td>                          
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="Label13" runat="server" ></asp:Label>  </td>
                          <td><asp:Label ID="lblenglishreadergrade11" runat="server"></asp:Label></td>
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="Label18" runat="server" ></asp:Label>  </td>
                      </tr>
                      <tr>
                          <td>Can comprehend text</td>
                          <td><asp:Label ID="lblenglishreader22" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblenglishreadergrade22" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Reading</td>
                          <td><asp:Label ID="lblenglishreader33" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblenglishreadergrade33" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Response to questions</td>
                          <td><asp:Label ID="lblenglishreader44" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblenglishreadergrade44" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td colspan="6" style="font-weight: bold;">Number Work</td>
                      </tr>
                       <tr>
                          <td>Number sense</td>
                          <td><asp:Label ID="lblnumberwork11" runat="server"></asp:Label></td>                          
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="Label14" runat="server"></asp:Label>  </td>
                           <td><asp:Label ID="lblnumberworkgrade11" runat="server"></asp:Label></td>
                           <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="Label23" runat="server"></asp:Label>  </td>
                      </tr>
                      <tr>
                          <td>Work accuracy</td>
                          <td><asp:Label ID="lblnumberwork22" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblnumberworkgrade22" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Concept Understanding</td>
                          <td><asp:Label ID="lblnumberwork33" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblnumberworkgrade33" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Work with tables</td>
                          <td><asp:Label ID="lblnumberwork44" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblnumberworkgrade44" runat="server"></asp:Label></td>                          
                      </tr>
                       <tr>
                          <td colspan="6" style="font-weight: bold;">Second Language Bengali</td>
                      </tr>
                       <tr>
                          <td>Proficiency in letters and matras</td>
                          <td><asp:Label ID="lblsecondlang11" runat="server"></asp:Label></td>                          
                          <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="Label15" runat="server"></asp:Label>  </td>
                           <td><asp:Label ID="lblsecondlanggrade11" runat="server"></asp:Label></td>
                           <td rowspan="4" style="vertical-align: middle;"><asp:Label ID="Label19" runat="server"></asp:Label>  </td>
                      </tr>
                      <tr>
                          <td>Spelling and dictation</td>
                          <td><asp:Label ID="lblsecondlang22" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblsecondlanggrade22" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Sentence contruction</td>
                          <td><asp:Label ID="lblsecondlang33" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblsecondlanggrade33" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Reading</td>
                          <td><asp:Label ID="lblsecondlang44" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblsecondlanggrade44" runat="server"></asp:Label></td>                          
                      </tr>
                       <tr>
                          <td colspan="6" style="font-weight: bold;">EVS</td>
                      </tr>
                       <tr>
                          <td>Observance and curiosity</td>
                          <td><asp:Label ID="lblevs11" runat="server"></asp:Label></td>                          
                          <td rowspan="3" style="vertical-align: middle;"><asp:Label ID="Label16" runat="server"></asp:Label>  </td>
                           <td><asp:Label ID="lblevsgrade11" runat="server"></asp:Label></td>
                           <td rowspan="3" style="vertical-align: middle;"><asp:Label ID="Label20" runat="server"></asp:Label>  </td>
                      </tr>
                      <tr>
                          <td>Concept and curiosity</td>
                          <td><asp:Label ID="lblevs22" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblevsgrade22" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Drawing and activity</td>
                          <td><asp:Label ID="lblevs33" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblevsgrade33" runat="server"></asp:Label></td>                          
                      </tr>

                                             <tr>
                          <td colspan="6" style="font-weight: bold;">Computer</td>
                      </tr>
                       <tr>
                          <td>Computer</td>
                          <td><asp:Label ID="lblcomputer11" runat="server"></asp:Label></td>                          
                          <td rowspan="3" style="vertical-align: middle;"><asp:Label ID="Label25" runat="server"></asp:Label>  </td>
                           <td><asp:Label ID="lblcomputergrd11" runat="server"></asp:Label></td>
                           <td rowspan="3" style="vertical-align: middle;"><asp:Label ID="Label27" runat="server"></asp:Label>  </td>
                      </tr>
                      <tr>
                          <td>Can relate hardware to this functions</td>
                          <td><asp:Label ID="lblcomputer22" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblcomputergrd22" runat="server"></asp:Label></td>                          
                      </tr>
                      <tr>
                          <td>Is able to follow the operations</td>
                          <td><asp:Label ID="lblcomputer33" runat="server"></asp:Label></td>
                          <td><asp:Label ID="lblcomputergrd33" runat="server"></asp:Label></td>                          
                      </tr>


                  </tbody>

            </table> 
            </asp:Panel> 
        </div>
        <div class="col-md-4 col-xs-6 pl-5 pr-15">

            <%--  <div class="l_child">
                    <img src="images/line1.jpg" alt=""/>
                </div>--%>

         <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result table table-hover mb-0 " PageSize="20" style="width: 98%;border-collapse:collapse;margin: auto;"
                                                      
                                                     EmptyDataText="No Records Found" Visible="false" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="Work Habit" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="First Term" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>
           
           
            <asp:GridView ID="GridView4" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result table col  table-hover mb-0" PageSize="20" style="width: 98%;border-collapse:collapse;margin: auto;"
                                                      
                                                     EmptyDataText="No Records Found" Visible="false" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="Personal & Social Traits" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="GRADE" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>

                                                    <asp:GridView ID="GridView9" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result table table-hover mb-0 " PageSize="20" style="width: 98%;border-collapse:collapse;margin: auto;"
                                                      
                                                     EmptyDataText="No Records Found" Visible="false" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="Work Habit" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="UTI" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="UTII" HeaderText="Final Term" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         
                                                        
                                                     </Columns>
                                                 </asp:GridView>
           <%--  <table class="tab_result table table-hover mb-0" style="width: 98%;border-collapse:collapse;margin: auto;     border-top: 0px !important;">
                        <tbody>
                               <tr>
                          <td style="font-weight: bold;    border-top: 0px !important;">Art & Craft</td>
                           <td style="border-top: 0px !important;"><asp:Label ID="lblartcrft" runat="server"></asp:Label></td>
                        
                           <td class="d-none" style="    "><asp:Label ID="Label21" runat="server"></asp:Label></td>
                      </tr>
                       <tr>
                          <td style="font-weight: bold; ">P.T.</td>
                           <td><asp:Label ID="lblpt" runat="server"></asp:Label></td>
                           
                           <td class="d-none"> <asp:Label ID="Label22" runat="server"></asp:Label></td>
                      </tr>
                      </tbody>
                      </table>--%>
           
            <asp:GridView ID="GridView10" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
                                                     CssClass="tab_result table  table-hover mb-0" PageSize="20" style="width: 98%;border-collapse:collapse;margin: auto;"
                                                      
                                                     EmptyDataText="No Records Found" Visible="false" > 
                                                     <AlternatingRowStyle CssClass="alt" />
                                                     <Columns>
                                                         <asp:BoundField DataField="VchName" HeaderText="Personal & Social Traits" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="UTI" HeaderText="UTI" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="UTII" HeaderText="Final Term" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="Half Yearly" HeaderText="Final Term" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="Annual Examination" HeaderText="Final Term" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                        
                                                     </Columns>
                                                 </asp:GridView>
                      
                      
          
            <div class="grad mt-5">
                <h4>Key to Grades & symbols</h4>
                <ul>
                    <li><i class="sp">A+ </i><span>90 up</span></li>
                    <li><i class="sp">A  </i><span>80-89</span></li>
                    <li><i class="sp">B+ </i><span>70-79</span></li>
                    <li><i class="sp">B  </i><span>60-69</span></li>
                    <li><i class="sp">C+ </i><span>50-59</span></li>
                    <li><i class="sp">C </i>  <span>40-49</span></li>
                    <li><i class="sp">D </i>  <span>below 40</span></li>
                </ul>
                 <ul>
                    <li>  <i>	&#x2714; &#x2714; &#x2714;</i> <span>Very Good</span></li>
                     <li class="pt-15"><i>&#x2714; &#x2714; </i>  <span>Good</span></li>
                     <li class="pt-15"> <i>&#x2714;</i> <span>Satisfactory</span></li>
                     <li class="pt-15"> NI <span>Needs to Improve</span></li>
                </ul>
            </div>
            <div class="col-md-12 ">
                <div class="form-horizontal">   
            <div class="form-group pb-15 mb-0">
                <span class="col-md-12 col-xs-12 mt-10 text-center"><strong>    Area of Strength: </strong></span>
                <asp:Label ID="Label8" runat="server" Text="Label" CssClass="col-xs-12 prl-5 h-52" style="text-align:left;border-bottom:1px solid black"></asp:Label>
                <asp:Label ID="Label24" runat="server" Text="" CssClass="col-xs-12 prl-5" style="text-align:left;"></asp:Label>
            </div>
            <div class="form-group mb-0">
                <span class="col-md-12 col-xs-12 mt-10  text-center"><strong>Teacher's Suggestion: </strong></span>
                <asp:Label ID="Label9" runat="server" Text="Label" CssClass="col-xs-12 prl-5 h-70"  style="text-align:left;border-bottom:1px solid black"></asp:Label>
                <asp:Label ID="Label26" runat="server" Text="" CssClass="col-xs-12 prl-5"  style="text-align:left;"></asp:Label>
            </div>
            <div class="form-group mb-0">
                <div class="col-xs-6" style="text-align:center; margin-top:68px;">
                    <h6 class="mtb-0" style="border-top: 1px solid black; padding-top: 8px;">Class Teacher</h6>
                </div>
                <div class="col-xs-6 sign" style="text-align:center; margin-top:30px; padding-top:38px;">
                    <h6 class="mtb-0" style="border-top: 1px solid black; padding-top: 8px;">Principal</h6>
                    <img src="images/principle_sign.png" alt="" />
                </div>
            </div>
            </div>

            </div>
           <%-- <div class="p-message">
                <h4>Parent's Message</h4>
                <ol>
                    <li>Student of ckasses up to IV are not awarded any position</li>
                    <li>The Report Card is to be signed by the Parents / Guardian and returned to the Class Teacher on the notified date.</li>
                    <li>Parents and pupils ought to bear in mind that final Examination results are 'Final' and will not be changed. Any request are from the parent's site
                        towards any alteration will not be entertained                    </li>
                    <li>In the event of loss of this Progress Report, a duplicate Report may be issued only on payment of Rs.100/- at School Office.</li>
                </ol>
            </div>--%>

       </div>
        </div>
        <div class="col-md-10  col-md-offset-1 col-xs-12  mt-15">           
              <h6 class=" text-left"></h6> 
            <h6 class=" text-left" style="padding-left: 36px;"></h6> 
             <h6 style=" border-top: 1px solid black;padding-top: 5px; text-align:center; margin:5px 0 0 0; font-size:11px;"><strong>Main Campus :</strong> Tiljala Road, Kol-120, <strong>Bypass Unit:</strong> 13/2/6, Mahendra Roy Lane, Kol-120, <strong>Park Circus Unit:</strong> 1, Shamsul Huda Road, Kol-120 </h6>
            <h6 style=" text-align:center;"><strong>Central Avenure Unit:</strong> 27/1, Debendra Mullick St., Kol-73, <strong>Metiabruz Unit: </strong> 1/58, Garden Reach Road, Kol-120 </h6>
            <h6 style=" text-align:center; ">Website: www.cmsbarrakpore.com, Email: info@cmsbarrackpore.org</h6>
            <!--   margin:5px 0 0 0; old-->
        </div>
        </asp:Panel>
            </div>

    </div>
</div>   

</ContentTemplate>
</asp:UpdatePanel>


    
    </div>
</section>
</div>
</section>
</asp:Content>


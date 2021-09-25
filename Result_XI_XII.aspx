<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Result_XI_XII.aspx.cs" Inherits="Result_XI_XII" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
        .w-20 {width:20%;  float:left;    padding:5px 10px;  }
        .w-60 {width:60%;  float:left;    padding:5px 10px;  }
        p,li{ font-family:Arial, Helvetica, sans-serif,Webdings; }
       .h-30{height:30px;}
        .h-50 {height:50px;        }
        .mt-55 {margin-top:55px;        }
        .h-52 {    height: 52px;}
        .mtb-0 {margin-top:0; margin-bottom:0;        }
        .result-h { display:block;    text-align:center;    }
        .result-h h2{ margin-bottom:3px;margin-top: 3px;   color: #025402;}        .result-h h3{font-size:19px;  margin-bottom:3px;}     
          .result-h h4{font-size:16px;  margin-top: 3px; margin-bottom:3px;}
            .result-h p {       margin: 0;            }
         /*.result-h h2, .result-h h3, .result-h h4 { padding:0; margin-top:5px;      margin-bottom: 0;          }*/
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
.tab_result1 tr td { /* border:1px solid #929292 !important; color- light black */  border:1px solid black !important;       padding: 2px 4px !important;       }

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
            .w-m-15 {width:15%;  float:left;    padding:10px 15px 5px;  }
        .w-m-70 {width:70%;  float:left;    padding:5px 10px;  }
            .result-h img {margin:0 auto;  text-align:center          }
            .result-h h2{ margin-bottom:3px !important; margin-top: 3px;  color: #025402;}        .result-h h3{font-size:19px !important;  margin-bottom:3px !important;}     
          .result-h h4{font-size:16px !important;     margin-top: 3px; margin-bottom:3px !important;}
            .result-h p {       margin: 0 !important;            }
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
<div class="row">
            <section class="col-md-12 col-xs-12">
                <div class="box box-orange">
   <%-- <button class="btn btn-sm btn-primary"  onclick="Img1_Click" id="printbutton" style="margin-bottom: 15px;" > Print</button>--%>
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm btn-primary" Text="Print" onclick="Img1_Click" Visible="false" />


    
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
                                                            <asp:ListItem Value="11" Text="XI Arts"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="XII Arts"></asp:ListItem>
                                                            <asp:ListItem Value="21" Text="XI Com"></asp:ListItem>
                                                            <asp:ListItem Value="22" Text="XII Com"></asp:ListItem>
                                                            <asp:ListItem Value="23" Text="XI Sc"></asp:ListItem>
                                                            <asp:ListItem Value="24" Text="XII Sc"></asp:ListItem>
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

<div class="col-md-12 col-sm-12 prl-5">
        <div class="clearfix"></div>
        <div class="row">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"></CR:CrystalReportViewer>
        </div>
        </div>
        


                                        </ContentTemplate>
</asp:UpdatePanel>


    
    </div>
</section>
</div>
</asp:Content>


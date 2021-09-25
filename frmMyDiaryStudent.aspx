<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmMyDiaryStudent.aspx.cs" Inherits="frmMyDiaryStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <head>
    </head>
    <div class="clearfix">
    </div>
    <div class="content-header">
        <h1>
            My Diary
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>            
            <li class="active">My Diary</li>
        </ol>
    </div>
    <table width="100%">
        <caption>
            <iframe id="frame" frameborder="0" src="frmMyDiaryCal.aspx" width="100%" height="450px"
                style="overflow: scroll;"></iframe>
        </caption>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmSyllabusMst.aspx.cs" Inherits="frmSyllabusMst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        $("#<%=ChkDivList.ClientID %>  input").css({
            "borderBottomWidth": "2px",
            "borderBottomStyle": "solid",
            "backgroundColor": "red",
            "color": "black",
            "textAlign": "right",
            "fontWeight": "bold"
        });
    </script>
    <style type="text/css">
        .style1 label
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input[type=text]
        {
            display: inline;
            float: left;
            color: #000;
            cursor: pointer;
            text-indent: 20px;
            white-space: nowrap;
        }
        .style1 input, form.winner-inside textarea, select
        {
            display: block;
            border: 1px solid #3498db;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .style1 select
        {
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
        }
        .efficacious_send
        {
            width: 40% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 1px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .efficacious_send_Plus
        {
            width: 26% !important;
            background: #3498db !important;
            border: none !important;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 1px;
            color: #fff;
            margin: 7px auto !important;
            padding: 3px;
            cursor: pointer;
            height: 28px !important;
            float: left;
            text-align: center !important;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        label
        {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 200;
            font-size: 12px;
            color: Black;
        }
        .standard-division ul
        {
            list-style: none;
            text-align: left;
            margin-top: 20px;
        }
        .standard-division ul li a
        {
            font-size: 16px;
        }
        .standard-division ul li a i
        {
            color: Red;
        }
        .TabPanel1{ display:none; }
    </style>
    <script type="text/javascript" language="javascript">
        var counter = 1;
        var limit = 5;
        function addInput12(divName) {
            if (counter == limit) {
                alert("You have reached the limit of adding " + counter + " inputs");
            }
            else {
                var newdiv = document.createElement('div');
                newdiv.innerHTML = "Entry " + (counter + 1) + " <br><input type='text'  name='myInputs[]'> ";
                document.getElementById(divName).appendChild(newdiv);
                counter++;
            }
        }

        function addInput(divName) {
            if (counter == limit) {
                alert("You have reached the limit of adding " + counter + " inputs");
            }
            else {
                var txtBxHolder = document.getElementById(divName);
                var newTxtBx = document.createElement('input');
                newTxtBx.type = 'text';
                txtBxHolder.appendChild(newTxtBx);
                counter++;
            }
        }

        function RemoveInput(divName) {
            var allTxtBxs = document.getElementById(divName).getElementsByTagName('input');
            if (allTxtBxs.length == 1) {
                alert('Add atleast one record');
            }
            else {
                document.getElementById(divName).removeChild(allTxtBxs[allTxtBxs.length - 1]);
                counter--;
            }

        }

        function TopicValidation() {
            var STD = document.getElementById("<%=ddlSTD.ClientID %>").value;
            var Subject = document.getElementById("<%=ddlSubject.ClientID %>").value;
            var Topic = document.getElementById("<%=txtTopicNm.ClientID %>").value;
            if (STD == 0) {
                alert('Please Select Standard First');
                return false;
            }
            if (ConfirmMsg() == false) {
                return false;
            }
            if (Subject == 0) {
                alert('Please Select Subject');
                return false;
            }
            else if (Topic.trim() == '') {
                alert('Please Enter Topic Name');
                return false;
            }
            return true;

        }

        function ConfirmMsg() {
            //            if (Page_ClientValidate()) {
            var CHK = document.getElementById("<%=ChkDivList.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var counter = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    counter++;
                }
            }
            if (1 > counter) {
                alert("Please select atleast " + 1 + " division");
                return false;
            }
            return true;
            //            }
        }

        function SyllabusValidation() {
            var syllabus = document.getElementById("<%=txtAddSyllabus.ClientID %>").value;
            if (syllabus.trim() == '') {
                alert('Please Enter Syllabus Name First');
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function GetDynamicTextBox(value) {
            alert(value);
            return '<tr><td><input name = "DynamicTextBox" type="text" style="margin-left:10px" class="input-blue" value = "' + value + '" /></td><td><asp:FileUpload ID="FileUploadDoc" Style="font-size: 11px;" runat="server" /></td>' +
                    '<td><input type="button" value="x" class="efficacious_send_Plus" style="width:18%; margin-right:10px; " onclick = "RemoveTextBox(this)" /></td></tr>'
        }
        function AddTextBox() {
            var div = document.createElement('DIV');
            div.innerHTML = GetDynamicTextBox("");
            document.getElementById("TextBoxContainer").appendChild(div);
        }

        function RemoveTextBox(div) {
            document.getElementById("TextBoxContainer").removeChild(div.parentNode);
        }

        function RecreateDynamicTextboxes() {
            var values = eval('<%=Values%>');
            if (values != null) {
                var html = "";
                for (var i = 0; i < values.length; i++) {
                    html += "<div>" + GetDynamicTextBox(values[i]) + "</div>";
                }
                document.getElementById("TextBoxContainer").innerHTML = html;
            }
        }
        window.onload = RecreateDynamicTextboxes;

        function CreateTextBox() {
            var div = document.createElement('DIV');
            div.innerHTML = assignValueToTextBox();
            document.getElementById("TextBoxContainer").appendChild(div);
        }

        function assignValueToTextBox() {
            var myArray = ["Lion", "Tiger", "Deer", "Elephant", "Zebra"];
            for (i = 0; i < myArray.length; i++) {
                $("<div />", {
                    "class": "ui-block-a"
                }).append($("<input />", {
                    "data-role": "none",
                    "value": myArray[i],
                    "type": "text",
                    "readonly": true
                })).appendTo(".ui-grid-a");
            }
        }


        function ConfirmDelete() {

            var con = confirm('Do You Really Want To Delete Selected Record?');
            if (con) {
                return true;
            }
            else {
                return false;
            }

        }

    </script>
    <script type="text/javascript">

        function AddDiv() {
            var count = 5
            for (var i = 0; i < count; i++) {
                var div = document.createElement('DIV');
                var div1 = document.createElement('DIV');
                document.getElementById("CollapsDiv").appendChild(div);
                document.getElementById("CollapsDiv").appendChild(div1);
            }

        }

        $(function () {
            $('.1').click(function () {
                $(".slidedivH").slideToggle();
            });
        });
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_tabcon_View_pnl0{ background#f5f5f5 !important;}
        .slidedivH
        {
            width: 80%;
            padding: 20px;
            background: #FFAA;
            color: #fff;
            margin-top: 10px;
            border-bottom: 5px solid #FFF;
            display: none;
        }
        .mGrid th{ text-align:center !important;}
        .efficacious span {
            display: block;
            height: auto;
            padding: 10px 0px;
            font-size: 12px !important;
            margin: 0% !important;
            padding: 2%;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: 120px;
            color: #000;
        }
        .modalBackground
        {
            height: 100%;
            background-color: #EBEBEB;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        #grv0{ width:100% !important;}
         #grv1{ width:100% !important;}
          #grv2{ width:100% !important;}
    </style>
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
    <style>
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .d-none {display:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">
        <ul class="top_nav1 sp">
            <li><a>Study <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmTeacherTimeTable.aspx">Time Table</a></li>
            <li><a href="frmExaminationSchedule.aspx">Examination</a></li>
            <li class="active1"><a href="frmSyllabusMst.aspx">Syllabus</a></li>
            <li><a href="frmMarksEntry.aspx">Marks Entry</a></li>
            <li><a href="Result.aspx">Result</a></li>
        </ul>
    </div>
    <section class="content">

    <div>
        <table width="9%" align="right" style="margin-right: 65px;">
            <tr>
                <td width="3%">
                    <asp:ImageButton ID="ImgExcel" Height="20px" OnClick="ImgExcel_Click" ToolTip="Export To Excel" Visible="false" 
                        ImageUrl="~/images/xlsImg.gif" runat="server" />
                </td>
               
            </tr>
        </table>
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
                <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="tabcon" ActiveTabIndex="1"
                    Width="99%" >
                    <asp:TabPanel ID="View" HeaderText="View" runat="server" >
                        <ContentTemplate>
                            <center>
                                <div class="efficacious">
                                    <table width="90%" style="margin-top: 15px;">
                                        <tr>
                                            <td align="center">
                                                <table runat="server" id="filtertable" width="40%">
                                                    <tr runat="server">
                                                    <td runat="server">
                                                        <asp:Label ID="Label10" runat="server" Style="position: relative; top: 5px; text-align: right; left: 0px;"
                                                            Text="Exam" visible="false"></asp:Label>
                                                    </td>
                                                    <td runat="server">
                                                        <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" onselectedindexchanged="ddlExam_SelectedIndexChanged" visible="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                        <td runat="server">
                                                            <asp:Label ID="lblSTD1" runat="server" Style="position: relative; top: 5px; text-align: right;" 
                                                                Text="STD"></asp:Label>
                                                        </td>
                                                        <td runat="server">
                                                            <asp:DropDownList ID="ddlSTD1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            
                                                        </td>
                                                        <td runat="server">
                                                            <asp:Label ID="lblDIV12" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                Text="DIV" Visible="false"></asp:Label>
                                                        </td>
                                                        <td align="left" runat="server">
                                                            <asp:DropDownList ID="ddlDIV" runat="server" OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged"
                                                                AutoPostBack="True" Visible="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td runat="server" visible="false">
                                                            <asp:Label ID="lblSub1" runat="server" Style="position: relative; top: 5px; text-align: right;" 
                                                                Text="Subject"></asp:Label>
                                                        </td>
                                                        <td align="left" runat="server" visible="false">
                                                            <asp:DropDownList ID="ddlSub" runat="server" OnSelectedIndexChanged="ddlSub_SelectedIndexChanged"  AutoPostBack="True">
                                                        
                                                               
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td>
                                                <div id="CollapsDiv" runat="server" style="overflow: hidden;">
         <ul class="brochure">
  <li>
    <a class="fa fa-file-pdf-o fa-2x" href="pdf/CLASS XI HINDI.pdf" target="_blank">    
      <span>Class XI HINDI </span>
    </a> 
  </li>
</ul>
</div>
<div id="Div1" runat="server" style="overflow: hidden;">
         <ul class="brochure">
  <li>
    <a class="fa fa-file-pdf-o fa-2x" href="pdf/CLASS XI HINDI.pdf" target="_blank">    
      <span>Class XI HINDI </span>
    </a> 
  </li>
</ul>
                                                </div>
<div id="Div2" runat="server" style="overflow: hidden;">
         <ul class="brochure">
  <li>
    <a class="fa fa-file-pdf-o fa-2x" href="pdf/BENGALI XI  2ND UNIT.pdf" target="_blank">    
      <span>Class XI HINDI </span>
    </a> 
  </li>
</ul>
</div>
<div id="Div3" runat="server" style="overflow: hidden;">
         <ul class="brochure">
  <li>
    <a class="fa fa-file-pdf-o fa-2x" href="pdf/CLASS XI MATHEMATICS.pdf" target="_blank">    
      <span>Class XI HINDI </span>
    </a> 
  </li>
</ul>
</div>
</td>
</tr>           <!-- tr close  hide-->
</table>
                                </div>
                                 <div class="standard-division" id="pdf1" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS -1/BENGALI-HINDI-ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-HINDI-ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS -1/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> ENGLISH </a> </li>
                                     <li> <a href="pdf/CLASS -1/COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS -1/ENGLISH-LITERATURE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH LITERATURE</a> </li>
                                     <li> <a href="pdf/CLASS -1/EVS-CRAFT-DRAWING.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>EVS-CRAFT-DRAWING</a> </li>
                                     <li> <a href="pdf/CLASS -1/MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS</a> </li>
                                     <li> <a href="pdf/CLASS -1/MUSIC-DANCE-COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MUSIC-DANCE-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS -1/SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SCIENCE</a> </li>
                                     <li> <a href="pdf/CLASS -1/SST-GK-VED.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SST-GK-VED</a> </li>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf2" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-2/BENGALI-HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-HINDI</a> </li>
                                     <li> <a href="pdf/CLASS-2/ENGLISH-LITERATURE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH-LITERATURE</a> </li>
                                     <li> <a href="pdf/CLASS-2/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-2/MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS</a> </li>
                                      <li> <a href="pdf/CLASS-2/SCIENCE-SST.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SCIENCE-SST</a> </li>
                                     <li> <a href="pdf/CLASS-2/VED-EVS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>VED-EVS</a> </li>
                                     <%-- <li> <a href="pdf/CLASS-2/VED,EVS,CRAFT,DRAWING,PT,MUSIC.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>VED-EVS-CRAFT-DRAWING-PT-MUSIC</a> </li>
                               --%>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf3" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-3/BENGALI-HINDI-MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-HINDI-MATHEMATICS</a> </li>
                                     <li> <a href="pdf/CLASS-3/COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-3/DWAWING-PT-DANCE-COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DWAWING-PT-DANCE-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-3/ENGLISH-LITERATURE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH LITERATURE</a> </li>
                                     <li> <a href="pdf/CLASS-3/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-3/GK-VED-EVS-CRAFT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>GK-VED-EVS-CRAFT</a> </li>
                                     <%--<li> <a href="pdf/CLASS-3/HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>HINDI</a> </li>  --%>
                                     <li> <a href="pdf/CLASS-3/MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS</a> </li>
                                     <li> <a href="pdf/CLASS-3/SCIENCE-SST.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SCIENCE-SST</a> </li>
                                     
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf4" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-4/BENGALI-MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-MATHEMATICS</a> </li>
                                     <li> <a href="pdf/CLASS-4/DANCE-COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DANCE-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-4/ENGLISH-LITERATURE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH-LITERATURE.pdf</a> </li>
                                     <li> <a href="pdf/CLASS-4/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                      <li> <a href="pdf/CLASS-4/EVS-CRAFT-DWAWING-DANCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>EVS-CRAFT-DWAWING-DANCE</a> </li>
                                     <li> <a href="pdf/CLASS-4/MATHEMATICS-SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS-SCIENCE</a> </li>
                                     <li> <a href="pdf/CLASS-4/SST-GK-VED.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SST-GK-VED</a> </li>
                                     
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf5" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-5/BENGALI-HINDI-LOWER HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DANCE-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-5/DANCE-COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DANCE-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-5/ENGLISH-BENGALI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH-BENGALI</a> </li>
                                     <li> <a href="pdf/CLASS-5/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-5/evs-craft-drawing-pt-music.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>EVS-CRAFT-DRAWING-PT-MUSIC</a> </li>
                                     <li> <a href="pdf/CLASS-5/maths-science.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS-SCIENCE</a> </li>
                                     <li> <a href="pdf/CLASS-5/sst-gk-ved.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SST-GK-VED</a> </li>
                                     
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf6" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-6/BENGALI-LOWERBENGALI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-LOWERBENGALI</a> </li>
                                     <li> <a href="pdf/CLASS-6/DANCE - PHYSICAL EDUCATION.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DANCE - PHYSICAL EDUCATION</a> </li>
                                     <li> <a href="pdf/CLASS-6/DWAWING-GENERAL KNOWLEDGE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DWAWING-GENERAL KNOWLEDGE</a> </li>
                                     <li> <a href="pdf/CLASS-6/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-6/HINDI-LOWER HINDI ALL.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>HINDI-LOWER HINDI</a> </li>
                                     <li> <a href="pdf/CLASS-6/MATHEMATICS -SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS-SCIENCE</a> </li>
                                      <li> <a href="pdf/CLASS-6/MUSIC-EVS-COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MUSIC-EVS-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-6/SOCIAL SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SOCIAL SCIENCE</a> </li>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf7" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS XI HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>dsdads </a> </li>
                                     <li> <a href="pdf/CLASS XI BENGALI  1ST UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> sadsad  </a> </li>
                                     <li> <a href="pdf/BENGALI XI  2ND UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                     <li> <a href="pdf/CLASS XI MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                     
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf8" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-8/BENGALI-MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-MATHEMATICS</a> </li>
                                     <li> <a href="pdf/CLASS-8/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-8/ENVORONMENT SCIENCE-COMPUTER.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENVORONMENT SCIENCE-COMPUTER</a> </li>
                                     <li> <a href="pdf/CLASS-8/GENERAL KNOWLEDGE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>GENERAL KNOWLEDGE</a> </li>
                                     <li> <a href="pdf/CLASS-8/GEOGRAPHY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>GEOGRAPHY</a> </li>
                                     <li> <a href="pdf/CLASS-8/HINDI-LOWER HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>HINDI-LOWER HINDI</a> </li>
                                     <li> <a href="pdf/CLASS-8/PHYSICAL EDUCATION-MUSIC.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>PHYSICAL EDUCATION-MUSIC</a> </li>
                                     <li> <a href="pdf/CLASS-8/SCIENCE-DANCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SCIENCE-DANCE</a> </li>
                                     <li> <a href="pdf/CLASS-8/SOCIAL SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SOCIAL SCIENCE</a> </li>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf9" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-9/BENGALI-PHYSICS-CHEMISTRY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-PHYSICS-CHEMISTRY</a> </li>
                                     <li> <a href="pdf/CLASS-9/CHEMISTRY-BIOLOGY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>CHEMISTRY-BIOLOGY</a> </li>
                                     <li> <a href="pdf/CLASS-9/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-9/ENGLISH-MATH-SOCIALSCEINCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH-MATH-SOCIALSCEINCE</a> </li>
                                     <li> <a href="pdf/CLASS-9/SOCIAL SCIENCE-HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SOCIAL SCIENCE-HINDI</a> </li>
                                    <li> <a href="pdf/CLASS-9/SOCIAL SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SOCIAL SCIENCE</a> </li>
                                    <li> <a href="pdf/CLASS-9/YOGA-EVS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>YOGA-EVS</a> </li>
                                    
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf10" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-10/BENGALI-CHEMISTRY-PHYSICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-CHEMISTRY-PHYSICS</a> </li>
                                     <li> <a href="pdf/CLASS-10/ENGLISH-MATH-SOCIALSCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH-MATH-SOCIALSCIENCE</a> </li>
                                     <li> <a href="pdf/CLASS-10/ENGLISH.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/CLASS-10/EVS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>EVS</a> </li>
                                     <li> <a href="pdf/CLASS-10/HINDI-BENGALI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>HINDI-BENGALI</a> </li>
                                     <li> <a href="pdf/CLASS-10/PHYSICS-BIO-YOGA.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>PHYSICS-BIO-YOGA</a> </li>
                                     <li> <a href="pdf/CLASS-10/SOCIAL SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SOCIAL SCIENCE</a> </li>
                                     
                                    </ul>
                                </div>
                                <div class="standard-division" id="pdf12" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-12/COMPUTER SCIENCE-SOCIOLOGY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>COMPUTER SCIENCE-SOCIOLOGY</a> </li>
                                     <li> <a href="pdf/CLASS-12/HISTORY-PHYSICAL SCIENCE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>HISTORY-PHYSICAL SCIENCE</a> </li>
                                     <li> <a href="pdf/CLASS-12/HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>HINDI</a> </li>
                                     <li> <a href="pdf/CLASS-12/POLITICAL SCIENCE-GEOGRAPHY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>POLITICAL SCIENCE-GEOGRAPHY</a></li>
                                     <li> <a href="pdf/CLASS-12/PSYCHOLOGY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>PSYCHOLOGY</a> </li>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf13" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/NURSERY/drawing.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>DRAWING</a> </li>
                                     <li> <a href="pdf/NURSERY/english-test.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH-TEST</a> </li>
                                     <li> <a href="pdf/NURSERY/english.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf14" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/P-1/bengali-english.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-ENGLISH</a> </li>
                                     <li> <a href="pdf/P-1/english.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/P-1/gk.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>GK</a> </li>
                                     <li> <a href="pdf/P-1/secien-maths.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SCIENCE-MATHEMATICS</a> </li>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf15" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/P-1/bengali-english.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BENGALI-ENGLISH</a> </li>
                                     <li> <a href="pdf/P-1/english.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH</a> </li>
                                     <li> <a href="pdf/P-1/gk.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>GK</a> </li>
                                     <li> <a href="pdf/P-1/secien-maths.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>SCIENCE-MATHEMATICS</a> </li>
                                      <%--<li><a href="pdf/P-1/maths-secicnce.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>MATHEMATICS-SCIENCE</a> </li>--%>
                                    
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf16" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/P-2/bengali-hindi.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>Bengali-Hindi </a> </li>
                                     <li> <a href="pdf/P-2/craft.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Craft  </a> </li>
                                     <li> <a href="pdf/P-2/englsih.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> English </a> </li>
                                     <li> <a href="pdf/P-2/gk-drawing.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Gk-Drawing </a> </li>
                                      <li> <a href="pdf/P-2/maths-secicnce.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Mathematics-Science </a> </li>
                                    
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf17" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS XI HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>dsdads </a> </li>
                                     <li> <a href="pdf/CLASS XI BENGALI  1ST UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> sadsad  </a> </li>
                                     <li> <a href="pdf/BENGALI XI  2ND UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                     <li> <a href="pdf/CLASS XI MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                    </ul>
                                </div>
                                 <div class="standard-division" id="pdf18" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS XI HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>dsdads </a> </li>
                                     <li> <a href="pdf/CLASS XI BENGALI  1ST UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> sadsad  </a> </li>
                                     <li> <a href="pdf/BENGALI XI  2ND UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                     <li> <a href="pdf/CLASS XI MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                    </ul>
                                </div>
                                
                                <div class="standard-division" id="pdf11" runat="server" visible="false">
                                     <ul>
                                      <b>HALF YEARLY SYLLABUS</b>
                                     <li> <a href="pdf/CLASS XI HINDI.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Class XI HIND  </a> </li>
                                     <li> <a href="pdf/CLASS XI BENGALI  1ST UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Class XI BENGALI 1st Unit  </a> </li>
                                     <li> <a href="pdf/BENGALI XI  2ND UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Class XI BENGALI 2st Unit </a> </li>
                                     <li> <a href="pdf/CLASS XI MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> Class XI MATHEMATICS  </a> </li>
                                    </ul>
                                </div>
                                <div class="standard-division" id="pdf21" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-12/BIOLOGY-ECONOMICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BIOLOGY-ECONOMICS</a> </li>
                                     <li> <a href="pdf/CLASS-12/BUSSINESS STUDIES-ACCOUNTANCY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>BUSSINESS STUDIES-ACCOUNTANCY</a> </li>
                                     <li> <a href="pdf/CLASS-12/ENTERPRENERSHIP-COMM ARTS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENTERPRENERSHIP-COMM ARTS</a> </li>
                                     <li> <a href="pdf/CLASS-12/ENGLISH CORE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH CORE</a> </li>
                                    </ul>
                                </div>
                                <div class="standard-division" id="pdf23" runat="server" visible="false">
                                    <ul>
                                     <li> <a href="pdf/CLASS-12/PHYSICS-CHEMISTRY.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>PHYSICS-CHEMISTRY</a> </li>
                                     <li> <a href="pdf/CLASS-12/ENGLISH CORE.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i>ENGLISH CORE</a> </li>
                                     <%--<li> <a href="pdf/CLASS-12/BENGALI XI  2ND UNIT.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>
                                     <li> <a href="pdf/CLASS-12/CLASS XI MATHEMATICS.pdf" target="_blank"><i  class="fa fa-file-pdf-o"></i> asdsad </a> </li>--%>
                                    </ul>
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Topic Details" CssClass="d-none">
                        <HeaderTemplate>
                            Topic Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <br />
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TabContainer1" ActiveTabIndex="0"
                                                Width="100%">
                                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="New">
                                                    <ContentTemplate>
                                                        <center>
                                                            <table width="50%">
                                                                <tr>
                                                                    <td align="left" >
                                                                        <div class="efficacious">
                                                                            <asp:Label ID="lblSTD" runat="server" Text="STD"></asp:Label></div>
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <div class="efficacious">
                                                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Topic"
                                                                                ControlToValidate="ddlSTD" runat="server" InitialValue="0" Display="None" ErrorMessage="Please Select Standard First"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                                                runat="server" TargetControlID="RequiredFieldValidator1" Enabled="True">
                                                                            </asp:ValidatorCalloutExtender>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trTopicDiv" runat="server" visible="False">
                                                                    <td align="left"  runat="server">
                                                                        <div class="efficacious">
                                                                            <asp:Label ID="lblDIV" runat="server" Text="DIV"></asp:Label></div>
                                                                    </td>
                                                                    <td align="left" runat="server">
                                                                        <div style="overflow: scroll; height: 100px">
                                                                            <asp:CheckBox ID="chkAll" Text="All" runat="server" CssClass="label" AutoPostBack="True"
                                                                                OnCheckedChanged="chkAll_CheckedChanged" /><asp:CheckBoxList ID="ChkDivList" runat="server"
                                                                                    AutoPostBack="True" CssClass="label" OnSelectedIndexChanged="ChkDivList_SelectedIndexChanged">
                                                                                </asp:CheckBoxList>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" >
                                                                        <div class="efficacious">
                                                                            <asp:Label ID="Label2" runat="server" Text="Subject"></asp:Label></div>
                                                                    </td>
                                                                    <td align="left">
                                                                        <div class="efficacious">
                                                                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="Subject" ValidationGroup="Topic" ControlToValidate="ddlSubject"
                                                                            runat="server" InitialValue="0" Display="None" ErrorMessage="Please Select Subject"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VSubject" runat="server"
                                                                            TargetControlID="Subject" Enabled="True">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" >
                                                                        <div class="efficacious">
                                                                            <asp:Label ID="lblTopic" runat="server" Text="Topic Name"></asp:Label></div>
                                                                    </td>
                                                                    <td align="left">
                                                                        <div class="efficacious">
                                                                            <asp:TextBox ID="txtTopicNm" CssClass="input-blue" TextMode="MultiLine" Height="68px"
                                                                                runat="server" Width="303px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                                    ValidationGroup="Topic" ControlToValidate="txtTopicNm" runat="server" Display="None"
                                                                                    ErrorMessage="Please Enter Topic Name"></asp:RequiredFieldValidator>
                                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                                    Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="left">
                                                                        &nbsp;</td>
                                                                    <td align="left">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" valign="top">
                                                                        <div class="efficacious" style="display: none">
                                                                            <asp:Button ID="btnClear" runat="server" CssClass="efficacious_send" 
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </div>
                                                                    </td>
                                                                    <td align="center">
                                                                        <div class="efficacious">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="efficacious_send" 
                                                                                OnClick="btnSubmit_Click" OnClientClick="return TopicValidation();" 
                                                                                Text="Submit" ValidationGroup="Topic" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Details">
                                                    <ContentTemplate>
                                                        <center>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="100%">
                                                                        <div id="efficacious" class="efficacious" style="width: 90%">
                                                                            <table width="90%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbl" runat="server" Text="STD" Style="position: relative; top: 5px;
                                                                                            text-align: right;"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlSTD2" runat="server" AutoPostBack="True" 
                                                                                            OnSelectedIndexChanged="ddlSTD2_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label3" runat="server" Text="DIV" Visible="False" Style="position: relative; top: 5px;
                                                                                            text-align: right; left: 0px;"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlDIV2" runat="server" AutoPostBack="True"  Visible="False" OnSelectedIndexChanged="ddlDIV2_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label4" runat="server" Style="position: relative; top: 5px; text-align: right;"
                                                                                            Text="Subject"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlSub1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSub1_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="grvTopic" runat="server" AllowPaging="True" AllowSorting="True"
                                                                            AutoGenerateColumns="False" CssClass="table  tabular-table " DataKeyNames="intTopic_id"
                                                                            EmptyDataText="Record not Found." OnRowDeleting="grvTopic_RowDeleting" Width="100%"
                                                                            OnRowEditing="grvTopic_RowEditing" OnPageIndexChanging="grvTopic_PageIndexChanging">
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("intTopic_id") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                               
                                                                               
                                                                                <asp:BoundField ReadOnly="True" DataField="vchStandard_name" HeaderText="STD" />
                                                                                <asp:BoundField ReadOnly="True" DataField="vchDivisionName" HeaderText="DIV" 
                                                                                    Visible="False" />
                                                                                <asp:BoundField ReadOnly="True" DataField="vchSubjectName" HeaderText="Subject" />
                                                                                <asp:BoundField ReadOnly="True" DataField="vchTopicName" HeaderText="Topic" />
                                                                                 <asp:TemplateField HeaderText="Edit">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                            ImageUrl="~/images/edit.png" OnClientClick="CreateTextBox();" /></ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                 <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgBtn" runat="server" CausesValidation="false" CommandName="Delete"
                                                                                            ImageUrl="~/images/delete.png" OnClientClick="return ConfirmDelete();" /></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <PagerStyle CssClass="pgr" />
                                                                            <RowStyle HorizontalAlign="Left" />
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
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="Syllabus" runat="server" HeaderText="Syllabus Details"  style="display:none;">
                        <ContentTemplate>
                            <br />
                            <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TabContainer2" ActiveTabIndex="0"
                                Width="100%">
                                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="New">
                                    <ContentTemplate>
                                        <div class="efficacious">
                                            <center>
                                                <table width="50%">
                                                    <tr>
                                                        <td width="50%">
                                                            <asp:Label ID="lblTopicName0" runat="server" Text="STD"></asp:Label>
                                                        </td>
                                                        <td width="50%">
                                                            <asp:DropDownList ID="ddlSTD3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD3_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSTD3"
                                                                Display="None" ErrorMessage="Please Select Standard First" InitialValue="0" ValidationGroup="Syll"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <%--<tr id="trDiv" runat="server" visible="False">
                                                        <td width="50%" runat="server">
                                                            <asp:Label ID="lblTopicName1" runat="server" Text="DIV"></asp:Label>
                                                        </td>
                                                        <td width="50%" runat="server">
                                                            <asp:DropDownList ID="ddlDIV3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDIV3_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td width="50%">
                                                            <asp:Label ID="lblTopicName2" runat="server" Text="Subject"></asp:Label>
                                                        </td>
                                                        <td width="50%">
                                                            <asp:DropDownList ID="ddlSub2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSub2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td width="50%">
                                                            <asp:Label ID="lblTopicName" runat="server" Text="Topic Name"></asp:Label>
                                                        </td>
                                                        <td width="50%">
                                                            <asp:DropDownList ID="ddlTopic" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTopic"
                                                                Display="None" ErrorMessage="Please Select Topic Name" InitialValue="0" ValidationGroup="Syll"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>--%>
                                                   <%-- <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="Label8" runat="server" Text="Syllabus"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSyllabus" runat="server" CssClass="input-blue"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                        <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="Label9" runat="server" Text="Syllabus" Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                      <%--  <td valign="top">
                                                            &nbsp;
                                                            <asp:Label ID="lblTopic1" runat="server" Text="Exam"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                            <asp:CheckBoxList ID="chkExamList" runat="server">
                                                            </asp:CheckBoxList>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <%--<tr id="dynTr" runat="server" visible="false">
                                                        <td valign="top">
                                                            <asp:Label ID="Label1" runat="server" Text="Syllabus"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <div id="TextBoxContainer" style="width: 92%; position: relative; left: -9px">
                                                                <table width="100%">
                                                                </table>
                                                            </div>
                                                            <input id="btnAdd" type="button" class="efficacious_send_Plus" style="width: 18%"
                                                                value="+" onclick="AddTextBox()" />
                                                            <br />
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="center">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnPost" />
                                                            </Triggers>
                                                            </asp:UpdatePanel>
                                                            <asp:Button ID="btnPost" runat="server" CssClass="efficacious_send" OnClick="Post"
                                                                Text="Submit" ValidationGroup="Syll" Width="50%" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TbDetail" HeaderText="Details" runat="server">
                                    <ContentTemplate>
                                        <center>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <div id="efficacious" class="efficacious" style="width: 100%">
                                                            <table width="90%">
                                                                <tr>
                                                                
                                                                    <td>
                                                                        <asp:Label ID="Label5" runat="server" Style="position: relative; top: -5px; text-align: right; left: 0px;"
                                                                            Text="STD"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSTD4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD4_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label6" runat="server" Style="position: relative; top: -5px; text-align: right;"
                                                                            Text="DIV" Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDIV4" runat="server" AutoPostBack="True" 
                                                                            Visible="False" OnSelectedIndexChanged="ddlDIV4_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label7" runat="server" Style="position: relative; top: -5px; text-align: right;"
                                                                            Text="Subject"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSub4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSub4_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grvSyllabus" runat="server" AllowPaging="True" AllowSorting="True"
                                                            DataKeyNames="intTopic_id" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                            EmptyDataText="Record not Found." Width="100%" PageSize="12" OnRowDeleting="grvSyllabus_RowDeleting"
                                                            OnPageIndexChanging="grvSyllabus_PageIndexChanging">
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblId" Text='<%# Eval("intTopic_id") %>' runat="server"></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                               
                                                                <asp:BoundField ReadOnly="True" HeaderText="STD" DataField="STD" />
                                                                <asp:BoundField ReadOnly="True" HeaderText="DIV" DataField="DIV" 
                                                                    Visible="False" />
                                                                <asp:BoundField ReadOnly="True" HeaderText="Subject" DataField="Subject" />
                                                                <asp:BoundField ReadOnly="True" HeaderText="Topic" DataField="vchTopicName" />
                                                                <asp:TemplateField HeaderText="Sub Topic">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkTopic" Text='<%# Eval("Tot") %>' runat="server" OnClick="lnkTopic_Click"></asp:LinkButton></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgBtn" runat="server" CommandName="Delete" ImageUrl="~/images/delete.png"
                                                                            CausesValidation="false" OnClientClick="confirm('Do you really want to delete selected record?')" /></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <RowStyle HorizontalAlign="Left"></RowStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                        <asp:Panel ID="pnlStudLateAtt" Width="50%" runat="server">
                                            <center>
                                                <table width="100%" style="background-color: White">
                                                    <tr>
                                                        <td align="center" style="background-color: WindowText">
                                                            <asp:Label ID="lblTopicNm" runat="server" Font-Bold="True" ForeColor="White" Font-Names="Times New Roman"
                                                                Font-Size="Small"></asp:Label>
                                                        </td>
                                                        <td align="right" style="background-color: WindowText">
                                                            <asp:Image ID="ImgBtn" runat="server" ImageUrl="~/images/cross.png" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:GridView ID="grvStudLate" CssClass="mGrid" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="intSyllabus_id" Width="90%" AllowPaging="True" BorderStyle="Dotted"
                                                                PageSize="5" OnRowDeleting="grvStudLate_RowDeleting" OnRowEditing="grvStudLate_RowEditing"
                                                                OnPageIndexChanging="grvStudLate_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Syllabus_id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSyllabus_Is" Text='<%# Eval("intSyllabus_id") %>' runat="server"></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   
                                                                   
                                                                    <asp:BoundField ReadOnly="True" HeaderText="Sr No" DataField="No">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ReadOnly="True" DataField="Syllabus" HeaderText="Syllabus">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>

                                                                     <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" CommandName="Edit" CausesValidation="false" runat="server"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>

                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" CommandName="Delete" OnClientClick="return confirm('Do You Really Want To Delete Selected Record?')"
                                                                                CausesValidation="false" runat="server" ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <div class="efficacious">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="60%" align="right" valign="middle">
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td>
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td align="center" valign="middle">
                                                                            &#160;&#160;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" valign="middle" width="60%">
                                                                            <asp:TextBox ID="txtAddSyllabus" runat="server" Width="300px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td align="center" valign="top">
                                                                            <asp:Button ID="btnAddS" runat="server" CssClass="efficacious_send" OnClick="btnAddS_Click"
                                                                                OnClientClick="return SyllabusValidation();" Text="Add" Width="60px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </asp:Panel>
                                        <asp:Button ID="btnPop" runat="server" Style="display: none" /><asp:ModalPopupExtender
                                            ID="ModalStudLateAtt" runat="server" TargetControlID="btnPop" BackgroundCssClass="modalBackground"
                                            PopupControlID="pnlStudLateAtt" OkControlID="ImgBtn" Enabled="True" DynamicServicePath="">
                                        </asp:ModalPopupExtender>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                           
                    
                            </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
</asp:Content>

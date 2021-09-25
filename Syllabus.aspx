<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Syllabus.aspx.cs" Inherits="Syllabus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<asp:scriptmanager runat="server"></asp:scriptmanager>
<head id="Head1" runat="server">
    <title></title>
    <link href="css/style12.css" rel="stylesheet" type="text/css" />
</head>
    <style type="text/css">
        .style1
        {
            width: 60%;
            margin: 0 auto;
        }
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
            width: 100%;
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
    </script>
    <script type="text/javascript">
        function GetDynamicTextBox(value) {
            alert(value);
            return '<tr><td><input name = "DynamicTextBox" type="text" style="margin-left:10px" class="input-blue" value = "' + value + '" /></td><td><asp:FileUpload ID="FileUpload1" Style="font-size: 11px;" runat="server" /></td>' +
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
<body>
    <form id="form1" runat="server">
    <div>
    <center>
           <%-- <asp:GridView ID="grdDet" runat="server" CssClass="table  tabular-table " EmptyDataText="No Details Available" Width="50%">
            </asp:GridView>--%>
            <tr>
                                            <td>
                                                <div id="CollapsDiv" runat="server" style="overflow: hidden;">
                                                </div>
                                            </td>
                                        </tr>
        </center>
    </div>
    </form>
</body>
</html>

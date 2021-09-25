<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTracking.aspx.cs" Inherits="frmTracking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Live Tracking</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"> </script>

    <script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script src="ASPSnippets_Pager.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    
    <style type="text/css">
        @charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset@charset"utf-8";/* CSS Document */
        *
        {
            margin: 0;
            padding: 0;
        }
       
        .mGrid
        {
            width: 100%;
            background-color: #fff;
            border: solid 1px #525252;
            border-collapse: collapse;
            font: 11px Verdana, Helvetica, sans-serif;
        }
        .mGrid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            color: #717171;
            text-align: center;
        }
        .mGrid th
        {
            padding: 4px 2px;
            color: #fff;
            background: #817f7f url(images/grd_head.png) repeat-x top;
            border-left: solid 1px #525252;
            font-size: 0.9em;
            font: 12px verdana;
        }
        .mGrid .alt
        {
            background: #FAFAFA;
        }
        .mGrid .pgr
        {
            background: #424242;
        }
        .mGrid .pgr table
        {
            margin: 5px 0;
        }
        .mGrid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGrid .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGrid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
        tr, td{ padding-left:5px;}
    </style>

    <script type="text/javascript">
        var url;
        var arrlength;
        var latlng;
        var map, dataLayer, infobox;
        var polylineMask = null;
        var MM = Microsoft.Maps;
        var startpin;
        var currentpin;
        var polyline;
        //using jquery..
        function getRequest() {
            url = "LiveTracking_Data.ashx";
            //alert(url)
            $.post(url, function(data) {

                if (data != null & data != '') {
                    //start 
                    var latlngsplit = new Array();
                    var latlngsplit1 = new Array();

                    latlngsplit = data.split('#&');
                    //alert('3 ' + latlngsplit[0]);
                    arrlength = latlngsplit.length - 1;
                    //alert('4 ' + arrlength);
                    var latlng = new Array();
                    var ll;
                    var startlatlon = latlngsplit[0].split(",");
                    var startlat, startlon, startlocation, endlocation;
                    startlat = startlatlon[0];
                    startlon = startlatlon[1];
                    startlocation = startlatlon[2];
                    var endlat, endlong;
                    var marker1;
                    var marker;
                    //loop 1
                    for (var p = 0; p < latlngsplit.length; p++) {
                        if (latlngsplit[p] != null) {
                            latlngtemp = latlngsplit[p].split(",");
                            ll = new Microsoft.Maps.Location(latlngtemp[0], latlngtemp[1]); ;
                            endlocation = latlngtemp[2];
                            latlng.push(ll);
                        } //end if
                    } // end for
                    //alert('new ' + latlng);
                    var demo = new Array();
                    var count = latlngsplit.length - 2;
                    //alert(count);
                    demo = latlngsplit[count].split(",");
                    endlat = demo[0]
                    endlong = demo[1];
                    //alert(endlat);
                    //alert(endlong);

                    //alert('before poly');
                    map.setView({ center: new Microsoft.Maps.Location(endlat, endlong), zoom: 15 });
                    var polylineStrokeColor = new Microsoft.Maps.Color(200, 0, 0, 200);
                    polyline = null;
                    polyline = new Microsoft.Maps.Polyline(latlng, { strokeColor: polylineStrokeColor, strokeThickness: 4 });
                    map.entities.push(polyline);
                    // pushpinOptions = { icon: 'images/busIcon.png' };
                    startpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(startlat, startlon));
                    startpin.Title = "Start Location";
                    startpin.Description = startlocation;
                    // Microsoft.Maps.Events.addHandler(startpin, 'mouseover', displayInfobox);
                    dataLayer.push(startpin);
                    //dataLayer.remove(startpin);

                    // dataLayer.remove(currentpin);
                    //                    currentpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(endlat, endlong));
                    //                    currentpin.Title = "Current Location";
                    //                    currentpin.Description = endlocation;
                    //                    Microsoft.Maps.Events.addHandler(currentpin, 'mouseover', displayInfobox);
                    //                    dataLayer.push(currentpin);
                    // map.removeOverlay(marker);
                    //end
                }
                else {
                    alert('No data available for selected date')
                    window.close();
                }

                $(document).ready(function() {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "frmTracking.aspx/BindDatatable",
                        data: "{}",
                        dataType: "json",
                        success: function(data) {
                        for (var i = 0; i < data.d.length; i++) {

                            document.getElementById('<%=lblDate.ClientID %>').innerHTML = data.d[i].dtdatetime;
                            document.getElementById('<%=lblTime.ClientID %>').innerHTML = data.d[i].dttime;
                            if (data.d[i].location != '')
                            {
                                document.getElementById('<%=lblLocation.ClientID %>').innerHTML = data.d[i].location;
                            }
                            
                            document.getElementById('<%=lblLatitude.ClientID %>').innerHTML = data.d[i].latitude;
                            document.getElementById('<%=lblLongitude.ClientID %>').innerHTML = data.d[i].longitude;
                            document.getElementById('<%=lblSpeed.ClientID %>').innerHTML = data.d[i].speed;
                                
                            }
                        },
                        error: function(result) {
                            alert("Error");
                        }
                    });
                });

                var busarrlength;
                var buslatlngsplit = new Array();
                var buslatlngsplit1 = new Array();

                var stop_data = document.getElementById("<%= hdnStops.ClientID%>").value;

                if (stop_data != null && stop_data != '') {
                    buslatlngsplit = stop_data.split('#&');
                    //arrlength = buslatlngsplit.length - 1;
                    var buslatlng = new Array();
                    var busll;
                    var pushpinOptions1 = { icon: 'images/Bus_Stop_sign.png' };

                    for (var p = 0; p < buslatlngsplit.length - 1; p++) {
                        if (buslatlngsplit[p] != null) {
                            var latlngtemp = buslatlngsplit[p].split("#");

                            //busll = new VELatLong(latlngtemp[0], latlngtemp[1]);

                            busll = new Microsoft.Maps.Location(latlngtemp[0], latlngtemp[1]);
                            var busstopaddress = latlngtemp[2];
                            /////


                            var busstoppin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(latlngtemp[0], latlngtemp[1]), pushpinOptions1);
                            busstoppin.Title = "Bus Stop";
                            busstoppin.Description = busstopaddress;
                            Microsoft.Maps.Events.addHandler(busstoppin, 'mouseover', displayInfobox);
                            dataLayer.push(busstoppin);
                        } //end if
                    } // end for

                }
            });
        }
        window.onload = function CallFunction() {
            map = new Microsoft.Maps.Map(document.getElementById("mapDiv"),
                {
                    credentials: 'AkJzJ92quLAPmLYVjUuZfFkOmynnTM60QaMyVNcUuHRu3cI74u2Q7NOuEKI5viNB',
                    center: new Microsoft.Maps.Location(19.0668, 73.00775),
                    mapTypeId: Microsoft.Maps.MapTypeId.road,
                    zoom: 12
                });
            dataLayer = new Microsoft.Maps.EntityCollection();
            map.entities.push(dataLayer);
            getRequest();
            setInterval("getRequest()", 10000);
        }

        function displayInfobox(e) {
            if (e.targetType == 'pushpin') {
                infobox.setLocation(e.target.getLocation());
                infobox.setOptions({ visible: true, title: e.target.Title, description: e.target.Description });
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        
            <table width="922" >
                <tr>
                    <td align="center">
                        <div id='mapDiv' style="position: relative; width: 920px; margin: 0 auto; height: 550px;">
                        </div>
                        
                        <table border="0" cellpadding="0" cellspacing="1" width="100%" style=" border:1px solid #f5f5f5; padding-top:20px; font-family:Verdana; font-size:13px; color:#242424;">
                       
                            <tr style="padding: 4px 2px;
color: #fff;
background: rgb(3, 116, 3);
border-left: solid 1px #525252;
font-size: 0.9em;
font: 12px verdana;
height: 29px; padding-left:5px; text-align:left;
">
<td rowspan="2" style="background:#fff; border:1px solid #242424; width:135px;">
                                <img src="img/logo.png" />  
                                </td>
                                <td>
                                   <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="Label1" runat="server" Text="Time"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="Label3" runat="server" Text="Location"></asp:Label> 
                                </td>
                                
                                <td>
                                   <asp:Label ID="Label4" runat="server" Text="Latitude"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="Label5" runat="server" Text="Longitude"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="Label6" runat="server" Text="Speed"></asp:Label> 
                                </td>
                                
                            </tr>
                            <tr>
                                
                                <td>
                                   <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label> 
                                </td>
                                
                                <td>
                                   <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="lblLocation" runat="server" Text="N/A"></asp:Label> 
                                </td>
                                
                                <td>
                                   <asp:Label ID="lblLatitude" runat="server" Text="Latitude"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="lblLongitude" runat="server" Text="Longitude"></asp:Label> 
                                </td>
                                <td>
                                   <asp:Label ID="lblSpeed" runat="server" Text="Speed"></asp:Label> 
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hdnStops" runat="server" />
                        
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>

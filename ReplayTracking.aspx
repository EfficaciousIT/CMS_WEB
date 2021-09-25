<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplayTracking.aspx.cs" Inherits="ReplayTracking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Replay Tracking</title>

    <script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.3"></script>

    <script type="text/javascript">
        var map;
        function LoadMap() {
            alert('asdasdasd');
            map = new VEMap('BingMap');
            var latlong = new VELatLong(28.63576, 77.22445);
            map.SetDashboardSize(VEDashboardSize.Large);
            map.LoadMap(latlong, 9, VEMapStyle.Road);
            //Add pushpin 
            var pin = new VEShape(VEShapeType.Pushpin, latlong);
            pin.SetCustomIcon(null);
            pin.SetTitle("New Delhi");
            pin.SetDescription("Capital City Of India");
            map.AddShape(pin);
            map.ShowDashboard();
        }

        function WayPoints() {
            //     alert('inside waypoint');
            map = new VEMap('BingMap');
            map.LoadMap();
            map.SetMapMode(VEMapMode.Mode2D);
            map.SetMapStyle(VEMapStyle.Road);
            var latlngsplit = new Array();
            var latlngsplit1 = new Array();
            var url_data = document.getElementById("<%= HiddenField1.ClientID%>").value;
            url_data = "18.180103,-66.74947#&18.363285,-67.18024#&18.448619,-67.13422#&18.498987,-67.13699#&18.465162,-67.141486#&18.182151,-66.9588#&18.256995,-66.104657#&18.142002,-66.273278#&18.288319,-67.13604#&18.279531,-66.80217#&18.449732,-66.69879#&18.458093,-66.732732#&18.429675,-66.674506#&17.96977,-66.061459#&18.426748,-66.67669#&18.455499,-66.55575#&18.185463,-66.305827#&18.003125,-67.16745#&18.08643,-67.15222#&18.055399,-66.72602#&18.232109,-66.039087#&18.235003,-66.037318#&18.435246,-66.85644#&18.186739,-66.85174#&18.194527,-66.183467#&18.111528,-66.177083#&18.262902,-65.646529#&18.113284,-67.039706#&18.073078,-66.94864#&18.308139,-66.49835#&18.176094,-66.158728#&18.077197,-66.359104#&18.268896,-66.70519#&18.341254,-66.315194#&18.049577,-66.55218#&18.308508,-65.304732#&18.442798,-66.27689#&17.964529,-66.93993#&18.333038,-65.656182#&18.363331,-66.56773#&18.457453,-66.61217#&17.992112,-66.90097#&17.979518,-66.117219#&17.976371,-66.116795#&18.038866,-66.79168#&18.254137,-65.973605#&18.432956,-66.80039";
            if (url_data != null && url_data != '') {
                latlngsplit = url_data.split('#&');
                arrlength = latlngsplit.length - 1;
                var latlng = new Array();
                var ll;
                var delimeter = ",";
                var startlatlon = latlngsplit[0].split(delimeter);
                var startlat, startlon, startlocation;
                var endlocation;
                startlat = startlatlon[0];
                startlon = startlatlon[1];
                startlocation = startlatlon[2];
                //loop 1
                for (var p = 0; p < latlngsplit.length; p++) {
                    if (latlngsplit[p] != null) {
                        var latlngtemp = latlngsplit[p].split(",");

                        //ll = new GLatLng('28.63576','77.22445');
                        ll = new VELatLong(latlngtemp[0], latlngtemp[1]);
                        endlocation = latlngtemp[2];
                        latlng.push(ll);
                    } //end if
                } // end for

                var demo = new Array();
                var count = latlngsplit.length - 2;
                //alert(count);
                demo = latlngsplit[count].split(",");
                endlat = demo[0]
                endlong = demo[1];

                //set center
                var currentloc = new VELatLong(endlat, endlong);
                var initView = new VEMapViewSpecification(currentloc, 14, 1000, -90, 0)
                map.SetMapView(initView);
                //adding line 
                var myShapeLayer = new VEShapeLayer();
                map.AddShapeLayer(myShapeLayer);
                var myShape = new VEShape(VEShapeType.Polyline, latlng);
                //Set the line color
                var lineColor = new VEColor(254, 0, 0, .5);
                myShape.SetLineColor(lineColor);

                //Set the line width
                var lineWidth = Math.round(3);
                myShape.SetLineWidth(lineWidth);
                myShape.HideIcon();
                myShapeLayer.AddShape(myShape);
                //adding marker(pushpin)

                //for start point
                var startaddress = startlocation;
                var first = 'Start';
                var startpin = new VEShape(VEShapeType.Pushpin, latlng[0]);
                startpin.SetTitle(first);
                //startpin.SetDescription(startaddress);
                map.AddShape(startpin);
                var currentMarkerID = "images/busIcon.png";
                startpin.SetCustomIcon(currentMarkerID);
                //for endpoint
                var endaddress = endlocation;
                var last = 'Current Location';
                var endpin = new VEShape(VEShapeType.Pushpin, currentloc);
                endpin.SetTitle(last);
                endpin.SetDescription(endaddress);
                map.AddShape(endpin);
                endpin.SetCustomIcon(currentMarkerID);


                var busarrlength;
                var buslatlngsplit = new Array();
                var buslatlngsplit1 = new Array();

                var stop_data = document.getElementById("<%= hdnStops.ClientID%>").value;


                if (stop_data != null && stop_data != '') {
                    buslatlngsplit = stop_data.split('#&');
                    //arrlength = buslatlngsplit.length - 1;
                    var buslatlng = new Array();
                    var busll;

                    for (var p = 0; p < buslatlngsplit.length - 1; p++) {
                        if (buslatlngsplit[p] != null) {
                            var latlngtemp = buslatlngsplit[p].split("#");
                            busll = new VELatLong(latlngtemp[0], latlngtemp[1]);
                            //for busstop
                            var busStopMarkerID = "images/Bus_Stop_ Sign.png";
                            var busstopaddress = latlngtemp[2];
                            var currentbustop = 'Bus Stop';
                            var busstoppin = new VEShape(VEShapeType.Pushpin, busll);
                            busstoppin.SetTitle(currentbustop);
                            busstoppin.SetDescription(busstopaddress);
                            map.AddShape(busstoppin);
                            busstoppin.SetCustomIcon(busStopMarkerID);
                        } //end if
                    } // end for
                }



            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="922" style="margin-top: -10px;">
            <tr height="25">
                <td align="left" width="100" style="padding-left: 20px;">
                    <b>Auto Refresh:</b>
                </td>
                <td align="left" width="822">
                    <asp:CheckBox ID="chkrefresh" AutoPostBack="true" runat="server" Checked="True" />
                </td>
            </tr>
        </table>
        <div id='BingMap' style="position: relative; width: 863px; margin: 0 auto; height: 493px;
            top: 0px; left: 0px;">
        </div>
        <center>
            <table width="922">
                <tr>
                    <td align="center">
                        <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                        <%--  <asp:Timer ID="timer1" Enabled="true" runat="server" Interval="9000">
                        </asp:Timer>--%>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStops" runat="server" />
                    </td>
                </tr>                
            </table>
        </center>
        <%--<asp:Panel ID="Panel1" runat="server" CssClass="outerPanel" Style="z-index: 10000;">
            <table align="left">
                <tr>
                    <td style="cursor: move; background-color: #fff; padding: 0 10px; border: 1px solid #ccc;">
                        <div id="Panel2" runat="server">
                        </div>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>--%>
    </div>
    </form>
</body>
</html>

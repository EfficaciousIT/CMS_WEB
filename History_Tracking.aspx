<%@ Page Language="C#" AutoEventWireup="true" CodeFile="History_Tracking.aspx.cs"
    Inherits="History_Tracking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>History Tracking</title>
</head>
<body onload="showMap()" onunload="GUnload()">
    <form id="form1" runat="server">

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=ABQIAAAAJ6UBXQPt7f7lc5O8y10v_hQ021nKtEf5RcJWBNKeu753x-WDlhT7WbIr6h29tfvn41nzJX-LZ67OyQ"
        type="text/javascript">
    </script>

    <script type="text/javascript" language="javascript">
        var count = 0;
        var longitude1;
        var latitude1;
        var rt_pt_list1 = new Array();
        var ll12 = new Array();
        var map2;
        var trace_speed = 10;
        var Zoomlev = 15;
        var mmg;
        var icon;
        var vehmarker;
        var tid;
        var mm;
        var catMarkers = new Array();
        var catPoints = new Array();

        function incre() {
            //alert("inside incre");
        }

        incre.prototype.run = function() {
            //alert('inside incre run...');
            var self = this;
            self.animate();
        }

        incre.prototype.animate = function() {
            //alert('inside animate..');
            var inc = function() {
                var bounds = map2.getBounds();
                var southWest = bounds.getSouthWest();
                var northEast = bounds.getNorthEast();
                var lngDelta = (northEast.lng() - southWest.lng()) / 100;
                var latDelta = (northEast.lat() - southWest.lat()) / 100;
                var x1 = southWest.lng() + lngDelta;
                var x2 = northEast.lng() - lngDelta;
                var y1 = southWest.lat() + latDelta;
                var y2 = northEast.lat() - latDelta;
                //if (count == 0) {
                //    map2.setCenter(rt_pt_list1[count], Zoomlev);
                //                }
                //alert(count);
                if (count == 0) {
                    //alert('trip started...');
                    var marker = createMarker(rt_pt_list1[count], 'Trip Started', 'Trip Started....');
                    //alert(mmg);
                    //mmg.addMarker(marker, 0, 17);
                    //alert(marker);
                    map2.addOverlay(marker);
                }
                else if (count == rt_pt_list1.length - 2) {
                    //alert('trip ended...');
                    var marker = createMarker(rt_pt_list1[count], 'Trip Ended', 'Trip Ended....');
                    //mmg.addMarker(marker, 0, 17);
                    map2.addOverlay(marker);
                    map2.removeOverlay(vehmarker);
                    return;
                }
                count = count + 1;
                if (count < rt_pt_list1.length - 1) {
                    ll12.push(rt_pt_list1[count - 1]);
                    var Polyline = new GPolyline(ll12, '#f33f00', 3, 0.8, 0.2);
                    //map2.clearOverlays();
                    map2.removeOverlay(Polyline);
                    //                    if (count > 0) {
                    //                        //alert([ll12[count - 1], ll12[count]]);
                    //                        var Polyline = new GPolyline([rt_pt_list1[count - 1], rt_pt_list1[count]], '#f33f00', 3, 0.8, 0.2);
                    //                    }
                    map2.addOverlay(Polyline);
                    if (vehmarker) {
                        map2.removeOverlay(vehmarker);
                    }
                    vehmarker = new GMarker(rt_pt_list1[count - 1], icon);
                    map2.addOverlay(vehmarker);
                    if (rt_pt_list1[count].x < x2 && rt_pt_list1[count].x > x1 && rt_pt_list1[count].y < y2 && rt_pt_list1[count].y > y1) {
                    }
                    else {
                        map2.panTo(rt_pt_list1[count]);
                    }
                    //map2.setCenter(rt_pt_list1[count], Zoomlev);
                }
                else {
                    return;
                }
                //window.setTimeout(inc, 10);
                tid = window.setTimeout(inc, 0);
            }
            inc();
        }

        function createMarker(point, name, html) {
            var marker;
            if (name == 'Trip Started') {
                marker = new GMarker(point, G_START_ICON);

            }
            else {
                marker = new GMarker(point, G_END_ICON);
            }
            //alert(name);
            marker.title = name + "";
            GEvent.addListener(marker, "click", function() {
                this.openInfoWindowHtml(html);
            });
            GEvent.addListener(marker, "mouseover", function() {
                this.openInfoWindowHtml(html);
            });
            return marker;
        }

        function showMap() {
            //function showMap(veh, date) {
            //var a = $find('MPE2');
            //a.show();
            //var veh = querySt('veh');
            //var date = querySt('date');
            //alert(veh, date);
            //PageMethods.replay_data(veh, date, onSuccess0, onError0);
            PageMethods.replay_data(onSuccess0, onError0);
        }

        function querySt(ji) {
            hu = window.location.search.substring(1);
            gy = hu.split("&");
            for (i = 0; i < gy.length; i++) {
                ft = gy[i].split("=");
                if (ft[0] == ji) {
                    return ft[1];
                }
            }
        }
        function closeMap() {
            //var a = $find('MPE2');
            //a.hide();
        }
        function clearfields() {
            count = 0;
            rt_pt_list1 = new Array();
            ll12 = new Array();
            map2 = null;
            trace_speed = 100;
            Zoomlev = 20;           
        }
        function setit() {
            clearTimeout(tid);
        }
        function onError0(exception, userContext, methodName) {
            alert(exception.get_message());
        }
        function onSuccess0(result, userContext, methodName) {
            var res = result;
            if (res == "" || res == null) {
            }
            else {
                for (var z = 0; z < res.length; z++) {
                    var ll11 = res[z].split(",");
                    longitude1 = ll11[1];
                    latitude1 = ll11[0];
                    var point5 = new GLatLng(latitude1, longitude1);
                    if (z == 0) {
                        rt_pt_list1.push(point5);
                    }
                    else {
                        if (rt_pt_list1[rt_pt_list1.length - 1].lat() == point5.lat() && rt_pt_list1[rt_pt_list1.length - 1].lng() == point5.lng()) {
                        }
                        else {
                            rt_pt_list1.push(point5);
                        }
                    }
                }
                //alert('original records : ' + res.length + ' & distinct records : ' + rt_pt_list1.length);
                if (GBrowserIsCompatible()) {
                    
                    map2 = new GMap2(document.getElementById('map1'));
                    map2.addControl(new GLargeMapControl());
                    map2.addControl(new GMapTypeControl());
                    //map2.speed(10);
                    ovcontrol = new GOverviewMapControl(new GSize(120, 120));
                    map2.addControl(ovcontrol);
                    //mmg = new GMarkerManager(map2);
                    map2.setCenter(rt_pt_list1[count], Zoomlev);

                    map2.setCenter(rt_pt_list1[count], 16);
                                    
                    GEvent.addListener(map2, 'zoomend', function() {
                        Zoomlev = map2.getZoom();
                    });
                }
                //alert(count);
                //var marker = createMarker(rt_pt_list1[count], 'Trip Started', 'Trip Started....');
                //    mmg.addMarker(marker, 0, 17);


                var anim = new incre();
                icon = new GIcon();
                icon.image = 'images/vehicle.gif';                
                icon.iconSize = new GSize(19, 25);
                icon.iconAnchor = new GPoint(6, 24);
                anim.icon = icon;
                anim.run();
            }
        }

        //function loadbyCategories() {
        function loadbyCategories(catname) {
            //            var myindex = dropdown.selectedIndex;
            //            var SelValue = dropdown.options[myindex].value;
            //            var catname = SelValue;
            alert('inside loadbyCategories ...' + catname);
            PageMethods.getCategoryData(catname, onSuccessCat, onError0);
            return false;
        }

        function onSuccessCat(result, userContext, methodName) {
            var res = result;
            if (res == "" || res == null) {
                //alert('No Data ...');
            }
            else {
                //alert('Data ....' + res);
                //var catMarkers = new Array();
                //var catPoints = new Array();
                //map2.removeOverlay(catMarkers);
                //mm = null;
                //mm.refresh();
                for (var z = 0; z < catMarkers.length; z++) {
                    map2.removeOverlay(catMarkers[z]);
                }
                catPoints = [];
                catMarkers = [];
                for (var z = 0; z < res.length; z++) {
                    var ll11 = res[z].split("#");
                    longitude1 = ll11[2];
                    latitude1 = ll11[1];
                    var location = ll11[0];
                    var point5 = new GLatLng(latitude1, longitude1);
                    var catmarker = createPosMarker(point5, location, '<b>Location Name : </b>' + location)
                    catPoints.push(point5);
                    catMarkers.push(catmarker);
                }
                if (GBrowserIsCompatible()) {
                    mm = new GMarkerManager(map2);
                    //$(mm).clearMarkers();
                    //mm.clearMarkers();

                    //alert('here...');
                    mm.addMarkers(catMarkers, 0, 17);
                    mm.refresh();
                }
            }
        }

        function showPOIs() {
            mm = new GMarkerManager(map2);
            mm.addMarkers(catMarkers, 0, 17);
            mm.refresh();
        }

        function createPosMarker(point, name, html) {
            var marker;
            //marker = new GMarker(point, G_START_ICON);
            var loc_icon = new GIcon();
            loc_icon.iconSize = new GSize(13, 15);
            loc_icon.iconAnchor = new GPoint(6, 20);
            loc_icon.infoWindowAnchor = new GPoint(5, 5);
            loc_icon.image = "images/car.png";
            //loc_icon.image = "images/pinezka.jpg";
            marker = new GMarker(point, { icon: loc_icon });
            marker.title = name + "";
            GEvent.addListener(marker, "click", function() {
                this.openInfoWindowHtml(html);
            });
            GEvent.addListener(marker, "mouseover", function() {
                this.openInfoWindowHtml(html);
            });
            return marker;
        }

        //        function bindgrid(suppliers) {
        //            grid.set_dataSource(suppliers);
        //            grid.dataBind();
        //        }
    </script>

    <asp:ScriptManager ID="sp1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <%--<asp:DropDownList runat="server" ID="ddlcategory" Width="230px" AutoPostBack="true"
    OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
    </asp:DropDownList><br/>--%>
    <center>
        <div id="map1" style="width: 850px; height: 600px; padding-left: 400px">
        </div>
        <br />
        <div style="width: 850px; text-align: right;">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon_excel.gif"
                OnClick="ImageButton1_Click" /></div>
    </center>
    <br />
    <asp:GridView ID="grdInfo" runat="server" AutoGenerateColumns="False" Width="850px">
        <Columns>
            <asp:BoundField DataField="dtdatetime" HeaderText="DateTime" />
            <asp:BoundField DataField="fltlatitude" HeaderText="Latitude" />
            <asp:BoundField DataField="fltlongitude" HeaderText="Logitude" />
            <asp:BoundField DataField="vchDescription" HeaderText="Location" />
            <%--<asp:BoundField DataField="vchDescription" HeaderText="Location" />--%>
        </Columns>
        <RowStyle BackColor="#ffffff" ForeColor="#333333" BorderColor="#465066" Font-Names="Verdana"
            Font-Size="10px" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#2E3442" ForeColor="White" BorderColor="#465066" Wrap="False"
            Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Center" />
    </asp:GridView>
    </form>
</body>
</html>

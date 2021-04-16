<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Medios de comunicacion.</h3>
    <div class="row">
    <address class="col-md-5">
       Calle Yosemite #35 col. Nápoles<br />
       CDMX, México<br />
       
    </address>
        </div>
        <div class="row">
    <address  class="col-md-5">
        <strong>Información y ventas:</strong>   <a href="mailto:mmtzros@risc.com.mx">mmtzros@risc.com.mx</a><br />
    </address>
            </div>
     <div id="map-container" class="col-md-5">
     </div>
        
     <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAvsBTylEDBRbxnW7W8_OhV0TNPBjm4TGs&callback=initMap"></script>
    <script>
        function init_map() {
            var var_location = new google.maps.LatLng(19.396465, -99.172929);

            var var_mapoptions = {
                center: var_location,
                zoom: 16
            };

            var var_marker = new google.maps.Marker({
                position: var_location,
                map: var_map,
                title: "RISC"
            });

            var var_map = new google.maps.Map(document.getElementById("map-container"),
                var_mapoptions);

            var_marker.setMap(var_map);

        }
        google.maps.event.addDomListener(window, 'load', init_map);
        $("#map-container").css({ height: '230px' });
    </script>
</asp:Content>

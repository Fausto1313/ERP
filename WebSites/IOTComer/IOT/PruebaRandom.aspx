<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog - Copia.master" CodeFile="PruebaRandom.aspx.cs" Inherits="IOT_PruebaRandom" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" Runat="Server">

    

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/solid.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/regular.css"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/brands.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/fontawesome.css" /> 
    <link rel="stylesheet" href="../Content/bootstrap2.css" />

    <div id="imamge_wrapper">
     <img src="../iconos/RISC-PB.jpg"  />
        </div>

	<input type='checkbox' id='R1710LE2005' onclick='checkFluency(this.id)'1710LE2005' class='C1710LE2005' style='display:none;'/>
	<label for='R1710LE2005' id='F1710LE2005' class='fas fa-traffic-light' title='Luces LEDS Sala de Juntas'></label>

	<script type = 'text/javascript' >$(document).ready(function() {$('.C1710LE2005').click(function() {var xhr = new XMLHttpRequest();var c3 = document.getElementById('R1710LE2005').checked;if (c3 === true){xhr.open('GET', 'http://addar.mx:8082/peticion.php?v1=risc-iot.ddns.net:4040&v2=1710LE2005&v3=ON', true);xhr.send();function processRequest(e){if (xhr.readyState == 4 && xhr.status == 200){alert(xhr.response.ip); }}}else if (c3 === false){xhr.open('GET', 'http://addar.mx:8082/peticion.php?v1=risc-iot.ddns.net:4040&v2=1710LE2005&v3=OFF', true);xhr.send();function processRequest(e){if (xhr.readyState == 4 && xhr.status == 200){alert(xhr.response.ip); }}}});}); </script>

<style type='text/css'>#F1710LE2005 {position: absolute; left:400px; top:300px; z-index:10;  
              float: left; opacity: 1;transition: opacity 1.5s linear;  -webkit-transition: opacity 0.5s linear; 
              cursor: pointer; border: 0px; width: 15px; height: 15px;  text-align: center;  line-height: 15px; 
              font-size: 100%; color: rgba(255,0,0,0.8);}#R1710LE2005:checked + #F1710LE2005 {color: rgba(0,220,0,0.8); }</style>


 
    <style type ="text/css">
    .image_wrapper {
    position: absolute;
    width: 900px;
    height: 600px;
    /*float: left;*/
    z-index: -1;
    margin-bottom: 25px;
}

    .image_wrapper .image {
        position: absolute;
        z-index: -1;  
        width: 900px;
        height: 600px;
        border: 1px solid #ccc;
        margin-top: 15px;
        top: 50px;
        /*left: 100px;*/
    }
</style>



</asp:content>


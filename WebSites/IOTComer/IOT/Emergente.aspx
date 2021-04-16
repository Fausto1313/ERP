<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="Emergente.aspx.cs" Inherits="IOT_Emergente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
 <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/solid.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/regular.css"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/brands.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/fontawesome.css" /> 
    <link href="../Content/Encimar_Combo_a_Imagen.css" rel="stylesheet" media="screen"/>
   <script src="//code.jquery.com/jquery-1.5.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-contextmenu/2.7.1/jquery.contextMenu.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-contextmenu/2.7.1/jquery.contextMenu.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-contextmenu/2.7.1/jquery.ui.position.js"></script>
        
<script>
    $(document).ready(() => {
        $.contextMenu({
        selector: '.context-menu-one', 
        items: {        
            key: {
                name: "Bitacora",
                callback: function () {
                    var idCheckbox = $(this).children().first().attr('id');
                    var url = "http://localhost:49436/IOT/consultaDAR?riscei=" + idCheckbox;
                    alert(idCheckbox);
                    window.open(url);
                }
            }
        }, 
        events: {
            show: function(opt) {
                var $this = this;
                $.contextMenu.setInputValues(opt, $this.data());
            }, 
            hide: function(opt) {
                var $this = this;
                $.contextMenu.getInputValues(opt, $this.data());
            }
        }
    });
    });
</script>

    <br /><br /><br /><br /><br /><br /><br /><br /> <br /><br /><br /><br /><br /><br /><br /><br />

<div class="context-menu-one" style="left:410px; top:200px; position:absolute">
<input type='checkbox' id='R" + RISCEI + "' onclick='checkFluency(this.id)'" + RISCEI + "  style='display:none;'/>
<label for='R" + RISCEI + "' id='F" + RISCEI + "' class="far fa-lightbulb" title="Prueba"></label>
</div>

    <br /><br /><br /><br />
    
<input type='checkbox' id='F1710LE2020' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>
<div class="context-menu-one" style="width:5px; height:5px;">
<label for='R" + RISCEI + "' id='F" + 1710LE2020 + "' class="far fa-lightbulb" title="Prueba2"></label>
</div>





    </asp:Content>
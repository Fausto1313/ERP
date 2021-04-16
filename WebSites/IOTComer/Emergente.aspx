<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="Emergente.aspx.cs" Inherits="IOT_Emergente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-contextmenu/2.7.1/jquery.contextMenu.min.css"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-contextmenu/2.7.1/jquery.contextMenu.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-contextmenu/2.7.1/jquery.ui.position.js"></script>

<script>
    $(document).ready(() => {
        $.contextMenu({
        selector: '.context-menu-one', 
        items: {        
            key: {
                name: "Bitacora", 
                callback: function() {
                    var idCheckbox = $(this).children().first().attr('id');
                    var url = "http://localhost:49436/IOT/consultaDAR?riscei=" + idCheckbox;
                    window.open(url,"holi");
                    
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

    <br /><br /><br /><br /><br /><br /><br /><br />

<div class="context-menu-one">
<input type='checkbox' id='R1710LE2005' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "'/>
<label for='R" + RISCEI + "' id='F" + RISCEI + "' class="far fa-lightbulb" title="Prueba"></label>
  
</div>
    <div class="context-menu-one">
          <input type='checkbox' id='R1901BP1212' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "'/>
<label for='R" + RISCEI + "' id='F1901BP1212' class="far fa-lightbulb" title="Prueba francisco"></label>
    </div>



    </asp:Content>
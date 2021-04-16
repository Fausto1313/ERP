<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLogMapas.master" CodeFile="ControlMultiCliente.aspx.cs" Inherits="IOT_ControlMultiCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/solid.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/regular.css"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/brands.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/fontawesome.css" /> 
    <link href="../Content/Encimar_Combo_a_Imagen.css" rel="stylesheet" media="screen"/>
    
    <script src="//code.jquery.com/jquery-1.5.js"></script>

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
                    callback: function () {
                        var idCheckbox = $(this).children().first().attr('id');
                        var cadena = idCheckbox.replace("R", "F");
                        var i = cadena.indexOf("HD", 0);
                        var k = cadena.indexOf("TH", 0);
                        var j = cadena.indexOf("SC", 0);

                        if (i > 0) {
                            var url = "http://addar.mx/IOT/Reportes?sitio=" + sitioJS;
                        }
                        else if (j > 0) {
                            var url = "http://addar.mx/IOT/ReportesCorriente?riscei=" + idCheckbox;
                        }
                        else if (k > 0)
                        {
                            var url = "http://addar.mx/IOT/ReportesTemperatura?riscei=" + idCheckbox;
                        }
                        else
                        {
                            var url = "http://addar.mx/IOT/consultaDAR?riscei=" + idCheckbox;
                        }
                        window.open(url);
                    }
                },
                //sep1: "---------",
                //key1: {
                //    name: "Reportes",
                //    callback: function () {     
                //        var seleccion = $(this).children().first().attr('id');
                //        var cadena = seleccion.replace("R", "F");
                //        var nuevaCadena = document.getElementById(cadena);
                //        var titulo = nuevaCadena.getAttribute("title");
                //        var i = cadena.indexOf("HD", 0)
                //        if (i > 0) {
                //            var huella = "http://localhost:49436/IOT/Reportes";
                //            window.open(huella)
                //        }
                //    }
                //}
            },
            events: {
                show: function (opt) {
                    var $this = this;
                    $.contextMenu.setInputValues(opt, $this.data());
                },
                hide: function (opt) {
                    var $this = this;
                    $.contextMenu.getInputValues(opt, $this.data());
                }
            }
        });
    });
</script>
   
  <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat; position:absolute; left:150px; top:75px; width:900px;">
  <div class="container-fluid">
      
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Panel de Control</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><!--Inicio de ]Modal

            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">
  Cliente Nuevo
</button>

            fin de modal-->
        </li>
        
      </ul>     
       <div id="Tabs" role="tabpanel">
<ul class="nav nav-tabs ">
    <li>
        <div>
                <asp:DropDownList  runat="server" ID="Nivel1"  BorderColor=#0c4566  AppendDataBoundItems="true" OnSelectedIndexChanged="Barrido">
                    <asp:ListItem Value="0">Seleccionar Nivel</asp:ListItem>
                </asp:DropDownList>
           
                <asp:Label runat="server" />
                <asp:LinkButton ID="btnRandom" runat="server" OnClick="GenerarBotones" CssClass="btn btn-primary">
                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>  Buscar
                </asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="GenerarBotones1" CssClass="btn btn-primary">
                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>  Refresh
                </asp:LinkButton>
                
            
        </div>                         
        </li>

</ul><!-- end of nav -->
       
      </div>
        
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
<br/><br/><br/><br/>

    <asp:UpdatePanel runat="server">
            <ContentTemplate>
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
              
              <div class="image_wrapper" id="img1">
                <img  class="image" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem, "imagen"))%>"/> 
              </div>

            </ItemTemplate>
     </asp:Repeater>
  </ContentTemplate>
            </asp:UpdatePanel>



    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
</asp:Content>

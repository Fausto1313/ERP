<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ParaGordi.aspx.cs" Inherits="ParaGordi" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="alert alert-info" role="alert" id ="banner" runat="server" visible="false">
       Página sin configurar.
   </div>
  <div id="carruselP" class="container" runat="server">
      <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
        <li data-target="#myCarousel" data-slide-to="3"></li>
        <li data-target="#myCarousel"  data-slide-to="4"></li>
        <li data-target="#myCarousel"  data-slide-to="5"></li>
    </ol>
    <!-- Wrapper for slides -->
     <div class="carousel-inner">
        <div class="item active">
            <asp:HyperLink runat="server" ID="Url1">
                 <asp:Image runat="server" ID="Imagen1" ImageUrl="~/recursos/Fotitos/foto1.jpg"/>
            </asp:HyperLink>
        </div>
        <div class="item">
          <asp:HyperLink runat="server" ID="Url2">
                 <asp:Image runat="server" ID="Imagen2" ImageUrl="~/recursos/Fotitos/foto2.jpg"/>
            </asp:HyperLink>
        </div>
        <div class="item">
           <asp:HyperLink runat="server" ID="Url3">
                 <asp:Image runat="server" ID="Imagen3" ImageUrl="~/recursos/Fotitos/foto3.jpg"/>
            </asp:HyperLink>
        </div>
         <div class="item">
           <asp:HyperLink runat="server" ID="Url4">
                 <asp:Image runat="server" ID="Imagen4" ImageUrl="~/recursos/Fotitos/foto4.jpg"/>
            </asp:HyperLink>
        </div>
         <div class="item">
           <asp:HyperLink runat="server" ID="Url5">
                 <asp:Image runat="server" ID="Imagen5" ImageUrl="~/recursos/Fotitos/foto5.jpg"/>
            </asp:HyperLink>
        </div>
         <div class="item">
           <asp:HyperLink runat="server" ID="HyperLink1">
                 <asp:Image runat="server" ID="Image1" ImageUrl="~/recursos/Fotitos/foto6.jpg"/>
            </asp:HyperLink>
        </div>
    </div>
          
    <!-- Controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev" >
        <span class="glyphicon glyphicon-chevron-left"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
        <span class="sr-only">Next</span>
    </a>
</div>
  </div>
    <!--Definicion de informacion-->
    <div id="contenedor0" class="container" runat="server">
        
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d1" runat="server">
            <h3>
                <asp:label runat="server" ID="Head1" Text="Para mi gordi"/>
            </h3>
            <asp:Literal runat="server" ID="Cont1">
                Holi mi amor!!! Muchas solo quería agradecerte estos 20 meses que llevamos juntos, con muchas altas y muchas más bajas que
                hemos tenido, pero ten por seguro que siempre me he sentido muy feliz a tu lado.
            </asp:Literal>
        </div>
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="Div1" runat="server">
            <h3>
                <asp:label runat="server" ID="Label1" Text="Continúa jaja"/>
            </h3>
            <asp:Literal runat="server" ID="Literal1">
                Se que a veces hemos pensado que no es nuestra relación soñada, que ambos tenemos muchos defectos, que los problemas son demasiado
                complicados pero sé que al final del día siempre los vamos a resolver por muy complicados que sean y eso es una de las cosas que me gustan de
                estar a tu lado: nunca nos rendimos <3.
            </asp:Literal>
        </div>
    </div>
    <div id="contenedor1" class="container" runat="server">
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d2" runat="server">
            <h3>
        <asp:label runat="server" ID="Head2" Text="Continúa x3"/>
            </h3>
            <asp:Literal runat="server" ID="Cont2">
                Pienso que podemos seguir mejorando siempre, que siempre podremos tener problemas pero que nunca nos rindamos, porque en serio planeo una vida a tu lado
                y quiero continuar siguiendo ser parte de la tuya. Y sobre todo que haces que lo mejor de mi salga y siempre quiera estarte consintiendo y mimando :3
            </asp:Literal>
        </div>
        
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d3" runat="server">
            <h3><asp:label runat="server" ID="Head3" Text="Ya casi jajaja"/></h3>
            <asp:Literal runat="server" ID="Cont3" >
                Así que no me queda más que decir que le sigamos echando ganas y que sigan siendo muchos muchos meses juntos. Te amará siempre tu gordi <3.
            </asp:Literal>
        </div>
        
    </div>
    <div id="contenedor2" class="container" runat="server">
                <div style="justify-content:center; text-align:justify" class="col-md-6" id="d4" runat="server">
                    <h3><asp:label runat="server" ID="Head4" Text="Postdata"/></h3>
            <asp:Literal runat="server" ID="Cont4" >
                Te dejo algo que escribí especialmente para ti, espero te guste mi amor <3
            </asp:Literal>
            </div>
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d5" runat="server">
             <h3><asp:label runat="server" ID="Head5"/></h3>
            <asp:Literal runat="server" ID="Cont5" >
            </asp:Literal>
            </div>
    </div>
    <br />
    <br />
    <br />
    <br />
        
   <style>
       .Capacitacion
       {
color:#0D3685;
font-family: Arial; 
font-size:150%; 
font-weight:normal;
width:70%;
       }
       .Risc
       {
color:#0D3685;
font-family: Arial; 
font-size:200%; 
font-weight:normal;
width:100%;
       }
       .MiLabel
{
text-align:center;
color: #0D3685;
font-family: Arial; 
font-size:150%; 
font-weight:normal;
width:100%;
}
       .carousel-inner img {
    width: 100%;
    max-height: 800px;

}

.carousel-inner{
 height: auto;

}
       </style>
</asp:Content>



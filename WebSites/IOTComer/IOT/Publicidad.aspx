<%@ Page Title="" Language="C#"  MasterPageFile="~/IOT/SiteLogPublicidad.master" AutoEventWireup="true" CodeFile="Publicidad.aspx.cs" Inherits="Publicidad" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
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
        <li data-target="#myCarousel" data-slide-to="4"></li>
        
    </ol>
    <!-- Wrapper for slides -->
     <div class="carousel-inner">
        <div class="item active">
            <asp:HyperLink runat="server" ID="Url1">
                 <asp:Image runat="server" ID="Imagen1"/>
            </asp:HyperLink>
        </div>
        <div class="item">
          <asp:HyperLink runat="server" ID="Url2">
                 <asp:Image runat="server" ID="Imagen2"/>
            </asp:HyperLink>
        </div>
        <div class="item">
           <asp:HyperLink runat="server" ID="Url3">
                 <asp:Image runat="server" ID="Imagen3"/>
            </asp:HyperLink>
        </div>
         <div class="item">
           <asp:HyperLink runat="server" ID="Url4">
                 <asp:Image runat="server" ID="Imagen4"/>
            </asp:HyperLink>
        </div>
         <div class="item">
           <asp:HyperLink runat="server" ID="Url5">
                 <asp:Image runat="server" ID="Imagen5"/>
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
                <asp:label runat="server" ID="Head1"/>
            </h3>
            <asp:Literal runat="server" ID="Cont1">
            </asp:Literal>
        </div>
        <div style="justify-content:center; text-align:center" class="col-md-6">
            <asp:Image runat="server" ID="icono" ImageAlign="Middle" Height="30%" Width="30%" />
        </div>
    </div>
    <div id="contenedor1" class="container" runat="server">
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d2" runat="server">
            <h3>
        <asp:label runat="server" ID="Head2"/>
            </h3>
            <asp:Literal runat="server" ID="Cont2"></asp:Literal>
        </div>
        
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d3" runat="server">
            <h3><asp:label runat="server" ID="Head3"/></h3>
            <asp:Literal runat="server" ID="Cont3" >
            </asp:Literal>
        </div>
        
    </div>
    <div id="contenedor2" class="container" runat="server">
                <div style="justify-content:center; text-align:justify" class="col-md-6" id="d4" runat="server">
                    <h3><asp:label runat="server" ID="Head4"/></h3>
            <asp:Literal runat="server" ID="Cont4" >
            </asp:Literal>
            </div>
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d5" runat="server">
             <h3><asp:label runat="server" ID="Head5"/></h3>
            <asp:Literal runat="server" ID="Cont5" >
            </asp:Literal>
            </div>
    </div>
    <div id="contenedor3" class="container" runat="server">
        <div style="justify-content:center; text-align:justify" class="col-md-6" id="d6" runat="server">
                    <h3><asp:label runat="server" ID="Head6"/></h3>
            <asp:Literal runat="server" ID="Cont6" >
            </asp:Literal>
            </div>
        <div style="justify-content:center; text-align:justify" class="col-md-6">
             <h3><asp:Label runat="server" ID="Head7"/></h3>
            <iframe runat="server" id="mapa" height="250" width="500" frameborder="0" style="border:0;" allowfullscreen=""></iframe>
            <br />
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
    max-height: 460px;

}

.carousel-inner{
 height: auto;

}
       </style>
</asp:Content>


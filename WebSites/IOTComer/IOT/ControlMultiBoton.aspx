<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="ControlMultiBoton.aspx.cs" Inherits="IOT_ControlMultiBoton" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" Runat="Server">
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
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
        <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Carga_select" AutoPostBack="true" />
        </li> 
        <li>
        <asp:DropDownList runat="server" ID="Nivel1" CssClass="form-control" BorderColor=#0c4566 />
        </li>
        <li>
        <asp:LinkButton ID="btnRandom" runat="server" OnClick="GenerarBotones" CssClass="btn btn-primary">
        <span aria-hidden="true" class="glyphicon glyphicon-search"></span>  Buscar
        </asp:LinkButton>                                
       </li>  
</ul>  
           </div>
      </div>    
    </div><!-- /.navbar-collapse -->
 
</nav>
      <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este cátalogo se realizará el manejo de dispositivos instalados en en catálogo DARS, a su vez de podrán controlar desde los botones mostrados.</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->

   <br />
    <div>
        <asp:UpdatePanel ID="x" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset style="height: 100px">
                <legend><h3>Dispositivos Instalados&nbsp;
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" ></asp:PlaceHolder>
                    </h3></legend>
           
                </fieldset>
                <div style="width: 500px; margin-left: 200px; margin-top: 20px" >
                   
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
                <!--<asp:Label ID="Label1" BorderStyle="Inset" runat="server">No has hecho click sobre ningún botón</asp:Label>
                <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>-->
           
            </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogoDispos.aspx" runat="server" role="button">Volver</a>
    </div>
</asp:Content>
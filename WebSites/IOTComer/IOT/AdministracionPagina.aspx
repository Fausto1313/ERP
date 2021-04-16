<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionPagina.aspx.cs" Inherits="IOT_AdministracionPagina" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <br />
     <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure" >Administración de sitio web</a>     
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li>
        </li>       
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group">       
        </div>     
      </div>
    </div>
  </div>
</nav>

     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Información: La sección de añadir imágenes será para la parte publicitaria de la página web, mostrándose en un carrusel promocional. El orden que se vayan insertando será el orden en que aparezcan, así como si
        redirigen a una página externa.</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
       
            <div class="container">
                
            <div class="col-md-2">
                <asp:Label runat="server" AssociatedControlID="Categoria"># de sección</asp:Label>
                </div>
                            <div class="col-md-2">

                <asp:DropDownList runat="server" ID="Categoria" CssClass="form-control" BorderColor="#0c4566"  AutoPostBack="false">
                    <asp:ListItem Text="Seleccionar" Selected="True" Value="0"/>
                    <asp:ListItem Text="#1" Value="1" />
                    <asp:ListItem Text="#2" Value="2" />
                    <asp:ListItem Text="#3" Value="3" />
                    <asp:ListItem Text="#4" Value="4" />
                    <asp:ListItem Text="#5" Value="5" />
                    <asp:ListItem Text="#6" Value="6"/>
                    <asp:ListItem Text="URL Localización" Value="7" />
                    </asp:DropDownList>
            </div> 
                <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="txtEncabezado">Encabezado</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtEncabezado" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEncabezado" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="txtContenido">Contenido</asp:Label>
                </div>
            <div class="col-md-2">
                 <asp:TextBox runat="server" ID="txtContenido" Rows="8" Columns="30" MaxLength="8"  TextMode="MultiLine"  placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContenido" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
            </div>
                </div>
                <div class="container">
            <div class="col-md-12 col-md-offset-5">
                <asp:Button runat="server" ID="Insertar" OnClick="Insertar_Click" Text="Insertar/Actualizar Texto"  CssClass="btn btn-success" />
            </div>
                    </div>
                <br />

     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> Información: La sección de añadir imágenes será para la parte publicitaria de la página web, mostrándose en un carrusel promocional. El orden que se vayan insertando será el orden en que aparezcan, así como si
        redirigen a una página externa.
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    
    <div class="container">
               <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="NumeroImagen" CssClass="col-md-1 control-label">Posición Imagen</asp:Label>
                </div>
                <div class="col-md-3">
                <asp:DropDownList runat="server" ID="NumeroImagen" CssClass="form-control" BorderColor="#0c4566"  AutoPostBack="false">
                    <asp:ListItem Text="Seleccionar" Selected="True" Value="0"/>
                    <asp:ListItem Text="Imagen Principal" Value="1" />
                    <asp:ListItem Text="Imagen #2" Value="2" />
                    <asp:ListItem Text="Imagen #3" Value="3" />
                    <asp:ListItem Text="Imagen #4" Value="4" />
                    <asp:ListItem Text="Imagen #5" Value="5" />
                    </asp:DropDownList>
            </div> 
        <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="Imagen" CssClass="col-md-1 control-label">Examinar</asp:Label>
        </div>
        <div class="col-md-3">
            <asp:FileUpload runat="server" accept=".jpg,.png" ID="Imagen" />
        </div>
        <div class="col-md-3">
        </div>
        </div>
    <br />
    <div class="container">
        <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="txtURL" CssClass="col-md-1 control-label">URL </asp:Label>
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="txtURL" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="GuardaImagen" Text="Insertar/Actualizar Imagen" OnClick="GuardaImagen_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogosGeneral.aspx" runat="server" role="button">Volver</a>
    </div>
</asp:Content>


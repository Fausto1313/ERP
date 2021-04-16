<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Activado.aspx.cs" Inherits="IOT_Activado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
       <br />
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
      <a class="navbar-brand" href="#" style="color:azure">Activación del Sistema</a>
    </div>
      </div>
         </nav> 
   <br />

     <div class="row">
                <div class="col-xs-3 col-sm-4 col-lg-4 col-sm-offset-1 col-md-offset-1">
                    <h2>Revisar registro de activación</h2>
                        <a class="btn btn-default" href="/IOT/ActivacionRegistro.aspx" style="background-image: url('/recursos/activado.jpg'); height: 260px; width: 260px;"></a>
                </div>
                <div class="col-xs-3 col-sm-4 col-lg-4 col-sm-offset-2 col-md-offset-3">
                    <h2>Activar Sistema</h2>
                       <asp:Button ID="btnAdd" runat="server" BorderColor=#0c4566 ValidationGroup="Activar" Text="Activar Sistema" OnClick="btnAdd_Click" CssClass="btn btn-success" Width="162px"/>
            </div>
          <div class="col-xs-3 col-sm-4 col-lg-4 col-sm-offset-2 col-md-offset-3">
                    <h2>Desactivar Sistema</h2>
                       <asp:Button ID="Button1" runat="server" BorderColor=#0c4566 ValidationGroup="Desactivar" OnClick="Button1_Click" Text="Desactivar Sistema" CssClass="btn btn-danger" Width="162px"/>
            </div>
         <div class="col-xs-3 col-sm-4 col-lg-4 col-sm-offset-2 col-md-offset-3">
                    <h2>Estatus del Sistema</h2>
                        <asp:label for="input" runat="server" ID="seguridad" CssClass=" fa fa-2x"  BorderColor="SpringGreen" BorderStyle="Double" class="col-md-3 control-label"></asp:label>
            </div>
         </div>
    <div>
        <a class="btn btn-danger" href="CatalogoSeguridad.aspx" runat="server" role="button">Volver</a>
    </div>
</asp:Content>


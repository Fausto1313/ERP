<%@ Page Title="Rastreo Satelital" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="MapaRastreo.aspx.cs" Inherits="IOT_MapaRastreo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Rastreo satelital</a>
        <asp:Button runat="server" ID="Buscar" Text="Buscar dispositivo" CssClass="btn btn-primary" OnClick="Timer1_Tick"  />
    </div>
  </div><!-- /.container-fluid -->
</nav>
    <asp:UpdatePanel runat="server" ID="Actualizar">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Buscar" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <div align="center">
    <iframe runat="server" src="http://addar.mx:8082/mapa3.html" id="Frame1" width="620" height="420" style="align-items:center" ></iframe>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
          <div>
        <a class="btn btn-danger" href="Bitacoras.aspx" runat="server" role="button">Volver</a>
    </div>
</asp:Content>


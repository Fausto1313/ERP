<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="ConteoPersonas.aspx.cs" Inherits="IOT_ConteoPersonas" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Muestra de conteo de personas</a>
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
       <div class="navbar-form navbar-left">
        <div class="form-group">
         
        </div>
       
      </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav> 
         <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">   Bitácora que muestra el conteo de personas del arco RFID)..</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />

    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID" CssClass="table table-hover table-striped" DataSourceID="connectionCount">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
        <asp:BoundField DataField="RISCEI" HeaderText="RISCEI" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
        <asp:BoundField DataField="numeroPersonas" HeaderText="Numero de personas" SortExpression="numeroPersonas" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
        <asp:BoundField DataField="personasTotales" HeaderText="Personas totales en el dia" SortExpression="personasTotales" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 Dataformatstring="{0:dd-M-yyyy}" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="connectionCount" runat="server" ConnectionString="<%$ ConnectionStrings:IOTComerConnectionString %>" SelectCommand="SELECT * FROM [Conteo]"></asp:SqlDataSource>
     <div>
        <a class="btn btn-danger" href="Bitacoras.aspx" runat="server" role="button">Volver</a>
    </div>
</asp:Content>


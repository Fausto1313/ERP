<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Electrico.aspx.cs" Inherits="Electrico" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Muestra de Corriente Eléctrica</a>
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
<a class="alert-link"> Bitácora de monitoreo eléctrico (Amperes y Voltaje).</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
   
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True"  CssClass="table table-hover table-striped" HorizontalAlign="Center">
         <Columns>
             <asp:BoundField DataField="RISCEI" HeaderText="RISCEI" SortExpression="RISCEI"  HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566  />
             <asp:BoundField DataField="Amperaje" HeaderText="Amperaje" SortExpression="Amperaje"  HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
             <asp:BoundField DataField="Potencia" HeaderText="Watts" SortExpression="Potencia"   HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566  />
             <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"   HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
         </Columns>
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT top 20 [RISCEI], [Amperaje], [Potencia], [Fecha] FROM [Electrico] order by Fecha desc"></asp:SqlDataSource>
      <div>
        <a class="btn btn-danger" href="Bitacoras.aspx" runat="server" role="button">Volver</a>
    </div>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="ActivacionRegistro.aspx.cs" Inherits="IOT_ActivacionRegistro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" Runat="Server">
    
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
      <a class="navbar-brand" href="#" style="color:azure">Bitácora de seguridad del sistema</a>
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
<a class="alert-link">En este catálogo se podrá consultar la información de los regristros de activación de seguridad de acuerdo al usuario.</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
    Buscar:&nbsp;<asp:TextBox ID="txtSearch" style="text-align:center" runat="server" OnTextChanged="Search" AutoPostBack="true" ></asp:TextBox>
            <br />
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="720px" HorizontalAlign="Center" AllowPaging="true" CssClass="table table-hover table-striped" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha"  DataFormatString="{0:dd/MM/yyyy hh:mm tt}" SortExpression="Fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
            <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario que activó/desactivó el sistema" SortExpression="Usuario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Button runat="server" ID="volver" OnClick="volver_Click" CssClass="btn btn-danger" Text="Volver"  />
        <br />
</asp:Content>


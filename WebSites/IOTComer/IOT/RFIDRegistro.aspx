﻿<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="RFIDRegistro.aspx.cs" Inherits="IOT_RFIDRegistro" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    
    &nbsp;<br />
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
      <a class="navbar-brand" href="#" style="color:azure">Bitácora de acciones realizadas</a>
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
   <div class="alert alert-info" role="alert">
        Bitácora que muestra todas las respuestas de los DAR que realizan acciones: Ej luces
   </div>

    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID" CssClass="table table-hover table-striped"
                        OnPageIndexChanging="PageIndexChanging" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="UsuarioRFID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario" SortExpression="Usuario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="CodigoRFID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Codigo" SortExpression="Codigo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Fecha" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"  ItemStyle-HorizontalAlign="Center" HeaderText="Fecha" SortExpression="Fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
        </Columns>
    </asp:GridView>
    <div>
        <a class="btn btn-danger" href="Bitacoras.aspx" runat="server" role="button">Volver</a>
    </div>

</asp:Content>


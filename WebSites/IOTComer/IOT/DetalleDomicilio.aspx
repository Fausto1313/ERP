<%@ Page Language="C#"  MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="DetalleDomicilio.aspx.cs" Inherits="IOT_DetalleDomicilio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
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
      <a class="navbar-brand" href="#" style="color:azure" >Detalle Pedido</a>
       
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li>
            <!--Inicio de ]Modal

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
<a class="alert-link">Este catálogo se podrá consultar la información del detalle del servicio a domicilio de acuerdo a la selección de la pantalla pedido domicilio .
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
     <!-- PANEL DE ROL SELECCIONADO -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
   <asp:GridView runat ="server" ID="DetallePedido" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false">
       <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre Persona" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           </Columns>
   </asp:GridView>
         <%--<asp:Button ID="btnAdd" runat="server" BorderColor="#0c4566" OnClick="btnAdd_Click" Text="Agregar Permiso" CssClass="btn btn-success" Width="162px"/>--%>
                 
    
    </div>
    
    <br />
    <br />
              </ContentTemplate>
         </asp:UpdatePanel>
   <%--  <!-- PANEL DE ROLES PERMISOS AGREGADOS -->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="PedidoDetalle" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="ID" CssClass="table table-hover table-striped"   >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="# Orden" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Tamaño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Tamaño" SortExpression="Tamaño" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Comentario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Comentario" SortExpression="Comentario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Tamaño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Tamaño" SortExpression="Tamaño" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <%--<asp:buttonField  CommandName="delRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar Permiso" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
         <%--   </Columns>
        </asp:GridView>
              </ContentTemplate>
              </asp:UpdatePanel>--%>

         <!-- PANEL DE ROLES PERMISOS AGREGADOS -->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
    <asp:GridView ID="DetalleOrden" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="ID" CssClass="table table-hover table-striped" OnPageIndexChanging="DetalleComida_PageIndexChanged"  >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
         <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField DataField="Tamaño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Tamaño" SortExpression="Tamaño" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Comentario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Comentario" SortExpression="Comentario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             

            <%--<asp:buttonField  CommandName="delRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar Permiso" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
            </Columns>
        </asp:GridView>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
         
                <div>
                  <a class="btn btn-danger" href="PedidoDomic.aspx" runat="server" role="button">Volver</a>
                </div>
    </asp:Content>
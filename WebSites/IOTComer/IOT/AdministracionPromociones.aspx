<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionPromociones.aspx.cs" Inherits="IOT_AdministracionPromociones" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Administración de Promociones</a>
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
    
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class ="row">
                <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="txtNombre">Nombre</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtNombre" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
                 <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Precio">Precio $</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="Precio" TextMode="Number" placeholder="Insertar Valor" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Precio" CssClass="text-danger" ErrorMessage="Ingresar Valor." ValidationGroup="groupInsert"/>
                </div>
                </div>
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Button runat="server" ID="Agregar" CssClass="btn btn-success" Text="Agregar" OnClick="Agregar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="GridView1" runat="server">
          <ContentTemplate>
    <asp:GridView ID="PromocionesDetalle" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="ID" CssClass="table table-hover table-striped" OnPageIndexChanging="PromocionesDetalle_PageIndexChanging" OnRowCommand="PromocionesDetalle_RowCommand" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de Paquete" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="${0:###,###,###.00}" HeaderText="Precio de Paquete" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:buttonField  CommandName="AddProducto" ButtonType="Button" ControlStyle-CssClass="btn btn-info" Text="Detalle" HeaderText="Productos" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>
            </Columns>
        </asp:GridView>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
                <div>
                  <a class="btn btn-danger" href="AdministracionRestaurantes.aspx" runat="server" role="button">Volver</a>
                </div>
</asp:Content>


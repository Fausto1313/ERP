<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="PedidoDomic.aspx.cs" Inherits="IOT_PedidoDomic" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Pedido a Domicilio</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li></li>    
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group">       
        </div>     
        </div>
    </div>
  </div>
</nav> 
       <style>
        .icon-success {
    color:darkgoldenrod;
     font-size:20px;
}
   .icon-cambiar {
    color:blue;
     font-size:20px;
}
  
    </style>
<!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrá consultar la información de los pedidos a domicilio realizadas en la aplicación ADDAR RISC Y ADDAR CONTROL.
<p>
    INSTRUCCION: Para ver el detalle del pedido deberas dar clic en el icono Ver Orden y para mostrar la información en la tabla deberás seleccionar el filtro.

</p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
                       <div class="row">
           <asp:Label runat="server" AssociatedControlID="Estatuss" CssClass="col-md-1 control-label">Estatus</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Estatuss" AutoPostBack="true" CssClass="form-control">
                <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                                       <asp:ListItem Text="En Espera" Value="En Espera" />
                                       <asp:ListItem Text="En Preparación" Value="En Preparación" />
                                       <asp:ListItem Text="Rechazado" Value="Rechazado" />
                                       <asp:ListItem Text="En Camino" Value="En Camino" />
                                        <asp:ListItem Text="Completado" Value="Completado" />
               </asp:DropDownList>
        </div>
        </div>
                 </br></br>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="ID"
                        CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>      
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

           <%-- <asp:BoundField DataField="IDUsuario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario" SortExpression="IDUsuario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>--%>
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Domicilio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Domicilio" SortExpression="Domicilio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Total" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Total" SortExpression="Total" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField CommandName="updDomi" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
          <%--  <asp:buttonField  CommandName="updDomi" ButtonType="Button"  ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
            <asp:ButtonField CommandName="asignarpedido" HeaderText="Ver Orden" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-eye-open icon-success"></i>' />
            <%--<asp:buttonField  CommandName="asignarpedido" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Ver Orden" HeaderText="Ver Orden" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
<%--   <asp:Button ID="btnAdd" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar" OnClick="BtnAddClick" Text="Agregar Comida" CssClass="btn btn-success" Width="162px" />
               <asp:Button ID="btnAdd2" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar2" OnClick="BtnAddClick2" Text="Reasignar Comida" CssClass="btn btn-primary" Width="162px" />--%>

            </ContentTemplate>
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div> 
    <div>
        <a class="btn btn-danger" href="CatalogosRestaurant.aspx" runat="server" role="button">Volver</a>
    </div>

      <!-- Edit Modal Starts here -->
             <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                       <div class="modal-body">

                            <table class="table">
                                  <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                    <asp:label ID="lblID"  runat="server"></asp:label>
                                 
                                     </div>
                              <div class="form-group">
                                           <label for="input" class="col-md-3 control-label">Estatus:</label>
                                   <asp:DropDownList runat="server" ID="tipo2" BorderColor=#0c4566 CssClass="form-control">
                                        
                                        <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                                       <asp:ListItem Text="En Espera" Value="En Espera" />
                                       <asp:ListItem Text="En Preparación" Value="En Preparación" />
                                       <asp:ListItem Text="Rechazado" Value="Rechazado" />
                                       <asp:ListItem Text="En Camino" Value="En Camino" />
                                        <asp:ListItem Text="Completado" Value="Completado" />
                                    
                                       </asp:DropDownList>
                                      </div>
                                     </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                         <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
     <!----->

     
</asp:Content>


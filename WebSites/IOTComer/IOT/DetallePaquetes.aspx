<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="DetallePaquetes.aspx.cs" Inherits="IOT_DetallePaquetes" %>

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
      <a class="navbar-brand" href="#" style="color:azure" >Detalle de Paquetes</a>
       
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
           <style>
        .icon-success {
    color:red;
     font-size:20px;
}
    </style>
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> En este catálogo podras dar el alta cada uno de los productos de acuerdo al paquete seleccionado anteriormente.
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <!-- PANEL DE ROL SELECCIONADO -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
   <asp:GridView runat ="server" ID="PaqueteInfo" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false">
       <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de paquete" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" DataFormatString="${0:###,###,###.00}" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           </Columns>
   </asp:GridView>
             <div>
                  <a class="btn btn-danger" href="AdministracionPaquetes.aspx" runat="server" role="button">Volver</a>
                </div>             
    
    </div>
    
    <br />
    <br />
              </ContentTemplate>
         </asp:UpdatePanel>
    <!-- PANEL DE ROLES PERMISOS AGREGADOS -->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="PaquetesDetalle" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="Id" CssClass="table table-hover table-striped" OnPageIndexChanging="PaquetesDetalle_PageIndexChanging" OnRowCommand="PaquetesDetalle_RowCommand" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de Producto" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Tamaño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Tamaño de Producto" SortExpression="Tamaño" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
           <%-- <asp:buttonField  CommandName="delRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar Producto" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
            </Columns>
        </asp:GridView>
<asp:Button ID="btnAdd" runat="server" BorderColor="#0c4566" OnClick="btnAdd_Click" Text="Agregar Producto" CssClass="btn btn-success" Width="162px"/>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
    <br />
    <br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
         
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
          <ContentTemplate>
    <asp:GridView ID="Extras" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="Id" CssClass="table table-hover table-striped" OnPageIndexChanging="Extras_PageIndexChanging" OnRowCommand="Extras_RowCommand" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Modulo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" DataFormatString="${0:###,###,###.00}" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:buttonField  CommandName="delRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar Extra" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>
            </Columns>
        </asp:GridView>
              <asp:Button ID="ExtraBoton" runat="server" BorderColor="#0c4566" OnClick="ExtraBoton_Click" Text="Agregar Extra" CssClass="btn btn-success" Width="162px"/>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
                
    <!-- INICIA MODAL PARA AGREGAR Y ELIMINAR PRODUCTOS -->
    <div id="addModalProducto" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Añadir Producto</h3>
                </div>
                    <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                    <ContentTemplate>
                         <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <asp:Label runat="server" CssClass="col-md-3" ID="Categoria" Text="Categoria" />
                             <asp:DropDownList runat="server" ID="Cat" CssClass="form-control" OnSelectedIndexChanged="Cat_SelectedIndexChanged" AutoPostBack="true" />
                                  <br />
                                <br />
                                    <asp:Label runat="server" CssClass="col-md-3" ID="Label1" Text="Subcategoria" />
                             <asp:DropDownList runat="server" ID="Sub" CssClass="form-control" OnSelectedIndexChanged="Sub_SelectedIndexChanged" AutoPostBack="true" />
                                <br />
                                <br />
                                    <asp:Label runat="server" CssClass="col-md-3" ID="Label2" Text="Producto" />
                             <asp:DropDownList runat="server" ID="Producto" CssClass="form-control" />
                                </table>
                                 </div>
                             </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="BtnAddRecord_Click" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="groupInsert"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnAddRecord" EventName="Click" />
                    </Triggers>
                        </asp:UpdatePanel>
                  
                  
                    </div>
                    </div>
        </div>
    <!-- INICIA MODAL PARA ELIMINAR PRODUCTOS -->
    <div id="eliminaModalProducto" class="modal fade"  tabindex="-1"  aria-labelledby="eliminaModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                    <h3 id="eliminaModalLabel" style="color:azure">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="DELETE" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            Desea Eliminar este registro?
                            <asp:HiddenField runat="server" ID="Producto_Borrar" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server" ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                        </div>
                       
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
<%--    Inicia INSERT DE EXTRAS--%>
    <div id="addModalExtras" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalExtrasLabel" style="color:azure">Añadir Extras</h3>
                </div>
                    <asp:UpdatePanel ID="UpdatePanel3" class="form-group"  runat="server">
                    <ContentTemplate>
                         <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <asp:Label runat="server" CssClass="col-md-3" ID="Label3" Text="Nombre" />
                             <asp:DropDownList runat="server" ID="ExtraList" CssClass="form-control" OnSelectedIndexChanged="ExtraList_SelectedIndexChanged" AutoPostBack="true" />
                                  <br />
                                <br />
                                    <asp:Label runat="server" CssClass="col-md-3" ID="Label4" Text="Precio: $" />
                             <asp:TextBox runat="server" CssClass="col-md-3" ID="PrecioExtra" Enabled="false" />
                                </table>
                                 </div>
                             </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="AddExtras" runat="server" OnClick="AddExtras_Click" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="groupInsert"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnAddRecord" EventName="Click" />
                    </Triggers>
                        </asp:UpdatePanel>
                  
                  
                    </div>
                    </div>
        </div>
    <!-- INICIA MODAL PARA ELIMINAR EXTRAS -->
    <div id="eliminaModalExtras" class="modal fade"  tabindex="-1"  aria-labelledby="eliminaModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                    <h3 id="eliminaModalExtrasLabel" style="color:azure">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            Desea Eliminar este registro?
                            <asp:HiddenField runat="server" ID="IDExtra" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="EliminarExtra" runat="server" ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="EliminarExtra_Click"  />
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                        </div>
                       
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>

</asp:Content>


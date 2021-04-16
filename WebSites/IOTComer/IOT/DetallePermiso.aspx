<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="DetallePermiso.aspx.cs" Inherits="IOT_DetallePermiso" %>

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
      <a class="navbar-brand" href="#" style="color:azure" >Detalle de Rol</a>
       
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
      <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este cátalogo se realizará la asignación de los permisos correspondientes de acuerdo al usuario.</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <!-- PANEL DE ROL SELECCIONADO -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
   <asp:GridView runat ="server" ID="DetalleRol" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false">
       <Columns>
           <asp:BoundField DataField="Id" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de Rol" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           </Columns>
   </asp:GridView>
         <asp:Button ID="btnAdd" runat="server" BorderColor="#0c4566" OnClick="btnAdd_Click" Text="Agregar Permiso" CssClass="btn btn-success" Width="162px"/>
                 
    
    </div>
    
    <br />
    <br />
              </ContentTemplate>
         </asp:UpdatePanel>
    <!-- PANEL DE ROLES PERMISOS AGREGADOS -->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="PermisosDetalle" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="Id" CssClass="table table-hover table-striped" OnPageIndexChanging="PermisosDetalle_PageIndexChanged" OnRowCommand="PermisosDetalle_RowCommand" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="# Permiso" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Modulo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de Catálogo" SortExpression="Modulo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
        <%--    <asp:buttonField  CommandName="delRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar Permiso" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
            </Columns>
        </asp:GridView>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
                <div>
                  <a class="btn btn-danger" href="Permisos.aspx" runat="server" role="button">Volver</a>
                </div>
    <!-- INICIA MODAL PARA AGREGAR -->
    <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Asignar Permiso</h3>
                </div>
                    <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                    <ContentTemplate>
                         <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <asp:Label runat="server" CssClass="col-md-3" ID="PermisoListaLabel" Text="Permiso" />
                             <asp:DropDownList runat="server" ID="PermisoLista" />
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
    <!-- INICIA MODAL PARA ELIMINAR -->
    <div id="eliminaModal" class="modal fade"  tabindex="-1"  aria-labelledby="eliminaModalLabel" aria-hidden="true">
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
                            <asp:HiddenField runat="server" ID="Permiso_Borrar" />
                            <asp:HiddenField runat="server" ID="Rol_Borrar" />
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

</asp:Content>


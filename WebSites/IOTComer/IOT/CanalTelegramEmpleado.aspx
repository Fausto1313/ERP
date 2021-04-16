<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="CanalTelegramEmpleado.aspx.cs" Inherits="IOT_CanalTelegramEmpleado" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent2">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
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
      <a class="navbar-brand" href="#" style="color:azure">Canales de telegram de empleados</a>
    </div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><!--Inicio de ]Modal
            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal"> Cliente Nuevo</button>
            fin de modal-->
        </li>  
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group"></div>  
      </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav> 
  <style>
     .icon-success {
     color: red;
    font-size: 20px;
  }
     .icon-asignar {
    color:darkorange;
     font-size:20px;
}
 
    </style>

     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> En este catálogo se podrá asignar uno o varios empleados a un canal de telegram para el envio de alerta al ingresar al sitio .</a>
</div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
<!-- INICIA Catalogo -->
    <div class="form-horizontal">
        <div class="row" >            
             <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Carga_select" AutoPostBack="true"/>
            </div>
             <asp:Label runat="server" AssociatedControlID="Empleado" CssClass="col-md-1 control-label"><b>Empleado</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Empleado" CssClass="form-control" BorderColor=#0c4566 />
            </div>                  
            </div>
        <br />
        <div class="row" > 
            <asp:Label runat="server" AssociatedControlID="Canal" CssClass="col-md-1 control-label"><b>Canal Telegram</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Canal" CssClass="form-control" BorderColor=#0c4566 />
            </div>
             <asp:Label runat="server" AssociatedControlID="Tipo" CssClass="col-md-1 control-label"><b>Tipo de aviso</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Tipo" CssClass="form-control" BorderColor=#0c4566>
                    <asp:ListItem>Unico</asp:ListItem>
                    <asp:ListItem>Repetitivo</asp:ListItem>
                </asp:DropDownList>
            </div>
                <asp:DropDownList runat="server" ID="Estatus" CssClass="form-control" BorderColor=#0c4566 Visible="false">
                    <asp:ListItem>Habilitado</asp:ListItem>
                </asp:DropDownList>

        </div>
      </div>    
    <br/>
  <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">            
          <ContentTemplate>
              <asp:Button runat="server" BorderColor=#2e7d32 OnClick="Asignar_Canal" Text="Asignar canal" CssClass="btn btn-success" Width="162px" ValidationGroup="groupInsert"/>
<br /><br /><br />   

<asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true"
         DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand"  OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>    
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Apellidos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellidos" SortExpression="Apellidos" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CanalTelegram" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Canal de telegram" SortExpression="Canal" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="NombreCanal" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre del canal" SortExpression="CanalNom" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Tipo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="tipo" SortExpression="tipo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                  <asp:ButtonField CommandName="Actualizar" HeaderText="Cambiar Canal" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-send icon-asignar"></i>' />
           <%-- <asp:buttonField  CommandName="Actualizar" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Cambiar" HeaderText="Cambiar de canal" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
                  <asp:ButtonField CommandName="Eliminar" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
            <%--<asp:buttonField  CommandName="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar regla" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
        </Columns>   
    </asp:GridView>
            </ContentTemplate>     
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogosAdmin.aspx" runat="server" role="button">Volver</a>
    </div>

<!-- Edit Modal Starts here -->
            <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                      <div class="modal-body">
                      <table class="table">
                        <tr>
                        <td>ID: 
                        <asp:Label ID="lblID" runat="server" BorderColor=#0c4566></asp:Label>
                        </td>                                  
                        </tr>
                        <tr>
                        <td>Nombre: 
                        <asp:Label ID="lblNombre" runat="server" BorderColor=#0c4566></asp:Label>
                        </td>                                  
                        </tr>
                         <tr>
                        <td>Canal actual: 
                        <asp:Label ID="lblActual" runat="server" BorderColor=#0c4566></asp:Label>
                        </td>                                  
                        </tr>
                        <tr>
                        <td>
                        -----------------------------------------------------------------------
                        </td>
                        </tr>
                        <tr>
                        <td>Cambiar canal:
                        <asp:DropDownList runat="server" ID="Can" BorderColor=#0c4566/>
                        </td>
                        </tr>
                        <tr>
                        <td>Cambiar tipo de aviso:
                        <asp:DropDownList runat="server" ID="tipo1" BorderColor=#0c4566>
                            <asp:ListItem>Unico</asp:ListItem>
                            <asp:ListItem>Repetitivo</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        </tr>
                        <tr>
                        <td>Cambiar Estatus:
                        <asp:DropDownList runat="server" ID="estatus1" BorderColor=#0c4566>
                            <asp:ListItem>Habilitado</asp:ListItem>
                            <asp:ListItem>Deshabilitado</asp:ListItem>
                        </asp:DropDownList>
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
    <!-- Edit Modal Ends here -->

    <!-- MODAL DE ELIMINAR -->
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
                            <asp:HiddenField ID="hfID" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server"  ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                        </div>                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
    <!-- FIN MODAL ELIMINAR -->

 </asp:Content>


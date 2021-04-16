<%@ Page Language="C#"  MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="IOT_Permisos" %>
   <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
       
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
      <a class="navbar-brand" href="#" style="color:azure" >Catalogo Roles</a>
       
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
          <style>
        .icon-success {
    color:goldenrod;
    font-size:20px;

}
         .icon-actualizar {
    color:blue;
     font-size:20px;
}
    </style>
        <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este cátalogo se dará de alta los roles y a su vez asignar los permisos correspondientes al usuario.</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->

   <br />

      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="OnPageIndexChanging" >
        <Columns>
             <asp:BoundField DataField="Id" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>   

              <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
              <%--  <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
            
             <asp:ButtonField CommandName="asignarPermiso" HeaderText="Asignar Permisos a Rol" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-cog icon-success"></i>' />
<%--        <asp:buttonField  CommandName="asignarPermiso" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Asignar" HeaderText="Asignar Permisos a Rol" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>--%>
        </Columns>
  
    </asp:GridView>
<asp:Button ID="btnAdd" runat="server" BorderColor=#0c4566 OnClick="BtnAddClick" Text="Agregar Rol" CssClass="btn btn-success" ValidationGroup="validar" Width="162px"/>

    
              </ContentTemplate>
          
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
                <div><br /><br />
   
                               
     
        <br /><br />
    </div>
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
                                    <label for="input" class="col-md-3 control-label">Nombre:</label>
                                <asp:TextBox ID="txtNombre12" placeholder="Nombre del Rol" runat="server" BorderColor=#0c4566></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNombre12" ForeColor="Red" ValidationGroup="Actualizar">
                                  </asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtNombre12" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo letras!" ValidationGroup="Actualizar"/>
                                 
                                
                                     </div>
                                     </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnAddRecordClickrole" ValidationGroup="Actualizar" Text="Guardar" CssClass="btn btn-success" />
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
        <!-- Inicia Modal Para CONSULTAR-->
  <div id="ConsultaModal" class="modal fade"  tabindex="-1"  aria-labelledby="delModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="delModalLabel1" style="color:azure">Permisos</h3>
                </div>
                <asp:UpdatePanel ID="Consulta" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">                  
       <asp:GridView ID="GridView2" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped" OnPageIndexChanging="GridView2_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Modulo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modulo" SortExpression="Modulo">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <div class="modal-footer">
                            
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>          
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
   
     <!-- Inicia Modal Para ELIMINAR Registro-->

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
   
     <!-- Inicia Modal Para Nuevo Registro-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Rol</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                <asp:label ID="lblID1"  runat="server"></asp:label>
                                 
                                     </div>
                                 
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Nombre:</label>
                                <asp:TextBox ID="txtNombre1" placeholder="Nombre del Rol" runat="server" BorderColor=#0c4566></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNombre1" ForeColor="Red" ValidationGroup="Agregar">
                                           </asp:RequiredFieldValidator>    
                                     </div>
                                       
                            
                            </table>
                        </div>
                            </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" ValidationGroup="Agregar" OnClick="BtnAddRecordClick" Text="Confirmar " CssClass="btn btn-success" />
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
            </div>
 <div>
        <a class="btn btn-danger" href="CatalogosUser.aspx" runat="server" role="button">Volver</a>
    </div>
            <!--Finaliza Modal Para Asignar PERMISOS-->
<!--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--> 
         <div id="addModals" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel1" style="color:azure">Asignar permisos</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                <asp:label ID="Label1"  runat="server"></asp:label>
                                 
                                     </div>
                                 
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Nombre:</label>
                               <asp:DropDownList ID="Roles" runat ="server" BorderColor=#0c4566></asp:DropDownList>
                                
                                     </div>
                                       
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Bitácora de Acciones Realizadas:</label>
                                <asp:CheckBox ID="chkAcciones" runat="server" BorderColor=#0c4566/>
                                     </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Bitácora de Acciones Registradas (DAR):</label>
                               <asp:CheckBox ID="chkPerifericos" runat="server" BorderColor=#0c4566/>
                                     </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Bitácora de Registros de Humedad y Temperatura:</label>
                                <asp:CheckBox ID="chkAmbiente" runat="server" BorderColor=#0c4566 />

                                     </div>
                                          <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Alta y Asignacion de Usuaarios Telegram:</label>
                                <asp:CheckBox ID="chkTelegram" runat="server" BorderColor=#0c4566 />

                                     </div>
                                   <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Crear un Nuevo Usuario:</label>
                                <asp:CheckBox ID="chkUsuarios" runat="server" BorderColor=#0c4566/>

                                     </div>

                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Crear un Nuevo Rol:</label>
                                <asp:CheckBox ID="chkNuevoRol" runat="server" BorderColor=#0c4566/>

                                     </div>

                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Bitácora de Usuarios Telegram:</label>
                                <asp:CheckBox ID="chkUsuariosTelegram" runat="server" BorderColor=#0c4566/>

                                     </div>


                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Niveles:</label>
                                <asp:CheckBox ID="chkNiveles" runat="server" BorderColor=#0c4566/>

                                     </div>
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Planos:</label>
                                <asp:CheckBox ID="chkPlanos" runat="server" BorderColor=#0c4566/>

                                     </div>

                                 <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Panel de Tareas Programadas: </label>
                                <asp:CheckBox ID="chkAutomatizado" runat="server" BorderColor=#0c4566/>
                                     </div>
                                
                                     </div>
                                 <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Generar Tarea Programada:</label>
                                <asp:CheckBox ID="chkNuevoAuto" runat="server" BorderColor=#0c4566 />

                                     </div>
                                 <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Bitácora de Tareas Programadas:</label>
                                <asp:CheckBox ID="chkRegistroAuto" runat="server" BorderColor=#0c4566 />
                                     </div>
                                  <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Administrador RISC:</label>
                                <asp:CheckBox ID="chkRISC" runat="server" BorderColor=#0c4566 />

                                     </div>
                                          <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Bitácora de Control de Asistencia:</label>
                                <asp:CheckBox ID="chkHuella" runat="server" BorderColor=#0c4566 />

                                     </div>

                                           <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Conteo:</label>
                                <asp:CheckBox ID="chkConteo" runat="server" BorderColor=#0c4566 />

                                     </div>
                                   <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Control de Dispositivos por Botones:</label>
                                <asp:CheckBox ID="chkBotones" runat="server" BorderColor=#0c4566 />

                                     </div>

                                       <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Activacion de Sistema de Seguridad:</label>
                                <asp:CheckBox ID="chkActivacion" runat="server" BorderColor=#0c4566 />

                                     </div>

                                       <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Administrador de Aplicación M:</label>
                                <asp:CheckBox ID="chkAdminApp" runat="server" BorderColor=#0c4566 />

                                     </div>
                                       <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">DARC:</label>
                                <asp:CheckBox ID="chkDARC" runat="server" BorderColor=#0c4566 />

                                     </div>

                                 <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Drools:</label>
                                <asp:CheckBox ID="chkDrools" runat="server" BorderColor=#0c4566 />

                                     </div>

       
                                  </div>
                              
                     
                             
                          
                            <%--nuevos check--%>

                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="Button2" runat="server"  OnClick="BtnAddRecordClick1" Text="Confirmar " CssClass="btn btn-success"  />
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
            </div>
           <div>
        <a class="btn btn-danger" href="Catalogos.aspx" runat="server" role="button">Volver</a>
    </div>
  
</asp:Content>
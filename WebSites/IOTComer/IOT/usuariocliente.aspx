<%@ Page Title="Usuarios Cliente"  Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup ="true" CodeFile="usuariocliente.aspx.cs" Inherits="IOT_usuariocliente" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent2">
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo de Administradores del Cliente</a>
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
    color:forestgreen;
     font-size:20px;
}
         .icon-actualizar {
    color:blue;
     font-size:20px;
}
    </style>
   <br />
   <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este cátalogo se dará de alta los usuarios qaue podrán ingresar al portal y a su vez se podrán Deshabilitar.</a>
        </div>
        <div class="alert alert-warning" role="alert">
 <a class="alert-link">Validación : El nombre de usuario no puede ser mayor a 10 caracteres.</a>
            </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
                     
    <!-- Inicia Modal Para Nuevo Registro-->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
    <div class="form-horizontal">
     <%--   <asp:ValidationSummary runat="server" CssClass="text-danger" />--%>
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Nombre de usuario</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="UserName"  placeholder="UserName" CssClass="form-control"  MaxLength="10" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="El campo de nombre de usuario es obligatorio.">
                </asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="UserName" ValidationExpression="^[a-zA-Z0-9\s]*$" errormessage="Ingrese Solo Texto" ValidationGroup="InsertFab"/>
            </div>
        </div>
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-2 control-label">Nombre </asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="Nombre" placeholder="Nombre" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre" CssClass="text-danger" ErrorMessage="El campo de nombre es obligatorio." >
                </asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="Nombre" ValidationExpression="^[a-zA-Z\s]*$" errormessage="Ingrese Solo Texto" ValidationGroup="InsertFab"/>
            </div>
            <asp:Label runat="server" AssociatedControlID="Apellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="Apellido" placeholder="Apellido" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Apellido" CssClass="text-danger" ErrorMessage="El campo de apellido  es obligatorio." >
                </asp:RequiredFieldValidator> 
                <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="Apellido" ValidationExpression="^[a-zA-Z\s]*$" errormessage="Ingrese Solo Texto" ValidationGroup="InsertFab"/>
            </div>
          </div>
          <div class="row">
                  <asp:Label runat="server" AssociatedControlID="Clientes" CssClass="col-md-2 control-label">Cliente</asp:Label>
                  <div class="col-md-2">
                     <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Clientes" AutoPostBack="true" OnSelectedIndexChanged="Clientes_SelectedIndexChanged"/>
                   </div>
                    <asp:Label runat="server" CssClass="col-md-1 control-label"><b>Rol</b></asp:Label>
                   <div class="col-md-2">
                      <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Roles" AutoPostBack="true"/>
                </div>
               <asp:Label runat="server" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
              <div class="col-md-1">
                      <asp:DropDownList runat="server" BorderColor=#0c4566  ID="dar" AutoPostBack="true"/>
                </div>
              </div>
              <br/>
              <br/>
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="Password" placeholder="Contraseña" TextMode="Password" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
                <asp:RegularExpressionValidator ID="valPassword" runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El minimo de caracteres debe de ser 6" ValidationExpression=".{6}.*" />
            </div>
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="ConfirmPassword"  placeholder="Contraseña" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
            </div>
          
           <div class="col-md-2">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Habilitado" Visible="false">
           <asp:ListItem Value ="Habilitado"></asp:ListItem>
            </asp:DropDownList>
           </div>
        </div>   
        <div class="row">
            <div class="col-md-offset-3 col-md-10">
                <asp:Button runat="server" BorderColor=#2e7d32 OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-success" Width="162px"  />
            </div>
               </div>
        </div>
    </div>
            </div>
                   </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
      <br/>

        <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
              Buscar:&nbsp;<asp:TextBox ID="txtSearch" style="text-align:center" runat="server" OnTextChanged="Search" AutoPostBack="true" ></asp:TextBox>
            <br />
       <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                         CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Username" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario" SortExpression="UserName" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Apellido" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellido" SortExpression="Apellido" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Habilitado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField> 
             <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
<%--            <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField> --%>
             <asp:ButtonField CommandName="habilitado" HeaderText="Habilitar/Deshabilitar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-user icon-success"></i>' />
          <%--  <asp:buttonField  CommandName="habilitado" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Habilitar/Deshabilitar" HeaderText="Habilitar/Deshabilitar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
        </Columns>
  
    </asp:GridView>
    
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
            <div>
        <a class="btn btn-danger" href="CatalogoUsuariosAdr.aspx" runat="server" role="button">Volver</a>
    </div>
    </div>


    <!---->
    <!-- MODAL HABILITADO --> 
            <div id="habilita" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="HabiModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="habiModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table">
                                   <tr>
                                    <td>Usuario: 
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                              <tr>
                                    <td>Estatus: 
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>    
                                </tr>
                            <tr>
                                    <td>Estatus:
                                    <asp:DropDownList  runat="server"   ID="Hab" BorderColor=#0c4566>
                                   <asp:ListItem Value ="Habilitado"></asp:ListItem>
                                   <asp:ListItem Value ="Deshabilitado"></asp:ListItem>
                                    </asp:DropDownList>  
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="Label4" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="Button1" runat="server" OnClick="BtnHabilitado" Text="Guardar" CssClass="btn btn-success" ValidationGroup="actualizar" />
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
       <!-- Edit Modal Starts here -->
     <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                      <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table">
                               
                                <tr><td>Usuario:
                                <asp:Label ID="txtUsuario" runat="server"></asp:Label>
                                </td></tr>

                                <tr><td>Nombre:
                                <asp:TextBox ID="txtNombre" runat="server" BorderColor=#0c4566></asp:TextBox> 
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                                CssClass="text-danger" ErrorMessage="El campo de nombre es obligatorio." ValidationGroup="Actualizar" />      
                                </td></tr>
                               
                                <tr><td>Apellido:
                                <asp:TextBox ID="txtApellido" runat="server"  BorderColor=#0c4566></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido"
                                CssClass="text-danger" ErrorMessage="El campo de apellido es obligatorio." ValidationGroup="Actualizar" />
                                </td></tr>
                            </table>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" ValidationGroup="Actualizar" Text="Guardar" CssClass="btn btn-success" />
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
     <!-- Inicia Modal Para Eliminar-->
            <div id="deleteModal" class="modal fade"  tabindex="-1"  aria-labelledby="delModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="delModalLabel" style="color:azure">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upDel" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            Desea Eliminar este registro?
                            <asp:HiddenField ID="hfID" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server" ValidationGroup="Eliminarr" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
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
    

            
</asp:Content>

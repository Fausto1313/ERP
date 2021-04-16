<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo de Clientes</a>
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
    color: red;
     font-size:20px;

}
         .icon-actualizar {
    color:blue;
     font-size:20px;
}
    </style>
<div class="alert alert-danger" role="alert">
<a class="alert-link"> En este catálogo podrás dar el alta de todos los clientes correspondientes .
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <!--- validaciones--->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->

      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
            Buscar:&nbsp;<asp:TextBox ID="txtSearch" style="text-align:center" runat="server" OnTextChanged="Search" AutoPostBack="true" ></asp:TextBox>
             

            <div style="overflow:auto; width:100%;" > 
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>

            </asp:BoundField>
            <asp:BoundField DataField="RazonSocial" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Razón Social" SortExpression="RazonSocial" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Pais" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="País" SortExpression="Pais" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" SortExpression="Estado" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Código Postal" SortExpression="CP" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CalleNumero" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Calle y Número" SortExpression="CalleNumero" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
      
      <asp:BoundField DataField="Colonia" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Colonia" SortExpression="Colonia" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:BoundField DataField="Contacto" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Contacto" SortExpression="Contacto" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:BoundField DataField="Telefono" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Teléfono" SortExpression="Telefono" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:BoundField DataField="Mail" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="E-mail" SortExpression="Mail" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
              <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
              <%-- <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
     </div>
     <br/>
         <asp:Button ID="btnAdd" runat="server" BorderColor=#0c4566 ValidationGroup="Eliminar" OnClick="BtnAddClick" Text="Agregar Cliente" CssClass="btn btn-success" Width="162px"/>
            </ContentTemplate>
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
        <br />
        <div class="container">
            <div class="row">
              <div class="col-md-3">
                  <p>Subir Icono para el cliente: (Solo tipo .PNG)
                  Cliente
                  <asp:DropDownList ID="Cli" runat="server" ></asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"  Display="Dynamic" ErrorMessage="El Cliente es obligatorio" ControlToValidate="Cli" ForeColor="Red">
                  </asp:RequiredFieldValidator>
                  </p>
                   </div>
                <div class="col-md-3">
                   Imagen Agregada:
                  <br />
                  <asp:Image ID="imgPreview"  ImageUrl="~/recursos/subirimg_01.png" Width="100"  runat="server" />
                  </div>
                <div class="col-md-3"></div>
                  Elegir Imagen: 
                  <asp:FileUpload ID="fuploadimagen" accept=".jpg,.png" runat="server" CssClass="form-control"/>
                  <br />
                  <asp:Button ID="Icono" runat="server" Text="Guardar icono" CssClass="btn btn-info" OnClick="BtnIcono" ValidationGroup="validar"/>
              </div>
                </div>
        </div>
     <br />
            <div>
            <a class="btn btn-danger" href="CatalogoUsuariosAdr.aspx" runat="server" role="button">Volver</a>
            </div>
        <!--Comienza Modal Para editar Registro-->
        <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="inputEmail3"  class="col-md-3 control-label">ID</label>
                                <asp:Label ID="lblID"   runat="server"></asp:Label>
                                     </div>
                                 <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Razón Social:</label>
                                <asp:TextBox ID="txtRazonSocial"  runat="server" BorderColor=#0c4566  ></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo razón social es obligatorio" ControlToValidate="txtRazonSocial" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtRazonSocial" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$" errormessage="No acepta caracteres especiales " />
                                </div>
                                    <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">País:</label>
                                <asp:TextBox ID="txtPais"  placeholder="Pais" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo país es obligatorio" ControlToValidate="txtPais" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator9" Display="Dynamic" controltovalidate="txtPais" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="No se aceptan numeros en este campo!" />
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estado:</label>
                                <asp:TextBox ID="txtEstado"  placeholder="Estado" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  Display="Dynamic" ErrorMessage="El campo estado es obligatorio" ControlToValidate="txtEstado" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator10" Display="Dynamic" controltovalidate="txtEstado" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="No se aceptan numeros en este campo!" />
                                </div>
                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Codigo Postal:</label>
                                <asp:TextBox ID="txtCP"  placeholder="CP" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  Display="Dynamic" ErrorMessage="El campo codigo postal es obligatorio" ControlToValidate="txtCP" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator11" Display="Dynamic" controltovalidate="txtCP" ValidationExpression="^[0-9]*" errormessage="Ingrese Solo Numeros!" />
                                </div>
                              <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Calle y Número:</label>
                                <asp:TextBox ID="txtCalleNumero"  placeholder="Calle y Número" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  Display="Dynamic" ErrorMessage="El campo calle es obligatorio" ControlToValidate="txtCalleNumero" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator12" Display="Dynamic" controltovalidate="txtCalleNumero" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$" errormessage="Ingrese Solo Texto y Numeros" />
                                </div>
                                    
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Colonia:</label>
                                <asp:TextBox ID="txtColonia"  placeholder="Colonia" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"  Display="Dynamic" ErrorMessage="El campo colonia es obligatorio" ControlToValidate="txtColonia" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator13" Display="Dynamic" controltovalidate="txtColonia" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese Solo Texto" />
                                </div>
                                          <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Contacto:</label>
                                <asp:TextBox ID="txtContacto"  placeholder="Contacto" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"  Display="Dynamic" ErrorMessage="El campo contacto es obligatorio" ControlToValidate="txtContacto" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                </div>
                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono"  placeholder="Telefono" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"  Display="Dynamic" ErrorMessage="El campo teléfono es obligatorio" ControlToValidate="txtTelefono" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator14" Display="Dynamic" controltovalidate="txtTelefono" ValidationExpression="^[0-9]*" errormessage="Ingrese Solo Numeros!" />
                                </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Email:</label>
                                <asp:TextBox ID="txtMail"  placeholder="Email"  runat="server" BorderColor=#0c4566 ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"  Display="Dynamic" ErrorMessage="El campo email es obligatorio" ControlToValidate="txtMail" ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail" ErrorMessage="Formato de correo inválido"></asp:RegularExpressionValidator>   
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estatus:</label>
                                    <asp:DropDownList runat="server" ID="Status2" BorderColor=#0c4566>
                                        <asp:ListItem Text="Activo" Value="Activo"/>
                                        <asp:ListItem Text="Inactivo" Value="Inactivo" />
                                    </asp:DropDownList>
                                </div>
                            </table>
                                 </div>
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
                            <asp:Button ID="BtnDelete" runat="server" ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
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
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Cliente</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                    <ContentTemplate>
                         <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="txtID1"  runat="server" BorderColor=#0c4566></asp:Label>

                                     </div>
                                   <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Razón Social:</label>
                                <asp:TextBox ID="txtRazonSocial1"  placeholder="Razón Social" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo razón social es obligatorio" ControlToValidate="txtRazonSocial1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtRazonSocial1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>       
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">País:</label>
                                <asp:TextBox ID="txtPais1"  placeholder="País" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic" ErrorMessage="El campo país es obligatorio" ControlToValidate="txtPais1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtPais1" ValidationExpression="^[a-zA-Za-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>
                                </div>
                            <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estado:</label>
                                <asp:TextBox ID="txtEstado1"  placeholder="Estado" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  Display="Dynamic" ErrorMessage="El campo estado es obligatorio" ControlToValidate="txtEstado1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtEstado1" ValidationExpression="^[a-zA-Za-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>
                                </div>
                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Codigo Postal:</label>
                                <asp:TextBox ID="txtCP1"  placeholder="CP" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  Display="Dynamic" ErrorMessage="El campo codigo postal es obligatorio" ControlToValidate="txtCP1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtCP1" ValidationExpression="^[0-9 ]*" errormessage="Ingrese Solo Numeros!" ValidationGroup="groupInsert"/>
                                </div>
                              <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Calle y Número:</label>
                                <asp:TextBox ID="txtCalleNumero1"  placeholder="Calle y Numero" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  Display="Dynamic" ErrorMessage="El campo calle es obligatorio" ControlToValidate="txtCalleNumero1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtCalleNumero1" ValidationExpression="^[0-9-a-z-A-ZñÑáéíóúÁÉÍÓÚ\s-#]*$" errormessage="Ingrese Solo Texto" ValidationGroup="groupInsert"/>
                                </div>
                                    
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Colonia:</label>
                                <asp:TextBox ID="txtColonia1"  placeholder="Colonia" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  Display="Dynamic" ErrorMessage="El campo colonia es obligatorio" ControlToValidate="txtColonia1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtColonia1" ValidationExpression="^[a-z-A-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese Solo Texto" ValidationGroup="groupInsert"/>
                                </div>
                                          <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Contacto:</label>
                                <asp:TextBox ID="txtContacto1"  placeholder="Contacto" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  Display="Dynamic" ErrorMessage="El campo contacto es obligatorio" ControlToValidate="txtContacto1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                </div>
                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono1"  placeholder="Teléfono" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  Display="Dynamic" ErrorMessage="El campo teléfono es obligatorio" ControlToValidate="txtTelefono1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator8" Display="Dynamic" controltovalidate="txtTelefono1" ValidationExpression="^[0-9]*" errormessage="Ingrese Solo Numeros!" ValidationGroup="groupInsert"/>
                                </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Email:</label>
                                <asp:TextBox ID="txtMail1"  placeholder="Email"  runat="server" BorderColor=#0c4566 ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  Display="Dynamic" ErrorMessage="El campo email es obligatorio" ControlToValidate="txtMail1" ForeColor="Red" ValidationGroup="groupInsert">
                                            </asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail1" ErrorMessage="Formato de correo inválido" ValidationGroup="groupInsert"></asp:RegularExpressionValidator>   
                                </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estatus:</label>
                                    <asp:DropDownList runat="server" ID="Status" BorderColor=#0c4566>
                                        <asp:ListItem Text="Activo" Value="Activo"/>
                                        <asp:ListItem Text="Inactivo" Value="Inactivo" />
                                    </asp:DropDownList>
                               </div>
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="BtnAddRecordClick" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="groupInsert"/>
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
            <!--Finaliza Modal Para Nuevo Registro-->
<!--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--> 
</asp:Content>



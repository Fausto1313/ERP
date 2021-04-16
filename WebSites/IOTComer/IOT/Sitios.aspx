<%@ Page Language="C#"MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Sitios.aspx.cs" Inherits="Sitios" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
          <br />
     <script src="//unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo de Sitios</a>
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
    color:green;
     font-size:20px;
}
         .icon-actualizar {
    color:blue;
     font-size:20px;
}
         </style>
   <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> En este catálogo se podrá dar de alta todos los sitios de acuerdo al cliente correspondiente.</a>
</div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->

      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
          Busqueda:&nbsp;<asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" AutoPostBack="true"></asp:TextBox>
              <br>
              <br />
            <div style="overflow:auto; width:100%;" > 
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
        <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ID_cliente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente" SortExpression="Cliente" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="C_Sitio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Sitio" SortExpression="Sitio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripción" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" SortExpression="Estado" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Ciudad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Ciudad" SortExpression="Ciudad" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="CP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Código Postal" SortExpression="Codigo Postal" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CalleNumero" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="CalleNúmero" SortExpression="CalleNumero" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Colonia" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Colonia" SortExpression="Colonia" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Telefono" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Teléfono" SortExpression="Telefono" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Mail" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Mail" SortExpression="Mail" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Seguridad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Seguridad" SortExpression="Seguridad" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="NOIP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="NOIP" SortExpression="NOIP" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="NOIPS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="NOIP Secundaria" SortExpression="NOIPS" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField DataField="MultipleNOIP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Multiple NOIP" SortExpression="MultipleNOIP" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
              <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
               <%--<asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
              <asp:ButtonField CommandName="sincSitio" HeaderText="Sincronizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-refresh icon-success"></i>' />
            <%--<asp:ButtonField CommandName="sincSitio" ButtonType="Button" ControlStyle-CssClass="btn btn-success" Text="Sincronizar" HeaderText="Monitoreo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 />--%>

        </Columns>
  
    </asp:GridView>
     </div>
     <br/>
         <asp:Button ID="btnAdd" runat="server" BorderColor=#0c4566 ValidationGroup="Eliminar" OnClick="BtnAddClick" Text="Agregar Sitio" CssClass="btn btn-success" Width="162px"/>
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
 </div>
    <div>
                  <a class="btn btn-danger" href="Configuraciones.aspx" runat="server" role="button">Volver</a>
                </div>
        <!--Comienza Modal Para actualizar Registro-->
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
                                    <label for="inputEmail3" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="lblID"  runat="server"></asp:Label>
                                     </div>
                                 <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Cliente:</label>
                               <asp:DropDownList runat="server" ID="Clientes" BorderColor=#0c4566></asp:DropDownList>
                                </div>
                                    <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Sitio:</label>
                                <asp:TextBox ID="txtSitio"  placeholder="Sitio" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo sitio es obligatorio" ControlToValidate="txtSitio" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator9" Display="Dynamic" controltovalidate="txtSitio" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Descripción:</label>
                                <asp:TextBox ID="textDescripcion"  placeholder="Descripción" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="textDescripcion" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator16" Display="Dynamic" controltovalidate="textDescripcion" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9 ]*$" errormessage="Ingrese Solo Texto o números!" />
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estado:</label>
                                <asp:TextBox ID="txtEstado"  placeholder="Estado" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  Display="Dynamic" ErrorMessage="El campo estado es obligatorio" ControlToValidate="txtEstado" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator10" Display="Dynamic" controltovalidate="txtEstado" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Ciudad:</label>
                                <asp:TextBox ID="txtCiudad"  placeholder="Ciudad" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"  Display="Dynamic" ErrorMessage="El campo ciudad es obligatorio" ControlToValidate="txtCiudad" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator17" Display="Dynamic" controltovalidate="txtCiudad" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Codigo Postal:</label>
                                <asp:TextBox ID="txtCP"  placeholder="CP" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  Display="Dynamic" ErrorMessage="El campo codigo postal es obligatorio" ControlToValidate="txtCP" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator11" Display="Dynamic" controltovalidate="txtCP" ValidationExpression="^[0-9 ]*" errormessage="Ingrese Solo Numeros!" />
                                </div>
                              <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Calle y Numero:</label>
                                <asp:TextBox ID="txtCalleNumero"  placeholder="Calle y Numero" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  Display="Dynamic" ErrorMessage="El campo calle es obligatorio" ControlToValidate="txtCalleNumero" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator12" Display="Dynamic" controltovalidate="txtCalleNumero" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9# ]*$" errormessage="Ingrese Solo Texto" />
                                </div>
                                    
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Colonia:</label>
                                <asp:TextBox ID="txtColonia"  placeholder="Colonia" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"  Display="Dynamic" ErrorMessage="El campo colonia es obligatorio" ControlToValidate="txtColonia" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator13" Display="Dynamic" controltovalidate="txtColonia" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto" />
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
                                    <asp:DropDownList runat="server" ID="Dstatus" BorderColor=#0c4566>
                                        <asp:ListItem Text="Activo" Value="Activo"/>
                                        <asp:ListItem Text="Inactivo" Value="Inactivo" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">NOIP:</label>
                                <asp:TextBox ID="txtNOIP"  placeholder="NOIP" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"  Display="Dynamic" ErrorMessage="El campo NOIP es obligatorio" ControlToValidate="txtNOIP" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator18" Display="Dynamic" controltovalidate="txtNOIP" ValidationExpression="^[a-zA-Z0-9-(.:)]*$" errormessage="Ingrese Solo Texto" />
                                </div>
                                 <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">NOIP Secundaria:</label>
                                <asp:TextBox ID="txtNOIPS"  placeholder="NOIPS" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"  Display="Dynamic" ErrorMessage="El campo NOIP Secundaria es obligatorio" ControlToValidate="txtNOIPS" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator21" Display="Dynamic" controltovalidate="txtNOIPS" ValidationExpression="^[a-zA-Z0-9-(.:)]*$" errormessage="Ingrese Solo Texto" />
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">¿Multiple NOIP?</label>
                                    <asp:DropDownList runat="server" ID="MultipleNOIP3" BorderColor="#0c4566">
                                        <asp:ListItem Text="Si" Value="1"/>
                                        <asp:ListItem Text="No" Value="0" />
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
             
    <!-- Edit Modal Ends here 
   
      <!-- Inicia Modal Para Nuevo Registro-->
             <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="addModalLabel" style="color:azure">Insertar Registro</h3>
                </div>
                        <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel1" class="form-group" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="inputEmail3" class="col-md-3 control-label">ID</label>
                                     </div>
                                 <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Cliente:</label>
                               <asp:DropDownList runat="server" ID="Clientes2" BorderColor=#0c4566></asp:DropDownList>
                                </div>
                                    <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Sitio:</label>
                                <asp:TextBox ID="txtSitio1"  placeholder="Sitio" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo sitio es obligatorio" ControlToValidate="txtSitio1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtSitio1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>
                                </div>
                                <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Descripción:</label>
                                <asp:TextBox ID="textDescripcion1"  placeholder="Descripción" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="textDescripcion1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="textDescripcion1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9 ]*$" errormessage="Ingrese Solo Texto o nemeros!" ValidationGroup="groupInsert"/>
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estado:</label>
                                <asp:TextBox ID="txtEstado1"  placeholder="Estado" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic" ErrorMessage="El campo estado es obligatorio" ControlToValidate="txtEstado1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtEstado1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Ciudad:</label>
                                <asp:TextBox ID="txtCiudad1"  placeholder="Ciudad" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  Display="Dynamic" ErrorMessage="El campo ciudad es obligatorio" ControlToValidate="txtCiudad1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtCiudad1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>
                                </div>
                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Codigo Postal:</label>
                                <asp:TextBox ID="txtCP1"  placeholder="CP" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  Display="Dynamic" ErrorMessage="El campo codigo postal es obligatorio" ControlToValidate="txtCP1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtCP1" ValidationExpression="^[0-9 ]*" errormessage="Ingrese Solo Numeros!" ValidationGroup="groupInsert"/>
                                </div>
                              <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Calle y Numero:</label>
                                <asp:TextBox ID="txtCalleNumero1"  placeholder="Calle y Numero" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  Display="Dynamic" ErrorMessage="El campo calle es obligatorio" ControlToValidate="txtCalleNumero1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtCalleNumero1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9# ]*$" errormessage="Ingrese Solo Texto" ValidationGroup="groupInsert"/>
                                </div>
                                    
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Colonia:</label>
                                <asp:TextBox ID="txtColonia1"  placeholder="Colonia" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  Display="Dynamic" ErrorMessage="El campo colonia es obligatorio" ControlToValidate="txtColonia1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtColonia1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" errormessage="Ingrese Solo Texto" ValidationGroup="groupInsert"/>
                                </div>

                                      <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono1" placeholder="Teléfono" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  Display="Dynamic" ErrorMessage="El campo telefono es obligatorio" ControlToValidate="txtTelefono1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator8" Display="Dynamic" controltovalidate="txtTelefono1" ValidationExpression="^[0-9]*" errormessage="Ingrese Solo Numeros!" ValidationGroup="groupInsert"/>
                                </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Email:</label>
                                <asp:TextBox ID="txtMail1"  placeholder="Email"  runat="server" BorderColor=#0c4566 ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  Display="Dynamic" ErrorMessage="El campo email es obligatorio" ControlToValidate="txtMail1" ForeColor="Red" ValidationGroup="groupInsert">
                                            </asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMail1" ErrorMessage="Formato de correo inválido" ValidationGroup="groupInsert"></asp:RegularExpressionValidator>   
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estatus:</label>
                                    <asp:DropDownList runat="server" ID="Dstatus1" BorderColor=#0c4566 ValidationGroup="groupInsert">
                                        <asp:ListItem Text="Activo" Value="Activo"/>
                                        <asp:ListItem Text="Inactivo" Value="Inactivo" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">NOIP:</label>
                                <asp:TextBox ID="txtNOIP1"  placeholder="NOIP" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  Display="Dynamic" ErrorMessage="El campo NOIP es obligatorio" ControlToValidate="txtNOIP1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator20" Display="Dynamic" controltovalidate="txtNOIP1" ValidationExpression="^[a-zA-Z0-9-(.:)]*$" errormessage="Ingrese Solo Texto" ValidationGroup="groupInsert"/>
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">NOIP Secundaria:</label>
                                <asp:TextBox ID="txtNOIP2"  placeholder="NOIP SECUNDARIA" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"  Display="Dynamic" ErrorMessage="El campo NOIP Secundaria es obligatorio" ControlToValidate="txtNOIP2" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator22" Display="Dynamic" controltovalidate="txtNOIP2" ValidationExpression="^[a-zA-Z0-9-(.:)]*$" errormessage="Ingrese Solo Texto" ValidationGroup="groupInsert"/>
                                </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">¿Múltiple NOIP? </label>
                                    <asp:DropDownList runat="server" ID="MultipleNOIP2" BorderColor="#0c4566" ValidationGroup="groupInsert">
                                        <asp:ListItem Text="Si" Value="1"/>
                                        <asp:ListItem Text="No" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </table>
                                 </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult1" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="Button1" runat="server" OnClick="BtnAddRecordClick" Text="Guardar" CssClass="btn btn-success" ValidationGroup="groupInsert"/>
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
             
            <!--Finaliza Modal Para Nuevo Registro-->
<!--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--> 
</asp:Content>



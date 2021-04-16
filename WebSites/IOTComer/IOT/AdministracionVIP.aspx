<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionVIP.aspx.cs" Inherits="IOT_AdministracionVIP" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Usuarios VIP</a>
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
    color:red;
     font-size:20px;
}
   .icon-cambiar {
    color:blue;
     font-size:20px;
}
    </style>
<!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrá agregar los usuarios (comensales) que podran visualizar el menú en la aplicación ADDAR RISC Y ADDAR CONTROL.
    <p>      
    INSTRUCCION: Para agregar los usuarios deberás dar clic en el botón verde y rellenar la información solicitada.
        </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="ID"
                        CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>      
            <asp:BoundField DataField="Usuario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario" SortExpression="Usuario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ApePat" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellido Paterno" SortExpression="ApePat" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ApeMat" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellido Materno" SortExpression="ApeMat" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Direccion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Direccion" SortExpression="Direccion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Telefono" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Telefono" SortExpression="Telefono" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
              <asp:ButtonField CommandName="updUser" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
           <%-- <asp:buttonField  CommandName="updUser" ButtonType="Button"  ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
              <asp:ButtonField CommandName="deleteRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
          <%-- <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
   <asp:Button ID="btnAdd" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar" OnClick="BtnAddClick" Text="Agregar Usuario" CssClass="btn btn-success" Width="162px" />
             <%-- <asp:Button ID="btnAdd2" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar2" OnClick="BtnAddClick2" Text="Reasignar Comida" CssClass="btn btn-primary" Width="162px" />--%>

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
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="inputEmail3" class="col-md-3 control-label">Usuario</label>
                                <asp:Label ID="lblUser"  runat="server"></asp:Label>
                                     </div>
                               
                                    <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Nombre:</label>
                                <asp:TextBox ID="txtNombre"  placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNombre" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtNombre" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
                                </div>

                                  <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Apellido Paterno:</label>
                                <asp:TextBox ID="txtAP"  placeholder="Apellido Paterno" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo apellido paterno es obligatorio" ControlToValidate="txtAP" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtAP" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                  <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Apellido Materno:</label>
                                <asp:TextBox ID="txtAM"  placeholder="Apellido Materno" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo apellido materno es obligatorio" ControlToValidate="txtAM" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtAM" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                  <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Dirección:</label>
                                <asp:TextBox ID="txtDir"  placeholder="Direccion" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  Display="Dynamic" ErrorMessage="El campo dirección es obligatorio" ControlToValidate="txtDir" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator12" Display="Dynamic" controltovalidate="txtDir" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$" errormessage="Ingrese Solo Texto y Numeros" />
                                </div>
                                 <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono"  placeholder="Telefono" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"  Display="Dynamic" ErrorMessage="El campo teléfono es obligatorio" ControlToValidate="txtTelefono" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator14" Display="Dynamic" controltovalidate="txtTelefono" ValidationExpression="^[0-9]*" errormessage="Ingrese Solo Numeros!" />
                                </div>
                                   <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Contrasaeña:</label>
                                <asp:TextBox ID="txtCon"  placeholder="Contraseña" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  Display="Dynamic" ErrorMessage="El campo contraseña es obligatorio" ControlToValidate="txtCon" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator11" Display="Dynamic" controltovalidate="txtCon" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$"  errormessage="Ingrese Solo Numeros!" />
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
            </div>
    <!-- Edit Modal Ends here -->

        <!-- Inicia Modal Para Eliminar-->
             <div id="deleteModal" class="modal fade"  tabindex="-1"  aria-labelledby="delModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
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
   
            <!--Finaliza Modal Para Eliminar-->

     <!-- Inicia Modal Para Nuevo Registro-->
              <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">

                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Menú</h3>
                </div>
                      <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="inputnom" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="txtID1"  runat="server"></asp:Label>
                                     </div>
                                 <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Usuario:</label>
                                <asp:TextBox ID="txtUser"  placeholder="Usuario" runat="server" BorderColor=#0c4566></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  Display="Dynamic" ErrorMessage="El campo usuario es obligatorio" ControlToValidate="txtUser" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtUser" ValidationExpression="^[0-9-a-z-A-ZñÑáéíóúÁÉÍÓÚ\s-#]*$" errormessage="Ingrese Solo Texto" ValidationGroup="InsertFab"/>
                                </div>         
                                     </div>
                                    <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Nombre:</label>
                                <asp:TextBox ID="txtNom"  placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtNom" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                    
                                </div>

                                   <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Apellido Paterno:</label>
                                <asp:TextBox ID="txtAP1"  placeholder="Apellido Paterno" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo apellido paterno es obligatorio" ControlToValidate="txtAP1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtAP1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                    
                                </div>

                                      <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Apellido Materno:</label>
                                <asp:TextBox ID="txtAM1"  placeholder="Apellido Materno" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo apellido materno es obligatorio" ControlToValidate="txtAM1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator8" Display="Dynamic" controltovalidate="txtAM1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                    
                                </div>

                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Dirección:</label>
                                <asp:TextBox ID="txtDirec"  placeholder="Direccion" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  Display="Dynamic" ErrorMessage="El campo direccion es obligatorio" ControlToValidate="txtDirec" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator9" Display="Dynamic" controltovalidate="txtDirec" ValidationExpression="^[0-9-a-z-A-ZñÑáéíóúÁÉÍÓÚ\s-#]*$" errormessage="Ingrese Solo Texto" ValidationGroup="InsertFab"/>
                                </div>

                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono1"  placeholder="Teléfono" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  Display="Dynamic" ErrorMessage="El campo teléfono es obligatorio" ControlToValidate="txtTelefono1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator10" Display="Dynamic" controltovalidate="txtTelefono1" ValidationExpression="^[0-9]*" errormessage="Ingrese Solo Numeros!" ValidationGroup="InsertFab"/>
                                </div>
                              <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Contraseña:</label>
                                <asp:TextBox ID="txtCon1"  placeholder="Contraseña" runat="server" BorderColor=#0c4566></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic" ErrorMessage="El campo contraseña es obligatorio" ControlToValidate="txtCon1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtCon1" ValidationExpression="^[0-9-a-z-A-ZñÑáéíóúÁÉÍÓÚ\s-#]*$" errorMessage ="Ingrese Solo Numeros!" ValidationGroup="InsertFab"/>
                                </div>
                            </table>
                                 </div>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="BtnAddRecordClick" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="InsertFab"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                       
                        
                    </Triggers>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
            <!--Finaliza Modal Para Nuevo Registro-->
</asp:Content>


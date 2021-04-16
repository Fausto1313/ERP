<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="AltaRFID.aspx.cs" Inherits="IOT_AltaRFID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
<nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Alta de Usuarios</a>
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
   .icon-permisos {
    color:green;
     font-size:20px;
}
    </style>
   <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrá realizar el alta de lo empleados y el codigo de RFID para el control de acceso al sitio, a su vez se les asignarán permisos para las entradas.
       <p>
          INSTRUCCION: Para mostrar la información en la tabla deberás seleccionar el filtro del Sitio
           
       </p>
    <p>
        Para asignarle acceso a una entrada deberás seleccionar el icono verde.
    </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <!-- Inicia Modal Para Nuevo Registro-->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <div class="form-horizontal">
           <div class="row">
           <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label">Sitio</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" CssClass="form-control" BorderColor=#0c4566  ID="Sitio" AutoPostBack="true" OnSelectedIndexChanged="Sitio_SelectedIndexChanged"/>
           </div>
           </div>
        <br />
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-1 control-label">Nombre:</asp:Label>
                <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="Nombre" placeholder="Nombre" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre"
                CssClass="text-danger" ErrorMessage="El campo de Nombre es obligatorio." ValidationGroup="groupInsert"/>         
                </div>
            <asp:Label runat="server" AssociatedControlID="ApellidoPat" CssClass="col-md-1 control-label">Apellido Paterno:</asp:Label>
                <div class="col-md-3">
                <asp:TextBox runat="server"  BorderColor=#0c4566 ID="ApellidoPat" placeholder="Apellido paterno" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ApellidoPat"
                CssClass="text-danger" ErrorMessage="El campo de Apellido Paterno  es obligatorio." ValidationGroup="groupInsert"/>
                </div>
            <asp:Label runat="server" AssociatedControlID="ApellidoMat" CssClass="col-md-1 control-label">Apellido Materno:</asp:Label>
                <div class="col-md-3">
                <asp:TextBox runat="server"  BorderColor=#0c4566 ID="ApellidoMat" placeholder="Apellido materno" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ApellidoMat"
                CssClass="text-danger" ErrorMessage="El campo de Apellido Materno es obligatorio." ValidationGroup="groupInsert"/>
            </div>
        </div>
        <div class="row">
        <asp:Label runat="server" AssociatedControlID="Correo" CssClass="col-md-1 control-label">Correo:</asp:Label>
                <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="Correo" placeholder="Correo" CssClass="form-control" />
                </div>
        <asp:Label runat="server" AssociatedControlID="Telefono" CssClass="col-md-1 control-label">Telefono:</asp:Label>
                <div class="col-md-3">
                <asp:TextBox runat="server" BorderColor=#0c4566  ID="Telefono" placeholder="Telefono" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Telefono"
                CssClass="text-danger" ErrorMessage="El campo de Telefono es obligatorio." ValidationGroup="groupInsert"/>  <br />
                <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" ValidationGroup="groupInsert"
                controltovalidate="Telefono" ValidationExpression="^[0-9.]*$"  CssClass="text-danger" errormessage="Ingrese solo numeros">
                </asp:RegularExpressionValidator>
                </div>
       <asp:Label runat="server" AssociatedControlID="RFID" CssClass="col-md-1 control-label">Codigo RFID:</asp:Label>
                <div class="col-md-3">
                <asp:TextBox runat="server"  BorderColor=#0c4566 ID="RFID" placeholder="Codigo RFID" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ApellidoMat"
                CssClass="text-danger" ErrorMessage="El campo de RFID es obligatorio." ValidationGroup="groupInsert"/>
            </div>
        </div>     
    </div> 
    <div class="container-fluid h-100"> 
    <div class="row w-100 align-items-center">
    <div class="col text-center">
    <asp:Button runat="server" BorderColor=#2e7d32 OnClick="CreateUser_Click" Text="Agregar" CssClass="btn btn-success" alig="center" BorderStyle="Solid" Width="155px" ValidationGroup="groupInsert"/> 
    </div>
    </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="ID"
                        CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>      
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="ApellidoPat" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellido Paterno" SortExpression="ApellidoPat" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="ApellidoMat" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellido Materno" SortExpression="ApellidoMat" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Correo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Correo" SortExpression="Correo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

          <asp:BoundField DataField="Telefono" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Telefono" SortExpression="Telefono" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

          <asp:BoundField DataField="RFID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="RFID" SortExpression="RFID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
          </asp:BoundField>
    <asp:ButtonField CommandName="actualizar" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
          <%-- <asp:buttonField  CommandName="actualizar" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
    <asp:ButtonField CommandName="asignar" HeaderText="Permisos de Acceso" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-user icon-permisos"></i>' />
         <%--  <asp:buttonField  CommandName="asignar" ButtonType="Button" ControlStyle-CssClass="btn btn-info" Text="Asignar" HeaderText="Permisos de Acceso" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
             <asp:ButtonField CommandName="deleteRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
        <%--   <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
            </ContentTemplate>
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div> 
    <div>
        <asp:Button runat="server" class="btn btn-danger" ID="volver" OnClick="volver_Click" Text="Volver"/>
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
                         <label for="input" class="col-md-3 control-label">ID:</label>
                         <asp:label ID="lblID"  runat="server"></asp:label>                                
                         </div> 
                          <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Nombre:</label>
                          <asp:TextBox ID="txtNombre" placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="Actualizar">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtNombre" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo letras" ValidationGroup="Actualizar"/>
                          </div>
                          <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Apellido Pat:</label>
                          <asp:TextBox ID="txtPaterno" placeholder="Apellido pat" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo apellido paterno es obligatorio" ControlToValidate="txtPaterno" ForeColor="Red" ValidationGroup="Actualizar">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtPaterno" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo letras" ValidationGroup="Actualizar"/>
                          </div> 
                          <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Apellido Mat:</label>
                          <asp:TextBox ID="txtMaterno" placeholder="Apellido mat" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo apellido materno es obligatorio" ControlToValidate="txtMaterno" ForeColor="Red" ValidationGroup="Actualizar">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtMaterno" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo letras" ValidationGroup="Actualizar"/>
                          </div>
                          <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Correo:</label>
                          <asp:TextBox ID="txtCorreo" placeholder="Correo" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtCorreo" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" errormessage="Formato de correo inválido" ValidationGroup="Actualizar"/>
                          </div>         
                          <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Telefono:</label>
                          <asp:TextBox ID="txtTelefono" placeholder="Telefono" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Telefono es obligatorio" ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="Actualizar">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator9" Display="Dynamic" controltovalidate="txtTelefono" ValidationExpression="^[0-9\s]*$" errormessage="Ingrese solo numeros" ValidationGroup="Actualizar"/>
                          </div>
                       </div>                              
                       </table>
                       </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnUPD" runat="server" OnClick="BtnUpdate" ValidationGroup="Actualizar" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="btnUPD" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
     <!----->
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
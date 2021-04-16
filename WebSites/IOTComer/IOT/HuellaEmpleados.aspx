<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="HuellaEmpleados.aspx.cs" Inherits="IOT_HuellaEmpleados" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Huella dactilar de empleado</a>
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
<!-- INICIA HuellaEmpleados -->
    <div class="form-horizontal">
        <div class="row" >            
             <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label">Sitio</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" BorderColor=#0c4566  AutoPostBack="true" />
            </div> 
            <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Nombre</b></asp:Label> 
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtNombre"  placeholder="Nombre" CssClass="form-control" BorderColor=#0c4566 />
                <asp:RequiredFieldValidator runat="server"   ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="El nombre es obligatorio." ValidationGroup="groupInsert"/>
            </div>    
             <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Apellido</b></asp:Label> 
            <div class="col-md-3">              
                <asp:TextBox runat="server" ID="txtApellido"  placeholder="Apellido" CssClass="form-control" BorderColor=#0c4566 />
                <asp:RequiredFieldValidator runat="server"   ControlToValidate="txtApellido" CssClass="text-danger" ErrorMessage="El apellido es obligatorio." ValidationGroup="groupInsert"/>
            </div>
            <div class="col-md-1" style="display: none">
              <asp:DropDownList runat="server" ID="Estatus" CssClass="form-control" BorderColor=#0c4566>
                  <asp:ListItem Value="Habilitado">Habilitado</asp:ListItem>
                  </asp:DropDownList>
            </div>
            </div>
      </div>    
    <br/>
  <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">            
          <ContentTemplate>
              <asp:Button runat="server" BorderColor=#2e7d32 OnClick="CreaUsuario_Click" Text="Agregar Registro" CssClass="btn btn-success" Width="162px" ValidationGroup="groupInsert"/>
<br /><br /><br />   
        <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true"
         DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand"  OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>           
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre empleado" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Apellidos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellidos" SortExpression="Apellido" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ID_checador" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID Huella" SortExpression="huella" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:buttonField  CommandName="InfoEmpleado" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Huella" HeaderText="Registro Huella" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                 </asp:buttonField>
             <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Actualizar" HeaderText="Actualizar informacion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>
             <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>
        </Columns>   
    </asp:GridView>
            </ContentTemplate>     
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="Catalogos.aspx" runat="server" role="button">Volver</a>
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
                        <asp:TextBox ID="txtNombre1" runat="server" BorderColor=#0c4566></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNombre1" ForeColor="Red" >
                        </asp:RequiredFieldValidator>    
                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtNombre1" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ/_ ]*$" errormessage="Ingrese solo texto!" />
                        <asp:Label runat="server" />
                        </td>
                        </tr>     
                        <tr>
                        <td>Apellidos:
                        <asp:TextBox ID="txtApellidos" runat="server" BorderColor=#0c4566></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Apellido es obligatorio" ControlToValidate="txtApellidos" ForeColor="Red" >
                        </asp:RequiredFieldValidator>    
                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtApellidos" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ/_ ]*$" errormessage="Ingrese solo texto!" />
                        <asp:Label runat="server" />
                        </td>
                        </tr>
                        <tr>
                        <td>ID huella:
                        <asp:TextBox ID="txtHuella" runat="server" BorderColor=#0c4566></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo ID huella es obligatorio" ControlToValidate="txtHuella" ForeColor="Red" >
                        </asp:RequiredFieldValidator>    
                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtHuella" ValidationExpression="^[0-9]*$" errormessage="Ingrese solo numeros!" />
                        <asp:Label runat="server" />
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
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="Upd_Guardar" Text="Guardar" CssClass="btn btn-success" />
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
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                </Triggers>
                </asp:UpdatePanel>
           </div>
           </div>
           </div>
    <!-- FIN MODAL ELIMINAR -->

 </asp:Content>


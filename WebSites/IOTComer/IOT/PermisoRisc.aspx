<%@ Page Language="C#"  MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="PermisoRisc.aspx.cs" Inherits="IOT_PermisoRisc" %>
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
<a class="alert-link">En este catalogo se dara de alta los roles y a su vez asignar los permisos correspondientes al usuario.</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->

   <br />

      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
         <div class="row">
           <asp:Label runat="server" AssociatedControlID="Clientes" CssClass="col-md-1 control-label">Cliente</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Clientes" AutoPostBack="true"/>
        </div>
        </div>
        </br></br>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="OnPageIndexChanging" >
        <Columns>
             <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
       <%--   <asp:BoundField DataField="RazonSocial" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente" SortExpression="ID_Cliente" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>--%>
    
             <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
                <%--<asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-info" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>

             <asp:ButtonField CommandName="Asignar" HeaderText="Asignar Permisos" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-cog icon-success"></i>' />
              <%--<asp:buttonField  CommandName="Asignar" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Asignar" HeaderText="Asignar Permisos" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>  --%> 
        </Columns>
    </asp:GridView>
   <asp:Button ID="btnAdd" runat="server" BorderColor="#0c4566" OnClick="BtnAddClick" Text="Agregar Rol" CssClass="btn btn-success" ValidationGroup="validar" Width="162px"/>
              </ContentTemplate>
          
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
                <div><br /><br />
   
                               
     
        <br /><br />
    </div>
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogoUsuariosAdr.aspx" runat="server" role="button">Volver</a>
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
      
   
   <!-- Inicia Modal Para Nuevo Registro-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
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
                                <asp:label runat="server" AssociatedControlID="txtNombre1" class="col-md-3 control-label">Nombre:</asp:label>
                                <asp:TextBox ID="txtNombre1" placeholder="Nombre del Rol" runat="server" BorderColor=#0c4566></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  ValidationExpression="string" ErrorMessage="El campo sitio es obligatorio" ControlToValidate="txtNombre1" ForeColor="Red" ValidationGroup="Agregar">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator9" Display="Dynamic" controltovalidate="txtNombre1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]*$" />
                                    </div>
                                   <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">RazonSocial</label>
                                <asp:DropDownList runat="server" ID="Cliente" BorderColor=#0c4566/>         
                                 </div> 
                            </table>
                        </div>
                            </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" ValidationGroup="Agregar" OnClick="BtnAddRecordClick" Text="Confirmar " CssClass="btn btn-success"  />
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

  
</asp:Content>
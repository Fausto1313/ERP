<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionPaquetes.aspx.cs" Inherits="IOT_AdministracionPaquetes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
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
      <a class="navbar-brand" href="#" style="color:azure">Administración de Paquetes</a>
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
    color:red;
     font-size:20px;
}
   .icon-cambiar {
    color:blue;
     font-size:20px;
}
  .icon-ver {
    color:darkgoldenrod;
     font-size:20px;
}
    </style>
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo ingresaras los paquetes o combos que maneje el restuarante y se podrán visualizar en la tabla
    <p>
        INSTRUCCION: Para agregar los productos del paquete deberás dar clic en el icono de detalle 
    </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class ="row">
                <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="txtNombre">Nombre</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtNombre" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
                 <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Precio">Precio $</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="Precio" TextMode="Number" placeholder="Insertar Valor" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Precio" CssClass="text-danger" ErrorMessage="Ingresar Valor." ValidationGroup="groupInsert"/>
                </div>
                </div>
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Button runat="server" ID="Agregar" CssClass="btn btn-success" Text="Agregar" OnClick="Agregar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />--%>
     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="GridView1" runat="server">
          <ContentTemplate>
    <asp:GridView ID="PaquetesDetalle" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="ID" CssClass="table table-hover table-striped" OnPageIndexChanging="PaquetesDetalle_PageIndexChanged" OnRowCommand="PaquetesDetalle_RowCommand" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de Paquete" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="${0:###,###,###.00}" HeaderText="Precio de Paquete" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
                 <%-- <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
              <asp:ButtonField CommandName="AddProducto" HeaderText="Productos" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-plus icon-ver"></i>' />
           <%-- <asp:buttonField  CommandName="AddProducto" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Detalle" HeaderText="Productos" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
             <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
<%--             <asp:buttonField  CommandName="delRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>--%>
            </Columns>
        </asp:GridView>
               <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" ValidationGroup="agregar" Text="Agregar Paquetes" CssClass="btn btn-success" BorderStyle="Solid" Width="162px"/>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
                <div>
                  <a class="btn btn-danger" href="AdministracionRestaurantes.aspx" runat="server" role="button">Volver</a>
                </div>


      <!-- Inicia Modal Para Nuevo Registro-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">

                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="addModalLabel" style="color:azure">Paquetes</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                
                                <tr>
                                    <td>Nombre: 
                                <asp:TextBox ID="txtNombres" placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                         
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNombres" ForeColor="Red" ValidationGroup="InsertFab">
                                        </asp:RequiredFieldValidator>    
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtNombres" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$" ErrorMessage ="Ingresa solo texto!" />   
                                    </td>
                                </tr>
                                <tr>
                                    <td>Precio $: 
                                <asp:TextBox ID="txtPrecios"  placeholder="Precio" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Precios es obligatorio" ControlToValidate="txtPrecios" ForeColor="Red"  ValidationGroup="InsertFab" >
                                            </asp:RequiredFieldValidator> 
                                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic"  controltovalidate="txtPrecios" ValidationExpression="^[0-9]+\.?[0-9]*$"  errormessage="Ingrese solo números !"/>
               
                                           
                                    </td>
                                </tr>
                                
                                                                                      
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
    <!---->


    
      <!-- Edit Modal Starts here -->
            <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Paquetes</h3>
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
                            <asp:TextBox ID="txtNomb" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtNomb" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9-#]*$" errormessage="Ingrese solo texto!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNomb" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                          
                       
                                    </td>
                                </tr>
                            <tr>
                                    <td>Precio $:
                                        <asp:TextBox ID="txtPrec" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtPrec" ValidationExpression="^[0-9]+\.?[0-9]*$" errormessage="Ingrese solo números!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Precio es obligatorio" ControlToValidate="txtPrec" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                          
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success"  />
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                       
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
                            <asp:HiddenField ID="hf" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Button2" runat="server"  ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                        </div>
                       
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
    <!-- FIN MODAL ELIMINAR -->
</asp:Content>


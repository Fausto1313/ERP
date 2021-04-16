<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionProducto.aspx.cs" Inherits="IOT_AdministracionProducto" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Administración de Productos</a>
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
  
    </style>
   <div class="alert alert-danger" role="alert">
<a class="alert-link">INSTRUCCION: Selecciona los filtros para visualizar la tabla con la información ingresada
  
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />

   <%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <%--<div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Sub">Categoria</asp:Label>
                </div>
                <div class="col-md-3">
                <asp:DropDownList runat="server" CssClass="form-control" ID="Cat" OnSelectedIndexChanged="Cat_SelectedIndexChanged" AutoPostBack="true" />
                    </div>
                <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Sub">Subcategoría</asp:Label>
                </div>
                <div class="col-md-3">
                <asp:DropDownList runat="server" CssClass="form-control" ID="Sub" />
                    </div>
            
            </div>--%>
           <%-- <br />
            <div class ="row">--%>
               <%-- <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="txtNombre">Nombre</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtNombre" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>--%>
               <%-- <div class="col-md-3">--%>
                   <%-- <asp:Label runat="server" AssociatedControlID="txtDesc">Descripcion</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtDesc" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDesc" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
                </div>--%>
          <%--  <div class="row">--%>
              <%--  <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Tamaño">Tamaño</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="Tamaño" CssClass="form-control">
                        <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                        <asp:ListItem Text="Unico" Value="Unico" />
                        <asp:ListItem Text="Chico" Value="Chico" />
                        <asp:ListItem Text="Mediano" Value="Mediano" />
                        <asp:ListItem Text="Grande" Value="Grande"/>
                        <asp:ListItem Text="Familiar" Value="Familiar" />
                    </asp:DropDownList>
                </div>--%>
              <%--  <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Precio">Precio $</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="Precio" TextMode="Number" placeholder="Insertar Valor" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDesc" CssClass="text-danger" ErrorMessage="Ingresar Valor." ValidationGroup="groupInsert"/>
                </div>
            </div>
            <br />
            <div class="row">
                 <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="Multiple">¿Alimento Fijo?</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="Multiple" CssClass="form-control">
                        <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                        <asp:ListItem Text="Si" Value="Si" />
                        <asp:ListItem Text="No" Value="No"/>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="Agregar" CssClass="btn btn-success" Text="Agregar" OnClick="Agregar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>

      <div class="form-horizontal">
          <asp:UpdatePanel runat="server">
              <ContentTemplate>

             
        <div class="row" >            
             <asp:Label runat="server" AssociatedControlID="Categoria" CssClass="col-md-1 control-label"><b>Categoria</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Categoria" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Categoria_SelectedIndexChanged" AutoPostBack="true"/>
            </div>
            <asp:Label runat="server" AssociatedControlID="Subcategoria" CssClass="col-md-3 control-label"><b>Subcategoria</b></asp:Label>
            <div class="col-md-3"> 
                <asp:DropDownList runat="server" ID="Subcategoria" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Subcategoria_SelectedIndexChanged" AutoPostBack="true"/>
            </div>
           
            </div>    
                   </ContentTemplate>
              </asp:UpdatePanel>
        </div>    

    <br />

    <!---Gridview--->


      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="GridView1" runat="server">
          <ContentTemplate>
    <asp:GridView ID="PaqueteAdmin" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          DataKeyNames="ID" CssClass="table table-hover table-striped" OnPageIndexChanging="PaqueteAdmi_PageIndexChanged" OnRowCommand="PaquetesAdmin_RowCommand" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre " SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderText="Descripcion " SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Tamaño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderText="Tamaño" SortExpression="Tamño" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="${0:###,###,###.00}" HeaderText="Precio " SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
                <%--  <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
    <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
            <%-- <asp:buttonField  CommandName="delRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>--%>
            </Columns>
        </asp:GridView>
               <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" ValidationGroup="agregar" Text="Agregar Producto" CssClass="btn btn-success" BorderStyle="Solid" Width="162px"/>
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
                    <h3 id="addModalLabel" style="color:azure">Productos</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                
                                <tr>
                                    <td>Categoria: 
                                       
                <asp:DropDownList runat="server" CssClass="form-control" ID="Cat" OnSelectedIndexChanged="Cat_SelectedIndexChanged" AutoPostBack="true"  BorderColor=#0c4566  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Categoria es obligatorio" ControlToValidate="Cat" ForeColor="Red"  >
                                       
                        </asp:RequiredFieldValidator> 
                                        </td>
                                </tr>
                                
                                <tr>

                                    <td>Subcategoria: 
                              <asp:DropDownList runat="server" CssClass="form-control" ID="Sub" BorderColor=#0c4566 />                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Subcategoria es obligatorio" ControlToValidate="Sub" ForeColor="Red"  >
                                       
                        </asp:RequiredFieldValidator> 
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>Nombre:
                                          <asp:TextBox ID="txtNombr"  placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNombr" ForeColor="Red"  ValidationGroup="groupInsert">
                                            </asp:RequiredFieldValidator> 
                                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic"  controltovalidate="txtNombr" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo Texto !"/>
                                           
                                    </td>
                                </tr>
                                <tr>
                                    <td>Descripción:
                                         <asp:TextBox ID="txtDesc"  placeholder="Descripción" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Descripción es obligatorio" ControlToValidate="txtDesc" ForeColor="Red"  ValidationGroup="groupInsert" >
                                            </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>Tamaño:
                                      <asp:DropDownList runat="server" ID="Tamaño" CssClass="form-control" BorderColor=#0c4566 >
                                        
                                        <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                                        <asp:ListItem Text="Unico" Value="Unico" />
                                        <asp:ListItem Text="Chico" Value="Chico" />
                                        <asp:ListItem Text="Mediano" Value="Mediano" />
                                        <asp:ListItem Text="Grande" Value="Grande"/>
                                        <asp:ListItem Text="Familiar" Value="Familiar" />

                                      
                      
                          </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Tamaño es obligatorio" ControlToValidate="Tamaño" ForeColor="Red"  >
                                             </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Precio $:

                                        <asp:TextBox ID="txtPre"  placeholder="Precio" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Precio es obligatorio" ControlToValidate="txtPre" ForeColor="Red"  ValidationGroup="groupInsert" >
                                            </asp:RequiredFieldValidator> 
                                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtPre" ValidationExpression="^[0-9]+\.?[0-9]*$" errormessage="Ingrese solo números !"/>
                                           
                                    </td>

                                <tr />
                                <tr>    
                                    <td>¿Alimento Fijo?
                                        <asp:DropDownList runat="server" ID="Multiple" CssClass="form-control">
                                            <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                                            <asp:ListItem Text="Si" Value="Si" />
                                            <asp:ListItem Text="No" Value="No"/>
                                        </asp:DropDownList>

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
                    <h3 id="updModalLabel" style="color:azure">Actualizar Productos</h3>
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

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtNomb" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo texto!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNomb" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                 
                                    </td>
                                </tr>


                                 <tr>
                                    <td>Descripcion:
                            <asp:TextBox ID="txtDes" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtDes" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo texto!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Descripcion es obligatorio" ControlToValidate="txtDes" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                 
                                    </td>
                                </tr>
                                
                                 <tr>
                                    <td>Tamaño:

                                         <asp:DropDownList runat="server" ID="Tama" BorderColor=#0c4566 CssClass="form-control" >
                                        
                                        <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                                        <asp:ListItem Text="Unico" Value="Unico" />
                                        <asp:ListItem Text="Chico" Value="Chico" />
                                        <asp:ListItem Text="Mediano" Value="Mediano" />
                                        <asp:ListItem Text="Grande" Value="Grande"/>
                                        <asp:ListItem Text="Familiar" Value="Familiar" />
                                      
                              </asp:DropDownList>
                                        </td>
                                     </tr>
                            <tr>

                                    <td>Precio $:
                                        <asp:TextBox ID="txtPrec" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtPrec" ValidationExpression="^[0-9]*" errormessage="Ingrese solo números!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Precio es obligatorio" ControlToValidate="txtPrec" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                          
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" ValidationGroup="InsertFab"  />
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
                            <asp:HiddenField ID="hfdf" runat="server" />
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


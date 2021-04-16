<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionExtras.aspx.cs" Inherits="IOT_AdministracionExtras" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
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
      <a class="navbar-brand" href="#" style="color:azure">Administración Extras</a>
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
   <br />

    
<%--    <asp:UpdatePanel runat ="server">
        <ContentTemplate>
    <div class="row">
    <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="txtCategoria">Nombre</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtCategoria" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoria" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
    
        <div class="col-md-3">
        <asp:Label runat="server" AssociatedControlID="txtPrecio">Nombre</asp:Label>
    </div>
        <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtPrecio" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecio" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                </div>
        
    </div>
            <div class="row">
                
    <div class="col-md-3">
        <asp:Button runat="server" ID="Guardar" OnClick="Guardar_Click" Text ="Guardar" CssClass="btn btn-success" />
    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    --%>
    <style>

        </style>
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server" CssClass="body" >
          
     
          <ContentTemplate>
              <br />
             <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
              AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="${0:###,###,###.00}" HeaderText="Precio" SortExpression="Precio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>
              
              <asp:buttonField  CommandName="delRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>
        </Columns>
  
    </asp:GridView>
         <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" ValidationGroup="agregar" Text="Agregar Extras" CssClass="btn btn-success" BorderStyle="Solid" Width="162px"/>
            </ContentTemplate>
          <Triggers>

        </Triggers>
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
                    <h3 id="addModalLabel" style="color:azure">Extras</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                
                                <tr>
                                    <td>Nombre: 
                                <asp:TextBox ID="txtNombre" placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                         
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="InsertFab">
                                        </asp:RequiredFieldValidator>    
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtNombre" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" ErrorMessage ="Ingresa solo texto!" />   
                                    </td>
                                </tr>
                                <tr>
                                    <td>Precio $: 
                                <asp:TextBox ID="txtPrecios"  placeholder="Precio" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Precios es obligatorio" ControlToValidate="txtPrecios" ForeColor="Red"  ValidationGroup="InsertFab" >
                                            </asp:RequiredFieldValidator> 
                                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic"  controltovalidate="txtPrecios" ValidationExpression="^[0-9]*" errormessage="Ingrese solo números !"/>
               
                                           
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
                    <h3 id="updModalLabel" style="color:azure">Actualizar Extras</h3>
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
                            <asp:TextBox ID="txtNom" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtNom" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" errormessage="Ingrese solo texto!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Nombre es obligatorio" ControlToValidate="txtNom" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                          
                                            
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                            <tr>
                                    <td>Precio $:
                                        <asp:TextBox ID="txtPrec" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtPrec" ValidationExpression="^[0-9]*" errormessage="Ingrese solo números!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Precio es obligatorio" ControlToValidate="txtNom" ForeColor="Red" ValidationGroup="InsertFab" >
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
                            <asp:HiddenField ID="hfID" runat="server" />
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


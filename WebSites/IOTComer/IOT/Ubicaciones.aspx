<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="UBicaciones.aspx.cs" Inherits="UBICACIONES" %>


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
      <a class="navbar-brand" href="#" style="color:azure">Catalogo de Ubicaciones de Cliente</a>
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
    <!---Validaciones--->
       <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID_Seccion" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID_Seccion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Seccion" SortExpression="ID_Seccion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Pais" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Pais" SortExpression="Pais">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Edificio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Edificio" SortExpression="Edificio">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Nivel" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel" SortExpression="Nivel">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="NO_IP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="NO_IP" SortExpression="NO_IP">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="RazonSocial" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente" SortExpression="RazonSocial">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar">
                </asp:buttonField>

        <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar ">
                </asp:buttonField>
        </Columns>
  
    </asp:GridView>
     <asp:Button ID="btnAdd" runat="server" ValidationGroup="Agregar" OnClick="BtnAddClick" Text="Agregar Ubicacion" CssClass="btn btn-primary" />
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
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

                            <table class="table">
                                <tr>
                                    <td>ID : 
                            <asp:Label ID="lblID_Seccion" runat="server"></asp:Label>
                                    </td>
                                  
                                </tr>
                                <tr>
                                    <td>Descripcion: 
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Pais :
                            <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Edificio:
                            <asp:TextBox ID="txtEdificio" runat="server"></asp:TextBox>
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                                     <tr>
                                    <td>Nivel:
                            <asp:TextBox ID="txtNivel" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            <tr>
                                    <td> NO IP:
                            <asp:TextBox ID="txtNDIP" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td> Cliente:
                                        <asp:DropDownList ID="Cliente2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Estatus: 
                                        <asp:DropDownList runat="server" ID="estat2" DataTextField="estat2" DataValueField="estat2">
                                    <asp:ListItem Text="Activo"/>
                                    <asp:ListItem Text="Inactivo" />
                                </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="Actualizar" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" />
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
                            <asp:HiddenField ID="hfidEvento" runat="server" />
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
                    <h3 id="addModalLabel" style="color:azure">Nueva Ubicación</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                     <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                
                                    <label for="input" class="col-md-3 control-label">Num</label>
                                <asp:Label ID="txtID1"  runat="server"></asp:Label>

                                     </div>
                         <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Descripcion:</label>
                                <asp:TextBox ID="txtDescripcion1"  placeholder="Descripcion" runat="server"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripcion es obligatorio" ControlToValidate="txtDescripcion1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtDescripcion1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                   <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Pais:</label>
                                <asp:TextBox ID="txtPais1"  placeholder="Pais" runat="server"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic" ErrorMessage="El campo pais es obligatorio" ControlToValidate="txtPais1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtPais1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                 <div class="form-group">
                              <label for="inputEmail3" class="col-md-3 control-label">Edificio:</label>        
                                <asp:TextBox ID="txtTipo1" placeholder="Edificio" runat="server"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="El campo edificio es obligatorio" ControlToValidate="txtTipo1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtTipo1" Display="Dynamic" ErrorMessage="*Ingresa solo Numeros" ForeColor="Red" ValidationExpression="^[0-9]*"> </asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                  <label for="input" class="col-md-3 control-label">Nivel:</label>
                                <asp:TextBox ID="txtNivel1" placeholder="Nivel" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="El campo nivel es obligatorio" ControlToValidate="txtNivel1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNivel1" Display="Dynamic" ErrorMessage="*Ingresa solo Numeros" ForeColor="Red" ValidationExpression="^[0-9]*"> </asp:RegularExpressionValidator>
                                 </div>
                                   <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">NO IP:</label>
                                <asp:TextBox ID="txtNDIP1"  placeholder="Dirección NO IP" runat="server"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ErrorMessage="El campo No IP es obligatorio" ControlToValidate="txtNDIP1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtNDIP1"   ValidationExpression="^((http|https)://)?([\w-]+\.)+[\w]+(/[\w- ./?]*)?$" errormessage="Ingrese Solo Url!" />
                              </div>
                            <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">RazonSocial</label>
                                <asp:DropDownList runat="server" ID="Cliente"/>
                                          
                                 </div> 
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Estatus</label>
                                <asp:DropDownList runat="server" ID="Estatus" DataTextField="Estatus" DataValueField="Estatus">
                                    <asp:ListItem Text="Activo"/>
                                    <asp:ListItem Text="Inactivo" />
                                </asp:DropDownList>
                                </div>
                            </table>
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
<!--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--> 
</asp:Content>